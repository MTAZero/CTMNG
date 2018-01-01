using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Persistance;
using CL.Services.Interface;
using CL.Services;
namespace CL.Services.Impl
{
    public partial class SupervisorService : ISupervisorService
    {

        public MTAQuizEntities Db = new MTAQuizEntities();

        public SupervisorService()
        {
            //if (Db == null)

        }
        #region RoomTest
        public string GetNameRoomTest(  int RoomTestID)
        {
            Db = new MTAQuizEntities();
            ROOMTEST rt = new ROOMTEST();
            string result="";
            try
            {
                rt = Db.ROOMTESTS.Where(x => x.RoomTestID == RoomTestID).FirstOrDefault();
                result = rt.RoomTestName;
                return result;
            }
            catch {
                return result;
            }
        }
        public ROOMTEST GetRoom(int roomID)
        {
            ROOMTEST result = new ROOMTEST();
            Db = new MTAQuizEntities();

            try
            {
                result = Db.ROOMTESTS.Where(x => x.RoomTestID == roomID).FirstOrDefault();
                return result;
            }
            catch
            {
                return new ROOMTEST();
            }

        }

        #endregion


        #region Roodiagram


        // UPDATE ROOMDIA
        public bool UpdateRoomDia(ROOMDIAGRAM roomDia)
        {
            ROOMDIAGRAM result = new ROOMDIAGRAM();
            Db = new MTAQuizEntities();
            try
            {
                result = Db.ROOMDIAGRAMS.Where(x => x.RoomDiagramID == roomDia.RoomDiagramID).FirstOrDefault();
                if (result != null)
                {
                    result.Status = roomDia.Status;
                    Db.SaveChanges();
                }
                else
                    return false;

                return true;
            }
            catch
            {
                return false;
            }

        }

        // Lấy danh sách mã vị trí ngồi theo phòng thi
        public List<int> ListRoomDiaID(int roomTestID)
        {
            List<int> result = new List<int>();
            Db = new MTAQuizEntities();

            try
            {
                result = (from obj in Db.ROOMDIAGRAMS
                          where obj.RoomTestID == roomTestID && obj.Status == 4001
                          select obj.RoomDiagramID).ToList();
                return result;
            }
            catch
            {
                return new List<int>();
            }

        }
        public ROOMDIAGRAM GetInfoRoomDia(int roomDiaID)
        {
            ROOMDIAGRAM result;
            result = new ROOMDIAGRAM();
            Db = new MTAQuizEntities();

            try
            {
                result = Db.ROOMDIAGRAMS.Where(x => x.RoomDiagramID == roomDiaID).FirstOrDefault();
                return result;
            }
            catch
            {
                return result;
            }

        }
        public int GetStatusDivisionShift(int _divisionShiftID)
        {
            Db = new MTAQuizEntities();
            DIVISION_SHIFTS ds = new DIVISION_SHIFTS();
            try
            {
                int status;
                status = (from obj in Db.DIVISION_SHIFTS
                          where obj.DivisionShiftID == _divisionShiftID
                          select obj.Status).FirstOrDefault();
                return status;
            }
            catch
            {
                return -1;
            }
        }
        public bool UpdateRoomdiagram(int roomtestID, string computername, int status)
        {
            Db = new MTAQuizEntities();
            ROOMDIAGRAM rd = new ROOMDIAGRAM();
            ROOMTEST rt = new ROOMTEST();
            try
            {
                rd = Db.ROOMDIAGRAMS.Single(x => x.ComputerName == computername && x.RoomTestID==roomtestID);
                rt = Db.ROOMTESTS.Single(x => x.RoomTestID == roomtestID);
              
                rd.Status = status;
                Db.Entry(rd).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }
        public bool AddRoomdiagram(int roomtestID, string computername, string computercode , int status)
        {
            Db = new MTAQuizEntities();
            ROOMDIAGRAM rd = new ROOMDIAGRAM();
            try
            {
                rd.ComputerName = computername;
                rd.ComputerCode = computercode;
                rd.Status = status;
                rd.RoomTestID = roomtestID;
                if (Db.ROOMDIAGRAMS.Where(x => x.ComputerName == computername).SingleOrDefault() == null)
                {
                    Db.ROOMDIAGRAMS.Add(rd);
                    Db.SaveChanges();

                    return true;
                }
                else { return false; }
            }
            catch
            {
                return false;
            }
        }

        public List<ROOMDIAGRAM> GetListRoomdiagram(int roomtestID)
        {
            List<ROOMDIAGRAM> result = new List<ROOMDIAGRAM>();
            Db = new MTAQuizEntities();
            {
                try
                {
                    result = (from obj in Db.ROOMDIAGRAMS
                              where obj.RoomTestID == roomtestID
                              select obj).ToList();


                    return result.OrderBy(x => x.RoomDiagramID).ToList();
                }
                catch (Exception ex)
                {
                    return result;
                }
            }

        }
        #region xếp chỗ

        public List<ROOMDIAGRAM> GetListComputerOfRoom(int roomTestID) // lấy tất cả các máy còn đang hoạt động được
        {
            List<ROOMDIAGRAM> result = new List<ROOMDIAGRAM>();
            Db = new MTAQuizEntities();

            try
            {
                result = (from obj in Db.ROOMDIAGRAMS
                          where obj.RoomTestID == roomTestID && obj.Status == 4001
                          select obj).ToList();
                return result;
            }
            catch
            {
                return new List<ROOMDIAGRAM>();
            }

        }
        #endregion

        public ROOMDIAGRAM GetRoomDia(string comName)
        {
            ROOMDIAGRAM result = new ROOMDIAGRAM();
            Db = new MTAQuizEntities();

            try
            {
                result = Db.ROOMDIAGRAMS.Where(x => x.ComputerName == comName).FirstOrDefault();
                return result;
            }
            catch
            {
                return new ROOMDIAGRAM();
            }

        }
        #endregion


        #region Staff And supervisor

        public STAFF GetStaff(int supervisorID)
        {
            try
            {
                STAFF staff = Db.STAFFS.Where(x => x.StaffID == supervisorID).FirstOrDefault();
                return staff;
            }
            catch
            {
                return new STAFF();
            }
        }
        public EXAMINATIONCOUNCIL_STAFFS GetInfoSupervisor(int _staffID)
        {
            Db = new MTAQuizEntities();
            /////// note
            try
            {
                EXAMINATIONCOUNCIL_STAFFS ex = (from x in Db.EXAMINATIONCOUNCIL_STAFFS
                                                where (x.StaffID==_staffID)
                                                select x).FirstOrDefault();
                return ex;
            }
            catch
            {
                return new EXAMINATIONCOUNCIL_STAFFS();
            }

        }
        #endregion

        #region Shift
        public SHIFT GetShiftByID(int shiftID)

        {
            SHIFT result = new SHIFT();
            Db = new MTAQuizEntities();
            try
            {
                result = (from obj in Db.SHIFTS
                          where obj.ShiftID == shiftID
                          select obj).FirstOrDefault();
                return result;
            }
            catch

            {
                return result;
            }

        }
        public SHIFT GetShift(int shiftID)
        {
            SHIFT shift = new SHIFT();
            Db = new MTAQuizEntities();
            {
                try
                {
                    shift = new SHIFT();
                    shift = Db.SHIFTS.Where(x => x.ShiftID == shiftID).FirstOrDefault();
                    return shift;
                }
                catch
                {
                    return new SHIFT();
                }
            }
        }
        // hiển thị danh sách các ca thi có starttime gần nhất với hiện tại khoảng 45 '
        public List<SHIFT> GetListShift(int timeNow, int DIF_TIME)
        {
            List<SHIFT> result = new List<SHIFT>();
            Db = new MTAQuizEntities();

            try
            {
                result = (from obj in Db.SHIFTS
                          where (timeNow > (obj.StartTime - DIF_TIME) && (timeNow < obj.EndTime))   // where (obj.StartTime - timeNow < DIF_TIME || (obj.StartTime ))
                          select obj).ToList();
                return result;
            }
            catch
            {
                return new List<SHIFT>();
            }

        }
        public SHIFT GetShiftNow(int TimeNow, int logTime, int difTime, int SupervisorID)
        {
            SHIFT result = new SHIFT();
            Db = new MTAQuizEntities();
            {

                try
                {
                    result = (from obj in Db.SHIFTS
                              from obj2 in Db.DIVISIONSHIFT_SUPERVISOR
                              where /*((int)(logTime / 86400) == (int)(obj.ShiftDate / 86400)) &&*/ (TimeNow + difTime > obj.StartTime) && TimeNow < obj.EndTime && obj2.DIVISION_SHIFTS.ShiftID == obj.ShiftID && (obj2.SupervisorID == SupervisorID)
                              select obj).FirstOrDefault();
                    return result;
                }

                catch (Exception ex)
                { return result; }
            }
        }
        public ROOMTEST GetRoomTestByShiftAndContestant(int contestantID,int shiftID)
        {
            ROOMTEST room = new ROOMTEST();
            CONTESTANTS_SHIFTS conshift = new CONTESTANTS_SHIFTS();
            Db = new MTAQuizEntities();
            {
                try
                {
                    conshift = Db.CONTESTANTS_SHIFTS.Where(x => x.DIVISION_SHIFTS.ShiftID == shiftID && x.ContestantID==contestantID).FirstOrDefault();
                    return conshift.ROOMDIAGRAM.ROOMTEST;
                    //return conshift.r
                }
                catch
                {
                    return new ROOMTEST();
                }
            }
        }

        // DIF_TIME_OPEN Là khoảng thời gian có thể truy cập vào ca thi để điều hành,
        // hay đó chính là thời gian chuẩn bị để thí sinh có thể bắt đầu làm bài thi
        // thông thường là khoảng 30' hoặc 15 phút để gọi thí sinh vao phòng thi ... bla blo
        // vậy giám thị chỉ có thể điều hành vào ca đó lúc trước 30' hoặc 15 ' tùy theo mình định nghĩa
        public bool CheckShowShift(int shiftID, int timeNow, int DIF_TIME_OPEN)
        {

            try
            {
                SHIFT shift = GetShift(shiftID);
                //  if (shift.StartTime > 0 && (timeNow > shift.StartTime - DIF_TIME_OPEN) && (timeNow < shift.StartTime)) ;
                // hiện tại thì mình cứ cho truy cập trong khoảng thời gian ca thi đang diễn ra cũng được
                if ((shift.StartTime > 0) && (timeNow > (shift.StartTime - DIF_TIME_OPEN)) && (timeNow < shift.EndTime))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion


        #region Login
        public bool CheckLogin(string user, string pass, out int per)
        {
            /// chay thu
            per = -1;
            Db = new MTAQuizEntities();
            {
                try
                {
                    // đặt mặc định permisstion là bao nhiêu.
                    var staffList = (from obj in Db.EXAMINATIONCOUNCIL_STAFFS
                                     from obj3 in Db.DIVISIONSHIFT_SUPERVISOR
                                     where ((obj.StaffID == obj3.SupervisorID) && (obj.UserName.Contains(user) && (obj.Password == pass)))
                                     select new { obj }).ToList();
                    if (staffList == null || staffList.Count == 0)
                        return false;
                    else
                        return true;
                }
                catch (Exception ex)
                {
                    string a = ex.Message;
                    return false;
                }
            }
        }
        #endregion

        #region Contestant
        public CONTESTANT GetInfoContestant(int contestantID)
        {
            CONTESTANT result = new CONTESTANT();
            Db = new MTAQuizEntities();
            
                try
                {
                    result = Db.CONTESTANTS.Where(x => x.ContestantID == contestantID).FirstOrDefault();
                    return result;
                }
                catch
                {
                    return new CONTESTANT();
                }
           
        }
        public List<CONTESTANT> GetlistContestant(int divisionShiftID)
        {
            List<CONTESTANT> result = new List<CONTESTANT>();
            Db = new MTAQuizEntities();

            try
            {
                var listContestantID = (from obj in Db.CONTESTANTS_SHIFTS
                                        where obj.DivisionShiftID == divisionShiftID
                                        select obj.ContestantID).ToList();
                result = (from obj in Db.CONTESTANTS
                          where listContestantID.Contains(obj.ContestantID)
                          select obj).ToList();
                return result;
            }
            catch
            {
                return result;
            }

        }
        public List<CONTESTANT> GetlistContestantByShitfID(int ShiftID)
        {
            List<CONTESTANT> result = new List<CONTESTANT>();
            Db = new MTAQuizEntities();

            try
            {
                var listContestantID = (from obj in Db.CONTESTANTS_SHIFTS
                                        where obj.DIVISION_SHIFTS.ShiftID == ShiftID
                                        select obj.ContestantID).ToList();
                result = (from obj in Db.CONTESTANTS
                          where listContestantID.Contains(obj.ContestantID)
                          select obj).ToList();
                return result;
            }
            catch
            {
                return result;
            }

        }
        public CONTESTANT GetContestantByContestanShiftID(int contestantShiftID)
        {
            CONTESTANT result = new CONTESTANT();
            Db = new MTAQuizEntities();
            CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
            try
            {
                cs = Db.CONTESTANTS_SHIFTS.Where(x => x.ContestantShiftID == contestantShiftID).SingleOrDefault();
                result = Db.CONTESTANTS.Where(x => x.ContestantID == cs.ContestantID).SingleOrDefault();
                return result;
            }
            catch
            {
                return new CONTESTANT();
            }
        }
        
        // Lấy thông tin thí sinh qua contestantCode hoặc cmt, hoặc số thẻ sv
        public CONTESTANT GetContestant(string contestantVerify)
        {
            CONTESTANT result = new CONTESTANT();
            Db = new MTAQuizEntities();

            try
            {
                result = (from obj in Db.CONTESTANTS
                          where (obj.ContestantID == Convert.ToInt32(contestantVerify) || obj.ContestantCode == contestantVerify || obj.IdentityCardNumber == contestantVerify)
                          select obj).FirstOrDefault();
                return result;
            }
            catch
            {
                return new CONTESTANT();
            }

        }
        public bool UpdateContestant(CONTESTANT contestant)
        {
            CONTESTANT result; 
            Db = new MTAQuizEntities();

            try
            {
                result = Db.CONTESTANTS.Where(x => x.ContestantID == contestant.ContestantID).FirstOrDefault();
                if(result!=null)
                {
                    result.FullName = contestant.FullName;
                    result.DOB = contestant.DOB;
                    result.Sex = contestant.Sex;
                    result.Image = contestant.Image;
                    Db.SaveChanges();
                    List<CONTESTANTS_SHIFTS> lstCon = result.CONTESTANTS_SHIFTS.Where(x => x.Status < 2000).ToList();
                    if (lstCon != null)
                    {
                        foreach (CONTESTANTS_SHIFTS item in lstCon)
                        {
                            CONTESTANTS_SHIFTS conshift = Db.CONTESTANTS_SHIFTS.Where(x => x.ContestantShiftID == item.ContestantShiftID).FirstOrDefault();
                            if (conshift != null)
                            {
                                if (conshift.Status == 1000)
                                {
                                    conshift.Status = 1002;
                                }
                                else if(conshift.Status == 1001)
                                {
                                    conshift.Status = 1003;
                                } else conshift.Status = 1002;
                                Db.SaveChanges();
                            }
                        }
                        return true;
                    }
                    else return false;
                }
                return false;
            }
            catch
            {
                return false;
            }

        }
        #endregion


        #region Violation
        public List<VIOLATION> GetListViolation()
        {

            List<VIOLATION> result = new List<VIOLATION>();
            Db = new MTAQuizEntities();
            
                try
                {
                    result = Db.VIOLATIONS.Where(x => x.Status == 1).ToList();
                    return result;
                }
                catch
                {
                    return new List<VIOLATION>();
                }
            
        }
        public int CountTimesViolation(int contestantShiftID)
        {
            List<VIOLATIONS_CONTESTANTS> result = new List<VIOLATIONS_CONTESTANTS>();
            Db = new MTAQuizEntities();

            int count = -1;
            try
            {
                result = (from obj in Db.VIOLATIONS_CONTESTANTS
                          where (obj.ContestantShiftID == contestantShiftID)
                          select obj).ToList();
                count = result.Count;
                return count;
            }
            catch
            {
                return count;
            }

        }
        #endregion


        #region DivisionShift
        public DIVISION_SHIFTS GetDivisionShift(int shiftID)
        {
            DIVISION_SHIFTS result = new DIVISION_SHIFTS();
            Db = new MTAQuizEntities();
           
                try
                {
                    result = Db.DIVISION_SHIFTS.Where(x => x.ShiftID == shiftID).FirstOrDefault();
                    return result;
                }
                catch
                {
                    return new DIVISION_SHIFTS();
                }
            
        }

        public DIVISION_SHIFTS GetDivisionShift(int shiftID, int roomID)
        {
            DIVISION_SHIFTS result = new DIVISION_SHIFTS();
            Db = new MTAQuizEntities();
            {
                try
                {
                    result = (from obj in Db.DIVISION_SHIFTS
                              where obj.ShiftID == shiftID && obj.RoomTestID == roomID
                              select obj).FirstOrDefault();
                    return result;
                }
                catch
                {
                    return result;
                }
            }
        }

        public DIVISION_SHIFTS GetDivisionShiftByID(int divisionShiftID)
        {
            DIVISION_SHIFTS result = new DIVISION_SHIFTS();
            Db = new MTAQuizEntities();
            {
                try
                {
                    result = (from obj in Db.DIVISION_SHIFTS
                              where obj.DivisionShiftID == divisionShiftID
                              select obj).FirstOrDefault();
                    return result;
                }
                catch
                {
                    return result;
                }
            }
        }

        //
        public bool UpdateStatusDivisionShift(int _divisionShiftID,int _status)
        {
            DIVISION_SHIFTS ds = new DIVISION_SHIFTS();
            Db = new MTAQuizEntities();
            try
            {
                ds = Db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == _divisionShiftID).FirstOrDefault();
                ds.Status = _status;
                    
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion



        #region ContestantShift

        // Lấy danh sách contestantshiftID divisionShift hiện tại
        public List<int> ListContestantShiftIDInTestExist(int divisionShiftID)
        {
            List<int> result = new List<int>();
            Db = new MTAQuizEntities();

            try
            {
                result = (from obj in Db.CONTESTANTS_SHIFTS
                          where obj.DivisionShiftID == divisionShiftID
                          select obj.ContestantShiftID).ToList();

                return result;
            }
            catch
            {
                return new List<int>();
            }

        }

        /// <summary>
        /// lấy danh sách thí sinh theo từng schedule <=> môn của ca đó
        /// </summary>
        /// <param name="divisionShiftID"></param>
        /// <param name="scheduleID"></param>
        /// <returns></returns>

        public List<int> ListContestantShiftIDForScheduleOfShift(int divisionShiftID, int scheduleID)
        {
            List<int> result = new List<int>();
            Db = new MTAQuizEntities();

            try
            {
                result = (from obj in Db.CONTESTANTS_SHIFTS
                          where (obj.DivisionShiftID == divisionShiftID) && (obj.ScheduleID == scheduleID) 
                          select obj.ContestantShiftID).ToList();
                return result;
            }
            catch
            {
                return new List<int>();
            }

        }

        //lấy danh sách thí sinh đã check vân tay thành công và được vào phòng thi, mình có thể kiểm tra điều kiện thời gian nó điểm danh trong ca thi hay ngoài ca thi
        public List<CONTESTANT> GetlistContestantHasCheckedFP(int divisionShiftID)
        {
            List<CONTESTANT> result = new List<CONTESTANT>();
            Db = new MTAQuizEntities();

            try
            {

                var listContestantID = (from obj in Db.CONTESTANTS_SHIFTS
                                        where obj.DivisionShiftID == divisionShiftID && obj.IsCheckFingerprint == 1
                                        select obj.ContestantID).ToList();
                result = (from obj in Db.CONTESTANTS
                          where listContestantID.Contains(obj.ContestantID)
                          select obj).ToList();
                return result;
            }
            catch
            {
                return new List<CONTESTANT>();
            }

        }
        public CONTESTANTS_SHIFTS GetContestantShift(int contestantShiftID)
        {
            CONTESTANTS_SHIFTS result = new CONTESTANTS_SHIFTS();
            Db = new MTAQuizEntities();

            try
            {
                result = Db.CONTESTANTS_SHIFTS.Where(x => x.ContestantShiftID == contestantShiftID).FirstOrDefault();
                return result;
            }
            catch
            {
                return new CONTESTANTS_SHIFTS();
            }

        }
        // Lấy danh sách contestantShiftId của ca thi
        public List<int> ListContestantShiftID(int divisionShiftID)
        {
            List<int> result = new List<int>();
            Db = new MTAQuizEntities();

            try
            {
                result = (from obj in Db.CONTESTANTS_SHIFTS
                          where obj.DivisionShiftID == divisionShiftID
                          select obj.ContestantShiftID).ToList();
                return result;
            }
            catch
            {
                return new List<int>();
            }

        }
        public CONTESTANTS_SHIFTS GetContestantShift(int divisionShiftID, int contestantD)
        {
            CONTESTANTS_SHIFTS result;
            result = new CONTESTANTS_SHIFTS();
            Db = new MTAQuizEntities();
           
                try
                {

                    result = (from obj in Db.CONTESTANTS_SHIFTS
                              where obj.DivisionShiftID == divisionShiftID && obj.ContestantID == contestantD
                              select obj).FirstOrDefault();
                    return result;
                }
                catch
                {
                    return result;
                }
            
        }
        public bool UpdateContestantShift(CONTESTANTS_SHIFTS contestantShift) // update contestant shift
        {

            using (MTAQuizEntities Db = new MTAQuizEntities())
            {
                using (System.Data.Entity.DbContextTransaction dbtran = Db.Database.BeginTransaction())
                {
                    CONTESTANTS_SHIFTS result;
                    result = new CONTESTANTS_SHIFTS();
                    result = Db.CONTESTANTS_SHIFTS.Where(x => x.ContestantShiftID == contestantShift.ContestantShiftID).FirstOrDefault();
                    try
                    {
                        //System.Console.WriteLine("đã chạy đến đây");

                        if (result != null)
                        {

                            result.ContestantShiftID = contestantShift.ContestantShiftID;
                            result.DivisionShiftID = contestantShift.DivisionShiftID;
                            //????? result.ClientIP = contestantShift.ClientIP;
                            result.ScheduleID = contestantShift.ScheduleID;
                            result.IsCheckFingerprint = contestantShift.IsCheckFingerprint;
                            result.TimeStarted = contestantShift.TimeStarted;
                            result.TimeWorked = contestantShift.TimeWorked;
                            result.TimeCheck = contestantShift.TimeCheck;
                            result.ContestantID = contestantShift.ContestantID;
                            result.RoomDiagramID = contestantShift.RoomDiagramID;
                            result.Status = contestantShift.Status;
                            Db.SaveChanges();
                            dbtran.Commit();

                        }
                        else
                            return false;

                        return true;
                    }
                    catch(Exception ex)
                    {
                        dbtran.Rollback();
                        return false;
                    }
                }
            }

        }
        // Lấy thông tin ContestantShift qua tên máy và ca thi
        public CONTESTANTS_SHIFTS GetContestantShiftByComName(int shiftID, string comName)
        {
            CONTESTANTS_SHIFTS result = new CONTESTANTS_SHIFTS();
            Db = new MTAQuizEntities();

            try
            {
                ROOMDIAGRAM roomDia = GetRoomDia(comName);
                if (roomDia.RoomDiagramID.ToString() != null)
                {
                    result = (from obj in Db.CONTESTANTS_SHIFTS
                              where obj.DivisionShiftID == shiftID && obj.RoomDiagramID == roomDia.RoomDiagramID
                              select obj).FirstOrDefault();
                    return result;
                }
                else
                {
                    return new CONTESTANTS_SHIFTS();
                }
            }
            catch { return new CONTESTANTS_SHIFTS(); }

        }
        #endregion


        #region hỗ trợ form manage



        #endregion

        #region Test


        // Lấy danh sách đề thi của môn thi thuộc 1 ca thi
        public List<int> ListTestIDForSubjectOfShift(int DivisionshiftID, int subjectID)
        {
            List<int> result = new List<int>();
            Db = new MTAQuizEntities();
        
                try
                {
                    
                    // Lấy ra bag of test của ca thi trước

                    BAGOFTEST bag = Db.BAGOFTESTS.Where(x => x.DivisionShiftID == DivisionshiftID).FirstOrDefault();

                    if (bag != null)
                    {
                        result = (from obj in Db.TESTS
                                  where obj.BagOfTestID == bag.BagOfTestID && (obj.SubjectID == subjectID)
                                  select obj.TestID).ToList();
                    }
                    return result;
                }
                catch { return new List<int>(); }
            
        }
        #endregion

        #region CheduleOfShitf 
        // lấy danh sách chi tiết kỳ thi để lấy được danh sách các môn thi có trong ca thi đó
        public List<SCHEDULE> ListScheduleOfShift(int DivisioonshiftID)
        {
            List<SCHEDULE> result = new List<SCHEDULE>();
            Db = new MTAQuizEntities();
          
                try
                {
                    List<int> listScheduleID = (from obj in Db.CONTESTANTS_SHIFTS
                                                where obj.DivisionShiftID == DivisioonshiftID
                                                select obj.ScheduleID).Distinct().ToList();
                    result = new List<SCHEDULE>();
                    if (listScheduleID != null)
                    {
                        result = (from obj in Db.SCHEDULES
                                  where listScheduleID.Contains(obj.ScheduleID)
                                  select obj).ToList();
                    }
                    return result;
                }
                catch { return new List<SCHEDULE>(); }
            
        }
        #endregion

        #region Contestant_test
        // Xóa tất cả các phát đề trước đó nếu bị lỗi và phải phát lại
        public bool DeleteContestantTest(int contestantTestID)
        {
            Db = new MTAQuizEntities();

            try
            {
                Db.CONTESTANTS_TESTS.Remove(Db.CONTESTANTS_TESTS.Where(x => x.ContestantTestID == contestantTestID).FirstOrDefault());
                Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        // LẤY đề thi của thí sinh theo contestantShiftID
        public CONTESTANTS_TESTS GetContestantTest(int contestantShiftID)
        {
            CONTESTANTS_TESTS result = new CONTESTANTS_TESTS();
            Db = new MTAQuizEntities();

            try
            {
                result = (from obj in Db.CONTESTANTS_TESTS
                          where obj.ContestantShiftID == contestantShiftID
                          select obj).FirstOrDefault();
                return result;
            }
            catch { return new CONTESTANTS_TESTS(); }

        }

        // phát đề cho thí sinh
        public bool AddContestantTest(CONTESTANTS_TESTS contestantTest)
        {
            Db = new MTAQuizEntities();
           
                try
                {
                    Db.CONTESTANTS_TESTS.Add(contestantTest);
                    Db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
           
        }

        // Lấy tất cả các phân đề thi 
        public List<CONTESTANTS_TESTS> ListContestantTestExist(int contestantShiftID)
        {
            List<CONTESTANTS_TESTS> result = new List<CONTESTANTS_TESTS>();
            Db = new MTAQuizEntities();
           
                try
                {
                     result = (from obj in Db.CONTESTANTS_TESTS
                                                      where obj.ContestantShiftID == contestantShiftID
                                                      select obj).ToList();

                    return result;
                }
                catch
                {
                    return new List<CONTESTANTS_TESTS>();
                }
            
        }
#endregion
       

       

       
     

        // Kiểm tra trạng thái thí sinh đã login thành công và đang chờ để nhận đề thi
        public bool CheckLoginSuccess(int shiftID, int contestantID)
        {
            try
            {
                List<CONTESTANTS_SHIFTS> result = (from obj in Db.CONTESTANTS_SHIFTS
                                                   where obj.DivisionShiftID == shiftID && obj.ContestantID == contestantID && obj.Status == 3000
                                                   select obj).ToList();
                if (result.Count > 0)
                {
                    return true;
                }
                else
                { return false; }
            }
            catch
            {
                return false;
            }
        }

        // Kiểm tra client đăng nhập đúng ko?
        public bool CheckClientLogin(int divisionShiftID, string contestantCode, string computerName)
        {
            try
            {
                CONTESTANT result = (from obj in Db.CONTESTANTS
                                     where obj.ContestantCode.ToUpper() == contestantCode.ToUpper() || obj.IdentityCardNumber == contestantCode || obj.StudentCode.ToUpper() == contestantCode.ToUpper()
                                     select obj).FirstOrDefault();
                if (result.ContestantID.ToString() != null)
                {
                    CONTESTANTS_SHIFTS contestantShift = GetContestantShift(divisionShiftID, result.ContestantID);
                    if (contestantShift.ContestantShiftID.ToString() != null)
                    {
                        ROOMDIAGRAM roomDia = GetInfoRoomDia(Convert.ToInt32(contestantShift.RoomDiagramID));
                        if (roomDia.RoomDiagramID.ToString() != null)
                        {
                            if (roomDia.ComputerName == computerName)
                            {
                                return true;
                            }
                            else { return false; }
                        }
                        else { return false; }
                    }
                    else { return false; }
                }
                else { return false; }
            }
            catch { return false; }
        }

        // Kiểm tra tất cả danh sách client đã đăng nhập hoặc danh sách thí sinh đã vào phòng thi là Logged
        public bool CheckAllContestantLogin(int shiftID, int status)
        {
            List<CONTESTANTS_SHIFTS> list = new List<CONTESTANTS_SHIFTS>();
            List<CONTESTANTS_SHIFTS> listHasLogin = new List<CONTESTANTS_SHIFTS>();
            Db = new MTAQuizEntities();
           
                try
                {
                    list = (from obj in Db.CONTESTANTS_SHIFTS
                            where obj.DivisionShiftID == shiftID && obj.IsCheckFingerprint == 1
                            select obj).ToList();
                    listHasLogin = (from obj in Db.CONTESTANTS_SHIFTS
                                    where obj.DivisionShiftID == shiftID && obj.IsCheckFingerprint == 1 && obj.Status == status
                                    select obj).ToList();
                    if (list.Count == listHasLogin.Count)
                    {
                        return true;
                    }
                    else { return false; }
                }
                catch { return false; }
           
        }

       

        // Lấy thông tin roomdia thông qua tên máy
        

       

        // kiểm tra tất cả đã sẵn sàng để lấy đề thi hay chưa
        public bool CheckAllContestantReadyToGetTest(int shiftID, int status)
        {
            List<CONTESTANTS_SHIFTS> list = new List<CONTESTANTS_SHIFTS>();
            List<CONTESTANTS_SHIFTS> listHasLogin = new List<CONTESTANTS_SHIFTS>();
            Db = new MTAQuizEntities();
           
                try
                {
                   list = (from obj in Db.CONTESTANTS_SHIFTS
                                                     where obj.DivisionShiftID == shiftID && obj.IsCheckFingerprint == 1
                                                     select obj).ToList();
                    listHasLogin = (from obj in Db.CONTESTANTS_SHIFTS
                                                             where obj.DivisionShiftID == shiftID && obj.IsCheckFingerprint == 1 && obj.Status == status
                                                             select obj).ToList();
                    if (list.Count == listHasLogin.Count)
                    {
                        return true;
                    }
                    else { return false; }
                }
                catch { return false; }
            
        }

        // Kiểm tra tất cả danh sách client đã đăng nhập hoặc danh sách thí sinh đã vào phòng thi và sẵn sàng thi
        public bool CheckAllContestantReadyTest(int shiftID, int status)
        {
            List<CONTESTANTS_SHIFTS> list = new List<CONTESTANTS_SHIFTS>();
            List<CONTESTANTS_SHIFTS> listHasLogin = new List<CONTESTANTS_SHIFTS>();
            Db = new MTAQuizEntities();
           
                try
                {
                     list = (from obj in Db.CONTESTANTS_SHIFTS
                                                     where obj.DivisionShiftID == shiftID && obj.IsCheckFingerprint == 1
                                                     select obj).ToList();
                   listHasLogin = (from obj in Db.CONTESTANTS_SHIFTS
                                                             where obj.DivisionShiftID == shiftID && obj.IsCheckFingerprint == 1 && obj.Status == status
                                                             select obj).ToList();
                    if (list.Count == listHasLogin.Count)
                    {
                        return true;
                    }
                    else { return false; }
                }
                catch { return false; }
          
        }

        // cảnh cáo
        public bool AddViolationContestant(VIOLATIONS_CONTESTANTS vio_Contestant)
        {

            try
            {
                Db.VIOLATIONS_CONTESTANTS.Add(vio_Contestant);
                Db.SaveChanges();
                return true;
            }
          
            catch (Exception ex)
            { return false; }
        }

        // các vị trí có thể chuyển
        public List<ROOMDIAGRAM> GetListComCanChange(int divisionShiftID, int roomTestID)
        {
            List<ROOMDIAGRAM> result = new List<ROOMDIAGRAM>();

            Db = new MTAQuizEntities();

            try
            {
                ROOMDIAGRAM rd = new ROOMDIAGRAM();
           
                var room = (from obj2 in Db.CONTESTANTS_SHIFTS
                            where (obj2.DivisionShiftID == divisionShiftID)
                            select obj2.RoomDiagramID).ToList();
                result = (from obj1 in Db.ROOMDIAGRAMS
                          where (obj1.RoomTestID == roomTestID) && (obj1.Status!=4002)
                             && !room.Contains(obj1.RoomDiagramID)
                              select obj1).ToList();
                    return result;
                }
                catch
                {
                    return new List<ROOMDIAGRAM>();
                }
            

        }

        // Lấy Roomdia để update trạng thái là hỏng máy ko sử dụng được
        public ROOMDIAGRAM GetRoomDiaByID(int roomDiaID)
        {
            ROOMDIAGRAM result = new ROOMDIAGRAM();
            Db = new MTAQuizEntities();
            
                try
                {
                     result = new ROOMDIAGRAM();
                    result = Db.ROOMDIAGRAMS.Where(x => x.RoomDiagramID == roomDiaID).FirstOrDefault();
                    return result;
                }
                catch
                {
                    return new ROOMDIAGRAM();
                }
            
        }

    

        // thống kê
        public List<CONTESTANT> GetListContestantDoneTest(int shiftID)
        {
            List<CONTESTANT> result = new List<CONTESTANT>();
            // 3005 LÀ MÃ hoàn thành bài thi
            Db = new MTAQuizEntities();
           
                try
            {
                var listContestantID = (from obj in Db.CONTESTANTS_SHIFTS
                                        where obj.DivisionShiftID == shiftID && obj.IsCheckFingerprint == 1 && obj.Status == 3005
                                        select obj.ContestantID).ToList();

                result = (from obj in Db.CONTESTANTS
                          where listContestantID.Contains(obj.ContestantID)
                          select obj).ToList();
                return result;
            }
            catch
            {
                return new List<CONTESTANT>();
            }
        }

        // hủy thi
        public List<CONTESTANT> GetListContestantCancelTest(int shiftID)
        {
            // 4001 là trạng thái khởi tạo thí sinh, mặc định, nếu kết thúc thi, trạng thái đó ko thay đổi thì
            // tức là hôm đó thí sinh ko tham dự thi 
            List<CONTESTANT> result = new List<CONTESTANT>();
            Db = new MTAQuizEntities();
            
                try
                {
                    var listContestantID = (from obj in Db.CONTESTANTS_SHIFTS
                                            where obj.DivisionShiftID == shiftID && obj.Status == 4001
                                            select obj.ContestantID).ToList();

                    result = (from obj in Db.CONTESTANTS
                                               where listContestantID.Contains(obj.ContestantID)
                                               select obj).ToList();
                    return result;
                }
                catch
                {
                    return new List<CONTESTANT>();
                }
           
        }

        // bị hủy thi
        public List<CONTESTANT> GetListContestantIsCancelTest(int shiftID)
        {
            List<CONTESTANT> result = new List<CONTESTANT>();
            // 4001 là trạng thái khởi tạo thí sinh
            // nếu nó khác tức là nó đã tham gia thi và thay đổi trạng thái nhưng chưa hoàn thành bài thi thì tức 
            // tức là hôm đó thí sinh đó bị hủy thi do vi phạm quy chế
            Db = new MTAQuizEntities();
           
                try
                {
                    var listContestantID = (from obj in Db.CONTESTANTS_SHIFTS
                                            where obj.DivisionShiftID == shiftID && obj.Status != 4001 && obj.IsCheckFingerprint == 1 && obj.Status != 3005
                                            select obj.ContestantID).ToList();

                   result = (from obj in Db.CONTESTANTS
                                               where listContestantID.Contains(obj.ContestantID)
                                               select obj).ToList();
                    return result;
                }
                catch
                {
                    return new List<CONTESTANT>();
                }
            
        }

        // Vi phạm quy chế thi
        public List<CONTESTANT> GetListContestantViolation(int shiftID)
        {
            List<CONTESTANTS_SHIFTS> listContestantShift = new List<CONTESTANTS_SHIFTS>();

            List<CONTESTANTS_SHIFTS> result1 = new List<CONTESTANTS_SHIFTS>();
            List<CONTESTANT> result2 = new List<CONTESTANT>();
            Db = new MTAQuizEntities();
            
                try
                {
                   listContestantShift = (from obj in Db.CONTESTANTS_SHIFTS
                                                                    where obj.DivisionShiftID == shiftID
                                                                    select obj).ToList();

                   result1 = (from obj in Db.VIOLATIONS_CONTESTANTS
                                                        join obj1 in listContestantShift on obj.ContestantShiftID equals obj1.ContestantShiftID
                                                        select obj1).ToList();
                    result2 = (from obj in Db.CONTESTANTS
                                                join obj1 in result1 on obj.ContestantID equals obj1.ContestantID
                                                select obj).ToList();
                    if (result2 != null)
                    {
                        return result2;
                    }
                    else
                    {

                        return new List<CONTESTANT>();
                    }
                }
                catch
                {
                    return new List<CONTESTANT>()
    ;
                }
            
        }

        // lấy môn thi của thí sinh
        public SUBJECT GetSubject(int scheduleID)
        {
            SUBJECT result;
             result= new SUBJECT();
            Db = new MTAQuizEntities();
           
                try
                {
                    //SCHEDULE schedule = Db.SCHEDULES.Where(x => x.ScheduleID == scheduleID).FirstOrDefault();
                    //SUBJECT result = (from obj in Db.SUBJECTS
                    //                  where obj.SubjectID == schedule.ScheduleID
                    //                  select obj).FirstOrDefault();
                    result = (from obj in Db.SUBJECTS
                              join obj2 in Db.SCHEDULES on obj.SubjectID equals obj2.SubjectID
                              where obj2.ScheduleID == scheduleID
                              select obj).FirstOrDefault();
                    return result;
                }
                catch { return result; }
           
        }

        // lấy contestant theo id
        public CONTESTANT GetContestantByCode(string code)
        {
            CONTESTANT result = new CONTESTANT();
            Db = new MTAQuizEntities();
           
                try
                {
                    result = (from obj in Db.CONTESTANTS
                              where obj.ContestantCode.Equals(code)
                              select obj).FirstOrDefault();
                    return result;
                }
                catch { return result; }
            
        }

        // lấy thời gian thi của môn thi
        public SCHEDULE GetSchedule(int scheduleID)

        {
            SCHEDULE result = new SCHEDULE();
            Db = new MTAQuizEntities();
           
                try
                {
                    result = Db.SCHEDULES.Where(x => x.ScheduleID == scheduleID).FirstOrDefault();
                    return result;
                }
                catch
                {
                    return new SCHEDULE();
                }
          
        }


        /// <summary>
        /// ////////////////
        /// </summary>
        /// <param name="shiftID"></param>
        /// <returns></returns>
        // lấy room test của ca thi
        // lấy room test của ca thi
        public List<ROOMTEST> GetListRoomTest(int SupervisorID)
        {
            List<ROOMTEST> result;
            result = new List<ROOMTEST>();
            
            Db = new MTAQuizEntities();
            {
                try
                {
                    result = (from obj in Db.DIVISION_SHIFTS
                              from obj2 in Db.ROOMTESTS
                              from obj3 in Db.DIVISIONSHIFT_SUPERVISOR
                              from sh in Db.SHIFTS
                              where (obj.DivisionShiftID == obj3.DivisionShiftID && obj3.SupervisorID == SupervisorID && obj2.RoomTestID == obj.RoomTestID &&sh.ShiftID==obj.ShiftID)
                              select obj2).ToList();
                    return result;
                }
                catch
                {
                    return result; ;
                }
            }
        }

        //Lấy ca thi hiện tại, diftime là thời gian có thể hiển thị danh sách phòng thuộc ca thi
        // ví dụ 1800 là 15' trước khi ca thi đó bắt đầu
        //public List< SHIFT> GetShiftNow(int shiftDate, int logTime, int difTime, int SupervisorID)
        //{
        //    try
        //    {
        //        List<SHIFT> result = (from obj in Db.SHIFTS
        //                         from obj2 in Db.DIVISION_SHIFTS
        //                          from obj3 in Db.DIVISIONSHIFT_SUPERVISOR                          
        //                        where /*obj.ShiftDate == shiftDate &&*/ ((obj.StartTime - difTime) < logTime)/* && (logTime < obj.EndTime)*/ && (obj3.SupervisorID== SupervisorID)&&(obj3.DivisionShiftID== obj2.DivisionShiftID)
        //                        select obj).ToList();
        //        return result;
        //    }
        //    catch { return new List<SHIFT>() ; }
        //}


      
        // lấy division shift của ca thi và phòng thi
      


        // tìm kiếm thí sinh theo tên
        public List<CONTESTANT> SearchListContestant(int divisionShiftID, string search)
        {
            List<CONTESTANT> result = new List<CONTESTANT>();
            Db = new MTAQuizEntities();
            {
                try
                {
                    var listContestantID = (from obj in Db.CONTESTANTS_SHIFTS
                                            where obj.DivisionShiftID == divisionShiftID && obj.IsCheckFingerprint == 1
                                            select obj.ContestantID).ToList();

                    result = (from obj in Db.CONTESTANTS
                              where listContestantID.Contains(obj.ContestantID) && obj.FullName.Contains(search)
                              select obj).ToList();
                    return result;
                }
                catch
                {
                    return new List<CONTESTANT>();
                }
            }

        }

        // kiểm tra có tồn tại contestantShiftID trong bảng đề thi hay chưa, nếu có thì update, ko có thi tạo mới
        public bool CheckContestantTestExist(int contestantShiftID)
        {
            List<CONTESTANTS_TESTS> listContestantTest = new List<CONTESTANTS_TESTS>();
               Db = new MTAQuizEntities();
            {
                try
                {
                    listContestantTest = (from obj in Db.CONTESTANTS_TESTS
                                          where obj.ContestantShiftID == contestantShiftID
                                          select obj).ToList();
                    if (listContestantTest.Count() > 0)
                    {
                        return true;
                    }
                    else { return false; }
                }
                catch { return false; }
            }
        }
        // update contestantTest

        public bool UpdateContestantTest(CONTESTANTS_TESTS contestantTest)
        {
            CONTESTANTS_TESTS result = new CONTESTANTS_TESTS();
            Db = new MTAQuizEntities();
            {
                try
                {
                 result = Db.CONTESTANTS_TESTS.Where(x => x.ContestantShiftID == contestantTest.ContestantShiftID).FirstOrDefault();
                    if (result != null)
                    {
                        result.ContestantShiftID = contestantTest.ContestantShiftID;
                        result.TestID = contestantTest.TestID;
                        Db.SaveChanges();
                    }
                    else
                        return false;

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public int DecryptQuestion(int divisionshiftid, string key2)
        {
            
            Db = new MTAQuizEntities();
            En_Decrypt _decrypt;
            string key = Db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == divisionshiftid).SingleOrDefault().Key;
            if (key == key2)
            {
                _decrypt = new En_Decrypt(key);
                List<QUESTIONS_TEMP> lsTempQuestion = new List<QUESTIONS_TEMP>();
                lsTempQuestion = Db.QUESTIONS_TEMP.Where(x => x.DivisionShiftID == divisionshiftid).ToList();
                int count = 0;
                foreach (var item in lsTempQuestion)
                {
                    QUESTION Question = new QUESTION();
                    Question = Db.QUESTIONS.Where(x => x.QuestionID == item.QuestionID).SingleOrDefault();
                    Question.QuestionContent = _decrypt.Encrypt(item.QuestionContent);
                    List<SUBQUESTION> lsSubQuestion = new List<SUBQUESTION>();
                    lsSubQuestion = Question.SUBQUESTIONS.ToList();

                    try
                    {
                        Db.SaveChanges();
                        int countlsSub = 0;
                        foreach (var sub in lsSubQuestion)
                        {
                            sub.SubQuestionContent = _decrypt.Encrypt(Db.SUBQUESTIONS_TEMP.Where(x => x.SubQuestionID == sub.SubQuestionID&& x.DivisionShiftID==divisionshiftid).FirstOrDefault().SubQuestionContent);
                            Db.SaveChanges();
                            countlsSub++;
                        }
                        if (countlsSub == lsSubQuestion.Count)
                        {
                            count++;
                        }
                    }

                    catch(Exception ex)
                    {

                    }

                }
                if (count == lsTempQuestion.Count)
                    return 1; // thành công
                else
                    return 0; // không thành công
            }
            else return -1; //key sai
        }

    }
}
