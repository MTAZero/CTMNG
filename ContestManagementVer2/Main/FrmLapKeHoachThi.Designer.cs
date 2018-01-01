namespace ContestManagementVer2.Main
{
    partial class FrmLapKeHoachThi
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelChinh = new System.Windows.Forms.Panel();
            this.panelChucNang = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSua = new MetroFramework.Controls.MetroButton();
            this.btnMonThi = new MetroFramework.Controls.MetroButton();
            this.btnCaThi = new MetroFramework.Controls.MetroButton();
            this.btnDiaDiem = new MetroFramework.Controls.MetroButton();
            this.btnPhanCongHDT = new MetroFramework.Controls.MetroButton();
            this.btnKiemTraKeHoach = new MetroFramework.Controls.MetroButton();
            this.btnHoanThanhKeHoach = new MetroFramework.Controls.MetroButton();
            this.panelThongTinKiThi = new System.Windows.Forms.GroupBox();
            this.dateCreatedQuestionEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateBeginDate = new System.Windows.Forms.DateTimePicker();
            this.dateCreatedQuestionStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateEndRegistration = new System.Windows.Forms.DateTimePicker();
            this.dateBeginRegistration = new System.Windows.Forms.DateTimePicker();
            this.dateCreatedDate = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContestName = new System.Windows.Forms.ComboBox();
            this.panelMain.SuspendLayout();
            this.panelChucNang.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelThongTinKiThi.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.panelChinh);
            this.panelMain.Controls.Add(this.panelChucNang);
            this.panelMain.Controls.Add(this.panelThongTinKiThi);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(20, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1300, 670);
            this.panelMain.TabIndex = 0;
            // 
            // panelChinh
            // 
            this.panelChinh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChinh.Location = new System.Drawing.Point(242, 210);
            this.panelChinh.Name = "panelChinh";
            this.panelChinh.Size = new System.Drawing.Size(1056, 458);
            this.panelChinh.TabIndex = 3;
            // 
            // panelChucNang
            // 
            this.panelChucNang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelChucNang.Controls.Add(this.flowLayoutPanel1);
            this.panelChucNang.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelChucNang.Location = new System.Drawing.Point(0, 210);
            this.panelChucNang.Name = "panelChucNang";
            this.panelChucNang.Size = new System.Drawing.Size(242, 458);
            this.panelChucNang.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSua);
            this.flowLayoutPanel1.Controls.Add(this.btnMonThi);
            this.flowLayoutPanel1.Controls.Add(this.btnCaThi);
            this.flowLayoutPanel1.Controls.Add(this.btnDiaDiem);
            this.flowLayoutPanel1.Controls.Add(this.btnPhanCongHDT);
            this.flowLayoutPanel1.Controls.Add(this.btnKiemTraKeHoach);
            this.flowLayoutPanel1.Controls.Add(this.btnHoanThanhKeHoach);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(238, 454);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSua.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.Location = new System.Drawing.Point(3, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(231, 39);
            this.btnSua.Style = MetroFramework.MetroColorStyle.Green;
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Lưu thông tin thời gian";
            this.btnSua.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnSua.UseCustomBackColor = true;
            this.btnSua.UseCustomForeColor = true;
            this.btnSua.UseSelectable = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnMonThi
            // 
            this.btnMonThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMonThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnMonThi.ForeColor = System.Drawing.Color.Black;
            this.btnMonThi.Location = new System.Drawing.Point(3, 48);
            this.btnMonThi.Name = "btnMonThi";
            this.btnMonThi.Size = new System.Drawing.Size(231, 39);
            this.btnMonThi.TabIndex = 8;
            this.btnMonThi.Text = "Môn thi";
            this.btnMonThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnMonThi.UseCustomBackColor = true;
            this.btnMonThi.UseCustomForeColor = true;
            this.btnMonThi.UseSelectable = true;
            this.btnMonThi.Click += new System.EventHandler(this.btnMonThi_Click);
            // 
            // btnCaThi
            // 
            this.btnCaThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCaThi.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnCaThi.ForeColor = System.Drawing.Color.Black;
            this.btnCaThi.Location = new System.Drawing.Point(3, 93);
            this.btnCaThi.Name = "btnCaThi";
            this.btnCaThi.Size = new System.Drawing.Size(231, 39);
            this.btnCaThi.TabIndex = 9;
            this.btnCaThi.Text = "Ca thi";
            this.btnCaThi.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnCaThi.UseCustomBackColor = true;
            this.btnCaThi.UseCustomForeColor = true;
            this.btnCaThi.UseSelectable = true;
            this.btnCaThi.Click += new System.EventHandler(this.btnCaThi_Click);
            // 
            // btnDiaDiem
            // 
            this.btnDiaDiem.AccessibleDescription = "";
            this.btnDiaDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDiaDiem.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnDiaDiem.ForeColor = System.Drawing.Color.Black;
            this.btnDiaDiem.Location = new System.Drawing.Point(3, 138);
            this.btnDiaDiem.Name = "btnDiaDiem";
            this.btnDiaDiem.Size = new System.Drawing.Size(231, 39);
            this.btnDiaDiem.TabIndex = 10;
            this.btnDiaDiem.Text = "Địa điểm - Phòng thi";
            this.btnDiaDiem.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnDiaDiem.UseCustomBackColor = true;
            this.btnDiaDiem.UseCustomForeColor = true;
            this.btnDiaDiem.UseSelectable = true;
            this.btnDiaDiem.Click += new System.EventHandler(this.btnDiaDiem_Click);
            // 
            // btnPhanCongHDT
            // 
            this.btnPhanCongHDT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPhanCongHDT.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnPhanCongHDT.ForeColor = System.Drawing.Color.Black;
            this.btnPhanCongHDT.Location = new System.Drawing.Point(3, 183);
            this.btnPhanCongHDT.Name = "btnPhanCongHDT";
            this.btnPhanCongHDT.Size = new System.Drawing.Size(231, 39);
            this.btnPhanCongHDT.TabIndex = 11;
            this.btnPhanCongHDT.Text = "Phân công hội đồng thi";
            this.btnPhanCongHDT.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnPhanCongHDT.UseCustomBackColor = true;
            this.btnPhanCongHDT.UseCustomForeColor = true;
            this.btnPhanCongHDT.UseSelectable = true;
            this.btnPhanCongHDT.Click += new System.EventHandler(this.btnPhanCongHDT_Click);
            // 
            // btnKiemTraKeHoach
            // 
            this.btnKiemTraKeHoach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnKiemTraKeHoach.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnKiemTraKeHoach.ForeColor = System.Drawing.Color.Black;
            this.btnKiemTraKeHoach.Location = new System.Drawing.Point(3, 228);
            this.btnKiemTraKeHoach.Name = "btnKiemTraKeHoach";
            this.btnKiemTraKeHoach.Size = new System.Drawing.Size(231, 39);
            this.btnKiemTraKeHoach.TabIndex = 12;
            this.btnKiemTraKeHoach.Text = "Xem kế hoạch";
            this.btnKiemTraKeHoach.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnKiemTraKeHoach.UseCustomBackColor = true;
            this.btnKiemTraKeHoach.UseCustomForeColor = true;
            this.btnKiemTraKeHoach.UseSelectable = true;
            this.btnKiemTraKeHoach.Click += new System.EventHandler(this.btnKiemTraKeHoach_Click);
            // 
            // btnHoanThanhKeHoach
            // 
            this.btnHoanThanhKeHoach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHoanThanhKeHoach.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnHoanThanhKeHoach.ForeColor = System.Drawing.Color.Black;
            this.btnHoanThanhKeHoach.Location = new System.Drawing.Point(3, 273);
            this.btnHoanThanhKeHoach.Name = "btnHoanThanhKeHoach";
            this.btnHoanThanhKeHoach.Size = new System.Drawing.Size(231, 39);
            this.btnHoanThanhKeHoach.TabIndex = 13;
            this.btnHoanThanhKeHoach.Text = "Hoàn thành kế hoạch";
            this.btnHoanThanhKeHoach.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnHoanThanhKeHoach.UseCustomBackColor = true;
            this.btnHoanThanhKeHoach.UseCustomForeColor = true;
            this.btnHoanThanhKeHoach.UseSelectable = true;
            this.btnHoanThanhKeHoach.Click += new System.EventHandler(this.btnHoanThanhKeHoach_Click);
            // 
            // panelThongTinKiThi
            // 
            this.panelThongTinKiThi.Controls.Add(this.txtContestName);
            this.panelThongTinKiThi.Controls.Add(this.dateCreatedQuestionEndDate);
            this.panelThongTinKiThi.Controls.Add(this.dateEndDate);
            this.panelThongTinKiThi.Controls.Add(this.dateBeginDate);
            this.panelThongTinKiThi.Controls.Add(this.dateCreatedQuestionStartDate);
            this.panelThongTinKiThi.Controls.Add(this.dateEndRegistration);
            this.panelThongTinKiThi.Controls.Add(this.dateBeginRegistration);
            this.panelThongTinKiThi.Controls.Add(this.dateCreatedDate);
            this.panelThongTinKiThi.Controls.Add(this.label26);
            this.panelThongTinKiThi.Controls.Add(this.label23);
            this.panelThongTinKiThi.Controls.Add(this.label21);
            this.panelThongTinKiThi.Controls.Add(this.label19);
            this.panelThongTinKiThi.Controls.Add(this.label18);
            this.panelThongTinKiThi.Controls.Add(this.label17);
            this.panelThongTinKiThi.Controls.Add(this.label16);
            this.panelThongTinKiThi.Controls.Add(this.label5);
            this.panelThongTinKiThi.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelThongTinKiThi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelThongTinKiThi.Location = new System.Drawing.Point(0, 0);
            this.panelThongTinKiThi.Name = "panelThongTinKiThi";
            this.panelThongTinKiThi.Size = new System.Drawing.Size(1298, 210);
            this.panelThongTinKiThi.TabIndex = 0;
            this.panelThongTinKiThi.TabStop = false;
            this.panelThongTinKiThi.Text = "Thông tin thời gian";
            // 
            // dateCreatedQuestionEndDate
            // 
            this.dateCreatedQuestionEndDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateCreatedQuestionEndDate.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCreatedQuestionEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateCreatedQuestionEndDate.Location = new System.Drawing.Point(792, 115);
            this.dateCreatedQuestionEndDate.Name = "dateCreatedQuestionEndDate";
            this.dateCreatedQuestionEndDate.Size = new System.Drawing.Size(149, 24);
            this.dateCreatedQuestionEndDate.TabIndex = 31;
            // 
            // dateEndDate
            // 
            this.dateEndDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateEndDate.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEndDate.Location = new System.Drawing.Point(792, 161);
            this.dateEndDate.Name = "dateEndDate";
            this.dateEndDate.Size = new System.Drawing.Size(149, 24);
            this.dateEndDate.TabIndex = 30;
            // 
            // dateBeginDate
            // 
            this.dateBeginDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateBeginDate.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateBeginDate.Location = new System.Drawing.Point(308, 161);
            this.dateBeginDate.Name = "dateBeginDate";
            this.dateBeginDate.Size = new System.Drawing.Size(149, 24);
            this.dateBeginDate.TabIndex = 29;
            // 
            // dateCreatedQuestionStartDate
            // 
            this.dateCreatedQuestionStartDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateCreatedQuestionStartDate.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCreatedQuestionStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateCreatedQuestionStartDate.Location = new System.Drawing.Point(308, 116);
            this.dateCreatedQuestionStartDate.Name = "dateCreatedQuestionStartDate";
            this.dateCreatedQuestionStartDate.Size = new System.Drawing.Size(149, 24);
            this.dateCreatedQuestionStartDate.TabIndex = 28;
            // 
            // dateEndRegistration
            // 
            this.dateEndRegistration.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateEndRegistration.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEndRegistration.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEndRegistration.Location = new System.Drawing.Point(792, 71);
            this.dateEndRegistration.Name = "dateEndRegistration";
            this.dateEndRegistration.Size = new System.Drawing.Size(149, 24);
            this.dateEndRegistration.TabIndex = 27;
            // 
            // dateBeginRegistration
            // 
            this.dateBeginRegistration.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateBeginRegistration.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateBeginRegistration.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateBeginRegistration.Location = new System.Drawing.Point(308, 71);
            this.dateBeginRegistration.Name = "dateBeginRegistration";
            this.dateBeginRegistration.Size = new System.Drawing.Size(149, 24);
            this.dateBeginRegistration.TabIndex = 26;
            // 
            // dateCreatedDate
            // 
            this.dateCreatedDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateCreatedDate.Enabled = false;
            this.dateCreatedDate.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCreatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateCreatedDate.Location = new System.Drawing.Point(792, 31);
            this.dateCreatedDate.Name = "dateCreatedDate";
            this.dateCreatedDate.Size = new System.Drawing.Size(149, 24);
            this.dateCreatedDate.TabIndex = 25;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(650, 168);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(88, 17);
            this.label26.TabIndex = 24;
            this.label26.Text = "Kết thúc thi : ";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(650, 122);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(114, 17);
            this.label23.TabIndex = 23;
            this.label23.Text = "Kết thúc làm đề : ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(190, 167);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 17);
            this.label21.TabIndex = 22;
            this.label21.Text = "Bắt đầu thi : ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(190, 122);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 17);
            this.label19.TabIndex = 21;
            this.label19.Text = "Bắt đầu làm đề : ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(650, 77);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(121, 17);
            this.label18.TabIndex = 20;
            this.label18.Text = "Kết thúc đăng ký : ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(190, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 17);
            this.label17.TabIndex = 19;
            this.label17.Text = "Bắt đầu đăng ký : ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(650, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 17);
            this.label16.TabIndex = 17;
            this.label16.Text = "Ngày tạo : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(190, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tên kì thi : ";
            // 
            // txtContestName
            // 
            this.txtContestName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtContestName.FormattingEnabled = true;
            this.txtContestName.Items.AddRange(new object[] {
            "Đánh giá năng lực",
            "Đầu ra ngoại ngữ"});
            this.txtContestName.Location = new System.Drawing.Point(308, 27);
            this.txtContestName.Name = "txtContestName";
            this.txtContestName.Size = new System.Drawing.Size(307, 27);
            this.txtContestName.TabIndex = 32;
            // 
            // FrmLapKeHoachThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 750);
            this.Controls.Add(this.panelMain);
            this.MaximizeBox = false;
            this.Name = "FrmLapKeHoachThi";
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "LẬP KẾ HOẠCH THI";
            this.Load += new System.EventHandler(this.FrmLapKeHoachThi_Load);
            this.panelMain.ResumeLayout(false);
            this.panelChucNang.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelThongTinKiThi.ResumeLayout(false);
            this.panelThongTinKiThi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox panelThongTinKiThi;
        private System.Windows.Forms.Panel panelChucNang;
        private System.Windows.Forms.Panel panelChinh;
        private System.Windows.Forms.DateTimePicker dateEndDate;
        private System.Windows.Forms.DateTimePicker dateBeginDate;
        private System.Windows.Forms.DateTimePicker dateCreatedQuestionStartDate;
        private System.Windows.Forms.DateTimePicker dateEndRegistration;
        private System.Windows.Forms.DateTimePicker dateBeginRegistration;
        private System.Windows.Forms.DateTimePicker dateCreatedDate;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateCreatedQuestionEndDate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroFramework.Controls.MetroButton btnHoanThanhKeHoach;
        private MetroFramework.Controls.MetroButton btnKiemTraKeHoach;
        private MetroFramework.Controls.MetroButton btnPhanCongHDT;
        private MetroFramework.Controls.MetroButton btnDiaDiem;
        private MetroFramework.Controls.MetroButton btnCaThi;
        private MetroFramework.Controls.MetroButton btnMonThi;
        private MetroFramework.Controls.MetroButton btnSua;
        private System.Windows.Forms.ComboBox txtContestName;
    }
}