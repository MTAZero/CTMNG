namespace ContestManagementVer2.Main
{
    partial class ucThemCaThi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.groupDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvCaThi = new System.Windows.Forms.DataGridView();
            this.IDCaThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STTCaThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThiCaThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianBatDauCaThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianKetThucCaThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.panelListButton = new System.Windows.Forms.Panel();
            this.btnXoaCaThi = new MetroFramework.Controls.MetroButton();
            this.btnSuaCaThi = new MetroFramework.Controls.MetroButton();
            this.btnThemCaThi = new MetroFramework.Controls.MetroButton();
            this.groupThongTinCaThi = new System.Windows.Forms.GroupBox();
            this.dateKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dateBatDau = new System.Windows.Forms.DateTimePicker();
            this.txtShiftName = new System.Windows.Forms.TextBox();
            this.cbxLoaiCaThi = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelGrid.SuspendLayout();
            this.groupDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaThi)).BeginInit();
            this.panelDetail.SuspendLayout();
            this.panelListButton.SuspendLayout();
            this.groupThongTinCaThi.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.panelGrid);
            this.panelMain.Controls.Add(this.panelDetail);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1017, 586);
            this.panelMain.TabIndex = 1;
            // 
            // panelGrid
            // 
            this.panelGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelGrid.Controls.Add(this.groupDanhSach);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 0);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(674, 584);
            this.panelGrid.TabIndex = 1;
            // 
            // groupDanhSach
            // 
            this.groupDanhSach.Controls.Add(this.dgvCaThi);
            this.groupDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDanhSach.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDanhSach.Location = new System.Drawing.Point(0, 0);
            this.groupDanhSach.Name = "groupDanhSach";
            this.groupDanhSach.Size = new System.Drawing.Size(670, 580);
            this.groupDanhSach.TabIndex = 0;
            this.groupDanhSach.TabStop = false;
            this.groupDanhSach.Text = "Danh sách ca thi";
            // 
            // dgvCaThi
            // 
            this.dgvCaThi.AllowUserToResizeColumns = false;
            this.dgvCaThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvCaThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCaThi.ColumnHeadersHeight = 30;
            this.dgvCaThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCaThi,
            this.STTCaThi,
            this.dataGridViewTextBoxColumn3,
            this.NgayThiCaThi,
            this.ThoiGianBatDauCaThi,
            this.ThoiGianKetThucCaThi});
            this.dgvCaThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCaThi.EnableHeadersVisualStyles = false;
            this.dgvCaThi.GridColor = System.Drawing.Color.Black;
            this.dgvCaThi.Location = new System.Drawing.Point(3, 19);
            this.dgvCaThi.MultiSelect = false;
            this.dgvCaThi.Name = "dgvCaThi";
            this.dgvCaThi.ReadOnly = true;
            this.dgvCaThi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCaThi.RowHeadersWidth = 25;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCaThi.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCaThi.RowTemplate.Height = 30;
            this.dgvCaThi.RowTemplate.ReadOnly = true;
            this.dgvCaThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCaThi.Size = new System.Drawing.Size(664, 558);
            this.dgvCaThi.TabIndex = 3;
            this.dgvCaThi.SelectionChanged += new System.EventHandler(this.dgvCaThi_SelectionChanged);
            // 
            // IDCaThi
            // 
            this.IDCaThi.DataPropertyName = "ID";
            this.IDCaThi.HeaderText = "ID";
            this.IDCaThi.Name = "IDCaThi";
            this.IDCaThi.ReadOnly = true;
            this.IDCaThi.Visible = false;
            // 
            // STTCaThi
            // 
            this.STTCaThi.DataPropertyName = "STT";
            this.STTCaThi.FillWeight = 8F;
            this.STTCaThi.HeaderText = "STT";
            this.STTCaThi.Name = "STTCaThi";
            this.STTCaThi.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TenCaThi";
            this.dataGridViewTextBoxColumn3.FillWeight = 20F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Tên ca thi";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // NgayThiCaThi
            // 
            this.NgayThiCaThi.DataPropertyName = "NgayThi";
            this.NgayThiCaThi.FillWeight = 15F;
            this.NgayThiCaThi.HeaderText = "Ngày thi";
            this.NgayThiCaThi.Name = "NgayThiCaThi";
            this.NgayThiCaThi.ReadOnly = true;
            // 
            // ThoiGianBatDauCaThi
            // 
            this.ThoiGianBatDauCaThi.DataPropertyName = "ThoiGianBatDau";
            this.ThoiGianBatDauCaThi.FillWeight = 15F;
            this.ThoiGianBatDauCaThi.HeaderText = "Thời gian bắt đầu";
            this.ThoiGianBatDauCaThi.Name = "ThoiGianBatDauCaThi";
            this.ThoiGianBatDauCaThi.ReadOnly = true;
            // 
            // ThoiGianKetThucCaThi
            // 
            this.ThoiGianKetThucCaThi.DataPropertyName = "ThoiGianKetThuc";
            this.ThoiGianKetThucCaThi.FillWeight = 15F;
            this.ThoiGianKetThucCaThi.HeaderText = "Thời gian kết thúc";
            this.ThoiGianKetThucCaThi.Name = "ThoiGianKetThucCaThi";
            this.ThoiGianKetThucCaThi.ReadOnly = true;
            // 
            // panelDetail
            // 
            this.panelDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDetail.Controls.Add(this.panelListButton);
            this.panelDetail.Controls.Add(this.groupThongTinCaThi);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDetail.Location = new System.Drawing.Point(674, 0);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(341, 584);
            this.panelDetail.TabIndex = 0;
            // 
            // panelListButton
            // 
            this.panelListButton.BackColor = System.Drawing.Color.White;
            this.panelListButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelListButton.Controls.Add(this.btnXoaCaThi);
            this.panelListButton.Controls.Add(this.btnSuaCaThi);
            this.panelListButton.Controls.Add(this.btnThemCaThi);
            this.panelListButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelListButton.Location = new System.Drawing.Point(0, 201);
            this.panelListButton.Name = "panelListButton";
            this.panelListButton.Size = new System.Drawing.Size(337, 96);
            this.panelListButton.TabIndex = 1;
            // 
            // btnXoaCaThi
            // 
            this.btnXoaCaThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXoaCaThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnXoaCaThi.ForeColor = System.Drawing.Color.Black;
            this.btnXoaCaThi.Location = new System.Drawing.Point(3, 48);
            this.btnXoaCaThi.Name = "btnXoaCaThi";
            this.btnXoaCaThi.Size = new System.Drawing.Size(327, 39);
            this.btnXoaCaThi.TabIndex = 16;
            this.btnXoaCaThi.Text = "Xóa";
            this.btnXoaCaThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnXoaCaThi.UseCustomBackColor = true;
            this.btnXoaCaThi.UseCustomForeColor = true;
            this.btnXoaCaThi.UseSelectable = true;
            this.btnXoaCaThi.Click += new System.EventHandler(this.btnXoaCaThi_Click);
            // 
            // btnSuaCaThi
            // 
            this.btnSuaCaThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSuaCaThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnSuaCaThi.ForeColor = System.Drawing.Color.Black;
            this.btnSuaCaThi.Location = new System.Drawing.Point(169, 5);
            this.btnSuaCaThi.Name = "btnSuaCaThi";
            this.btnSuaCaThi.Size = new System.Drawing.Size(161, 39);
            this.btnSuaCaThi.TabIndex = 15;
            this.btnSuaCaThi.Text = "Sửa";
            this.btnSuaCaThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnSuaCaThi.UseCustomBackColor = true;
            this.btnSuaCaThi.UseCustomForeColor = true;
            this.btnSuaCaThi.UseSelectable = true;
            this.btnSuaCaThi.Click += new System.EventHandler(this.btnSuaCaThi_Click);
            // 
            // btnThemCaThi
            // 
            this.btnThemCaThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnThemCaThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnThemCaThi.ForeColor = System.Drawing.Color.Black;
            this.btnThemCaThi.Location = new System.Drawing.Point(3, 5);
            this.btnThemCaThi.Name = "btnThemCaThi";
            this.btnThemCaThi.Size = new System.Drawing.Size(160, 39);
            this.btnThemCaThi.TabIndex = 14;
            this.btnThemCaThi.Text = "Thêm";
            this.btnThemCaThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnThemCaThi.UseCustomBackColor = true;
            this.btnThemCaThi.UseCustomForeColor = true;
            this.btnThemCaThi.UseSelectable = true;
            this.btnThemCaThi.Click += new System.EventHandler(this.btnThemCaThi_Click);
            // 
            // groupThongTinCaThi
            // 
            this.groupThongTinCaThi.BackColor = System.Drawing.Color.White;
            this.groupThongTinCaThi.Controls.Add(this.dateKetThuc);
            this.groupThongTinCaThi.Controls.Add(this.dateBatDau);
            this.groupThongTinCaThi.Controls.Add(this.txtShiftName);
            this.groupThongTinCaThi.Controls.Add(this.cbxLoaiCaThi);
            this.groupThongTinCaThi.Controls.Add(this.label8);
            this.groupThongTinCaThi.Controls.Add(this.label10);
            this.groupThongTinCaThi.Controls.Add(this.label12);
            this.groupThongTinCaThi.Controls.Add(this.label13);
            this.groupThongTinCaThi.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupThongTinCaThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupThongTinCaThi.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupThongTinCaThi.Location = new System.Drawing.Point(0, 0);
            this.groupThongTinCaThi.Name = "groupThongTinCaThi";
            this.groupThongTinCaThi.Size = new System.Drawing.Size(337, 201);
            this.groupThongTinCaThi.TabIndex = 0;
            this.groupThongTinCaThi.TabStop = false;
            this.groupThongTinCaThi.Text = "Chi tiết ca thi";
            // 
            // dateKetThuc
            // 
            this.dateKetThuc.CustomFormat = "HH:mm";
            this.dateKetThuc.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateKetThuc.Location = new System.Drawing.Point(157, 159);
            this.dateKetThuc.Name = "dateKetThuc";
            this.dateKetThuc.Size = new System.Drawing.Size(65, 23);
            this.dateKetThuc.TabIndex = 13;
            // 
            // dateBatDau
            // 
            this.dateBatDau.CustomFormat = "HH:mm";
            this.dateBatDau.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateBatDau.Location = new System.Drawing.Point(157, 114);
            this.dateBatDau.Name = "dateBatDau";
            this.dateBatDau.Size = new System.Drawing.Size(65, 23);
            this.dateBatDau.TabIndex = 12;
            // 
            // txtShiftName
            // 
            this.txtShiftName.Location = new System.Drawing.Point(109, 27);
            this.txtShiftName.Name = "txtShiftName";
            this.txtShiftName.Size = new System.Drawing.Size(211, 23);
            this.txtShiftName.TabIndex = 11;
            // 
            // cbxLoaiCaThi
            // 
            this.cbxLoaiCaThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLoaiCaThi.FormattingEnabled = true;
            this.cbxLoaiCaThi.Items.AddRange(new object[] {
            "Ca thi chính thức",
            "Ca thi dự phòng"});
            this.cbxLoaiCaThi.Location = new System.Drawing.Point(111, 72);
            this.cbxLoaiCaThi.Name = "cbxLoaiCaThi";
            this.cbxLoaiCaThi.Size = new System.Drawing.Size(173, 23);
            this.cbxLoaiCaThi.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Thời gian kết thúc : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 16);
            this.label10.TabIndex = 7;
            this.label10.Text = "Thời gian bắt đầu :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 16);
            this.label12.TabIndex = 8;
            this.label12.Text = "Loại ca thi : ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 16);
            this.label13.TabIndex = 9;
            this.label13.Text = "Tên ca thi : ";
            // 
            // ucThemCaThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "ucThemCaThi";
            this.Size = new System.Drawing.Size(1017, 586);
            this.Load += new System.EventHandler(this.ucThemCaThi_Load);
            this.panelMain.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            this.groupDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaThi)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panelListButton.ResumeLayout(false);
            this.groupThongTinCaThi.ResumeLayout(false);
            this.groupThongTinCaThi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.GroupBox groupDanhSach;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Panel panelListButton;
        private MetroFramework.Controls.MetroButton btnXoaCaThi;
        private MetroFramework.Controls.MetroButton btnSuaCaThi;
        private MetroFramework.Controls.MetroButton btnThemCaThi;
        private System.Windows.Forms.GroupBox groupThongTinCaThi;
        private System.Windows.Forms.DateTimePicker dateKetThuc;
        private System.Windows.Forms.DateTimePicker dateBatDau;
        private System.Windows.Forms.TextBox txtShiftName;
        private System.Windows.Forms.ComboBox cbxLoaiCaThi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThiCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianBatDauCaThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianKetThucCaThi;
    }
}
