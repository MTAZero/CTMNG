namespace EXON_ExamManagement.UC.LapKeHoachKiThi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMonThi = new System.Windows.Forms.DataGridView();
            this.IDMonThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STTMonThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMonThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HinhThucThiMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeOfTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeToSubmit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LePhiMonThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnThemMonThi = new System.Windows.Forms.Button();
            this.btnXoaMonThi = new System.Windows.Forms.Button();
            this.groupThongTinMonThi = new System.Windows.Forms.GroupBox();
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
            this.panelTrangThai = new System.Windows.Forms.Panel();
            this.panelStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonThi)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupThongTinMonThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeToSubmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeOfTest)).BeginInit();
            this.panelTrangThai.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panelTrangThai);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1308, 608);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1308, 492);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.dgvMonThi);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(931, 490);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách ca thi";
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
            this.STTMonThi,
            this.TenMonThi,
            this.HinhThucThiMT,
            this.TimeOfTest,
            this.TimeToSubmit,
            this.LePhiMonThi});
            this.dgvMonThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonThi.EnableHeadersVisualStyles = false;
            this.dgvMonThi.GridColor = System.Drawing.Color.Black;
            this.dgvMonThi.Location = new System.Drawing.Point(3, 19);
            this.dgvMonThi.MultiSelect = false;
            this.dgvMonThi.Name = "dgvMonThi";
            this.dgvMonThi.ReadOnly = true;
            this.dgvMonThi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMonThi.RowHeadersWidth = 25;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMonThi.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMonThi.RowTemplate.Height = 30;
            this.dgvMonThi.RowTemplate.ReadOnly = true;
            this.dgvMonThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonThi.Size = new System.Drawing.Size(925, 468);
            this.dgvMonThi.TabIndex = 1;
            // 
            // IDMonThi
            // 
            this.IDMonThi.DataPropertyName = "ID";
            this.IDMonThi.HeaderText = "ID";
            this.IDMonThi.Name = "IDMonThi";
            this.IDMonThi.ReadOnly = true;
            this.IDMonThi.Visible = false;
            // 
            // STTMonThi
            // 
            this.STTMonThi.DataPropertyName = "STT";
            this.STTMonThi.FillWeight = 10F;
            this.STTMonThi.HeaderText = "STT";
            this.STTMonThi.Name = "STTMonThi";
            this.STTMonThi.ReadOnly = true;
            // 
            // TenMonThi
            // 
            this.TenMonThi.DataPropertyName = "MonThi";
            this.TenMonThi.FillWeight = 25F;
            this.TenMonThi.HeaderText = "Môn thi";
            this.TenMonThi.Name = "TenMonThi";
            this.TenMonThi.ReadOnly = true;
            // 
            // HinhThucThiMT
            // 
            this.HinhThucThiMT.DataPropertyName = "HinhThucThi";
            this.HinhThucThiMT.FillWeight = 15F;
            this.HinhThucThiMT.HeaderText = "Hình thức thi";
            this.HinhThucThiMT.Name = "HinhThucThiMT";
            this.HinhThucThiMT.ReadOnly = true;
            // 
            // TimeOfTest
            // 
            this.TimeOfTest.DataPropertyName = "ThoiGianThi";
            this.TimeOfTest.FillWeight = 20F;
            this.TimeOfTest.HeaderText = "Thời gian thi";
            this.TimeOfTest.Name = "TimeOfTest";
            this.TimeOfTest.ReadOnly = true;
            // 
            // TimeToSubmit
            // 
            this.TimeToSubmit.DataPropertyName = "ThoiGianNopBai";
            this.TimeToSubmit.FillWeight = 20F;
            this.TimeToSubmit.HeaderText = "Thời gian nộp bài";
            this.TimeToSubmit.Name = "TimeToSubmit";
            this.TimeToSubmit.ReadOnly = true;
            // 
            // LePhiMonThi
            // 
            this.LePhiMonThi.DataPropertyName = "LePhiThi";
            this.LePhiMonThi.FillWeight = 20F;
            this.LePhiMonThi.HeaderText = "Lệ phí thi";
            this.LePhiMonThi.Name = "LePhiMonThi";
            this.LePhiMonThi.ReadOnly = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.groupThongTinMonThi);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(931, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(375, 490);
            this.panel6.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnThemMonThi);
            this.panel3.Controls.Add(this.btnXoaMonThi);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 258);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(375, 93);
            this.panel3.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(188, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "Thêm môn thi";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnThemMonThi
            // 
            this.btnThemMonThi.BackColor = System.Drawing.Color.Teal;
            this.btnThemMonThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMonThi.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMonThi.ForeColor = System.Drawing.Color.White;
            this.btnThemMonThi.Location = new System.Drawing.Point(3, 3);
            this.btnThemMonThi.Name = "btnThemMonThi";
            this.btnThemMonThi.Size = new System.Drawing.Size(182, 39);
            this.btnThemMonThi.TabIndex = 2;
            this.btnThemMonThi.Text = "Thêm môn thi";
            this.btnThemMonThi.UseVisualStyleBackColor = false;
            // 
            // btnXoaMonThi
            // 
            this.btnXoaMonThi.BackColor = System.Drawing.Color.Teal;
            this.btnXoaMonThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaMonThi.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaMonThi.ForeColor = System.Drawing.Color.White;
            this.btnXoaMonThi.Location = new System.Drawing.Point(3, 48);
            this.btnXoaMonThi.Name = "btnXoaMonThi";
            this.btnXoaMonThi.Size = new System.Drawing.Size(367, 39);
            this.btnXoaMonThi.TabIndex = 3;
            this.btnXoaMonThi.Text = "Xóa môn thi";
            this.btnXoaMonThi.UseVisualStyleBackColor = false;
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
            this.groupThongTinMonThi.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupThongTinMonThi.Location = new System.Drawing.Point(0, 0);
            this.groupThongTinMonThi.Name = "groupThongTinMonThi";
            this.groupThongTinMonThi.Size = new System.Drawing.Size(375, 258);
            this.groupThongTinMonThi.TabIndex = 0;
            this.groupThongTinMonThi.TabStop = false;
            this.groupThongTinMonThi.Text = "Chi tiết môn học";
            // 
            // txtLePhiThi
            // 
            this.txtLePhiThi.Location = new System.Drawing.Point(131, 217);
            this.txtLePhiThi.Name = "txtLePhiThi";
            this.txtLePhiThi.Size = new System.Drawing.Size(215, 23);
            this.txtLePhiThi.TabIndex = 6;
            // 
            // txtLePhiThiLabel
            // 
            this.txtLePhiThiLabel.AutoSize = true;
            this.txtLePhiThiLabel.Location = new System.Drawing.Point(31, 220);
            this.txtLePhiThiLabel.Name = "txtLePhiThiLabel";
            this.txtLePhiThiLabel.Size = new System.Drawing.Size(69, 16);
            this.txtLePhiThiLabel.TabIndex = 5;
            this.txtLePhiThiLabel.Text = "Lệ phí thi :";
            // 
            // cbxHinhThucThi
            // 
            this.cbxHinhThucThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHinhThucThi.FormattingEnabled = true;
            this.cbxHinhThucThi.Location = new System.Drawing.Point(131, 170);
            this.cbxHinhThucThi.Name = "cbxHinhThucThi";
            this.cbxHinhThucThi.Size = new System.Drawing.Size(215, 23);
            this.cbxHinhThucThi.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hình thức thi : ";
            // 
            // txtTimeToSubmit
            // 
            this.txtTimeToSubmit.Location = new System.Drawing.Point(194, 122);
            this.txtTimeToSubmit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtTimeToSubmit.Name = "txtTimeToSubmit";
            this.txtTimeToSubmit.Size = new System.Drawing.Size(54, 23);
            this.txtTimeToSubmit.TabIndex = 2;
            this.txtTimeToSubmit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtTimeOfTest
            // 
            this.txtTimeOfTest.Location = new System.Drawing.Point(131, 77);
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
            this.cbxMonThi.Location = new System.Drawing.Point(131, 29);
            this.cbxMonThi.Name = "cbxMonThi";
            this.cbxMonThi.Size = new System.Drawing.Size(215, 23);
            this.cbxMonThi.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "phút";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Thời gian có thể nộp bài : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "phút";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thời gian : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Môn thi : ";
            // 
            // panelTrangThai
            // 
            this.panelTrangThai.BackColor = System.Drawing.Color.White;
            this.panelTrangThai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTrangThai.Controls.Add(this.panelStatus);
            this.panelTrangThai.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTrangThai.Location = new System.Drawing.Point(0, 0);
            this.panelTrangThai.Name = "panelTrangThai";
            this.panelTrangThai.Size = new System.Drawing.Size(1308, 116);
            this.panelTrangThai.TabIndex = 0;
            // 
            // panelStatus
            // 
            this.panelStatus.AutoSize = true;
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStatus.Location = new System.Drawing.Point(0, 0);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(1306, 114);
            this.panelStatus.TabIndex = 0;
            // 
            // ucThemCaThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ucThemCaThi";
            this.Size = new System.Drawing.Size(1308, 608);
            this.Load += new System.EventHandler(this.ucThemCaThi_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonThi)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupThongTinMonThi.ResumeLayout(false);
            this.groupThongTinMonThi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeToSubmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeOfTest)).EndInit();
            this.panelTrangThai.ResumeLayout(false);
            this.panelTrangThai.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvMonThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMonThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTMonThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMonThi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HinhThucThiMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeOfTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeToSubmit;
        private System.Windows.Forms.DataGridViewTextBoxColumn LePhiMonThi;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnThemMonThi;
        private System.Windows.Forms.Button btnXoaMonThi;
        private System.Windows.Forms.GroupBox groupThongTinMonThi;
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
        private System.Windows.Forms.Panel panelTrangThai;
        private System.Windows.Forms.FlowLayoutPanel panelStatus;
    }
}
