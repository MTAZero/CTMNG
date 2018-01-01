namespace EXON.Main.Module.Controls
{
    partial class ucTest
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
            this.gcOriginalTest = new System.Windows.Forms.DataGridView();
            this.btnTaoDeThiGoc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gcShift = new System.Windows.Forms.DataGridView();
            this.ShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShiftName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShiftDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScheduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumContestant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gleKiThi = new EXON.Main.Core.Controls.AutoComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcOriginalTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcShift)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gcOriginalTest);
            this.groupBox1.Controls.Add(this.btnTaoDeThiGoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.gcShift);
            this.groupBox1.Controls.Add(this.gleKiThi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 552);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // gcOriginalTest
            // 
            this.gcOriginalTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcOriginalTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcOriginalTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestID,
            this.TestName,
            this.TestDate});
            this.gcOriginalTest.Location = new System.Drawing.Point(6, 330);
            this.gcOriginalTest.Name = "gcOriginalTest";
            this.gcOriginalTest.ReadOnly = true;
            this.gcOriginalTest.Size = new System.Drawing.Size(772, 187);
            this.gcOriginalTest.TabIndex = 7;
            // 
            // btnTaoDeThiGoc
            // 
            this.btnTaoDeThiGoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoDeThiGoc.Location = new System.Drawing.Point(7, 523);
            this.btnTaoDeThiGoc.Name = "btnTaoDeThiGoc";
            this.btnTaoDeThiGoc.Size = new System.Drawing.Size(771, 23);
            this.btnTaoDeThiGoc.TabIndex = 6;
            this.btnTaoDeThiGoc.Text = "Tạo Đề Thi ";
            this.btnTaoDeThiGoc.UseVisualStyleBackColor = true;
            this.btnTaoDeThiGoc.Click += new System.EventHandler(this.btnTaoDeThiGoc_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 314);
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
            this.gcShift.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcShift.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShiftID,
            this.SubjectID,
            this.SubjectName,
            this.SubjectCode,
            this.ShiftName,
            this.ShiftDate,
            this.ScheduleID,
            this.NumContestant});
            this.gcShift.Location = new System.Drawing.Point(7, 71);
            this.gcShift.Name = "gcShift";
            this.gcShift.ReadOnly = true;
            this.gcShift.Size = new System.Drawing.Size(771, 240);
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
            // SubjectCode
            // 
            this.SubjectCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubjectCode.DataPropertyName = "SubjectCode";
            this.SubjectCode.HeaderText = "Mã Môn";
            this.SubjectCode.Name = "SubjectCode";
            this.SubjectCode.ReadOnly = true;
            // 
            // ShiftName
            // 
            this.ShiftName.DataPropertyName = "ShiftName";
            this.ShiftName.HeaderText = "Ca Thi";
            this.ShiftName.Name = "ShiftName";
            this.ShiftName.ReadOnly = true;
            // 
            // ShiftDate
            // 
            this.ShiftDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ShiftDate.DataPropertyName = "ShiftDate";
            this.ShiftDate.HeaderText = "Ngày Thi";
            this.ShiftDate.Name = "ShiftDate";
            this.ShiftDate.ReadOnly = true;
            // 
            // ScheduleID
            // 
            this.ScheduleID.DataPropertyName = "ScheduleID";
            this.ScheduleID.HeaderText = "ScheduleID";
            this.ScheduleID.Name = "ScheduleID";
            this.ScheduleID.ReadOnly = true;
            this.ScheduleID.Visible = false;
            // 
            // NumContestant
            // 
            this.NumContestant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
            this.gleKiThi.Size = new System.Drawing.Size(366, 21);
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
            // TestID
            // 
            this.TestID.DataPropertyName = "TestID";
            this.TestID.HeaderText = "OriginalTestID";
            this.TestID.Name = "TestID";
            this.TestID.ReadOnly = true;
            this.TestID.Visible = false;
            // 
            // TestName
            // 
            this.TestName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TestName.DataPropertyName = "TestName";
            this.TestName.HeaderText = "Tên Đề Thi";
            this.TestName.Name = "TestName";
            this.TestName.ReadOnly = true;
            // 
            // TestDate
            // 
            this.TestDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TestDate.DataPropertyName = "TestDate";
            this.TestDate.HeaderText = "Ngày Tạo";
            this.TestDate.Name = "TestDate";
            this.TestDate.ReadOnly = true;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Test";
            this.Size = new System.Drawing.Size(784, 552);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcOriginalTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcShift)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTaoDeThiGoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gcShift;
        private Core.Controls.AutoComboBox gleKiThi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShiftID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShiftName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShiftDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumContestant;
        private System.Windows.Forms.DataGridView gcOriginalTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestDate;
    }
}
