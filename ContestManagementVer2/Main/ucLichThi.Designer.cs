namespace ContestManagementVer2.Main
{
    partial class ucLichThi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelThongTin = new System.Windows.Forms.Panel();
            this.panelDiaDiemPhongThi = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvRoomTest = new System.Windows.Forms.DataGridView();
            this.IDPhongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STTPhongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongPhongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbxLocation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCaThi = new System.Windows.Forms.DataGridView();
            this.IDCaThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STTCaThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCaThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInKetQuaThiSinh = new MetroFramework.Controls.MetroButton();
            this.btnInKetQuaCaThi = new MetroFramework.Controls.MetroButton();
            this.btnInLichThi = new MetroFramework.Controls.MetroButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvLichThi = new System.Windows.Forms.DataGridView();
            this.IDLichThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STTLichThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SBDThiSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenThiSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelThongTin.SuspendLayout();
            this.panelDiaDiemPhongThi.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomTest)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaThi)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichThi)).BeginInit();
            this.SuspendLayout();
            // 
            // panelThongTin
            // 
            this.panelThongTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThongTin.Controls.Add(this.panelDiaDiemPhongThi);
            this.panelThongTin.Controls.Add(this.groupBox1);
            this.panelThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelThongTin.Location = new System.Drawing.Point(0, 0);
            this.panelThongTin.Name = "panelThongTin";
            this.panelThongTin.Size = new System.Drawing.Size(1024, 209);
            this.panelThongTin.TabIndex = 0;
            // 
            // panelDiaDiemPhongThi
            // 
            this.panelDiaDiemPhongThi.Controls.Add(this.groupBox3);
            this.panelDiaDiemPhongThi.Controls.Add(this.panel4);
            this.panelDiaDiemPhongThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDiaDiemPhongThi.Location = new System.Drawing.Point(536, 0);
            this.panelDiaDiemPhongThi.Name = "panelDiaDiemPhongThi";
            this.panelDiaDiemPhongThi.Size = new System.Drawing.Size(486, 207);
            this.panelDiaDiemPhongThi.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.dgvRoomTest);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 51);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(486, 156);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách phòng thi";
            // 
            // dgvRoomTest
            // 
            this.dgvRoomTest.AllowUserToResizeColumns = false;
            this.dgvRoomTest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoomTest.BackgroundColor = System.Drawing.Color.White;
            this.dgvRoomTest.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRoomTest.ColumnHeadersHeight = 30;
            this.dgvRoomTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPhongThi,
            this.STTPhongThi,
            this.TenPhong,
            this.SoLuongPhongThi});
            this.dgvRoomTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoomTest.EnableHeadersVisualStyles = false;
            this.dgvRoomTest.GridColor = System.Drawing.Color.Black;
            this.dgvRoomTest.Location = new System.Drawing.Point(3, 19);
            this.dgvRoomTest.MultiSelect = false;
            this.dgvRoomTest.Name = "dgvRoomTest";
            this.dgvRoomTest.ReadOnly = true;
            this.dgvRoomTest.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRoomTest.RowHeadersWidth = 25;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRoomTest.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvRoomTest.RowTemplate.Height = 30;
            this.dgvRoomTest.RowTemplate.ReadOnly = true;
            this.dgvRoomTest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRoomTest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoomTest.Size = new System.Drawing.Size(480, 134);
            this.dgvRoomTest.TabIndex = 2;
            this.dgvRoomTest.SelectionChanged += new System.EventHandler(this.dgvRoomTest_SelectionChanged);
            // 
            // IDPhongThi
            // 
            this.IDPhongThi.DataPropertyName = "IDPhongThi";
            this.IDPhongThi.HeaderText = "IDPhongThi";
            this.IDPhongThi.Name = "IDPhongThi";
            this.IDPhongThi.ReadOnly = true;
            this.IDPhongThi.Visible = false;
            // 
            // STTPhongThi
            // 
            this.STTPhongThi.DataPropertyName = "STT";
            this.STTPhongThi.FillWeight = 20F;
            this.STTPhongThi.HeaderText = "STT";
            this.STTPhongThi.Name = "STTPhongThi";
            this.STTPhongThi.ReadOnly = true;
            // 
            // TenPhong
            // 
            this.TenPhong.DataPropertyName = "PhongThi";
            this.TenPhong.FillWeight = 80F;
            this.TenPhong.HeaderText = "Phòng Thi";
            this.TenPhong.Name = "TenPhong";
            this.TenPhong.ReadOnly = true;
            // 
            // SoLuongPhongThi
            // 
            this.SoLuongPhongThi.DataPropertyName = "SoLuong";
            this.SoLuongPhongThi.FillWeight = 30F;
            this.SoLuongPhongThi.HeaderText = "Số chỗ";
            this.SoLuongPhongThi.Name = "SoLuongPhongThi";
            this.SoLuongPhongThi.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cbxLocation);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(486, 51);
            this.panel4.TabIndex = 1;
            // 
            // cbxLocation
            // 
            this.cbxLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLocation.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLocation.FormattingEnabled = true;
            this.cbxLocation.Location = new System.Drawing.Point(104, 14);
            this.cbxLocation.Name = "cbxLocation";
            this.cbxLocation.Size = new System.Drawing.Size(297, 23);
            this.cbxLocation.TabIndex = 1;
            this.cbxLocation.SelectedIndexChanged += new System.EventHandler(this.cbxLocation_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Địa điểm thi : ";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dgvCaThi);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 207);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách ca thi";
            // 
            // dgvCaThi
            // 
            this.dgvCaThi.AllowUserToResizeColumns = false;
            this.dgvCaThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvCaThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCaThi.ColumnHeadersHeight = 30;
            this.dgvCaThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCaThi,
            this.STTCaThi,
            this.TenCaThi,
            this.ThoiGianBatDau,
            this.ThoiGianKetThuc});
            this.dgvCaThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCaThi.EnableHeadersVisualStyles = false;
            this.dgvCaThi.GridColor = System.Drawing.Color.Black;
            this.dgvCaThi.Location = new System.Drawing.Point(3, 19);
            this.dgvCaThi.MultiSelect = false;
            this.dgvCaThi.Name = "dgvCaThi";
            this.dgvCaThi.ReadOnly = true;
            this.dgvCaThi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCaThi.RowHeadersWidth = 25;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCaThi.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvCaThi.RowTemplate.Height = 30;
            this.dgvCaThi.RowTemplate.ReadOnly = true;
            this.dgvCaThi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCaThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCaThi.Size = new System.Drawing.Size(530, 185);
            this.dgvCaThi.TabIndex = 2;
            this.dgvCaThi.SelectionChanged += new System.EventHandler(this.dgvCaThi_SelectionChanged);
            // 
            // IDCaThi
            // 
            this.IDCaThi.DataPropertyName = "ID";
            this.IDCaThi.HeaderText = "ID";
            this.IDCaThi.Name = "IDCaThi";
            this.IDCaThi.ReadOnly = true;
            this.IDCaThi.Visible = false;
            this.IDCaThi.Width = 50;
            // 
            // STTCaThi
            // 
            this.STTCaThi.DataPropertyName = "STT";
            this.STTCaThi.HeaderText = "STT";
            this.STTCaThi.Name = "STTCaThi";
            this.STTCaThi.ReadOnly = true;
            this.STTCaThi.Width = 50;
            // 
            // TenCaThi
            // 
            this.TenCaThi.DataPropertyName = "CaThi";
            this.TenCaThi.HeaderText = "Ca thi";
            this.TenCaThi.Name = "TenCaThi";
            this.TenCaThi.ReadOnly = true;
            this.TenCaThi.Width = 200;
            // 
            // ThoiGianBatDau
            // 
            this.ThoiGianBatDau.DataPropertyName = "BatDau";
            this.ThoiGianBatDau.HeaderText = "Bắt đầu";
            this.ThoiGianBatDau.Name = "ThoiGianBatDau";
            this.ThoiGianBatDau.ReadOnly = true;
            this.ThoiGianBatDau.Width = 150;
            // 
            // ThoiGianKetThuc
            // 
            this.ThoiGianKetThuc.DataPropertyName = "KetThuc";
            this.ThoiGianKetThuc.HeaderText = "Kết thúc";
            this.ThoiGianKetThuc.Name = "ThoiGianKetThuc";
            this.ThoiGianKetThuc.ReadOnly = true;
            this.ThoiGianKetThuc.Width = 150;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnInKetQuaThiSinh);
            this.panel1.Controls.Add(this.btnInKetQuaCaThi);
            this.panel1.Controls.Add(this.btnInLichThi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 209);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 48);
            this.panel1.TabIndex = 1;
            // 
            // btnInKetQuaThiSinh
            // 
            this.btnInKetQuaThiSinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInKetQuaThiSinh.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnInKetQuaThiSinh.ForeColor = System.Drawing.Color.Black;
            this.btnInKetQuaThiSinh.Location = new System.Drawing.Point(422, 3);
            this.btnInKetQuaThiSinh.Name = "btnInKetQuaThiSinh";
            this.btnInKetQuaThiSinh.Size = new System.Drawing.Size(203, 39);
            this.btnInKetQuaThiSinh.TabIndex = 17;
            this.btnInKetQuaThiSinh.Text = "In kết quả thí sinh";
            this.btnInKetQuaThiSinh.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnInKetQuaThiSinh.UseCustomBackColor = true;
            this.btnInKetQuaThiSinh.UseCustomForeColor = true;
            this.btnInKetQuaThiSinh.UseSelectable = true;
            this.btnInKetQuaThiSinh.Visible = false;
            this.btnInKetQuaThiSinh.Click += new System.EventHandler(this.btnInKetQuaThiSinh_Click);
            // 
            // btnInKetQuaCaThi
            // 
            this.btnInKetQuaCaThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInKetQuaCaThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnInKetQuaCaThi.ForeColor = System.Drawing.Color.Black;
            this.btnInKetQuaCaThi.Location = new System.Drawing.Point(213, 3);
            this.btnInKetQuaCaThi.Name = "btnInKetQuaCaThi";
            this.btnInKetQuaCaThi.Size = new System.Drawing.Size(203, 39);
            this.btnInKetQuaCaThi.TabIndex = 16;
            this.btnInKetQuaCaThi.Text = "In kết quả ca thi";
            this.btnInKetQuaCaThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnInKetQuaCaThi.UseCustomBackColor = true;
            this.btnInKetQuaCaThi.UseCustomForeColor = true;
            this.btnInKetQuaCaThi.UseSelectable = true;
            this.btnInKetQuaCaThi.Visible = false;
            this.btnInKetQuaCaThi.Click += new System.EventHandler(this.btnInKetQuaCaThi_Click);
            // 
            // btnInLichThi
            // 
            this.btnInLichThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInLichThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnInLichThi.ForeColor = System.Drawing.Color.Black;
            this.btnInLichThi.Location = new System.Drawing.Point(4, 3);
            this.btnInLichThi.Name = "btnInLichThi";
            this.btnInLichThi.Size = new System.Drawing.Size(203, 39);
            this.btnInLichThi.TabIndex = 15;
            this.btnInLichThi.Text = "In lịch thi";
            this.btnInLichThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnInLichThi.UseCustomBackColor = true;
            this.btnInLichThi.UseCustomForeColor = true;
            this.btnInLichThi.UseSelectable = true;
            this.btnInLichThi.Click += new System.EventHandler(this.btnInLichThi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.dgvLichThi);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1024, 463);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách thí sinh";
            // 
            // dgvLichThi
            // 
            this.dgvLichThi.AllowUserToResizeColumns = false;
            this.dgvLichThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLichThi.ColumnHeadersHeight = 30;
            this.dgvLichThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDLichThi,
            this.STTLichThi,
            this.SBDThiSinh,
            this.TenThiSinh,
            this.NgaySinh,
            this.MonThi});
            this.dgvLichThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichThi.EnableHeadersVisualStyles = false;
            this.dgvLichThi.GridColor = System.Drawing.Color.Black;
            this.dgvLichThi.Location = new System.Drawing.Point(3, 19);
            this.dgvLichThi.MultiSelect = false;
            this.dgvLichThi.Name = "dgvLichThi";
            this.dgvLichThi.ReadOnly = true;
            this.dgvLichThi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLichThi.RowHeadersWidth = 25;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLichThi.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvLichThi.RowTemplate.Height = 30;
            this.dgvLichThi.RowTemplate.ReadOnly = true;
            this.dgvLichThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichThi.Size = new System.Drawing.Size(1018, 441);
            this.dgvLichThi.TabIndex = 2;
            // 
            // IDLichThi
            // 
            this.IDLichThi.DataPropertyName = "ID";
            this.IDLichThi.HeaderText = "ID";
            this.IDLichThi.Name = "IDLichThi";
            this.IDLichThi.ReadOnly = true;
            this.IDLichThi.Visible = false;
            // 
            // STTLichThi
            // 
            this.STTLichThi.DataPropertyName = "STT";
            this.STTLichThi.FillWeight = 7F;
            this.STTLichThi.HeaderText = "STT";
            this.STTLichThi.Name = "STTLichThi";
            this.STTLichThi.ReadOnly = true;
            // 
            // SBDThiSinh
            // 
            this.SBDThiSinh.DataPropertyName = "SBD";
            this.SBDThiSinh.FillWeight = 16F;
            this.SBDThiSinh.HeaderText = "SBD";
            this.SBDThiSinh.Name = "SBDThiSinh";
            this.SBDThiSinh.ReadOnly = true;
            // 
            // TenThiSinh
            // 
            this.TenThiSinh.DataPropertyName = "HoTen";
            this.TenThiSinh.FillWeight = 25F;
            this.TenThiSinh.HeaderText = "Họ và tên";
            this.TenThiSinh.Name = "TenThiSinh";
            this.TenThiSinh.ReadOnly = true;
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.FillWeight = 12F;
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.ReadOnly = true;
            // 
            // MonThi
            // 
            this.MonThi.DataPropertyName = "MonThi";
            this.MonThi.FillWeight = 18F;
            this.MonThi.HeaderText = "Môn thi";
            this.MonThi.Name = "MonThi";
            this.MonThi.ReadOnly = true;
            // 
            // ucLichThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelThongTin);
            this.Name = "ucLichThi";
            this.Size = new System.Drawing.Size(1024, 720);
            this.Load += new System.EventHandler(this.ucLichThi_Load);
            this.panelThongTin.ResumeLayout(false);
            this.panelDiaDiemPhongThi.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomTest)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaThi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichThi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelThongTin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianKetThuc;
        private System.Windows.Forms.Panel panelDiaDiemPhongThi;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbxLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvRoomTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPhongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTPhongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongPhongThi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvLichThi;
        private MetroFramework.Controls.MetroButton btnInLichThi;
        private MetroFramework.Controls.MetroButton btnInKetQuaThiSinh;
        private MetroFramework.Controls.MetroButton btnInKetQuaCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDLichThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTLichThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SBDThiSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenThiSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonThi;
    }
}
