namespace EXONSYSTEM.Layout
{
    partial class frmLoading
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
            this.mpgLoading = new MetroFramework.Controls.MetroProgressBar();
            this.mlbLoading = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // mpgLoading
            // 
            this.mpgLoading.Location = new System.Drawing.Point(19, 52);
            this.mpgLoading.Margin = new System.Windows.Forms.Padding(5);
            this.mpgLoading.Name = "mpgLoading";
            this.mpgLoading.Size = new System.Drawing.Size(492, 24);
            this.mpgLoading.Style = MetroFramework.MetroColorStyle.Blue;
            this.mpgLoading.TabIndex = 1;
            this.mpgLoading.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // mlbLoading
            // 
            this.mlbLoading.AutoSize = true;
            this.mlbLoading.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.mlbLoading.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.mlbLoading.Location = new System.Drawing.Point(191, 84);
            this.mlbLoading.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.mlbLoading.Name = "mlbLoading";
            this.mlbLoading.Size = new System.Drawing.Size(171, 25);
            this.mlbLoading.TabIndex = 2;
            this.mlbLoading.Text = "Đang tải đề thi... 0%";
            // 
            // frmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 115);
            this.ControlBox = false;
            this.Controls.Add(this.mlbLoading);
            this.Controls.Add(this.mpgLoading);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "frmLoading";
            this.Padding = new System.Windows.Forms.Padding(34, 97, 34, 32);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Tải dữ liệu";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar mpgLoading;
        private MetroFramework.Controls.MetroLabel mlbLoading;
    }
}