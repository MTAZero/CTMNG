using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateDB.Report
{
    public partial class frmReportKey : Form
    {
        int dvid = 0;
        public frmReportKey()
        {
            InitializeComponent();
        }
        public frmReportKey(int id)
        {
            InitializeComponent();
            dvid = id;
        }
        private void frmReportKey_Load(object sender, EventArgs e)
        {
            this.DataTable1TableAdapter.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["EXON_DbContext"].ConnectionString;
            // TODO: This line of code loads data into the 'DataSetDVKey.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DataSetDVKey.DataTable1,dvid);

            this.reportViewer1.RefreshReport();
        }
    }
}
