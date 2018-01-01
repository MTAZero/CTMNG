namespace EXON.RegisterManager.Module
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.bhiStaff = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripStatusContest = new System.Windows.Forms.ToolStripStatusLabel();
            this.pcMain = new EXON.RegisterManager.Core.Controls.BufferPanel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bhiStaff,
            this.stripStatusContest});
            this.statusStrip1.Location = new System.Drawing.Point(0, 613);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1098, 24);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // bhiStaff
            // 
            this.bhiStaff.Name = "bhiStaff";
            this.bhiStaff.Size = new System.Drawing.Size(61, 19);
            this.bhiStaff.Text = "Nhân viên";
            // 
            // stripStatusContest
            // 
            this.stripStatusContest.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.stripStatusContest.ForeColor = System.Drawing.Color.Maroon;
            this.stripStatusContest.Name = "stripStatusContest";
            this.stripStatusContest.Size = new System.Drawing.Size(46, 19);
            this.stripStatusContest.Text = "Kỳ thi";
            // 
            // pcMain
            // 
            this.pcMain.AutoScroll = true;
            this.pcMain.BackColor = System.Drawing.Color.White;
            this.pcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcMain.Location = new System.Drawing.Point(0, 0);
            this.pcMain.Name = "pcMain";
            this.pcMain.Size = new System.Drawing.Size(1098, 613);
            this.pcMain.TabIndex = 6;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 637);
            this.Controls.Add(this.pcMain);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Quản Lý Đăng Ký Thi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel bhiStaff;
        private System.Windows.Forms.ToolStripStatusLabel stripStatusContest;
        private Core.Controls.BufferPanel pcMain;
    }
}