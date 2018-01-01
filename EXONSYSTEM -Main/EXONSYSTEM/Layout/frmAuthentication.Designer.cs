namespace EXONSYSTEM.Layout
{
    partial class frmAuthentication
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
            this.pAuthen = new MetroFramework.Controls.MetroPanel();
            this.mrbtnStudentCode = new MetroFramework.Controls.MetroRadioButton();
            this.mrbtnIdentityCardName = new MetroFramework.Controls.MetroRadioButton();
            this.mrbtnContestantCode = new MetroFramework.Controls.MetroRadioButton();
            this.btnSubmit = new MetroFramework.Controls.MetroButton();
            this.txtUsername = new MetroFramework.Controls.MetroTextBox();
            this.pnContestInfo = new System.Windows.Forms.Panel();
            this.lbShiftInfo = new System.Windows.Forms.Label();
            this.lbSubject = new System.Windows.Forms.Label();
            this.lbLine = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pAuthen.SuspendLayout();
            this.pnContestInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pAuthen
            // 
            this.pAuthen.Controls.Add(this.mrbtnStudentCode);
            this.pAuthen.Controls.Add(this.mrbtnIdentityCardName);
            this.pAuthen.Controls.Add(this.mrbtnContestantCode);
            this.pAuthen.Controls.Add(this.btnSubmit);
            this.pAuthen.Controls.Add(this.txtUsername);
            this.pAuthen.HorizontalScrollbarBarColor = true;
            this.pAuthen.HorizontalScrollbarHighlightOnWheel = false;
            this.pAuthen.HorizontalScrollbarSize = 9;
            this.pAuthen.Location = new System.Drawing.Point(30, 194);
            this.pAuthen.Name = "pAuthen";
            this.pAuthen.Size = new System.Drawing.Size(364, 135);
            this.pAuthen.TabIndex = 1;
            this.pAuthen.VerticalScrollbarBarColor = true;
            this.pAuthen.VerticalScrollbarHighlightOnWheel = false;
            this.pAuthen.VerticalScrollbarSize = 10;
            // 
            // mrbtnStudentCode
            // 
            this.mrbtnStudentCode.AutoSize = true;
            this.mrbtnStudentCode.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.mrbtnStudentCode.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.mrbtnStudentCode.Location = new System.Drawing.Point(204, 16);
            this.mrbtnStudentCode.Name = "mrbtnStudentCode";
            this.mrbtnStudentCode.Size = new System.Drawing.Size(157, 19);
            this.mrbtnStudentCode.TabIndex = 3;
            this.mrbtnStudentCode.Text = "metroRadioButton1";
            this.mrbtnStudentCode.UseCustomBackColor = true;
            this.mrbtnStudentCode.UseCustomForeColor = true;
            this.mrbtnStudentCode.UseSelectable = true;
            this.mrbtnStudentCode.CheckedChanged += new System.EventHandler(this.MetroRadioButton_CheckedChanged);
            // 
            // mrbtnIdentityCardName
            // 
            this.mrbtnIdentityCardName.AutoSize = true;
            this.mrbtnIdentityCardName.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.mrbtnIdentityCardName.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.mrbtnIdentityCardName.Location = new System.Drawing.Point(73, 16);
            this.mrbtnIdentityCardName.Name = "mrbtnIdentityCardName";
            this.mrbtnIdentityCardName.Size = new System.Drawing.Size(157, 19);
            this.mrbtnIdentityCardName.TabIndex = 2;
            this.mrbtnIdentityCardName.Text = "metroRadioButton1";
            this.mrbtnIdentityCardName.UseCustomBackColor = true;
            this.mrbtnIdentityCardName.UseCustomForeColor = true;
            this.mrbtnIdentityCardName.UseSelectable = true;
            this.mrbtnIdentityCardName.CheckedChanged += new System.EventHandler(this.MetroRadioButton_CheckedChanged);
            // 
            // mrbtnContestantCode
            // 
            this.mrbtnContestantCode.AutoSize = true;
            this.mrbtnContestantCode.Checked = true;
            this.mrbtnContestantCode.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.mrbtnContestantCode.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.mrbtnContestantCode.Location = new System.Drawing.Point(7, 16);
            this.mrbtnContestantCode.Name = "mrbtnContestantCode";
            this.mrbtnContestantCode.Size = new System.Drawing.Size(157, 19);
            this.mrbtnContestantCode.TabIndex = 1;
            this.mrbtnContestantCode.TabStop = true;
            this.mrbtnContestantCode.Text = "metroRadioButton1";
            this.mrbtnContestantCode.UseCustomBackColor = true;
            this.mrbtnContestantCode.UseCustomForeColor = true;
            this.mrbtnContestantCode.UseSelectable = true;
            this.mrbtnContestantCode.CheckedChanged += new System.EventHandler(this.MetroRadioButton_CheckedChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.DimGray;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.DisplayFocus = true;
            this.btnSubmit.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnSubmit.Highlight = true;
            this.btnSubmit.Location = new System.Drawing.Point(15, 87);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(317, 37);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "ĐĂNG NHẬP ➜";
            this.btnSubmit.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnSubmit.UseCustomBackColor = true;
            this.btnSubmit.UseCustomForeColor = true;
            this.btnSubmit.UseSelectable = true;
            this.btnSubmit.UseStyleColors = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtUsername
            // 
            // 
            // 
            // 
            this.txtUsername.CustomButton.Image = null;
            this.txtUsername.CustomButton.Location = new System.Drawing.Point(291, 1);
            this.txtUsername.CustomButton.Name = "";
            this.txtUsername.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtUsername.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUsername.CustomButton.TabIndex = 1;
            this.txtUsername.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUsername.CustomButton.UseSelectable = true;
            this.txtUsername.CustomButton.Visible = false;
            this.txtUsername.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtUsername.Lines = new string[] {
        "KQH"};
            this.txtUsername.Location = new System.Drawing.Point(15, 52);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.ShortcutsEnabled = true;
            this.txtUsername.Size = new System.Drawing.Size(317, 27);
            this.txtUsername.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUsername.TabIndex = 4;
            this.txtUsername.Text = "KQH";
            this.txtUsername.UseSelectable = true;
            this.txtUsername.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUsername.WaterMarkFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Click += new System.EventHandler(this.txtUsername_Click);
            // 
            // pnContestInfo
            // 
            this.pnContestInfo.Controls.Add(this.lbShiftInfo);
            this.pnContestInfo.Controls.Add(this.lbSubject);
            this.pnContestInfo.Location = new System.Drawing.Point(55, 60);
            this.pnContestInfo.Name = "pnContestInfo";
            this.pnContestInfo.Size = new System.Drawing.Size(364, 85);
            this.pnContestInfo.TabIndex = 2;
            // 
            // lbShiftInfo
            // 
            this.lbShiftInfo.AutoSize = true;
            this.lbShiftInfo.Location = new System.Drawing.Point(132, 42);
            this.lbShiftInfo.Name = "lbShiftInfo";
            this.lbShiftInfo.Size = new System.Drawing.Size(59, 22);
            this.lbShiftInfo.TabIndex = 0;
            this.lbShiftInfo.Text = "label1";
            // 
            // lbSubject
            // 
            this.lbSubject.AutoSize = true;
            this.lbSubject.Location = new System.Drawing.Point(132, 10);
            this.lbSubject.Name = "lbSubject";
            this.lbSubject.Size = new System.Drawing.Size(59, 22);
            this.lbSubject.TabIndex = 0;
            this.lbSubject.Text = "label1";
            // 
            // lbLine
            // 
            this.lbLine.Location = new System.Drawing.Point(90, 162);
            this.lbLine.Name = "lbLine";
            this.lbLine.Size = new System.Drawing.Size(35, 13);
            this.lbLine.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmAuthentication
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(481, 385);
            this.ControlBox = false;
            this.Controls.Add(this.lbLine);
            this.Controls.Add(this.pnContestInfo);
            this.Controls.Add(this.pAuthen);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "frmAuthentication";
            this.Padding = new System.Windows.Forms.Padding(37, 102, 37, 34);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.Text = "HỆ THỐNG THI TRỰC TUYẾN";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.TransparencyKey = System.Drawing.Color.DeepSkyBlue;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAuthentication_FormClosing);
            this.Load += new System.EventHandler(this.frmAuthentication_Load);
            this.pAuthen.ResumeLayout(false);
            this.pAuthen.PerformLayout();
            this.pnContestInfo.ResumeLayout(false);
            this.pnContestInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pAuthen;
        private MetroFramework.Controls.MetroButton btnSubmit;
        private MetroFramework.Controls.MetroTextBox txtUsername;
        private MetroFramework.Controls.MetroRadioButton mrbtnContestantCode;
        private MetroFramework.Controls.MetroRadioButton mrbtnIdentityCardName;
        private MetroFramework.Controls.MetroRadioButton mrbtnStudentCode;
        private System.Windows.Forms.Panel pnContestInfo;
        private System.Windows.Forms.Label lbShiftInfo;
        private System.Windows.Forms.Label lbSubject;
        private System.Windows.Forms.Label lbLine;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}