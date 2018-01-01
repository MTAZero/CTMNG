using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateDB.Report
{
    public partial class frmReportComputer : Form
    {
        int _roomid;
        public frmReportComputer()
        {
            InitializeComponent();
        }
        public frmReportComputer(int roomid)
        {
            InitializeComponent();
            _roomid = roomid;
            this.ShowInTaskbar = false;
        }
        public String ConvertStatus(int status)
        {
            String a = "";
            if (status == 4001) a = "Tốt";
            else if (status == 4002) a = "Hỏng";
            else if (status == 4003) a = "Dự phòng";
            return a;
        }
        private void frmReportComputer_Load(object sender, EventArgs e)
        {
            try
            {
                // lấy thông tin của ca thi


                // truyền table vào trong report
                Main.Main db = new Main.Main();
                int i = 1;
                Main.ROOMTEST room = new Main.ROOMTEST();
                room = db.ROOMTESTS.Where(x => x.RoomTestID == _roomid).FirstOrDefault();
                ComputerStatusBindingSource.DataSource =
                                    (
                                        from may in db.ROOMDIAGRAMS.Where(p => p.Status > 0).ToList()
                                        from phong in db.ROOMTESTS.Where(p => p.RoomTestID == may.RoomTestID && p.Status > 0 && p.RoomTestID==_roomid).ToList()
                                        from diadiem in db.LOCATIONS.Where(p => p.LocationID == phong.LocationID && p.Status > 0).ToList()
                                            //from diadiem in db.LOCATIONS.Where(p => p.Status > 0 && p.LocationID == phong.LocationID && p.ContestID == kithi.ContestID)
                                        select new
                                        {
                                            Order = i++,
                                            ComputerName = may.ComputerName,
                                            //ClientIP = may.ClientIP,
                                            ComputerCode = may.ComputerCode,
                                            RoomTest = phong.RoomTestName,
                                            Status = ConvertStatus(may.Status).ToString(),
                                            Location = diadiem.LocationName,
                                        }
                                    ).ToList();


                //// add parameter;

                ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",room.LOCATION.CONTEST.ContestName),
                    new ReportParameter("CreateDate",DateTime.Now.ToString(@"\n\g\à\y\ dd \t\h\á\n\g\ MM \n\ă\m\ yyyy")),



                };
                this.reportViewer1.LocalReport.SetParameters(listPara);


                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
