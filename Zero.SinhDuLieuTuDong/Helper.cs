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
                                                        from ct in db.SHIFTS.Where(p => p.ContestID == kithi.ContestID).ToList()
                                                        from dv in db.DIVISION_SHIFTS.Where(p => p.ShiftID == ct.ShiftID).ToList()
                                                        select dv
                                                    )
                                                    .ToList()
                                               );
                db.SaveChanges();

                /// Xóa Contestant Subject
                db.CONTESTANTS_SUBJECTS.RemoveRange(
                                                      (
                                                            from dk in db.REGISTERS.Where(p => p.ContestID == kithi.ContestID).ToList()
                                                            from ts in db.CONTESTANTS.Where(p => p.RegisterID == dk.RegisterID).ToList()
                                                            from mt in db.CONTESTANTS_SUBJECTS.Where(p => p.ContestantID == ts.ContestantID).ToList()
                                                            select mt
                                                      )
                                                      .ToList()
                                                 );
                db.SaveChanges();

                /// Xóa Regiter Subject
                db.REGISTERS_SUBJECTS.RemoveRange(
                                                      (
                                                            from dk in db.REGISTERS.Where(p => p.ContestID == kithi.ContestID).ToList()
                                                            from mt in db.REGISTERS_SUBJECTS.Where(p => p.RegisterID == dk.RegisterID).ToList()
                                                            select mt
                                                      )
                                                      .ToList()
                                                 );
                db.SaveChanges();

                /// Xóa Receipt
                db.RECEIPTS.RemoveRange(
                                                (
                                                            from dk in db.REGISTERS.Where(p => p.ContestID == kithi.ContestID).ToList()
                                                            from rc in db.RECEIPTS.Where(p => p.RegisterID == dk.RegisterID).ToList()
                                                            select rc
                                                      )
                                                      .ToList()
                                            );
                db.SaveChanges();

                /// Xóa finger Print
                db.FINGERPRINTS.RemoveRange(
                                                (
                                                            from dk in db.REGISTERS.Where(p => p.ContestID == kithi.ContestID).ToList()
                                                            from ts in db.CONTESTANTS.Where(p => p.RegisterID == dk.RegisterID).ToList()
                                                            from vt in db.FINGERPRINTS.Where(p => p.ContestantID == ts.ContestantID).ToList()
                                                            select vt
                                                      )
                                                      .ToList()
                                            );
                db.SaveChanges();

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

        private static REGISTER newRegister()
        {
            REGISTER dk = new REGISTER();

            dk.DOB = 0;
            dk.CurrentAddress = "";
            dk.Email = "";
            dk.Ethnic = "";
            dk.HighSchool = "";
            dk.IdentityCardNumber = "";
            dk.Status = 1;
            return dk;
        }


        private static bool[] kt = new bool[1000];
        internal static void SinhDuLieuDangKy(CONTEST kithi, int SoThiSinh, int SoMonThiThiSinh, string TienToTenTS)
        {

            try
            {
                ExonSystem db = new ExonSystem();
                kithi = db.CONTESTS.Where(p => p.ContestID == kithi.ContestID).FirstOrDefault();


                for (int index = 1; index <= SoThiSinh; index++)
                {

                    /// Thêm register
                    REGISTER dk = newRegister();
                    dk.FullName = TienToTenTS + " " + index;
                    dk.ContestID = kithi.ContestID;
                    db.REGISTERS.Add(dk);
                    db.SaveChanges();

                    /// Thêm contestant
                    CONTESTANT ct = new CONTESTANT();
                    ct.RegisterID = dk.RegisterID;
                    ct.Status = 1;
                    ct.ContestantCode = "KQH" + kithi.ContestID.ToString() + index;
                    db.CONTESTANTS.Add(ct);
                    db.SaveChanges();

                    /// Thêm Register Subject

                    var listMonThi = db.SCHEDULES.Where(p => p.ContestID == kithi.ContestID && p.Status > 0).ToList();
                   
                    for (int jx = 1; jx <= SoMonThiThiSinh; jx++)
                    {
                        for (int j = 0; j <= 999; j++) kt[j] = true;

                        Random rd = new Random();

                        while (true)
                        {
                            int stt = rd.Next(0, listMonThi.Count );

                            if (kt[stt] == true)
                            {
                                kt[stt] = false;

                                REGISTERS_SUBJECTS rs = new REGISTERS_SUBJECTS();
                                rs.RegisterID = dk.RegisterID;
                                rs.SubjectID = listMonThi[stt].SubjectID;
                                rs.Status = 1;
                                db.REGISTERS_SUBJECTS.Add(rs);
                                db.SaveChanges();

                                CONTESTANTS_SUBJECTS tsdk = new CONTESTANTS_SUBJECTS();
                                tsdk.Status = 1;
                                tsdk.ContestantID = ct.ContestantID;
                                tsdk.SubjectID = listMonThi[stt].SubjectID;
                                db.CONTESTANTS_SUBJECTS.Add(tsdk);
                                db.SaveChanges();

                                break;
                            }
                        }
                    }


                }

                /// chuyển trạng thái sang là đã đăng ký thành công
                kithi.Status = 4;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
