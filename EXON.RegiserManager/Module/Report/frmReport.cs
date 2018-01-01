using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace EXON.RegisterManager.Module.Forms
{
    public partial class frmReport : Form
    {
        int id;
        public frmReport()
        {
            InitializeComponent();
        }
        public frmReport(int i)
        {
            InitializeComponent();
            id = i;
        }
        private void frmReport_Load(object sender, EventArgs e)
        {
            this.dataTable1TableAdapter.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["RMDbContext"].ConnectionString;
            this.dataTable2TableAdapter.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["RMDbContext"].ConnectionString;
            // TODO: This line of code loads data into the 'receipt.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.receipt.DataTable1,id);
            // TODO: This line of code loads data into the 'receipt.DataTable2' table. You can move, or remove it, as needed.
            this.dataTable2TableAdapter.Fill(this.receipt.DataTable2,id);

            this.reportViewer1.RefreshReport();

            
        }
    }
}
