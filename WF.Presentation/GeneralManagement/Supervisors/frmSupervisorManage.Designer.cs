namespace GeneralManagement.Supervisors
{
    partial class frmSupervisorManage
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupervisorManage));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvListRoomTest = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomTestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomTestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxSeatMount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Endtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SHIFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblChuThich = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.btnRegisterFinger = new MetroFramework.Controls.MetroButton();
            this.btnRefresh = new MetroFramework.Controls.MetroButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.analogClock1 = new AnalogClock.AnalogClock();
            this.lblTimeNow = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.mlblContestName = new MetroFramework.Controls.MetroLabel();
            this.mbtnSupervisor = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.metroContextMenu2 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.mItemMenuCheckinRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemMenuComein = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mItemMenuTurnOn = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoomTest)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.metroContextMenu1.SuspendLayout();
            this.metroContextMenu2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(1, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1348, 570);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(977, 544);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách các ca thi hiện tại hoặc gần đến giờ: ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvListRoomTest);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(971, 391);
            this.panel2.TabIndex = 3;
            // 
            // dgvListRoomTest
            // 
            this.dgvListRoomTest.AllowUserToAddRows = false;
            this.dgvListRoomTest.AllowUserToDeleteRows = false;
            this.dgvListRoomTest.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvListRoomTest.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvListRoomTest.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvListRoomTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListRoomTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.RoomTestID,
            this.RoomTestName,
            this.MaxSeatMount,
            this.StartTime,
            this.Endtime,
            this.SHIFID});
            this.dgvListRoomTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListRoomTest.EnableHeadersVisualStyles = false;
            this.dgvListRoomTest.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvListRoomTest.Location = new System.Drawing.Point(0, 0);
            this.dgvListRoomTest.MultiSelect = false;
            this.dgvListRoomTest.Name = "dgvListRoomTest";
            this.dgvListRoomTest.ReadOnly = true;
            this.dgvListRoomTest.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvListRoomTest.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListRoomTest.Size = new System.Drawing.Size(971, 391);
            this.dgvListRoomTest.TabIndex = 1;
            this.dgvListRoomTest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListRoomTest_CellClick);
            this.dgvListRoomTest.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListRoomTest_CellDoubleClick);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // RoomTestID
            // 
            this.RoomTestID.HeaderText = "Mã phòng thi";
            this.RoomTestID.Name = "RoomTestID";
            this.RoomTestID.ReadOnly = true;
            this.RoomTestID.Visible = false;
            // 
            // RoomTestName
            // 
            this.RoomTestName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RoomTestName.HeaderText = "Tên phòng thi";
            this.RoomTestName.Name = "RoomTestName";
            this.RoomTestName.ReadOnly = true;
            // 
            // MaxSeatMount
            // 
            this.MaxSeatMount.HeaderText = "Số chỗ ngồi";
            this.MaxSeatMount.Name = "MaxSeatMount";
            this.MaxSeatMount.ReadOnly = true;
            this.MaxSeatMount.Width = 150;
            // 
            // StartTime
            // 
            this.StartTime.FillWeight = 200F;
            this.StartTime.HeaderText = "Thời gian bắt đầu";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Width = 210;
            // 
            // Endtime
            // 
            this.Endtime.FillWeight = 200F;
            this.Endtime.HeaderText = "Thời gian kết thúc";
            this.Endtime.Name = "Endtime";
            this.Endtime.ReadOnly = true;
            this.Endtime.Width = 210;
            // 
            // SHIFID
            // 
            this.SHIFID.HeaderText = "ShiftID";
            this.SHIFID.Name = "SHIFID";
            this.SHIFID.ReadOnly = true;
            this.SHIFID.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblChuThich);
            this.panel1.Controls.Add(this.lblThongBao);
            this.panel1.Controls.Add(this.btnRegisterFinger);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 413);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 128);
            this.panel1.TabIndex = 2;
            // 
            // lblChuThich
            // 
            this.lblChuThich.AutoSize = true;
            this.lblChuThich.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChuThich.ForeColor = System.Drawing.Color.Red;
            this.lblChuThich.Location = new System.Drawing.Point(13, 30);
            this.lblChuThich.Name = "lblChuThich";
            this.lblChuThich.Size = new System.Drawing.Size(948, 38);
            this.lblChuThich.TabIndex = 3;
            this.lblChuThich.Text = "Bạn chỉ có thể xem ca thi trong khoảng thời gian trước 30\' và truy cập vào phòng " +
    "thi trước 15\' thời gian ca thi bắt đầu để tiến hành điều hành\r\n giám sát ca thi";
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblThongBao.Location = new System.Drawing.Point(13, 11);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(88, 19);
            this.lblThongBao.TabIndex = 2;
            this.lblThongBao.Text = "Thông báo: ";
            // 
            // btnRegisterFinger
            // 
            this.btnRegisterFinger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.btnRegisterFinger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegisterFinger.ForeColor = System.Drawing.Color.White;
            this.btnRegisterFinger.Location = new System.Drawing.Point(519, 71);
            this.btnRegisterFinger.Name = "btnRegisterFinger";
            this.btnRegisterFinger.Size = new System.Drawing.Size(187, 45);
            this.btnRegisterFinger.TabIndex = 0;
            this.btnRegisterFinger.Text = "Đăng ký xác thực";
            this.btnRegisterFinger.UseCustomBackColor = true;
            this.btnRegisterFinger.UseCustomForeColor = true;
            this.btnRegisterFinger.UseSelectable = true;
            this.btnRegisterFinger.Click += new System.EventHandler(this.btnRegisterFinger_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(182)))), ((int)(((byte)(246)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(251, 71);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(187, 45);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Cập nhập danh sách ca thi";
            this.btnRefresh.UseCustomBackColor = true;
            this.btnRefresh.UseCustomForeColor = true;
            this.btnRefresh.UseSelectable = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.analogClock1);
            this.groupBox2.Controls.Add(this.lblTimeNow);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(980, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 544);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Giờ hệ thống";
            // 
            // analogClock1
            // 
            this.analogClock1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analogClock1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.analogClock1.CalendarType = AnalogClock.AnalogClock.CalendarTypes.Gregorian;
            this.analogClock1.Caption = "MTA Clock";
            this.analogClock1.ClockStyle = AnalogClock.AnalogClock.ClockStyles.Standard;
            this.analogClock1.DateStyle = AnalogClock.AnalogClock.DateStyles.Full;
            this.analogClock1.Enabled = false;
            this.analogClock1.HandColor = System.Drawing.Color.Black;
            this.analogClock1.HandStyle = AnalogClock.AnalogClock.HandStyles.Uniform;
            this.analogClock1.InnerColor = System.Drawing.Color.SkyBlue;
            this.analogClock1.Location = new System.Drawing.Point(51, 25);
            this.analogClock1.Margin = new System.Windows.Forms.Padding(4);
            this.analogClock1.MinimumSize = new System.Drawing.Size(75, 69);
            this.analogClock1.Name = "analogClock1";
            this.analogClock1.NumberStyle = AnalogClock.AnalogClock.NumberStyles.All;
            this.analogClock1.OuterColor = System.Drawing.Color.SteelBlue;
            this.analogClock1.SecondHandColor = System.Drawing.Color.Red;
            this.analogClock1.Size = new System.Drawing.Size(283, 209);
            this.analogClock1.TabIndex = 2;
            this.analogClock1.TextColor = System.Drawing.Color.Black;
            this.analogClock1.TickColor = System.Drawing.Color.Black;
            this.analogClock1.TickStyle = AnalogClock.AnalogClock.TickStyles.All;
            // 
            // lblTimeNow
            // 
            this.lblTimeNow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeNow.AutoSize = true;
            this.lblTimeNow.Location = new System.Drawing.Point(106, 274);
            this.lblTimeNow.Name = "lblTimeNow";
            this.lblTimeNow.Size = new System.Drawing.Size(0, 19);
            this.lblTimeNow.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.metroPanel1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(1, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1348, 57);
            this.panelMain.TabIndex = 2;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.mlblContestName);
            this.metroPanel1.Controls.Add(this.mbtnSupervisor);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1348, 51);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // mlblContestName
            // 
            this.mlblContestName.AutoSize = true;
            this.mlblContestName.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.mlblContestName.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.mlblContestName.Location = new System.Drawing.Point(33, 10);
            this.mlblContestName.Name = "mlblContestName";
            this.mlblContestName.Size = new System.Drawing.Size(0, 0);
            this.mlblContestName.TabIndex = 5;
            // 
            // mbtnSupervisor
            // 
            this.mbtnSupervisor.AutoSize = true;
            this.mbtnSupervisor.Highlight = true;
            this.mbtnSupervisor.Location = new System.Drawing.Point(1198, 3);
            this.mbtnSupervisor.Name = "mbtnSupervisor";
            this.mbtnSupervisor.Size = new System.Drawing.Size(147, 25);
            this.mbtnSupervisor.TabIndex = 3;
            this.mbtnSupervisor.UseSelectable = true;
            this.mbtnSupervisor.Click += new System.EventHandler(this.mbtnSupervisor_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Gold;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(1105, 3);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(87, 25);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Xin chào: ";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Green;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maintenanceToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(172, 54);
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.maintenanceToolStripMenuItem.Text = "&Đổi mật khẩu";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.toolsToolStripMenuItem.Text = "&Thông tin cá nhân";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
            // 
            // metroContextMenu2
            // 
            this.metroContextMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemMenuCheckinRoom,
            this.mItemMenuComein,
            this.toolStripSeparator1,
            this.mItemMenuTurnOn});
            this.metroContextMenu2.Name = "metroContextMenu1";
            this.metroContextMenu2.Size = new System.Drawing.Size(184, 76);
            // 
            // mItemMenuCheckinRoom
            // 
            this.mItemMenuCheckinRoom.Name = "mItemMenuCheckinRoom";
            this.mItemMenuCheckinRoom.Size = new System.Drawing.Size(183, 22);
            this.mItemMenuCheckinRoom.Text = "&Kiểm tra phòng thi";
            this.mItemMenuCheckinRoom.Click += new System.EventHandler(this.mItemMenuCheckinRoom_Click);
            // 
            // mItemMenuComein
            // 
            this.mItemMenuComein.Name = "mItemMenuComein";
            this.mItemMenuComein.Size = new System.Drawing.Size(183, 22);
            this.mItemMenuComein.Text = "&Vào phòng thi";
            this.mItemMenuComein.Click += new System.EventHandler(this.mItemMenuComein_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // mItemMenuTurnOn
            // 
            this.mItemMenuTurnOn.Name = "mItemMenuTurnOn";
            this.mItemMenuTurnOn.Size = new System.Drawing.Size(183, 22);
            this.mItemMenuTurnOn.Text = "&Bật Camera giám sát";
            this.mItemMenuTurnOn.Click += new System.EventHandler(this.mItemMenuTurnOn_Click);
            // 
            // frmSupervisorManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 688);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmSupervisorManage";
            this.Padding = new System.Windows.Forms.Padding(1, 60, 1, 1);
            this.Tag = "  ";
            this.Text = "GIÁM SÁT CUỘC THI";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSupervisorManage_FormClosing);
            this.Load += new System.EventHandler(this.frmSupervisorManage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoomTest)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.metroContextMenu1.ResumeLayout(false);
            this.metroContextMenu2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvListRoomTest;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private AnalogClock.AnalogClock analogClock1;
        private System.Windows.Forms.Label lblTimeNow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton mbtnSupervisor;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu2;
        private System.Windows.Forms.ToolStripMenuItem mItemMenuCheckinRoom;
        private System.Windows.Forms.ToolStripMenuItem mItemMenuComein;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mItemMenuTurnOn;
        private System.Windows.Forms.Label lblChuThich;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroLabel mlblContestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomTestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomTestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxSeatMount;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Endtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn SHIFID;
        private MetroFramework.Controls.MetroButton btnRefresh;
        private MetroFramework.Controls.MetroButton btnRegisterFinger;
    }
}