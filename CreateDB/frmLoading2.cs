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
    public partial class frmLoading2 : Form
    {
        private BackgroundWorker bw;
        Encrypter _encrypt = null;
        //Main.Main model = new Main.Main();
        Quiz.Quiz quiz = new Quiz.Quiz();
        QuizMain.QuizMain mainquiz = new QuizMain.QuizMain();
        //int _dsID = 0;
        static int status = 0;
        // int countSuccessfull = 0;
        //List<int> _lsDvisionShiftID = new List<int>();
        public frmLoading2()
        {
            InitializeComponent();
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Hoàn Thành quá trình chuyển CSDL");
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
            Roomdiagram();
            Violation();
            Schedule();
            Shift();
            Contestant();
            ExaminationCouncil();

            BagOfTest();
            Tests();
            Questions();
            SubQuestions();
            Answers();
            TestDetail();
            Violation_contestant();
            ContestantTest();

            AnswerSheet();
            AnswerSheetDetail();
            divisionshift_supervisor();
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
                    
                    break;
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            //Main.Main model = new Main.Main();
            List<Quiz.STAFF> lsstaff = new List<Quiz.STAFF>();
            lsstaff = quiz.STAFFS.ToList();

            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsstaff)
            {
                try
                {
                    if (mainquiz.STAFFS.Where(x => x.StaffID == item.StaffID).Count() == 0)
                    {
                        QuizMain.STAFF staff = new QuizMain.STAFF();
                        staff.FullName = item.FullName;
                        //staff.Username = item.StaffID.ToString();
                        staff.DOB = item.DOB;
                        staff.Sex = item.Sex;
                        staff.IdentityCardNumber = item.IdentityCardNumber;
                        staff.AcademicRank = item.AcademicRank;
                        staff.Degree = item.Degree;
                        staff.Status = item.Status;
                        staff.StaffID = item.StaffID;
                        mainquiz.STAFFS.Add(staff);
                        mainquiz.SaveChanges();
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
        public int Position() //1.1 bảng  POSITIONSs taff_position
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.POSITION> lsPosition = new List<Quiz.POSITION>();
            lsPosition = quiz.POSITIONS.ToList();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsPosition)
            {
                try
                {
                    if (mainquiz.POSITIONS.Where(x => x.PositionID == item.PositionID).Count() == 0)
                    {
                        QuizMain.POSITION position = new QuizMain.POSITION();
                        position.PositionID = item.PositionID;
                        position.PositionCode = item.PositionCode;
                        position.PositionName = item.PositionName;
                        position.Permission = item.Permission;
                        position.Status = item.Status;
                        mainquiz.POSITIONS.Add(position);
                        mainquiz.SaveChanges();
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

                List<Quiz.STAFFS_POSITIONS> ls = new List<Quiz.STAFFS_POSITIONS>();
                ls = quiz.STAFFS_POSITIONS.ToList();
                int count2 = 0;
                foreach (var itemst in ls)
                {
                    try
                    {
                        if (mainquiz.STAFFS.Where(x => x.StaffID == itemst.StaffID).Count() == 0)
                        {
                            QuizMain.STAFFS_POSITIONS staff = new QuizMain.STAFFS_POSITIONS();
                            staff.PositionID = itemst.PositionID;
                            staff.StaffPositionID = itemst.StaffPositionID;
                            staff.StaffID = itemst.StaffID;
                            mainquiz.STAFFS_POSITIONS.Add(staff);
                            mainquiz.SaveChanges();
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.CONTEST> lsContest = new List<Quiz.CONTEST>();
            lsContest = quiz.CONTESTS.ToList();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsContest)
            {
                try
                {
                    QuizMain.CONTEST contest = new QuizMain.CONTEST();
                    if (mainquiz.CONTESTS.Where(x => x.ContestID == item.ContestID).Count() == 0)
                    {

                        contest.ContestID = item.ContestID;
                        contest.Status = item.Status;
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

                        mainquiz.CONTESTS.Add(contest);
                        mainquiz.SaveChanges();
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
        public int Location2() //1.3 bảng Location,  
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.LOCATION> lsLocation = new List<Quiz.LOCATION>();
            lsLocation = quiz.LOCATIONS.ToList();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsLocation)
            {
                try
                {
                    if (mainquiz.LOCATIONS.Where(x => x.LocationID == item.LocationID).Count() == 0)
                    {
                        QuizMain.LOCATION location = new QuizMain.LOCATION();
                        location.ContestID = item.ContestID;
                        location.Status = item.Status;
                        location.LocationName = item.LocationName;
                        location.LocationID = item.LocationID;
                        mainquiz.LOCATIONS.Add(location);
                        mainquiz.SaveChanges();
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.ROOMTEST> lsRoom = new List<Quiz.ROOMTEST>();
            lsRoom = quiz.ROOMTESTS.ToList();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsRoom)
            {
                try
                {
                    if (mainquiz.ROOMTESTS.Where(x => x.RoomTestID == item.RoomTestID).ToList().Count == 0)
                    {
                        QuizMain.ROOMTEST room = new QuizMain.ROOMTEST();
                        room.RoomTestID = item.RoomTestID;
                        room.RoomTestName = item.RoomTestName;
                        room.MaxSeatMount = item.MaxSeatMount;
                        room.MaxSupervisor = item.MaxSupervisor;
                        room.Status = item.Status;
                        room.LocationID = (Int32)item.LocationID;

                        mainquiz.ROOMTESTS.Add(room);
                        mainquiz.SaveChanges();
                    }
                    count++;
                    bw.ReportProgress(count / lsRoom.Count);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển ROOMTESTS: \n" + item.RoomTestID.ToString() + ": " + item.RoomTestName + ex.Message);
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
        public int Roomdiagram() //2.1. bang  ROOMDIAGRAM
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.ROOMDIAGRAM> lsttest = new List<Quiz.ROOMDIAGRAM>();
            lsttest = quiz.ROOMDIAGRAMS.ToList();
            int count = 0;
            foreach (Quiz.ROOMDIAGRAM itemtest in lsttest)
            {
                try
                {
                    if (mainquiz.ROOMDIAGRAMS.Where(x => x.RoomDiagramID == itemtest.RoomDiagramID).Count() == 0)
                    {
                        QuizMain.ROOMDIAGRAM bg = new QuizMain.ROOMDIAGRAM();
                        bg.RoomDiagramID = itemtest.RoomDiagramID;
                        bg.Description = itemtest.Description;
                        bg.ComputerName = itemtest.ComputerName;
                        bg.ComputerCode = itemtest.ComputerCode;
                        bg.ClientIP = itemtest.ClientIP;
                        bg.RoomTestID = itemtest.RoomTestID;
                        bg.Status = bg.Status;
                        mainquiz.ROOMDIAGRAMS.Add(bg);
                        mainquiz.SaveChanges();
                    }
                    count++;
                    bw.ReportProgress(count * 100 / lsttest.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chuyển phân công giám thị" + itemtest.RoomDiagramID.ToString() + " thất bại\n" + ex.ToString());
                }
            }
            return 1;
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.VIOLATION> lsViolation = new List<Quiz.VIOLATION>();
            lsViolation = quiz.VIOLATIONS.ToList();
            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsViolation)
            {
                try
                {
                    if (mainquiz.VIOLATIONS.Where(x => x.ViolationID == item.ViolationID).Count() == 0)
                    {
                        QuizMain.VIOLATION violation = new QuizMain.VIOLATION();
                        violation.ViolationID = item.ViolationID;
                        violation.ViolationName = item.ViolationName;
                        violation.Description = item.Description;
                        violation.Level = item.Level;
                        violation.Status = item.Status;

                        mainquiz.VIOLATIONS.Add(violation);
                        mainquiz.SaveChanges();
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.SCHEDULE> lsSchedule = new List<Quiz.SCHEDULE>();

            int count = 0;
            try
            {

                lsSchedule = quiz.SCHEDULES.ToList();
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
                    QuizMain.SCHEDULE schedule = new QuizMain.SCHEDULE();
                    QuizMain.SUBJECT subject = new QuizMain.SUBJECT();
                    if (mainquiz.SUBJECTS.Where(x => x.SubjectID == item.SUBJECT.SubjectID).Count() == 0)
                    {
                        subject.SubjectID = item.SUBJECT.SubjectID;
                        subject.SubjectName = item.SUBJECT.SubjectName;
                        subject.SubjectCode = item.SUBJECT.SubjectCode;
                        subject.Status = item.SUBJECT.Status;
                        mainquiz.SUBJECTS.Add(subject);
                        mainquiz.SaveChanges();
                    }
                    if (mainquiz.SCHEDULES.Where(x => x.ScheduleID == item.ScheduleID).Count() == 0)
                    {
                        schedule.ScheduleID = item.ScheduleID;
                        schedule.TimeOfTest = item.TimeOfTest;
                        schedule.TimeToSubmit = item.TimeToSubmit;
                        schedule.Status = item.Status;
                        schedule.ContestID = item.ContestID;
                        schedule.ContestTypeName = item.ContestTypeName;
                        schedule.SubjectID = item.SubjectID;
                        mainquiz.SCHEDULES.Add(schedule);
                        mainquiz.SaveChanges();
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.SHIFT> lsShift = new List<Quiz.SHIFT>();
            lsShift = quiz.SHIFTS.ToList();

            int count = 0;
            foreach (var item in lsShift)
            {
                try
                {
                    int kt = 0;
                    if (mainquiz.SHIFTS.Where(x => x.ShiftID == item.ShiftID).Count() == 0)
                    {
                        QuizMain.SHIFT shift = new QuizMain.SHIFT();
                        shift.ContestID = item.ContestID;
                        shift.ShiftName = item.ShiftName;
                        shift.ShiftID = item.ShiftID;
                        shift.ShiftDate = item.ShiftDate;
                        shift.StartTime = item.StartTime;
                        shift.EndTime = item.EndTime;
                        shift.Status = item.Status;
                        mainquiz.SHIFTS.Add(shift);
                        mainquiz.SaveChanges();
                        int count2 = 0;
                        foreach (var i in item.DIVISION_SHIFTS)
                        {
                            if (mainquiz.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == i.DivisionShiftID).Count() == 0)
                            {
                                QuizMain.DIVISION_SHIFTS divisionshift = new QuizMain.DIVISION_SHIFTS();
                                divisionshift.DivisionShiftID = i.DivisionShiftID;
                                divisionshift.Status = i.Status;
                                divisionshift.ShiftID = i.ShiftID;
                                //divisionshift.SupervisorID = i.SupervisorID;
                                divisionshift.RoomTestID = i.RoomTestID;
                                divisionshift.Key = i.Key;
                                try
                                {
                                    mainquiz.DIVISION_SHIFTS.Add(divisionshift);
                                    mainquiz.SaveChanges();

                                    //bw.ReportProgress(count * 100 / lsShift.Count);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Lỗi chuyển DIVISION_SHIFTS " + i.DivisionShiftID.ToString() + "\n" + ex.Message);
                                    continue;
                                }
                            }
                            count2++;

                        }
                        if (count2 == item.DIVISION_SHIFTS.Count)
                        {
                            count++;
                            bw.ReportProgress(count * 100 / lsShift.Count);
                        }
                        kt = 1;
                    }
                    if(kt==0)
                    {
                        count++;
                        bw.ReportProgress(count * 100 / lsShift.Count);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chuyển SHIFTS " + item.ShiftID.ToString() + ": " + item.ShiftName + "\n" + ex.Message);
                }

            }
            if (count == lsShift.Count)
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.CONTESTANT> lsContestant = new List<Quiz.CONTESTANT>();
            lsContestant = quiz.CONTESTANTS.ToList();

            int count = 0;
            bw.ReportProgress(0);
            foreach (var item in lsContestant)
            {
                try
                {
                    if (mainquiz.CONTESTANTS.Where(x => x.ContestantID == item.ContestantID).Count() == 0)
                    {
                        QuizMain.CONTESTANT contestant_quiz = new QuizMain.CONTESTANT();
                        contestant_quiz.ContestantCode = item.ContestantCode;
                        contestant_quiz.ContestantID = item.ContestantID;
                        contestant_quiz.CurrentAddress = item.CurrentAddress;
                        //contestant_quiz.ContestantType = item.REGISTER.CONTESTANT_TYPES.ContestantTypeName;
                        contestant_quiz.DOB = (Int32)item.DOB;
                        contestant_quiz.Ethnic = item.Ethnic;
                        contestant_quiz.FullName = item.FullName;
                        contestant_quiz.HighSchool = item.HighSchool;
                        contestant_quiz.IdentityCardNumber = item.IdentityCardNumber;
                        contestant_quiz.Image = item.Image;
                        contestant_quiz.PlaceOfBirth = item.PlaceOfBirth;
                        contestant_quiz.Sex = (Int32)item.Sex;
                        contestant_quiz.Status = item.Status;
                        contestant_quiz.StudentCode = item.StudentCode;
                        contestant_quiz.TrainingSystem = item.TrainingSystem.ToString();
                        contestant_quiz.Unit = item.Unit;
                        try
                        {
                            mainquiz.CONTESTANTS.Add(contestant_quiz);
                            mainquiz.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi chuyển CONTESTANTS " + item.ContestantID.ToString() + item.FullName + "\n" + ex.Message);

                        }
                    }
                    //int count1 = 0;
                    foreach (var i in item.FINGERPRINTS)
                    {
                        QuizMain.FINGERPRINT finger = new QuizMain.FINGERPRINT();
                        finger.FingerprintID = i.FingerprintID;
                        finger.FingerprintImage = i.FingerprintImage;
                        finger.FilePath = i.FilePath;
                        finger.TimeSaveFingerprint = i.TimeSaveFingerprint;
                        finger.Status = i.Status;
                        finger.ContestantID = i.ContestantID;
                        try
                        {
                            mainquiz.FINGERPRINTS.Add(finger);
                            mainquiz.SaveChanges();
                           // count1++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi chuyển FINGERPRINTS " + item.ContestantID.ToString() + item.FullName + "\n" + ex.Message);
                        }

                    }
                    //int count2 = 0;
                    foreach (var i in item.CONTESTANTS_SHIFTS)
                    {

                        QuizMain.CONTESTANTS_SHIFTS conshift = new QuizMain.CONTESTANTS_SHIFTS();
                        conshift.ContestantShiftID = i.ContestantShiftID;
                        conshift.DivisionShiftID = i.DivisionShiftID;
                        conshift.ScheduleID = i.ScheduleID;
                        conshift.Status = 4001;
                        conshift.ContestantID = i.ContestantID;
                        try
                        {
                            mainquiz.CONTESTANTS_SHIFTS.Add(conshift);
                            mainquiz.SaveChanges();
                            //count2++;
                        }
                        catch
                        { }
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.EXAMINATIONCOUNCIL_STAFFS> lsExamStaff = new List<Quiz.EXAMINATIONCOUNCIL_STAFFS>();
            lsExamStaff = quiz.EXAMINATIONCOUNCIL_STAFFS.ToList();
            List<Quiz.EXAMINATIONCOUNCIL_POSITIONS> lsExamPosition = new List<Quiz.EXAMINATIONCOUNCIL_POSITIONS>();
            lsExamPosition = quiz.EXAMINATIONCOUNCIL_POSITIONS.ToList();

            int count1 = 0;
            int count2 = 0;
            foreach (var i in lsExamPosition)
            {
                try
                {
                    if (mainquiz.EXAMINATIONCOUNCIL_POSITIONS.Where(x => x.ExaminationCouncil_PositionID == i.ExaminationCouncil_PositionID).Count() == 0)
                    {
                        QuizMain.EXAMINATIONCOUNCIL_POSITIONS examposition = new QuizMain.EXAMINATIONCOUNCIL_POSITIONS();
                        examposition.ExaminationCouncil_PositionID = i.ExaminationCouncil_PositionID;
                        examposition.ExaminationCouncil_PositionCode = i.ExaminationCouncil_PositionCode;
                        examposition.ExaminationCouncil_PositionName = i.ExaminationCouncil_PositionName;
                        examposition.Permission = i.Permission;
                        examposition.Status = i.Status;
                        mainquiz.EXAMINATIONCOUNCIL_POSITIONS.Add(examposition);
                        mainquiz.SaveChanges();
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
                        if (mainquiz.EXAMINATIONCOUNCIL_STAFFS.Where(x => x.ExaminationCouncil_StaffID == item.ExaminationCouncil_StaffID).Count() == 0)
                        {
                            QuizMain.EXAMINATIONCOUNCIL_STAFFS examstaff = new QuizMain.EXAMINATIONCOUNCIL_STAFFS();
                            examstaff.ExaminationCouncil_StaffID = item.ExaminationCouncil_StaffID;
                            examstaff.ContestID = item.ContestID;
                            examstaff.StaffID = item.StaffID;
                            examstaff.ExaminationCouncil_PositionID = item.ExaminationCouncil_PositionID;
                            examstaff.LocationID = item.LocationID;
                            examstaff.UserName = item.UserName;
                            examstaff.Password = item.Password;
                            examstaff.Status = item.Status;
                            mainquiz.EXAMINATIONCOUNCIL_STAFFS.Add(examstaff);
                            mainquiz.SaveChanges();
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
        public int BagOfTest() //8.1. bang BAGOFTEST,
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.BAGOFTEST> lstbg = new List<Quiz.BAGOFTEST>();
            lstbg = quiz.BAGOFTESTS.ToList();
            int count = 0;
            foreach (Quiz.BAGOFTEST itembg in lstbg)
            {
                try
                {
                    if (mainquiz.BAGOFTESTS.Where(x => x.BagOfTestID == itembg.BagOfTestID).Count() == 0)
                    {
                        QuizMain.BAGOFTEST bg = new QuizMain.BAGOFTEST();
                        bg.BagOfTestID = itembg.BagOfTestID;
                        bg.DivisionShiftID = itembg.DivisionShiftID;
                        bg.NumberOfTest = itembg.NumberOfTest;
                        bg.Status = itembg.Status;

                        mainquiz.BAGOFTESTS.Add(bg);
                        mainquiz.SaveChanges();
                        
                    }
                    count++;
                    bw.ReportProgress(count * 100 / lstbg.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chuyển túi đề thi " + itembg.BagOfTestID.ToString() + " thất bại\n" + ex.ToString());
                }
                

            }
            return 1;
        }
        public int Tests() //8.2. bang TEST
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.TEST> lsttest = new List<Quiz.TEST>();
            lsttest = quiz.TESTS.ToList();
            int count = 0;
            foreach (Quiz.TEST itemtest in lsttest)
            {
                try
                {
                    if (mainquiz.TESTS.Where(x => x.TestID == itemtest.TestID).Count() == 0)
                    {
                        QuizMain.TEST bg = new QuizMain.TEST();
                        bg.BagOfTestID = itemtest.BagOfTestID;
                        bg.TestID = itemtest.TestID;
                        bg.SubjectID = itemtest.SubjectID;
                        bg.Status = itemtest.Status;

                        mainquiz.TESTS.Add(bg);
                        mainquiz.SaveChanges();
                    }
                    count++;
                    bw.ReportProgress(count * 100 / lsttest.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chuyển đề thi " + itemtest.BagOfTestID.ToString() + " thất bại\n" + ex.ToString());
                }
            }
            return 1;
        }
        public int Questions() //8.3. bang  QUESTION
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.QUESTION> lsttest = new List<Quiz.QUESTION>();
            lsttest = quiz.QUESTIONS.ToList();
            int count = 0;
            foreach (Quiz.QUESTION itemtest in lsttest)
            {
                try
                {
                    if (mainquiz.QUESTIONS.Where(x => x.QuestionID == itemtest.QuestionID).Count() == 0)
                    {
                        QuizMain.QUESTION bg = new QuizMain.QUESTION();
                        bg.QuestionID = itemtest.QuestionID;
                        bg.QuestionContent = itemtest.QuestionContent;
                        bg.QuestionFormat = itemtest.QuestionFormat;
                        bg.Level = itemtest.Level;
                        bg.IsParagraph = itemtest.IsParagraph;
                        bg.IsQuestionContent = itemtest.IsQuestionContent;
                        bg.IsQuiz = itemtest.IsQuiz;
                        bg.IsSingleChoice = itemtest.IsSingleChoice;
                        bg.NumberAnswer = itemtest.NumberAnswer;
                        bg.NumberSubQuestion = itemtest.NumberSubQuestion;

                        mainquiz.QUESTIONS.Add(bg);
                        mainquiz.SaveChanges();
                        
                    }
                    count++;
                    bw.ReportProgress(count * 100 / lsttest.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chuyển câu hỏi " + itemtest.QuestionID.ToString() + " thất bại\n" + ex.ToString());
                }
                

            }
            return 1;
        }
        public int SubQuestions() //8.4. bang  SUBQUESTION
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.SUBQUESTION> lsttest = new List<Quiz.SUBQUESTION>();
            lsttest = quiz.SUBQUESTIONS.ToList();
            int count = 0;
            foreach (Quiz.SUBQUESTION itemtest in lsttest)
            {
                if (mainquiz.SUBQUESTIONS.Where(x => x.SubQuestionID == itemtest.SubQuestionID).Count() == 0)
                {
                    QuizMain.SUBQUESTION bg = new QuizMain.SUBQUESTION();
                    bg.QuestionID = itemtest.QuestionID;
                    bg.SubQuestionID = itemtest.SubQuestionID;
                    bg.SubQuestionContent = itemtest.SubQuestionContent;

                    try
                    {
                        mainquiz.SUBQUESTIONS.Add(bg);
                        mainquiz.SaveChanges();
                        count++;
                        bw.ReportProgress(count * 100 / lsttest.Count);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chuyển câu hỏi con " + itemtest.SubQuestionID.ToString() + " thất bại\n" + ex.ToString());
                    }
                }

            }
            return 1;
        }
        public int Answers() //8.4. bang  ANSWERS
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.ANSWER> lsttest = new List<Quiz.ANSWER>();
            lsttest = quiz.ANSWERS.ToList();
            int count = 0;
            foreach (Quiz.ANSWER itemtest in lsttest)
            {
                if (mainquiz.ANSWERS.Where(x => x.AnswerID == itemtest.AnswerID).Count() == 0)
                {
                    QuizMain.ANSWER bg = new QuizMain.ANSWER();
                    bg.AnswerID = itemtest.AnswerID;
                    bg.SubQuestionID = itemtest.SubQuestionID;
                    bg.AnswerContent = itemtest.AnswerContent;
                    bg.IsCorrect = itemtest.IsCorrect;
                    try
                    {
                        mainquiz.ANSWERS.Add(bg);
                        mainquiz.SaveChanges();
                        count++;
                        bw.ReportProgress(count * 100 / lsttest.Count);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chuyển câu trả lời " + itemtest.AnswerID.ToString() + " thất bại\n" + ex.ToString());
                    }
                }

            }
            return 1;
        }
        public int TestDetail() //8.5. bang  TESTDETAIL
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.TEST_DETAILS> lsttest = new List<Quiz.TEST_DETAILS>();
            lsttest = quiz.TEST_DETAILS.ToList();
            int count = 0;
            foreach (Quiz.TEST_DETAILS itemtest in lsttest)
            {
                if (mainquiz.TEST_DETAILS.Where(x => x.TestDetailID == itemtest.TestDetailID).Count() == 0)
                {
                    QuizMain.TEST_DETAILS bg = new QuizMain.TEST_DETAILS();
                    bg.TestDetailID = itemtest.TestDetailID;
                    bg.RandomAnswer = itemtest.RandomAnswer;
                    bg.NumberIndex = itemtest.NumberIndex;
                    bg.Score = itemtest.Score;
                    bg.Status = itemtest.Status;
                    bg.TestID = itemtest.TestID;
                    bg.QuestionID = itemtest.QuestionID;

                    try
                    {
                        mainquiz.TEST_DETAILS.Add(bg);
                        mainquiz.SaveChanges();
                        count++;
                        bw.ReportProgress(count * 100 / lsttest.Count);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chuyển chi tiết câu hỏi " + itemtest.TestDetailID.ToString() + " thất bại\n" + ex.ToString());
                    }
                }

            }
            return 1;
        }
        public int Violation_contestant() //9. bang  VIOLATION_CONTESTANT
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.VIOLATIONS_CONTESTANTS> lsttest = new List<Quiz.VIOLATIONS_CONTESTANTS>();
            lsttest = quiz.VIOLATIONS_CONTESTANTS.ToList();
            int count = 0;
            foreach (Quiz.VIOLATIONS_CONTESTANTS itemtest in lsttest)
            {
                if (mainquiz.VIOLATIONS_CONTESTANTS.Where(x => x.ViolationDetailID == itemtest.ViolationDetailID).Count() == 0)
                {
                    QuizMain.VIOLATIONS_CONTESTANTS bg = new QuizMain.VIOLATIONS_CONTESTANTS();
                    bg.ViolationDetailID = itemtest.ViolationDetailID;
                    bg.TimeSave = itemtest.TimeSave;
                    bg.ViolationID = itemtest.ViolationID;
                    bg.ContestantShiftID = itemtest.ContestantShiftID;
                    bg.Status = itemtest.Status;
                    try
                    {
                        mainquiz.VIOLATIONS_CONTESTANTS.Add(bg);
                        mainquiz.SaveChanges();
                        count++;
                        bw.ReportProgress(count * 100 / lsttest.Count);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chuyển vi phạm thí sinh " + itemtest.ViolationDetailID.ToString() + " thất bại\n" + ex.ToString());
                    }
                }

            }
            return 1;
        }
        public int ContestantTest() //10. bang  CONTESTANTS_TESTS
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.CONTESTANTS_TESTS> lsttest = new List<Quiz.CONTESTANTS_TESTS>();
            lsttest = quiz.CONTESTANTS_TESTS.ToList();
            int count = 0;
            foreach (Quiz.CONTESTANTS_TESTS itemtest in lsttest)
            {
                if (mainquiz.CONTESTANTS_TESTS.Where(x => x.ContestantTestID == itemtest.ContestantTestID).Count() == 0)
                {
                    QuizMain.CONTESTANTS_TESTS bg = new QuizMain.CONTESTANTS_TESTS();
                    bg.ContestantTestID = itemtest.ContestantTestID;
                    bg.ContestantShiftID = itemtest.ContestantShiftID;
                    bg.TestID = itemtest.TestID;
                    bg.Status = itemtest.Status;
                    try
                    {
                        mainquiz.CONTESTANTS_TESTS.Add(bg);
                        mainquiz.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chuyển đề thí sinh " + itemtest.ContestantTestID.ToString() + " thất bại\n" + ex.ToString());
                    }
                }
                count++;
                bw.ReportProgress(count * 100 / lsttest.Count);

            }
            return 1;
        }
        public int AnswerSheet() //11. bang  ANSWERSHEET
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.ANSWERSHEET> lsttest = new List<Quiz.ANSWERSHEET>();
            lsttest = quiz.ANSWERSHEETS.ToList();
            int count = 0;
            foreach (Quiz.ANSWERSHEET itemtest in lsttest)
            {
                if (mainquiz.ANSWERSHEETS.Where(x => x.AnswerSheetID == itemtest.AnswerSheetID).Count() == 0)
                {
                    QuizMain.ANSWERSHEET bg = new QuizMain.ANSWERSHEET();
                    bg.ContestantTestID = itemtest.ContestantTestID;
                    bg.AnswerSheetID = itemtest.AnswerSheetID;
                    bg.TestScores = itemtest.TestScores;
                    bg.EssayPoints = itemtest.EssayPoints;
                    bg.StaffID = itemtest.StaffID;
                    bg.Status = itemtest.Status;
                    try
                    {
                        mainquiz.ANSWERSHEETS.Add(bg);
                        mainquiz.SaveChanges();
                        count++;
                        bw.ReportProgress(count * 100 / lsttest.Count);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chuyển bài làm thí sinh" + itemtest.AnswerSheetID.ToString() + " thất bại\n" + ex.ToString());
                    }
                }

            }
            return 1;
        }
        public int AnswerSheetDetail() //11. bang  ANSWERSHEETDEtail
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.ANSWERSHEET_DETAILS> lsttest = new List<Quiz.ANSWERSHEET_DETAILS>();
            lsttest = quiz.ANSWERSHEET_DETAILS.ToList();
            int count = 0;
            foreach (Quiz.ANSWERSHEET_DETAILS itemtest in lsttest)
            {
                if (mainquiz.ANSWERSHEET_DETAILS.Where(x => x.AnswerSheetDetailID == itemtest.AnswerSheetDetailID).Count() == 0)
                {
                    QuizMain.ANSWERSHEET_DETAILS bg = new QuizMain.ANSWERSHEET_DETAILS();
                    bg.AnswerSheetDetailID = itemtest.AnswerSheetDetailID;
                    bg.AnswerSheetID = itemtest.AnswerSheetID;
                    bg.ChoosenAnswer = itemtest.ChoosenAnswer;
                    bg.AnswerContent = itemtest.AnswerContent;
                    bg.LastTime = itemtest.LastTime;
                    bg.SubQuestionID = itemtest.SubQuestionID;
                    bg.Status = itemtest.Status;
                    try
                    {
                        mainquiz.ANSWERSHEET_DETAILS.Add(bg);
                        mainquiz.SaveChanges();
                        count++;
                        bw.ReportProgress(count * 100 / lsttest.Count);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chuyển chi tiết bài làm thí sinh" + itemtest.AnswerSheetDetailID.ToString() + " thất bại\n" + ex.ToString());
                    }
                }

            }
            return 1;
        }
        public int divisionshift_supervisor() //12. bang  DIVISIONSHIFT_SUPERVISOR
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
            mainquiz = new QuizMain.QuizMain();
            quiz = new Quiz.Quiz();
            List<Quiz.DIVISIONSHIFT_SUPERVISOR> lsttest = new List<Quiz.DIVISIONSHIFT_SUPERVISOR>();
            lsttest = quiz.DIVISIONSHIFT_SUPERVISOR.ToList();
            int count = 0;
            foreach (Quiz.DIVISIONSHIFT_SUPERVISOR itemtest in lsttest)
            {
                if (mainquiz.DIVISIONSHIFT_SUPERVISOR.Where(x => x.DivisionShift_SupervisorID == itemtest.DivisionShift_SupervisorID).Count() == 0)
                {
                    QuizMain.DIVISIONSHIFT_SUPERVISOR bg = new QuizMain.DIVISIONSHIFT_SUPERVISOR();
                    bg.DivisionShift_SupervisorID = itemtest.DivisionShift_SupervisorID;
                    bg.SupervisorID = itemtest.SupervisorID;
                    bg.DivisionShiftID = itemtest.DivisionShiftID;

                    try
                    {
                        mainquiz.DIVISIONSHIFT_SUPERVISOR.Add(bg);
                        mainquiz.SaveChanges();
                        count++;
                        bw.ReportProgress(count * 100 / lsttest.Count);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chuyển phân công giám thị" + itemtest.DivisionShift_SupervisorID.ToString() + " thất bại\n" + ex.ToString());
                    }
                }

            }
            return 1;
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
