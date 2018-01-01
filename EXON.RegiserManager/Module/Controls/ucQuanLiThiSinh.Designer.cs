namespace EXON.RegisterManager.Module.Controls
{
    partial class ucQuanLiThiSinh
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucQuanLiThiSinh));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cậpNhậtThôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lấyVânTayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbKeyName = new System.Windows.Forms.ComboBox();
            this.btnFilt = new System.Windows.Forms.Button();
            this.rdiNotImage = new System.Windows.Forms.RadioButton();
            this.rbNotFinger = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cContestantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBoD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStudentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIsImage = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTongSo = new System.Windows.Forms.Label();
            this.btnRefesh = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLayVanTay = new System.Windows.Forms.Button();
            this.btnChiTietThiSinh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.contextMenuMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1459433211_Remove.ico");
            this.imageList1.Images.SetKeyName(1, "1459968210_view-refresh.png");
            this.imageList1.Images.SetKeyName(2, "Actions-list-add-icon (1).png");
            this.imageList1.Images.SetKeyName(3, "Excel-icon.png");
            this.imageList1.Images.SetKeyName(4, "Search-icon.png");
            this.imageList1.Images.SetKeyName(5, "maps-and-flags.png");
            this.imageList1.Images.SetKeyName(6, "funnel.png");
            this.imageList1.Images.SetKeyName(7, "1459968365_edit-paste.png");
            this.imageList1.Images.SetKeyName(8, "Finger-Print-icon.png");
            // 
            // contextMenuMain
            // 
            this.contextMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cậpNhậtThôngTinToolStripMenuItem,
            this.lấyVânTayToolStripMenuItem,
            this.xóaToolStripMenuItem});
            this.contextMenuMain.Name = "contextMenuMain";
            this.contextMenuMain.Size = new System.Drawing.Size(175, 92);
            // 
            // cậpNhậtThôngTinToolStripMenuItem
            // 
            this.cậpNhậtThôngTinToolStripMenuItem.Name = "cậpNhậtThôngTinToolStripMenuItem";
            this.cậpNhậtThôngTinToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.cậpNhậtThôngTinToolStripMenuItem.Text = "Cập nhật thông tin";
            this.cậpNhậtThôngTinToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtThôngTinToolStripMenuItem_Click);
            // 
            // lấyVânTayToolStripMenuItem
            // 
            this.lấyVânTayToolStripMenuItem.Name = "lấyVânTayToolStripMenuItem";
            this.lấyVânTayToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.lấyVânTayToolStripMenuItem.Text = "Lấy Vân tay";
            this.lấyVânTayToolStripMenuItem.Click += new System.EventHandler(this.lấyVânTayToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbKeyName);
            this.groupBox2.Controls.Add(this.btnFilt);
            this.groupBox2.Controls.Add(this.rdiNotImage);
            this.groupBox2.Controls.Add(this.rbNotFinger);
            this.groupBox2.Controls.Add(this.rbAll);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.gvMain);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1104, 592);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách Thí sinh";
            // 
            // cmbKeyName
            // 
            this.cmbKeyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbKeyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbKeyName.FormattingEnabled = true;
            this.cmbKeyName.Location = new System.Drawing.Point(89, 19);
            this.cmbKeyName.Name = "cmbKeyName";
            this.cmbKeyName.Size = new System.Drawing.Size(438, 21);
            this.cmbKeyName.TabIndex = 9;
            this.cmbKeyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbKeyName_KeyDown);
            // 
            // btnFilt
            // 
            this.btnFilt.ImageIndex = 6;
            this.btnFilt.ImageList = this.imageList1;
            this.btnFilt.Location = new System.Drawing.Point(995, 15);
            this.btnFilt.Name = "btnFilt";
            this.btnFilt.Size = new System.Drawing.Size(75, 23);
            this.btnFilt.TabIndex = 8;
            this.btnFilt.Text = "Lọc";
            this.btnFilt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFilt.UseVisualStyleBackColor = true;
            this.btnFilt.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // rdiNotImage
            // 
            this.rdiNotImage.AutoSize = true;
            this.rdiNotImage.Location = new System.Drawing.Point(896, 18);
            this.rdiNotImage.Name = "rdiNotImage";
            this.rdiNotImage.Size = new System.Drawing.Size(73, 17);
            this.rdiNotImage.TabIndex = 7;
            this.rdiNotImage.TabStop = true;
            this.rdiNotImage.Text = "Thiếu ảnh";
            this.rdiNotImage.UseVisualStyleBackColor = true;
            // 
            // rbNotFinger
            // 
            this.rbNotFinger.AutoSize = true;
            this.rbNotFinger.Location = new System.Drawing.Point(782, 19);
            this.rbNotFinger.Name = "rbNotFinger";
            this.rbNotFinger.Size = new System.Drawing.Size(108, 17);
            this.rbNotFinger.TabIndex = 6;
            this.rbNotFinger.Text = "Chưa Lấy vân tay";
            this.rbNotFinger.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(719, 19);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(57, 17);
            this.rbAll.TabIndex = 5;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "Tất Cả";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.ImageIndex = 0;
            this.btnClear.ImageList = this.imageList1;
            this.btnClear.Location = new System.Drawing.Point(614, 18);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.ImageIndex = 4;
            this.btnSearch.ImageList = this.imageList1;
            this.btnSearch.Location = new System.Drawing.Point(533, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tìm Kiếm";
            // 
            // gvMain
            // 
            this.gvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvMain.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cID,
            this.cSTT,
            this.cCheck,
            this.cContestantCode,
            this.cName,
            this.CBoD,
            this.cCMND,
            this.cSex,
            this.cStudentCode,
            this.cStatus,
            this.cIsImage});
            this.gvMain.ContextMenuStrip = this.contextMenuMain;
            this.gvMain.GridColor = System.Drawing.Color.Black;
            this.gvMain.Location = new System.Drawing.Point(3, 47);
            this.gvMain.Name = "gvMain";
            this.gvMain.ReadOnly = true;
            this.gvMain.Size = new System.Drawing.Size(1098, 542);
            this.gvMain.TabIndex = 0;
            this.gvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellClick);
            this.gvMain.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvMain_CellMouseDown);
            this.gvMain.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.gvMain_RowPrePaint);
            this.gvMain.SelectionChanged += new System.EventHandler(this.gvMain_SelectionChanged);
            // 
            // cID
            // 
            this.cID.DataPropertyName = "ContestantID";
            this.cID.HeaderText = "ID";
            this.cID.Name = "cID";
            this.cID.ReadOnly = true;
            this.cID.Visible = false;
            // 
            // cSTT
            // 
            this.cSTT.DataPropertyName = "STT";
            this.cSTT.HeaderText = "STT";
            this.cSTT.Name = "cSTT";
            this.cSTT.ReadOnly = true;
            this.cSTT.Width = 50;
            // 
            // cCheck
            // 
            this.cCheck.FalseValue = "false";
            this.cCheck.HeaderText = "Chọn";
            this.cCheck.Name = "cCheck";
            this.cCheck.ReadOnly = true;
            this.cCheck.TrueValue = "true";
            this.cCheck.Width = 50;
            // 
            // cContestantCode
            // 
            this.cContestantCode.DataPropertyName = "ContestantCode";
            this.cContestantCode.HeaderText = "Số Báo danh";
            this.cContestantCode.Name = "cContestantCode";
            this.cContestantCode.ReadOnly = true;
            this.cContestantCode.Width = 150;
            // 
            // cName
            // 
            this.cName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cName.DataPropertyName = "FullName";
            this.cName.HeaderText = "Họ và Tên";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // CBoD
            // 
            this.CBoD.DataPropertyName = "DOB";
            this.CBoD.HeaderText = "Ngày Sinh";
            this.CBoD.Name = "CBoD";
            this.CBoD.ReadOnly = true;
            this.CBoD.Width = 200;
            // 
            // cCMND
            // 
            this.cCMND.DataPropertyName = "IdentityCardNumber";
            this.cCMND.HeaderText = "CMND";
            this.cCMND.Name = "cCMND";
            this.cCMND.ReadOnly = true;
            this.cCMND.Width = 150;
            // 
            // cSex
            // 
            this.cSex.DataPropertyName = "Sex";
            this.cSex.HeaderText = "Giới Tính";
            this.cSex.Name = "cSex";
            this.cSex.ReadOnly = true;
            this.cSex.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cStudentCode
            // 
            this.cStudentCode.DataPropertyName = "StudentCode";
            this.cStudentCode.HeaderText = "Mã sinh viên";
            this.cStudentCode.Name = "cStudentCode";
            this.cStudentCode.ReadOnly = true;
            this.cStudentCode.Visible = false;
            // 
            // cStatus
            // 
            this.cStatus.DataPropertyName = "Status";
            this.cStatus.HeaderText = "Trạng Thái";
            this.cStatus.Name = "cStatus";
            this.cStatus.ReadOnly = true;
            // 
            // cIsImage
            // 
            this.cIsImage.DataPropertyName = "IsImage";
            this.cIsImage.HeaderText = "Có ảnh";
            this.cIsImage.Name = "cIsImage";
            this.cIsImage.ReadOnly = true;
            this.cIsImage.Width = 70;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAccept);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbTongSo);
            this.groupBox1.Controls.Add(this.btnRefesh);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnLayVanTay);
            this.groupBox1.Controls.Add(this.btnChiTietThiSinh);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 592);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1104, 43);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAccept.Location = new System.Drawing.Point(448, 6);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 34);
            this.btnAccept.TabIndex = 12;
            this.btnAccept.Text = "Phê duyệt đăng ký";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(342, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Chưa lấy vân tay";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(192, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 19);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Blue;
            this.button6.Location = new System.Drawing.Point(317, 13);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(19, 19);
            this.button6.TabIndex = 9;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Đã lấy vân tay";
            // 
            // lbTongSo
            // 
            this.lbTongSo.AutoSize = true;
            this.lbTongSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongSo.Location = new System.Drawing.Point(6, 16);
            this.lbTongSo.Name = "lbTongSo";
            this.lbTongSo.Size = new System.Drawing.Size(62, 17);
            this.lbTongSo.TabIndex = 5;
            this.lbTongSo.Text = "Tổng Số";
            // 
            // btnRefesh
            // 
            this.btnRefesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefesh.ImageIndex = 1;
            this.btnRefesh.ImageList = this.imageList1;
            this.btnRefesh.Location = new System.Drawing.Point(1023, 11);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(75, 23);
            this.btnRefesh.TabIndex = 4;
            this.btnRefesh.Text = "Làm Mới";
            this.btnRefesh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefesh.UseVisualStyleBackColor = true;
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.ImageIndex = 0;
            this.btnXoa.ImageList = this.imageList1;
            this.btnXoa.Location = new System.Drawing.Point(942, 11);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLayVanTay
            // 
            this.btnLayVanTay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLayVanTay.ImageIndex = 8;
            this.btnLayVanTay.ImageList = this.imageList1;
            this.btnLayVanTay.Location = new System.Drawing.Point(697, 11);
            this.btnLayVanTay.Name = "btnLayVanTay";
            this.btnLayVanTay.Size = new System.Drawing.Size(112, 23);
            this.btnLayVanTay.TabIndex = 2;
            this.btnLayVanTay.Text = "Lấy vân tay";
            this.btnLayVanTay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLayVanTay.UseVisualStyleBackColor = true;
            this.btnLayVanTay.Click += new System.EventHandler(this.btnLayVanTay_Click);
            // 
            // btnChiTietThiSinh
            // 
            this.btnChiTietThiSinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiTietThiSinh.ImageIndex = 7;
            this.btnChiTietThiSinh.ImageList = this.imageList1;
            this.btnChiTietThiSinh.Location = new System.Drawing.Point(815, 11);
            this.btnChiTietThiSinh.Name = "btnChiTietThiSinh";
            this.btnChiTietThiSinh.Size = new System.Drawing.Size(123, 23);
            this.btnChiTietThiSinh.TabIndex = 2;
            this.btnChiTietThiSinh.Text = "Chi tiết thí sinh";
            this.btnChiTietThiSinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChiTietThiSinh.UseVisualStyleBackColor = true;
            this.btnChiTietThiSinh.Click += new System.EventHandler(this.btnChiTietThiSinh_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.ImageIndex = 3;
            this.btnExport.ImageList = this.imageList1;
            this.btnExport.Location = new System.Drawing.Point(574, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(117, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Xuất ra file Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // ucQuanLiThiSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucQuanLiThiSinh";
            this.Size = new System.Drawing.Size(1104, 635);
            this.contextMenuMain.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvMain;
        private System.Windows.Forms.Button btnRefesh;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.RadioButton rbNotFinger;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuMain;
        private System.Windows.Forms.ToolStripMenuItem cậpNhậtThôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.Label lbTongSo;
        private System.Windows.Forms.Button btnLayVanTay;
        private System.Windows.Forms.RadioButton rdiNotImage;
        private System.Windows.Forms.ToolStripMenuItem lấyVânTayToolStripMenuItem;
        private System.Windows.Forms.Button btnFilt;
        private System.Windows.Forms.ComboBox cmbKeyName;
        private System.Windows.Forms.Button btnChiTietThiSinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSTT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBoD;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCMND;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStudentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cIsImage;
        private System.Windows.Forms.Button btnAccept;
    }
}
