namespace EXON.Register
{
    partial class frmTakePhoto
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
            this.btnDone = new System.Windows.Forms.Button();
            this.btnTakePhoto = new System.Windows.Forms.Button();
            this.ptbImage = new System.Windows.Forms.PictureBox();
            this.ptbWebcam = new System.Windows.Forms.PictureBox();
            this.cboCam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbWebcam)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDone.Image = global::EXON.Register.Properties.Resources.maps_and_flags;
            this.btnDone.Location = new System.Drawing.Point(531, 405);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 60);
            this.btnDone.TabIndex = 2;
            this.btnDone.Text = "Xong";
            this.btnDone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnTakePhoto
            // 
            this.btnTakePhoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnTakePhoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnTakePhoto.Image = global::EXON.Register.Properties.Resources.camera;
            this.btnTakePhoto.Location = new System.Drawing.Point(391, 405);
            this.btnTakePhoto.Name = "btnTakePhoto";
            this.btnTakePhoto.Size = new System.Drawing.Size(75, 60);
            this.btnTakePhoto.TabIndex = 1;
            this.btnTakePhoto.Text = "Chụp ảnh";
            this.btnTakePhoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTakePhoto.UseVisualStyleBackColor = false;
            this.btnTakePhoto.Click += new System.EventHandler(this.btnTakePhoto_Click);
            // 
            // ptbImage
            // 
            this.ptbImage.BackColor = System.Drawing.Color.White;
            this.ptbImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptbImage.Location = new System.Drawing.Point(531, 53);
            this.ptbImage.Name = "ptbImage";
            this.ptbImage.Size = new System.Drawing.Size(418, 331);
            this.ptbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbImage.TabIndex = 0;
            this.ptbImage.TabStop = false;
            // 
            // ptbWebcam
            // 
            this.ptbWebcam.BackColor = System.Drawing.Color.White;
            this.ptbWebcam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptbWebcam.Location = new System.Drawing.Point(40, 53);
            this.ptbWebcam.Name = "ptbWebcam";
            this.ptbWebcam.Size = new System.Drawing.Size(426, 331);
            this.ptbWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbWebcam.TabIndex = 0;
            this.ptbWebcam.TabStop = false;
            // 
            // cboCam
            // 
            this.cboCam.FormattingEnabled = true;
            this.cboCam.Location = new System.Drawing.Point(121, 12);
            this.cboCam.Name = "cboCam";
            this.cboCam.Size = new System.Drawing.Size(345, 21);
            this.cboCam.TabIndex = 3;
            this.cboCam.SelectedIndexChanged += new System.EventHandler(this.cboCam_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Camera";
            // 
            // frmTakePhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(980, 480);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCam);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnTakePhoto);
            this.Controls.Add(this.ptbImage);
            this.Controls.Add(this.ptbWebcam);
            this.Name = "frmTakePhoto";
            this.Text = "Chụp ảnh";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTakePhoto_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTakePhoto_FormClosed);
            this.Load += new System.EventHandler(this.frmTakePhoto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbWebcam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbWebcam;
        private System.Windows.Forms.Button btnTakePhoto;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.PictureBox ptbImage;
        private System.Windows.Forms.ComboBox cboCam;
        private System.Windows.Forms.Label label1;
    }
}