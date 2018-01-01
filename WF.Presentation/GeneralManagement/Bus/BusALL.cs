using CL.Persistance;
using CL.Services.Impl;
using CL.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeneralManagement.Bus
{
  public   class BusALL
    {
        private static BusALL instance;
        public static BusALL Instance
        {    get
                 {
                if (instance == null)
                {
                instance = new BusALL();
                 }
                return instance;
        }
}
        ISupervisorService supervisorService = new SupervisorService();
        #region login
        public bool CheckLogin(string user, string pass, out int per)
        {
            return supervisorService.CheckLogin(user, pass, out per);
        }
        public List<ROOMDIAGRAM> GetListRoomdiagram(int roomtestID)
        {
            return supervisorService.GetListRoomdiagram(roomtestID);
        }
        public EXAMINATIONCOUNCIL_STAFFS GetInfoSupervisor(int _staffID)
        {
            return supervisorService.GetInfoSupervisor(_staffID);
        }

        public STAFF GetStaff(int supervisorID)
        {
            return supervisorService.GetStaff(supervisorID);
        }
        #endregion

        public SHIFT GetShift(int shiftID)
        {
            return supervisorService.GetShift(shiftID);
        }
        public int GetStatusDivisionShift(int _divisionShiftID)
        {
            return supervisorService.GetStatusDivisionShift(_divisionShiftID);
        }
        public bool UpdateStatusDivisionShift(int _divisionShiftID, int _status)
        {
            return supervisorService.UpdateStatusDivisionShift(_divisionShiftID, _status);
        }
        public bool UpdateRoomdiagram(int roomtestID, string computername, int status)
        {
            return supervisorService.UpdateRoomdiagram(roomtestID, computername, status);
        }
        public bool AddRoomdiagram(int roomtestID, string computername, string computercode, int status)
        {
            return supervisorService.AddRoomdiagram(roomtestID, computername, computercode, status);
        }
        public CONTESTANT GetInfoContestant(int contestantID)
        {
            return supervisorService.GetInfoContestant(contestantID);
        }
        public List<VIOLATION> GetListViolation()
        {
            return supervisorService.GetListViolation();
        }



        public ROOMTEST GetRoom(int roomID)
        {
            return supervisorService.GetRoom(roomID);
        }

        public List<CONTESTANT> GetlistContestant(int shiftID)
        {
            return supervisorService.GetlistContestant(shiftID);
        }

        public CONTESTANTS_SHIFTS GetContestantShift(int shiftID, int contestantD)
        {
            return supervisorService.GetContestantShift(shiftID, contestantD);
        }

        public ROOMDIAGRAM GetInfoRoomDia(int roomDiaID)
        {
            return supervisorService.GetInfoRoomDia(roomDiaID);
        }

        #region hỗ trợ form manage
        // hiển thị danh sách các ca thi có starttime gần nhất với hiện tại khoảng 45 '
        public List<SHIFT> GetListShift(int timeNow, int DIF_TIME)
        {
            return supervisorService.GetListShift(timeNow, DIF_TIME);
        }


        public bool CheckShowShift(int shiftID, int timeNow, int DIF_TIME_OPEN)
        {
            return supervisorService.CheckShowShift(shiftID, timeNow, DIF_TIME_OPEN);
        }

        public int CountTimesViolation(int contestantShiftID)
        {
            return supervisorService.CountTimesViolation(contestantShiftID);
        }

        #endregion

        #region xếp chỗ
        public List<ROOMDIAGRAM> GetListComputerOfRoom(int roomTestID) // lấy tất cả các máy còn đang hoạt động được
        {
            return supervisorService.GetListComputerOfRoom(roomTestID);
        }
        #endregion

        public bool UpdateContestantShift(CONTESTANTS_SHIFTS contestantShift) // update contestant shift
        {
            return supervisorService.UpdateContestantShift(contestantShift);
        }

        // Lấy danh sách contestantShiftId của ca thi
        public List<int> ListContestantShiftID(int divisionShiftID)
        {
            return supervisorService.ListContestantShiftID(divisionShiftID);
        }

        // Lấy danh sách mã vị trí ngồi theo phòng thi
        public List<int> ListRoomDiaID(int roomTestID)
        {
            return supervisorService.ListRoomDiaID(roomTestID);
        }

        public CONTESTANTS_SHIFTS GetContestantShift(int contestantShiftID)
        {
            return supervisorService.GetContestantShift(contestantShiftID);
        }

        //lấy danh sách thí sinh đã check vân tay thành công và được vào phòng thi, mình có thể kiểm tra điều kiện thời gian nó điểm danh trong ca thi hay ngoài ca thi
        public List<CONTESTANT> GetlistContestantHasCheckedFP(int divisionShiftID)
        {
            return supervisorService.GetlistContestantHasCheckedFP(divisionShiftID);
        }

        // Lấy danh sách đề thi của môn thi thuộc 1 ca thi
        public List<int> ListTestIDForSubjectOfShift(int shiftID, int subjectID)
        {
            return supervisorService.ListTestIDForSubjectOfShift(shiftID, subjectID);
        }

        // lấy danh sách chi tiết kỳ thi để lấy được danh sách các môn thi có trong ca thi đó
        public List<SCHEDULE> ListScheduleOfShift(int shiftID)
        {
            return supervisorService.ListScheduleOfShift(shiftID);
        }

        // lấy danh sách thí sinh theo từng schedule <=> môn của ca đó
        public List<int> ListContestantShiftIDForScheduleOfShift(int divisionShiftID, int scheduleID)
        {
            return supervisorService.ListContestantShiftIDForScheduleOfShift(divisionShiftID, scheduleID);
        }

        public string GetNameRoomTest(int RoomTestID)
        {
            return supervisorService.GetNameRoomTest(RoomTestID);
        }
        // lấy ca thi theo id
        public SHIFT GetShiftByID(int shiftID)
        {
            return supervisorService.GetShiftByID(shiftID);
        }

        // phát đề cho thí sinh
        public bool AddContestantTest(CONTESTANTS_TESTS contestantTest)
        {
            return supervisorService.AddContestantTest(contestantTest);
        }

        // Lấy tất cả các phân đề thi 
        public List<CONTESTANTS_TESTS> ListContestantTestExist(int contestantShiftID)
        {
            return supervisorService.ListContestantTestExist(contestantShiftID);
        }

        // LẤY đề thi của thí sinh theo contestantShiftID
        public CONTESTANTS_TESTS GetContestantTest(int contestantShiftID)
        {
            return supervisorService.GetContestantTest(contestantShiftID);
        }


        // Lấy danh sách contestantshiftID divisionShift hiện tại
        List<int> ListContestantShiftIDInTestExist(int divisionShiftID)
        {
            return supervisorService.ListContestantShiftIDInTestExist(divisionShiftID);
        }

        // Xóa tất cả các phát đề trước đó nếu bị lỗi và phải phát lại
        public bool DeleteContestantTest(int contestantTestID)
        {
            return supervisorService.DeleteContestantTest(contestantTestID);
        }

        // Kiểm tra trạng thái thí sinh đã login thành công và đang chờ để nhận đề thi
        public bool CheckLoginSuccess(int shiftID, int contestantID)
        {
            return supervisorService.CheckLoginSuccess(shiftID, contestantID);
        }

        // Kiểm tra client đăng nhập đúng ko?
        public bool CheckClientLogin(int divisionShiftID, string contestantCode, string computerName)
        {
            return supervisorService.CheckClientLogin(divisionShiftID, contestantCode, computerName);
        }

        // Kiểm tra tất cả danh sách client đã đăng nhập hoặc danh sách thí sinh đã vào phòng thi là Logged
        public bool CheckAllContestantLogin(int shiftID, int status)
        {
            return supervisorService.CheckAllContestantLogin(shiftID, status);
        }
        public CONTESTANT GetContestantByContestanShiftID(int contestantShiftID)
        {
            return supervisorService.GetContestantByContestanShiftID(contestantShiftID);
        }
        // Lấy thông tin thí sinh qua contestantCode hoặc cmt, hoặc số thẻ sv
        public CONTESTANT GetContestant(string contestantVerify)
        {
            return supervisorService.GetContestant(contestantVerify);
        }

        // Lấy thông tin roomdia thông qua tên máy
        public ROOMDIAGRAM GetRoomDia(string comName)
        {
            return supervisorService.GetRoomDia(comName);
        }

        // Lấy thông tin ContestantShift qua tên máy và ca thi
        public CONTESTANTS_SHIFTS GetContestantShiftByComName(int shiftID, string comName)
        {
            return supervisorService.GetContestantShiftByComName(shiftID, comName);
        }

        // kiểm tra tất cả đã sẵn sàng để lấy đề thi hay chưa
        public bool CheckAllContestantReadyToGetTest(int shiftID, int status)
        {
            return supervisorService.CheckAllContestantReadyToGetTest(shiftID, status);
        }

        // Kiểm tra tất cả danh sách client đã đăng nhập hoặc danh sách thí sinh đã vào phòng thi và sẵn sàng thi
        public bool CheckAllContestantReadyTest(int shiftID, int status)
        {
            return supervisorService.CheckAllContestantReadyTest(shiftID, status);
        }

        // TẠO CẢNH CÁO
        public bool AddViolationContestant(VIOLATIONS_CONTESTANTS vio_Contestant)
        {
            return supervisorService.AddViolationContestant(vio_Contestant);
        }

        // các vị trí máy có thể chuyển
        public List<ROOMDIAGRAM> GetListComCanChange(int divisionShiftID, int roomTestID)
        {
            return supervisorService.GetListComCanChange(divisionShiftID, roomTestID);
        }

        // Lấy Roomdia để update trạng thái là hỏng máy ko sử dụng được
        public ROOMDIAGRAM GetRoomDiaByID(int roomDiaID)
        {
            return supervisorService.GetRoomDiaByID(roomDiaID);
        }

        // Update roomdiagram
        public bool UpdateRoomDia(ROOMDIAGRAM roomDia)
        {
            return supervisorService.UpdateRoomDia(roomDia);
        }

        //thống kê
        public List<CONTESTANT> GetListContestantDoneTest(int shiftID)
        {
            return supervisorService.GetListContestantDoneTest(shiftID);
        }

        // hủy thi
        public List<CONTESTANT> GetListContestantCancelTest(int shiftID)
        {
            return supervisorService.GetListContestantCancelTest(shiftID);
        }

        // bị hủy thi
        public List<CONTESTANT> GetListContestantIsCancelTest(int shiftID)
        {
            return supervisorService.GetListContestantIsCancelTest(shiftID);
        }

        // Vi phạm quy chế thi
        public List<CONTESTANT> GetListContestantViolation(int shiftID)
        {
            return supervisorService.GetListContestantViolation(shiftID);
        }

        // lấy môn thi của thí sinh
        public SUBJECT GetSubject(int scheduleID)
        {
            return supervisorService.GetSubject(scheduleID);
        }

        // lấy contestant theo code
        public CONTESTANT GetContestantByCode(string code)
        {
            return supervisorService.GetContestantByCode(code);
        }

        // lấy thời gian thi của môn thi
        public SCHEDULE GetSchedule(int scheduleID)
        {
            return supervisorService.GetSchedule(scheduleID);
        }

        // lấy room test của ca thi
        public List<ROOMTEST> GetListRoomTest(int SupervisorID)
        {
            return supervisorService.GetListRoomTest(SupervisorID);
        }

        //public List<SHIFT> GetShiftNow(int shiftDate, int logTime, int difTime, int SupervisorID)
        //{
        //    return supervisorService.GetShiftNow(shiftDate, logTime, difTime, SupervisorID);
        //}
        public SHIFT GetShiftNow(int Timenow, int logTime, int difTime, int SupervisorID)
        {
            return supervisorService.GetShiftNow(Timenow, logTime, difTime, SupervisorID);
        }

        // lấy division shift của ca thi và phòng thi
        public DIVISION_SHIFTS GetDivisionShift(int shiftID, int roomID)
        {
            return supervisorService.GetDivisionShift(shiftID, roomID);
        }

        public DIVISION_SHIFTS GetDivisionShiftByID(int divisionShiftID)
        {
            return supervisorService.GetDivisionShiftByID(divisionShiftID);
        }

        // tìm kiếm thí sinh theo tên
        public List<CONTESTANT> SearchListContestant(int divisionShiftID, string search)
        {
            return supervisorService.SearchListContestant(divisionShiftID, search);
        }

        // kiểm tra có tồn tại contestantShiftID trong bảng đề thi hay chưa, nếu có thì update, ko có thi tạo mới
        public bool CheckContestantTestExist(int contestantShiftID)
        {
            return supervisorService.CheckContestantTestExist(contestantShiftID);
        }

        // update contestantTest
        public bool UpdateContestantTest(CONTESTANTS_TESTS contestantTest)
        {
            return supervisorService.UpdateContestantTest(contestantTest);
        }
        public int DecryptQuestion(int divisionshiftID, string key)
        {
            return supervisorService.DecryptQuestion(divisionshiftID, key);
        }

        public  void UpdateCheckFingerFasle(int divisionshiftID)
        {
            //return supervisorService.UpdateCheckFingerFasle(divisionshiftID, key);
        }
    }
}
