using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContestManagementVer2.CSDL_Exonsytem;
using ContestManagementVer2.Report;

namespace ContestManagementVer2.Main
{
    public partial class ucDanhSachDangKy : UserControl
    {
        private ExonSystem db = DAO.DBService.db;
        private CONTEST kithi = new CONTEST();

        #region Hàm khởi tạo
        public ucDanhSachDangKy(CONTEST _kt)
        {
            InitializeComponent();
            DAO.DBService.Reload();
            kithi = _kt;
        }


        #endregion

        #region Hàm chức năng

        private void LoadInitControl()
        {
            // Load cbx Mon thi
            var listMonThi = (
                                from dk in db.SCHEDULES.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID).ToList()
                                from mt in db.SUBJECTS.Where(p => p.SubjectID == dk.SubjectID).ToList()
                                select mt
                              )
                              .ToList();
            cbxMonThi.DataSource = listMonThi;
            cbxMonThi.DisplayMember = "SubjectName";
            cbxMonThi.ValueMember = "SubjectID";
        }

        private void LoadDgvDanhSach()
        {
            try
            {
                int SubjectID = (int) cbxMonThi.SelectedValue;

                int i = 1;
                var listThiSinh = (
                                    from tt in db.REGISTERS.Where(pz => pz.Status > 0 && pz.ContestID == kithi.ContestID).ToList()
                                    from ts in db.CONTESTANTS.Where(pz => pz.Status > 0 && pz.RegisterID == tt.RegisterID).ToList()
                                    from dk in db.CONTESTANTS_SUBJECTS.Where(pz => pz.Status > 0 && pz.ContestantID == ts.ContestantID && pz.SubjectID == SubjectID).ToList()
                                    select new
                                    {
                                        SBD = ts.ContestantCode,
                                        STT = i++,
                                        HoTen = tt.FullName,
                                        NgaySinh = DAO.Helper.ConvertUnixToDateTime((int)tt.DOB).ToString("dd/MM/yyyy"),
                                        GioiTinh = (tt.Sex == 0) ? "Nữ" : "Nam",
                                        CMND = tt.IdentityCardNumber
                                    }
                                   ).ToList();
                dgvThiSinh.DataSource = listThiSinh;
            }
            catch { }
        }

        private void ucDanhSachDangKy_Load(object sender, EventArgs e)
        {
            LoadInitControl();
            LoadDgvDanhSach();
        }
        #endregion

        private void cbxMonThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgvDanhSach();
        }

        private void btnInDanhSach_Click(object sender, EventArgs e)
        {
            try
            {
                int SubjectID = (int) cbxMonThi.SelectedValue;
                SCHEDULE sc = db.SCHEDULES.Where(p => p.ContestID == kithi.ContestID && p.Status > 0 && p.SubjectID == SubjectID).FirstOrDefault();
                FrmRpThiSinhDangKyTheoMonThi form = new FrmRpThiSinhDangKyTheoMonThi(sc);
                form.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Chưa có môn thi nào được chọn",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                );
            }

        }
    }
}
