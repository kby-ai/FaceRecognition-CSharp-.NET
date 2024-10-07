namespace FaceRecognition
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMachineCode = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btnRegister = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.pictureRegister = new System.Windows.Forms.PictureBox();
            this.pictureIdentify = new System.Windows.Forms.PictureBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblSimilarity = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIdentify)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "machineCode:";
            // 
            // textBoxMachineCode
            // 
            this.textBoxMachineCode.Location = new System.Drawing.Point(93, 32);
            this.textBoxMachineCode.Name = "textBoxMachineCode";
            this.textBoxMachineCode.Size = new System.Drawing.Size(224, 20);
            this.textBoxMachineCode.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(24, 29);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Register User";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(16, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(358, 466);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(125, 29);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(75, 23);
            this.btnIdentify.TabIndex = 7;
            this.btnIdentify.Text = "Identify";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(229, 29);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAll.TabIndex = 8;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // pictureRegister
            // 
            this.pictureRegister.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureRegister.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureRegister.Location = new System.Drawing.Point(27, 31);
            this.pictureRegister.Name = "pictureRegister";
            this.pictureRegister.Size = new System.Drawing.Size(120, 121);
            this.pictureRegister.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureRegister.TabIndex = 9;
            this.pictureRegister.TabStop = false;
            // 
            // pictureIdentify
            // 
            this.pictureIdentify.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureIdentify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureIdentify.Location = new System.Drawing.Point(176, 31);
            this.pictureIdentify.Name = "pictureIdentify";
            this.pictureIdentify.Size = new System.Drawing.Size(120, 121);
            this.pictureIdentify.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureIdentify.TabIndex = 10;
            this.pictureIdentify.TabStop = false;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(27, 204);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 13);
            this.lblResult.TabIndex = 12;
            // 
            // lblSimilarity
            // 
            this.lblSimilarity.AutoSize = true;
            this.lblSimilarity.Location = new System.Drawing.Point(27, 229);
            this.lblSimilarity.Name = "lblSimilarity";
            this.lblSimilarity.Size = new System.Drawing.Size(0, 13);
            this.lblSimilarity.TabIndex = 13;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(27, 253);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxMachineCode);
            this.groupBox1.Location = new System.Drawing.Point(392, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 72);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Activation";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.pictureIdentify);
            this.groupBox2.Controls.Add(this.pictureRegister);
            this.groupBox2.Controls.Add(this.lblName);
            this.groupBox2.Controls.Add(this.lblResult);
            this.groupBox2.Controls.Add(this.lblSimilarity);
            this.groupBox2.Location = new System.Drawing.Point(392, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 283);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Identify Result";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Identify Face";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Register Face";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDeleteAll);
            this.groupBox3.Controls.Add(this.btnRegister);
            this.groupBox3.Controls.Add(this.btnIdentify);
            this.groupBox3.Location = new System.Drawing.Point(392, 411);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(326, 67);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Action";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 490);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Face Recognition - KBY-AI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIdentify)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMachineCode;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.PictureBox pictureRegister;
        private System.Windows.Forms.PictureBox pictureIdentify;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblSimilarity;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

