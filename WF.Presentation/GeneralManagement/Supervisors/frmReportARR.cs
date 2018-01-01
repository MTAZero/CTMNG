using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralManagement.Supervisors
{
    public partial class frmReportARR : Form
    {
        int divisionShiftID;
        public frmReportARR()
        {
            InitializeComponent();
        }
        public frmReportARR(int _divisionShiftID)
        {
            InitializeComponent();
            this.divisionShiftID = _divisionShiftID;
        }
        private void frmReportARR_Load(object sender, EventArgs e)
        {
            this.rEPORTCONTESTANT_ARRTableAdapter.Connection.ConnectionString = CL.Persistance.Common.GetConnectString("MTAQuizEntities");
            this.rEPORTCONTESTANT_ARRTableAdapter.Fill(mTA_QUIZ_8DataSet.REPORTCONTESTANT_ARR, divisionShiftID);

            this.rOOMTESTSTableAdapter.Connection.ConnectionString = CL.Persistance.Common.GetConnectString("MTAQuizEntities");
            this.rOOMTESTSTableAdapter.Fill(mTA_QUIZ_8DataSet.ROOMTESTS, divisionShiftID);

            this.sHIFTSTableAdapter.Connection.ConnectionString = CL.Persistance.Common.GetConnectString("MTAQuizEntities");
            this.sHIFTSTableAdapter.Fill(mTA_QUIZ_8DataSet.SHIFTS, divisionShiftID);
            this.reportViewer1.RefreshReport();
        }
    }
}
