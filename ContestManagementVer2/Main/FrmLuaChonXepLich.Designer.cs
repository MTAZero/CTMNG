namespace ContestManagementVer2.Main
{
    partial class FrmLuaChonXepLich
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.radUuTienMonThi = new MetroFramework.Controls.MetroRadioButton();
            this.radUuTienThiSinh = new MetroFramework.Controls.MetroRadioButton();
            this.btnHuy = new MetroFramework.Controls.MetroButton();
            this.btnXepLich = new MetroFramework.Controls.MetroButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.radUuTienMonThi);
            this.panel1.Controls.Add(this.radUuTienThiSinh);
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.btnXepLich);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 167);
            this.panel1.TabIndex = 0;
            // 
            // radUuTienMonThi
            // 
            this.radUuTienMonThi.AutoSize = true;
            this.radUuTienMonThi.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.radUuTienMonThi.Location = new System.Drawing.Point(77, 20);
            this.radUuTienMonThi.Name = "radUuTienMonThi";
            this.radUuTienMonThi.Size = new System.Drawing.Size(217, 25);
            this.radUuTienMonThi.TabIndex = 20;
            this.radUuTienMonThi.Text = "Xếp lịch ưu tiên môn thi";
            this.radUuTienMonThi.UseSelectable = true;
            // 
            // radUuTienThiSinh
            // 
            this.radUuTienThiSinh.AutoSize = true;
            this.radUuTienThiSinh.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.radUuTienThiSinh.Location = new System.Drawing.Point(77, 63);
            this.radUuTienThiSinh.Name = "radUuTienThiSinh";
            this.radUuTienThiSinh.Size = new System.Drawing.Size(212, 25);
            this.radUuTienThiSinh.TabIndex = 21;
            this.radUuTienThiSinh.Text = "Xếp lịch ưu tiên thí sinh";
            this.radUuTienThiSinh.UseSelectable = true;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.White;
            this.btnHuy.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnHuy.Location = new System.Drawing.Point(284, 109);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(135, 36);
            this.btnHuy.TabIndex = 19;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnHuy.UseCustomBackColor = true;
            this.btnHuy.UseCustomForeColor = true;
            this.btnHuy.UseSelectable = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXepLich
            // 
            this.btnXepLich.BackColor = System.Drawing.Color.White;
            this.btnXepLich.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnXepLich.ForeColor = System.Drawing.Color.Green;
            this.btnXepLich.Location = new System.Drawing.Point(143, 109);
            this.btnXepLich.Name = "btnXepLich";
            this.btnXepLich.Size = new System.Drawing.Size(135, 36);
            this.btnXepLich.TabIndex = 18;
            this.btnXepLich.Text = "Xếp lịch";
            this.btnXepLich.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnXepLich.UseCustomBackColor = true;
            this.btnXepLich.UseCustomForeColor = true;
            this.btnXepLich.UseSelectable = true;
            this.btnXepLich.Click += new System.EventHandler(this.btnXepLich_Click);
            // 
            // FrmLuaChonXepLich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 247);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmLuaChonXepLich";
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "XẾP LỊCH THI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton btnHuy;
        private MetroFramework.Controls.MetroButton btnXepLich;
        private MetroFramework.Controls.MetroRadioButton radUuTienMonThi;
        private MetroFramework.Controls.MetroRadioButton radUuTienThiSinh;
    }
}