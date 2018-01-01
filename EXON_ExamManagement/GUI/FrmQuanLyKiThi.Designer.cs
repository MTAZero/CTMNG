namespace EXON_ExamManagement.GUI
{
    partial class FrmQuanLyKiThi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTrangThaiCuocThi = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panelMain);
            this.panel1.Controls.Add(this.panelTrangThaiCuocThi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1310, 660);
            this.panel1.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 128);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1308, 530);
            this.panelMain.TabIndex = 1;
            // 
            // panelTrangThaiCuocThi
            // 
            this.panelTrangThaiCuocThi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTrangThaiCuocThi.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTrangThaiCuocThi.Location = new System.Drawing.Point(0, 0);
            this.panelTrangThaiCuocThi.Name = "panelTrangThaiCuocThi";
            this.panelTrangThaiCuocThi.Size = new System.Drawing.Size(1308, 128);
            this.panelTrangThaiCuocThi.TabIndex = 0;
            // 
            // FrmQuanLyKiThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1350, 740);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmQuanLyKiThi";
            this.Text = "QUẢN LÝ KÌ THI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelTrangThaiCuocThi;
        private System.Windows.Forms.Panel panelMain;
    }
}