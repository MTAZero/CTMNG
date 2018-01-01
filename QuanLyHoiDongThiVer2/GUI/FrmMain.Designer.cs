namespace QuanLyHoiDongThiVer2.GUI
{
    partial class FrmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phânCôngGiámThịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trạngTháiĐịaĐiểmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoiMatKhauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DangXuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTieuDe = new System.Windows.Forms.Panel();
            this.txtStaffName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocationName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContestName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panelTieuDe.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chứcNăngToolStripMenuItem,
            this.tàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1302, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phânCôngGiámThịToolStripMenuItem,
            this.trạngTháiĐịaĐiểmToolStripMenuItem});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.chứcNăngToolStripMenuItem.Text = "Quản lý";
            // 
            // phânCôngGiámThịToolStripMenuItem
            // 
            this.phânCôngGiámThịToolStripMenuItem.Name = "phânCôngGiámThịToolStripMenuItem";
            this.phânCôngGiámThịToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.phânCôngGiámThịToolStripMenuItem.Text = "Phân công giám thị";
            this.phânCôngGiámThịToolStripMenuItem.Click += new System.EventHandler(this.PhanCongGiamThiToolStripMenuItem_Click);
            // 
            // trạngTháiĐịaĐiểmToolStripMenuItem
            // 
            this.trạngTháiĐịaĐiểmToolStripMenuItem.Name = "trạngTháiĐịaĐiểmToolStripMenuItem";
            this.trạngTháiĐịaĐiểmToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.trạngTháiĐịaĐiểmToolStripMenuItem.Text = "Trạng thái địa điểm";
            this.trạngTháiĐịaĐiểmToolStripMenuItem.Click += new System.EventHandler(this.TrangThaiDiaDiemToolStripMenuItem_Click);
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DoiMatKhauToolStripMenuItem,
            this.DangXuatToolStripMenuItem});
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
            // 
            // DoiMatKhauToolStripMenuItem
            // 
            this.DoiMatKhauToolStripMenuItem.Name = "DoiMatKhauToolStripMenuItem";
            this.DoiMatKhauToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DoiMatKhauToolStripMenuItem.Text = "Đổi mật khẩu";
            this.DoiMatKhauToolStripMenuItem.Click += new System.EventHandler(this.DoiMatKhauToolStripMenuItem_Click);
            // 
            // DangXuatToolStripMenuItem
            // 
            this.DangXuatToolStripMenuItem.Name = "DangXuatToolStripMenuItem";
            this.DangXuatToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DangXuatToolStripMenuItem.Text = "Đăng xuất";
            this.DangXuatToolStripMenuItem.Click += new System.EventHandler(this.DangXuatToolStripMenuItem_Click);
            // 
            // panelTieuDe
            // 
            this.panelTieuDe.BackColor = System.Drawing.Color.Teal;
            this.panelTieuDe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTieuDe.Controls.Add(this.txtStaffName);
            this.panelTieuDe.Controls.Add(this.label5);
            this.panelTieuDe.Controls.Add(this.txtLocationName);
            this.panelTieuDe.Controls.Add(this.label3);
            this.panelTieuDe.Controls.Add(this.txtContestName);
            this.panelTieuDe.Controls.Add(this.label1);
            this.panelTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTieuDe.ForeColor = System.Drawing.Color.White;
            this.panelTieuDe.Location = new System.Drawing.Point(0, 24);
            this.panelTieuDe.Name = "panelTieuDe";
            this.panelTieuDe.Size = new System.Drawing.Size(1302, 41);
            this.panelTieuDe.TabIndex = 1;
            // 
            // txtStaffName
            // 
            this.txtStaffName.AutoSize = true;
            this.txtStaffName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffName.Location = new System.Drawing.Point(1112, 13);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(131, 19);
            this.txtStaffName.TabIndex = 5;
            this.txtStaffName.Text = "Nguyễn Thanh Hà";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(969, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "ĐIỂM TRƯỞNG :";
            // 
            // txtLocationName
            // 
            this.txtLocationName.AutoSize = true;
            this.txtLocationName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocationName.Location = new System.Drawing.Point(554, 13);
            this.txtLocationName.Name = "txtLocationName";
            this.txtLocationName.Size = new System.Drawing.Size(247, 19);
            this.txtLocationName.TabIndex = 3;
            this.txtLocationName.Text = "HỌC VIỆN KỸ THUẬT QUÂN SỰ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(464, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "ĐỊA ĐIỂM :";
            // 
            // txtContestName
            // 
            this.txtContestName.AutoSize = true;
            this.txtContestName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContestName.Location = new System.Drawing.Point(101, 13);
            this.txtContestName.Name = "txtContestName";
            this.txtContestName.Size = new System.Drawing.Size(150, 19);
            this.txtContestName.TabIndex = 1;
            this.txtContestName.Text = "TỐT NGHIỆP THPT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "KÌ THI : ";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 65);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1302, 596);
            this.panelMain.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 661);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTieuDe);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý địa điểm thi";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelTieuDe.ResumeLayout(false);
            this.panelTieuDe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phânCôngGiámThịToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trạngTháiĐịaĐiểmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoiMatKhauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DangXuatToolStripMenuItem;
        private System.Windows.Forms.Panel panelTieuDe;
        private System.Windows.Forms.Label txtContestName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label txtLocationName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtStaffName;
        private System.Windows.Forms.Label label5;
    }
}