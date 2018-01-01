namespace EXON.GenerateTest.Core.Reports
{
    partial class FrmStructTestReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.StructTestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetReport = new EXON.GenerateTest.Core.Reports.DataSetReport();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.StructTestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReport)).BeginInit();
            this.SuspendLayout();
            // 
            // StructTestBindingSource
            // 
            this.StructTestBindingSource.DataMember = "StructTest";
            this.StructTestBindingSource.DataSource = this.DataSetReport;
            // 
            // DataSetReport
            // 
            this.DataSetReport.DataSetName = "DataSetReport";
            this.DataSetReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "StructTest";
            reportDataSource1.Value = this.StructTestBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "EXON.GenerateTest.Core.Reports.StructTestReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(816, 620);
            this.reportViewer1.TabIndex = 0;
            // 
            // FrmStructTestReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 620);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmStructTestReport";
            this.Text = "Báo Cáo";
            this.Load += new System.EventHandler(this.FrmStructTestReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StructTestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource StructTestBindingSource;
        private DataSetReport DataSetReport;
    }
}