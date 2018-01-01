namespace GeneralManagement.Supervisors
{
    partial class ucComputer
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
            this.cBCheckFP = new System.Windows.Forms.CheckBox();
            this.lbContestantName = new System.Windows.Forms.Label();
            this.lbViolation = new System.Windows.Forms.Label();
            this.lbComputername = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ptbImage = new System.Windows.Forms.PictureBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbContestantCode = new System.Windows.Forms.Label();
            this.lblCountViolation = new System.Windows.Forms.Label();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).BeginInit();
            this.metroContextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBCheckFP
            // 
            this.cBCheckFP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBCheckFP.AutoSize = true;
            this.cBCheckFP.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBCheckFP.Location = new System.Drawing.Point(8, 153);
            this.cBCheckFP.Name = "cBCheckFP";
            this.cBCheckFP.Size = new System.Drawing.Size(73, 16);
            this.cBCheckFP.TabIndex = 2;
            this.cBCheckFP.Text = "Điểm Danh";
            this.cBCheckFP.UseVisualStyleBackColor = true;
            this.cBCheckFP.Click += new System.EventHandler(this.cBCheckFP_Click);
            // 
            // lbContestantName
            // 
            this.lbContestantName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbContestantName.AutoSize = true;
            this.lbContestantName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContestantName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbContestantName.Location = new System.Drawing.Point(5, 121);
            this.lbContestantName.Name = "lbContestantName";
            this.lbContestantName.Size = new System.Drawing.Size(79, 15);
            this.lbContestantName.TabIndex = 5;
            this.lbContestantName.Text = "Tên Thí Sinh";
            // 
            // lbViolation
            // 
            this.lbViolation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbViolation.AutoSize = true;
            this.lbViolation.ForeColor = System.Drawing.Color.Maroon;
            this.lbViolation.Location = new System.Drawing.Point(7, 137);
            this.lbViolation.Name = "lbViolation";
            this.lbViolation.Size = new System.Drawing.Size(48, 13);
            this.lbViolation.TabIndex = 5;
            this.lbViolation.Text = "Vi phạm:";
            // 
            // lbComputername
            // 
            this.lbComputername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbComputername.AutoSize = true;
            this.lbComputername.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbComputername.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbComputername.Location = new System.Drawing.Point(5, 8);
            this.lbComputername.Name = "lbComputername";
            this.lbComputername.Size = new System.Drawing.Size(54, 15);
            this.lbComputername.TabIndex = 5;
            this.lbComputername.Text = "Tên Máy";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::GeneralManagement.Properties.Resources.keybooo;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(10, 81);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(89, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // ptbImage
            // 
            this.ptbImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbImage.Image = global::GeneralManagement.Properties.Resources.monitor_khongcothisinh;
            this.ptbImage.Location = new System.Drawing.Point(10, 26);
            this.ptbImage.Name = "ptbImage";
            this.ptbImage.Size = new System.Drawing.Size(89, 54);
            this.ptbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbImage.TabIndex = 0;
            this.ptbImage.TabStop = false;
            this.ptbImage.Click += new System.EventHandler(this.ptbImage_Click);
            this.ptbImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptbImage_MouseClick);
            // 
            // lbStatus
            // 
            this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(5, 169);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(74, 17);
            this.lbStatus.TabIndex = 6;
            this.lbStatus.Text = "Trạng thái";
            // 
            // lbContestantCode
            // 
            this.lbContestantCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbContestantCode.AutoSize = true;
            this.lbContestantCode.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContestantCode.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbContestantCode.Location = new System.Drawing.Point(6, 106);
            this.lbContestantCode.Name = "lbContestantCode";
            this.lbContestantCode.Size = new System.Drawing.Size(33, 15);
            this.lbContestantCode.TabIndex = 5;
            this.lbContestantCode.Text = "SBD";
            // 
            // lblCountViolation
            // 
            this.lblCountViolation.AutoSize = true;
            this.lblCountViolation.Location = new System.Drawing.Point(55, 136);
            this.lblCountViolation.Name = "lblCountViolation";
            this.lblCountViolation.Size = new System.Drawing.Size(0, 13);
            this.lblCountViolation.TabIndex = 7;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maintenanceToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(157, 76);
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.maintenanceToolStripMenuItem.Text = "&Phát đề";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.toolsToolStripMenuItem.Text = "&Bắt đầu làm bài";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.exitToolStripMenuItem.Text = "&Chuyển ca thi ";
            // 
            // ucComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblCountViolation);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbViolation);
            this.Controls.Add(this.lbComputername);
            this.Controls.Add(this.lbContestantCode);
            this.Controls.Add(this.lbContestantName);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cBCheckFP);
            this.Controls.Add(this.ptbImage);
            this.Name = "ucComputer";
            this.Size = new System.Drawing.Size(107, 193);
            this.Load += new System.EventHandler(this.ucComputer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).EndInit();
            this.metroContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbImage;
        private System.Windows.Forms.CheckBox cBCheckFP;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbContestantName;
        private System.Windows.Forms.Label lbViolation;
        private System.Windows.Forms.Label lbComputername;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbContestantCode;
        private System.Windows.Forms.Label lblCountViolation;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}
