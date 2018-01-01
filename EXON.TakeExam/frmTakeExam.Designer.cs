namespace EXON.TakeExam
{
    partial class frmTakeExam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTakeExam));
            this.btnToChucThi = new MetroFramework.Controls.MetroButton();
            this.btnDangKiThi = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // btnToChucThi
            // 
            this.btnToChucThi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnToChucThi.BackgroundImage")));
            this.btnToChucThi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToChucThi.Location = new System.Drawing.Point(223, 97);
            this.btnToChucThi.Name = "btnToChucThi";
            this.btnToChucThi.Size = new System.Drawing.Size(169, 62);
            this.btnToChucThi.TabIndex = 63;
            this.btnToChucThi.UseSelectable = true;
            this.btnToChucThi.Click += new System.EventHandler(this.btnToChucThi_Click);
            // 
            // btnDangKiThi
            // 
            this.btnDangKiThi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDangKiThi.BackgroundImage")));
            this.btnDangKiThi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDangKiThi.Location = new System.Drawing.Point(48, 97);
            this.btnDangKiThi.Name = "btnDangKiThi";
            this.btnDangKiThi.Size = new System.Drawing.Size(169, 62);
            this.btnDangKiThi.TabIndex = 62;
            this.btnDangKiThi.UseSelectable = true;
            this.btnDangKiThi.Click += new System.EventHandler(this.btnDangKiThi_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(48, 181);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(136, 19);
            this.metroLabel1.TabIndex = 64;
            this.metroLabel1.Text = "* Lựa chọn chức năng";
            // 
            // frmTakeExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 241);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnToChucThi);
            this.Controls.Add(this.btnDangKiThi);
            this.Name = "frmTakeExam";
            this.Text = "Phân Hệ Thi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnToChucThi;
        private MetroFramework.Controls.MetroButton btnDangKiThi;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}