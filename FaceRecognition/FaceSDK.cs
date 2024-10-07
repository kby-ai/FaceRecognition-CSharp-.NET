using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace KBYAIFace
{
    enum SDK_ERROR
    {
        SDK_SUCCESS = 0,
        SDK_LICENSE_KEY_ERROR = -1,
        SDK_LICENSE_APPID_ERROR = -2,
        SDK_LICENSE_EXPIRED = -3,
        SDK_NO_ACTIVATED = -4,
        SDK_INIT_ERROR = -5,
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct FaceBox
    {
        public int x1, y1, x2, y2;

        public float yaw, roll, pitch;
        public float face_quality, face_luminance, eye_dist;

        public float left_eye_closed, right_eye_closed, face_occlusion, mouth_opened;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 68 * 2)]
        public float[] landmark_68; // Array of 136 floats

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)]
        public byte[] templates; // Array of 2048 bytes

        public FaceBox(int n)
        {
            x1 = x2 = y1 = y2 = 0;
            yaw = roll = pitch = 0;
            face_quality = face_luminance = eye_dist = 0;
            left_eye_closed = right_eye_closed = face_occlusion = mouth_opened = 0;
            templates = new byte[2056];
            landmark_68 = new float[68 * 2];
        }
    };

    //[StructLayout(LayoutKind.Sequential)]
    //public struct FACE_RESULTS
    //{
    //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    //    public FACE_RESULT[] faceResults;

    //    public FACE_RESULTS(int n)
    //    {
    //        faceResults = new FACE_RESULT[10];
    //        for (int i = 0; i < 10; i++)
    //            faceResults[i] = new FACE_RESULT(0);
    //    }
    //};

    class FaceSDK
    {
        [DllImport("facesdk2.dll")]

        public static extern IntPtr getMachineCode();

        public static String GetMachineCode()
        {
            try
            {
                IntPtr machineCode = getMachineCode();
                if (machineCode == null)
                    throw new Exception("Failed to retrieve machine code.");

                string strMachineCode = Marshal.PtrToStringAnsi(machineCode);
                return strMachineCode;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        [DllImport("facesdk2.dll")]
        public static extern int setActivation(IntPtr license);

        public static int SetActivation(String license)
        {
            IntPtr ptr = Marshal.StringToHGlobalAnsi(license);

            try
            {
                return setActivation(ptr);
            }
            finally
            {
                // Free the unmanaged memory when done
                Marshal.FreeHGlobal(ptr);                
            }
        }

        [DllImport("facesdk2.dll")]
        public static extern int initSDK(IntPtr modelPath);

        public static int InitSDK(String modelPath)
        {
            IntPtr ptr = Marshal.StringToHGlobalAnsi(modelPath);

            try
            {
                return initSDK(ptr);
            }
            finally
            {
                // Free the unmanaged memory when done
                Marshal.FreeHGlobal(ptr);
            }
        }

        [DllImport("facesdk2.dll")]
        public static extern int faceDetection(
            IntPtr rgbData, // Pointer to the RGB data
            int width,      // Width of the image
            int height,     // Height of the image
            [In, Out] FaceBox[] faceBoxes, // Array of FaceBox
            int faceBoxCount // Number of face boxes
        );

        public static int FaceDetection(byte[] rgbData, int width, int height, [In, Out] FaceBox[] faceBoxes, int faceBoxCount)
        {
            IntPtr imgPtr = Marshal.AllocHGlobal(rgbData.Length);
            Marshal.Copy(rgbData, 0, imgPtr, rgbData.Length);

            try
            {
                int ret = faceDetection(imgPtr, width, height, faceBoxes, faceBoxCount);
                return ret;
            }
            finally
            {
                Marshal.FreeHGlobal(imgPtr);
            }
        }

        [DllImport("facesdk2.dll")]
        public static extern int templateExtraction(IntPtr rgbData, int width, int height, ref FaceBox faceBox);
        public static int TemplateExtraction(byte[] rgbData, int width, int height, ref FaceBox faceBox)
        {
            IntPtr imgPtr = Marshal.AllocHGlobal(rgbData.Length);
            Marshal.Copy(rgbData, 0, imgPtr, rgbData.Length);

            try
            {
                int ret = templateExtraction(imgPtr, width, height, ref faceBox);
                return ret;
            }
            finally
            {
                Marshal.FreeHGlobal(imgPtr);
            }
        }


        [DllImport("facesdk2.dll")]
        public static extern float similarityCalculation(IntPtr templates1, IntPtr templates2);

        public static float SimilarityCalculation(byte[] templates1, byte[] templates2)
        {
            IntPtr templatesPtr1 = Marshal.AllocHGlobal(templates1.Length);
            Marshal.Copy(templates1, 0, templatesPtr1, templates1.Length);

            IntPtr templatesPtr2 = Marshal.AllocHGlobal(templates2.Length);
            Marshal.Copy(templates2, 0, templatesPtr2, templates2.Length);

            try
            {
                float ret = similarityCalculation(templatesPtr1, templatesPtr2);
                return ret;
            }
            finally
            {
                Marshal.FreeHGlobal(templatesPtr1);
                Marshal.FreeHGlobal(templatesPtr2);
            }
        }

        //public static int ttv_process(byte[] imgData, int width, int height, ref FACE_RESULTS faceResults, int maxFaceNum, int mode)
        //{
        //    IntPtr imgPtr = Marshal.AllocHGlobal(imgData.Length);
        //    Marshal.Copy(imgData, 0, imgPtr, imgData.Length);

        //    try
        //    {
        //        int ret = ttv_process(imgPtr, width, height, ref faceResults, maxFaceNum, mode);
        //        return ret;
        //    }
        //    finally
        //    {
        //        Marshal.FreeHGlobal(imgPtr);
        //    }
        //}

        //public static float ttv_compare_feature(byte[] feat1, byte[] feat2)
        //{
        //    IntPtr featPtr1 = Marshal.AllocHGlobal(feat1.Length);
        //    Marshal.Copy(feat1, 0, featPtr1, feat1.Length);

        //    IntPtr featPtr2 = Marshal.AllocHGlobal(feat2.Length);
        //    Marshal.Copy(feat2, 0, featPtr2, feat2.Length);

        //    try
        //    {
        //        float ret = ttv_compare_feature(featPtr1, featPtr2);
        //        return ret;
        //    }
        //    finally
        //    {
        //        Marshal.FreeHGlobal(featPtr1);
        //        Marshal.FreeHGlobal(featPtr2);
        //    }
        //}
    }
}
