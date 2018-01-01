namespace ContestManagementVer2.Main
{
    partial class FrmXacNhanPheDuyetKeHoach
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoKeHoach = new System.Windows.Forms.TextBox();
            this.btnHuy = new MetroFramework.Controls.MetroButton();
            this.btnPheDuyet = new MetroFramework.Controls.MetroButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCanBoPheDuyet = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbxCanBoPheDuyet);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.btnPheDuyet);
            this.panel1.Controls.Add(this.txtSoKeHoach);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 190);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số kế hoạch : ";
            // 
            // txtSoKeHoach
            // 
            this.txtSoKeHoach.Location = new System.Drawing.Point(158, 30);
            this.txtSoKeHoach.Name = "txtSoKeHoach";
            this.txtSoKeHoach.Size = new System.Drawing.Size(216, 24);
            this.txtSoKeHoach.TabIndex = 1;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.White;
            this.btnHuy.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnHuy.Location = new System.Drawing.Point(308, 135);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(136, 36);
            this.btnHuy.TabIndex = 21;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnHuy.UseCustomBackColor = true;
            this.btnHuy.UseCustomForeColor = true;
            this.btnHuy.UseSelectable = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnPheDuyet
            // 
            this.btnPheDuyet.BackColor = System.Drawing.Color.White;
            this.btnPheDuyet.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnPheDuyet.ForeColor = System.Drawing.Color.Green;
            this.btnPheDuyet.Location = new System.Drawing.Point(167, 135);
            this.btnPheDuyet.Name = "btnPheDuyet";
            this.btnPheDuyet.Size = new System.Drawing.Size(135, 36);
            this.btnPheDuyet.TabIndex = 20;
            this.btnPheDuyet.Text = "Phê duyệt";
            this.btnPheDuyet.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnPheDuyet.UseCustomBackColor = true;
            this.btnPheDuyet.UseCustomForeColor = true;
            this.btnPheDuyet.UseSelectable = true;
            this.btnPheDuyet.Click += new System.EventHandler(this.btnPheDuyet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Cán bộ xác nhận :";
            // 
            // cbxCanBoPheDuyet
            // 
            this.cbxCanBoPheDuyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCanBoPheDuyet.FormattingEnabled = true;
            this.cbxCanBoPheDuyet.Location = new System.Drawing.Point(158, 83);
            this.cbxCanBoPheDuyet.Name = "cbxCanBoPheDuyet";
            this.cbxCanBoPheDuyet.Size = new System.Drawing.Size(286, 25);
            this.cbxCanBoPheDuyet.TabIndex = 23;
            // 
            // FrmXacNhanPheDuyetKeHoach
            // 
            this.ClientSize = new System.Drawing.Size(521, 270);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FrmXacNhanPheDuyetKeHoach";
            this.Resizable = false;
            this.Text = "PHÊ DUYỆT KẾ HOẠCH";
            this.Load += new System.EventHandler(this.FrmXacNhanPheDuyetKeHoach_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoKeHoach;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroButton btnHuy;
        private MetroFramework.Controls.MetroButton btnPheDuyet;
        private System.Windows.Forms.ComboBox cbxCanBoPheDuyet;
    }
}