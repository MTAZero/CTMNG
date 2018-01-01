using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreateDB.Main;
namespace CreateDB
{
    public partial class frmLoading : Form
    {
        private BackgroundWorker bw;
        Encrypter _encrypt = null;
        Main.Main model =new Main.Main();
        Quiz.Quiz quiz=new Quiz.Quiz(); 
        //int _dsID = 0;
        static int status = 0;
        int countSuccessfull = 0;
        List<int> _lsDvisionShiftID = new List<int>();
        int issucc = 1;
        public frmLoading(List<int> lsDSID)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            string sql = @"delete from ANSWERSHEET_DETAILS
delete from ANSWERSHEETS
delete from CONTESTANTS_TESTS
delete from VIOLATIONS_CONTESTANTS
delete from answers
delete from answers_temp
delete from subquestions
delete from subquestions_temp
delete from TEST_DETAILS
delete from TESTS
delete from BAGOFTESTS
delete from QUESTIONS
delete from QUESTIONS_TEMP
delete from EXAMINATIONCOUNCIL_STAFFS
delete from EXAMINATIONCOUNCIL_POSITIONS

delete from CONTESTANTS_SHIFTS
delete from FINGERPRINTS
delete from contestants
delete from DIVISIONSHIFT_SUPERVISOR
delete from DIVISION_SHIFTS
delete from shifts


delete from schedules
delete from SUBJECTS

delete from VIOLATIONS
delete from ROOMDIAGRAMS
delete from ROOMTESTS
delete from STAFFS_POSITIONS
delete from LOCATIONS
delete from CONTESTS

delete from STAFFS
delete from POSITIONS";
            
            try
            {
                int k = quiz.Database.ExecuteSqlCommand(sql);

            }
            catch(Exception ex)
            {
                string s = ex.Message;
            }
            _lsDvisionShiftID = lsDSID;
            lbinfo.Text = "Chuyển dữ liệu " + lsDSID.Count.ToString() + " ca thi";
            //_dsID = id;
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(issucc!=0)
            MessageBox.Show("Hoàn Thành quá trình chuyển CSDL");
            else MessageBox.Show("Quá trình chuyển CSDL bị gián đoạn, xem lại đề thi của các ca thi");
            //Main.CONTEST contest = new Main.CONTEST();

            this.Close();
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbLoading.Value = e.ProgressPercentage;
            lbRate.Text = pgbLoading.Value.ToString() + "%";
            Application.DoEvents();
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Staff();
            Position();
            Contest();
            Location2();
            RoomTest();
            Violation();
            Schedule();
            Shift();
            Contestant();
            ExaminationCouncil();
            foreach (int i in _lsDvisionShiftID)
            {
                if(BagOfTest(i)==0) issucc=0;
            }

        }
        private delegate void SetLB();

        void SetLabelText()
        {
            switch (status)
            {
                case 11:

                    lbStaff.ForeColor = Color.Blue;
                    lbStaff.Text = "Đang chuyển dữ liệu cán bộ...";
                    break;
                case 12:
                    lbStaff.ForeColor = Color.Green;
                    lbStaff.Text = "Chuyển dữ liệu cán bộ thành công!";
                    break;
                case 13:
                    lbStaff.ForeColor = Color.Red;
                    lbStaff.Text = "Chuyển dữ liệu cán bộ thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;
                case 21:
                    this.Height += 25;
                    lbRoomTest.ForeColor = Color.Blue;
                    lbRoomTest.Text = "Đang chuyển dữ liệu phòng thi...";
                    break;
                case 22:
                    lbRoomTest.ForeColor = Color.Green;
                    lbRoomTest.Text = "Chuyển dữ liệu phòng thi thành công!";
                    break;
                case 23:
                    lbRoomTest.ForeColor = Color.Red;
                    lbRoomTest.Text = "Chuyển dữ liệu phòng thi thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;
                case 31:
                    this.Height += 25;
                    lbViolation.ForeColor = Color.Blue;
                    lbViolation.Text = "Đang chuyển dữ liệu lỗi vi phạm...";
                    break;
                case 32:
                    lbViolation.ForeColor = Color.Green;
                    lbViolation.Text = "Chuyển dữ liệu lỗi vi phạm thành công!";
                    break;
                case 33:
                    lbViolation.ForeColor = Color.Red;
                    lbViolation.Text = "Chuyển dữ liệu lỗi vi phạm thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;
                case 41:
                    this.Height += 25;
                    lbSchedule.ForeColor = Color.Blue;
                    lbSchedule.Text = "Đang chuyển dữ liệu môn thi...";
                    break;
                case 42:
                    lbSchedule.ForeColor = Color.Green;
                    lbSchedule.Text = "Chuyển dữ liệu môn thi thành công!";
                    break;
                case 43:
                    lbSchedule.ForeColor = Color.Red;
                    lbSchedule.Text = "Chuyển dữ liệu môn thi thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;

                case 51:
                    this.Height += 25;
                    lbShift.ForeColor = Color.Blue;
                    lbShift.Text = "Đang chuyển dữ liệu ca thi...";
                    break;
                case 52:
                    lbShift.ForeColor = Color.Green;
                    lbShift.Text = "Chuyển dữ liệu ca thi thành công!";
                    break;
                case 53:
                    lbShift.ForeColor = Color.Red;
                    lbShift.Text = "Chuyển dữ liệu ca thi thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;
                case 61:
                    this.Height += 25;
                    lbContestant.ForeColor = Color.Blue;
                    lbContestant.Text = "Đang chuyển dữ liệu thí sinh...";
                    break;
                case 62:
                    lbContestant.ForeColor = Color.Green;
                    lbContestant.Text = "Chuyển dữ liệu thí sinh thành công!";
                    break;
                case 63:
                    lbContestant.ForeColor = Color.Red;
                    lbContestant.Text = "Chuyển dữ liệu thí sinh thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;
                case 71:
                    this.Height += 25;
                    lbExam.ForeColor = Color.Blue;
                    lbExam.Text = "Đang chuyển dữ liệu hội đồng thi...";
                    break;
                case 72:

                    lbExam.ForeColor = Color.Green;
                    lbExam.Text = "Chuyển dữ liệu hội đồng thi thành công!";
                    break;
                case 73:
                    lbExam.ForeColor = Color.Red;
                    lbExam.Text = "Chuyển dữ liệu hội đồng thi thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;
                case 81:
                    this.Height += 25;
                    lbTest.ForeColor = Color.Blue;
                    lbTest.Text = "Đang chuyển dữ liệu đề thi...";
                    break;
                case 82:

                    lbTest.ForeColor = Color.Green;
                    lbTest.Text = "Chuyển dữ liệu đề thi thành công!";
                    break;
                case 83:
                    lbTest.ForeColor = Color.Red;
                    lbTest.Text = "Chuyển dữ liệu đề thi thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;
                case 111:
                    this.Height += 25;
                    lbPosition.ForeColor = Color.Blue;
                    lbPosition.Text = "Đang chuyển dữ liệu chức vụ...";
                    break;
                case 112:
                    lbPosition.ForeColor = Color.Green;
                    lbPosition.Text = "Chuyển dữ liệu chức vụ thành công!";
                    break;
                case 113:
                    lbPosition.ForeColor = Color.Red;
                    lbPosition.Text = "Chuyển dữ liệu chức vụ thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;
                case 121:
                    this.Height += 25;
                    lbContest.ForeColor = Color.Blue;
                    lbContest.Text = "Đang chuyển dữ liệu kỳ thi...";
                    break;
                case 122:

                    lbContest.ForeColor = Color.Green;
                    lbContest.Text = "Chuyển dữ liệu kỳ thi thành công!";
                    break;
                case 123:
                    lbContest.ForeColor = Color.Red;
                    lbContest.Text = "Chuyển dữ liệu kỳ thi thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;
                case 131:
                    this.Height += 25;
                    lbLocation.ForeColor = Color.Blue;
                    lbLocation.Text = "Đang chuyển dữ liệu địa điểm thi...";
                    break;
                case 132:

                    lbLocation.ForeColor = Color.Green;
                    lbLocation.Text = "Chuyển dữ liệu địa điểm thi thành công!";
                    break;
                case 133:
                    lbLocation.ForeColor = Color.Red;
                    lbLocation.Text = "Chuyển dữ liệu địa điểm thi thất bại " + pgbLoading.Value.ToString() + "%!";
                    break;
                default:
                    this.Height += 25;
                    if(status==_lsDvisionShiftID.Count)
                    lbDivision.ForeColor = Color.Green;
                    else lbDivision.ForeColor = Color.Blue;
                    lbDivision.Text = "Chuyển Xong " + status.ToString() + " ca thi";
                    break;
            }
        }
        public int RoomTest()//2. 
        {
            status = 21;
            if (lbRoomTest.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            Main.Main model = new Main.Main();
            List<Main.ROOMTEST> lsRoom = new List<Main.ROOMTEST>();
            lsRoom = model.ROOMTESTS.Where(x => x.LocationID==AppSession.LocationID).ToList();
            Quiz.Quiz quiz = new Quiz.Quiz();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsRoom)
            {
                if (quiz.ROOMTESTS.Where(x => x.RoomTestID == item.RoomTestID).ToList().Count == 0)
                {
                    Quiz.ROOMTEST room = new Quiz.ROOMTEST();
                    room.RoomTestID = item.RoomTestID;
                    room.RoomTestName = item.RoomTestName;
                    room.MaxSeatMount = item.MaxSeatMount;
                    room.MaxSupervisor = item.MaxSupervisor;
                    room.Status = item.Status;
                    room.LocationID = (Int32)item.LocationID;
                    try
                    {
                        quiz.ROOMTESTS.Add(room);
                        quiz.SaveChanges();
                        int count2 = 0;
                        foreach (var roomdiaitem in item.ROOMDIAGRAMS)
                        {
                            Quiz.ROOMDIAGRAM roomdia = new Quiz.ROOMDIAGRAM();
                            roomdia.RoomDiagramID = roomdiaitem.RoomDiagramID;
                            roomdia.ComputerCode = roomdiaitem.ComputerCode;
                            roomdia.ComputerName = roomdiaitem.ComputerName;
                            roomdia.Status = roomdiaitem.Status;
                            roomdia.RoomTestID = roomdiaitem.RoomTestID;
                            try
                            {
                                quiz.ROOMDIAGRAMS.Add(roomdia);
                                quiz.SaveChanges();
                                count2++;
                            }
                            catch
                            { }
                        }
                        if(count2==item.ROOMDIAGRAMS.Count)
                        {
                            count++;
                            bw.ReportProgress(count / lsRoom.Count);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi chuyển ROOMTESTS: \n" + room.RoomTestID.ToString() + ": " + room.RoomTestName + ex.Message);
                    }
                    
                }


            }
            if (count == lsRoom.Count)
            {
                status = 22;
                if (lbRoomTest.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 22;
                if (lbRoomTest.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return count - lsRoom.Count;
            }

        }
        public int Violation()//3. 
        {
            status = 31;
            if (lbViolation.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            Main.Main model = new Main.Main();
            List<Main.VIOLATION> lsViolation = new List<Main.VIOLATION>();
            lsViolation = model.VIOLATIONS.ToList();
            Quiz.Quiz quiz = new Quiz.Quiz();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsViolation)
            {
                try
                {
                    if (quiz.VIOLATIONS.Where(x => x.ViolationID == item.ViolationID).Count() == 0)
                    {
                        Quiz.VIOLATION violation = new Quiz.VIOLATION();
                        violation.ViolationID = item.ViolationID;
                        violation.ViolationName = item.ViolationName;
                        violation.Description = item.Description;
                        violation.Level = item.Level;
                        violation.Status = item.Status;

                        quiz.VIOLATIONS.Add(violation);
                        quiz.SaveChanges();


                    }
                    count++;
                    bw.ReportProgress(count / lsViolation.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển VIOLATIONS: " + item.ViolationID.ToString() + ": " + item.ViolationName + "\n" + ex.Message);
                }



            }
            if (count == lsViolation.Count)
            {
                status = 32;
                if (lbViolation.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 33;
                if (lbViolation.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return count - lsViolation.Count;
            }

        }
        public int Schedule() //4.  bảng schedule, subject
        {
            status = 41;
            if (lbSchedule.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            Main.Main model = new Main.Main();
           
            List<Main.SCHEDULE> lsSchedule = new List<Main.SCHEDULE>();
            int count = 0;
            try
            {
               
                lsSchedule = model.SCHEDULES.Where(x => x.ContestID == AppSession.ContestID).ToList();
                Quiz.Quiz quiz = new Quiz.Quiz();
               
                bw.ReportProgress(0);
            }
            catch (Exception e)
            {
                string a = e.Message;
            }
            foreach (var item in lsSchedule)
            {
                try
                {
                    Quiz.SCHEDULE schedule = new Quiz.SCHEDULE();
                    Quiz.SUBJECT subject = new Quiz.SUBJECT();
                    if (quiz.SUBJECTS.Where(x => x.SubjectID == item.SUBJECT.SubjectID).Count() == 0)
                    {
                        subject.SubjectID = item.SUBJECT.SubjectID;
                        subject.SubjectName = item.SUBJECT.SubjectName;
                        subject.SubjectCode = item.SUBJECT.SubjectCode;
                        subject.Status = item.SUBJECT.Status;
                        quiz.SUBJECTS.Add(subject);
                        quiz.SaveChanges();
                    }
                    if (quiz.SCHEDULES.Where(x => x.ScheduleID == item.ScheduleID).Count() == 0)
                    {
                        schedule.ScheduleID = item.ScheduleID;
                        schedule.TimeOfTest = item.TimeOfTest;
                        schedule.TimeToSubmit = item.TimeToSubmit;
                        schedule.Status = item.Status;
                        schedule.ContestID = item.ContestID;
                        schedule.ContestTypeName = item.CONTEST_TYPES.ContestTypeName;
                        schedule.SubjectID = item.SubjectID;
                        quiz.SCHEDULES.Add(schedule);
                        quiz.SaveChanges();
                    }
                    count++;
                    bw.ReportProgress(count * 100 / lsSchedule.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển SCHEDULES: " + item.ScheduleID.ToString() + " " + item.SUBJECT.SubjectName + " \n" + ex.Message);
                }
            }
            if (count == lsSchedule.Count)
            {
                status = 42;
                if (lbSchedule.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 43;
                if (lbSchedule.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return count - lsSchedule.Count;
            }

        }

        public int Position() //1.1 bảng  POSITIONS
        {
            status = 111;
            if (lbPosition.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            model = new Main.Main();
            quiz = new Quiz.Quiz();
            List<Main.POSITION> lsPosition = new List<Main.POSITION>();
            lsPosition = model.POSITIONS.ToList();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsPosition)
            {
                try
                {
                    if (quiz.POSITIONS.Where(x => x.PositionID == item.PositionID).Count() == 0)
                    {
                        Quiz.POSITION position = new Quiz.POSITION();
                        position.PositionID = item.PositionID;
                        position.PositionCode = item.PositionCode;
                        position.PositionName = item.PositionName;
                        position.Permission = item.Permission;
                        position.Status = item.Status;
                        quiz.POSITIONS.Add(position);
                        quiz.SaveChanges();
                    }
                    count++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển POSITIONS " + item.PositionID.ToString() + ": " + item.PositionName + "\n" + ex.Message);
                }
            }
            if (count == lsPosition.Count)
            {

                List<Main.STAFFS_POSITIONS> ls = new List<Main.STAFFS_POSITIONS>();
                ls = model.STAFFS_POSITIONS.ToList();
                int count2 = 0;
                foreach (var itemst in ls)
                {
                    try
                    {
                        if (quiz.STAFFS.Where(x => x.StaffID == itemst.StaffID).Count() == 0)
                        {
                            Quiz.STAFFS_POSITIONS staff = new Quiz.STAFFS_POSITIONS();
                            staff.PositionID = itemst.PositionID;
                            staff.StaffPositionID = itemst.StaffPositionID;
                            staff.StaffID = itemst.StaffID;
                            quiz.STAFFS_POSITIONS.Add(staff);
                            quiz.SaveChanges();
                        }
                        count2++;
                        bw.ReportProgress(count2 * 100 / ls.Count);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi chuyển STAFFS_POSITIONS\n" + itemst.StaffPositionID.ToString() + "\n" + ex.Message);
                    }
                }
                if (count2 == ls.Count)
                {
                    status = 112;
                    if (lbPosition.InvokeRequired)
                    {
                        SetLB set = new SetLB(SetLabelText);
                        Invoke(set);
                    }
                    else
                    {
                        SetLabelText();
                    }
                    return 1;
                }
                else
                {
                    status = 123;
                    if (lbPosition.InvokeRequired)
                    {
                        SetLB set = new SetLB(SetLabelText);
                        Invoke(set);
                    }
                    else
                    {
                        SetLabelText();
                    }
                    return count2 - ls.Count;
                }

            }
            else
                return count - lsPosition.Count;
        }
        public int Contest() //1.2 bảng Contest
        {
            status = 121;
            if (lbContest.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            model = new Main.Main();
            quiz = new Quiz.Quiz();
            List<Main.CONTEST> lsContest = new List<Main.CONTEST>();
            lsContest = model.CONTESTS.Where(x=>x.ContestID==AppSession.ContestID).ToList();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsContest)
            {
                try
                {
                    Quiz.CONTEST contest = new Quiz.CONTEST();
                    if (quiz.CONTESTS.Where(x => x.ContestID == item.ContestID).Count() == 0)
                    {

                        contest.ContestID = item.ContestID;
                        contest.Status = 7;
                        contest.ContestName = item.ContestName;
                        contest.Description = item.Description;
                        contest.CreatedDate = item.CreatedDate;
                        contest.EndDate = item.EndDate;
                        contest.AcceptedDate = item.AcceptedDate;
                        contest.BeginRegistration = item.BeginRegistration;
                        contest.EndRegistration = item.EndRegistration;
                        contest.CreatedQuestionEndDate = item.CreatedQuestionEndDate;
                        contest.CreatedQuestionStartDate = item.CreatedQuestionStartDate;
                        contest.SchoolYear = item.SchoolYear;
                        contest.CreatedStaffID = item.CreatedStaffID;
                        contest.AcceptedStaffID = item.AcceptedStaffID;

                        quiz.CONTESTS.Add(contest);
                        quiz.SaveChanges();
                    }
                    count++;
                    bw.ReportProgress(count * 100 / lsContest.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển CONTESTS " + item.ContestName + "\n" + ex.Message);
                }
            }
            if (count == lsContest.Count)
            {
                status = 122;
                if (lbContest.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 123;
                if (lbContest.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return count - lsContest.Count;
            }
        }
        public int Location2() //1.3 bảng Location
        {
            status = 131;
            if (lbLocation.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            model = new Main.Main();
            quiz = new Quiz.Quiz();
            List<Main.LOCATION> lsLocation = new List<Main.LOCATION>();
            lsLocation = model.LOCATIONS.Where(x => x.LocationID== AppSession.LocationID).ToList();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsLocation)
            {
                try
                {
                    if (quiz.LOCATIONS.Where(x => x.LocationID == item.LocationID).Count() == 0)
                    {
                        Quiz.LOCATION location = new Quiz.LOCATION();
                        location.ContestID = item.ContestID;
                        location.Status = item.Status;
                        location.LocationName = item.LocationName;
                        location.LocationID = item.LocationID;
                        quiz.LOCATIONS.Add(location);
                        quiz.SaveChanges();
                    }
                    count++;
                    bw.ReportProgress(count * 100 / lsLocation.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển LOCATIONS " + item.LocationID.ToString() + item.LocationName + "\n" + ex.Message);
                }
            }
            if (count == lsLocation.Count)
            {
                status = 132;
                if (lbLocation.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 133;
                if (lbLocation.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return count - lsLocation.Count;

            }
        }
        public int Contestant() //6. chuyển BẢNG CONTESTANTS, FINGERPRINTS, CONTESTANT_SHIFT(có SCHEDULES trước)
        {
            status = 61;
            if (lbContestant.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            Main.Main model = new Main.Main();
            List<Main.CONTESTANT> lsContestant = new List<Main.CONTESTANT>();
            lsContestant = model.CONTESTANTS.Where(x => x.REGISTER.ContestID == AppSession.ContestID).ToList();
            Quiz.Quiz quiz = new Quiz.Quiz();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsContestant)
            {
                try
                {
                    if (quiz.CONTESTANTS.Where(x => x.ContestantID == item.ContestantID).Count() == 0)
                    {
                        Quiz.CONTESTANT contestant_quiz = new Quiz.CONTESTANT();
                        contestant_quiz.ContestantCode = item.ContestantCode;
                        contestant_quiz.ContestantID = item.ContestantID;
                        contestant_quiz.CurrentAddress = item.REGISTER.CurrentAddress;
                        //contestant_quiz.ContestantType = item.REGISTER.CONTESTANT_TYPES.ContestantTypeName;
                        contestant_quiz.DOB = (Int32)item.REGISTER.DOB;
                        contestant_quiz.Ethnic = item.REGISTER.Ethnic;
                        contestant_quiz.FullName = item.REGISTER.FullName;
                        contestant_quiz.HighSchool = item.REGISTER.HighSchool;
                        contestant_quiz.IdentityCardNumber = item.REGISTER.IdentityCardNumber;
                        contestant_quiz.Image = item.REGISTER.Image;
                        contestant_quiz.PlaceOfBirth = item.REGISTER.PlaceOfBirth;
                        contestant_quiz.Sex = (Int32)item.REGISTER.Sex;
                        contestant_quiz.Status = item.Status;
                        contestant_quiz.StudentCode = item.REGISTER.StudentCode;
                        contestant_quiz.TrainingSystem = item.REGISTER.TrainingSystem.ToString();
                        contestant_quiz.Unit = item.REGISTER.Unit;
                        try
                        {
                            quiz.CONTESTANTS.Add(contestant_quiz);
                            quiz.SaveChanges();
                        }
                       catch(Exception ex)
                        {
                            MessageBox.Show("Lỗi chuyển CONTESTANTS " + item.ContestantID.ToString() + item.REGISTER.FullName + "\n" + ex.Message);

                        }
                        foreach (var i in item.FINGERPRINTS)
                        {
                            Quiz.FINGERPRINT finger = new Quiz.FINGERPRINT();
                            finger.FingerprintID = i.FingerprintID;
                            finger.FingerprintImage = i.FingerprintImage;
                            finger.FilePath = i.FilePath;
                            finger.TimeSaveFingerprint = i.TimeSaveFingerprint;
                            finger.Status = i.Status;
                            finger.ContestantID = i.ContestantID;
                            try
                            {
                                quiz.FINGERPRINTS.Add(finger);
                                quiz.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi chuyển FINGERPRINTS " + item.ContestantID.ToString() + item.REGISTER.FullName + "\n" + ex.Message);
                            }

                        }
                        foreach (var i in item.CONTESTANTS_SHIFTS)
                        {
                            int kt = 0;
                            foreach (int id in _lsDvisionShiftID)
                            {
                                if (i.ShiftID == id)
                                {
                                    kt = 1;
                                    break;
                                }
                            }
                            if (kt == 1)
                            {
                                Quiz.CONTESTANTS_SHIFTS conshift = new Quiz.CONTESTANTS_SHIFTS();
                                conshift.ContestantShiftID = i.ContestantShiftID;
                                conshift.DivisionShiftID = i.ShiftID;
                                conshift.ScheduleID = i.ScheduleID;
                                conshift.Status = item.Status;
                                conshift.ContestantID = i.ContestantID;
                                try
                                {
                                    quiz.CONTESTANTS_SHIFTS.Add(conshift);
                                    quiz.SaveChanges();
                                    
                                }
                                catch(Exception ex)
                                {
                                    MessageBox.Show("Lỗi ContestantShift "+ex.Message);
                                }
                                
                            }
                        }
                    }
                    count++;
                    bw.ReportProgress(count * 100 / lsContestant.Count);
                }
                catch (Exception ex)
                {
                }
            }
            if (count == lsContestant.Count)
            {
                status = 62;
                if (lbContestant.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 63;
                if (lbContestant.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return count - lsContestant.Count;
            }


        }
        public int Staff() //1.bảng STAFFS
        {
            status = 11;
            if (lbStaff.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            Main.Main model = new Main.Main();
            List<Main.STAFF> lsstaff = new List<Main.STAFF>();
            lsstaff = model.STAFFS.ToList();
            Quiz.Quiz quiz = new Quiz.Quiz();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsstaff)
            {
                try
                {
                    if (quiz.STAFFS.Where(x => x.StaffID == item.StaffID).Count() == 0)
                    {
                        Quiz.STAFF staff = new Quiz.STAFF();
                        staff.FullName = item.FullName;
                        //staff.Username = item.StaffID.ToString();
                        staff.DOB = item.DOB;
                        staff.Sex = item.Sex;
                        staff.IdentityCardNumber = item.IdentityCardNumber;
                        staff.AcademicRank = item.AcademicRank;
                        staff.Degree = item.Degree;
                        staff.Status = item.Status;
                        staff.StaffID = item.StaffID;
                        quiz.STAFFS.Add(staff);
                        quiz.SaveChanges();
                    }
                    count++;
                    bw.ReportProgress(count * 100 / lsstaff.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển STAFFS " + item.StaffID.ToString() + ": " + item.FullName + "\n" + ex.Message);
                }
            }
            if (count == lsstaff.Count)
            {
                status = 12;
                if (lbStaff.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 13;
                if (lbStaff.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }

                return count - lsstaff.Count;
            }

        }
        public int Shift() //5. bản SHIFTS, DIVISION_SHIFTS (có staff, roomtesst trước)
        {
            status = 51;
            if (lbShift.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            bw.ReportProgress(0);
            Main.Main model = new Main.Main();
            List<Main.SHIFT> lsShift = new List<Main.SHIFT>();
            lsShift = model.SHIFTS.Where(x => x.ContestID == AppSession.ContestID).ToList();
            Quiz.Quiz quiz = new Quiz.Quiz();
            int count = 0;
            foreach (var item in lsShift)
            {
                try
                {
                    if (quiz.SHIFTS.Where(x => x.ShiftID == item.ShiftID).Count() == 0)
                    {
                        Quiz.SHIFT shift = new Quiz.SHIFT();
                        shift.ContestID = item.ContestID;
                        shift.ShiftName = item.ShiftName;
                        shift.ShiftID = item.ShiftID;
                        shift.ShiftDate = item.ShiftDate;
                        shift.StartTime = item.StartTime;
                        shift.EndTime = item.EndTime;
                        shift.Status = item.Status;
                        quiz.SHIFTS.Add(shift);
                        quiz.SaveChanges();
                        int count2 = 0;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển SHIFTS " + item.ShiftID.ToString() + ": " + item.ShiftName + "\n" + ex.Message);
                }

            }
            List<DIVISION_SHIFTS> lstdivisionshift = new List<DIVISION_SHIFTS>();
            lstdivisionshift = model.DIVISION_SHIFTS.Where(x => x.SHIFT.ContestID == AppSession.ContestID).ToList();
            foreach (var i in lstdivisionshift)
            {
                int kt = 0;
                foreach (int id in _lsDvisionShiftID)
                {
                    if (i.DivisionShiftID == id)
                    {
                        kt = 1;
                        break;
                    }
                }
                if (kt == 1)
                {
                    Quiz.DIVISION_SHIFTS divisionshift = new Quiz.DIVISION_SHIFTS();
                    divisionshift.DivisionShiftID = i.DivisionShiftID;
                    divisionshift.Status = i.Status;
                    divisionshift.ShiftID = i.ShiftID;
                    //divisionshift.SupervisorID = i.SupervisorID;
                    divisionshift.RoomTestID = i.RoomTestID;
                    divisionshift.Key = i.Key;
                    divisionshift.CheckFinger = 2;
                    try
                    {
                        quiz.DIVISION_SHIFTS.Add(divisionshift);
                        quiz.SaveChanges();
                        count++;
                        bw.ReportProgress(count * 100 / _lsDvisionShiftID.Count);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi chuyển DIVISION_SHIFTS " + i.DivisionShiftID.ToString() + "\n" + ex.Message);
                    }
                }

            }
            if (count == _lsDvisionShiftID.Count)
            {
                status = 52;
                if (lbShift.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 53;
                if (lbShift.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
            }
            return count - lsShift.Count;

        }
        public int BagOfTest(int _dsID) //7. bang BAGOFTEST,TEST,TEST_DETAILS, QUESTION_TEMP, SUBQUESTION_TEMP, ANSWERS_TEMP
        {
            status = 81;
            if (lbTest.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            bw.ReportProgress(0);
            Main.Main main = new Main.Main();
            Quiz.Quiz quiz = new Quiz.Quiz();
            Main.BAGOFTEST bg = new BAGOFTEST();
            bg = main.BAGOFTESTS.Where(x => x.DivisionShiftID == _dsID).FirstOrDefault();
            if (bg != null)
            {
                Quiz.BAGOFTEST bagOfTest = new Quiz.BAGOFTEST();
                bagOfTest.BagOfTestID = bg.BagOfTestID;
                bagOfTest.DivisionShiftID = bg.DivisionShiftID;
                bagOfTest.Status = bg.Status;
                bagOfTest.NumberOfTest = bg.NumberOfTest;
                //luu bag of test vao csdl de lay BagOfTestID
                try
                {
                    if (quiz.BAGOFTESTS.Where(x => x.BagOfTestID == bg.BagOfTestID).Count() == 0)
                    {
                        
                        Quiz.DIVISION_SHIFTS dsquiz = new Quiz.DIVISION_SHIFTS();
                        dsquiz = quiz.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == _dsID).SingleOrDefault();
                        string key = dsquiz.Key;
                        if (key==null)
                        {
                            //key = new Random().Next(100000, 999999).ToString();
                            //dsquiz.Key = key;
                            MessageBox.Show("Đề thi của ca thi " + dsquiz.SHIFT.ShiftName + ", phòng thi " + dsquiz.ROOMTEST.RoomTestName + " chưa được niêm phong!");
                            return 0;
                        }
                        _encrypt = new Encrypter(key);
                        quiz.SaveChanges();
                        quiz.BAGOFTESTS.Add(bagOfTest);
                        quiz.SaveChanges();
                        if (bg.TESTS.Count == 0)
                        {
                            MessageBox.Show("Túi đề thi của phòng " + dsquiz.ROOMTEST.RoomTestName + ", ca thi " + dsquiz.SHIFT.ShiftName + " chưa có đề thi! Vui lòng kiểm tra lại và chuyển lại CSDL!");
                            return 0;
                        }
                    }
                    int count = 0;
                   
                    foreach (var itemtest in bg.TESTS)
                    {

                        Quiz.TEST test = new Quiz.TEST()
                        {
                            BagOfTestID = itemtest.BagOfTestID,
                            SubjectID = itemtest.SubjectID,
                            TestID = itemtest.TestID,
                            Status = 1
                        };
                        //Luu Test vao csdls       
                        try
                        {
                            if (quiz.TESTS.Where(x => x.TestID == test.TestID).Count() == 0)
                            {
                                quiz.TESTS.Add(test);
                                quiz.SaveChanges();
                            }

                            foreach (var it in main.TEST_DETAILS.Where(x => x.TestID == itemtest.TestID))
                            {
                                Quiz.TEST_DETAILS tsDetail = new Quiz.TEST_DETAILS();
                                Quiz.QUESTIONS_TEMP question = new Quiz.QUESTIONS_TEMP();
                                Quiz.QUESTION question2 = new Quiz.QUESTION();
                                if (quiz.QUESTIONS_TEMP.Where(x => x.QuestionID == it.QuestionID && x.DivisionShiftID == _dsID).Count() == 0)
                                {
                                    question.QuestionID = it.QuestionID;
                                    question.QuestionContent = _encrypt.Encrypt(it.QUESTION.QuestionContent);
                                    question.QuestionFormat = (Int32)it.QUESTION.QuestionFormat;
                                    question.Level = it.QUESTION.Level;
                                    question.IsSingleChoice = it.QUESTION.QUESTION_TYPES.IsSingleChoice;
                                    question.IsQuiz = it.QUESTION.QUESTION_TYPES.IsQuiz;
                                    question.IsQuestionContent = it.QUESTION.QUESTION_TYPES.IsQuestionContent;
                                    question.IsParagarph = it.QUESTION.QUESTION_TYPES.IsParagraph;
                                    question.NumberAnswer = it.QUESTION.QUESTION_TYPES.NumberAnswer;
                                    question.NumberSubQuestion = it.QUESTION.QUESTION_TYPES.NumberSubQuestion;
                                    question.DivisionShiftID = _dsID;
                                    quiz.QUESTIONS_TEMP.Add(question);
                                    quiz.SaveChanges();
                                    if (quiz.QUESTIONS.Where(x => x.QuestionID == it.QuestionID).ToList().Count == 0)
                                    {
                                        question2.QuestionID = it.QuestionID;
                                        //question2.QuestionContent = it.QUESTION.QuestionContent;
                                        question2.QuestionFormat = (Int32)it.QUESTION.QuestionFormat;
                                        question2.Level = it.QUESTION.Level;
                                        question2.IsSingleChoice = it.QUESTION.QUESTION_TYPES.IsSingleChoice;
                                        question2.IsQuiz = it.QUESTION.QUESTION_TYPES.IsQuiz;
                                        question2.IsQuestionContent = it.QUESTION.QUESTION_TYPES.IsQuestionContent;
                                        question2.IsParagraph = it.QUESTION.QUESTION_TYPES.IsParagraph;
                                        question2.NumberAnswer = it.QUESTION.QUESTION_TYPES.NumberAnswer;
                                        question2.NumberSubQuestion = it.QUESTION.QUESTION_TYPES.NumberSubQuestion;

                                        try
                                        {
                                            quiz.QUESTIONS_TEMP.Add(question);
                                            quiz.QUESTIONS.Add(question2);
                                            quiz.SaveChanges();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Lỗi chuyển QUESTIONS: " + it.QuestionID.ToString() + "\n" + ex.Message);
                                        }
                                    }
                                    var lsSubquestion = it.QUESTION.SUBQUESTIONS;
                                    foreach (var itemsub in lsSubquestion)
                                    {
                                        if (quiz.SUBQUESTIONS_TEMP.Where(x => x.SubQuestionID == itemsub.SubQuestionID && x.DivisionShiftID == _dsID).Count() == 0)
                                        {
                                            Quiz.SUBQUESTIONS_TEMP subtemp = new Quiz.SUBQUESTIONS_TEMP();
                                            subtemp.SubQuestionID = itemsub.SubQuestionID;
                                            subtemp.SubQuestionContent = _encrypt.Encrypt(itemsub.SubQuestionContent);
                                            subtemp.QuestionID = itemsub.QuestionID;
                                            subtemp.Score = it.Score;
                                            subtemp.DivisionShiftID = _dsID;
                                            quiz.SUBQUESTIONS_TEMP.Add(subtemp);
                                            if (quiz.SUBQUESTIONS.Where(x => x.SubQuestionID == itemsub.SubQuestionID).ToList().Count == 0)
                                            {
                                                Quiz.SUBQUESTION sub = new Quiz.SUBQUESTION();
                                                sub.SubQuestionID = itemsub.SubQuestionID;
                                                //sub.SubQuestionContent = itemsub.SubQuestionContent;
                                                sub.Score = it.Score;
                                                sub.QuestionID = itemsub.QuestionID;

                                                try
                                                {

                                                    quiz.SUBQUESTIONS.Add(sub);
                                                    quiz.SaveChanges();
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show("Lỗi chuyển SUBQUESTIONS " + itemsub.SubQuestionID.ToString() + "\n" + ex.Message);
                                                }


                                            }
                                            var lsAnswer = itemsub.ANSWERS;
                                            foreach (var itemans in lsAnswer)
                                            {
                                                Quiz.ANSWERS_TEMP anstemp = new Quiz.ANSWERS_TEMP();
                                                Quiz.ANSWER ans = new Quiz.ANSWER();
                                                anstemp.AnswerID = itemans.AnswerID;
                                                anstemp.AnswerContent = itemans.AnswerContent;
                                                anstemp.IsCorrect = itemans.IsCorrect;
                                                anstemp.SubQuestionID = itemans.SubQuestionID;
                                                anstemp.DivisionShiftID = _dsID;
                                                quiz.ANSWERS_TEMP.Add(anstemp);
                                                quiz.SaveChanges();
                                                if (quiz.ANSWERS.Where(x => x.AnswerID == itemans.AnswerID).ToList().Count == 0)
                                                {
                                                    ans.AnswerID = itemans.AnswerID;
                                                    ans.AnswerContent = itemans.AnswerContent;
                                                    ans.IsCorrect = itemans.IsCorrect;
                                                    ans.SubQuestionID = itemans.SubQuestionID;
                                                    try
                                                    {
                                                        quiz.ANSWERS.Add(ans);
                                                        quiz.ANSWERS_TEMP.Add(anstemp);
                                                        quiz.SaveChanges();
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MessageBox.Show("Lỗi chuyển ANSWERS " + itemans.AnswerID.ToString() + "\n" + ex.Message);
                                                    }
                                                }


                                            }

                                        }
                                    }
                                }

                                //if (quiz.TESTS.Where(x => x.TestID == testid).ToList().Count == 0)
                                // {

                                tsDetail.TestID = it.TestID;
                                tsDetail.RandomAnswer = it.RandomAnswer;
                                tsDetail.NumberIndex = it.NumberIndex;
                                tsDetail.Score = it.Score;
                                tsDetail.TestDetailID = it.TestDetailID;
                                tsDetail.QuestionID = it.QuestionID;
                                tsDetail.Status = it.Status;
                                try
                                {
                                    //if (quiz.TEST_DETAILS.Where(x => x.TestDetailID == test.TestID).Count() == 0)
                                    //{
                                        quiz.TEST_DETAILS.Add(tsDetail);
                                        quiz.SaveChanges();
                                    //}
                                   
                                }
                                catch(Exception e)
                                {
                                    //MessageBox.Show("Lỗi chuyển TESTS_DETAILS: " + it.TestDetailID.ToString() + "\n" + e.Message);
                                }

                                // }

                                //lưu subquestion


                            }
                            count++;
                            bw.ReportProgress(count * 100 / bg.TESTS.Count);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Lỗi chuyển TESTS: " + itemtest.TestID.ToString() + "\n" + e.Message);
                        }
                    }

                    if (count == bg.TESTS.Count)
                    {
                        countSuccessfull++;
                        status = countSuccessfull;
                        if (lbDivision.InvokeRequired)
                        {
                            SetLB set = new SetLB(SetLabelText);
                            Invoke(set);
                        }
                        else
                        {
                            SetLabelText();
                        }

                    }
                    else
                    {
                        status = 83;
                        if (lbTest.InvokeRequired)
                        {
                            SetLB set = new SetLB(SetLabelText);
                            Invoke(set);
                        }
                        else
                        {
                            SetLabelText();
                        }
                    }
                    if (countSuccessfull == _lsDvisionShiftID.Count)
                    {

                        status = 82;
                        if (lbTest.InvokeRequired)
                        {
                            SetLB set = new SetLB(SetLabelText);
                            Invoke(set);
                        }
                        else
                        {
                            SetLabelText();
                        }

                    }
                    else
                    {
                        status = 83;
                        if (lbTest.InvokeRequired)
                        {
                            SetLB set = new SetLB(SetLabelText);
                            Invoke(set);
                        }
                        else
                        {
                            SetLabelText();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển BAGOFTESTS: " + bagOfTest.BagOfTestID.ToString() + "\n" + ex.Message);
                    return 0;
                }
            }
            else
            {
                DIVISION_SHIFTS dv = new DIVISION_SHIFTS();
                dv = main.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == _dsID).SingleOrDefault();
                MessageBox.Show("Ca thi " + dv.SHIFT.ShiftName + " phòng " + dv.ROOMTEST.RoomTestName + " không có đề thi!");
            }
            //}
            //}
            return 1;
        }
        public int ExaminationCouncil()//7
        {
            status = 71;
            if (lbExam.InvokeRequired)
            {
                SetLB set = new SetLB(SetLabelText);
                Invoke(set);
            }
            else
            {
                SetLabelText();
            }
            bw.ReportProgress(0);
            Main.Main model = new Main.Main();
            List<Main.EXAMINATIONCOUNCIL_STAFFS> lsExamStaff = new List<Main.EXAMINATIONCOUNCIL_STAFFS>();
            lsExamStaff = model.EXAMINATIONCOUNCIL_STAFFS.Where(x => x.LocationID== AppSession.LocationID).ToList();
            List<Main.EXAMINATIONCOUNCIL_POSITIONS> lsExamPosition = new List<Main.EXAMINATIONCOUNCIL_POSITIONS>();
            lsExamPosition = model.EXAMINATIONCOUNCIL_POSITIONS.ToList();
            Quiz.Quiz quiz = new Quiz.Quiz();
            int count1 = 0;
            int count2 = 0;
            foreach (var i in lsExamPosition)
            {
                try
                {
                    if (quiz.EXAMINATIONCOUNCIL_POSITIONS.Where(x => x.ExaminationCouncil_PositionID == i.ExaminationCouncil_PositionID).Count() == 0)
                    {
                        Quiz.EXAMINATIONCOUNCIL_POSITIONS examposition = new Quiz.EXAMINATIONCOUNCIL_POSITIONS();
                        examposition.ExaminationCouncil_PositionID = i.ExaminationCouncil_PositionID;
                        examposition.ExaminationCouncil_PositionCode = i.ExaminationCouncil_PositionCode;
                        examposition.ExaminationCouncil_PositionName = i.ExaminationCouncil_PositionName;
                        examposition.Permission = i.Permission;
                        examposition.Status = i.Status;
                        quiz.EXAMINATIONCOUNCIL_POSITIONS.Add(examposition);
                        quiz.SaveChanges();
                    }
                    count1++;
                }
                catch (Exception ex)
                {
                    string a = ex.ToString();
                }

            }
            if (count1 == lsExamPosition.Count)
            {
                foreach (var item in lsExamStaff)
                {
                    try
                    {
                        if (quiz.EXAMINATIONCOUNCIL_STAFFS.Where(x => x.ExaminationCouncil_StaffID == item.ExaminationCouncil_StaffID).Count() == 0)
                        {
                            Quiz.EXAMINATIONCOUNCIL_STAFFS examstaff = new Quiz.EXAMINATIONCOUNCIL_STAFFS();
                            examstaff.ExaminationCouncil_StaffID = item.ExaminationCouncil_StaffID;
                            examstaff.ContestID = item.ContestID;
                            examstaff.StaffID = item.StaffID;
                            examstaff.ExaminationCouncil_PositionID = item.ExaminationCouncil_PositionID;
                            examstaff.LocationID = item.LocationID;
                            examstaff.UserName = item.UserName;
                            examstaff.Password = item.Password;
                            examstaff.Status = item.Status;
                            quiz.EXAMINATIONCOUNCIL_STAFFS.Add(examstaff);
                            quiz.SaveChanges();
                            if(examstaff.EXAMINATIONCOUNCIL_POSITIONS.ExaminationCouncil_PositionCode=="DT")
                            {
                                foreach(int dvid in _lsDvisionShiftID)
                                {
                                    Quiz.DIVISIONSHIFT_SUPERVISOR disu = new Quiz.DIVISIONSHIFT_SUPERVISOR();
                                    disu.DivisionShiftID = dvid;
                                    disu.SupervisorID = examstaff.StaffID;
                                    quiz.DIVISIONSHIFT_SUPERVISOR.Add(disu);
                                    try
                                    {
                                        quiz.SaveChanges();
                                    }
                                    catch { }
                                }
                                
                                
                            }
                        }

                        count2++;
                        bw.ReportProgress(count2 * 100 / lsExamStaff.Count);
                    }
                    catch (Exception ex)
                    {
                        string a = ex.ToString();
                    }

                }
            }

            if (count2 == lsExamStaff.Count)
            {
                status = 72;
                if (lbExam.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();
                }
                return 1;
            }
            else
            {
                status = 73;
                if (lbExam.InvokeRequired)
                {
                    SetLB set = new SetLB(SetLabelText);
                    Invoke(set);
                }
                else
                {
                    SetLabelText();

                }
                return count2 - lsExamStaff.Count;
            }

        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true; // ho tro bao cao tien do
            bw.WorkerSupportsCancellation = true; // cho phep dung tien trinh
            // su kien
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }
    }
}
