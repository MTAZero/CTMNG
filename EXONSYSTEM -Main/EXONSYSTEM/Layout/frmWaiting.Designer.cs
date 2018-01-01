namespace EXONSYSTEM.Layout
{
	partial class frmWaiting
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
			this.mpsWaiting = new MetroFramework.Controls.MetroProgressSpinner();
			this.fpnlLabel = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// mpsWaiting
			// 
			this.mpsWaiting.CustomBackground = true;
			this.mpsWaiting.Location = new System.Drawing.Point(70, 15);
			this.mpsWaiting.Maximum = 100;
			this.mpsWaiting.Name = "mpsWaiting";
			this.mpsWaiting.Size = new System.Drawing.Size(60, 60);
			this.mpsWaiting.Speed = 4F;
			this.mpsWaiting.Style = MetroFramework.MetroColorStyle.Blue;
			this.mpsWaiting.TabIndex = 0;
			this.mpsWaiting.UseCustomBackColor = true;
			this.mpsWaiting.UseCustomForeColor = true;
			this.mpsWaiting.UseSelectable = true;
			this.mpsWaiting.UseStyleColors = true;
			this.mpsWaiting.Value = 30;
			// 
			// fpnlLabel
			// 
			this.fpnlLabel.AutoSize = true;
			this.fpnlLabel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.fpnlLabel.Location = new System.Drawing.Point(0, 83);
			this.fpnlLabel.Name = "fpnlLabel";
			this.fpnlLabel.Size = new System.Drawing.Size(200, 46);
			this.fpnlLabel.TabIndex = 1;
			// 
			// frmWaiting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(200, 130);
			this.ControlBox = false;
			this.Controls.Add(this.fpnlLabel);
			this.Controls.Add(this.mpsWaiting);
			this.DisplayHeader = false;
			this.DoubleBuffered = false;
			this.MinimumSize = new System.Drawing.Size(200, 130);
			this.Movable = false;
			this.Name = "frmWaiting";
			this.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
			this.Resizable = false;
			this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "WaitingForm";
			this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
			this.Load += new System.EventHandler(this.frmWaiting_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroFramework.Controls.MetroProgressSpinner mpsWaiting;
		private System.Windows.Forms.FlowLayoutPanel fpnlLabel;
	}
}