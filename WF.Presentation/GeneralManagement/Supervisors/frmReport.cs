using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CL.Persistance;
using GeneralManagement.Common;
namespace GeneralManagement.Supervisors
{
    public partial class frmReport : Form
    {
        int divisionShiftID;
        int SupervisorID;
        SHIFT shift = new SHIFT();
        int roomTestID;
        int shiftID;
        public frmReport()
        {
            InitializeComponent();
        }
        public frmReport(int _DivisionShiftID,int _SupervisorID, int _shiftID)
        {
            this.shiftID = _shiftID;
            this.divisionShiftID = _DivisionShiftID;
            this.SupervisorID = _SupervisorID;
            
            InitializeComponent();
        }
        private void frmReport_Load(object sender, EventArgs e)
        {
            GetInfoShift();
            this.pR_REPORTCONTESTANTTableAdapter.Connection.ConnectionString = CL.Persistance.Common.GetConnectString("MTAQuizEntities");


            this.pR_REPORTCONTESTANTTableAdapter.Fill(this.mTA_QUIZ_8DataSet.PR_REPORTCONTESTANT, divisionShiftID, SupervisorID);
            this.sTAFFSTableAdapter.Connection.ConnectionString = CL.Persistance.Common.GetConnectString("MTAQuizEntities");
            this.sHIFTSTableAdapter.Connection.ConnectionString = CL.Persistance.Common.GetConnectString("MTAQuizEntities");
            this.rOOMTESTSTableAdapter.Connection.ConnectionString = CL.Persistance.Common.GetConnectString("MTAQuizEntities");
            this.contestantNotCompleteApdapter.Connection.ConnectionString = CL.Persistance.Common.GetConnectString("MTAQuizEntities");
            this.contestantNotCompleteApdapter.Fill(this.mTA_QUIZ_8DataSet.ContestantNotComplete, divisionShiftID);
            this.sHIFTSTableAdapter.Fill(this.mTA_QUIZ_8DataSet.SHIFTS, divisionShiftID);
            this.rOOMTESTSTableAdapter.Fill(this.mTA_QUIZ_8DataSet.ROOMTESTS, divisionShiftID);
            this.sTAFFSTableAdapter.Fill(this.mTA_QUIZ_8DataSet.STAFFS, SupervisorID);
            this.reportViewer1.RefreshReport();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
        private void GetInfoShift()
        {
           
        }

        private void mnuAttendance_Click(object sender, EventArgs e)
        {

        }

        private void mnuDoneTest_Click(object sender, EventArgs e)
        {

        }

        private void mnuViolation_Click(object sender, EventArgs e)
        {

        }

        private void mnuIsCancelTest_Click(object sender, EventArgs e)
        {

        }

        private void mnuCancelTest_Click(object sender, EventArgs e)
        {

        }
    }
}
