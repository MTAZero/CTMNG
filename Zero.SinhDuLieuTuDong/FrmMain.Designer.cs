namespace Zero.SinhDuLieuTuDong
{
    partial class FrmMain
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSoThiSinh = new System.Windows.Forms.NumericUpDown();
            this.txtTienToTenThiSinh = new System.Windows.Forms.TextBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnSinhDuLieu = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSoPhongThi = new System.Windows.Forms.Label();
            this.txtSoMonThi = new System.Windows.Forms.Label();
            this.txtSoCaThi = new System.Windows.Forms.Label();
            this.txtTenKiThi = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoMonThiSinh = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoThiSinh)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoMonThiSinh)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1022, 265);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSoMonThiSinh);
            this.groupBox2.Controls.Add(this.txtSoThiSinh);
            this.groupBox2.Controls.Add(this.txtTienToTenThiSinh);
            this.groupBox2.Controls.Add(this.btnHuy);
            this.groupBox2.Controls.Add(this.btnSinhDuLieu);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(402, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(607, 243);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lựa chọn sinh dữ liệu";
            // 
            // txtSoThiSinh
            // 
            this.txtSoThiSinh.Location = new System.Drawing.Point(251, 48);
            this.txtSoThiSinh.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtSoThiSinh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSoThiSinh.Name = "txtSoThiSinh";
            this.txtSoThiSinh.Size = new System.Drawing.Size(98, 24);
            this.txtSoThiSinh.TabIndex = 11;
            this.txtSoThiSinh.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtTienToTenThiSinh
            // 
            this.txtTienToTenThiSinh.Location = new System.Drawing.Point(251, 147);
            this.txtTienToTenThiSinh.Name = "txtTienToTenThiSinh";
            this.txtTienToTenThiSinh.Size = new System.Drawing.Size(306, 24);
            this.txtTienToTenThiSinh.TabIndex = 10;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHuy.Location = new System.Drawing.Point(406, 192);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(151, 32);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnSinhDuLieu
            // 
            this.btnSinhDuLieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSinhDuLieu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSinhDuLieu.Location = new System.Drawing.Point(251, 192);
            this.btnSinhDuLieu.Name = "btnSinhDuLieu";
            this.btnSinhDuLieu.Size = new System.Drawing.Size(149, 32);
            this.btnSinhDuLieu.TabIndex = 8;
            this.btnSinhDuLieu.Text = "Sinh dữ liệu";
            this.btnSinhDuLieu.UseVisualStyleBackColor = false;
            this.btnSinhDuLieu.Click += new System.EventHandler(this.btnSinhDuLieu_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tiền tố tên thí sinh :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Số môn thi của mỗi thí sinh :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Số lượng thí sinh :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSoPhongThi);
            this.groupBox1.Controls.Add(this.txtSoMonThi);
            this.groupBox1.Controls.Add(this.txtSoCaThi);
            this.groupBox1.Controls.Add(this.txtTenKiThi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 243);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin kì thi ";
            // 
            // txtSoPhongThi
            // 
            this.txtSoPhongThi.AutoSize = true;
            this.txtSoPhongThi.Location = new System.Drawing.Point(143, 200);
            this.txtSoPhongThi.Name = "txtSoPhongThi";
            this.txtSoPhongThi.Size = new System.Drawing.Size(22, 17);
            this.txtSoPhongThi.TabIndex = 11;
            this.txtSoPhongThi.Text = "20";
            // 
            // txtSoMonThi
            // 
            this.txtSoMonThi.AutoSize = true;
            this.txtSoMonThi.Location = new System.Drawing.Point(143, 150);
            this.txtSoMonThi.Name = "txtSoMonThi";
            this.txtSoMonThi.Size = new System.Drawing.Size(15, 17);
            this.txtSoMonThi.TabIndex = 10;
            this.txtSoMonThi.Text = "4";
            // 
            // txtSoCaThi
            // 
            this.txtSoCaThi.AutoSize = true;
            this.txtSoCaThi.Location = new System.Drawing.Point(143, 100);
            this.txtSoCaThi.Name = "txtSoCaThi";
            this.txtSoCaThi.Size = new System.Drawing.Size(22, 17);
            this.txtSoCaThi.TabIndex = 9;
            this.txtSoCaThi.Text = "15";
            // 
            // txtTenKiThi
            // 
            this.txtTenKiThi.AutoSize = true;
            this.txtTenKiThi.Location = new System.Drawing.Point(143, 50);
            this.txtTenKiThi.Name = "txtTenKiThi";
            this.txtTenKiThi.Size = new System.Drawing.Size(173, 17);
            this.txtTenKiThi.TabIndex = 8;
            this.txtTenKiThi.Text = "Tốt nghiệp THPT năm 2018";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số phòng thi :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Số môn thi :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Số ca thi :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên kì thi : ";
            // 
            // txtSoMonThiSinh
            // 
            this.txtSoMonThiSinh.Location = new System.Drawing.Point(251, 98);
            this.txtSoMonThiSinh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSoMonThiSinh.Name = "txtSoMonThiSinh";
            this.txtSoMonThiSinh.Size = new System.Drawing.Size(98, 24);
            this.txtSoMonThiSinh.TabIndex = 12;
            this.txtSoMonThiSinh.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 265);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sinh dữ liệu ngẫu nhiên";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoThiSinh)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoMonThiSinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtSoPhongThi;
        private System.Windows.Forms.Label txtSoMonThi;
        private System.Windows.Forms.Label txtSoCaThi;
        private System.Windows.Forms.Label txtTenKiThi;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnSinhDuLieu;
        private System.Windows.Forms.TextBox txtTienToTenThiSinh;
        private System.Windows.Forms.NumericUpDown txtSoThiSinh;
        private System.Windows.Forms.NumericUpDown txtSoMonThiSinh;
    }
}

