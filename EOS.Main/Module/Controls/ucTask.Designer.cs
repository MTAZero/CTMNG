namespace EXON.Main.Module.Controls
{
    partial class ucTask
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbTopic = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.deEndDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.deStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNguoiNhan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gcTopicStaff = new System.Windows.Forms.DataGridView();
            this.TopicStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedStaffID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedStaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopicID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopicName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTopicStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.cbTopic);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbSubject);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.deEndDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.deStartDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMoTa);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbNguoiNhan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(505, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 526);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nội Dung Công Việc";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(153, 471);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(153, 23);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Cập Nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(3, 471);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(144, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRefresh.Location = new System.Drawing.Point(3, 500);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(303, 23);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbTopic
            // 
            this.cbTopic.FormattingEnabled = true;
            this.cbTopic.Location = new System.Drawing.Point(78, 74);
            this.cbTopic.Name = "cbTopic";
            this.cbTopic.Size = new System.Drawing.Size(225, 21);
            this.cbTopic.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Chủ Đề";
            // 
            // cbSubject
            // 
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(78, 47);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(225, 21);
            this.cbSubject.TabIndex = 9;
            this.cbSubject.SelectedValueChanged += new System.EventHandler(this.cbSubject_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Môn Học";
            // 
            // deEndDate
            // 
            this.deEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.deEndDate.Location = new System.Drawing.Point(87, 447);
            this.deEndDate.Name = "deEndDate";
            this.deEndDate.Size = new System.Drawing.Size(215, 20);
            this.deEndDate.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 453);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày Kết Thúc";
            // 
            // deStartDate
            // 
            this.deStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.deStartDate.Location = new System.Drawing.Point(87, 421);
            this.deStartDate.Name = "deStartDate";
            this.deStartDate.Size = new System.Drawing.Size(215, 20);
            this.deStartDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày Bắt Đầu";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(6, 128);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(296, 286);
            this.txtMoTa.TabIndex = 3;
            this.txtMoTa.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mô Tả Chi Tiết";
            // 
            // cbNguoiNhan
            // 
            this.cbNguoiNhan.FormattingEnabled = true;
            this.cbNguoiNhan.Location = new System.Drawing.Point(78, 20);
            this.cbNguoiNhan.Name = "cbNguoiNhan";
            this.cbNguoiNhan.Size = new System.Drawing.Size(225, 21);
            this.cbNguoiNhan.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Người Nhận";
            // 
            // gcTopicStaff
            // 
            this.gcTopicStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcTopicStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TopicStaffID,
            this.Description,
            this.AssignedStaffID,
            this.AssignedStaffName,
            this.BeginDate,
            this.EndDate,
            this.TopicID,
            this.TopicName,
            this.Status});
            this.gcTopicStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTopicStaff.Location = new System.Drawing.Point(0, 0);
            this.gcTopicStaff.Name = "gcTopicStaff";
            this.gcTopicStaff.Size = new System.Drawing.Size(505, 526);
            this.gcTopicStaff.TabIndex = 1;
            this.gcTopicStaff.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.gcTopicStaff_RowPrePaint);
            this.gcTopicStaff.SelectionChanged += new System.EventHandler(this.gcTopicStaff_SelectionChanged);
            // 
            // TopicStaffID
            // 
            this.TopicStaffID.DataPropertyName = "TopicStaffID";
            this.TopicStaffID.HeaderText = "Id";
            this.TopicStaffID.Name = "TopicStaffID";
            this.TopicStaffID.Visible = false;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Mô Tả";
            this.Description.Name = "Description";
            // 
            // AssignedStaffID
            // 
            this.AssignedStaffID.DataPropertyName = "AssignedStaffID";
            this.AssignedStaffID.HeaderText = "AssignedStaffID";
            this.AssignedStaffID.Name = "AssignedStaffID";
            this.AssignedStaffID.Visible = false;
            // 
            // AssignedStaffName
            // 
            this.AssignedStaffName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AssignedStaffName.DataPropertyName = "AssignedStaffName";
            this.AssignedStaffName.HeaderText = "Người Nhận";
            this.AssignedStaffName.Name = "AssignedStaffName";
            // 
            // BeginDate
            // 
            this.BeginDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BeginDate.DataPropertyName = "BeginDate";
            this.BeginDate.HeaderText = "Ngày Bắt Đầu";
            this.BeginDate.Name = "BeginDate";
            // 
            // EndDate
            // 
            this.EndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EndDate.DataPropertyName = "EndDate";
            this.EndDate.HeaderText = "Ngày Kết Thúc";
            this.EndDate.Name = "EndDate";
            // 
            // TopicID
            // 
            this.TopicID.DataPropertyName = "TopicID";
            this.TopicID.HeaderText = "TopicID";
            this.TopicID.Name = "TopicID";
            this.TopicID.Visible = false;
            // 
            // TopicName
            // 
            this.TopicName.DataPropertyName = "TopicName";
            this.TopicName.HeaderText = "Chủ Đề";
            this.TopicName.Name = "TopicName";
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Trạng Thái";
            this.Status.Name = "Status";
            // 
            // Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcTopicStaff);
            this.Controls.Add(this.groupBox1);
            this.Name = "Task";
            this.Size = new System.Drawing.Size(814, 526);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTopicStaff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbTopic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker deEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker deStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtMoTa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbNguoiNhan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gcTopicStaff;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopicStaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignedStaffID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignedStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopicID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopicName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}
