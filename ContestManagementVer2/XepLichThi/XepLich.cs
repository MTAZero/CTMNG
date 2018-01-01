using ContestManagementVer2.CSDL_Exonsytem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContestManagementVer2.XepLichThi
{
    public class XepLich
    {
        private ExonSystem db = DAO.DBService.db;
        /*
         * Input : 
         *          Danh sách thí sinh  : Contestant
         *          Danh sách phòng thi : Roomtest
         *          Danh sách ca thi    : Shift
         *          Danh sách môn thi   : Schedule
         *          Danh sách liên kết thí sinh - môn thi : Contestant_Subject
         */
        List<CONTESTANT> ListContestant;
        List<ROOMTEST> ListRoomTest;
        List<SHIFT> ListShift;
        List<SCHEDULE> ListSchedule;
        List<CONTESTANTS_SUBJECTS> ListContestant_Subject;

        /**
         * Output :
         *          Thí sinh a thi môn thi b tại phòng thi c và ca thi 
         *          Liên kết ca thi với phòng thi ( phân công - giám sát ) : DivitionShift
         *          Liên kết thí sinh với môn thi với phân công - giám sát : ContestantShift
         * **/
        List<DIVISION_SHIFTS> ListDivition_Shift = new List<DIVISION_SHIFTS>();
        List<CONTESTANTS_SHIFTS> ListContestant_Shift = new List<CONTESTANTS_SHIFTS>();

        CONTEST kithi;

        private bool XepLichThanhCong = true; // true - thanh cong, false - that bai

        #region constructor
        public XepLich(CONTEST _kithi)
        {
            kithi = _kithi;
            DAO.DBService.Reload();
            XepLichThanhCong = false;
        }
        #endregion

        #region phương thức

        private void Input(int type)
        {
            // lấy dữ liệu đầu vào từ database
            ListContestant = (
                                from ts in db.CONTESTANTS
                                from tt in db.REGISTERS
                                where ts.Status > 0
                                where tt.Status > 0
                                where ts.RegisterID == tt.RegisterID
                                where tt.ContestID == kithi.ContestID
                                select ts
                             ).ToList();

            ListRoomTest = (
                                from rt in db.ROOMTESTS
                                from dd in db.LOCATIONS
                                where rt.Status > 0
                                where dd.Status > 0
                                where rt.LocationID == dd.LocationID
                                where dd.ContestID == kithi.ContestID
                                select rt
                            ).ToList();

            ListShift = db.SHIFTS
                        .Where(p => p.ContestID == kithi.ContestID && p.Status != 0)
                        .OrderBy(p => p.ShiftDate)
                        .ToList();
            ListSchedule = db.SCHEDULES.Where(p => p.ContestID == kithi.ContestID && p.Status != 0).ToList();

            if (type == 0)
            {
                ListContestant_Subject = (
                                            from tt in db.REGISTERS.Where(p => p.Status > 0 && p.ContestID == kithi.ContestID)
                                            from ts in db.CONTESTANTS.Where(p => p.Status > 0 && p.RegisterID == tt.RegisterID).ToList()
                                            from mt in db.CONTESTANTS_SUBJECTS.Where(p => p.Status > 0 && p.ContestantID == ts.ContestantID).ToList()
                                            select mt
                                         )
                                         .OrderBy(p => p.ContestantID)
                                         .ToList();
            }
            else
            {
                ListContestant_Subject = (
                                            from tt in db.REGISTERS.Where(p =>p.Status>0 && p.ContestID == kithi.ContestID)
                                            from ts in db.CONTESTANTS.Where(p => p.Status > 0 && p.RegisterID == tt.RegisterID).ToList()
                                            from mt in db.CONTESTANTS_SUBJECTS.Where(p => p.Status > 0 && p.ContestantID == ts.ContestantID).ToList()
                                            select mt
                                         )
                                         .OrderByDescending(p => p.SubjectID)
                                         .ToList();
            }

            ListShift = ListShift.OrderBy(p => p.ShiftDate).ToList();
        }

        private void Output()
        {
            //  Ghi kết quả ra database

            foreach (CONTESTANTS_SHIFTS item in ListContestant_Shift)
                db.CONTESTANTS_SHIFTS.Add(item);
            db.SaveChanges();
        }

        List<int>[] dsMonThi = new List<int>[1111];

        /*private void SapXepTheoMonThi()
        {
            // Lấy ra danh sách thí sinh của từng môn thi
            for (int i = 0; i < ListSchedule.Count; i++)
            {
                List<int> dahsa = new List<int>();
                //dsMonThi[i].Clear();

                int k = ListSchedule[i].SubjectID;
                for (int j = 0; j < ListContestant_Subject.Count; j++)
                {
                    Contestant_SubjectDTO a = ListContestant_Subject[j];
                    if (a.SubjectID == k) dahsa.Add(a.ContestantID);
                }

                dsMonThi[i] = dahsa;
            }

            // Xếp các thí sinh của từng môn vào các ca thi
            int iCaThi = 0;

            for (int i = 0; i < ListSchedule.Count; i++)
            {
                int SoLuongThiSinhCuaMonThi = dsMonThi[i].Count;
                int iThiSinh = 0;
                while (SoLuongThiSinhCuaMonThi > 0)
                {
                    // xếp các thí sinh vào ca thi số iCaThi
                    for (int j = 0; j < ListRoomTest.Count; j++)
                    {
                        Division_ShiftDTO di = new Division_ShiftDTO();
                        try
                        {

                            di.ShiftID = ListShift[iCaThi].ShiftID;
                            di.Status = 1;
                            di.RoomTestID = ListRoomTest[j].RoomTestID;
                            di.DivisionShiftID = DAO.Division_ShiftDAO.Insert(di);
                        }
                        catch
                        {
                            XepLichThanhCong = false;
                            return;
                        }

                        // xếp các thí sinh tiếp theo vào phòng thi j
                        int soluong = (ListRoomTest[j].MaxSeatMount * 9) / 10;
                        for (int vitri = 1; vitri <= soluong; vitri++)
                        {
                            //xếp thí sinh tiếp theo vào vị trí

                            Contestants_ShiftDTO ct = new Contestants_ShiftDTO();
                            ct.ScheduleID = ListSchedule[i].ScheduleID;
                            ct.ContestantID = dsMonThi[i][iThiSinh];
                            ct.ShiftID = di.DivisionShiftID;
                            ct.Status = 1;
                            ListContestant_Shift.Add(ct);

                            // cập nhật lại trạng thái của các biến
                            SoLuongThiSinhCuaMonThi--;
                            iThiSinh++;

                            if (SoLuongThiSinhCuaMonThi <= 0) break;
                        }

                    }
                    iCaThi++;
                }
            }
        }*/
        private void Solve()
        {
            //SapXepTheoMonThi();

            // 25/07/2017
            // tao list DivisionShift
            foreach (ROOMTEST pt in ListRoomTest)
                foreach (SHIFT ct in ListShift)
                {
                    DIVISION_SHIFTS tg = db.DIVISION_SHIFTS.Where(p => p.Status > 0 && p.RoomTestID == pt.RoomTestID && p.ShiftID == ct.ShiftID)
                                           .FirstOrDefault();
                    if (tg != null) continue;
                    DIVISION_SHIFTS dv = new DIVISION_SHIFTS();
                    dv.RoomTestID = pt.RoomTestID;
                    dv.ShiftID = ct.ShiftID;
                    dv.Status = 1;
                    db.DIVISION_SHIFTS.Add(dv);
                    db.SaveChanges();
                }
            ListDivition_Shift = db.DIVISION_SHIFTS.Where(p => p.Status > 0)
                                 .Where(p => db.SHIFTS.Where(ctg => ctg.ShiftID == p.ShiftID).FirstOrDefault().ContestID == kithi.ContestID)
                                 .OrderBy(p => db.SHIFTS.Where(ctg => ctg.ShiftID == p.ShiftID).FirstOrDefault().ShiftDate)
                                 .ToList();

            // xep lich
            int cnt = ListContestant_Subject.Count;

            if (cnt == 0) return;

            List<bool> DaSapXep = new List<bool>();

            for (int i = 1; i <= cnt; i++)
            {
                bool a = true;
                DaSapXep.Add(a);
            }

            int iThiSinh = 0;
            int iShift = 0;
            while (cnt > 0)
            {
                SHIFT shift;
                try
                {
                    shift = ListShift[iShift];
                }
                catch
                {
                    MessageBox.Show("Không đủ ca thi để xếp lịch", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.SaveChanges();
                    return;
                }

                int iRoomTest = 0;
                while (iRoomTest < ListRoomTest.Count)
                {
                    int SoChoNgoi = ListRoomTest[iRoomTest].MaxSeatMount * 9 / 10;
                    ROOMTEST roomtest = ListRoomTest[iRoomTest];

                    for (int vitri = 0; vitri < SoChoNgoi; vitri++)
                    {
                        int bd = iThiSinh;
                        while (cnt > 0)
                        {
                            CONTESTANTS_SUBJECTS ts = ListContestant_Subject[iThiSinh];
                            // tim thi sinh thoa man de them vao lich thi

                            // kiem tra them thi sinh vao co thoa man k
                            int a = (from ct in ListContestant_Shift
                                     from dv in ListDivition_Shift
                                     where ct.ShiftID == dv.DivisionShiftID
                                     where ct.ContestantID == ts.ContestantID
                                     where dv.ShiftID == shift.ShiftID
                                     select ct)
                                     .ToList().Count;
                            if (a > 0 || DaSapXep[iThiSinh] == false)
                            {
                                // thi sinh nay dc them vao ca thi nay hoac da duco xep
                                iThiSinh = (iThiSinh + 1) % DaSapXep.Count;
                                if (iThiSinh == bd) break;
                                continue;
                            }

                            // them contestant
                            CONTESTANTS_SHIFTS cts = new CONTESTANTS_SHIFTS();
                            cts.ContestantID = (int)ts.ContestantID;
                            try
                            {
                                cts.ShiftID = (
                                                from dv in ListDivition_Shift
                                                where dv.ShiftID == shift.ShiftID
                                                where dv.RoomTestID == roomtest.RoomTestID
                                                select dv
                                              )
                                              .FirstOrDefault().DivisionShiftID;
                            }
                            catch { }
                            try
                            {
                                cts.ScheduleID = (from sc in ListSchedule
                                                  where sc.SubjectID == ts.SubjectID
                                                  select sc
                                                 )
                                                 .FirstOrDefault().ScheduleID;
                            }
                            catch { }
                            cts.Status = 1;


                            // cap nhat trang thai la da xep lich i thi sinh
                            ListContestant_Shift.Add(cts);
                            db.CONTESTANTS_SHIFTS.Add(cts);

                            DaSapXep[iThiSinh] = false;
                            cnt--;

                            // neu them thi sinh vao thoa man thi them
                            iThiSinh = (iThiSinh + 1) % DaSapXep.Count;

                            if (cnt == 0)
                            {
                                XepLichThanhCong = true;
                                return;
                            }

                            break;
                        }
                    }

                    iRoomTest++;
                }

                iShift++;
            }

            db.SaveChanges();
            XepLichThanhCong = true;

        }

        private void XoaLichThi()
        {
            foreach (DIVISION_SHIFTS dv in ListDivition_Shift)
                db.CONTESTANTS_SHIFTS.RemoveRange(db.CONTESTANTS_SHIFTS.Where(p => p.ShiftID == dv.DivisionShiftID));

            db.SaveChanges();
            return;
        }

        public int Run(int type)
        {
            // type == 1 xep theo mon thi
            // type == 0 xep theo thi sinh
            Input(type);
            Solve();


            if (!XepLichThanhCong)
            {
                if (ListContestant.Count == 0)
                {
                    MessageBox.Show("Kì thi không có thí sinh đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    if (ListContestant_Subject.Count == 0)
                {
                    MessageBox.Show("Các thí sinh chưa đăng ký môn thi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                XoaLichThi();
                return 0;
            }

            return 1;
        }

        #endregion

    }
}
