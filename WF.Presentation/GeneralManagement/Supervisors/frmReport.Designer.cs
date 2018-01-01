namespace GeneralManagement.Supervisors
{
    partial class frmReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.PR_REPORTCONTESTANTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mTA_QUIZ_8DataSet = new GeneralManagement.MTA_QUIZ_8DataSet();
            this.STAFFSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rOOMTESTSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sHIFTSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contestantNotCompleteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sTAFFSBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pRREPORTCONTESTANTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pR_REPORTCONTESTANTTableAdapter = new GeneralManagement.MTA_QUIZ_8DataSetTableAdapters.PR_REPORTCONTESTANTTableAdapter();
            this.tstrMain = new System.Windows.Forms.ToolStrip();
            this.lblHome = new System.Windows.Forms.ToolStripLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sTAFFSTableAdapter = new GeneralManagement.MTA_QUIZ_8DataSetTableAdapters.STAFFSTableAdapter();
            this.rOOMTESTSTableAdapter = new GeneralManagement.MTA_QUIZ_8DataSetTableAdapters.ROOMTESTSTableAdapter();
            this.sHIFTSTableAdapter = new GeneralManagement.MTA_QUIZ_8DataSetTableAdapters.SHIFTSTableAdapter();
            this.contestantNotCompleteApdapter = new GeneralManagement.MTA_QUIZ_8DataSetTableAdapters.ContestantNotCompleteApdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PR_REPORTCONTESTANTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTA_QUIZ_8DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFFSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOOMTESTSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sHIFTSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contestantNotCompleteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTAFFSBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRREPORTCONTESTANTBindingSource)).BeginInit();
            this.tstrMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // PR_REPORTCONTESTANTBindingSource
            // 
            this.PR_REPORTCONTESTANTBindingSource.DataMember = "PR_REPORTCONTESTANT";
            this.PR_REPORTCONTESTANTBindingSource.DataSource = this.mTA_QUIZ_8DataSet;
            // 
            // mTA_QUIZ_8DataSet
            // 
            this.mTA_QUIZ_8DataSet.DataSetName = "MTA_QUIZ_8DataSet";
            this.mTA_QUIZ_8DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // STAFFSBindingSource
            // 
            this.STAFFSBindingSource.DataMember = "STAFFS";
            this.STAFFSBindingSource.DataSource = this.mTA_QUIZ_8DataSet;
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
            // contestantNotCompleteBindingSource
            // 
            this.contestantNotCompleteBindingSource.DataMember = "ContestantNotComplete";
            this.contestantNotCompleteBindingSource.DataSource = this.mTA_QUIZ_8DataSet;
            // 
            // sTAFFSBindingSource1
            // 
            this.sTAFFSBindingSource1.DataMember = "STAFFS";
            this.sTAFFSBindingSource1.DataSource = this.mTA_QUIZ_8DataSet;
            // 
            // pRREPORTCONTESTANTBindingSource
            // 
            this.pRREPORTCONTESTANTBindingSource.DataMember = "PR_REPORTCONTESTANT";
            this.pRREPORTCONTESTANTBindingSource.DataSource = this.mTA_QUIZ_8DataSet;
            // 
            // pR_REPORTCONTESTANTTableAdapter
            // 
            this.pR_REPORTCONTESTANTTableAdapter.ClearBeforeFill = true;
            // 
            // tstrMain
            // 
            this.tstrMain.BackColor = System.Drawing.Color.Aquamarine;
            this.tstrMain.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.tstrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblHome});
            this.tstrMain.Location = new System.Drawing.Point(0, 0);
            this.tstrMain.Name = "tstrMain";
            this.tstrMain.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tstrMain.Size = new System.Drawing.Size(901, 25);
            this.tstrMain.TabIndex = 13;
            this.tstrMain.Text = "toolStrip1";
            // 
            // lblHome
            // 
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(162, 22);
            this.lblHome.Text = "BÁO CÁO THỐNG KÊ";
            // 
            // reportViewer1
            // 
            this.reportViewer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            reportDataSource1.Name = "ReportContestant";
            reportDataSource1.Value = this.PR_REPORTCONTESTANTBindingSource;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.STAFFSBindingSource;
            reportDataSource3.Name = "DataSet2";
            reportDataSource3.Value = this.rOOMTESTSBindingSource;
            reportDataSource4.Name = "DataSet3";
            reportDataSource4.Value = this.sHIFTSBindingSource;
            reportDataSource5.Name = "DataSet4";
            reportDataSource5.Value = this.contestantNotCompleteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GeneralManagement.Supervisors.ReportContestant.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 28);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this.reportViewer1.Size = new System.Drawing.Size(901, 696);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // sTAFFSTableAdapter
            // 
            this.sTAFFSTableAdapter.ClearBeforeFill = true;
            // 
            // rOOMTESTSTableAdapter
            // 
            this.rOOMTESTSTableAdapter.ClearBeforeFill = true;
            // 
            // sHIFTSTableAdapter
            // 
            this.sHIFTSTableAdapter.ClearBeforeFill = true;
            // 
            // contestantNotCompleteApdapter
            // 
            this.contestantNotCompleteApdapter.ClearBeforeFill = true;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 724);
            this.Controls.Add(this.tstrMain);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PR_REPORTCONTESTANTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTA_QUIZ_8DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STAFFSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOOMTESTSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sHIFTSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contestantNotCompleteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTAFFSBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRREPORTCONTESTANTBindingSource)).EndInit();
            this.tstrMain.ResumeLayout(false);
            this.tstrMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ToolStrip tstrMain;
        private System.Windows.Forms.ToolStripLabel lblHome;
        private System.Windows.Forms.BindingSource pRREPORTCONTESTANTBindingSource;
        private MTA_QUIZ_8DataSet mTA_QUIZ_8DataSet;
        private MTA_QUIZ_8DataSetTableAdapters.PR_REPORTCONTESTANTTableAdapter pR_REPORTCONTESTANTTableAdapter;
        private System.Windows.Forms.BindingSource PR_REPORTCONTESTANTBindingSource;
        private System.Windows.Forms.BindingSource STAFFSBindingSource;
        private System.Windows.Forms.BindingSource sTAFFSBindingSource1;
        private MTA_QUIZ_8DataSetTableAdapters.STAFFSTableAdapter sTAFFSTableAdapter;
        private System.Windows.Forms.BindingSource rOOMTESTSBindingSource;
        private System.Windows.Forms.BindingSource sHIFTSBindingSource;
        private MTA_QUIZ_8DataSetTableAdapters.ROOMTESTSTableAdapter rOOMTESTSTableAdapter;
        private MTA_QUIZ_8DataSetTableAdapters.SHIFTSTableAdapter sHIFTSTableAdapter;
        private System.Windows.Forms.BindingSource contestantNotCompleteBindingSource;
        private MTA_QUIZ_8DataSetTableAdapters.ContestantNotCompleteApdapter contestantNotCompleteApdapter;
    }
}