namespace EXON.Main.Module.Controls
{
    partial class ucOriginalTest
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXemDe = new System.Windows.Forms.Button();
            this.btnPheDuyet = new System.Windows.Forms.Button();
            this.btnXoaDeThiGoc = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnTaoDeThiGoc = new System.Windows.Forms.Button();
            this.gcOriginalTest = new System.Windows.Forms.DataGridView();
            this.OriginalTestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginalTestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gcShift = new System.Windows.Forms.DataGridView();
            this.ShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScheduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumContestant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gleKiThi = new EXON.Main.Core.Controls.AutoComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pcMain = new EXON.Main.Core.Controls.BufferPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPrintTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOriginalTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcShift)).BeginInit();
            this.pcMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXemDe);
            this.groupBox1.Controls.Add(this.btnPheDuyet);
            this.groupBox1.Controls.Add(this.btnXoaDeThiGoc);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.btnTaoDeThiGoc);
            this.groupBox1.Controls.Add(this.gcOriginalTest);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.gcShift);
            this.groupBox1.Controls.Add(this.gleKiThi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(614, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 532);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // btnXemDe
            // 
            this.btnXemDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXemDe.Location = new System.Drawing.Point(6, 476);
            this.btnXemDe.Name = "btnXemDe";
            this.btnXemDe.Size = new System.Drawing.Size(189, 23);
            this.btnXemDe.TabIndex = 10;
            this.btnXemDe.Text = "Xem Đề Thi";
            this.btnXemDe.UseVisualStyleBackColor = true;
            this.btnXemDe.Click += new System.EventHandler(this.btnXemDeThi);
            // 
            // btnPheDuyet
            // 
            this.btnPheDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPheDuyet.Location = new System.Drawing.Point(202, 504);
            this.btnPheDuyet.Name = "btnPheDuyet";
            this.btnPheDuyet.Size = new System.Drawing.Size(153, 23);
            this.btnPheDuyet.TabIndex = 9;
            this.btnPheDuyet.Text = "Phê Duyệt";
            this.btnPheDuyet.UseVisualStyleBackColor = true;
            this.btnPheDuyet.Click += new System.EventHandler(this.btnPheDuyet_Click);
            // 
            // btnXoaDeThiGoc
            // 
            this.btnXoaDeThiGoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaDeThiGoc.Location = new System.Drawing.Point(7, 503);
            this.btnXoaDeThiGoc.Name = "btnXoaDeThiGoc";
            this.btnXoaDeThiGoc.Size = new System.Drawing.Size(189, 23);
            this.btnXoaDeThiGoc.TabIndex = 8;
            this.btnXoaDeThiGoc.Text = "Xóa Đề Thi";
            this.btnXoaDeThiGoc.UseVisualStyleBackColor = true;
            this.btnXoaDeThiGoc.Click += new System.EventHandler(this.btnXoaDeThiGoc_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown1.Location = new System.Drawing.Point(202, 478);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(153, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnTaoDeThiGoc
            // 
            this.btnTaoDeThiGoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTaoDeThiGoc.Location = new System.Drawing.Point(7, 475);
            this.btnTaoDeThiGoc.Name = "btnTaoDeThiGoc";
            this.btnTaoDeThiGoc.Size = new System.Drawing.Size(189, 23);
            this.btnTaoDeThiGoc.TabIndex = 6;
            this.btnTaoDeThiGoc.Text = "Tạo Đề Thi Gốc Với Số Lượng";
            this.btnTaoDeThiGoc.UseVisualStyleBackColor = true;
            this.btnTaoDeThiGoc.Click += new System.EventHandler(this.btnTaoDeThiGoc_Click);
            // 
            // gcOriginalTest
            // 
            this.gcOriginalTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gcOriginalTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcOriginalTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OriginalTestID,
            this.OriginalTestName,
            this.CreateDate,
            this.Status});
            this.gcOriginalTest.Location = new System.Drawing.Point(7, 311);
            this.gcOriginalTest.Name = "gcOriginalTest";
            this.gcOriginalTest.ReadOnly = true;
            this.gcOriginalTest.Size = new System.Drawing.Size(348, 157);
            this.gcOriginalTest.TabIndex = 5;
            this.gcOriginalTest.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.gcOriginalTest_RowPrePaint);
            this.gcOriginalTest.SelectionChanged += new System.EventHandler(this.gcOriginalTest_SelectionChanged);
            // 
            // OriginalTestID
            // 
            this.OriginalTestID.DataPropertyName = "OriginalTestID";
            this.OriginalTestID.HeaderText = "OriginalTestID";
            this.OriginalTestID.Name = "OriginalTestID";
            this.OriginalTestID.ReadOnly = true;
            this.OriginalTestID.Visible = false;
            // 
            // OriginalTestName
            // 
            this.OriginalTestName.DataPropertyName = "OriginalTestName";
            this.OriginalTestName.HeaderText = "Tên Đề Thi";
            this.OriginalTestName.Name = "OriginalTestName";
            this.OriginalTestName.ReadOnly = true;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Tạo";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Trạng Thái";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Danh Sách Đề Thi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Danh Sách Môn Thi";
            // 
            // gcShift
            // 
            this.gcShift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gcShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcShift.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShiftID,
            this.SubjectID,
            this.SubjectName,
            this.ScheduleID,
            this.SubjectCode,
            this.NumContestant});
            this.gcShift.Location = new System.Drawing.Point(7, 71);
            this.gcShift.Name = "gcShift";
            this.gcShift.ReadOnly = true;
            this.gcShift.Size = new System.Drawing.Size(348, 220);
            this.gcShift.TabIndex = 2;
            this.gcShift.SelectionChanged += new System.EventHandler(this.gcShift_SelectionChanged);
            // 
            // ShiftID
            // 
            this.ShiftID.DataPropertyName = "ShiftID";
            this.ShiftID.HeaderText = "ShiftID";
            this.ShiftID.Name = "ShiftID";
            this.ShiftID.ReadOnly = true;
            this.ShiftID.Visible = false;
            // 
            // SubjectID
            // 
            this.SubjectID.DataPropertyName = "SubjectID";
            this.SubjectID.HeaderText = "SubjectID";
            this.SubjectID.Name = "SubjectID";
            this.SubjectID.ReadOnly = true;
            this.SubjectID.Visible = false;
            // 
            // SubjectName
            // 
            this.SubjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubjectName.DataPropertyName = "SubjectName";
            this.SubjectName.HeaderText = "Môn Thi (Phút)";
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.ReadOnly = true;
            // 
            // ScheduleID
            // 
            this.ScheduleID.DataPropertyName = "ScheduleID";
            this.ScheduleID.HeaderText = "ScheduleID";
            this.ScheduleID.Name = "ScheduleID";
            this.ScheduleID.ReadOnly = true;
            this.ScheduleID.Visible = false;
            // 
            // SubjectCode
            // 
            this.SubjectCode.DataPropertyName = "SubjectCode";
            this.SubjectCode.HeaderText = "Mã Môn";
            this.SubjectCode.Name = "SubjectCode";
            this.SubjectCode.ReadOnly = true;
            // 
            // NumContestant
            // 
            this.NumContestant.DataPropertyName = "NumContestant";
            this.NumContestant.HeaderText = "Số Thí Sinh";
            this.NumContestant.Name = "NumContestant";
            this.NumContestant.ReadOnly = true;
            // 
            // gleKiThi
            // 
            this.gleKiThi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.gleKiThi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gleKiThi.FormattingEnabled = true;
            this.gleKiThi.Location = new System.Drawing.Point(105, 17);
            this.gleKiThi.Name = "gleKiThi";
            this.gleKiThi.Size = new System.Drawing.Size(250, 21);
            this.gleKiThi.TabIndex = 1;
            this.gleKiThi.SelectedValueChanged += new System.EventHandler(this.gleKiThi_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Sách Kì Thi";
            // 
            // pcMain
            // 
            this.pcMain.AutoScroll = true;
            this.pcMain.BackColor = System.Drawing.Color.White;
            this.pcMain.Controls.Add(this.groupBox2);
            this.pcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcMain.Location = new System.Drawing.Point(0, 0);
            this.pcMain.Name = "pcMain";
            this.pcMain.Size = new System.Drawing.Size(614, 532);
            this.pcMain.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPrintTest);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 495);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(614, 37);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnPrintTest
            // 
            this.btnPrintTest.Location = new System.Drawing.Point(3, 9);
            this.btnPrintTest.Name = "btnPrintTest";
            this.btnPrintTest.Size = new System.Drawing.Size(75, 23);
            this.btnPrintTest.TabIndex = 0;
            this.btnPrintTest.Text = "In Đề thi";
            this.btnPrintTest.UseVisualStyleBackColor = true;
            this.btnPrintTest.Click += new System.EventHandler(this.btnPrintTest_Click);
            // 
            // ucOriginalTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcMain);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucOriginalTest";
            this.Size = new System.Drawing.Size(975, 532);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOriginalTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcShift)).EndInit();
            this.pcMain.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPheDuyet;
        private System.Windows.Forms.Button btnXoaDeThiGoc;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnTaoDeThiGoc;
        private System.Windows.Forms.DataGridView gcOriginalTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gcShift;
        private Core.Controls.AutoComboBox gleKiThi;
        private System.Windows.Forms.Label label1;
        private Core.Controls.BufferPanel pcMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalTestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalTestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShiftID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumContestant;
        private System.Windows.Forms.Button btnXemDe;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPrintTest;
    }
}
