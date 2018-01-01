namespace CreateDB
{
    partial class MFrmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbContestName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRoomTest = new System.Windows.Forms.DataGridView();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRoomTestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMaxSitMount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbtnConfig = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDivisionShift = new System.Windows.Forms.DataGridView();
            this.cDivisionShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cShiftName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRoomtest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbtnEncrypt = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomTest)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDivisionShift)).BeginInit();
            this.SuspendLayout();
            // 
            // lbContestName
            // 
            this.lbContestName.AutoSize = true;
            this.lbContestName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContestName.Location = new System.Drawing.Point(22, 6);
            this.lbContestName.Name = "lbContestName";
            this.lbContestName.Size = new System.Drawing.Size(79, 22);
            this.lbContestName.TabIndex = 0;
            this.lbContestName.Text = "Kỳ thi:   ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Địa điểm";
            // 
            // cboLocation
            // 
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(135, 38);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(361, 21);
            this.cboLocation.TabIndex = 2;
            this.cboLocation.SelectedIndexChanged += new System.EventHandler(this.cboLocation_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(585, 32);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 30);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Bắt đầu chuyển";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboLocation);
            this.panel1.Controls.Add(this.lbContestName);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 100);
            this.panel1.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(20, 160);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(994, 294);
            this.splitContainer1.SplitterDistance = 408;
            this.splitContainer1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvRoomTest);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 294);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phòng thi";
            // 
            // dgvRoomTest
            // 
            this.dgvRoomTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoomTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cID,
            this.cRoomTestName,
            this.cMaxSitMount,
            this.cbtnConfig});
            this.dgvRoomTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoomTest.Location = new System.Drawing.Point(3, 16);
            this.dgvRoomTest.Name = "dgvRoomTest";
            this.dgvRoomTest.Size = new System.Drawing.Size(402, 275);
            this.dgvRoomTest.TabIndex = 0;
            this.dgvRoomTest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoomTest_CellClick);
            this.dgvRoomTest.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoomTest_CellContentClick);
            this.dgvRoomTest.SelectionChanged += new System.EventHandler(this.dgvRoomTest_SelectionChanged);
            // 
            // cID
            // 
            this.cID.DataPropertyName = "RoomtestID";
            this.cID.HeaderText = "ID";
            this.cID.Name = "cID";
            this.cID.Visible = false;
            // 
            // cRoomTestName
            // 
            this.cRoomTestName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cRoomTestName.DataPropertyName = "RoomtestName";
            this.cRoomTestName.HeaderText = "Tên Phòng";
            this.cRoomTestName.Name = "cRoomTestName";
            // 
            // cMaxSitMount
            // 
            this.cMaxSitMount.DataPropertyName = "MaxsitMount";
            this.cMaxSitMount.HeaderText = "Số lượng chỗ";
            this.cMaxSitMount.Name = "cMaxSitMount";
            // 
            // cbtnConfig
            // 
            this.cbtnConfig.DataPropertyName = "btnconfig";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cbtnConfig.DefaultCellStyle = dataGridViewCellStyle2;
            this.cbtnConfig.HeaderText = "Cấu hình máy";
            this.cbtnConfig.Name = "cbtnConfig";
            this.cbtnConfig.Text = "Cấu hình máy";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDivisionShift);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 294);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ca thi";
            // 
            // dgvDivisionShift
            // 
            this.dgvDivisionShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDivisionShift.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDivisionShiftID,
            this.cShiftName,
            this.cDate,
            this.cStartTime,
            this.cRoomtest,
            this.cbtnEncrypt});
            this.dgvDivisionShift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDivisionShift.Location = new System.Drawing.Point(3, 16);
            this.dgvDivisionShift.Name = "dgvDivisionShift";
            this.dgvDivisionShift.Size = new System.Drawing.Size(576, 275);
            this.dgvDivisionShift.TabIndex = 0;
            this.dgvDivisionShift.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDivisionShift_CellContentClick);
            // 
            // cDivisionShiftID
            // 
            this.cDivisionShiftID.DataPropertyName = "DivisionShiftID";
            this.cDivisionShiftID.HeaderText = "ID";
            this.cDivisionShiftID.Name = "cDivisionShiftID";
            this.cDivisionShiftID.Visible = false;
            // 
            // cShiftName
            // 
            this.cShiftName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cShiftName.DataPropertyName = "ShiftName";
            this.cShiftName.HeaderText = "Ca thi";
            this.cShiftName.Name = "cShiftName";
            // 
            // cDate
            // 
            this.cDate.DataPropertyName = "Date";
            this.cDate.HeaderText = "Ngày";
            this.cDate.Name = "cDate";
            // 
            // cStartTime
            // 
            this.cStartTime.DataPropertyName = "StartTime";
            this.cStartTime.HeaderText = "Thời gian bắt đầu";
            this.cStartTime.Name = "cStartTime";
            this.cStartTime.Width = 120;
            // 
            // cRoomtest
            // 
            this.cRoomtest.DataPropertyName = "Roomtest";
            this.cRoomtest.HeaderText = "Phòng Thi";
            this.cRoomtest.Name = "cRoomtest";
            // 
            // cbtnEncrypt
            // 
            this.cbtnEncrypt.DataPropertyName = "checkshift";
            this.cbtnEncrypt.HeaderText = "Niêm phong";
            this.cbtnEncrypt.Name = "cbtnEncrypt";
            this.cbtnEncrypt.Width = 70;
            // 
            // MFrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 474);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "MFrmMain";
            this.Text = "Chuyển dữ liệu thi";
            this.Load += new System.EventHandler(this.MFrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomTest)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDivisionShift)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbContestName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRoomTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRoomTestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMaxSitMount;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnConfig;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDivisionShift;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDivisionShiftID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cShiftName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRoomtest;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnEncrypt;
    }
}