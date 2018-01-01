namespace ContestManagementVer2.Report
{
    partial class FrmRpKeHoachKiThi
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource9 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource10 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.LOCATIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KeHoachThiDataSetxsd = new ContestManagementVer2.Report.KeHoachThiDataSetxsd();
            this.SUBJECTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SHIFTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HOIDONGTHIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ROOMTESTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportDataSet = new ContestManagementVer2.Report.ReportDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOCATIONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeHoachThiDataSetxsd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SUBJECTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SHIFTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOIDONGTHIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ROOMTESTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // LOCATIONBindingSource
            // 
            this.LOCATIONBindingSource.DataMember = "LOCATION";
            this.LOCATIONBindingSource.DataSource = this.KeHoachThiDataSetxsd;
            // 
            // KeHoachThiDataSetxsd
            // 
            this.KeHoachThiDataSetxsd.DataSetName = "KeHoachThiDataSetxsd";
            this.KeHoachThiDataSetxsd.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SUBJECTBindingSource
            // 
            this.SUBJECTBindingSource.DataMember = "SUBJECT";
            this.SUBJECTBindingSource.DataSource = this.KeHoachThiDataSetxsd;
            // 
            // SHIFTBindingSource
            // 
            this.SHIFTBindingSource.DataMember = "SHIFT";
            this.SHIFTBindingSource.DataSource = this.KeHoachThiDataSetxsd;
            // 
            // HOIDONGTHIBindingSource
            // 
            this.HOIDONGTHIBindingSource.DataMember = "HOIDONGTHI";
            this.HOIDONGTHIBindingSource.DataSource = this.KeHoachThiDataSetxsd;
            // 
            // ROOMTESTBindingSource
            // 
            this.ROOMTESTBindingSource.DataMember = "ROOMTEST";
            this.ROOMTESTBindingSource.DataSource = this.KeHoachThiDataSetxsd;
            // 
            // ReportDataSet
            // 
            this.ReportDataSet.DataSetName = "ReportDataSet";
            this.ReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource6.Name = "LOCATION";
            reportDataSource6.Value = this.LOCATIONBindingSource;
            reportDataSource7.Name = "SUBJECT";
            reportDataSource7.Value = this.SUBJECTBindingSource;
            reportDataSource8.Name = "SHIFT";
            reportDataSource8.Value = this.SHIFTBindingSource;
            reportDataSource9.Name = "HOIDONGTHI";
            reportDataSource9.Value = this.HOIDONGTHIBindingSource;
            reportDataSource10.Name = "ROOMTEST";
            reportDataSource10.Value = this.ROOMTESTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource9);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource10);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ContestManagementVer2.Report.rpKeHoachKiThi.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(665, 701);
            this.reportViewer1.TabIndex = 0;
            // 
            // FrmRpKeHoachKiThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 701);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmRpKeHoachKiThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kế hoạch kì thi";
            this.Load += new System.EventHandler(this.FrmRpLichThiTheoCaThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOCATIONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeHoachThiDataSetxsd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SUBJECTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SHIFTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOIDONGTHIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ROOMTESTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ReportDataSet ReportDataSet;
        private System.Windows.Forms.BindingSource LOCATIONBindingSource;
        private KeHoachThiDataSetxsd KeHoachThiDataSetxsd;
        private System.Windows.Forms.BindingSource SUBJECTBindingSource;
        private System.Windows.Forms.BindingSource SHIFTBindingSource;
        private System.Windows.Forms.BindingSource HOIDONGTHIBindingSource;
        private System.Windows.Forms.BindingSource ROOMTESTBindingSource;
    }
}