using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBYAIFace;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace FaceRecognition
{
    public partial class Form1 : Form
    {
        private SQLiteConnection conn;
        private List<Person> personList;

        float identifyThreshold = 0.7f;

        public Form1()
        {
            InitializeComponent();

            textBoxMachineCode.Text = FaceSDK.GetMachineCode();

            try
            {
                string license = File.ReadAllText("license.txt");
                int ret = FaceSDK.SetActivation(license);
                if (ret == (int)SDK_ERROR.SDK_SUCCESS)
                {
                    ret = FaceSDK.InitSDK("data");
                    if(ret == (int)SDK_ERROR.SDK_SUCCESS)
                    {
                        MessageBox.Show("Init Successful!");
                    }
                    else
                    {
                        MessageBox.Show("Init Failed!");
                    }
                }
                else
                {
                    throw new Exception("Activtaion Failure!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Activtaion Failure!");
            }

            InitDatabase();
            RefreshListView();
        }

        public void InitDatabase()
        {
            // Get the database path
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "person.db");

            // Create or open the database
            conn = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            conn.Open();

            // Create table if it doesn't exist
            string createTableQuery = @"CREATE TABLE IF NOT EXISTS person (
                                name TEXT,
                                faceJpg BLOB,
                                templates BLOB)";
            using (var command = new SQLiteCommand(createTableQuery, conn))
            {
                command.ExecuteNonQuery();
            }

            personList = LoadAllPersons();
        }

        public List<Person> LoadAllPersons()
        {
            var persons = new List<Person>();

            // Query the table for all persons.
            var command = new SQLiteCommand("SELECT * FROM person", conn);
            var reader = command.ExecuteReader();

            // Convert the data into a List<Person>.
            while (reader.Read())
            {
                var person = new Person(reader["name"].ToString(), (byte[])reader["faceJpg"], (byte[])reader["templates"]);
                persons.Add(person);
            }

            return persons;
        }


        public void InsertPerson(Person person, SQLiteConnection dbConnection)
        {
            string insertQuery = @"INSERT OR REPLACE INTO person (name, faceJpg, templates) 
                           VALUES (@name, @faceJpg, @templates)";

            using (var command = new SQLiteCommand(insertQuery, dbConnection))
            {
                command.Parameters.AddWithValue("@name", person.Name);
                command.Parameters.AddWithValue("@faceJpg", person.FaceJpg);
                command.Parameters.AddWithValue("@templates", person.Templates);

                command.ExecuteNonQuery();
            }

            // Optionally update the UI or list after insertion.
            personList.Add(person);
        }

        public void DeleteAllPerson()
        {
            using (var command = new SQLiteCommand("DELETE FROM person", conn))
            {
                command.ExecuteNonQuery();
            }

            personList.Clear();
        }

        public void RefreshListView()
        {
            this.listView1.Clear();
            this.listView1.Columns.Add("Person", 300);

            // Create an ImageList
            var imageList = new ImageList();
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageSize = new Size(60, 60);

            for (int i = 0; i < personList.Count; i++)
            {
                String itemText = $"item{i + 1}";
                imageList.Images.Add(itemText, ConvertJpgByteArrayToBitmap(personList[i].FaceJpg));
            }

            listView1.SmallImageList = imageList;

            for(int i = 0; i < personList.Count; i ++)
            {
                String itemText = $"item{i + 1}";
                // Add items to the ListView with images and text
                listView1.Items.Add(new ListViewItem
                {
                    Text = personList[i].Name,
                    ImageKey = itemText
                });
            }

        }

        public static Bitmap ConvertTo24bpp(Image img)
        {
            var bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (var gr = Graphics.FromImage(bmp))
                gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            return bmp;
        }


        public static Bitmap CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        public static Image LoadImageWithExif(String filePath)
        {
            try
            {
                Image image = Image.FromFile(filePath);

                // Check if the image has EXIF orientation data
                if (image.PropertyIdList.Contains(0x0112))
                {
                    int orientation = image.GetPropertyItem(0x0112).Value[0];

                    switch (orientation)
                    {
                        case 1:
                            // Normal
                            break;
                        case 3:
                            // Rotate 180
                            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case 6:
                            // Rotate 90
                            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case 8:
                            // Rotate 270
                            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        default:
                            // Do nothing
                            break;
                    }
                }

                return image;
            }
            catch (Exception e)
            {
                throw new Exception("Image null!");
            }
        }

        public byte[] BitmapToJpegByteArray(Bitmap bitmap)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Save the Bitmap as JPEG to the MemoryStream
                bitmap.Save(memoryStream, ImageFormat.Jpeg);
                // Return the byte array
                return memoryStream.ToArray();
            }
        }

        public static Bitmap ConvertJpgByteArrayToBitmap(byte[] jpgData)
        {
            using (MemoryStream ms = new MemoryStream(jpgData))
            {
                return new Bitmap(ms);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                String fileName = openFileDialog1.FileName;

                Image image = null;
                try
                {
                    image = LoadImageWithExif(fileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Unknown Format!");
                    return;
                }

                Bitmap imgBmp = ConvertTo24bpp(image);
                BitmapData bitmapData = imgBmp.LockBits(new Rectangle(0, 0, imgBmp.Width, imgBmp.Height), ImageLockMode.ReadWrite, imgBmp.PixelFormat);

                int bytesPerPixel = Bitmap.GetPixelFormatSize(imgBmp.PixelFormat) / 8;
                int byteCount = bitmapData.Stride * imgBmp.Height;
                byte[] pixels = new byte[byteCount];
                IntPtr ptrFirstPixel = bitmapData.Scan0;
                Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);

                imgBmp.UnlockBits(bitmapData);


                FaceBox[] faceBoxes = new FaceBox[10];
                int faceCount = FaceSDK.FaceDetection(pixels, imgBmp.Width, imgBmp.Height, faceBoxes, 10);
                if (faceCount > 0)
                {
                    Rectangle cropRect = new Rectangle(faceBoxes[0].x1, faceBoxes[0].y1, faceBoxes[0].x2 - faceBoxes[0].x1, faceBoxes[0].y2 - faceBoxes[0].y1); // Adjust crop area
                    Bitmap croppedImage = CropImage(image, cropRect);


                    PersonDialog dialog = new PersonDialog();
                    dialog.SetFace(croppedImage);
                    DialogResult res = dialog.ShowDialog();
                    if(res == DialogResult.OK)
                    {
                        FaceSDK.TemplateExtraction(pixels, imgBmp.Width, imgBmp.Height, ref faceBoxes[0]);


                        byte[] jpgData = BitmapToJpegByteArray(croppedImage);
                        Person person = new Person(dialog.GetName(), jpgData, faceBoxes[0].templates);
                        InsertPerson(person, this.conn);
                        RefreshListView();
                    }
                }
                else
                {
                    //richTextBoxResult.Text += "image1: no face detected!\n";
                    //templates1 = null;
                    MessageBox.Show("No face detected!\n");
                }
            }

        }

        private void btnIdentify_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                String fileName = openFileDialog1.FileName;

                Image image = null;
                try
                {
                    image = LoadImageWithExif(fileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("Unknown Format!");
                    return;
                }

                Bitmap imgBmp = ConvertTo24bpp(image);
                BitmapData bitmapData = imgBmp.LockBits(new Rectangle(0, 0, imgBmp.Width, imgBmp.Height), ImageLockMode.ReadWrite, imgBmp.PixelFormat);

                int bytesPerPixel = Bitmap.GetPixelFormatSize(imgBmp.PixelFormat) / 8;
                int byteCount = bitmapData.Stride * imgBmp.Height;
                byte[] pixels = new byte[byteCount];
                IntPtr ptrFirstPixel = bitmapData.Scan0;
                Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);

                imgBmp.UnlockBits(bitmapData);


                FaceBox[] faceBoxes = new FaceBox[10];
                int faceCount = FaceSDK.FaceDetection(pixels, imgBmp.Width, imgBmp.Height, faceBoxes, 10);
                if (faceCount > 0)
                {
                    FaceSDK.TemplateExtraction(pixels, imgBmp.Width, imgBmp.Height, ref faceBoxes[0]);

                    Rectangle cropRect = new Rectangle(faceBoxes[0].x1, faceBoxes[0].y1, faceBoxes[0].x2 - faceBoxes[0].x1, faceBoxes[0].y2 - faceBoxes[0].y1); // Adjust crop area
                    Bitmap croppedImage = CropImage(image, cropRect);

                    float maxSimilarity = 0f;
                    int maxSimilarIdx = -1;
                    for(int i = 0; i < personList.Count; i ++)
                    {
                        float similarity = FaceSDK.SimilarityCalculation(faceBoxes[0].templates, personList[i].Templates);
                        if(similarity > maxSimilarity)
                        {
                            maxSimilarity = similarity;
                            maxSimilarIdx = i;
                        }
                    }

                    if(maxSimilarity > identifyThreshold)
                    {
                        lblName.Text = $"Name: {personList[maxSimilarIdx].Name}";
                        lblSimilarity.Text = $"Similarity: {maxSimilarity}";
                        lblResult.Text = $"Result: Same Person";
                        pictureIdentify.Image = croppedImage;
                        pictureRegister.Image = ConvertJpgByteArrayToBitmap(personList[maxSimilarIdx].FaceJpg);
                    }
                    else
                    {
                        lblName.Text = "";
                        lblSimilarity.Text = $"Similarity: {maxSimilarity}";
                        lblResult.Text = $"Result: Different Person";
                        pictureIdentify.Image = croppedImage;
                        pictureRegister.Image = null;
                    }

                }
                else
                {
                    //richTextBoxResult.Text += "image1: no face detected!\n";
                    //templates1 = null;
                    MessageBox.Show("No face detected!\n");
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DeleteAllPerson();
            RefreshListView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
