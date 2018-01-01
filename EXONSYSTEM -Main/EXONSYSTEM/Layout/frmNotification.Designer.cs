namespace EXONSYSTEM.Layout
{
    partial class frmNotification
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
            this.mbtnOK = new MetroFramework.Controls.MetroButton();
            this.mbtnCancel = new MetroFramework.Controls.MetroButton();
            this.lbContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mbtnOK
            // 
            this.mbtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.mbtnOK.Location = new System.Drawing.Point(167, 118);
            this.mbtnOK.Name = "mbtnOK";
            this.mbtnOK.Size = new System.Drawing.Size(127, 35);
            this.mbtnOK.TabIndex = 1;
            this.mbtnOK.Text = "metroButton1";
            this.mbtnOK.UseCustomBackColor = true;
            this.mbtnOK.UseCustomForeColor = true;
            this.mbtnOK.UseSelectable = true;
            // 
            // mbtnCancel
            // 
            this.mbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.mbtnCancel.Location = new System.Drawing.Point(315, 118);
            this.mbtnCancel.Name = "mbtnCancel";
            this.mbtnCancel.Size = new System.Drawing.Size(127, 35);
            this.mbtnCancel.TabIndex = 2;
            this.mbtnCancel.Text = "metroButton1";
            this.mbtnCancel.UseCustomBackColor = true;
            this.mbtnCancel.UseCustomForeColor = true;
            this.mbtnCancel.UseSelectable = true;
            this.mbtnCancel.Visible = false;
            // 
            // lbContent
            // 
            this.lbContent.AutoSize = true;
            this.lbContent.Location = new System.Drawing.Point(17, 53);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(53, 21);
            this.lbContent.TabIndex = 3;
            this.lbContent.Text = "label1";
            // 
            // frmNotification
            // 
            this.AcceptButton = this.mbtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 171);
            this.ControlBox = false;
            this.Controls.Add(this.lbContent);
            this.Controls.Add(this.mbtnCancel);
            this.Controls.Add(this.mbtnOK);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "frmNotification";
            this.Padding = new System.Windows.Forms.Padding(34, 97, 34, 32);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmNotification";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton mbtnOK;
        private MetroFramework.Controls.MetroButton mbtnCancel;
        private System.Windows.Forms.Label lbContent;
    }
}