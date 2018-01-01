namespace EXON.Main.Module.Controls
{
    partial class ucAcceptQuestion
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ceFullQuestion = new System.Windows.Forms.CheckBox();
            this.btnPheDuyetNV = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.gcTask = new System.Windows.Forms.DataGridView();
            this.AssignedStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopicStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbTopic = new System.Windows.Forms.ComboBox();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbThongTin = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPheDuyet = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pcMain = new EXON.Main.Core.Controls.BufferPanel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTask)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ceFullQuestion);
            this.groupBox2.Controls.Add(this.btnPheDuyetNV);
            this.groupBox2.Controls.Add(this.btnGetData);
            this.groupBox2.Controls.Add(this.gcTask);
            this.groupBox2.Controls.Add(this.cbTopic);
            this.groupBox2.Controls.Add(this.cbSubject);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 535);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin";
            // 
            // ceFullQuestion
            // 
            this.ceFullQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ceFullQuestion.AutoSize = true;
            this.ceFullQuestion.Location = new System.Drawing.Point(314, 512);
            this.ceFullQuestion.Name = "ceFullQuestion";
            this.ceFullQuestion.Size = new System.Drawing.Size(248, 17);
            this.ceFullQuestion.TabIndex = 11;
            this.ceFullQuestion.Text = "Bao Gồm Cả Câu Hỏi Thêm Ngoài NV Đã Giao";
            this.ceFullQuestion.UseVisualStyleBackColor = true;
            this.ceFullQuestion.CheckedChanged += new System.EventHandler(this.ceFullQuestion_CheckedChanged);
            // 
            // btnPheDuyetNV
            // 
            this.btnPheDuyetNV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPheDuyetNV.Location = new System.Drawing.Point(4, 479);
            this.btnPheDuyetNV.Name = "btnPheDuyetNV";
            this.btnPheDuyetNV.Size = new System.Drawing.Size(558, 23);
            this.btnPheDuyetNV.TabIndex = 10;
            this.btnPheDuyetNV.Text = "Phê Duyệt Nhiệm Vụ";
            this.btnPheDuyetNV.UseVisualStyleBackColor = true;
            this.btnPheDuyetNV.Click += new System.EventHandler(this.btnPheDuyetNV_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGetData.Location = new System.Drawing.Point(4, 508);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(304, 23);
            this.btnGetData.TabIndex = 9;
            this.btnGetData.Text = "Lấy Câu Hỏi Mới";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // gcTask
            // 
            this.gcTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gcTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AssignedStaffID,
            this.Description,
            this.StaffName,
            this.BeginDate,
            this.EndDate,
            this.Status,
            this.TopicStaffID});
            this.gcTask.Location = new System.Drawing.Point(4, 87);
            this.gcTask.Name = "gcTask";
            this.gcTask.ReadOnly = true;
            this.gcTask.Size = new System.Drawing.Size(558, 385);
            this.gcTask.TabIndex = 8;
            this.gcTask.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.gcTask_RowPrePaint);
            // 
            // AssignedStaffID
            // 
            this.AssignedStaffID.DataPropertyName = "AssignedStaffID";
            this.AssignedStaffID.HeaderText = "AssignedStaffID";
            this.AssignedStaffID.Name = "AssignedStaffID";
            this.AssignedStaffID.ReadOnly = true;
            this.AssignedStaffID.Visible = false;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Mô Tả";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // StaffName
            // 
            this.StaffName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StaffName.DataPropertyName = "StaffName";
            this.StaffName.HeaderText = "Nhân Viên";
            this.StaffName.Name = "StaffName";
            this.StaffName.ReadOnly = true;
            // 
            // BeginDate
            // 
            this.BeginDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BeginDate.DataPropertyName = "BeginDate";
            this.BeginDate.HeaderText = "Ngày Bắt Đầu";
            this.BeginDate.Name = "BeginDate";
            this.BeginDate.ReadOnly = true;
            // 
            // EndDate
            // 
            this.EndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EndDate.DataPropertyName = "EndDate";
            this.EndDate.HeaderText = "Ngày Kết Thúc";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Trạng Thái";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // TopicStaffID
            // 
            this.TopicStaffID.DataPropertyName = "TopicStaffID";
            this.TopicStaffID.HeaderText = "TopicStaffID";
            this.TopicStaffID.Name = "TopicStaffID";
            this.TopicStaffID.ReadOnly = true;
            this.TopicStaffID.Visible = false;
            // 
            // cbTopic
            // 
            this.cbTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTopic.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbTopic.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTopic.FormattingEnabled = true;
            this.cbTopic.Location = new System.Drawing.Point(79, 47);
            this.cbTopic.Name = "cbTopic";
            this.cbTopic.Size = new System.Drawing.Size(483, 21);
            this.cbTopic.TabIndex = 7;
            this.cbTopic.SelectedValueChanged += new System.EventHandler(this.cbTopic_SelectedValueChanged);
            // 
            // cbSubject
            // 
            this.cbSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSubject.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbSubject.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(79, 19);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(483, 21);
            this.cbSubject.TabIndex = 6;
            this.cbSubject.SelectedValueChanged += new System.EventHandler(this.cbSubject_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chủ Đề";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Môn Học";
            // 
            // lbThongTin
            // 
            this.lbThongTin.AutoSize = true;
            this.lbThongTin.Location = new System.Drawing.Point(6, 16);
            this.lbThongTin.Name = "lbThongTin";
            this.lbThongTin.Size = new System.Drawing.Size(161, 13);
            this.lbThongTin.TabIndex = 1;
            this.lbThongTin.Text = "Thông Tin Ngân Hàng Câu Hỏi: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPheDuyet);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.lbThongTin);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(568, 500);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 35);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = ".";
            // 
            // btnPheDuyet
            // 
            this.btnPheDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPheDuyet.Location = new System.Drawing.Point(104, 9);
            this.btnPheDuyet.Name = "btnPheDuyet";
            this.btnPheDuyet.Size = new System.Drawing.Size(96, 23);
            this.btnPheDuyet.TabIndex = 2;
            this.btnPheDuyet.Text = "Phê Duyệt";
            this.btnPheDuyet.UseVisualStyleBackColor = true;
            this.btnPheDuyet.Click += new System.EventHandler(this.btnPheDuyet_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(215, 9);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(35, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "<<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(256, 9);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pcMain
            // 
            this.pcMain.AutoScroll = true;
            this.pcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcMain.Location = new System.Drawing.Point(568, 0);
            this.pcMain.Name = "pcMain";
            this.pcMain.Size = new System.Drawing.Size(299, 500);
            this.pcMain.TabIndex = 6;
            // 
            // AcceptQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcMain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "AcceptQuestion";
            this.Size = new System.Drawing.Size(867, 535);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTask)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbThongTin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPheDuyet;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private Core.Controls.BufferPanel pcMain;
        private System.Windows.Forms.ComboBox cbTopic;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.DataGridView gcTask;
        private System.Windows.Forms.Button btnPheDuyetNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignedStaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopicStaffID;
        private System.Windows.Forms.CheckBox ceFullQuestion;
    }
}
