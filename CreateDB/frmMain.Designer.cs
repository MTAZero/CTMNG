namespace CreateDB
{
    partial class frmMain
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPassThi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserThi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDBThi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIPThi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCheckExam = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassMain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserMain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDBServerMain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPServerMain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnReTransData = new System.Windows.Forms.Button();
            this.btnAgain = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvShift = new System.Windows.Forms.DataGridView();
            this.cSTT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShiftID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShiftName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkshift = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvRoomtest = new System.Windows.Forms.DataGridView();
            this.cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomtestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomtestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cboContest = new System.Windows.Forms.ComboBox();
            this.txtContestID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnChuyenNguoc = new System.Windows.Forms.Button();
            this.btnTranferData = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomtest)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPassThi);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtUserThi);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDBThi);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtIPThi);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(511, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Thi";
            // 
            // txtPassThi
            // 
            this.txtPassThi.Location = new System.Drawing.Point(129, 156);
            this.txtPassThi.Name = "txtPassThi";
            this.txtPassThi.PasswordChar = '☼';
            this.txtPassThi.Size = new System.Drawing.Size(246, 20);
            this.txtPassThi.TabIndex = 6;
            this.txtPassThi.Text = "1234@bcd";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Password";
            // 
            // txtUserThi
            // 
            this.txtUserThi.Location = new System.Drawing.Point(129, 111);
            this.txtUserThi.Name = "txtUserThi";
            this.txtUserThi.Size = new System.Drawing.Size(246, 20);
            this.txtUserThi.TabIndex = 7;
            this.txtUserThi.Text = "sa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Username";
            // 
            // txtDBThi
            // 
            this.txtDBThi.Location = new System.Drawing.Point(129, 69);
            this.txtDBThi.Name = "txtDBThi";
            this.txtDBThi.Size = new System.Drawing.Size(246, 20);
            this.txtDBThi.TabIndex = 8;
            this.txtDBThi.Text = "MTA_QUIZ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "DB Server Thi";
            // 
            // txtIPThi
            // 
            this.txtIPThi.Location = new System.Drawing.Point(129, 29);
            this.txtIPThi.Name = "txtIPThi";
            this.txtIPThi.Size = new System.Drawing.Size(246, 20);
            this.txtIPThi.TabIndex = 9;
            this.txtIPThi.Text = "169.254.227.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "IP Server Thi";
            // 
            // btnCheckExam
            // 
            this.btnCheckExam.Location = new System.Drawing.Point(590, 228);
            this.btnCheckExam.Name = "btnCheckExam";
            this.btnCheckExam.Size = new System.Drawing.Size(125, 39);
            this.btnCheckExam.TabIndex = 10;
            this.btnCheckExam.Text = "Kiểm tra kết nối";
            this.btnCheckExam.UseVisualStyleBackColor = true;
            this.btnCheckExam.Click += new System.EventHandler(this.btnCheckExam_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPassMain);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUserMain);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDBServerMain);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIPServerMain);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 200);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server  Trung Tâm";
            // 
            // txtPassMain
            // 
            this.txtPassMain.Location = new System.Drawing.Point(116, 156);
            this.txtPassMain.Name = "txtPassMain";
            this.txtPassMain.PasswordChar = '☼';
            this.txtPassMain.Size = new System.Drawing.Size(246, 20);
            this.txtPassMain.TabIndex = 6;
            this.txtPassMain.Text = "1234@bcd";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password";
            // 
            // txtUserMain
            // 
            this.txtUserMain.Location = new System.Drawing.Point(116, 111);
            this.txtUserMain.Name = "txtUserMain";
            this.txtUserMain.Size = new System.Drawing.Size(246, 20);
            this.txtUserMain.TabIndex = 7;
            this.txtUserMain.Text = "sa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Username";
            // 
            // txtDBServerMain
            // 
            this.txtDBServerMain.Location = new System.Drawing.Point(116, 69);
            this.txtDBServerMain.Name = "txtDBServerMain";
            this.txtDBServerMain.Size = new System.Drawing.Size(246, 20);
            this.txtDBServerMain.TabIndex = 2;
            this.txtDBServerMain.Text = "EXON_SYSTEM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "DB Server";
            // 
            // txtIPServerMain
            // 
            this.txtIPServerMain.Location = new System.Drawing.Point(116, 29);
            this.txtIPServerMain.Name = "txtIPServerMain";
            this.txtIPServerMain.Size = new System.Drawing.Size(246, 20);
            this.txtIPServerMain.TabIndex = 1;
            this.txtIPServerMain.Text = "169.254.227.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP Server";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnReTransData);
            this.splitContainer1.Panel1.Controls.Add(this.btnAgain);
            this.splitContainer1.Panel1.Controls.Add(this.btnCheckExam);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(1010, 635);
            this.splitContainer1.SplitterDistance = 293;
            this.splitContainer1.TabIndex = 4;
            // 
            // btnReTransData
            // 
            this.btnReTransData.Enabled = false;
            this.btnReTransData.Location = new System.Drawing.Point(457, 228);
            this.btnReTransData.Name = "btnReTransData";
            this.btnReTransData.Size = new System.Drawing.Size(75, 39);
            this.btnReTransData.TabIndex = 13;
            this.btnReTransData.Text = "Bắt đầu chuyển";
            this.btnReTransData.UseVisualStyleBackColor = true;
            this.btnReTransData.Visible = false;
            this.btnReTransData.Click += new System.EventHandler(this.btnReTransData_Click);
            // 
            // btnAgain
            // 
            this.btnAgain.Location = new System.Drawing.Point(299, 228);
            this.btnAgain.Name = "btnAgain";
            this.btnAgain.Size = new System.Drawing.Size(75, 39);
            this.btnAgain.TabIndex = 12;
            this.btnAgain.Text = "Kết nối lại";
            this.btnAgain.UseVisualStyleBackColor = true;
            this.btnAgain.Click += new System.EventHandler(this.btnAgain_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPrint);
            this.groupBox3.Controls.Add(this.cboLocation);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.dgvShift);
            this.groupBox3.Controls.Add(this.dgvRoomtest);
            this.groupBox3.Controls.Add(this.cboContest);
            this.groupBox3.Controls.Add(this.txtContestID);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.btnChuyenNguoc);
            this.groupBox3.Controls.Add(this.btnTranferData);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1010, 338);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách kỳ thi";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(660, 295);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(77, 37);
            this.btnPrint.TabIndex = 16;
            this.btnPrint.Text = "In danh sách ca thi";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cboLocation
            // 
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(660, 19);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(182, 21);
            this.cboLocation.TabIndex = 15;
            this.cboLocation.SelectedIndexChanged += new System.EventHandler(this.cboLocation_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(530, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Ca thời gian";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Địa điểm thi";
            // 
            // dgvShift
            // 
            this.dgvShift.AllowUserToAddRows = false;
            this.dgvShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShift.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSTT2,
            this.ShiftID,
            this.ShiftName,
            this.Date,
            this.StartTime,
            this.checkshift});
            this.dgvShift.Location = new System.Drawing.Point(511, 64);
            this.dgvShift.Name = "dgvShift";
            this.dgvShift.Size = new System.Drawing.Size(487, 218);
            this.dgvShift.TabIndex = 13;
            // 
            // cSTT2
            // 
            this.cSTT2.HeaderText = "STT";
            this.cSTT2.Name = "cSTT2";
            this.cSTT2.Width = 50;
            // 
            // ShiftID
            // 
            this.ShiftID.DataPropertyName = "ShiftID";
            this.ShiftID.HeaderText = "ID";
            this.ShiftID.Name = "ShiftID";
            this.ShiftID.Visible = false;
            // 
            // ShiftName
            // 
            this.ShiftName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ShiftName.DataPropertyName = "ShiftName";
            this.ShiftName.HeaderText = "Tên Ca thi";
            this.ShiftName.Name = "ShiftName";
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Ngày Thi";
            this.Date.Name = "Date";
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "Thời gian bắt đầu";
            this.StartTime.Name = "StartTime";
            // 
            // checkshift
            // 
            this.checkshift.DataPropertyName = "checkshift";
            this.checkshift.HeaderText = "Chọn";
            this.checkshift.Name = "checkshift";
            this.checkshift.Width = 50;
            // 
            // dgvRoomtest
            // 
            this.dgvRoomtest.AllowUserToAddRows = false;
            this.dgvRoomtest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoomtest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSTT,
            this.RoomtestID,
            this.RoomtestName,
            this.Location,
            this.check});
            this.dgvRoomtest.Location = new System.Drawing.Point(33, 64);
            this.dgvRoomtest.Name = "dgvRoomtest";
            this.dgvRoomtest.Size = new System.Drawing.Size(438, 218);
            this.dgvRoomtest.TabIndex = 12;
            // 
            // cSTT
            // 
            this.cSTT.HeaderText = "STT";
            this.cSTT.Name = "cSTT";
            this.cSTT.Width = 50;
            // 
            // RoomtestID
            // 
            this.RoomtestID.DataPropertyName = "RoomtestID";
            this.RoomtestID.HeaderText = "ID";
            this.RoomtestID.Name = "RoomtestID";
            this.RoomtestID.Visible = false;
            // 
            // RoomtestName
            // 
            this.RoomtestName.DataPropertyName = "RoomtestName";
            this.RoomtestName.HeaderText = "Tên Phòng";
            this.RoomtestName.Name = "RoomtestName";
            this.RoomtestName.Width = 150;
            // 
            // Location
            // 
            this.Location.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Location.DataPropertyName = "Location";
            this.Location.HeaderText = "Địa điểm";
            this.Location.Name = "Location";
            // 
            // check
            // 
            this.check.DataPropertyName = "check";
            this.check.HeaderText = "Chọn";
            this.check.Name = "check";
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check.Width = 50;
            // 
            // cboContest
            // 
            this.cboContest.FormattingEnabled = true;
            this.cboContest.Location = new System.Drawing.Point(102, 19);
            this.cboContest.Name = "cboContest";
            this.cboContest.Size = new System.Drawing.Size(321, 21);
            this.cboContest.TabIndex = 8;
            this.cboContest.SelectedIndexChanged += new System.EventHandler(this.cboContest_SelectedIndexChanged);
            // 
            // txtContestID
            // 
            this.txtContestID.Location = new System.Drawing.Point(844, 350);
            this.txtContestID.Name = "txtContestID";
            this.txtContestID.Size = new System.Drawing.Size(24, 20);
            this.txtContestID.TabIndex = 3;
            this.txtContestID.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(587, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Địa điểm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Kỳ thi";
            // 
            // btnChuyenNguoc
            // 
            this.btnChuyenNguoc.Location = new System.Drawing.Point(511, 295);
            this.btnChuyenNguoc.Name = "btnChuyenNguoc";
            this.btnChuyenNguoc.Size = new System.Drawing.Size(109, 40);
            this.btnChuyenNguoc.TabIndex = 0;
            this.btnChuyenNguoc.Text = "Chuyển Dữ liệu Ngược lại";
            this.btnChuyenNguoc.UseVisualStyleBackColor = true;
            this.btnChuyenNguoc.Click += new System.EventHandler(this.btnChuyenNguoc_Click);
            // 
            // btnTranferData
            // 
            this.btnTranferData.Enabled = false;
            this.btnTranferData.Location = new System.Drawing.Point(362, 292);
            this.btnTranferData.Name = "btnTranferData";
            this.btnTranferData.Size = new System.Drawing.Size(108, 40);
            this.btnTranferData.TabIndex = 0;
            this.btnTranferData.Text = "Chuyển Dữ liệu";
            this.btnTranferData.UseVisualStyleBackColor = true;
            this.btnTranferData.Click += new System.EventHandler(this.btnTranferData_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 635);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMain";
            this.Text = "Chuyển dữ liệu";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomtest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCheckExam;
        private System.Windows.Forms.TextBox txtPassThi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserThi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDBThi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIPThi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassMain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDBServerMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIPServerMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnAgain;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboContest;
        private System.Windows.Forms.TextBox txtContestID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnTranferData;
        private System.Windows.Forms.DataGridView dgvRoomtest;
        private System.Windows.Forms.DataGridView dgvShift;
        private System.Windows.Forms.Button btnChuyenNguoc;
        private System.Windows.Forms.Button btnReTransData;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSTT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShiftID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShiftName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkshift;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomtestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomtestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.Button btnPrint;
    }
}