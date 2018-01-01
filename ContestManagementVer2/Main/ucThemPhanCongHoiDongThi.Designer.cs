namespace ContestManagementVer2.Main
{
    partial class ucThemPhanCongHoiDongThi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXoaPhanCongHoiDongThi = new MetroFramework.Controls.MetroButton();
            this.btnThemPhanCongHoiDongThi = new MetroFramework.Controls.MetroButton();
            this.groupThongTinHoiDongThi = new System.Windows.Forms.GroupBox();
            this.txtTaiKhoanHoiDongThi = new System.Windows.Forms.TextBox();
            this.cbxDiaDiem = new System.Windows.Forms.ComboBox();
            this.cbxChucVuHoiDongThi = new System.Windows.Forms.ComboBox();
            this.cbxCanBoHoiDongThi = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvHoiDongThi = new System.Windows.Forms.DataGridView();
            this.IDHoiDongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STTHoiDongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanBoHoiDongTHi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChucVuHoiDongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaDiemHoiDongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaiKhoanHoiDongThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel10.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupThongTinHoiDongThi.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoiDongThi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel1);
            this.panel10.Controls.Add(this.groupThongTinHoiDongThi);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(733, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(372, 658);
            this.panel10.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnXoaPhanCongHoiDongThi);
            this.panel1.Controls.Add(this.btnThemPhanCongHoiDongThi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 229);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 54);
            this.panel1.TabIndex = 1;
            // 
            // btnXoaPhanCongHoiDongThi
            // 
            this.btnXoaPhanCongHoiDongThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXoaPhanCongHoiDongThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnXoaPhanCongHoiDongThi.ForeColor = System.Drawing.Color.Black;
            this.btnXoaPhanCongHoiDongThi.Location = new System.Drawing.Point(190, 6);
            this.btnXoaPhanCongHoiDongThi.Name = "btnXoaPhanCongHoiDongThi";
            this.btnXoaPhanCongHoiDongThi.Size = new System.Drawing.Size(178, 39);
            this.btnXoaPhanCongHoiDongThi.TabIndex = 17;
            this.btnXoaPhanCongHoiDongThi.Text = "Xóa phân công";
            this.btnXoaPhanCongHoiDongThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnXoaPhanCongHoiDongThi.UseCustomBackColor = true;
            this.btnXoaPhanCongHoiDongThi.UseCustomForeColor = true;
            this.btnXoaPhanCongHoiDongThi.UseSelectable = true;
            this.btnXoaPhanCongHoiDongThi.Click += new System.EventHandler(this.btnXoaPhanCongHoiDongThi_Click);
            // 
            // btnThemPhanCongHoiDongThi
            // 
            this.btnThemPhanCongHoiDongThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnThemPhanCongHoiDongThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnThemPhanCongHoiDongThi.ForeColor = System.Drawing.Color.Black;
            this.btnThemPhanCongHoiDongThi.Location = new System.Drawing.Point(6, 6);
            this.btnThemPhanCongHoiDongThi.Name = "btnThemPhanCongHoiDongThi";
            this.btnThemPhanCongHoiDongThi.Size = new System.Drawing.Size(178, 39);
            this.btnThemPhanCongHoiDongThi.TabIndex = 16;
            this.btnThemPhanCongHoiDongThi.Text = "Thêm phân công";
            this.btnThemPhanCongHoiDongThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnThemPhanCongHoiDongThi.UseCustomBackColor = true;
            this.btnThemPhanCongHoiDongThi.UseCustomForeColor = true;
            this.btnThemPhanCongHoiDongThi.UseSelectable = true;
            this.btnThemPhanCongHoiDongThi.Click += new System.EventHandler(this.btnThemPhanCongHoiDongThi_Click);
            // 
            // groupThongTinHoiDongThi
            // 
            this.groupThongTinHoiDongThi.BackColor = System.Drawing.Color.White;
            this.groupThongTinHoiDongThi.Controls.Add(this.txtTaiKhoanHoiDongThi);
            this.groupThongTinHoiDongThi.Controls.Add(this.cbxDiaDiem);
            this.groupThongTinHoiDongThi.Controls.Add(this.cbxChucVuHoiDongThi);
            this.groupThongTinHoiDongThi.Controls.Add(this.cbxCanBoHoiDongThi);
            this.groupThongTinHoiDongThi.Controls.Add(this.label20);
            this.groupThongTinHoiDongThi.Controls.Add(this.label22);
            this.groupThongTinHoiDongThi.Controls.Add(this.label24);
            this.groupThongTinHoiDongThi.Controls.Add(this.label25);
            this.groupThongTinHoiDongThi.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupThongTinHoiDongThi.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupThongTinHoiDongThi.Location = new System.Drawing.Point(0, 0);
            this.groupThongTinHoiDongThi.Name = "groupThongTinHoiDongThi";
            this.groupThongTinHoiDongThi.Size = new System.Drawing.Size(372, 229);
            this.groupThongTinHoiDongThi.TabIndex = 0;
            this.groupThongTinHoiDongThi.TabStop = false;
            this.groupThongTinHoiDongThi.Text = "Chi tiết phân công";
            // 
            // txtTaiKhoanHoiDongThi
            // 
            this.txtTaiKhoanHoiDongThi.Enabled = false;
            this.txtTaiKhoanHoiDongThi.Location = new System.Drawing.Point(130, 170);
            this.txtTaiKhoanHoiDongThi.Name = "txtTaiKhoanHoiDongThi";
            this.txtTaiKhoanHoiDongThi.Size = new System.Drawing.Size(158, 24);
            this.txtTaiKhoanHoiDongThi.TabIndex = 5;
            // 
            // cbxDiaDiem
            // 
            this.cbxDiaDiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDiaDiem.FormattingEnabled = true;
            this.cbxDiaDiem.Location = new System.Drawing.Point(130, 123);
            this.cbxDiaDiem.Name = "cbxDiaDiem";
            this.cbxDiaDiem.Size = new System.Drawing.Size(197, 25);
            this.cbxDiaDiem.TabIndex = 4;
            this.cbxDiaDiem.EnabledChanged += new System.EventHandler(this.cbxDiaDiem_EnabledChanged);
            // 
            // cbxChucVuHoiDongThi
            // 
            this.cbxChucVuHoiDongThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChucVuHoiDongThi.FormattingEnabled = true;
            this.cbxChucVuHoiDongThi.Location = new System.Drawing.Point(130, 76);
            this.cbxChucVuHoiDongThi.Name = "cbxChucVuHoiDongThi";
            this.cbxChucVuHoiDongThi.Size = new System.Drawing.Size(197, 25);
            this.cbxChucVuHoiDongThi.TabIndex = 3;
            // 
            // cbxCanBoHoiDongThi
            // 
            this.cbxCanBoHoiDongThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCanBoHoiDongThi.FormattingEnabled = true;
            this.cbxCanBoHoiDongThi.Location = new System.Drawing.Point(130, 29);
            this.cbxCanBoHoiDongThi.Name = "cbxCanBoHoiDongThi";
            this.cbxCanBoHoiDongThi.Size = new System.Drawing.Size(197, 25);
            this.cbxCanBoHoiDongThi.TabIndex = 2;
            this.cbxCanBoHoiDongThi.SelectedIndexChanged += new System.EventHandler(this.cbxCanBoHoiDongThi_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(56, 173);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 17);
            this.label20.TabIndex = 0;
            this.label20.Text = "Tài khoản : ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(56, 126);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 17);
            this.label22.TabIndex = 0;
            this.label22.Text = "Địa điểm :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(56, 79);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(69, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "Chức vụ : ";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(56, 32);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(61, 17);
            this.label25.TabIndex = 0;
            this.label25.Text = "Cán bộ : ";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox6.Controls.Add(this.dgvHoiDongThi);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(733, 658);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Danh sách phần công cán bộ";
            // 
            // dgvHoiDongThi
            // 
            this.dgvHoiDongThi.AllowUserToResizeColumns = false;
            this.dgvHoiDongThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoiDongThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoiDongThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvHoiDongThi.ColumnHeadersHeight = 30;
            this.dgvHoiDongThi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDHoiDongThi,
            this.STTHoiDongThi,
            this.CanBoHoiDongTHi,
            this.ChucVuHoiDongThi,
            this.DiaDiemHoiDongThi,
            this.TaiKhoanHoiDongThi});
            this.dgvHoiDongThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoiDongThi.EnableHeadersVisualStyles = false;
            this.dgvHoiDongThi.GridColor = System.Drawing.Color.Black;
            this.dgvHoiDongThi.Location = new System.Drawing.Point(3, 20);
            this.dgvHoiDongThi.MultiSelect = false;
            this.dgvHoiDongThi.Name = "dgvHoiDongThi";
            this.dgvHoiDongThi.ReadOnly = true;
            this.dgvHoiDongThi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvHoiDongThi.RowHeadersWidth = 25;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHoiDongThi.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoiDongThi.RowTemplate.Height = 30;
            this.dgvHoiDongThi.RowTemplate.ReadOnly = true;
            this.dgvHoiDongThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoiDongThi.Size = new System.Drawing.Size(727, 635);
            this.dgvHoiDongThi.TabIndex = 3;
            this.dgvHoiDongThi.SelectionChanged += new System.EventHandler(this.dgvHoiDongThi_SelectionChanged);
            // 
            // IDHoiDongThi
            // 
            this.IDHoiDongThi.DataPropertyName = "ID";
            this.IDHoiDongThi.HeaderText = "IDHoiDongThi";
            this.IDHoiDongThi.Name = "IDHoiDongThi";
            this.IDHoiDongThi.ReadOnly = true;
            this.IDHoiDongThi.Visible = false;
            // 
            // STTHoiDongThi
            // 
            this.STTHoiDongThi.DataPropertyName = "STT";
            this.STTHoiDongThi.FillWeight = 10F;
            this.STTHoiDongThi.HeaderText = "STT";
            this.STTHoiDongThi.Name = "STTHoiDongThi";
            this.STTHoiDongThi.ReadOnly = true;
            // 
            // CanBoHoiDongTHi
            // 
            this.CanBoHoiDongTHi.DataPropertyName = "HoTen";
            this.CanBoHoiDongTHi.FillWeight = 30F;
            this.CanBoHoiDongTHi.HeaderText = "Cán bộ";
            this.CanBoHoiDongTHi.Name = "CanBoHoiDongTHi";
            this.CanBoHoiDongTHi.ReadOnly = true;
            // 
            // ChucVuHoiDongThi
            // 
            this.ChucVuHoiDongThi.DataPropertyName = "ChucVu";
            this.ChucVuHoiDongThi.FillWeight = 30F;
            this.ChucVuHoiDongThi.HeaderText = "Chức vụ ";
            this.ChucVuHoiDongThi.Name = "ChucVuHoiDongThi";
            this.ChucVuHoiDongThi.ReadOnly = true;
            // 
            // DiaDiemHoiDongThi
            // 
            this.DiaDiemHoiDongThi.DataPropertyName = "DiaDiem";
            this.DiaDiemHoiDongThi.FillWeight = 30F;
            this.DiaDiemHoiDongThi.HeaderText = "Địa điểm thi";
            this.DiaDiemHoiDongThi.Name = "DiaDiemHoiDongThi";
            this.DiaDiemHoiDongThi.ReadOnly = true;
            // 
            // TaiKhoanHoiDongThi
            // 
            this.TaiKhoanHoiDongThi.DataPropertyName = "TaiKhoan";
            this.TaiKhoanHoiDongThi.FillWeight = 30F;
            this.TaiKhoanHoiDongThi.HeaderText = "Tài khoản hội đồng thi";
            this.TaiKhoanHoiDongThi.Name = "TaiKhoanHoiDongThi";
            this.TaiKhoanHoiDongThi.ReadOnly = true;
            // 
            // ucThemPhanCongHoiDongThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.panel10);
            this.Name = "ucThemPhanCongHoiDongThi";
            this.Size = new System.Drawing.Size(1105, 658);
            this.Load += new System.EventHandler(this.ucThemPhanCongHoiDongThi_Load);
            this.panel10.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupThongTinHoiDongThi.ResumeLayout(false);
            this.groupThongTinHoiDongThi.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoiDongThi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.GroupBox groupThongTinHoiDongThi;
        private System.Windows.Forms.TextBox txtTaiKhoanHoiDongThi;
        private System.Windows.Forms.ComboBox cbxDiaDiem;
        private System.Windows.Forms.ComboBox cbxChucVuHoiDongThi;
        private System.Windows.Forms.ComboBox cbxCanBoHoiDongThi;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvHoiDongThi;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton btnXoaPhanCongHoiDongThi;
        private MetroFramework.Controls.MetroButton btnThemPhanCongHoiDongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDHoiDongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTHoiDongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanBoHoiDongTHi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChucVuHoiDongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaDiemHoiDongThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaiKhoanHoiDongThi;
    }
}
