namespace EXONSYSTEM
{
    partial class frmMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.timeCountDown = new System.Windows.Forms.Timer(this.components);
            this.pnInformation = new MetroFramework.Controls.MetroPanel();
            this.flpnListOfButtonQuestions = new System.Windows.Forms.FlowLayoutPanel();
            this.lbTimer = new System.Windows.Forms.Label();
            this.flpnListOfQuestions = new System.Windows.Forms.FlowLayoutPanel();
           
            this.pnInformation.SuspendLayout();
            this.flpnListOfQuestions.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeCountDown
            // 
            this.timeCountDown.Interval = 1000;
            this.timeCountDown.Tick += new System.EventHandler(this.timeCountDown_Tick);
            // 
            // pnInformation
            // 
            this.pnInformation.Controls.Add(this.flpnListOfButtonQuestions);
            this.pnInformation.Controls.Add(this.lbTimer);
            this.pnInformation.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnInformation.HorizontalScrollbarBarColor = true;
            this.pnInformation.HorizontalScrollbarHighlightOnWheel = false;
            this.pnInformation.HorizontalScrollbarSize = 10;
            this.pnInformation.Location = new System.Drawing.Point(12, 12);
            this.pnInformation.Name = "pnInformation";
            this.pnInformation.Size = new System.Drawing.Size(46, 100);
            this.pnInformation.TabIndex = 7;
            this.pnInformation.UseCustomBackColor = true;
            this.pnInformation.UseCustomForeColor = true;
            this.pnInformation.VerticalScrollbarBarColor = true;
            this.pnInformation.VerticalScrollbarHighlightOnWheel = false;
            this.pnInformation.VerticalScrollbarSize = 10;
            // 
            // flpnListOfButtonQuestions
            // 
            this.flpnListOfButtonQuestions.AutoScroll = true;
            this.flpnListOfButtonQuestions.BackColor = System.Drawing.Color.Transparent;
            this.flpnListOfButtonQuestions.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpnListOfButtonQuestions.Location = new System.Drawing.Point(17, 30);
            this.flpnListOfButtonQuestions.Name = "flpnListOfButtonQuestions";
            this.flpnListOfButtonQuestions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flpnListOfButtonQuestions.Size = new System.Drawing.Size(26, 54);
            this.flpnListOfButtonQuestions.TabIndex = 3;
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimer.Location = new System.Drawing.Point(7, 7);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(0, 73);
            this.lbTimer.TabIndex = 2;
            // 
            // flpnListOfQuestions
            // 
            this.flpnListOfQuestions.AutoScroll = true;
            this.flpnListOfQuestions.BackColor = System.Drawing.SystemColors.Control;
           
            this.flpnListOfQuestions.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpnListOfQuestions.Location = new System.Drawing.Point(96, 19);
            this.flpnListOfQuestions.Name = "flpnListOfQuestions";
            this.flpnListOfQuestions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flpnListOfQuestions.Size = new System.Drawing.Size(62, 80);
            this.flpnListOfQuestions.TabIndex = 2;
            this.flpnListOfQuestions.MouseEnter += new System.EventHandler(this.flpnListOfQuestions_MouseEnter);
            // 
            // vScrollBar1
            // 
           
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 204);
            this.Controls.Add(this.flpnListOfQuestions);
            this.Controls.Add(this.pnInformation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnInformation.ResumeLayout(false);
            this.pnInformation.PerformLayout();
            this.flpnListOfQuestions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timeCountDown;
        private MetroFramework.Controls.MetroPanel pnInformation;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.FlowLayoutPanel flpnListOfQuestions;
        private System.Windows.Forms.FlowLayoutPanel flpnListOfButtonQuestions;
       
    }
}

