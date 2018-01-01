using DAO.DataProvider;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DAO.DAO
{
    public class ContestDAO
    {
        private static ContestDAO instance;
        public static ContestDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContestDAO();
                }
                return instance;
            }
        }
        private ContestDAO() { }

        public void GetContestByShiftTime(string ComputerName, out Contest ContestOut, out ErrorController EC)
        {
            Contest C = new Contest();
            using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
            {
                try
                {
                    int  currentnow =(int)DAO.ConvertDateTime.GetDateTimeServer().TimeOfDay.TotalSeconds;
                    int datenow = DAO.ConvertDateTime.ConvertDateTimeToUnix(DAO.ConvertDateTime.GetDateTimeServer()) / 86400;
                    ROOMDIAGRAM  RD = DB.ROOMDIAGRAMS.SingleOrDefault(x => x.ComputerName == ComputerName);
                    if (RD != null)
                    {
                        SHIFT sh = DB.SHIFTS.Where(x => x.EndTime >= currentnow && x.ShiftDate / 86400 == datenow).OrderBy(x => x.StartTime).FirstOrDefault();
                        if (sh != null)
                        {
                                
                            ROOMTEST RT = DB.ROOMTESTS.Where(x => x.RoomTestID == RD.RoomTestID).SingleOrDefault();

                            DIVISION_SHIFTS ds = DB.DIVISION_SHIFTS.Where(x => x.RoomTestID == RT.RoomTestID && x.ShiftID == sh.ShiftID).SingleOrDefault();
                            if (ds != null)
                            {
                                CONTESTANTS_SHIFTS cshift = DB.CONTESTANTS_SHIFTS.Where(x => x.DivisionShiftID == ds.DivisionShiftID && x.RoomDiagramID== RD.RoomDiagramID).SingleOrDefault();
                                if (cshift != null)
                                {
                                    if(cshift.IsCheckFingerprint!=null && cshift.IsCheckFingerprint!=0)
                                    {
                                        C.ContestName = ds.SHIFT.CONTEST.ContestName;
                                        C.StartTime = ds.SHIFT.StartTime;
                                        C.EndTime = ds.SHIFT.EndTime;
                                        C.ShiftDate = ds.SHIFT.ShiftDate;
                                        C.Subject = cshift.SCHEDULE.SUBJECT.SubjectName;
                                        C.TimeOfTest = cshift.SCHEDULE.TimeOfTest + 300;//5p kiem tra b
                                        C.DivisionShiftID = cshift.DivisionShiftID;
                                        C.RoomID = ds.RoomTestID;
                                        C.RoomName = ds.ROOMTEST.RoomTestName;
                                        C.ComputerCode = RD.ComputerCode;
                                        C.ScheduleID = cshift.ScheduleID;
                                        C.ComputerName = RD.ComputerName;
                                        C.TimeToSubmit = cshift.SCHEDULE.TimeToSubmit;
                                        ContestOut = C;
                                        EC = new ErrorController(Common.STATUS_OK, "Get contest information succedsfully");
                                    }
                                    else
                                    {
                                        ContestOut = null;
                                        EC = new ErrorController(Common.STATUS_ERROR, "Thí sinh chưa xác thực!");
                                    }
                                    //C.ContestID = SS.SHIFT.ContestID??default(int);
                                   
                                }
                                else
                                {
                                    ContestOut = null;
                                    EC = new ErrorController(Common.STATUS_ERROR, "Máy không tham gia thi!");

                                }
                            }
                    else
                      {
                      ContestOut = null;
                       EC = new ErrorController(Common.STATUS_ERROR, "Không thể lấy dữ liệu ca thi");
                                // trường hợp này lỗi do k lấy dc dữ liệu từ DB.
                            }

                        }
                        else
                        {
                            ContestOut = null;
                            EC = new ErrorController(Common.STATUS_ERROR, "Chưa đến giờ thi");
                            // trường hợp này lỗi do k lấy dc dữ liệu từ DB.

                        }
                    }
                    else
                    {
                        ContestOut = null;
                        EC = new ErrorController(Common.STATUS_ERROR, "Máy không tham gia thi");

                        // trường hợp này lỗi do k lấy dc dữ liệu từ DB.
                    }

                }
                catch (Exception ex)
                {
                    ContestOut = null;
                    EC = new ErrorController(Common.STATUS_UNKOWN_EXCEPTION, string.Format(Common.STR_STATUS_UNKOWN_EXCEPTION, "Có lỗi khi lấy dữ liệu"));
                    // đây là trường hợp lỗi khi sử dụng try catch thường sẽ là unknown
                }
            }
        }
        public void GetContestByComputerName(string ComputerName, out Contest ContestOut, out ErrorController EC)
        {
            Contest C = new Contest();
            using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
            {
                try
                {
                    ROOMDIAGRAM RD = DB.ROOMDIAGRAMS.SingleOrDefault(x => x.ComputerName == ComputerName);

                    if (RD != null)
                    {
                        CONTESTANTS_SHIFTS CSH = RD.CONTESTANTS_SHIFTS.SingleOrDefault();
                        DIVISION_SHIFTS SS = RD.ROOMTEST.DIVISION_SHIFTS.SingleOrDefault(x => x.ShiftID == CSH.DIVISION_SHIFTS.ShiftID && x.RoomTestID == CSH.DIVISION_SHIFTS.RoomTestID);
                        if (SS != null && CSH != null)
                        {
                            //C.ContestID = SS.SHIFT.ContestID??default(int);
                            C.ContestName = SS.SHIFT.CONTEST.ContestName;
                            C.StartTime = SS.SHIFT.StartTime;
                            C.EndTime = SS.SHIFT.EndTime;
                            C.ShiftDate = SS.SHIFT.ShiftDate;
                            C.Subject = CSH.SCHEDULE.SUBJECT.SubjectName;
                            C.TimeOfTest = CSH.SCHEDULE.TimeOfTest+300;
                            C.DivisionShiftID = CSH.DivisionShiftID;
                            C.RoomID = SS.RoomTestID;
                            C.RoomName = SS.ROOMTEST.RoomTestName;
                            C.ComputerCode = RD.ComputerCode;
                            C.ScheduleID = CSH.ScheduleID;
                            C.ComputerName = RD.ComputerName;
                            C.TimeToSubmit = CSH.SCHEDULE.TimeToSubmit;
                            ContestOut = C;
                            EC = new ErrorController(Common.STATUS_OK, "Get contest information successfully");
                            // den day la xong nhiem vu của hàm này., thì a trả ra STATUS_OK 
                        }
                        else
                        {
                            ContestOut = null;
                            EC = new ErrorController(Common.STATUS_ERROR, "Can not get SHIFTS_STAFFS by ComputerName");
                            // trường hợp này lỗi do k lấy dc dữ liệu từ DB.
                        }
                    }
                    else
                    {
                        ContestOut = null;
                        EC = new ErrorController(Common.STATUS_ERROR, "Can not get ROOMDIAGRAMS by ComputerName");
                        // trường hợp này lỗi do k lấy dc dữ liệu từ DB.
                    }
                }
                catch (Exception ex)
                {
                    ContestOut = null;
                    EC = new ErrorController(Common.STATUS_UNKOWN_EXCEPTION, string.Format(Common.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
                    // đây là trường hợp lỗi khi sử dụng try catch thường sẽ là unknown
                }
            }
        }
    }
}
