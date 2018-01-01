namespace ExamManagement.GUI
{
    partial class FrmChucVuCanBo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChucVuCanBo));
            this.label1 = new System.Windows.Forms.Label();
            this.cbxStaff = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvChucVuCanBo = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.groupThongTin = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxPosition = new System.Windows.Forms.ComboBox();
            this.txtStaffName = new System.Windows.Forms.Label();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffPositionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxDepartment = new System.Windows.Forms.ComboBox();
            this.DepartmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChucVuCanBo)).BeginInit();
            this.groupThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cán bộ";
            // 
            // cbxStaff
            // 
            this.cbxStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStaff.FormattingEnabled = true;
            this.cbxStaff.Location = new System.Drawing.Point(138, 20);
            this.cbxStaff.Name = "cbxStaff";
            this.cbxStaff.Size = new System.Drawing.Size(320, 21);
            this.cbxStaff.TabIndex = 1;
            this.cbxStaff.SelectedIndexChanged += new System.EventHandler(this.cbxStaff_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbxDepartment);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbxStaff);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(709, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 104);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Danh sách các chức vụ của cán bộ : ";
            // 
            // dgvChucVuCanBo
            // 
            this.dgvChucVuCanBo.AllowDrop = true;
            this.dgvChucVuCanBo.AllowUserToAddRows = false;
            this.dgvChucVuCanBo.AllowUserToResizeColumns = false;
            this.dgvChucVuCanBo.AllowUserToResizeRows = false;
            this.dgvChucVuCanBo.BackgroundColor = System.Drawing.Color.White;
            this.dgvChucVuCanBo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvChucVuCanBo.ColumnHeadersHeight = 30;
            this.dgvChucVuCanBo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvChucVuCanBo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.StaffPositionID,
            this.StaffID,
            this.PositionID,
            this.FullName,
            this.PositionName,
            this.DepartmentID});
            this.dgvChucVuCanBo.EnableHeadersVisualStyles = false;
            this.dgvChucVuCanBo.GridColor = System.Drawing.Color.Black;
            this.dgvChucVuCanBo.Location = new System.Drawing.Point(29, 25);
            this.dgvChucVuCanBo.MultiSelect = false;
            this.dgvChucVuCanBo.Name = "dgvChucVuCanBo";
            this.dgvChucVuCanBo.ReadOnly = true;
            this.dgvChucVuCanBo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChucVuCanBo.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChucVuCanBo.RowHeadersWidth = 20;
            this.dgvChucVuCanBo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvChucVuCanBo.RowTemplate.Height = 40;
            this.dgvChucVuCanBo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChucVuCanBo.Size = new System.Drawing.Size(655, 527);
            this.dgvChucVuCanBo.TabIndex = 4;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(709, 439);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(270, 54);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.White;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(709, 499);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(534, 54);
            this.btnDong.TabIndex = 11;
            this.btnDong.Text = "Đóng chức năng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(987, 439);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(256, 54);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // groupThongTin
            // 
            this.groupThongTin.Controls.Add(this.cbxPosition);
            this.groupThongTin.Controls.Add(this.label12);
            this.groupThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupThongTin.Location = new System.Drawing.Point(709, 192);
            this.groupThongTin.Name = "groupThongTin";
            this.groupThongTin.Size = new System.Drawing.Size(534, 69);
            this.groupThongTin.TabIndex = 7;
            this.groupThongTin.TabStop = false;
            this.groupThongTin.Text = "Thông tin chức vụ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(60, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Chức vụ";
            // 
            // cbxPosition
            // 
            this.cbxPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPosition.FormattingEnabled = true;
            this.cbxPosition.Location = new System.Drawing.Point(139, 25);
            this.cbxPosition.Name = "cbxPosition";
            this.cbxPosition.Size = new System.Drawing.Size(320, 21);
            this.cbxPosition.TabIndex = 2;
            // 
            // txtStaffName
            // 
            this.txtStaffName.AutoSize = true;
            this.txtStaffName.Location = new System.Drawing.Point(220, 9);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(91, 13);
            this.txtStaffName.TabIndex = 12;
            this.txtStaffName.Text = "Phan Nguyên Hải";
            // 
            // Index
            // 
            this.Index.DataPropertyName = "Index";
            this.Index.HeaderText = "STT";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.Width = 70;
            // 
            // StaffPositionID
            // 
            this.StaffPositionID.DataPropertyName = "StaffPositionID";
            this.StaffPositionID.HeaderText = "StaffPositionID ";
            this.StaffPositionID.Name = "StaffPositionID";
            this.StaffPositionID.ReadOnly = true;
            this.StaffPositionID.Visible = false;
            // 
            // StaffID
            // 
            this.StaffID.DataPropertyName = "StaffID";
            this.StaffID.HeaderText = "StaffID";
            this.StaffID.Name = "StaffID";
            this.StaffID.ReadOnly = true;
            this.StaffID.Visible = false;
            // 
            // PositionID
            // 
            this.PositionID.DataPropertyName = "PositionID";
            this.PositionID.HeaderText = "PositionID";
            this.PositionID.Name = "PositionID";
            this.PositionID.ReadOnly = true;
            this.PositionID.Visible = false;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Họ và tên";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 300;
            // 
            // PositionName
            // 
            this.PositionName.DataPropertyName = "PositionName";
            this.PositionName.HeaderText = "Chức vụ";
            this.PositionName.Name = "PositionName";
            this.PositionName.ReadOnly = true;
            this.PositionName.Width = 263;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đơn vị";
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDepartment.Enabled = false;
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.Location = new System.Drawing.Point(138, 59);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(320, 21);
            this.cbxDepartment.TabIndex = 3;
            // 
            // DepartmentID
            // 
            this.DepartmentID.HeaderText = "Đơn vị";
            this.DepartmentID.Name = "DepartmentID";
            this.DepartmentID.ReadOnly = true;
            this.DepartmentID.Visible = false;
            // 
            // FrmChucVuCanBo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1327, 576);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.groupThongTin);
            this.Controls.Add(this.dgvChucVuCanBo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmChucVuCanBo";
            this.Text = "FrmChucVuCanBo";
            this.Load += new System.EventHandler(this.FrmChucVuCanBo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChucVuCanBo)).EndInit();
            this.groupThongTin.ResumeLayout(false);
            this.groupThongTin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxStaff;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvChucVuCanBo;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.GroupBox groupThongTin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbxPosition;
        private System.Windows.Forms.Label txtStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffPositionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentID;
    }
}