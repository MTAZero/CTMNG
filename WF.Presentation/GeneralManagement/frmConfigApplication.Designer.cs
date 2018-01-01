namespace GeneralManagement
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.pnDB = new System.Windows.Forms.Panel();
            this.lbIPDB = new System.Windows.Forms.Label();
            this.pnDB.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(129, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "Kết nối";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.Location = new System.Drawing.Point(170, 13);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(123, 26);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "169.254.227.0";
            // 
            // pnDB
            // 
            this.pnDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnDB.Controls.Add(this.lbIPDB);
            this.pnDB.Controls.Add(this.button1);
            this.pnDB.Controls.Add(this.txtIP);
            this.pnDB.Location = new System.Drawing.Point(43, 12);
            this.pnDB.Name = "pnDB";
            this.pnDB.Size = new System.Drawing.Size(372, 124);
            this.pnDB.TabIndex = 11;
            // 
            // lbIPDB
            // 
            this.lbIPDB.AutoSize = true;
            this.lbIPDB.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbIPDB.Location = new System.Drawing.Point(3, 18);
            this.lbIPDB.Name = "lbIPDB";
            this.lbIPDB.Size = new System.Drawing.Size(142, 21);
            this.lbIPDB.TabIndex = 10;
            this.lbIPDB.Text = "Địa chỉ máy chủ: ";
            // 
            // frmConfigApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(446, 154);
            this.Controls.Add(this.pnDB);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfigApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình máy";
            this.Load += new System.EventHandler(this.frmConfigApplication_Load);
            this.pnDB.ResumeLayout(false);
            this.pnDB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Panel pnDB;
        private System.Windows.Forms.Label lbIPDB;
    }
}