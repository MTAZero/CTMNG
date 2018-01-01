namespace EXON_ExamManagement
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMain = new MetroFramework.Controls.MetroPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvContest = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKiThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mbtnPhanCong = new MetroFramework.Controls.MetroButton();
            this.mbtnExit = new MetroFramework.Controls.MetroButton();
            this.mbtnCauHinhHeThong = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btnDanhSachKeHoach = new MetroFramework.Controls.MetroButton();
            this.btnLapKeHoachThi = new MetroFramework.Controls.MetroButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbGiamSatTo = new System.Windows.Forms.Label();
            this.lbGiamSatFrom = new System.Windows.Forms.Label();
            this.lbChuanBiThiTo = new System.Windows.Forms.Label();
            this.lbChuanBiThiFrom = new System.Windows.Forms.Label();
            this.lbSinhDeThiTo = new System.Windows.Forms.Label();
            this.lbSinhDeThiFrom = new System.Windows.Forms.Label();
            this.lbXepLichThiTo = new System.Windows.Forms.Label();
            this.lbXepLichThiFrom = new System.Windows.Forms.Label();
            this.lbSinhDeGocTo = new System.Windows.Forms.Label();
            this.lbSinhDeGocFrom = new System.Windows.Forms.Label();
            this.lbRegisterTo = new System.Windows.Forms.Label();
            this.lbRegisterFrom = new System.Windows.Forms.Label();
            this.btnSinhDeThi = new MetroFramework.Controls.MetroButton();
            this.btnToChucThi = new MetroFramework.Controls.MetroButton();
            this.btnLapKeHoach = new MetroFramework.Controls.MetroButton();
            this.btnXepLich = new MetroFramework.Controls.MetroButton();
            this.btnDangKiThi = new MetroFramework.Controls.MetroButton();
            this.btnChuanBiThi = new MetroFramework.Controls.MetroButton();
            this.btnSinhDeThiGoc = new MetroFramework.Controls.MetroButton();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerUpdateSTTContest = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContest)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.HorizontalScrollbarBarColor = true;
            this.panelMain.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMain.HorizontalScrollbarSize = 12;
            this.panelMain.Location = new System.Drawing.Point(23, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1324, 678);
            this.panelMain.TabIndex = 0;
            this.panelMain.VerticalScrollbarBarColor = true;
            this.panelMain.VerticalScrollbarHighlightOnWheel = false;
            this.panelMain.VerticalScrollbarSize = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panelStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1322, 676);
            this.panel2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvContest);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 247);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1322, 429);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách các kì thi";
            // 
            // dgvContest
            // 
            this.dgvContest.AllowUserToResizeColumns = false;
            this.dgvContest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContest.BackgroundColor = System.Drawing.Color.White;
            this.dgvContest.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvContest.ColumnHeadersHeight = 30;
            this.dgvContest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Status,
            this.STT,
            this.TenKiThi,
            this.TrangThai});
            this.dgvContest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContest.EnableHeadersVisualStyles = false;
            this.dgvContest.GridColor = System.Drawing.Color.Black;
            this.dgvContest.Location = new System.Drawing.Point(3, 19);
            this.dgvContest.MultiSelect = false;
            this.dgvContest.Name = "dgvContest";
            this.dgvContest.ReadOnly = true;
            this.dgvContest.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvContest.RowHeadersWidth = 25;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvContest.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContest.RowTemplate.Height = 30;
            this.dgvContest.RowTemplate.ReadOnly = true;
            this.dgvContest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContest.Size = new System.Drawing.Size(1049, 407);
            this.dgvContest.TabIndex = 7;
            this.dgvContest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContest_CellClick);
            this.dgvContest.SelectionChanged += new System.EventHandler(this.dgvContest_SelectionChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Visible = false;
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.FillWeight = 30F;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // TenKiThi
            // 
            this.TenKiThi.DataPropertyName = "TenKiThi";
            this.TenKiThi.HeaderText = "Tên kì thi";
            this.TenKiThi.Name = "TenKiThi";
            this.TenKiThi.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng thái kì thi";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.mbtnPhanCong);
            this.panel3.Controls.Add(this.mbtnExit);
            this.panel3.Controls.Add(this.mbtnCauHinhHeThong);
            this.panel3.Controls.Add(this.metroButton1);
            this.panel3.Controls.Add(this.btnDanhSachKeHoach);
            this.panel3.Controls.Add(this.btnLapKeHoachThi);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1052, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 407);
            this.panel3.TabIndex = 6;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint_1);
            // 
            // mbtnPhanCong
            // 
            this.mbtnPhanCong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mbtnPhanCong.DisplayFocus = true;
            this.mbtnPhanCong.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnPhanCong.ForeColor = System.Drawing.Color.Black;
            this.mbtnPhanCong.Location = new System.Drawing.Point(3, 147);
            this.mbtnPhanCong.Name = "mbtnPhanCong";
            this.mbtnPhanCong.Size = new System.Drawing.Size(255, 42);
            this.mbtnPhanCong.Style = MetroFramework.MetroColorStyle.Green;
            this.mbtnPhanCong.TabIndex = 4;
            this.mbtnPhanCong.Text = "     Phân công giám sát";
            this.mbtnPhanCong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mbtnPhanCong.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mbtnPhanCong.UseCustomBackColor = true;
            this.mbtnPhanCong.UseCustomForeColor = true;
            this.mbtnPhanCong.UseSelectable = true;
            this.mbtnPhanCong.UseStyleColors = true;
            this.mbtnPhanCong.Click += new System.EventHandler(this.mbtnPhanCong_Click);
            // 
            // mbtnExit
            // 
            this.mbtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mbtnExit.DisplayFocus = true;
            this.mbtnExit.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnExit.ForeColor = System.Drawing.Color.Black;
            this.mbtnExit.Location = new System.Drawing.Point(3, 243);
            this.mbtnExit.Name = "mbtnExit";
            this.mbtnExit.Size = new System.Drawing.Size(255, 42);
            this.mbtnExit.Style = MetroFramework.MetroColorStyle.Green;
            this.mbtnExit.TabIndex = 3;
            this.mbtnExit.Text = "     Thoát";
            this.mbtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mbtnExit.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mbtnExit.UseCustomBackColor = true;
            this.mbtnExit.UseCustomForeColor = true;
            this.mbtnExit.UseSelectable = true;
            this.mbtnExit.UseStyleColors = true;
            this.mbtnExit.Click += new System.EventHandler(this.mbtnExit_Click);
            // 
            // mbtnCauHinhHeThong
            // 
            this.mbtnCauHinhHeThong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mbtnCauHinhHeThong.DisplayFocus = true;
            this.mbtnCauHinhHeThong.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.mbtnCauHinhHeThong.ForeColor = System.Drawing.Color.Black;
            this.mbtnCauHinhHeThong.Location = new System.Drawing.Point(3, 195);
            this.mbtnCauHinhHeThong.Name = "mbtnCauHinhHeThong";
            this.mbtnCauHinhHeThong.Size = new System.Drawing.Size(255, 42);
            this.mbtnCauHinhHeThong.Style = MetroFramework.MetroColorStyle.Green;
            this.mbtnCauHinhHeThong.TabIndex = 3;
            this.mbtnCauHinhHeThong.Text = "     Cấu hình hệ thống";
            this.mbtnCauHinhHeThong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mbtnCauHinhHeThong.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mbtnCauHinhHeThong.UseCustomBackColor = true;
            this.mbtnCauHinhHeThong.UseCustomForeColor = true;
            this.mbtnCauHinhHeThong.UseSelectable = true;
            this.mbtnCauHinhHeThong.UseStyleColors = true;
            this.mbtnCauHinhHeThong.Click += new System.EventHandler(this.mbtnCauHinhHeThong_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton1.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Location = new System.Drawing.Point(3, 99);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(255, 42);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "     In danh sách các kì thi";
            this.metroButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // btnDanhSachKeHoach
            // 
            this.btnDanhSachKeHoach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDanhSachKeHoach.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnDanhSachKeHoach.ForeColor = System.Drawing.Color.Black;
            this.btnDanhSachKeHoach.Location = new System.Drawing.Point(3, 51);
            this.btnDanhSachKeHoach.Name = "btnDanhSachKeHoach";
            this.btnDanhSachKeHoach.Size = new System.Drawing.Size(255, 42);
            this.btnDanhSachKeHoach.Style = MetroFramework.MetroColorStyle.Green;
            this.btnDanhSachKeHoach.TabIndex = 1;
            this.btnDanhSachKeHoach.Text = "     Xem lại các kì thi";
            this.btnDanhSachKeHoach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhSachKeHoach.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnDanhSachKeHoach.UseCustomBackColor = true;
            this.btnDanhSachKeHoach.UseCustomForeColor = true;
            this.btnDanhSachKeHoach.UseSelectable = true;
            this.btnDanhSachKeHoach.UseStyleColors = true;
            this.btnDanhSachKeHoach.Click += new System.EventHandler(this.btnDanhSachKeHoach_Click_1);
            // 
            // btnLapKeHoachThi
            // 
            this.btnLapKeHoachThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLapKeHoachThi.DisplayFocus = true;
            this.btnLapKeHoachThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnLapKeHoachThi.ForeColor = System.Drawing.Color.Black;
            this.btnLapKeHoachThi.Location = new System.Drawing.Point(3, 3);
            this.btnLapKeHoachThi.Name = "btnLapKeHoachThi";
            this.btnLapKeHoachThi.Size = new System.Drawing.Size(255, 42);
            this.btnLapKeHoachThi.Style = MetroFramework.MetroColorStyle.Green;
            this.btnLapKeHoachThi.TabIndex = 0;
            this.btnLapKeHoachThi.Text = "     Lập mới kế hoạch thi";
            this.btnLapKeHoachThi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLapKeHoachThi.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnLapKeHoachThi.UseCustomBackColor = true;
            this.btnLapKeHoachThi.UseCustomForeColor = true;
            this.btnLapKeHoachThi.UseSelectable = true;
            this.btnLapKeHoachThi.UseStyleColors = true;
            this.btnLapKeHoachThi.Click += new System.EventHandler(this.btnLapKeHoachThi_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbGiamSatTo);
            this.panel1.Controls.Add(this.lbGiamSatFrom);
            this.panel1.Controls.Add(this.lbChuanBiThiTo);
            this.panel1.Controls.Add(this.lbChuanBiThiFrom);
            this.panel1.Controls.Add(this.lbSinhDeThiTo);
            this.panel1.Controls.Add(this.lbSinhDeThiFrom);
            this.panel1.Controls.Add(this.lbXepLichThiTo);
            this.panel1.Controls.Add(this.lbXepLichThiFrom);
            this.panel1.Controls.Add(this.lbSinhDeGocTo);
            this.panel1.Controls.Add(this.lbSinhDeGocFrom);
            this.panel1.Controls.Add(this.lbRegisterTo);
            this.panel1.Controls.Add(this.lbRegisterFrom);
            this.panel1.Controls.Add(this.btnSinhDeThi);
            this.panel1.Controls.Add(this.btnToChucThi);
            this.panel1.Controls.Add(this.btnLapKeHoach);
            this.panel1.Controls.Add(this.btnXepLich);
            this.panel1.Controls.Add(this.btnDangKiThi);
            this.panel1.Controls.Add(this.btnChuanBiThi);
            this.panel1.Controls.Add(this.btnSinhDeThiGoc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1322, 130);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lbGiamSatTo
            // 
            this.lbGiamSatTo.AutoSize = true;
            this.lbGiamSatTo.Location = new System.Drawing.Point(1141, 99);
            this.lbGiamSatTo.Name = "lbGiamSatTo";
            this.lbGiamSatTo.Size = new System.Drawing.Size(38, 16);
            this.lbGiamSatTo.TabIndex = 63;
            this.lbGiamSatTo.Text = "Đến: ";
            // 
            // lbGiamSatFrom
            // 
            this.lbGiamSatFrom.AutoSize = true;
            this.lbGiamSatFrom.Location = new System.Drawing.Point(1141, 81);
            this.lbGiamSatFrom.Name = "lbGiamSatFrom";
            this.lbGiamSatFrom.Size = new System.Drawing.Size(36, 16);
            this.lbGiamSatFrom.TabIndex = 63;
            this.lbGiamSatFrom.Text = "Từ : ";
            // 
            // lbChuanBiThiTo
            // 
            this.lbChuanBiThiTo.AutoSize = true;
            this.lbChuanBiThiTo.Location = new System.Drawing.Point(952, 99);
            this.lbChuanBiThiTo.Name = "lbChuanBiThiTo";
            this.lbChuanBiThiTo.Size = new System.Drawing.Size(38, 16);
            this.lbChuanBiThiTo.TabIndex = 63;
            this.lbChuanBiThiTo.Text = "Đến: ";
            // 
            // lbChuanBiThiFrom
            // 
            this.lbChuanBiThiFrom.AutoSize = true;
            this.lbChuanBiThiFrom.Location = new System.Drawing.Point(952, 81);
            this.lbChuanBiThiFrom.Name = "lbChuanBiThiFrom";
            this.lbChuanBiThiFrom.Size = new System.Drawing.Size(36, 16);
            this.lbChuanBiThiFrom.TabIndex = 63;
            this.lbChuanBiThiFrom.Text = "Từ : ";
            // 
            // lbSinhDeThiTo
            // 
            this.lbSinhDeThiTo.AutoSize = true;
            this.lbSinhDeThiTo.Location = new System.Drawing.Point(763, 99);
            this.lbSinhDeThiTo.Name = "lbSinhDeThiTo";
            this.lbSinhDeThiTo.Size = new System.Drawing.Size(38, 16);
            this.lbSinhDeThiTo.TabIndex = 63;
            this.lbSinhDeThiTo.Text = "Đến: ";
            // 
            // lbSinhDeThiFrom
            // 
            this.lbSinhDeThiFrom.AutoSize = true;
            this.lbSinhDeThiFrom.Location = new System.Drawing.Point(763, 81);
            this.lbSinhDeThiFrom.Name = "lbSinhDeThiFrom";
            this.lbSinhDeThiFrom.Size = new System.Drawing.Size(36, 16);
            this.lbSinhDeThiFrom.TabIndex = 63;
            this.lbSinhDeThiFrom.Text = "Từ : ";
            // 
            // lbXepLichThiTo
            // 
            this.lbXepLichThiTo.AutoSize = true;
            this.lbXepLichThiTo.Location = new System.Drawing.Point(574, 99);
            this.lbXepLichThiTo.Name = "lbXepLichThiTo";
            this.lbXepLichThiTo.Size = new System.Drawing.Size(38, 16);
            this.lbXepLichThiTo.TabIndex = 63;
            this.lbXepLichThiTo.Text = "Đến: ";
            // 
            // lbXepLichThiFrom
            // 
            this.lbXepLichThiFrom.AutoSize = true;
            this.lbXepLichThiFrom.Location = new System.Drawing.Point(574, 81);
            this.lbXepLichThiFrom.Name = "lbXepLichThiFrom";
            this.lbXepLichThiFrom.Size = new System.Drawing.Size(36, 16);
            this.lbXepLichThiFrom.TabIndex = 63;
            this.lbXepLichThiFrom.Text = "Từ : ";
            // 
            // lbSinhDeGocTo
            // 
            this.lbSinhDeGocTo.AutoSize = true;
            this.lbSinhDeGocTo.Location = new System.Drawing.Point(385, 99);
            this.lbSinhDeGocTo.Name = "lbSinhDeGocTo";
            this.lbSinhDeGocTo.Size = new System.Drawing.Size(38, 16);
            this.lbSinhDeGocTo.TabIndex = 63;
            this.lbSinhDeGocTo.Text = "Đến: ";
            // 
            // lbSinhDeGocFrom
            // 
            this.lbSinhDeGocFrom.AutoSize = true;
            this.lbSinhDeGocFrom.Location = new System.Drawing.Point(385, 81);
            this.lbSinhDeGocFrom.Name = "lbSinhDeGocFrom";
            this.lbSinhDeGocFrom.Size = new System.Drawing.Size(36, 16);
            this.lbSinhDeGocFrom.TabIndex = 63;
            this.lbSinhDeGocFrom.Text = "Từ : ";
            // 
            // lbRegisterTo
            // 
            this.lbRegisterTo.AutoSize = true;
            this.lbRegisterTo.Location = new System.Drawing.Point(196, 99);
            this.lbRegisterTo.Name = "lbRegisterTo";
            this.lbRegisterTo.Size = new System.Drawing.Size(38, 16);
            this.lbRegisterTo.TabIndex = 63;
            this.lbRegisterTo.Text = "Đến: ";
            // 
            // lbRegisterFrom
            // 
            this.lbRegisterFrom.AutoSize = true;
            this.lbRegisterFrom.Location = new System.Drawing.Point(196, 81);
            this.lbRegisterFrom.Name = "lbRegisterFrom";
            this.lbRegisterFrom.Size = new System.Drawing.Size(36, 16);
            this.lbRegisterFrom.TabIndex = 63;
            this.lbRegisterFrom.Text = "Từ : ";
            // 
            // btnSinhDeThi
            // 
            this.btnSinhDeThi.BackgroundImage = global::EXON_ExamManagement.Properties.Resources.step5;
            this.btnSinhDeThi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSinhDeThi.Enabled = false;
            this.btnSinhDeThi.Location = new System.Drawing.Point(766, 16);
            this.btnSinhDeThi.Name = "btnSinhDeThi";
            this.btnSinhDeThi.Size = new System.Drawing.Size(169, 62);
            this.btnSinhDeThi.TabIndex = 62;
            this.btnSinhDeThi.UseSelectable = true;
            this.btnSinhDeThi.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // btnToChucThi
            // 
            this.btnToChucThi.BackgroundImage = global::EXON_ExamManagement.Properties.Resources.step7;
            this.btnToChucThi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToChucThi.Enabled = false;
            this.btnToChucThi.ForeColor = System.Drawing.Color.Black;
            this.btnToChucThi.Location = new System.Drawing.Point(1144, 16);
            this.btnToChucThi.Name = "btnToChucThi";
            this.btnToChucThi.Size = new System.Drawing.Size(169, 62);
            this.btnToChucThi.TabIndex = 61;
            this.btnToChucThi.UseSelectable = true;
            this.btnToChucThi.Click += new System.EventHandler(this.btnToChucThi_Click);
            // 
            // btnLapKeHoach
            // 
            this.btnLapKeHoach.BackgroundImage = global::EXON_ExamManagement.Properties.Resources.step1;
            this.btnLapKeHoach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLapKeHoach.Enabled = false;
            this.btnLapKeHoach.Location = new System.Drawing.Point(10, 16);
            this.btnLapKeHoach.Name = "btnLapKeHoach";
            this.btnLapKeHoach.Size = new System.Drawing.Size(169, 62);
            this.btnLapKeHoach.TabIndex = 56;
            this.btnLapKeHoach.UseSelectable = true;
            this.btnLapKeHoach.Click += new System.EventHandler(this.btnLapKeHoach_Click);
            // 
            // btnXepLich
            // 
            this.btnXepLich.BackgroundImage = global::EXON_ExamManagement.Properties.Resources.step4;
            this.btnXepLich.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXepLich.Enabled = false;
            this.btnXepLich.Location = new System.Drawing.Point(563, 16);
            this.btnXepLich.Name = "btnXepLich";
            this.btnXepLich.Size = new System.Drawing.Size(169, 62);
            this.btnXepLich.TabIndex = 58;
            this.btnXepLich.UseSelectable = true;
            this.btnXepLich.Click += new System.EventHandler(this.btnXepLich_Click);
            // 
            // btnDangKiThi
            // 
            this.btnDangKiThi.BackgroundImage = global::EXON_ExamManagement.Properties.Resources.step2;
            this.btnDangKiThi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDangKiThi.Enabled = false;
            this.btnDangKiThi.Location = new System.Drawing.Point(199, 16);
            this.btnDangKiThi.Name = "btnDangKiThi";
            this.btnDangKiThi.Size = new System.Drawing.Size(169, 62);
            this.btnDangKiThi.TabIndex = 57;
            this.btnDangKiThi.UseSelectable = true;
            this.btnDangKiThi.Click += new System.EventHandler(this.btnDangKiThi_Click);
            // 
            // btnChuanBiThi
            // 
            this.btnChuanBiThi.BackgroundImage = global::EXON_ExamManagement.Properties.Resources.step6;
            this.btnChuanBiThi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChuanBiThi.Enabled = false;
            this.btnChuanBiThi.Location = new System.Drawing.Point(969, 16);
            this.btnChuanBiThi.Name = "btnChuanBiThi";
            this.btnChuanBiThi.Size = new System.Drawing.Size(169, 62);
            this.btnChuanBiThi.TabIndex = 60;
            this.btnChuanBiThi.UseSelectable = true;
            this.btnChuanBiThi.Click += new System.EventHandler(this.metroButton6_Click);
            // 
            // btnSinhDeThiGoc
            // 
            this.btnSinhDeThiGoc.BackgroundImage = global::EXON_ExamManagement.Properties.Resources.step3;
            this.btnSinhDeThiGoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSinhDeThiGoc.Enabled = false;
            this.btnSinhDeThiGoc.Location = new System.Drawing.Point(388, 16);
            this.btnSinhDeThiGoc.Name = "btnSinhDeThiGoc";
            this.btnSinhDeThiGoc.Size = new System.Drawing.Size(169, 62);
            this.btnSinhDeThiGoc.TabIndex = 59;
            this.btnSinhDeThiGoc.UseSelectable = true;
            this.btnSinhDeThiGoc.Click += new System.EventHandler(this.btnSinhDeThi_Click);
            // 
            // panelStatus
            // 
            this.panelStatus.Controls.Add(this.pictureBox1);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatus.Location = new System.Drawing.Point(0, 0);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(1322, 117);
            this.panelStatus.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::EXON_ExamManagement.Properties.Resources.LogoHVnew1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1322, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // timerUpdateSTTContest
            // 
            this.timerUpdateSTTContest.Interval = 120000;
            this.timerUpdateSTTContest.Tick += new System.EventHandler(this.timerUpdateSTTContest_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1370, 772);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(23, 70, 23, 24);
            this.Text = "HỆ THỐNG THI TRỰC TUYẾN";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panelMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContest)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panelMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton btnLapKeHoach;
        private MetroFramework.Controls.MetroButton btnToChucThi;
        private MetroFramework.Controls.MetroButton btnChuanBiThi;
        private MetroFramework.Controls.MetroButton btnSinhDeThiGoc;
        private MetroFramework.Controls.MetroButton btnXepLich;
        private MetroFramework.Controls.MetroButton btnDangKiThi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvContest;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKiThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroButton mbtnCauHinhHeThong;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton btnDanhSachKeHoach;
        private MetroFramework.Controls.MetroButton btnLapKeHoachThi;
        private MetroFramework.Controls.MetroButton mbtnPhanCong;
        private MetroFramework.Controls.MetroButton btnSinhDeThi;
        private MetroFramework.Controls.MetroButton mbtnExit;
        private System.Windows.Forms.Label lbGiamSatTo;
        private System.Windows.Forms.Label lbGiamSatFrom;
        private System.Windows.Forms.Label lbChuanBiThiTo;
        private System.Windows.Forms.Label lbChuanBiThiFrom;
        private System.Windows.Forms.Label lbSinhDeThiTo;
        private System.Windows.Forms.Label lbSinhDeThiFrom;
        private System.Windows.Forms.Label lbXepLichThiTo;
        private System.Windows.Forms.Label lbXepLichThiFrom;
        private System.Windows.Forms.Label lbSinhDeGocTo;
        private System.Windows.Forms.Label lbSinhDeGocFrom;
        private System.Windows.Forms.Label lbRegisterTo;
        private System.Windows.Forms.Label lbRegisterFrom;
        private System.Windows.Forms.Timer timerUpdateSTTContest;
    }
}

