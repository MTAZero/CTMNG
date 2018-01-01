using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zero.SinhDuLieuTuDong.Data;

namespace Zero.SinhDuLieuTuDong
{
    internal static class Helper
    {
        internal static void XoaDuLieuDangKy(CONTEST kithi)
        {
            try
            {
                ExonSystem db = new ExonSystem();
                kithi = db.CONTESTS.Where(p => p.ContestID == kithi.ContestID).FirstOrDefault();

                /// Xóa contestant Shift
                db.CONTESTANTS_SHIFTS.RemoveRange(
                                            (
                                                from dk in db.REGISTERS.Where(p => p.ContestID == kithi.ContestID).ToList()
                                                from ts in db.CONTESTANTS.Where(p => p.RegisterID == dk.RegisterID).ToList()
                                                from lt in db.CONTESTANTS_SHIFTS.Where(p => p.ContestantID == ts.ContestantID).ToList()
                                                select lt
                                            )
                                            .ToList()
                                         );
                db.SaveChanges();

                /// Xóa division Shift
                db.DIVISION_SHIFTS.RemoveRange(
                                                    (
                                                        from ct in db.SHIFTS.Where(p=>p.ContestID == kithi.ContestID).ToList()
                                                        from dv in db.DIVISION_SHIFTS.Where(p=>p.ShiftID == ct.ShiftID).ToList()
                                                        select dv
                                                    )
                                                    .ToList()
                                               );


                /// Xóa Contestant Subject
                db.CONTESTANTS_SUBJECTS.RemoveRange(
                                                      (
                                                            from dk in db.REGISTERS.Where(p => p.ContestID == kithi.ContestID).ToList()
                                                            from ts in db.CONTESTANTS.Where(p => p.RegisterID == dk.RegisterID).ToList()
                                                            from mt in db.CONTESTANTS_SUBJECTS.Where(p=>p.ContestantID == ts.ContestantID).ToList()
                                                            select mt
                                                      )
                                                      .ToList()
                                                 );

                /// Xóa Regiter Subject
                db.REGISTERS_SUBJECTS.RemoveRange(
                                                      (
                                                            from dk in db.REGISTERS.Where(p => p.ContestID == kithi.ContestID).ToList()
                                                            from mt in db.REGISTERS_SUBJECTS.Where(p => p.RegisterID == dk.RegisterID).ToList()
                                                            select mt
                                                      )
                                                      .ToList()
                                                 );

                /// Xóa contestant
                db.CONTESTANTS.RemoveRange(
                                            (
                                                from dk in db.REGISTERS.Where(p => p.ContestID == kithi.ContestID).ToList()
                                                from ts in db.CONTESTANTS.Where(p => p.RegisterID == dk.RegisterID).ToList()
                                                select ts
                                            )
                                            .ToList()
                                         );
                db.SaveChanges();

                /// Xóa Register
                db.REGISTERS.RemoveRange(db.REGISTERS.Where(p => p.ContestID == kithi.ContestID));
                db.SaveChanges();



                /// Chuyển trạng thái về đã phê duyệt
                kithi.Status = 1;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }

        internal static void SinhDuLieuDangKy(CONTEST kithi, int SoThiSinh, int SoMonThiThiSinh, string TienToTenTS)
        {
            ExonSystem db = new ExonSystem();
            kithi = db.CONTESTS.Where(p => p.ContestID == kithi.ContestID).FirstOrDefault();


            /// chuyển trạng thái sang là đã đăng ký thành công
            kithi.Status = 4;
            db.SaveChanges();

        }
    }
}
