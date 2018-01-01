namespace EXON.RegisterManager.Module.Controls
{
    partial class ucQuanLiDangKi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucQuanLiDangKi));
            this.contextMenuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PrintReceiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoneRegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.GetfingerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbKeyName = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.rbtnNotgetFinger = new System.Windows.Forms.RadioButton();
            this.rbtnDone = new System.Windows.Forms.RadioButton();
            this.rbtnNotReceipt = new System.Windows.Forms.RadioButton();
            this.rbtnLostImage = new System.Windows.Forms.RadioButton();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContestantID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cContestantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStudentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBoD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIsGetFinger = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cIsImage = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.lbCount = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddnew = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.contextMenuMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuMain
            // 
            this.contextMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintReceiptToolStripMenuItem,
            this.DoneRegisterToolStripMenuItem,
            this.UpdateInfoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.GetfingerToolStripMenuItem,
            this.DeleteToolStripMenuItem});
            this.contextMenuMain.Name = "contextMenuMain";
            this.contextMenuMain.Size = new System.Drawing.Size(175, 120);
            this.contextMenuMain.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuMain_Opening);
            // 
            // PrintReceiptToolStripMenuItem
            // 
            this.PrintReceiptToolStripMenuItem.Name = "PrintReceiptToolStripMenuItem";
            this.PrintReceiptToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.PrintReceiptToolStripMenuItem.Text = "In phiếu thu";
            this.PrintReceiptToolStripMenuItem.Click += new System.EventHandler(this.PrintReceiptToolStripMenuItem_Click);
            // 
            // DoneRegisterToolStripMenuItem
            // 
            this.DoneRegisterToolStripMenuItem.Name = "DoneRegisterToolStripMenuItem";
            this.DoneRegisterToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.DoneRegisterToolStripMenuItem.Text = "Hoàn Tất Đăng Ki";
            this.DoneRegisterToolStripMenuItem.Click += new System.EventHandler(this.DoneRegisterToolStripMenuItem_Click);
            // 
            // UpdateInfoToolStripMenuItem
            // 
            this.UpdateInfoToolStripMenuItem.Name = "UpdateInfoToolStripMenuItem";
            this.UpdateInfoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.UpdateInfoToolStripMenuItem.Text = "Cập nhật thông tin";
            this.UpdateInfoToolStripMenuItem.Click += new System.EventHandler(this.UpdateInfoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(171, 6);
            // 
            // GetfingerToolStripMenuItem
            // 
            this.GetfingerToolStripMenuItem.Name = "GetfingerToolStripMenuItem";
            this.GetfingerToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.GetfingerToolStripMenuItem.Text = "Lấy dấu vân tay";
            this.GetfingerToolStripMenuItem.Click += new System.EventHandler(this.GetfingerToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.DeleteToolStripMenuItem.Text = "Xóa";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbKeyName);
            this.groupBox2.Controls.Add(this.btnFilter);
            this.groupBox2.Controls.Add(this.rbtnNotgetFinger);
            this.groupBox2.Controls.Add(this.rbtnDone);
            this.groupBox2.Controls.Add(this.rbtnNotReceipt);
            this.groupBox2.Controls.Add(this.rbtnLostImage);
            this.groupBox2.Controls.Add(this.rbtnAll);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.gvMain);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1359, 585);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Đăng Ký";
            // 
            // cmbKeyName
            // 
            this.cmbKeyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbKeyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbKeyName.FormattingEnabled = true;
            this.cmbKeyName.Location = new System.Drawing.Point(77, 18);
            this.cmbKeyName.Name = "cmbKeyName";
            this.cmbKeyName.Size = new System.Drawing.Size(420, 21);
            this.cmbKeyName.TabIndex = 8;
            this.cmbKeyName.SelectedIndexChanged += new System.EventHandler(this.cmbKeyName_SelectedIndexChanged);
            this.cmbKeyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbKeyName_KeyDown);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Image = global::EXON.RegisterManager.Properties.Resources.filter;
            this.btnFilter.Location = new System.Drawing.Point(1268, 15);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 30);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // rbtnNotgetFinger
            // 
            this.rbtnNotgetFinger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnNotgetFinger.AutoSize = true;
            this.rbtnNotgetFinger.Location = new System.Drawing.Point(1156, 21);
            this.rbtnNotgetFinger.Name = "rbtnNotgetFinger";
            this.rbtnNotgetFinger.Size = new System.Drawing.Size(104, 17);
            this.rbtnNotgetFinger.TabIndex = 6;
            this.rbtnNotgetFinger.Text = "Chưa lấy vân tay";
            this.rbtnNotgetFinger.UseVisualStyleBackColor = true;
            // 
            // rbtnDone
            // 
            this.rbtnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnDone.AutoSize = true;
            this.rbtnDone.Location = new System.Drawing.Point(1056, 21);
            this.rbtnDone.Name = "rbtnDone";
            this.rbtnDone.Size = new System.Drawing.Size(90, 17);
            this.rbtnDone.TabIndex = 6;
            this.rbtnDone.Text = "Đã nộp lệ phí";
            this.rbtnDone.UseVisualStyleBackColor = true;
            // 
            // rbtnNotReceipt
            // 
            this.rbtnNotReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnNotReceipt.AutoSize = true;
            this.rbtnNotReceipt.Location = new System.Drawing.Point(925, 21);
            this.rbtnNotReceipt.Name = "rbtnNotReceipt";
            this.rbtnNotReceipt.Size = new System.Drawing.Size(114, 17);
            this.rbtnNotReceipt.TabIndex = 6;
            this.rbtnNotReceipt.Text = "Chưa lập phiếu thu";
            this.rbtnNotReceipt.UseVisualStyleBackColor = true;
            // 
            // rbtnLostImage
            // 
            this.rbtnLostImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnLostImage.AutoSize = true;
            this.rbtnLostImage.Location = new System.Drawing.Point(825, 21);
            this.rbtnLostImage.Name = "rbtnLostImage";
            this.rbtnLostImage.Size = new System.Drawing.Size(74, 17);
            this.rbtnLostImage.TabIndex = 6;
            this.rbtnLostImage.Text = "Thiếu Ảnh";
            this.rbtnLostImage.UseVisualStyleBackColor = true;
            // 
            // rbtnAll
            // 
            this.rbtnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Checked = true;
            this.rbtnAll.Location = new System.Drawing.Point(751, 21);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(57, 17);
            this.rbtnAll.TabIndex = 5;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "Tất Cả";
            this.rbtnAll.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Image = global::EXON.RegisterManager.Properties.Resources.delete16;
            this.btnClear.Location = new System.Drawing.Point(618, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Xóa";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::EXON.RegisterManager.Properties.Resources.search16;
            this.btnSearch.Location = new System.Drawing.Point(537, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 30);
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
            this.gvMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cID,
            this.cContestantID,
            this.cSTT,
            this.cCheck,
            this.cContestantCode,
            this.cStudentCode,
            this.cName,
            this.CBoD,
            this.cCMND,
            this.cSex,
            this.cStatus,
            this.cIsGetFinger,
            this.cIsImage});
            this.gvMain.ContextMenuStrip = this.contextMenuMain;
            this.gvMain.Location = new System.Drawing.Point(3, 57);
            this.gvMain.Name = "gvMain";
            this.gvMain.Size = new System.Drawing.Size(1340, 522);
            this.gvMain.TabIndex = 0;
            this.gvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellClick);
            this.gvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellContentClick);
            this.gvMain.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvMain_CellMouseDown);
            this.gvMain.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.gvMain_RowPrePaint);
            this.gvMain.SelectionChanged += new System.EventHandler(this.gvMain_SelectionChanged);
            // 
            // cID
            // 
            this.cID.DataPropertyName = "RegisterID";
            this.cID.HeaderText = "ID";
            this.cID.Name = "cID";
            this.cID.Visible = false;
            // 
            // cContestantID
            // 
            this.cContestantID.DataPropertyName = "ContestantID";
            this.cContestantID.HeaderText = "cID";
            this.cContestantID.Name = "cContestantID";
            this.cContestantID.Visible = false;
            // 
            // cSTT
            // 
            this.cSTT.DataPropertyName = "STT";
            this.cSTT.HeaderText = "STT";
            this.cSTT.Name = "cSTT";
            this.cSTT.Width = 50;
            // 
            // cCheck
            // 
            this.cCheck.FalseValue = "false";
            this.cCheck.HeaderText = "Chọn";
            this.cCheck.Name = "cCheck";
            this.cCheck.TrueValue = "true";
            this.cCheck.Width = 70;
            // 
            // cContestantCode
            // 
            this.cContestantCode.DataPropertyName = "ContestantCode";
            this.cContestantCode.HeaderText = "SBD";
            this.cContestantCode.Name = "cContestantCode";
            this.cContestantCode.Width = 120;
            // 
            // cStudentCode
            // 
            this.cStudentCode.DataPropertyName = "StudentCode";
            this.cStudentCode.HeaderText = "Mã sinh viên";
            this.cStudentCode.Name = "cStudentCode";
            this.cStudentCode.Visible = false;
            // 
            // cName
            // 
            this.cName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cName.DataPropertyName = "FullName";
            this.cName.HeaderText = "Họ và Tên";
            this.cName.Name = "cName";
            // 
            // CBoD
            // 
            this.CBoD.DataPropertyName = "DOB";
            this.CBoD.HeaderText = "Ngày Sinh";
            this.CBoD.Name = "CBoD";
            this.CBoD.Width = 120;
            // 
            // cCMND
            // 
            this.cCMND.DataPropertyName = "IdentityCardNumber";
            this.cCMND.HeaderText = "CMND";
            this.cCMND.Name = "cCMND";
            this.cCMND.Width = 150;
            // 
            // cSex
            // 
            this.cSex.DataPropertyName = "Sex";
            this.cSex.HeaderText = "Giới Tính";
            this.cSex.Name = "cSex";
            this.cSex.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cSex.Width = 120;
            // 
            // cStatus
            // 
            this.cStatus.DataPropertyName = "Status";
            this.cStatus.HeaderText = "Lệ phí thi";
            this.cStatus.Name = "cStatus";
            this.cStatus.Width = 150;
            // 
            // cIsGetFinger
            // 
            this.cIsGetFinger.DataPropertyName = "IsGetFingerPrinter";
            this.cIsGetFinger.HeaderText = "Đã lấy vân tay";
            this.cIsGetFinger.Name = "cIsGetFinger";
            this.cIsGetFinger.ReadOnly = true;
            this.cIsGetFinger.Width = 120;
            // 
            // cIsImage
            // 
            this.cIsImage.DataPropertyName = "IsImage";
            this.cIsImage.HeaderText = "Có ảnh";
            this.cIsImage.Name = "cIsImage";
            this.cIsImage.ReadOnly = true;
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
            this.imageList1.Images.SetKeyName(7, "Finger-Print-icon.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAccept);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.btnDone);
            this.groupBox1.Controls.Add(this.lbCount);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAddnew);
            this.groupBox1.Controls.Add(this.btnExportExcel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 585);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1359, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAccept.Location = new System.Drawing.Point(574, 10);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(110, 34);
            this.btnAccept.TabIndex = 14;
            this.btnAccept.Text = "Kết thúc đăng ký";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Visible = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(615, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Đã lấy dấu vân tay";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Indigo;
            this.button1.Location = new System.Drawing.Point(590, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 19);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(414, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Chưa lập phiếu thu, chưa có ảnh";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(389, 44);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(19, 19);
            this.button6.TabIndex = 7;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Đã lập phiếu thu";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.SaddleBrown;
            this.button5.Location = new System.Drawing.Point(261, 44);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(19, 19);
            this.button5.TabIndex = 7;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Chưa lập phiếu thu";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkGreen;
            this.button4.Location = new System.Drawing.Point(129, 44);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(19, 19);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hoàn tất đăng ký";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkBlue;
            this.button3.Location = new System.Drawing.Point(8, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(19, 19);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.Enabled = false;
            this.btnDone.Image = global::EXON.RegisterManager.Properties.Resources.check16;
            this.btnDone.Location = new System.Drawing.Point(976, 11);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(123, 30);
            this.btnDone.TabIndex = 6;
            this.btnDone.Text = "Hoàn tất đăng ký";
            this.btnDone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(6, 16);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(48, 13);
            this.lbCount.TabIndex = 5;
            this.lbCount.Text = "Tổng Số";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::EXON.RegisterManager.Properties.Resources.refresh162;
            this.btnRefresh.Location = new System.Drawing.Point(1233, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(123, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::EXON.RegisterManager.Properties.Resources.delete16;
            this.btnDelete.Location = new System.Drawing.Point(1105, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(123, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddnew
            // 
            this.btnAddnew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddnew.Image = global::EXON.RegisterManager.Properties.Resources.add16;
            this.btnAddnew.Location = new System.Drawing.Point(718, 11);
            this.btnAddnew.Name = "btnAddnew";
            this.btnAddnew.Size = new System.Drawing.Size(123, 30);
            this.btnAddnew.TabIndex = 1;
            this.btnAddnew.Text = "Thêm mới";
            this.btnAddnew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddnew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddnew.UseVisualStyleBackColor = true;
            this.btnAddnew.Click += new System.EventHandler(this.btnAddnew_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Image = global::EXON.RegisterManager.Properties.Resources.exl16;
            this.btnExportExcel.Location = new System.Drawing.Point(847, 11);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(123, 30);
            this.btnExportExcel.TabIndex = 0;
            this.btnExportExcel.Text = "Xuất ra file Excel";
            this.btnExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // ucQuanLiDangKi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucQuanLiDangKi";
            this.Size = new System.Drawing.Size(1359, 657);
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
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddnew;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.RadioButton rbtnLostImage;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuMain;
        private System.Windows.Forms.ToolStripMenuItem PrintReceiptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem DoneRegisterToolStripMenuItem;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.RadioButton rbtnNotReceipt;
        private System.Windows.Forms.ComboBox cmbKeyName;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem GetfingerToolStripMenuItem;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.RadioButton rbtnNotgetFinger;
        private System.Windows.Forms.RadioButton rbtnDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSTT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContestantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStudentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CBoD;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCMND;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cIsGetFinger;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cIsImage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}
