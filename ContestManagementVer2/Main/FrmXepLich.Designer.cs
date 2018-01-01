namespace ContestManagementVer2.Main
{
    partial class FrmXepLich
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLichThi = new MetroFramework.Controls.MetroButton();
            this.btnXepLich = new MetroFramework.Controls.MetroButton();
            this.btnDanhSachDangKy = new MetroFramework.Controls.MetroButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panelMain);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1310, 660);
            this.panel1.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(248, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1060, 658);
            this.panelMain.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnLichThi);
            this.panel2.Controls.Add(this.btnXepLich);
            this.panel2.Controls.Add(this.btnDanhSachDangKy);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 658);
            this.panel2.TabIndex = 0;
            // 
            // btnLichThi
            // 
            this.btnLichThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLichThi.ForeColor = System.Drawing.Color.Black;
            this.btnLichThi.Location = new System.Drawing.Point(3, 93);
            this.btnLichThi.Name = "btnLichThi";
            this.btnLichThi.Size = new System.Drawing.Size(240, 39);
            this.btnLichThi.TabIndex = 2;
            this.btnLichThi.Text = "Lịch thi";
            this.btnLichThi.UseCustomBackColor = true;
            this.btnLichThi.UseCustomForeColor = true;
            this.btnLichThi.UseSelectable = true;
            this.btnLichThi.Click += new System.EventHandler(this.btnLichThi_Click);
            // 
            // btnXepLich
            // 
            this.btnXepLich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXepLich.ForeColor = System.Drawing.Color.Black;
            this.btnXepLich.Location = new System.Drawing.Point(3, 48);
            this.btnXepLich.Name = "btnXepLich";
            this.btnXepLich.Size = new System.Drawing.Size(240, 39);
            this.btnXepLich.TabIndex = 1;
            this.btnXepLich.Text = "Xếp lịch";
            this.btnXepLich.UseCustomBackColor = true;
            this.btnXepLich.UseCustomForeColor = true;
            this.btnXepLich.UseSelectable = true;
            this.btnXepLich.Click += new System.EventHandler(this.btnXepLich_Click);
            // 
            // btnDanhSachDangKy
            // 
            this.btnDanhSachDangKy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDanhSachDangKy.ForeColor = System.Drawing.Color.Black;
            this.btnDanhSachDangKy.Location = new System.Drawing.Point(3, 3);
            this.btnDanhSachDangKy.Name = "btnDanhSachDangKy";
            this.btnDanhSachDangKy.Size = new System.Drawing.Size(240, 39);
            this.btnDanhSachDangKy.TabIndex = 0;
            this.btnDanhSachDangKy.Text = "Danh sách đăng ký";
            this.btnDanhSachDangKy.UseCustomBackColor = true;
            this.btnDanhSachDangKy.UseCustomForeColor = true;
            this.btnDanhSachDangKy.UseSelectable = true;
            this.btnDanhSachDangKy.Click += new System.EventHandler(this.btnDanhSachDangKy_Click);
            // 
            // FrmXepLich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 740);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmXepLich";
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "XẾP LỊCH THI";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroButton btnXepLich;
        private MetroFramework.Controls.MetroButton btnDanhSachDangKy;
        private MetroFramework.Controls.MetroButton btnLichThi;
        private System.Windows.Forms.Panel panelMain;
    }
}