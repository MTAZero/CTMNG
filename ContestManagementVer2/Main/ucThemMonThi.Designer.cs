namespace ContestManagementVer2.Main
{
    partial class ucThemMonThi
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.groupDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvMonThi = new System.Windows.Forms.DataGridView();
            this.groupThongTinMonThi = new System.Windows.Forms.GroupBox();
            this.panelListButton = new System.Windows.Forms.Panel();
            this.btnThem = new MetroFramework.Controls.MetroButton();
            this.btnSua = new MetroFramework.Controls.MetroButton();
            this.btnXoa = new MetroFramework.Controls.MetroButton();
            this.txtLePhiThi = new System.Windows.Forms.TextBox();
            this.txtLePhiThiLabel = new System.Windows.Forms.Label();
            this.cbxHinhThucThi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimeToSubmit = new System.Windows.Forms.NumericUpDown();
            this.txtTimeOfTest = new System.Windows.Forms.NumericUpDown();
            this.cbxMonThi = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IDMonThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianNopBai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HinhThucThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LePhiThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMain.SuspendLayout();
            this.panelDetail.SuspendLayout();
            this.panelGrid.SuspendLayout();
            this.groupDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonThi)).BeginInit();
            this.groupThongTinMonThi.SuspendLayout();
            this.panelListButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeToSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeOfTest)).BeginInit();
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
            this.panelMain.Size = new System.Drawing.Size(987, 628);
            this.panelMain.TabIndex = 0;
            // 
            // panelDetail
            // 
            this.panelDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDetail.Controls.Add(this.panelListButton);
            this.panelDetail.Controls.Add(this.groupThongTinMonThi);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDetail.Location = new System.Drawing.Point(644, 0);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(341, 626);
            this.panelDetail.TabIndex = 0;
            // 
            // panelGrid
            // 
            this.panelGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelGrid.Controls.Add(this.groupDanhSach);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 0);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(644, 626);
            this.panelGrid.TabIndex = 1;
            // 
            // groupDanhSach
            // 
            this.groupDanhSach.Controls.Add(this.dgvMonThi);
            this.groupDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDanhSach.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDanhSach.Location = new System.Drawing.Point(0, 0);
            this.groupDanhSach.Name = "groupDanhSach";
            this.groupDanhSach.Size = new System.Drawing.Size(640, 622);
            this.groupDanhSach.TabIndex = 0;
            this.groupDanhSach.TabStop = false;
            this.groupDanhSach.Text = "Danh sách môn thi";
            // 
            // dgvMonThi
            // 
            this.dgvMonThi.AllowUserToResizeColumns = false;
            this.dgvMonThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvMonThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMonThi.ColumnHeadersHeight = 30;
            this.dgvMonThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDMonThi,
            this.STT,
            this.MonThi,
            this.ThoiGianThi,
            this.ThoiGianNopBai,
            this.HinhThucThi,
            this.LePhiThi});
            this.dgvMonThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonThi.EnableHeadersVisualStyles = false;
            this.dgvMonThi.GridColor = System.Drawing.Color.Black;
            this.dgvMonThi.Location = new System.Drawing.Point(3, 19);
            this.dgvMonThi.MultiSelect = false;
            this.dgvMonThi.Name = "dgvMonThi";
            this.dgvMonThi.ReadOnly = true;
            this.dgvMonThi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMonThi.RowHeadersWidth = 25;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMonThi.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMonThi.RowTemplate.Height = 30;
            this.dgvMonThi.RowTemplate.ReadOnly = true;
            this.dgvMonThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonThi.Size = new System.Drawing.Size(634, 600);
            this.dgvMonThi.TabIndex = 4;
            this.dgvMonThi.SelectionChanged += new System.EventHandler(this.dgvMonThi_SelectionChanged);
            // 
            // groupThongTinMonThi
            // 
            this.groupThongTinMonThi.BackColor = System.Drawing.Color.White;
            this.groupThongTinMonThi.Controls.Add(this.txtLePhiThi);
            this.groupThongTinMonThi.Controls.Add(this.txtLePhiThiLabel);
            this.groupThongTinMonThi.Controls.Add(this.cbxHinhThucThi);
            this.groupThongTinMonThi.Controls.Add(this.label1);
            this.groupThongTinMonThi.Controls.Add(this.txtTimeToSubmit);
            this.groupThongTinMonThi.Controls.Add(this.txtTimeOfTest);
            this.groupThongTinMonThi.Controls.Add(this.cbxMonThi);
            this.groupThongTinMonThi.Controls.Add(this.label7);
            this.groupThongTinMonThi.Controls.Add(this.label4);
            this.groupThongTinMonThi.Controls.Add(this.label6);
            this.groupThongTinMonThi.Controls.Add(this.label3);
            this.groupThongTinMonThi.Controls.Add(this.label2);
            this.groupThongTinMonThi.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupThongTinMonThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupThongTinMonThi.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupThongTinMonThi.Location = new System.Drawing.Point(0, 0);
            this.groupThongTinMonThi.Name = "groupThongTinMonThi";
            this.groupThongTinMonThi.Size = new System.Drawing.Size(337, 262);
            this.groupThongTinMonThi.TabIndex = 0;
            this.groupThongTinMonThi.TabStop = false;
            this.groupThongTinMonThi.Text = "Chi tiết môn thi";
            // 
            // panelListButton
            // 
            this.panelListButton.BackColor = System.Drawing.Color.White;
            this.panelListButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelListButton.Controls.Add(this.btnXoa);
            this.panelListButton.Controls.Add(this.btnSua);
            this.panelListButton.Controls.Add(this.btnThem);
            this.panelListButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelListButton.Location = new System.Drawing.Point(0, 262);
            this.panelListButton.Name = "panelListButton";
            this.panelListButton.Size = new System.Drawing.Size(337, 96);
            this.panelListButton.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnThem.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.Location = new System.Drawing.Point(3, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(160, 39);
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "Thêm";
            this.btnThem.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnThem.UseCustomBackColor = true;
            this.btnThem.UseCustomForeColor = true;
            this.btnThem.UseSelectable = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSua.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.Location = new System.Drawing.Point(169, 5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(161, 39);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnSua.UseCustomBackColor = true;
            this.btnSua.UseCustomForeColor = true;
            this.btnSua.UseSelectable = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXoa.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Location = new System.Drawing.Point(3, 48);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(327, 39);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnXoa.UseCustomBackColor = true;
            this.btnXoa.UseCustomForeColor = true;
            this.btnXoa.UseSelectable = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtLePhiThi
            // 
            this.txtLePhiThi.Location = new System.Drawing.Point(115, 213);
            this.txtLePhiThi.Name = "txtLePhiThi";
            this.txtLePhiThi.Size = new System.Drawing.Size(169, 23);
            this.txtLePhiThi.TabIndex = 5;
            // 
            // txtLePhiThiLabel
            // 
            this.txtLePhiThiLabel.AutoSize = true;
            this.txtLePhiThiLabel.Location = new System.Drawing.Point(15, 216);
            this.txtLePhiThiLabel.Name = "txtLePhiThiLabel";
            this.txtLePhiThiLabel.Size = new System.Drawing.Size(69, 16);
            this.txtLePhiThiLabel.TabIndex = 17;
            this.txtLePhiThiLabel.Text = "Lệ phí thi :";
            // 
            // cbxHinhThucThi
            // 
            this.cbxHinhThucThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHinhThucThi.FormattingEnabled = true;
            this.cbxHinhThucThi.Location = new System.Drawing.Point(115, 166);
            this.cbxHinhThucThi.Name = "cbxHinhThucThi";
            this.cbxHinhThucThi.Size = new System.Drawing.Size(215, 23);
            this.cbxHinhThucThi.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Hình thức thi : ";
            // 
            // txtTimeToSubmit
            // 
            this.txtTimeToSubmit.Location = new System.Drawing.Point(172, 120);
            this.txtTimeToSubmit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtTimeToSubmit.Name = "txtTimeToSubmit";
            this.txtTimeToSubmit.Size = new System.Drawing.Size(54, 23);
            this.txtTimeToSubmit.TabIndex = 3;
            this.txtTimeToSubmit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtTimeOfTest
            // 
            this.txtTimeOfTest.Location = new System.Drawing.Point(115, 73);
            this.txtTimeOfTest.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtTimeOfTest.Name = "txtTimeOfTest";
            this.txtTimeOfTest.Size = new System.Drawing.Size(54, 23);
            this.txtTimeOfTest.TabIndex = 2;
            this.txtTimeOfTest.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbxMonThi
            // 
            this.cbxMonThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMonThi.FormattingEnabled = true;
            this.cbxMonThi.Location = new System.Drawing.Point(115, 25);
            this.cbxMonThi.Name = "cbxMonThi";
            this.cbxMonThi.Size = new System.Drawing.Size(215, 23);
            this.cbxMonThi.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "phút";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Thời gian có thể nộp bài : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "phút";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Thời gian : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Môn thi : ";
            // 
            // IDMonThi
            // 
            this.IDMonThi.DataPropertyName = "ID";
            this.IDMonThi.HeaderText = "ID";
            this.IDMonThi.Name = "IDMonThi";
            this.IDMonThi.ReadOnly = true;
            this.IDMonThi.Visible = false;
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.FillWeight = 5F;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // MonThi
            // 
            this.MonThi.DataPropertyName = "MonThi";
            this.MonThi.FillWeight = 15F;
            this.MonThi.HeaderText = "Môn thi";
            this.MonThi.Name = "MonThi";
            this.MonThi.ReadOnly = true;
            // 
            // ThoiGianThi
            // 
            this.ThoiGianThi.DataPropertyName = "ThoiGianThi";
            this.ThoiGianThi.FillWeight = 15F;
            this.ThoiGianThi.HeaderText = "Thời gian thi";
            this.ThoiGianThi.Name = "ThoiGianThi";
            this.ThoiGianThi.ReadOnly = true;
            // 
            // ThoiGianNopBai
            // 
            this.ThoiGianNopBai.DataPropertyName = "ThoiGianNopBai";
            this.ThoiGianNopBai.FillWeight = 15F;
            this.ThoiGianNopBai.HeaderText = "Thời gian nộp bài";
            this.ThoiGianNopBai.Name = "ThoiGianNopBai";
            this.ThoiGianNopBai.ReadOnly = true;
            this.ThoiGianNopBai.Visible = false;
            // 
            // HinhThucThi
            // 
            this.HinhThucThi.DataPropertyName = "HinhThucThi";
            this.HinhThucThi.FillWeight = 15F;
            this.HinhThucThi.HeaderText = "Hình thức thi";
            this.HinhThucThi.Name = "HinhThucThi";
            this.HinhThucThi.ReadOnly = true;
            // 
            // LePhiThi
            // 
            this.LePhiThi.DataPropertyName = "LePhiThi";
            this.LePhiThi.FillWeight = 15F;
            this.LePhiThi.HeaderText = "Lệ phí thi";
            this.LePhiThi.Name = "LePhiThi";
            this.LePhiThi.ReadOnly = true;
            // 
            // ucThemMonThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "ucThemMonThi";
            this.Size = new System.Drawing.Size(987, 628);
            this.Load += new System.EventHandler(this.ucThemMonThi_Load);
            this.panelMain.ResumeLayout(false);
            this.panelDetail.ResumeLayout(false);
            this.panelGrid.ResumeLayout(false);
            this.groupDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonThi)).EndInit();
            this.groupThongTinMonThi.ResumeLayout(false);
            this.groupThongTinMonThi.PerformLayout();
            this.panelListButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeToSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeOfTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.GroupBox groupDanhSach;
        private System.Windows.Forms.DataGridView dgvMonThi;
        private System.Windows.Forms.GroupBox groupThongTinMonThi;
        private System.Windows.Forms.Panel panelListButton;
        private MetroFramework.Controls.MetroButton btnXoa;
        private MetroFramework.Controls.MetroButton btnSua;
        private MetroFramework.Controls.MetroButton btnThem;
        private System.Windows.Forms.TextBox txtLePhiThi;
        private System.Windows.Forms.Label txtLePhiThiLabel;
        private System.Windows.Forms.ComboBox cbxHinhThucThi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtTimeToSubmit;
        private System.Windows.Forms.NumericUpDown txtTimeOfTest;
        private System.Windows.Forms.ComboBox cbxMonThi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMonThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianNopBai;
        private System.Windows.Forms.DataGridViewTextBoxColumn HinhThucThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn LePhiThi;
    }
}
