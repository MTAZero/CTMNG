namespace ContestManagementVer2.Main
{
    partial class ucDanhSachDangKy
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInDanhSach = new MetroFramework.Controls.MetroButton();
            this.cbxMonThi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvThiSinh = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThiSinh)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnInDanhSach);
            this.panel1.Controls.Add(this.cbxMonThi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1056, 73);
            this.panel1.TabIndex = 0;
            // 
            // btnInDanhSach
            // 
            this.btnInDanhSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInDanhSach.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnInDanhSach.ForeColor = System.Drawing.Color.Black;
            this.btnInDanhSach.Location = new System.Drawing.Point(443, 18);
            this.btnInDanhSach.Name = "btnInDanhSach";
            this.btnInDanhSach.Size = new System.Drawing.Size(179, 34);
            this.btnInDanhSach.TabIndex = 15;
            this.btnInDanhSach.Text = "In danh sách";
            this.btnInDanhSach.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnInDanhSach.UseCustomBackColor = true;
            this.btnInDanhSach.UseCustomForeColor = true;
            this.btnInDanhSach.UseSelectable = true;
            this.btnInDanhSach.Click += new System.EventHandler(this.btnInDanhSach_Click);
            // 
            // cbxMonThi
            // 
            this.cbxMonThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMonThi.FormattingEnabled = true;
            this.cbxMonThi.Location = new System.Drawing.Point(125, 24);
            this.cbxMonThi.Name = "cbxMonThi";
            this.cbxMonThi.Size = new System.Drawing.Size(297, 25);
            this.cbxMonThi.TabIndex = 1;
            this.cbxMonThi.SelectedIndexChanged += new System.EventHandler(this.cbxMonThi_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Môn thi : ";
            // 
            // groupDanhSach
            // 
            this.groupDanhSach.BackColor = System.Drawing.Color.White;
            this.groupDanhSach.Controls.Add(this.dgvThiSinh);
            this.groupDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDanhSach.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDanhSach.Location = new System.Drawing.Point(0, 73);
            this.groupDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.groupDanhSach.Name = "groupDanhSach";
            this.groupDanhSach.Padding = new System.Windows.Forms.Padding(4);
            this.groupDanhSach.Size = new System.Drawing.Size(1056, 540);
            this.groupDanhSach.TabIndex = 1;
            this.groupDanhSach.TabStop = false;
            this.groupDanhSach.Text = "Danh sách thí sinh";
            // 
            // dgvThiSinh
            // 
            this.dgvThiSinh.AllowUserToResizeColumns = false;
            this.dgvThiSinh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThiSinh.BackgroundColor = System.Drawing.Color.White;
            this.dgvThiSinh.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvThiSinh.ColumnHeadersHeight = 30;
            this.dgvThiSinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.STT,
            this.SBD,
            this.HoTen,
            this.CMND,
            this.NgaySinh,
            this.GioiTinh});
            this.dgvThiSinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThiSinh.EnableHeadersVisualStyles = false;
            this.dgvThiSinh.GridColor = System.Drawing.Color.Black;
            this.dgvThiSinh.Location = new System.Drawing.Point(4, 20);
            this.dgvThiSinh.Margin = new System.Windows.Forms.Padding(4);
            this.dgvThiSinh.MultiSelect = false;
            this.dgvThiSinh.Name = "dgvThiSinh";
            this.dgvThiSinh.ReadOnly = true;
            this.dgvThiSinh.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvThiSinh.RowHeadersWidth = 25;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvThiSinh.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThiSinh.RowTemplate.Height = 30;
            this.dgvThiSinh.RowTemplate.ReadOnly = true;
            this.dgvThiSinh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThiSinh.Size = new System.Drawing.Size(1048, 516);
            this.dgvThiSinh.TabIndex = 3;
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
            this.STT.FillWeight = 7F;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // SBD
            // 
            this.SBD.DataPropertyName = "SBD";
            this.SBD.FillWeight = 15F;
            this.SBD.HeaderText = "SBD";
            this.SBD.Name = "SBD";
            this.SBD.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.FillWeight = 20F;
            this.HoTen.HeaderText = "Họ và tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            // 
            // CMND
            // 
            this.CMND.DataPropertyName = "CMND";
            this.CMND.FillWeight = 15F;
            this.CMND.HeaderText = "CMND";
            this.CMND.Name = "CMND";
            this.CMND.ReadOnly = true;
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.FillWeight = 15F;
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.ReadOnly = true;
            // 
            // GioiTinh
            // 
            this.GioiTinh.DataPropertyName = "GioiTinh";
            this.GioiTinh.FillWeight = 15F;
            this.GioiTinh.HeaderText = "Giới tính";
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.ReadOnly = true;
            // 
            // ucDanhSachDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupDanhSach);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucDanhSachDangKy";
            this.Size = new System.Drawing.Size(1056, 613);
            this.Load += new System.EventHandler(this.ucDanhSachDangKy_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThiSinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupDanhSach;
        private System.Windows.Forms.DataGridView dgvThiSinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxMonThi;
        private MetroFramework.Controls.MetroButton btnInDanhSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMND;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
    }
}
