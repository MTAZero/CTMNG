namespace EXONSYSTEM.Layout
{
    partial class frmConfigApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigApplication));
            this.pnContent = new System.Windows.Forms.Panel();
            this.pnDB = new System.Windows.Forms.Panel();
            this.lbIPDB = new System.Windows.Forms.Label();
            this.mtxbIPDatabase = new MetroFramework.Controls.MetroTextBox();
            this.pnSupervisor = new System.Windows.Forms.Panel();
            this.lbIPS = new System.Windows.Forms.Label();
            this.mtxbIPSupervisor = new MetroFramework.Controls.MetroTextBox();
            this.lbLine2 = new System.Windows.Forms.Label();
            this.lbDB = new System.Windows.Forms.Label();
            this.lbLine1 = new System.Windows.Forms.Label();
            this.lbSupervisor = new System.Windows.Forms.Label();
            this.btnSubmit = new MetroFramework.Controls.MetroButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnContent.SuspendLayout();
            this.pnDB.SuspendLayout();
            this.pnSupervisor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnContent
            // 
            this.pnContent.Controls.Add(this.pnDB);
            this.pnContent.Controls.Add(this.pnSupervisor);
            this.pnContent.Controls.Add(this.lbLine2);
            this.pnContent.Controls.Add(this.lbDB);
            this.pnContent.Controls.Add(this.lbLine1);
            this.pnContent.Controls.Add(this.lbSupervisor);
            this.pnContent.Location = new System.Drawing.Point(23, 64);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(405, 260);
            this.pnContent.TabIndex = 0;
            // 
            // pnDB
            // 
            this.pnDB.Controls.Add(this.lbIPDB);
            this.pnDB.Controls.Add(this.mtxbIPDatabase);
            this.pnDB.Location = new System.Drawing.Point(2, 194);
            this.pnDB.Name = "pnDB";
            this.pnDB.Size = new System.Drawing.Size(400, 55);
            this.pnDB.TabIndex = 2;
            // 
            // lbIPDB
            // 
            this.lbIPDB.AutoSize = true;
            this.lbIPDB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbIPDB.Location = new System.Drawing.Point(33, 13);
            this.lbIPDB.Name = "lbIPDB";
            this.lbIPDB.Size = new System.Drawing.Size(27, 21);
            this.lbIPDB.TabIndex = 1;
            this.lbIPDB.Text = "IP";
            // 
            // mtxbIPDatabase
            // 
            // 
            // 
            // 
            this.mtxbIPDatabase.CustomButton.Image = null;
            this.mtxbIPDatabase.CustomButton.Location = new System.Drawing.Point(220, 2);
            this.mtxbIPDatabase.CustomButton.Name = "";
            this.mtxbIPDatabase.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.mtxbIPDatabase.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxbIPDatabase.CustomButton.TabIndex = 1;
            this.mtxbIPDatabase.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxbIPDatabase.CustomButton.UseSelectable = true;
            this.mtxbIPDatabase.CustomButton.Visible = false;
            this.mtxbIPDatabase.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxbIPDatabase.Lines = new string[] {
        "169.254.227.0"};
            this.mtxbIPDatabase.Location = new System.Drawing.Point(132, 7);
            this.mtxbIPDatabase.MaxLength = 32767;
            this.mtxbIPDatabase.Name = "mtxbIPDatabase";
            this.mtxbIPDatabase.PasswordChar = '\0';
            this.mtxbIPDatabase.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxbIPDatabase.SelectedText = "";
            this.mtxbIPDatabase.SelectionLength = 0;
            this.mtxbIPDatabase.SelectionStart = 0;
            this.mtxbIPDatabase.ShortcutsEnabled = true;
            this.mtxbIPDatabase.Size = new System.Drawing.Size(250, 32);
            this.mtxbIPDatabase.TabIndex = 1;
            this.mtxbIPDatabase.Text = "169.254.227.0";
            this.mtxbIPDatabase.UseSelectable = true;
            this.mtxbIPDatabase.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxbIPDatabase.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mtxbIPDatabase.TextChanged += new System.EventHandler(this.mtxb_TextChanged);
            this.mtxbIPDatabase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxb_KeyPress);
            this.mtxbIPDatabase.Validating += new System.ComponentModel.CancelEventHandler(this.mtxb_Validating);
            // 
            // pnSupervisor
            // 
            this.pnSupervisor.Controls.Add(this.lbIPS);
            this.pnSupervisor.Controls.Add(this.mtxbIPSupervisor);
            this.pnSupervisor.Location = new System.Drawing.Point(3, 62);
            this.pnSupervisor.Name = "pnSupervisor";
            this.pnSupervisor.Size = new System.Drawing.Size(400, 62);
            this.pnSupervisor.TabIndex = 1;
            // 
            // lbIPS
            // 
            this.lbIPS.AutoSize = true;
            this.lbIPS.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbIPS.Location = new System.Drawing.Point(33, 18);
            this.lbIPS.Name = "lbIPS";
            this.lbIPS.Size = new System.Drawing.Size(27, 21);
            this.lbIPS.TabIndex = 1;
            this.lbIPS.Text = "IP";
            // 
            // mtxbIPSupervisor
            // 
            // 
            // 
            // 
            this.mtxbIPSupervisor.CustomButton.Image = null;
            this.mtxbIPSupervisor.CustomButton.Location = new System.Drawing.Point(220, 2);
            this.mtxbIPSupervisor.CustomButton.Name = "";
            this.mtxbIPSupervisor.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.mtxbIPSupervisor.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxbIPSupervisor.CustomButton.TabIndex = 1;
            this.mtxbIPSupervisor.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxbIPSupervisor.CustomButton.UseSelectable = true;
            this.mtxbIPSupervisor.CustomButton.Visible = false;
            this.mtxbIPSupervisor.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.mtxbIPSupervisor.Lines = new string[] {
        "169.254.225.46"};
            this.mtxbIPSupervisor.Location = new System.Drawing.Point(132, 12);
            this.mtxbIPSupervisor.MaxLength = 32767;
            this.mtxbIPSupervisor.Name = "mtxbIPSupervisor";
            this.mtxbIPSupervisor.PasswordChar = '\0';
            this.mtxbIPSupervisor.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxbIPSupervisor.SelectedText = "";
            this.mtxbIPSupervisor.SelectionLength = 0;
            this.mtxbIPSupervisor.SelectionStart = 0;
            this.mtxbIPSupervisor.ShortcutsEnabled = false;
            this.mtxbIPSupervisor.Size = new System.Drawing.Size(250, 32);
            this.mtxbIPSupervisor.TabIndex = 1;
            this.mtxbIPSupervisor.Text = "169.254.225.46";
            this.mtxbIPSupervisor.UseSelectable = true;
            this.mtxbIPSupervisor.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxbIPSupervisor.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.mtxbIPSupervisor.TextChanged += new System.EventHandler(this.mtxb_TextChanged);
            this.mtxbIPSupervisor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxb_KeyPress);
            this.mtxbIPSupervisor.Validating += new System.ComponentModel.CancelEventHandler(this.mtxb_Validating);
            // 
            // lbLine2
            // 
            this.lbLine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbLine2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbLine2.Location = new System.Drawing.Point(-1, 190);
            this.lbLine2.Name = "lbLine2";
            this.lbLine2.Size = new System.Drawing.Size(405, 1);
            this.lbLine2.TabIndex = 0;
            // 
            // lbDB
            // 
            this.lbDB.AutoSize = true;
            this.lbDB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbDB.Location = new System.Drawing.Point(158, 155);
            this.lbDB.Name = "lbDB";
            this.lbDB.Size = new System.Drawing.Size(127, 24);
            this.lbDB.TabIndex = 0;
            this.lbDB.Text = "Cơ sở dữ liệu";
            this.lbDB.Click += new System.EventHandler(this.lbDB_Click);
            // 
            // lbLine1
            // 
            this.lbLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbLine1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbLine1.Location = new System.Drawing.Point(-1, 40);
            this.lbLine1.Name = "lbLine1";
            this.lbLine1.Size = new System.Drawing.Size(405, 1);
            this.lbLine1.TabIndex = 0;
            // 
            // lbSupervisor
            // 
            this.lbSupervisor.AutoSize = true;
            this.lbSupervisor.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbSupervisor.Location = new System.Drawing.Point(158, 6);
            this.lbSupervisor.Name = "lbSupervisor";
            this.lbSupervisor.Size = new System.Drawing.Size(127, 24);
            this.lbSupervisor.TabIndex = 0;
            this.lbSupervisor.Text = "Máy giám thị";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.DimGray;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.DisplayFocus = true;
            this.btnSubmit.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnSubmit.Highlight = true;
            this.btnSubmit.Location = new System.Drawing.Point(91, 330);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(269, 37);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "XÁC NHẬN";
            this.btnSubmit.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnSubmit.UseCustomBackColor = true;
            this.btnSubmit.UseCustomForeColor = true;
            this.btnSubmit.UseSelectable = true;
            this.btnSubmit.UseStyleColors = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmConfigApplication
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 378);
            this.ControlBox = false;
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.pnContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "frmConfigApplication";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "CẤU HÌNH";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.frmConfigApplication_Load);
            this.pnContent.ResumeLayout(false);
            this.pnContent.PerformLayout();
            this.pnDB.ResumeLayout(false);
            this.pnDB.PerformLayout();
            this.pnSupervisor.ResumeLayout(false);
            this.pnSupervisor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnContent;
        private MetroFramework.Controls.MetroTextBox mtxbIPSupervisor;
        private System.Windows.Forms.Label lbIPS;
        private System.Windows.Forms.Label lbLine1;
        private System.Windows.Forms.Label lbSupervisor;
        private System.Windows.Forms.Label lbIPDB;
        private System.Windows.Forms.Label lbLine2;
        private System.Windows.Forms.Label lbDB;
        private MetroFramework.Controls.MetroButton btnSubmit;
        private System.Windows.Forms.Panel pnSupervisor;
        private System.Windows.Forms.Panel pnDB;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private MetroFramework.Controls.MetroTextBox mtxbIPDatabase;
    }
}