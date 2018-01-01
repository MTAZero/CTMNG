namespace GeneralManagement.Supervisors
{
    partial class frmRoomConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoomConfig));
            this.pnlSupervisor = new System.Windows.Forms.Panel();
            this.grDetailCom = new System.Windows.Forms.GroupBox();
            this.lblNotifi = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtComputerCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComputerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRoomTest = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlDiagram = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlSupervisor.SuspendLayout();
            this.grDetailCom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSupervisor
            // 
            this.pnlSupervisor.Controls.Add(this.grDetailCom);
            this.pnlSupervisor.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSupervisor.Location = new System.Drawing.Point(982, 30);
            this.pnlSupervisor.Name = "pnlSupervisor";
            this.pnlSupervisor.Size = new System.Drawing.Size(352, 630);
            this.pnlSupervisor.TabIndex = 0;
            // 
            // grDetailCom
            // 
            this.grDetailCom.BackColor = System.Drawing.Color.White;
            this.grDetailCom.Controls.Add(this.lblNotifi);
            this.grDetailCom.Controls.Add(this.btnCheck);
            this.grDetailCom.Controls.Add(this.button5);
            this.grDetailCom.Controls.Add(this.btnRefresh);
            this.grDetailCom.Controls.Add(this.label3);
            this.grDetailCom.Controls.Add(this.cmbStatus);
            this.grDetailCom.Controls.Add(this.txtComputerCode);
            this.grDetailCom.Controls.Add(this.label2);
            this.grDetailCom.Controls.Add(this.txtComputerName);
            this.grDetailCom.Controls.Add(this.label1);
            this.grDetailCom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDetailCom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grDetailCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grDetailCom.Location = new System.Drawing.Point(0, 0);
            this.grDetailCom.Name = "grDetailCom";
            this.grDetailCom.Size = new System.Drawing.Size(352, 630);
            this.grDetailCom.TabIndex = 3;
            this.grDetailCom.TabStop = false;
            this.grDetailCom.Text = "Chi tiết máy thi";
            // 
            // lblNotifi
            // 
            this.lblNotifi.AutoSize = true;
            this.lblNotifi.Location = new System.Drawing.Point(88, 83);
            this.lblNotifi.Name = "lblNotifi";
            this.lblNotifi.Size = new System.Drawing.Size(0, 17);
            this.lblNotifi.TabIndex = 11;
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.Green;
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(91, 345);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(177, 45);
            this.btnCheck.TabIndex = 10;
            this.btnCheck.Text = "Kiểm tra tình trạng máy";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Green;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(183, 291);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(85, 34);
            this.button5.TabIndex = 10;
            this.button5.Text = "ImPort";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Green;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(91, 291);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(86, 34);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Cập nhập";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Trạng thái máy thi";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Tốt",
            "Hỏng"});
            this.cmbStatus.Location = new System.Drawing.Point(178, 199);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 24);
            this.cmbStatus.TabIndex = 4;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // txtComputerCode
            // 
            this.txtComputerCode.Location = new System.Drawing.Point(178, 164);
            this.txtComputerCode.Name = "txtComputerCode";
            this.txtComputerCode.Size = new System.Drawing.Size(121, 23);
            this.txtComputerCode.TabIndex = 3;
            this.txtComputerCode.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã máy";
            this.label2.Visible = false;
            // 
            // txtComputerName
            // 
            this.txtComputerName.Location = new System.Drawing.Point(178, 164);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.Size = new System.Drawing.Size(121, 23);
            this.txtComputerName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên máy";
            // 
            // lblRoomTest
            // 
            this.lblRoomTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoomTest.AutoSize = true;
            this.lblRoomTest.BackColor = System.Drawing.Color.Green;
            this.lblRoomTest.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomTest.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblRoomTest.Location = new System.Drawing.Point(437, 8);
            this.lblRoomTest.Name = "lblRoomTest";
            this.lblRoomTest.Size = new System.Drawing.Size(107, 23);
            this.lblRoomTest.TabIndex = 0;
            this.lblRoomTest.Text = "Phòng Thi: ";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.pnlDiagram);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(962, 591);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách máy thi trong phòng";
            // 
            // pnlDiagram
            // 
            this.pnlDiagram.AutoScroll = true;
            this.pnlDiagram.BackColor = System.Drawing.Color.White;
            this.pnlDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDiagram.Location = new System.Drawing.Point(3, 19);
            this.pnlDiagram.Name = "pnlDiagram";
            this.pnlDiagram.Size = new System.Drawing.Size(956, 569);
            this.pnlDiagram.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(20, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(962, 630);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 39);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblRoomTest);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(962, 39);
            this.panel3.TabIndex = 0;
            // 
            // frmRoomConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 680);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlSupervisor);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRoomConfig";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Text = "Cấu hình phòng thi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRoomConfig_Load);
            this.pnlSupervisor.ResumeLayout(false);
            this.grDetailCom.ResumeLayout(false);
            this.grDetailCom.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSupervisor;
        private System.Windows.Forms.GroupBox grDetailCom;
        private System.Windows.Forms.TextBox txtComputerCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComputerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lblNotifi;
        private System.Windows.Forms.Label lblRoomTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlDiagram;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Panel panel3;
    }
}