namespace EXON.GenerateTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.Ribbon = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel0 = new System.Windows.Forms.RibbonPanel();
            this.rbiCreateStruct = new System.Windows.Forms.RibbonButton();
            this.rbiUpdateStruct = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.rbiExportStructToDoc = new System.Windows.Forms.RibbonButton();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.rbiCreateOriginalTest = new System.Windows.Forms.RibbonButton();
            this.upNumberOfTest = new System.Windows.Forms.RibbonUpDown();
            this.cbAutoNumberOfTest = new System.Windows.Forms.RibbonCheckBox();
            this.cbOriginalTestNotSame = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.rbiDeleteOriginalTest = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton10 = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonButton11 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton12 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel7 = new System.Windows.Forms.RibbonPanel();
            this.rbiAccepted = new System.Windows.Forms.RibbonButton();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.rbiCreateTest = new System.Windows.Forms.RibbonButton();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton6 = new System.Windows.Forms.RibbonButton();
            this.ribbonUpDown1 = new System.Windows.Forms.RibbonUpDown();
            this.ribbonCheckBox1 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox2 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonTab4 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton13 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton14 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.mtcMain = new MetroFramework.Controls.MetroTabControl();
            this.mtpStructure = new MetroFramework.Controls.MetroTabPage();
            this.mtpOriginalTest = new MetroFramework.Controls.MetroTabPage();
            this.mtpTest = new MetroFramework.Controls.MetroTabPage();
            this.pnButton = new System.Windows.Forms.Panel();
            this.pnMain = new System.Windows.Forms.Panel();
            this.ribbonButton7 = new System.Windows.Forms.RibbonButton();
            this.ribbonTab5 = new System.Windows.Forms.RibbonTab();
            this.mtcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ribbon
            // 
            this.Ribbon.CaptionBarVisible = false;
            this.Ribbon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Ribbon.Location = new System.Drawing.Point(20, 60);
            this.Ribbon.Minimized = false;
            this.Ribbon.Name = "Ribbon";
            // 
            // 
            // 
            this.Ribbon.OrbDropDown.BorderRoundness = 8;
            this.Ribbon.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.Ribbon.OrbDropDown.Name = "";
            this.Ribbon.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.Ribbon.OrbDropDown.TabIndex = 0;
            this.Ribbon.OrbImage = null;
            this.Ribbon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.Ribbon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.Ribbon.Size = new System.Drawing.Size(1130, 133);
            this.Ribbon.TabIndex = 0;
            this.Ribbon.Tabs.Add(this.ribbonTab1);
            this.Ribbon.Tabs.Add(this.ribbonTab2);
            this.Ribbon.Tabs.Add(this.ribbonTab3);
            this.Ribbon.Tabs.Add(this.ribbonTab4);
            this.Ribbon.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.Ribbon.Text = "ribbon1";
            this.Ribbon.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel0);
            this.ribbonTab1.Panels.Add(this.ribbonPanel3);
            this.ribbonTab1.Text = "Cấu Trúc Đề";
            // 
            // ribbonPanel0
            // 
            this.ribbonPanel0.ButtonMoreVisible = false;
            this.ribbonPanel0.Items.Add(this.rbiCreateStruct);
            this.ribbonPanel0.Items.Add(this.rbiUpdateStruct);
            this.ribbonPanel0.Text = "Cấu Trúc Đề";
            // 
            // rbiCreateStruct
            // 
            this.rbiCreateStruct.Image = global::EXON.GenerateTest.Properties.Resources.icon_panel_right_32;
            this.rbiCreateStruct.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbiCreateStruct.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiCreateStruct.SmallImage")));
            this.rbiCreateStruct.Text = "Nhập Cấu Trúc";
            // 
            // rbiUpdateStruct
            // 
            this.rbiUpdateStruct.Image = global::EXON.GenerateTest.Properties.Resources.Edit_32x32;
            this.rbiUpdateStruct.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbiUpdateStruct.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiUpdateStruct.SmallImage")));
            this.rbiUpdateStruct.Text = "Sửa Cấu Trúc";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ButtonMoreVisible = false;
            this.ribbonPanel3.Items.Add(this.rbiExportStructToDoc);
            this.ribbonPanel3.Text = "Báo Cáo";
            // 
            // rbiExportStructToDoc
            // 
            this.rbiExportStructToDoc.Image = global::EXON.GenerateTest.Properties.Resources.ExportToDOC_32x32;
            this.rbiExportStructToDoc.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbiExportStructToDoc.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiExportStructToDoc.SmallImage")));
            this.rbiExportStructToDoc.Text = "Xuất Ra Doc";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Panels.Add(this.ribbonPanel4);
            this.ribbonTab2.Panels.Add(this.ribbonPanel2);
            this.ribbonTab2.Panels.Add(this.ribbonPanel5);
            this.ribbonTab2.Panels.Add(this.ribbonPanel7);
            this.ribbonTab2.Text = "Sinh Đề Gốc";
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.ButtonMoreVisible = false;
            this.ribbonPanel4.Items.Add(this.rbiCreateOriginalTest);
            this.ribbonPanel4.Items.Add(this.upNumberOfTest);
            this.ribbonPanel4.Items.Add(this.cbAutoNumberOfTest);
            this.ribbonPanel4.Items.Add(this.cbOriginalTestNotSame);
            this.ribbonPanel4.Text = "Sinh Đề";
            // 
            // rbiCreateOriginalTest
            // 
            this.rbiCreateOriginalTest.Image = global::EXON.GenerateTest.Properties.Resources.Code_Central;
            this.rbiCreateOriginalTest.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbiCreateOriginalTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiCreateOriginalTest.SmallImage")));
            this.rbiCreateOriginalTest.Text = "Sinh Đề Thi Gốc";
            // 
            // upNumberOfTest
            // 
            this.upNumberOfTest.Text = "Số Đề Thi";
            this.upNumberOfTest.TextBoxText = "";
            this.upNumberOfTest.TextBoxWidth = 50;
            this.upNumberOfTest.TextBoxTextChanged += new System.EventHandler(this.upNumberOfTest_TextBoxTextChanged);
            // 
            // cbAutoNumberOfTest
            // 
            this.cbAutoNumberOfTest.Text = "Tự Động Tính Số Đề";
            this.cbAutoNumberOfTest.CheckBoxCheckChanged += new System.EventHandler(this.cbAutoNumberOfTest_CheckBoxCheckChanged);
            // 
            // cbOriginalTestNotSame
            // 
            this.cbOriginalTestNotSame.Checked = true;
            this.cbOriginalTestNotSame.Text = "Đề Gốc Không Trùng Nhau";
            this.cbOriginalTestNotSame.CheckBoxCheckChanged += new System.EventHandler(this.cbOriginalTestNotSame_CheckBoxCheckChanged);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ButtonMoreVisible = false;
            this.ribbonPanel2.Items.Add(this.rbiDeleteOriginalTest);
            this.ribbonPanel2.Text = "Xóa";
            // 
            // rbiDeleteOriginalTest
            // 
            this.rbiDeleteOriginalTest.Image = global::EXON.GenerateTest.Properties.Resources.Delete_32x32;
            this.rbiDeleteOriginalTest.MinimumSize = new System.Drawing.Size(50, 0);
            this.rbiDeleteOriginalTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiDeleteOriginalTest.SmallImage")));
            this.rbiDeleteOriginalTest.Text = "Xóa Đề Thi";
            this.rbiDeleteOriginalTest.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.ButtonMoreVisible = false;
            this.ribbonPanel5.Items.Add(this.ribbonButton10);
            this.ribbonPanel5.Items.Add(this.ribbonSeparator2);
            this.ribbonPanel5.Items.Add(this.ribbonButton11);
            this.ribbonPanel5.Items.Add(this.ribbonButton12);
            this.ribbonPanel5.Text = "Đề Thi";
            // 
            // ribbonButton10
            // 
            this.ribbonButton10.Image = global::EXON.GenerateTest.Properties.Resources.icon_show_product_img_32;
            this.ribbonButton10.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbonButton10.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton10.SmallImage")));
            this.ribbonButton10.Text = "Xem Đề Thi";
            // 
            // ribbonButton11
            // 
            this.ribbonButton11.Image = global::EXON.GenerateTest.Properties.Resources.ExportToDOC_32x32;
            this.ribbonButton11.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbonButton11.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton11.SmallImage")));
            this.ribbonButton11.Text = "Xuất Ra Doc";
            // 
            // ribbonButton12
            // 
            this.ribbonButton12.Image = global::EXON.GenerateTest.Properties.Resources.ExportToPDF_32x32;
            this.ribbonButton12.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbonButton12.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton12.SmallImage")));
            this.ribbonButton12.Text = "Xuất Ra Pdf";
            // 
            // ribbonPanel7
            // 
            this.ribbonPanel7.ButtonMoreVisible = false;
            this.ribbonPanel7.Items.Add(this.rbiAccepted);
            this.ribbonPanel7.Text = "Phê Duyệt";
            // 
            // rbiAccepted
            // 
            this.rbiAccepted.Image = global::EXON.GenerateTest.Properties.Resources.Task_32x32;
            this.rbiAccepted.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbiAccepted.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiAccepted.SmallImage")));
            this.rbiAccepted.Text = "Phê Duyệt Đề Thi";
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Panels.Add(this.ribbonPanel1);
            this.ribbonTab3.Text = "Sinh Đề Thi";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ButtonMoreVisible = false;
            this.ribbonPanel1.Items.Add(this.rbiCreateTest);
            this.ribbonPanel1.Items.Add(this.ribbonUpDown1);
            this.ribbonPanel1.Items.Add(this.ribbonCheckBox1);
            this.ribbonPanel1.Items.Add(this.ribbonCheckBox2);
            this.ribbonPanel1.Text = "Sinh Đề";
            // 
            // rbiCreateTest
            // 
            this.rbiCreateTest.DropDownItems.Add(this.ribbonButton1);
            this.rbiCreateTest.DropDownItems.Add(this.ribbonButton6);
            this.rbiCreateTest.Image = global::EXON.GenerateTest.Properties.Resources.EditContact_32x32;
            this.rbiCreateTest.MinimumSize = new System.Drawing.Size(70, 0);
            this.rbiCreateTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbiCreateTest.SmallImage")));
            this.rbiCreateTest.Text = "Sinh Đề Thi";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.Image")));
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "ribbonButton1";
            // 
            // ribbonButton6
            // 
            this.ribbonButton6.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.Image")));
            this.ribbonButton6.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.SmallImage")));
            this.ribbonButton6.Text = "ribbonButton6";
            // 
            // ribbonUpDown1
            // 
            this.ribbonUpDown1.FlashIntervall = 100;
            this.ribbonUpDown1.Text = "Số Lượng Đề";
            this.ribbonUpDown1.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.ribbonUpDown1.TextBoxText = "";
            this.ribbonUpDown1.TextBoxWidth = 50;
            this.ribbonUpDown1.Value = "1";
            // 
            // ribbonCheckBox1
            // 
            this.ribbonCheckBox1.Checked = true;
            this.ribbonCheckBox1.Text = "Sinh Đề Từ Đề Thi Gốc";
            // 
            // ribbonCheckBox2
            // 
            this.ribbonCheckBox2.Text = "Sinh Đề  Trực Tiếp Từ NH";
            // 
            // ribbonTab4
            // 
            this.ribbonTab4.Panels.Add(this.ribbonPanel6);
            this.ribbonTab4.Text = "Hỗ Trợ";
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.ButtonMoreVisible = false;
            this.ribbonPanel6.Items.Add(this.ribbonButton13);
            this.ribbonPanel6.Items.Add(this.ribbonButton14);
            this.ribbonPanel6.Text = "Thông Tin";
            // 
            // ribbonButton13
            // 
            this.ribbonButton13.Image = global::EXON.GenerateTest.Properties.Resources.Index_32x32;
            this.ribbonButton13.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbonButton13.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton13.SmallImage")));
            this.ribbonButton13.Text = "Hướng Dẫn";
            // 
            // ribbonButton14
            // 
            this.ribbonButton14.Image = global::EXON.GenerateTest.Properties.Resources.Build_32x32;
            this.ribbonButton14.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton14.SmallImage")));
            this.ribbonButton14.Text = "Thông Tin";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = global::EXON.GenerateTest.Properties.Resources.icon_panel_right_32;
            this.ribbonButton3.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "Nhập Cấu Trúc";
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.Image = global::EXON.GenerateTest.Properties.Resources.Edit_32x32;
            this.ribbonButton4.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Text = "Sửa Cấu Trúc";
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.Image = global::EXON.GenerateTest.Properties.Resources.icon_show_product_img_32;
            this.ribbonButton5.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "Xem Đề Thi";
            // 
            // mtcMain
            // 
            this.mtcMain.Controls.Add(this.mtpStructure);
            this.mtcMain.Controls.Add(this.mtpOriginalTest);
            this.mtcMain.Controls.Add(this.mtpTest);
            this.mtcMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mtcMain.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.mtcMain.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.mtcMain.ItemSize = new System.Drawing.Size(50, 40);
            this.mtcMain.Location = new System.Drawing.Point(20, 611);
            this.mtcMain.Name = "mtcMain";
            this.mtcMain.RightToLeftLayout = true;
            this.mtcMain.SelectedIndex = 0;
            this.mtcMain.Size = new System.Drawing.Size(1130, 48);
            this.mtcMain.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtcMain.TabIndex = 5;
            this.mtcMain.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtcMain.UseSelectable = true;
            this.mtcMain.UseStyleColors = true;
            this.mtcMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.mtcMain_Selected);
            // 
            // mtpStructure
            // 
            this.mtpStructure.HorizontalScrollbarBarColor = true;
            this.mtpStructure.HorizontalScrollbarHighlightOnWheel = true;
            this.mtpStructure.HorizontalScrollbarSize = 10;
            this.mtpStructure.Location = new System.Drawing.Point(4, 44);
            this.mtpStructure.Name = "mtpStructure";
            this.mtpStructure.Size = new System.Drawing.Size(1122, 0);
            this.mtpStructure.TabIndex = 0;
            this.mtpStructure.Text = "Cấu Trúc Đề";
            this.mtpStructure.VerticalScrollbarBarColor = true;
            this.mtpStructure.VerticalScrollbarHighlightOnWheel = false;
            this.mtpStructure.VerticalScrollbarSize = 10;
            // 
            // mtpOriginalTest
            // 
            this.mtpOriginalTest.HorizontalScrollbarBarColor = true;
            this.mtpOriginalTest.HorizontalScrollbarHighlightOnWheel = false;
            this.mtpOriginalTest.HorizontalScrollbarSize = 10;
            this.mtpOriginalTest.Location = new System.Drawing.Point(4, 44);
            this.mtpOriginalTest.Name = "mtpOriginalTest";
            this.mtpOriginalTest.Size = new System.Drawing.Size(1122, 0);
            this.mtpOriginalTest.TabIndex = 2;
            this.mtpOriginalTest.Text = "Sinh Đề Thi Gốc";
            this.mtpOriginalTest.VerticalScrollbarBarColor = true;
            this.mtpOriginalTest.VerticalScrollbarHighlightOnWheel = false;
            this.mtpOriginalTest.VerticalScrollbarSize = 10;
            // 
            // mtpTest
            // 
            this.mtpTest.HorizontalScrollbarBarColor = true;
            this.mtpTest.HorizontalScrollbarHighlightOnWheel = false;
            this.mtpTest.HorizontalScrollbarSize = 10;
            this.mtpTest.Location = new System.Drawing.Point(4, 44);
            this.mtpTest.Name = "mtpTest";
            this.mtpTest.Size = new System.Drawing.Size(1122, 0);
            this.mtpTest.TabIndex = 3;
            this.mtpTest.Text = "Sinh Đề Thi";
            this.mtpTest.VerticalScrollbarBarColor = true;
            this.mtpTest.VerticalScrollbarHighlightOnWheel = false;
            this.mtpTest.VerticalScrollbarSize = 10;
            // 
            // pnButton
            // 
            this.pnButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnButton.Location = new System.Drawing.Point(20, 193);
            this.pnButton.Name = "pnButton";
            this.pnButton.Size = new System.Drawing.Size(200, 418);
            this.pnButton.TabIndex = 6;
            // 
            // pnMain
            // 
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(220, 193);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(930, 418);
            this.pnMain.TabIndex = 7;
            // 
            // ribbonButton7
            // 
            this.ribbonButton7.Image = global::EXON.GenerateTest.Properties.Resources.Code_Central;
            this.ribbonButton7.MinimumSize = new System.Drawing.Size(70, 0);
            this.ribbonButton7.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.SmallImage")));
            this.ribbonButton7.Text = "Sinh Đề Gốc";
            // 
            // ribbonTab5
            // 
            this.ribbonTab5.Text = "ribbonTab5";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 679);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnButton);
            this.Controls.Add(this.mtcMain);
            this.Controls.Add(this.Ribbon);
            this.Name = "frmMain";
            this.Text = "Hệ Thống Sinh Đề Thi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mtcMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton rbiCreateTest;
        private System.Windows.Forms.RibbonUpDown ribbonUpDown1;
        private System.Windows.Forms.RibbonButton rbiDeleteOriginalTest;
        private System.Windows.Forms.RibbonPanel ribbonPanel0;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.RibbonButton rbiCreateStruct;
        private System.Windows.Forms.RibbonButton rbiUpdateStruct;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton ribbonButton10;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.Windows.Forms.RibbonButton ribbonButton11;
        private System.Windows.Forms.RibbonButton ribbonButton12;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonButton ribbonButton13;
        private System.Windows.Forms.RibbonButton ribbonButton14;
        private System.Windows.Forms.RibbonCheckBox ribbonCheckBox1;
        private System.Windows.Forms.RibbonCheckBox ribbonCheckBox2;
        public System.Windows.Forms.Ribbon Ribbon;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton ribbonButton6;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonTab ribbonTab4;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton rbiExportStructToDoc;
        private MetroFramework.Controls.MetroTabControl mtcMain;
        private MetroFramework.Controls.MetroTabPage mtpStructure;
        private MetroFramework.Controls.MetroTabPage mtpOriginalTest;
        private MetroFramework.Controls.MetroTabPage mtpTest;
        private System.Windows.Forms.Panel pnButton;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton rbiCreateOriginalTest;
        private System.Windows.Forms.RibbonButton ribbonButton7;
        private System.Windows.Forms.RibbonPanel ribbonPanel7;
        private System.Windows.Forms.RibbonButton rbiAccepted;
        private System.Windows.Forms.RibbonUpDown upNumberOfTest;
        private System.Windows.Forms.RibbonCheckBox cbAutoNumberOfTest;
        private System.Windows.Forms.RibbonCheckBox cbOriginalTestNotSame;
        private System.Windows.Forms.RibbonTab ribbonTab5;
    }
}