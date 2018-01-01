using ContestManagementVer2.CSDL_Exonsytem;
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

namespace ContestManagementVer2.Report
{
    public partial class FrmRpKetQuaTheoThiSinh : Form
    {
        private CONTESTANT thisinh = new CONTESTANT();
        private ExonSystem db = DAO.DBService.db;

        #region contructor
        public FrmRpKetQuaTheoThiSinh(CONTESTANT _ts)
        {
            InitializeComponent();
            thisinh = _ts;
            DAO.DBService.Reload();
        }
        #endregion


        #region LoadForm
        private void FrmRpKetQuaTheoThiSinh_Load(object sender, EventArgs e)
        {
            try
            {
                // lấy thông tin của ca thi
                
                REGISTER thongtin = db.REGISTERS.Where(p=>p.RegisterID == thisinh.RegisterID).FirstOrDefault();
                CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == thongtin.ContestID).FirstOrDefault();

                CSDL_Luu_Tru.MTA_Quiz_Main z = new CSDL_Luu_Tru.MTA_Quiz_Main();
                // truyền table vào trong report
                int i = 1;
                KetQuaThiBindingSource.DataSource = (
                               from lt in db.CONTESTANTS_SHIFTS.Where(pz => pz.Status == 1 && pz.ContestantID == thisinh.ContestantID).ToList()
                               from ts in db.CONTESTANTS.Where(pz => pz.Status > 0 && lt.ContestantID == pz.ContestantID).ToList()
                               from tt in db.REGISTERS.Where(pz => pz.Status > 0 && pz.ContestID == kithi.ContestID && pz.RegisterID == ts.RegisterID).ToList()
                               from mt in db.SCHEDULES.Where(pz => pz.Status == 1 && pz.ContestID == kithi.ContestID && pz.ScheduleID == lt.ScheduleID).ToList()
                               select new
                               {
                                   STT = i++,
                                   MonThi = db.SUBJECTS.Where(p => p.SubjectID == mt.SubjectID).FirstOrDefault().SubjectName,
                                   Diem = (
                                                (
                                                    from ct in z.CONTESTANTS_TESTS.Where(k => k.Status > 0 && k.ContestantShiftID == lt.ContestantShiftID).ToList()
                                                    from ans in z.ANSWERSHEETS.Where(k => k.ContestantTestID == ct.ContestantTestID && k.Status > 0).ToList()
                                                    select ans
                                                 )
                                                 .FirstOrDefault() == null
                                            )
                                            ? ""
                                            :
                                                (
                                                    from ct in z.CONTESTANTS_TESTS.Where(k => k.Status > 0 && k.ContestantShiftID == lt.ContestantShiftID).ToList()
                                                    from ans in z.ANSWERSHEETS.Where(k => k.ContestantTestID == ct.ContestantTestID && k.Status > 0).ToList()
                                                    select ans
                                                 )
                                                 .FirstOrDefault()
                                                 .TestScores
                                                 .ToString()
                               }
                              ).ToList();
                

                // add parameter
                ReportParameter[] listPara = new ReportParameter[]{
                    new ReportParameter("ContestName",kithi.ContestName.ToUpper()),
                    new ReportParameter("FullName",thongtin.FullName),
                    new ReportParameter("DOB",DAO.Helper.ConvertUnixToDateTime((int) thongtin.DOB).ToString("dd/MM/yyyy")),
                    new ReportParameter("SBD", thisinh.ContestantCode),
                    new ReportParameter("SDT", thongtin.TelephoneNumber),
                    new ReportParameter("Sex", thongtin.Sex == 0 ? "Nữ" : "Nam"),
                    new ReportParameter("CMND",thongtin.IdentityCardNumber),
                    new ReportParameter("Date",DateTime.Now.ToString(@"\n\g\à\y dd \t\h\á\n\g MM \n\ă\m yyyy")),
                    new ReportParameter("POB","")

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
        #endregion
    }
}
