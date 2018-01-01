namespace ClientSide
{
    partial class ClientSide
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
            this.lbTimer = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lstbTraceLog = new System.Windows.Forms.ListBox();
            this.timeCountDown = new System.Windows.Forms.Timer(this.components);
            this.pACS = new System.Windows.Forms.Panel();
            this.pACS.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTimer.Location = new System.Drawing.Point(3, 18);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(33, 24);
            this.lbTimer.TabIndex = 11;
            this.lbTimer.Text = "Ttt";
            this.lbTimer.Click += new System.EventHandler(this.lbTimer_Click);
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSend.Location = new System.Drawing.Point(537, 283);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(60, 60);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "GỬI";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(22, 283);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(412, 60);
            this.txtMessage.TabIndex = 9;
            this.txtMessage.Text = "300";
            // 
            // lstbTraceLog
            // 
            this.lstbTraceLog.FormattingEnabled = true;
            this.lstbTraceLog.Location = new System.Drawing.Point(22, 12);
            this.lstbTraceLog.Name = "lstbTraceLog";
            this.lstbTraceLog.Size = new System.Drawing.Size(575, 264);
            this.lstbTraceLog.TabIndex = 8;
            // 
            // timeCountDown
            // 
            this.timeCountDown.Interval = 1000;
            this.timeCountDown.Tick += new System.EventHandler(this.timeCountDown_Tick);
            // 
            // pACS
            // 
            this.pACS.Controls.Add(this.lbTimer);
            this.pACS.Location = new System.Drawing.Point(441, 283);
            this.pACS.Name = "pACS";
            this.pACS.Size = new System.Drawing.Size(60, 55);
            this.pACS.TabIndex = 12;
            // 
            // ClientSide
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 403);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lstbTraceLog);
            this.Controls.Add(this.pACS);
            this.Name = "ClientSide";
            this.Text = "CLIENT SIDE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientSide_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientSide_FormClosed);
            this.Load += new System.EventHandler(this.ClientSide_Load);
            this.pACS.ResumeLayout(false);
            this.pACS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ListBox lstbTraceLog;
        private System.Windows.Forms.Timer timeCountDown;
        private System.Windows.Forms.Panel pACS;
    }
}

