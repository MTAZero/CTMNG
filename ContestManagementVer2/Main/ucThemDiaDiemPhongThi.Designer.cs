namespace ContestManagementVer2.Main
{
    partial class ucThemDiaDiemPhongThi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelPhai = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dgvPhongThi = new System.Windows.Forms.DataGridView();
            this.panel14 = new System.Windows.Forms.Panel();
            this.btnXoaPhongThi = new MetroFramework.Controls.MetroButton();
            this.btnSuaPhongThi = new MetroFramework.Controls.MetroButton();
            this.btnThemPhongThi = new MetroFramework.Controls.MetroButton();
            this.groupThongTinPhongThi = new System.Windows.Forms.GroupBox();
            this.txtSoGiamThi = new System.Windows.Forms.NumericUpDown();
            this.txtSoCho = new System.Windows.Forms.NumericUpDown();
            this.txtTenPhongThi = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dgvDiaDiemThi = new System.Windows.Forms.DataGridView();
            this.panel15 = new System.Windows.Forms.Panel();
            this.btnXoaDiaDiemThi = new MetroFramework.Controls.MetroButton();
            this.btnSuaDiaDiemThi = new MetroFramework.Controls.MetroButton();
            this.btnThemDiaDiemThi = new MetroFramework.Controls.MetroButton();
            this.groupThongTinDiaDiemThi = new System.Windows.Forms.GroupBox();
            this.txtTenDiaDiemThi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.IDDiaDiemThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STTDiaDiemThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDiaDiemThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoChoPhongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoGiamThiPhongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelPhai.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongThi)).BeginInit();
            this.panel14.SuspendLayout();
            this.groupThongTinPhongThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoGiamThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCho)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiaDiemThi)).BeginInit();
            this.panel15.SuspendLayout();
            this.groupThongTinDiaDiemThi.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPhai
            // 
            this.panelPhai.Controls.Add(this.groupBox8);
            this.panelPhai.Controls.Add(this.panel14);
            this.panelPhai.Controls.Add(this.groupThongTinPhongThi);
            this.panelPhai.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelPhai.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelPhai.Location = new System.Drawing.Point(571, 0);
            this.panelPhai.Name = "panelPhai";
            this.panelPhai.Size = new System.Drawing.Size(541, 558);
            this.panelPhai.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.White;
            this.groupBox8.Controls.Add(this.dgvPhongThi);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox8.Location = new System.Drawing.Point(0, 0);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(541, 389);
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Danh sách phòng thi";
            // 
            // dgvPhongThi
            // 
            this.dgvPhongThi.AllowUserToResizeColumns = false;
            this.dgvPhongThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhongThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhongThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPhongThi.ColumnHeadersHeight = 30;
            this.dgvPhongThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.STT,
            this.TenPhongThi,
            this.SoChoPhongThi,
            this.SoGiamThiPhongThi});
            this.dgvPhongThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhongThi.EnableHeadersVisualStyles = false;
            this.dgvPhongThi.GridColor = System.Drawing.Color.Black;
            this.dgvPhongThi.Location = new System.Drawing.Point(3, 20);
            this.dgvPhongThi.MultiSelect = false;
            this.dgvPhongThi.Name = "dgvPhongThi";
            this.dgvPhongThi.ReadOnly = true;
            this.dgvPhongThi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPhongThi.RowHeadersWidth = 25;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPhongThi.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPhongThi.RowTemplate.Height = 30;
            this.dgvPhongThi.RowTemplate.ReadOnly = true;
            this.dgvPhongThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhongThi.Size = new System.Drawing.Size(535, 366);
            this.dgvPhongThi.TabIndex = 3;
            this.dgvPhongThi.SelectionChanged += new System.EventHandler(this.dgvPhongThi_SelectionChanged);
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.White;
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Controls.Add(this.btnXoaPhongThi);
            this.panel14.Controls.Add(this.btnSuaPhongThi);
            this.panel14.Controls.Add(this.btnThemPhongThi);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(0, 389);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(541, 48);
            this.panel14.TabIndex = 9;
            // 
            // btnXoaPhongThi
            // 
            this.btnXoaPhongThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXoaPhongThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnXoaPhongThi.ForeColor = System.Drawing.Color.Black;
            this.btnXoaPhongThi.Location = new System.Drawing.Point(337, 3);
            this.btnXoaPhongThi.Name = "btnXoaPhongThi";
            this.btnXoaPhongThi.Size = new System.Drawing.Size(160, 39);
            this.btnXoaPhongThi.TabIndex = 19;
            this.btnXoaPhongThi.Text = "Xóa phòng thi";
            this.btnXoaPhongThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnXoaPhongThi.UseCustomBackColor = true;
            this.btnXoaPhongThi.UseCustomForeColor = true;
            this.btnXoaPhongThi.UseSelectable = true;
            this.btnXoaPhongThi.Click += new System.EventHandler(this.btnXoaPhongThi_Click);
            // 
            // btnSuaPhongThi
            // 
            this.btnSuaPhongThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSuaPhongThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnSuaPhongThi.ForeColor = System.Drawing.Color.Black;
            this.btnSuaPhongThi.Location = new System.Drawing.Point(171, 4);
            this.btnSuaPhongThi.Name = "btnSuaPhongThi";
            this.btnSuaPhongThi.Size = new System.Drawing.Size(160, 39);
            this.btnSuaPhongThi.TabIndex = 18;
            this.btnSuaPhongThi.Text = "Sửa phòng thi";
            this.btnSuaPhongThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnSuaPhongThi.UseCustomBackColor = true;
            this.btnSuaPhongThi.UseCustomForeColor = true;
            this.btnSuaPhongThi.UseSelectable = true;
            this.btnSuaPhongThi.Click += new System.EventHandler(this.btnSuaPhongThi_Click);
            // 
            // btnThemPhongThi
            // 
            this.btnThemPhongThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnThemPhongThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnThemPhongThi.ForeColor = System.Drawing.Color.Black;
            this.btnThemPhongThi.Location = new System.Drawing.Point(5, 3);
            this.btnThemPhongThi.Name = "btnThemPhongThi";
            this.btnThemPhongThi.Size = new System.Drawing.Size(160, 39);
            this.btnThemPhongThi.TabIndex = 17;
            this.btnThemPhongThi.Text = "Thêm phòng thi";
            this.btnThemPhongThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnThemPhongThi.UseCustomBackColor = true;
            this.btnThemPhongThi.UseCustomForeColor = true;
            this.btnThemPhongThi.UseSelectable = true;
            this.btnThemPhongThi.Click += new System.EventHandler(this.btnThemPhongThi_Click);
            // 
            // groupThongTinPhongThi
            // 
            this.groupThongTinPhongThi.BackColor = System.Drawing.Color.White;
            this.groupThongTinPhongThi.Controls.Add(this.txtSoGiamThi);
            this.groupThongTinPhongThi.Controls.Add(this.txtSoCho);
            this.groupThongTinPhongThi.Controls.Add(this.txtTenPhongThi);
            this.groupThongTinPhongThi.Controls.Add(this.label15);
            this.groupThongTinPhongThi.Controls.Add(this.label14);
            this.groupThongTinPhongThi.Controls.Add(this.label11);
            this.groupThongTinPhongThi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupThongTinPhongThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupThongTinPhongThi.Location = new System.Drawing.Point(0, 437);
            this.groupThongTinPhongThi.Margin = new System.Windows.Forms.Padding(0);
            this.groupThongTinPhongThi.Name = "groupThongTinPhongThi";
            this.groupThongTinPhongThi.Size = new System.Drawing.Size(541, 121);
            this.groupThongTinPhongThi.TabIndex = 8;
            this.groupThongTinPhongThi.TabStop = false;
            this.groupThongTinPhongThi.Text = "Thông tin phòng thi";
            // 
            // txtSoGiamThi
            // 
            this.txtSoGiamThi.Location = new System.Drawing.Point(356, 64);
            this.txtSoGiamThi.Name = "txtSoGiamThi";
            this.txtSoGiamThi.Size = new System.Drawing.Size(54, 24);
            this.txtSoGiamThi.TabIndex = 4;
            // 
            // txtSoCho
            // 
            this.txtSoCho.Location = new System.Drawing.Point(145, 64);
            this.txtSoCho.Name = "txtSoCho";
            this.txtSoCho.Size = new System.Drawing.Size(54, 24);
            this.txtSoCho.TabIndex = 3;
            // 
            // txtTenPhongThi
            // 
            this.txtTenPhongThi.Location = new System.Drawing.Point(145, 29);
            this.txtTenPhongThi.Name = "txtTenPhongThi";
            this.txtTenPhongThi.Size = new System.Drawing.Size(329, 24);
            this.txtTenPhongThi.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(267, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 17);
            this.label15.TabIndex = 2;
            this.label15.Text = "Số giám thị : ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(59, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 17);
            this.label14.TabIndex = 2;
            this.label14.Text = "Số chỗ : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(59, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "Tên phòng : ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox7);
            this.panel2.Controls.Add(this.panel15);
            this.panel2.Controls.Add(this.groupThongTinDiaDiemThi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(571, 558);
            this.panel2.TabIndex = 1;
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.White;
            this.groupBox7.Controls.Add(this.dgvDiaDiemThi);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(571, 389);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Danh sách địa điểm thi";
            // 
            // dgvDiaDiemThi
            // 
            this.dgvDiaDiemThi.AllowUserToResizeColumns = false;
            this.dgvDiaDiemThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiaDiemThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiaDiemThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDiaDiemThi.ColumnHeadersHeight = 30;
            this.dgvDiaDiemThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDDiaDiemThi,
            this.STTDiaDiemThi,
            this.TenDiaDiemThi});
            this.dgvDiaDiemThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiaDiemThi.EnableHeadersVisualStyles = false;
            this.dgvDiaDiemThi.GridColor = System.Drawing.Color.Black;
            this.dgvDiaDiemThi.Location = new System.Drawing.Point(3, 20);
            this.dgvDiaDiemThi.MultiSelect = false;
            this.dgvDiaDiemThi.Name = "dgvDiaDiemThi";
            this.dgvDiaDiemThi.ReadOnly = true;
            this.dgvDiaDiemThi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDiaDiemThi.RowHeadersWidth = 25;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDiaDiemThi.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDiaDiemThi.RowTemplate.Height = 30;
            this.dgvDiaDiemThi.RowTemplate.ReadOnly = true;
            this.dgvDiaDiemThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiaDiemThi.Size = new System.Drawing.Size(565, 366);
            this.dgvDiaDiemThi.TabIndex = 3;
            this.dgvDiaDiemThi.SelectionChanged += new System.EventHandler(this.dgvDiaDiemThi_SelectionChanged);
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.White;
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Controls.Add(this.btnXoaDiaDiemThi);
            this.panel15.Controls.Add(this.btnSuaDiaDiemThi);
            this.panel15.Controls.Add(this.btnThemDiaDiemThi);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel15.Location = new System.Drawing.Point(0, 389);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(571, 48);
            this.panel15.TabIndex = 6;
            // 
            // btnXoaDiaDiemThi
            // 
            this.btnXoaDiaDiemThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXoaDiaDiemThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnXoaDiaDiemThi.ForeColor = System.Drawing.Color.Black;
            this.btnXoaDiaDiemThi.Location = new System.Drawing.Point(334, 3);
            this.btnXoaDiaDiemThi.Name = "btnXoaDiaDiemThi";
            this.btnXoaDiaDiemThi.Size = new System.Drawing.Size(160, 39);
            this.btnXoaDiaDiemThi.TabIndex = 17;
            this.btnXoaDiaDiemThi.Text = "Xóa địa điểm";
            this.btnXoaDiaDiemThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnXoaDiaDiemThi.UseCustomBackColor = true;
            this.btnXoaDiaDiemThi.UseCustomForeColor = true;
            this.btnXoaDiaDiemThi.UseSelectable = true;
            this.btnXoaDiaDiemThi.Click += new System.EventHandler(this.btnXoaDiaDiemThi_Click);
            // 
            // btnSuaDiaDiemThi
            // 
            this.btnSuaDiaDiemThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSuaDiaDiemThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnSuaDiaDiemThi.ForeColor = System.Drawing.Color.Black; 
            this.btnSuaDiaDiemThi.Location = new System.Drawing.Point(168, 3);
            this.btnSuaDiaDiemThi.Name = "btnSuaDiaDiemThi";
            this.btnSuaDiaDiemThi.Size = new System.Drawing.Size(160, 39);
            this.btnSuaDiaDiemThi.TabIndex = 16;
            this.btnSuaDiaDiemThi.Text = "Sửa địa điểm";
            this.btnSuaDiaDiemThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnSuaDiaDiemThi.UseCustomBackColor = true;
            this.btnSuaDiaDiemThi.UseCustomForeColor = true;
            this.btnSuaDiaDiemThi.UseSelectable = true;
            this.btnSuaDiaDiemThi.Click += new System.EventHandler(this.btnSuaDiaDiemThi_Click);
            // 
            // btnThemDiaDiemThi
            // 
            this.btnThemDiaDiemThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnThemDiaDiemThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnThemDiaDiemThi.ForeColor = System.Drawing.Color.Black;
            this.btnThemDiaDiemThi.Location = new System.Drawing.Point(2, 3);
            this.btnThemDiaDiemThi.Name = "btnThemDiaDiemThi";
            this.btnThemDiaDiemThi.Size = new System.Drawing.Size(160, 39);
            this.btnThemDiaDiemThi.TabIndex = 15;
            this.btnThemDiaDiemThi.Text = "Thêm địa điểm";
            this.btnThemDiaDiemThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnThemDiaDiemThi.UseCustomBackColor = true;
            this.btnThemDiaDiemThi.UseCustomForeColor = true;
            this.btnThemDiaDiemThi.UseSelectable = true;
            this.btnThemDiaDiemThi.Click += new System.EventHandler(this.btnThemDiaDiemThi_Click);
            // 
            // groupThongTinDiaDiemThi
            // 
            this.groupThongTinDiaDiemThi.BackColor = System.Drawing.Color.White;
            this.groupThongTinDiaDiemThi.Controls.Add(this.txtTenDiaDiemThi);
            this.groupThongTinDiaDiemThi.Controls.Add(this.label9);
            this.groupThongTinDiaDiemThi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupThongTinDiaDiemThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupThongTinDiaDiemThi.Location = new System.Drawing.Point(0, 437);
            this.groupThongTinDiaDiemThi.Margin = new System.Windows.Forms.Padding(0);
            this.groupThongTinDiaDiemThi.Name = "groupThongTinDiaDiemThi";
            this.groupThongTinDiaDiemThi.Size = new System.Drawing.Size(571, 121);
            this.groupThongTinDiaDiemThi.TabIndex = 5;
            this.groupThongTinDiaDiemThi.TabStop = false;
            this.groupThongTinDiaDiemThi.Text = "Thông tin địa điểm thi";
            // 
            // txtTenDiaDiemThi
            // 
            this.txtTenDiaDiemThi.Location = new System.Drawing.Point(180, 48);
            this.txtTenDiaDiemThi.Name = "txtTenDiaDiemThi";
            this.txtTenDiaDiemThi.Size = new System.Drawing.Size(305, 24);
            this.txtTenDiaDiemThi.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(64, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tên địa điểm thi : ";
            // 
            // IDDiaDiemThi
            // 
            this.IDDiaDiemThi.DataPropertyName = "ID";
            this.IDDiaDiemThi.HeaderText = "ID";
            this.IDDiaDiemThi.Name = "IDDiaDiemThi";
            this.IDDiaDiemThi.ReadOnly = true;
            this.IDDiaDiemThi.Visible = false;
            // 
            // STTDiaDiemThi
            // 
            this.STTDiaDiemThi.DataPropertyName = "STT";
            this.STTDiaDiemThi.FillWeight = 30F;
            this.STTDiaDiemThi.HeaderText = "STT";
            this.STTDiaDiemThi.Name = "STTDiaDiemThi";
            this.STTDiaDiemThi.ReadOnly = true;
            // 
            // TenDiaDiemThi
            // 
            this.TenDiaDiemThi.DataPropertyName = "TenDiaDiemThi";
            this.TenDiaDiemThi.HeaderText = "Tên địa điểm thi";
            this.TenDiaDiemThi.Name = "TenDiaDiemThi";
            this.TenDiaDiemThi.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.FillWeight = 8F;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // TenPhongThi
            // 
            this.TenPhongThi.DataPropertyName = "TenPhongThi";
            this.TenPhongThi.FillWeight = 25F;
            this.TenPhongThi.HeaderText = "Tên phòng thi";
            this.TenPhongThi.Name = "TenPhongThi";
            this.TenPhongThi.ReadOnly = true;
            // 
            // SoChoPhongThi
            // 
            this.SoChoPhongThi.DataPropertyName = "SoCho";
            this.SoChoPhongThi.FillWeight = 12F;
            this.SoChoPhongThi.HeaderText = "Số chỗ";
            this.SoChoPhongThi.Name = "SoChoPhongThi";
            this.SoChoPhongThi.ReadOnly = true;
            // 
            // SoGiamThiPhongThi
            // 
            this.SoGiamThiPhongThi.DataPropertyName = "SoGiamThi";
            this.SoGiamThiPhongThi.FillWeight = 12F;
            this.SoGiamThiPhongThi.HeaderText = "Số giám thị";
            this.SoGiamThiPhongThi.Name = "SoGiamThiPhongThi";
            this.SoGiamThiPhongThi.ReadOnly = true;
            // 
            // ucThemDiaDiemPhongThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelPhai);
            this.Name = "ucThemDiaDiemPhongThi";
            this.Size = new System.Drawing.Size(1112, 558);
            this.Load += new System.EventHandler(this.ucThemDiaDiemPhongThi_Load);
            this.panelPhai.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongThi)).EndInit();
            this.panel14.ResumeLayout(false);
            this.groupThongTinPhongThi.ResumeLayout(false);
            this.groupThongTinPhongThi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoGiamThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCho)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiaDiemThi)).EndInit();
            this.panel15.ResumeLayout(false);
            this.groupThongTinDiaDiemThi.ResumeLayout(false);
            this.groupThongTinDiaDiemThi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPhai;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView dgvPhongThi;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.GroupBox groupThongTinPhongThi;
        private System.Windows.Forms.NumericUpDown txtSoGiamThi;
        private System.Windows.Forms.NumericUpDown txtSoCho;
        private System.Windows.Forms.TextBox txtTenPhongThi;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView dgvDiaDiemThi;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.GroupBox groupThongTinDiaDiemThi;
        private System.Windows.Forms.TextBox txtTenDiaDiemThi;
        private System.Windows.Forms.Label label9;
        private MetroFramework.Controls.MetroButton btnXoaDiaDiemThi;
        private MetroFramework.Controls.MetroButton btnSuaDiaDiemThi;
        private MetroFramework.Controls.MetroButton btnThemDiaDiemThi;
        private MetroFramework.Controls.MetroButton btnXoaPhongThi;
        private MetroFramework.Controls.MetroButton btnSuaPhongThi;
        private MetroFramework.Controls.MetroButton btnThemPhongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoChoPhongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoGiamThiPhongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDDiaDiemThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTDiaDiemThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDiaDiemThi;
    }
}
