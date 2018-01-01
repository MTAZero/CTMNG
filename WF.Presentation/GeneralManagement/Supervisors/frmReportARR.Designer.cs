namespace GeneralManagement.Supervisors
{
    partial class frmReportARR
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rEPORTCONTESTANTARRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mTA_QUIZ_8DataSet = new GeneralManagement.MTA_QUIZ_8DataSet();
            this.rOOMTESTSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sHIFTSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rEPORTCONTESTANT_ARRTableAdapter = new GeneralManagement.MTA_QUIZ_8DataSetTableAdapters.REPORTCONTESTANT_ARRTableAdapter();
            this.rOOMTESTSTableAdapter = new GeneralManagement.MTA_QUIZ_8DataSetTableAdapters.ROOMTESTSTableAdapter();
            this.sHIFTSTableAdapter = new GeneralManagement.MTA_QUIZ_8DataSetTableAdapters.SHIFTSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.rEPORTCONTESTANTARRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTA_QUIZ_8DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOOMTESTSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sHIFTSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rEPORTCONTESTANTARRBindingSource
            // 
            this.rEPORTCONTESTANTARRBindingSource.DataMember = "REPORTCONTESTANT_ARR";
            this.rEPORTCONTESTANTARRBindingSource.DataSource = this.mTA_QUIZ_8DataSet;
            // 
            // mTA_QUIZ_8DataSet
            // 
            this.mTA_QUIZ_8DataSet.DataSetName = "MTA_QUIZ_8DataSet";
            this.mTA_QUIZ_8DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rOOMTESTSBindingSource
            // 
            this.rOOMTESTSBindingSource.DataMember = "ROOMTESTS";
            this.rOOMTESTSBindingSource.DataSource = this.mTA_QUIZ_8DataSet;
            // 
            // sHIFTSBindingSource
            // 
            this.sHIFTSBindingSource.DataMember = "SHIFTS";
            this.sHIFTSBindingSource.DataSource = this.mTA_QUIZ_8DataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.rEPORTCONTESTANTARRBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.rOOMTESTSBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.sHIFTSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GeneralManagement.Supervisors.ReportcontestantARR.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(731, 581);
            this.reportViewer1.TabIndex = 0;
            // 
            // rEPORTCONTESTANT_ARRTableAdapter
            // 
            this.rEPORTCONTESTANT_ARRTableAdapter.ClearBeforeFill = true;
            // 
            // rOOMTESTSTableAdapter
            // 
            this.rOOMTESTSTableAdapter.ClearBeforeFill = true;
            // 
            // sHIFTSTableAdapter
            // 
            this.sHIFTSTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportARR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 581);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmReportARR";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In Danh Sách Thí Sinh Xếp Chỗ";
            this.Load += new System.EventHandler(this.frmReportARR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rEPORTCONTESTANTARRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTA_QUIZ_8DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOOMTESTSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sHIFTSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource rEPORTCONTESTANTARRBindingSource;
        private MTA_QUIZ_8DataSet mTA_QUIZ_8DataSet;
        private System.Windows.Forms.BindingSource rOOMTESTSBindingSource;
        private MTA_QUIZ_8DataSetTableAdapters.REPORTCONTESTANT_ARRTableAdapter rEPORTCONTESTANT_ARRTableAdapter;
        private MTA_QUIZ_8DataSetTableAdapters.ROOMTESTSTableAdapter rOOMTESTSTableAdapter;
        private System.Windows.Forms.BindingSource sHIFTSBindingSource;
        private MTA_QUIZ_8DataSetTableAdapters.SHIFTSTableAdapter sHIFTSTableAdapter;
    }
}