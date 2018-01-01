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
    public partial class ucLichThi : UserControl
    {
        private ExonSystem db = DAO.DBService.db;
        private CONTEST kithi = new CONTEST();

        #region Hàm khởi tạo
        public ucLichThi(CONTEST ct)
        {
            InitializeComponent();
            DAO.DBService.Reload();
            kithi = ct;
        }
        #endregion

        #region LoadForm
        private void LoadDgvCaThi()
        {
            int i = 1;
            dgvCaThi.DataSource = (from ctg in db.SHIFTS.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID).ToList().OrderBy(p => p.ShiftDate)
                                   select new
                                   {
                                       ID = ctg.ShiftID,
                                       CaThi = ctg.ShiftName,
                                       BatDau = DAO.Helper.ConvertUnixToDateTime((int)ctg.StartTime).ToString("HH : mm"),
                                       KetThuc = DAO.Helper.ConvertUnixToDateTime((int)ctg.EndTime).ToString("HH : mm"),
                                       ShiftDate = ctg.ShiftDate
                                   }
                                  )
                                  .OrderBy(p => p.ShiftDate)
                                  .Select(p => new
                                  {
                                      ID = p.ID,
                                      CaThi = p.CaThi,
                                      BatDau = p.BatDau,
                                      KetThuc = p.KetThuc,
                                      ShiftDate = p.ShiftDate,
                                      STT = i++
                                  })
                                  .ToList();

            LoadDgvLichThi();
        }
        private void LoadDgvLichThi()
        {
            int i = 1;
            try
            {
                int Shiftid = (int)dgvCaThi.SelectedRows[0].Cells["IDCaThi"].Value;
                int RoomTestID = (int)dgvRoomTest.SelectedRows[0].Cells["IDPhongThi"].Value;

                int id = db.DIVISION_SHIFTS.Where(p => p.Status > 0 && p.ShiftID == Shiftid && p.RoomTestID == RoomTestID).FirstOrDefault().DivisionShiftID;

                dgvLichThi.DataSource = (
                                            from lt in db.CONTESTANTS_SHIFTS.Where(pz => pz.Status == 1 && pz.ShiftID == id).ToList()
                                            from ts in db.CONTESTANTS.Where(pz => pz.Status > 0 && lt.ContestantID == pz.ContestantID).ToList()
                                            from tt in db.REGISTERS.Where(pz => pz.Status > 0 && pz.ContestID == kithi.ContestID && pz.RegisterID == ts.RegisterID).ToList()
                                            from mt in db.SCHEDULES.Where(pz => pz.Status == 1 && pz.ContestID == kithi.ContestID && pz.ScheduleID == lt.ScheduleID).ToList()
                                            select new
                                            {
                                                ID = lt.ContestantShiftID,
                                                SBD = ts.ContestantCode,
                                                STT = i++,
                                                HoTen = tt.FullName,
                                                NgaySinh = DAO.Helper.ConvertUnixToDateTime((int)tt.DOB).ToString("dd/MM/yyyy"),
                                                MonThi = db.SUBJECTS.Where(p => p.SubjectID == mt.SubjectID).FirstOrDefault().SubjectName
                                            }
                                        ).ToList();
            }
            catch (Exception e)
            {
            }
        }
        private void LoadDgvPhongThi()
        {
            try
            {
                int i = 1;
                int ID = (int)cbxLocation.SelectedValue;

                dgvRoomTest.DataSource = db.ROOMTESTS.Where(p => p.LocationID == ID && p.Status > 0).ToList()
                                         .Select(p => new
                                         {
                                             IDPhongThi = p.RoomTestID,
                                             STT = i++,
                                             PhongThi = p.RoomTestName,
                                             SoLuong = p.MaxSeatMount
                                         })
                                         .ToList();
            }
            catch
            {
                // Chả có địa điểm nào được chọn :D
            }
        }
        private void LoadInitControl()
        {
            // Load CbxDia diem
            cbxLocation.DataSource = db.LOCATIONS.Where(p => p.ContestID == kithi.ContestID && p.Status > 0).ToList();
            cbxLocation.DisplayMember = "LocationName";
            cbxLocation.ValueMember = "LocationID";

            LoadDgvPhongThi();
        }
        private void ucLichThi_Load(object sender, EventArgs e)
        {
            LoadInitControl();
            LoadDgvCaThi();
        }
        #endregion

        #region Sự kiện ngầm
        private void dgvCaThi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCaThi.SelectedRows.Count < 1) return;
            try
            {
                LoadDgvLichThi();
            }
            catch
            {

            }
        }

        private void cbxLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgvPhongThi();
        }

        private void dgvRoomTest_SelectionChanged(object sender, EventArgs e)
        {
            LoadDgvLichThi();
        }
        #endregion

        #region Sự kiện
        private void btnInLichThi_Click(object sender, EventArgs e)
        {
            try
            {
                int Shiftid = (int)dgvCaThi.SelectedRows[0].Cells["IDCaThi"].Value;
                int RoomTestID = (int)dgvRoomTest.SelectedRows[0].Cells["IDPhongThi"].Value;

                int id = db.DIVISION_SHIFTS.Where(p => p.Status > 0 && p.ShiftID == Shiftid && p.RoomTestID == RoomTestID).FirstOrDefault().DivisionShiftID;

                DIVISION_SHIFTS dv = db.DIVISION_SHIFTS.Where(p => p.DivisionShiftID == id).FirstOrDefault();
                FrmRpLichThiTheoCaThi lichthi = new FrmRpLichThiTheoCaThi(dv);
                lichthi.ShowDialog();
            }
            catch { }
        }

        private void btnInKetQuaCaThi_Click(object sender, EventArgs e)
        {
            try
            {
                int Shiftid = (int)dgvCaThi.SelectedRows[0].Cells["IDCaThi"].Value;
                int RoomTestID = (int)dgvRoomTest.SelectedRows[0].Cells["IDPhongThi"].Value;

                int id = db.DIVISION_SHIFTS.Where(p => p.Status > 0 && p.ShiftID == Shiftid && p.RoomTestID == RoomTestID).FirstOrDefault().DivisionShiftID;

                DIVISION_SHIFTS dv = db.DIVISION_SHIFTS.Where(p => p.DivisionShiftID == id).FirstOrDefault();
                FrmRpKetQuaTheoCaThi lichthi = new FrmRpKetQuaTheoCaThi(dv);
                lichthi.ShowDialog();
            }
            catch { }
        }

        private void btnInKetQuaThiSinh_Click(object sender, EventArgs e)
        {
            try
            {
                int ContestantShiftID = (int)dgvLichThi.SelectedRows[0].Cells["IDLichThi"].Value;
                CONTESTANTS_SHIFTS lt = db.CONTESTANTS_SHIFTS.Where(p => p.ContestantShiftID == ContestantShiftID).FirstOrDefault();
                CONTESTANT thisinh = db.CONTESTANTS.Where(p => p.ContestantID == lt.ContestantID).FirstOrDefault();

                FrmRpKetQuaTheoThiSinh form = new FrmRpKetQuaTheoThiSinh(thisinh);
                form.ShowDialog();
            }
            catch { }
        }
        #endregion
    }
}
