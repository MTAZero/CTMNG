using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.Persistance;

namespace CL.Services.Interface
{
    public partial interface ISupervisorService
    {
        List<ROOMDIAGRAM> GetListRoomdiagram(int roomtestID);
        STAFF GetStaff(int supervisorID); // lấy thông tin của giám thị 
                                          // List<SHIFT> GetListShiftByStaff(int supervisorID); // lấy ra các ca thi của giám sát hiện tại

        SHIFT GetShift(int shiftID); // Lấy thông tin của ca thi khi biết id của ca thi đó
                                     //  List<CONTESTANT> GetListContestant(int shiftID); // lấy ra ds thí sinh của ca thi đó
                                     // List<SHIFT> GetListShiftbyDayOfSup(int supervisorID, int day); // Lấy ra ca thi của giám thị theo ngày

        int GetStatusDivisionShift(int _divisionShiftID);
        bool UpdateStatusDivisionShift(int _divisionShiftID, int _status);
        bool UpdateRoomdiagram(int roomtestID, string computername, int status);
        bool AddRoomdiagram(int roomtestID, string computername, string computercode, int status);
        bool CheckLogin(string user, string pass, out int per);
        EXAMINATIONCOUNCIL_STAFFS GetInfoSupervisor(int _staffID);

        CONTESTANT GetInfoContestant(int contestantID);

        List<VIOLATION> GetListViolation();

        DIVISION_SHIFTS GetDivisionShift(int shiftID);

        ROOMTEST GetRoom(int roomID);
        ROOMTEST GetRoomTestByShiftAndContestant(int contestantID, int shiftID);
        List<CONTESTANT> GetlistContestant(int shiftID);
        List<CONTESTANT> GetlistContestantByShitfID(int ShiftID);

        CONTESTANTS_SHIFTS GetContestantShift(int shiftID, int contestantD);
        bool UpdateContestant(CONTESTANT contestant);
        ROOMDIAGRAM GetInfoRoomDia(int roomDiaID);

        //CONTESTANTS_TESTS GetContestantTest(int shiftID, int contestantID);

        #region hỗ trợ form manage
        // hiển thị danh sách các ca thi có starttime gần nhất với hiện tại

        List<SHIFT> GetListShift(int timeNow, int DIF_TIME);

        bool CheckShowShift(int shiftID, int timeNow, int DIF_TIME_OPEN);

        int CountTimesViolation(int contestantShiftID);

        #endregion

        #region xếp chỗ
        List<ROOMDIAGRAM> GetListComputerOfRoom(int roomTestID); // lấy tất cả các máy còn đang hoạt động được
        #endregion

        bool UpdateContestantShift(CONTESTANTS_SHIFTS contestantShift); // update contestant shift

        // Lấy danh sách contestantShiftId của ca thi
        List<int> ListContestantShiftID(int divisionShiftID);

        // Lấy danh sách mã vị trí ngồi theo phòng thi
        List<int> ListRoomDiaID(int roomTestID);

        CONTESTANTS_SHIFTS GetContestantShift(int contestantShiftID);

        //lấy danh sách thí sinh đã check vân tay thành công và được vào phòng thi
        List<CONTESTANT> GetlistContestantHasCheckedFP(int divisionShiftID);

        // Lấy danh sách đề thi của môn thi thuộc 1 ca thi
        List<int> ListTestIDForSubjectOfShift(int shiftID, int subjectID);

        // lấy danh sách chi tiết kỳ thi để lấy được danh sách các môn thi có trong ca thi đó
        List<SCHEDULE> ListScheduleOfShift(int shiftID);

        // lấy danh sách thí sinh theo từng schedule <=> môn của ca đó
        List<int> ListContestantShiftIDForScheduleOfShift(int divisionShiftID, int scheduleID);

        // phát đề cho thí sinh
        bool AddContestantTest(CONTESTANTS_TESTS contestantTest);

        // Lấy tất cả các phân đề thi 
        List<CONTESTANTS_TESTS> ListContestantTestExist(int contestantShiftID);

        // Lấy danh sách contestantshiftID divisionShift hiện tại
        List<int> ListContestantShiftIDInTestExist(int divisionShiftID);

        // LẤY đề thi của thí sinh theo contestantShiftID
        CONTESTANTS_TESTS GetContestantTest(int contestantShiftID);

        // Xóa tất cả các phát đề trước đó nếu bị lỗi và phải phát lại
        bool DeleteContestantTest(int contestantTestID);

        // Kiểm tra trạng thái thí sinh đã login thành công và đang chờ để nhận đề thi
        bool CheckLoginSuccess(int shiftID, int contestantID);

        // Kiểm tra client đăng nhập đúng ko?
        bool CheckClientLogin(int divisionShiftID, string contestantCode, string computerName);

        // Kiểm tra tất cả danh sách client đã đăng nhập hoặc danh sách thí sinh đã vào phòng thi là Logged
        bool CheckAllContestantLogin(int shiftID, int status);

        //lay thong tin thi sinh theo contestantshiftid
        CONTESTANT GetContestantByContestanShiftID(int contestantShiftID);
        // Lấy thông tin thí sinh qua contestantCode hoặc cmt, hoặc số thẻ sv
        CONTESTANT GetContestant(string contestantVerify);

        // Lấy thông tin roomdia thông qua tên máy
        ROOMDIAGRAM GetRoomDia(string comName);

        // Lấy thông tin ContestantShift qua tên máy và ca thi
        CONTESTANTS_SHIFTS GetContestantShiftByComName(int shiftID, string comName);

        // kiểm tra tất cả đã sẵn sàng để lấy đề thi hay chưa
        bool CheckAllContestantReadyToGetTest(int shiftID, int status);

        // Kiểm tra tất cả danh sách client đã đăng nhập hoặc danh sách thí sinh đã vào phòng thi và sẵn sàng thi
        bool CheckAllContestantReadyTest(int shiftID, int status);

        // cảnh cáo
        bool AddViolationContestant(VIOLATIONS_CONTESTANTS vio_Contestant);

        // danh sách vị trí có thể chuyển tới
        List<ROOMDIAGRAM> GetListComCanChange(int divisionShiftID, int roomTestID);

        // Lấy Roomdia để update trạng thái là hỏng máy ko sử dụng được
        ROOMDIAGRAM GetRoomDiaByID(int roomDiaID);

        // UPDATE ROOMDIA
        bool UpdateRoomDia(ROOMDIAGRAM roomDia);


        // thống kê
        List<CONTESTANT> GetListContestantDoneTest(int shiftID);

        // hủy thi
        List<CONTESTANT> GetListContestantCancelTest(int shiftID);

        // bị hủy thi
        List<CONTESTANT> GetListContestantIsCancelTest(int shiftID);

        // Vi phạm quy chế thi
        List<CONTESTANT> GetListContestantViolation(int shiftID);

        // lấy môn thi của thí sinh
        SUBJECT GetSubject(int scheduleID);

        // lấy contestant theo code
        CONTESTANT GetContestantByCode(string code);

        // lấy thời gian thi của môn thi
        SCHEDULE GetSchedule(int scheduleID);
        /// <summary>
        /// ////////////////
        /// </summary>
        /// <param name="shiftID"></param>
        /// <returns></returns>
        // lấy room test của ca thi
        List<ROOMTEST> GetListRoomTest(int SuppervisorID);

        // LẤY RA CA THI HIỆN TẠI KHI ĐĂNG NHẬP
        //List<SHIFT> GetShiftNow(int shiftDate, int logTime, int difTime, int SupervisorID);
        SHIFT GetShiftByID(int shiftID);
        string GetNameRoomTest(int RoomTestID);

        SHIFT GetShiftNow(int Timenow, int logTime, int difTime, int SupervisorID);
        // lấy division shift của ca thi và phòng thi
        DIVISION_SHIFTS GetDivisionShift(int shiftID, int roomID);

         DIVISION_SHIFTS GetDivisionShiftByID(int divisionShiftID);

        // tìm kiếm thí sinh theo tên
        List<CONTESTANT> SearchListContestant(int divisionShiftID, string search);

        // kiểm tra có tồn tại contestantShiftID trong bảng đề thi hay chưa, nếu có thì update, ko có thi tạo mới
        bool CheckContestantTestExist(int contestantShiftID);

        // update contestantTest
        bool UpdateContestantTest(CONTESTANTS_TESTS contestantTest);
        
        //giải mã đề thi
        int DecryptQuestion(int divisionshiftid, string key2);

    }
}
