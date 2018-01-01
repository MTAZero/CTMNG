using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO.DataProvider;
using EXONSYSTEM.Common;
using System.Diagnostics;
using EXONSYSTEM.Layout;
using System.Threading;
using System.Net;
using MetroFramework;
using MetroFramework.Controls;
using System.Configuration;
using MetroFramework.Drawing.Html;

namespace EXONSYSTEM
{
    public partial class frmMainForm : Form
    {
        #region Declare variables
        private ContestantInformation CILogged;
        private Contest CLogged;
        private ConfigApplication CARead;
        private List<List<Questions>> lstLQuestion;
        private static List<ObjControl> lstObjControl;
        private static List<string> lstbtnQuestions;
        private static List<Control> lstControlQuestions;
        private static List<Control> lstControlBtnQuestions;
        SendWorking s;
        private int StatusLogged;
        public delegate void SendQuestion(Questions q, int AnswerSheetID);
        public delegate void SendUCRowInfor(string strTitle, string strContent);
        public delegate void SendWorking(bool isProgress);

        private int PreSubQuestionID = Constant.STATUS_NORMAL; // Câu hõi đã được chọn trước.
        private bool IsContinute = false; // True: Nếu thí sinh gặp sự cố và thi tiếp || False: Thí sinh thi mới
        private int IsLoadingTest = Constant.STATUS_NORMAL; // True: Bắt đầu tải đề thi || False: Ngược lại
        private int WarningCount = 0; // Số lần bị cảnh cáo
        private UserHelper.UserTransformation UT;
        private int currentStatusContestant; // Trạng thái cuối của thí sinh trong lần đăng nhập cuối
        UserHelper.ClientSide ClientSocket;
        private Answersheet rASH;

        private int maxTime;

        #endregion
        public frmMainForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            lstControlQuestions = new List<Control>();
            lstControlBtnQuestions = new List<Control>();
            flpnListOfButtonQuestions.Width = Constant.WIDTH_PANEL_INFORMATION;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
        /// <summary>
        /// Xử lý dữ liệu từ form Authen
        /// </summary>
        public void HandleInformationFromAuthenForm(ContestantInformation CI, Contest C, UserHelper.ClientSide clientSocket, ConfigApplication ca)
        {

            CILogged = CI;
          
            CLogged = C;
            CARead = ca;
            maxTime = CLogged.TimeOfTest;
            WarningCount = CILogged.Warning;
            currentStatusContestant = CILogged.Status;

            // Khởi tạo socket
            UT = new UserHelper.UserTransformation();
            UT.ComputerName = Dns.GetHostName();
            UT.UserCode = CILogged.ContestantCode;
            UT.UserID = CILogged.ContestantID;
            this.ClientSocket = clientSocket;
            ClientSocket.Status = true;
            ClientSocket.Remote.NoConnected += Remote_NoConnected;
            ClientSocket.Remote.Receive += Remote_Receive;

            // Render giao diện
            HandlePanelWelcome();
            HandlePanelInformation();
            HandlePanelListOfQuestions();
            HandleVisibleWelcome(true);
        }
        #region Handle Style panels

        #region Panel Welcome
        /// <summary>
        /// Xử lý giao diện Welcome
        /// </summary>
        private void HandlePanelWelcome()
        {
            MetroPanel mpnWelcome = new MetroPanel();
            mpnWelcome.Name = "mpnWelcome";
            Controllers.Instance.SetCanChangeMetroPanelColor(mpnWelcome);
            mpnWelcome.Location = new Point(0, 0);
            mpnWelcome.Width = Constant.WIDTH_SCREEN;
            mpnWelcome.Height = Constant.HEIGHT_SCREEN;
            mpnWelcome.BackColor = Constant.BACKCOLOR_PANEL_WELCOME;
            mpnWelcome.BringToFront();
            this.Controls.Add(mpnWelcome);

            MetroPanel mpnWelcomeWraper = new MetroPanel();
            Controllers.Instance.SetCanChangeMetroPanelColor(mpnWelcomeWraper);
            mpnWelcomeWraper.BackColor = Constant.COLOR_TRANSPARENT;
            mpnWelcome.Controls.Add(mpnWelcomeWraper);
            mpnWelcomeWraper.AutoSize = true;

            MetroPanel mpnWelcomeContent = new MetroPanel();
            Controllers.Instance.SetCanChangeMetroPanelColor(mpnWelcomeContent);
            mpnWelcomeContent.BackColor = Constant.COLOR_TRANSPARENT;
            mpnWelcomeWraper.Controls.Add(mpnWelcomeContent);
            mpnWelcomeContent.AutoSize = true;

            //Tên kỳ thi
            Label lbContestName = new Label();
            lbContestName.AutoSize = true;
            lbContestName.Text = CLogged.ContestName.ToUpper();
            lbContestName.Font = new Font(Constant.FONT_FAMILY_DEFAULT, 30, FontStyle.Bold);
            lbContestName.BackColor = Constant.COLOR_TRANSPARENT;
            lbContestName.ForeColor = Constant.FORCECOLOR_LABEL_CONTEST_NAME;
            mpnWelcomeWraper.Controls.Add(lbContestName);
            mpnWelcomeWraper.Width = lbContestName.Width;

            // Ngày diễn ra kỳ thi
            ucRowInfor ucContestDate = new ucRowInfor();
            SendUCRowInfor sucContestDate = new SendUCRowInfor(ucContestDate.HandleUC);
            sucContestDate(Properties.Resources.MSG_GUI_0007, Controllers.Instance.ConvertUnixToDateTime(CLogged.ShiftDate).ToString(Constant.FORMAT_DATE_DEFAULT));
            mpnWelcomeContent.Controls.Add(ucContestDate);

            // Ca thi
            ucRowInfor ucContestShift = new ucRowInfor();
            SendUCRowInfor sucContestShift = new SendUCRowInfor(ucContestShift.HandleUC);
            sucContestShift(Properties.Resources.MSG_GUI_0049, string.Format("{0} - {1}", Controllers.Instance.ConvertUnixToDateTime(CLogged.StartTime).ToString(Constant.FORMAT_TIME_DEFAULT), Controllers.Instance.ConvertUnixToDateTime(CLogged.EndTime).ToString(Constant.FORMAT_TIME_DEFAULT)));
            ucContestShift.Location = new Point(0, ucContestDate.Bottom);
            mpnWelcomeContent.Controls.Add(ucContestShift);

            // Tên môn thi
            ucRowInfor ucContestSubject = new ucRowInfor();
            SendUCRowInfor sucContestSubject = new SendUCRowInfor(ucContestSubject.HandleUC);
            sucContestSubject(Properties.Resources.MSG_GUI_0008, CLogged.Subject);
            mpnWelcomeContent.Controls.Add(ucContestSubject);
            ucContestSubject.Location = new Point(0, ucContestShift.Bottom);


            // Thời gian thi
            ucRowInfor ucDuration = new ucRowInfor();
            SendUCRowInfor sucDuration = new SendUCRowInfor(ucDuration.HandleUC);
            sucDuration(Properties.Resources.MSG_GUI_0014, string.Format(Properties.Resources.MSG_GUI_0048, Controllers.Instance.HandleDuration(CLogged.TimeOfTest - 300)));
            mpnWelcomeContent.Controls.Add(ucDuration);
            ucDuration.Location = new Point(0, ucContestSubject.Bottom);

            // Tên phòng thi
            ucRowInfor ucContestRoom = new ucRowInfor();
            SendUCRowInfor sucContestRoom = new SendUCRowInfor(ucContestRoom.HandleUC);
            sucContestRoom(Properties.Resources.MSG_GUI_0036, CLogged.RoomName);
            ucContestRoom.Location = new Point(0, ucDuration.Bottom);
            mpnWelcomeContent.Controls.Add(ucContestRoom);

            // Tên máy thi
            ucRowInfor ucContestComputer = new ucRowInfor();
            SendUCRowInfor sucContestComputer = new SendUCRowInfor(ucContestComputer.HandleUC);
            sucContestComputer(Properties.Resources.MSG_GUI_0037, Dns.GetHostName());
            ucContestComputer.Location = new Point(0, ucContestRoom.Bottom);
            mpnWelcomeContent.Controls.Add(ucContestComputer);

            // Họ tên thí sinh
            ucRowInfor ucContestantName = new ucRowInfor();
            SendUCRowInfor sucContestantName = new SendUCRowInfor(ucContestantName.HandleUC);
            sucContestantName(Properties.Resources.MSG_GUI_0001, Controllers.Instance.CapitalizeString(CILogged.Fullname));
            mpnWelcomeContent.Controls.Add(ucContestantName);
            ucContestantName.Location = new Point(0, ucContestComputer.Bottom + 20);

            // Ngày sinh
            ucRowInfor ucContestantGender = new ucRowInfor();
            SendUCRowInfor sucContestantGender = new SendUCRowInfor(ucContestantGender.HandleUC);
            sucContestantGender(Properties.Resources.MSG_GUI_0032, Controllers.Instance.GetSex(CILogged.SEX));
            mpnWelcomeContent.Controls.Add(ucContestantGender);
            ucContestantGender.Location = new Point(0, ucContestantName.Bottom);

            // Ngày sinh
            ucRowInfor ucDOB = new ucRowInfor();
            SendUCRowInfor sucDOB = new SendUCRowInfor(ucDOB.HandleUC);
            sucDOB(Properties.Resources.MSG_GUI_0002, Controllers.Instance.ConvertUnixToDateTime(CILogged.DOB).ToString(Constant.FORMAT_DATE_DEFAULT));
            mpnWelcomeContent.Controls.Add(ucDOB);
            ucDOB.Location = new Point(0, ucContestantGender.Bottom);

            // Số CMND
            ucRowInfor ucStudentIdentify = new ucRowInfor();
            SendUCRowInfor sucStudentIdentify = new SendUCRowInfor(ucStudentIdentify.HandleUC);
            sucStudentIdentify(Properties.Resources.MSG_GUI_0003, CILogged.IdentityCardName);
            mpnWelcomeContent.Controls.Add(ucStudentIdentify);
            ucStudentIdentify.Location = new Point(0, ucDOB.Bottom);

            //Button confirm
            MetroButton mbtnConfirm = new MetroButton();
            Controllers.Instance.SetCanChangeMetroButtonColor(mbtnConfirm);
            mbtnConfirm.Text = Properties.Resources.MSG_GUI_0015;
            mbtnConfirm.BackColor = Constant.COLOR_WHITE;
            mbtnConfirm.ForeColor = Constant.FORCECOLOR_BUTTON_CONFIRM;
            mbtnConfirm.Size = new Size(300, 40);
            mbtnConfirm.Click += new System.EventHandler(this.mbtnConfirm_Click);
            mpnWelcomeContent.Controls.Add(mbtnConfirm);
            mbtnConfirm.Location = new Point(0, ucStudentIdentify.Bottom + 30);

            int widthWrapper = mpnWelcomeWraper.Width > mpnWelcomeContent.Width ? mpnWelcomeWraper.Width : mpnWelcomeContent.Width;
            lbContestName.Location = new Point(Convert.ToInt32((widthWrapper - lbContestName.Width) / 2));
            if (lbContestName.Width < mpnWelcomeContent.Width)
            {
                mpnWelcomeContent.Location = new Point(0, lbContestName.Bottom + 50);
            }
            else
            {
                mpnWelcomeContent.Location = new Point(Convert.ToInt32((widthWrapper - mpnWelcomeContent.Width) / 2), lbContestName.Bottom + 50);
            }
            mpnWelcomeWraper.Location = new Point(Convert.ToInt32((Constant.WIDTH_SCREEN - widthWrapper) / 2), Convert.ToInt32((Constant.HEIGHT_SCREEN - mpnWelcomeWraper.Height) / 2));
        }
        private void mbtnConfirm_Click(object sender, EventArgs e)
        {
            // Nếu là thí sinh đăng nhập lần đầu sẽ phải đợi hiệu lệnh của giám thị mới được thi
            // Nếu là thí sinh đang thi nhưng đang gặp sự cố sẽ được vào làm bài luôn.
            if (CILogged.Status == Constant.STATUS_LOGGED)
            {
                // Gửi tin nhắn thông báo rằng sẵn sàng nhận đề bài
                UT.Status = Constant.STATUS_READY_TO_GET_TEST;
                UT.Content = "READY TO GET TEST";
                //TODO
                ErrorController rEC = new ErrorController();
                CILogged.Status = Constant.STATUS_READY_TO_GET_TEST;
                ContestantBUS.Instance.ChangeStatusContestant(CILogged, CLogged, out rEC);
                if (rEC.ErrorCode == Constant.STATUS_OK)
                {
                    Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | CHANGE_STATUS_CONTESTANT_RADIO_PERFORMCLICK | STATUS_READY | ChangeStatusContestant", Controllers.Instance.HandleStringErrorController(rEC));
                    UT.Status = Constant.STATUS_READY_TO_GET_TEST;
                    UT.Content = "READY TO GET TEST";
                    ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
   
                }

                ///
              //  ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));

                HandleVisibleWelcome(false);
                HandleContentPanelLoading();
                this.Update();
            }
            else if (CILogged.Status == Constant.STATUS_LOGGED_DO_NOT_FINISH)
            {
                HandleVisibleWelcome(false);
                this.Update();
                GernerateObjControl();
            }


            else if (CILogged.Status == Constant.STATUS_READY)
            {
                // Gửi tin nhắn thông báo rằng sẵn sàng để thi
                UT.Status = Constant.STATUS_READY;
                UT.Content = "READY TO TEST";
                //TODO
                ErrorController rEC = new ErrorController();
                CILogged.Status = Constant.STATUS_READY;
                ContestantBUS.Instance.ChangeStatusContestant(CILogged, CLogged, out rEC);
                if (rEC.ErrorCode == Constant.STATUS_OK)
                {
                    Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | CHANGE_STATUS_CONTESTANT_RADIO_PERFORMCLICK | STATUS_READY | ChangeStatusContestant", Controllers.Instance.HandleStringErrorController(rEC));
                    UT.Status = Constant.STATUS_READY;
                    UT.Content = "READY TO TEST";
                    bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                    if (!uhRes)
                    {
                        ClosingSocket();
                    }

                }
            //    ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));

                HandleVisibleWelcome(false);
                HandleContentPanelLoading();

                this.Update();
            }
        }
        private MetroPanel GetMpnWelcome()
        {
            return (MetroPanel)this.Controls["mpnWelcome"];
        }
        private void HandleVisibleWelcome(bool flag)
        {
            GetMpnWelcome().Visible = flag;
            flpnListOfQuestions.Visible = pnInformation.Visible = GetPanelLoading().Visible = !flag;
        }
        private void HandleGetTestInformation()
        {
            //Debug.WriteLine(DateTime.Now + "Start");
            ErrorController rEC = new ErrorController();
            this.Cursor = Cursors.WaitCursor;
            if ( currentStatusContestant  == Constant.STATUS_LOGGED)
            {
                // Lấy TestID + ContestantTestID
                ContestantBUS.Instance.GetContestantTestInformation(CILogged, out CILogged, out rEC);
                if (rEC.ErrorCode == Constant.STATUS_OK)
                {
                    // Thêm mới 1 bài thi (AnswerSheet)
                    rASH = new Answersheet();
                    rASH.ContestantTestID = CILogged.ContestantTestID;
                    AnswersheetBUS.Instance.PushAnswerSheet(rASH, out rEC);
                    if (rEC.ErrorCode == Constant.STATUS_OK)
                    {
                        Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | PUSHANSWERSHEET | STATUS_LOGGED | HandleGetTestInformation | PushAnswerSheet", Controllers.Instance.HandleStringErrorController(rEC));
                        // Lấy mã bài thi (AnswerSheet)
                        AnswersheetBUS.Instance.GetAnswerSheetByContestantID(CILogged, out rASH, out rEC);
                        if (rEC.ErrorCode == Constant.STATUS_OK)
                        {
                            Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | GETANSWERSHEETBYCONTESTANT | STATUS_LOGGED | HandleGetTestInformation | GetAnswerSheetByContestantID", Controllers.Instance.HandleStringErrorController(rEC));
                            CILogged.AnswerSheetID = rASH.AnswerSheetID;
                            // Lấy danh sách câu hỏi
                            int NumberQuestionsOfTest = 0;
                            TestBUS.Instance.GetListLQuestionByContestantInformation(CILogged, out lstLQuestion, out IsContinute, out NumberQuestionsOfTest, out rEC);
                            if (rEC.ErrorCode == Constant.STATUS_OK)
                            {
                                CLogged.NumberQuestionOfTest = NumberQuestionsOfTest;
                                Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | GETLISTLQUESTIONBYCONTESTANT | STATUS_LOGGED | HandleGetTestInformation | GetListLQuestionByContestantInformation", Controllers.Instance.HandleStringErrorController(rEC));
                            }
                            else
                            {
                                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Controllers.Instance.HandleStringErrorController(rEC));
                                Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                                Controllers.Instance.ExitApplicationFromNotificationForm(this);
                            }
                        }
                        else
                        {
                            Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Controllers.Instance.HandleStringErrorController(rEC));
                            Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                            Controllers.Instance.ExitApplicationFromNotificationForm(this);
                        }
                    }
                    else
                    {
                        Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Controllers.Instance.HandleStringErrorController(rEC));
                        Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                        Controllers.Instance.ExitApplicationFromNotificationForm(this);
                    }
                }
            }
            else if (currentStatusContestant == Constant.STATUS_LOGGED_DO_NOT_FINISH)
            {
                rASH = new Answersheet();
                // Lấy mã bài thi (AnswerSheet)
                AnswersheetBUS.Instance.GetAnswerSheetByContestantID(CILogged, out rASH, out rEC);
                if (rEC.ErrorCode == Constant.STATUS_OK)
                {
                    Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | GETANSWERSHEETBYCONTESTANT | STATUS_LOGGED_DO_NOT_FINISH | HandleGetTestInformation | GetAnswerSheetByContestantID", Controllers.Instance.HandleStringErrorController(rEC));
                    CILogged.AnswerSheetID = rASH.AnswerSheetID;
                    // Lấy danh sách câu hỏi
                    int NumberQuestionsOfTest = 0;
                    TestBUS.Instance.GetListLQuestionByContestantInformation(CILogged, out lstLQuestion, out IsContinute, out NumberQuestionsOfTest, out rEC);
                    if (rEC.ErrorCode == Constant.STATUS_OK)
                    {
                        CLogged.NumberQuestionOfTest = NumberQuestionsOfTest;
                        Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | GETLISTLQUESTIONBYCONTESTANT | STATUS_LOGGED_DO_NOT_FINISH | HandleGetTestInformation | GetAnswerSheetByContestantID", Controllers.Instance.HandleStringErrorController(rEC));
                    }
                    else
                    {
                        Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Controllers.Instance.HandleStringErrorController(rEC));
                        Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                        Controllers.Instance.ExitApplicationFromNotificationForm(this);
                    }
                }
                else
                {
                    Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Controllers.Instance.HandleStringErrorController(rEC));
                    Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                    Controllers.Instance.ExitApplicationFromNotificationForm(this);
                }
            }
            this.Cursor = Cursors.Arrow;
        }
        #endregion

        #region Information panel

        /// <summary>
        /// Giao diện thông tin kỳ thi
        /// </summary>
        private void HandlePanelInformation()
        {
            #region Panel Information
            pnInformation.Dock = DockStyle.Left;
            pnInformation.Location = new Point(0, 0);
            pnInformation.BackColor = Constant.BACKCOLOR_PANEL_INFORMATION;
            pnInformation.Width = Constant.WIDTH_PANEL_INFORMATION;
            pnInformation.Height = Constant.HEIGHT_SCREEN;

            Panel pnContestInformation = new Panel();
            pnContestInformation.Width = Constant.WIDTH_PANEL_INFORMATION;
            pnContestInformation.Location = new Point(0, 0);
            pnContestInformation.Name = "pnContestInformation";

            // Tên kỳ thi
            Label lbContestName = new Label();
            lbContestName.AutoSize = true;
            lbContestName.Text = CLogged.ContestName.ToUpper();
            lbContestName.Font = new Font(Constant.FONT_FAMILY_DEFAULT, 16, FontStyle.Bold);
            lbContestName.BackColor = Constant.COLOR_TRANSPARENT;
            lbContestName.ForeColor = Constant.BACKCOLOR_PANEL_WRAPPER_CONTENT;
            pnContestInformation.Controls.Add(lbContestName);
            lbContestName.Location = new Point(Convert.ToInt32((Constant.WIDTH_PANEL_INFORMATION - lbContestName.Width) / 2), 10);

            // Môn thi
            Label lbContestSubject = new Label();
            lbContestSubject.AutoSize = true;
            lbContestSubject.Text = CLogged.Subject;
            lbContestSubject.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Bold);
            lbContestSubject.BackColor = Constant.COLOR_TRANSPARENT;
            lbContestSubject.ForeColor = Constant.BACKCOLOR_PANEL_WRAPPER_CONTENT;
            pnContestInformation.Controls.Add(lbContestSubject);
            lbContestSubject.Location = new Point(Convert.ToInt32((Constant.WIDTH_PANEL_INFORMATION - lbContestSubject.Width) / 2), lbContestName.Bottom + 10);

            pnContestInformation.Height = lbContestSubject.Bottom + 20;
            pnInformation.Controls.Add(pnContestInformation);

            #region Timer
            // giao diện thời gian thi
            Panel pnTimerMask = new Panel();
            pnTimerMask.Name = "pnTimerMask";
            pnInformation.Controls.Add(pnTimerMask);
            lbTimer.Font = new Font(Constant.FONT_FAMILY_DEFAULT, 50, FontStyle.Bold);
            lbTimer.ForeColor = Constant.BACKCOLOR_PANEL_INFORMATION;
            lbTimer.TextAlign = ContentAlignment.MiddleCenter;
            lbTimer.AutoSize = true;
            lbTimer.Text = Controllers.Instance.HandleCountDown(CLogged.TimeOfTest);

            pnTimerMask.Size = lbTimer.Size;
            pnTimerMask.BringToFront();
            pnTimerMask.BackColor = Constant.BACKCOLOR_PANEL_INFORMATION;
            lbTimer.Location = new Point(Convert.ToInt32((Constant.WIDTH_PANEL_INFORMATION - lbTimer.Width) / 2), pnContestInformation.Bottom);
            pnTimerMask.Location = lbTimer.Location;
            timeCountDown.Start();
            #endregion

            HandleStylePanelController();
            #endregion
        }
        private void HandleTimer()
        {
            Panel pnTimerMask = (Panel)pnInformation.Controls["pnTimerMask"];
            this.maxTime = currentStatusContestant == Constant.STATUS_LOGGED_DO_NOT_FINISH ? CILogged.TimeRemained : CLogged.TimeOfTest;
            pnTimerMask.Visible = false;
            lbTimer.ForeColor = Constant.FORCECOLOR_LABEL_TIMER;
            lbTimer.Text = Controllers.Instance.HandleCountDown(maxTime);
        }
        private void timeCountDown_Tick(object sender, EventArgs e)
        {
            maxTime--;
            lbTimer.Text = Controllers.Instance.HandleCountDown(maxTime);

            // Hiển thị nút nộp bài
            if (CLogged.TimeToSubmit - 1 == maxTime && CILogged.Status == Constant.STATUS_DOING)
            {
                HandleGenerateButtonSubmit();
            }

            // Nộp bài thi
            if (maxTime == 0 && CILogged.Status == Constant.STATUS_DOING)
            {
                timeCountDown.Stop();
                UT.Status = Constant.STATUS_FINISHED;
                UT.Content = "TIME OUT";
                ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                HandleSubmitTest();
                Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | FINISHED | HandleSubmitTest", Properties.Resources.MSG_MESS_0028);
            }

            if (IsLoadingTest == Constant.WAITING_BY_ADMIN_TO_LOAD_TEST)
            {
                IsLoadingTest = Constant.STATUS_NORMAL;
                GernerateObjControl();
            }
            else if (IsLoadingTest == Constant.LOAD_TEST_WITH_CONTESTANT_INTERRUPT)
            {
                IsLoadingTest = Constant.STATUS_NORMAL;
                if (CLogged.TimeToSubmit > CILogged.TimeRemained)
                {
                    HandleGenerateButtonSubmit();
                }
                HandleStartDoingTest();
            }

        }
        /// <summary>
        /// Giao diện nút báo lỗi + nộp bài
        /// </summary>
        private void HandleStylePanelController()
        {
            Label lbTimer = (Label)pnInformation.Controls["lbTimer"];

            MetroPanel mpnController = new MetroPanel();
            Controllers.Instance.SetCanChangeMetroPanelColor(mpnController);
            mpnController.Name = "mpnController";
            mpnController.AutoSize = true;
            mpnController.AutoScroll = false;

            MetroButton mbtnReportError = new MetroButton();
            Controllers.Instance.SetCanChangeMetroButtonColor(mbtnReportError);
            mbtnReportError.Name = "mbtnReportError";
            mbtnReportError.ForeColor = Constant.FORCECOLOR_BUTTON_REPORTERROR;
            mbtnReportError.BackColor = Constant.BACKCOLOR_BUTTON_CONTROLLER;
            mbtnReportError.Text = Properties.Resources.MSG_GUI_0009;
            mbtnReportError.Size = Constant.SIZE_BUTTON_DEFAULT;
            mbtnReportError.Click += new System.EventHandler(this.mbtnReportError_Click);
            mpnController.Controls.Add(mbtnReportError);
            mpnController.Height = mbtnReportError.Height + 20;
            mpnController.Width = mbtnReportError.Width;
            mbtnReportError.Location = new Point(0, Convert.ToInt32((mpnController.Height - mbtnReportError.Height) / 2));

            mpnController.Location = new Point(Convert.ToInt32((Constant.WIDTH_PANEL_INFORMATION - mpnController.Width) / 2), lbTimer.Bottom);
            pnInformation.Controls.Add(mpnController);

            MetroPanel mpnInformationWrapper = new MetroPanel();
            mpnInformationWrapper.Name = "mpnInformationWrapper";
            Controllers.Instance.SetCanChangeMetroPanelColor(mpnInformationWrapper);
            mpnInformationWrapper.Location = new Point(0, mpnController.Bounds.Bottom + 30);
            mpnInformationWrapper.BackColor = Constant.BACKCOLOR_PANEL_INFORMATION;
            pnInformation.Controls.Add(mpnInformationWrapper);

            flpnListOfButtonQuestions.Location = new Point(0, mpnController.Bounds.Bottom + 30);
            flpnListOfButtonQuestions.Height = Constant.HEIGHT_SCREEN - flpnListOfButtonQuestions.Top - 100;
            mpnInformationWrapper.Size = new Size(Constant.WIDTH_PANEL_INFORMATION, flpnListOfButtonQuestions.Bottom + 20);
            flpnListOfButtonQuestions.SendToBack();
            HandleStyleWarningCount();
            HandleStyleInformationOfContest();
        }

        private void HandleStyleWarningCount()
        {
            Label lbWarningCount = new Label();
            lbWarningCount.Name = "lbWarningCount";
            pnInformation.Controls.Add(lbWarningCount);
            lbWarningCount.Location = new Point(30, flpnListOfButtonQuestions.Bottom + 20);
            lbWarningCount.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Bold);
            lbWarningCount.ForeColor = WarningCount > 0 ? Constant.FORCECOLOR_LABEL_HEADER_CONTENT : Constant.BACKCOLOR_PANEL_INFORMATION;
            lbWarningCount.Text = WarningCount > 0 ? string.Format(Properties.Resources.MSG_GUI_0053, WarningCount, GetValueOfWarningCount(WarningCount)) : string.Empty;
            lbWarningCount.Width = Constant.WIDTH_PANEL_INFORMATION;
            lbWarningCount.SendToBack();

        }
        /// <summary>
        /// Thêm nút nộp bài nếu kỳ thi có cho phép nộp bài trước thời gian hết giờ
        /// </summary>
        private void HandleGenerateButtonSubmit()
        {
            MetroPanel mpnController = (MetroPanel)pnInformation.Controls["mpnController"];
            MetroButton mbtnReportError = (MetroButton)mpnController.Controls["mbtnReportError"];
            MetroButton mbtnSubmit = new MetroButton();
            Controllers.Instance.SetCanChangeMetroButtonColor(mbtnSubmit);
            mbtnSubmit.Name = "mbtnSubmit";
            mbtnSubmit.ForeColor = Constant.FORCECOLOR_BUTTON_SUBMIT;
            mbtnSubmit.BackColor = Constant.BACKCOLOR_BUTTON_CONTROLLER;
            mbtnSubmit.Text = Properties.Resources.MSG_GUI_0011;
            mbtnSubmit.Size = Constant.SIZE_BUTTON_DEFAULT;
            mbtnSubmit.Click += new System.EventHandler(this.mbtnSubmit_Click);
            mpnController.Controls.Add(mbtnSubmit);
            mbtnSubmit.Location = new Point(mbtnReportError.Bounds.Width + 30, Convert.ToInt32((mpnController.Height - mbtnSubmit.Height) / 2));
            mpnController.Width = mbtnSubmit.Right - mbtnReportError.Left;
            mpnController.Location = new Point(Convert.ToInt32((Constant.WIDTH_PANEL_INFORMATION - mpnController.Width) / 2), lbTimer.Bottom);
        }
        private MetroButton GetMetroButtonSubmit()
        {
            MetroPanel mpnController = (MetroPanel)pnInformation.Controls["mpnController"];
            return (MetroButton)mpnController.Controls["mbtnSubmit"];
        }
        /// <summary>
        /// Xử lý nộp bài
        /// </summary>
        private void HandleSubmitTest()
        {
            ErrorController rEC = new ErrorController();
            timeCountDown.Stop();
            double result = 0;
            int count = 0;
            double rResult = 0;
            double sResult = 0;
            sResult = TestBUS.Instance.SumScore(CILogged);
            if (WarningCount >= 3)
            {
                rASH.TestScores = 0;
                rASH.Status = Constant.STATUS_WARNING;
            }
            else
            {
                List<AnswersheetDetail> lstAHD = new List<AnswersheetDetail>();

                AnswersheetDetailBUS.Instance.GetListAnswerSheetDetail(CILogged, out lstAHD);
                foreach (AnswersheetDetail ad in lstAHD)
                {

                    rResult = TestBUS.Instance.CheckAnswers(ad);
                    if (rResult > 0)
                    {
                        result += rResult;
                        count++;

                    }
                }
                rASH.TestScores = result-HandleWarning(result);
                rASH.Status = Constant.STATUS_FINISHED;

            }

            AnswersheetBUS.Instance.PushAnswerSheet(rASH, out rEC);
            if (rEC.ErrorCode == Constant.STATUS_OK)
            {
                ChangeContestantStatusToFinished();
                Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_RESULT, string.Format(Properties.Resources.MSG_GUI_0051, rASH.TestScores, sResult), this);
                Controllers.Instance.ExitApplicationFromNotificationForm(this);
            }
            else
            {
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Controllers.Instance.HandleStringErrorController(rEC));
                Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                Controllers.Instance.ExitApplicationFromNotificationForm(this);
            }
        }
        private double HandleWarning(double result)
        {
            switch (WarningCount)
            {
                case 1: return result * Properties.Settings.Default.Warning1 / 100;
                case 2: return result * Properties.Settings.Default.Warning2 / 100;
                case 3: return result;
                default: return 0;
            }
        }
        /// <summary>
        /// Xư3 lý sự kiện nút nộp bài
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mbtnSubmit_Click(object sender, EventArgs e)
        {
            UT.Status = Constant.STATUS_FINISHED;
            UT.Content = "Submit";
            ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
            Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | SUBMITATION | mbtnSubmit_Click", Properties.Resources.MSG_MESS_0008);
            HandleSubmitTest();
            Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | SUBMITATION | mbtnSubmit_Click", Properties.Resources.MSG_MESS_0009);
        }
        /// <summary>
        /// Xử lý sự iện nút báo lỗi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mbtnReportError_Click(object sender, EventArgs e)
        {
            Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_YESNO, Properties.Resources.MSG_GUI_0047, this);
            if (DTO.NotificationForm.DialogResult == DialogResult.OK)
            {
                UT.Status = Constant.STATUS_REPORT_ERROR;
                UT.Content = Properties.Resources.MSG_MESS_0038;
                ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
            }

        }
        /// <summary>
        /// Giao diện thẻ kỳ thi
        /// </summary>
        private void HandleStyleInformationOfContest()
        {
            MetroPanel mpnInformationWrapper = (MetroPanel)pnInformation.Controls["mpnInformationWrapper"];
            MetroPanel mpnController = (MetroPanel)pnInformation.Controls["mpnController"];

            MetroPanel mpnContestWrapper = new MetroPanel();
            Controllers.Instance.SetCanChangeMetroPanelColor(mpnContestWrapper);
            mpnContestWrapper.Name = "mpnContestWrapper";
            mpnContestWrapper.BackColor = Constant.BACKCOLOR_PANEL_WRAPPER_CONTENT;
            mpnContestWrapper.Width = Constant.WIDTH_PANEL_INFORMATION;
            MetroPanel mpnContestContent = new MetroPanel();

            Controllers.Instance.SetCanChangeMetroPanelColor(mpnContestContent);
            mpnContestContent.Name = "mpnContestContent";

            Label lbHeaderContest = new Label();
            lbHeaderContest.Name = "lbHeaderContest";
            lbHeaderContest.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Bold);
            lbHeaderContest.ForeColor = Constant.FORCECOLOR_LABEL_HEADER_CONTENT;
            lbHeaderContest.BackColor = Constant.COLOR_TRANSPARENT;
            lbHeaderContest.AutoSize = true;
            lbHeaderContest.Text = Properties.Resources.MSG_GUI_0005;
            lbHeaderContest.Location = new Point(0, 0);
            mpnContestContent.BackColor = Constant.COLOR_TRANSPARENT;

            ////Contest's name
            //ucRowInfor ucContestName = new ucRowInfor();
            //SendUCRowInfor sucContestName = new SendUCRowInfor(ucContestName.HandleUC);
            //sucContestName(Properties.Resources.MSG_GUI_0006, CLogged.ContestName);
            //ucContestName.Location = new Point(0, lbHeaderContest.Bounds.Height);
            //mpnContestContent.Controls.Add(ucContestName);

            ////Contest's subject
            //ucRowInfor ucContestSubject = new ucRowInfor();
            //SendUCRowInfor sucContestSubject = new SendUCRowInfor(ucContestSubject.HandleUC);
            //sucContestSubject(Properties.Resources.MSG_GUI_0008, CLogged.Subject);
            //ucContestSubject.Location = new Point(0, ucContestName.Bottom);
            //mpnContestContent.Controls.Add(ucContestSubject);

            // Ngày thi
            ucRowInfor ucContestDate = new ucRowInfor();
            SendUCRowInfor sucContestDate = new SendUCRowInfor(ucContestDate.HandleUC);
            ucContestDate.BackColor = Constant.COLOR_TRANSPARENT;
            sucContestDate(Properties.Resources.MSG_GUI_0007, Controllers.Instance.ConvertUnixToDateTime(CLogged.ShiftDate).ToString(Constant.FORMAT_DATE_DEFAULT));
            ucContestDate.Location = new Point(0, lbHeaderContest.Bounds.Height);
            mpnContestContent.Controls.Add(ucContestDate);
            // Ca thi
            ucRowInfor ucContestShift = new ucRowInfor();
            SendUCRowInfor sucContestShift = new SendUCRowInfor(ucContestShift.HandleUC);
            sucContestShift(Properties.Resources.MSG_GUI_0049, string.Format("{0} - {1}", Controllers.Instance.ConvertUnixToDateTime(CLogged.StartTime).ToString(Constant.FORMAT_TIME_DEFAULT), Controllers.Instance.ConvertUnixToDateTime(CLogged.EndTime).ToString(Constant.FORMAT_TIME_DEFAULT)));
            ucContestShift.Location = new Point(0, ucContestDate.Bottom);
            mpnContestContent.Controls.Add(ucContestShift);

            // Phòng thi
            ucRowInfor ucContestRoom = new ucRowInfor();
            SendUCRowInfor sucContestRoom = new SendUCRowInfor(ucContestRoom.HandleUC);
            sucContestRoom(Properties.Resources.MSG_GUI_0036, CLogged.RoomName);
            ucContestRoom.Location = new Point(0, ucContestShift.Bottom);
            mpnContestContent.Controls.Add(ucContestRoom);

            // Máy thi
            ucRowInfor ucContestComputer = new ucRowInfor();
            SendUCRowInfor sucContestComputer = new SendUCRowInfor(ucContestComputer.HandleUC);
            sucContestComputer(Properties.Resources.MSG_GUI_0037, Dns.GetHostName());
            ucContestComputer.Location = new Point(0, ucContestRoom.Bottom);
            mpnContestContent.Controls.Add(ucContestComputer);

            mpnContestContent.AutoSize = true;
            mpnContestContent.AutoScroll = false;
            mpnContestContent.Height = ucContestComputer.Bottom;
            mpnContestWrapper.Location = new Point(0, lbHeaderContest.Bottom - lbHeaderContest.Height / 2);
            mpnContestContent.Location = new Point(40, 0);

            mpnContestWrapper.Height = mpnContestContent.Height + 20;
            mpnInformationWrapper.Controls.Add(lbHeaderContest);
            mpnContestWrapper.Controls.Add(mpnContestContent);
            mpnInformationWrapper.Controls.Add(mpnContestWrapper);

            HandleStyleInformationOfContestant();
        }
        /// <summary>
        /// Giao diện thông tin thí sinh
        /// </summary>
        private void HandleStyleInformationOfContestant()
        {
            MetroPanel mpnInformationWrapper = (MetroPanel)pnInformation.Controls["mpnInformationWrapper"];
            MetroPanel mpnContestWrapper = (MetroPanel)mpnInformationWrapper.Controls["mpnContestWrapper"];
            MetroPanel mpnContestantWrapper = new MetroPanel();
            Controllers.Instance.SetCanChangeMetroPanelColor(mpnContestantWrapper);
            mpnContestantWrapper.Name = "mpnContestantWrapper";
            mpnContestantWrapper.BackColor = Constant.BACKCOLOR_PANEL_WRAPPER_CONTENT;
            mpnContestantWrapper.Width = Constant.WIDTH_PANEL_INFORMATION;
            MetroPanel mpnContestantContent = new MetroPanel();

            Controllers.Instance.SetCanChangeMetroPanelColor(mpnContestantContent);
            mpnContestantContent.Name = "mpnContestantContent";

            Label lbHeaderIOC = new Label();
            lbHeaderIOC.Name = "lbHeaderIOC";
            lbHeaderIOC.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Bold);
            lbHeaderIOC.ForeColor = Constant.FORCECOLOR_LABEL_HEADER_CONTENT;
            lbHeaderIOC.BackColor = Constant.COLOR_TRANSPARENT;
            lbHeaderIOC.AutoSize = true;
            lbHeaderIOC.Text = Properties.Resources.MSG_GUI_0004;
            lbHeaderIOC.Location = new Point(0, mpnContestWrapper.Bounds.Bottom + 30);

            // Tên thí sinh
            ucRowInfor ucFullname = new ucRowInfor();
            SendUCRowInfor sucFullname = new SendUCRowInfor(ucFullname.HandleUC);
            sucFullname(Properties.Resources.MSG_GUI_0001, Controllers.Instance.CapitalizeString(CILogged.Fullname));
            ucFullname.Location = new Point(0, lbHeaderIOC.Bounds.Height);
            mpnContestantContent.Controls.Add(ucFullname);

            // Ngày sinh 
            ucRowInfor ucDOB = new ucRowInfor();
            SendUCRowInfor sucDOB = new SendUCRowInfor(ucDOB.HandleUC);
            sucDOB(Properties.Resources.MSG_GUI_0002, Controllers.Instance.ConvertUnixToDateTime(CILogged.DOB).ToString(Constant.FORMAT_DATE_DEFAULT));
            ucDOB.Location = new Point(0, ucFullname.Bottom);
            mpnContestantContent.Controls.Add(ucDOB);

            // Số CMND
            ucRowInfor ucStudentIdentify = new ucRowInfor();
            SendUCRowInfor sucStudentIdentify = new SendUCRowInfor(ucStudentIdentify.HandleUC);
            sucStudentIdentify(Properties.Resources.MSG_GUI_0003, CILogged.IdentityCardName);
            ucStudentIdentify.Location = new Point(0, ucDOB.Bottom);
            mpnContestantContent.Controls.Add(ucStudentIdentify);

            mpnContestantContent.AutoSize = true;
            mpnContestantContent.AutoScroll = false;
            mpnContestantContent.Height = mpnContestantContent.Height + 20;
            mpnContestantWrapper.Location = new Point(0, lbHeaderIOC.Bottom - lbHeaderIOC.Height / 2);
            mpnContestantContent.Location = new Point(40, 0);

            mpnContestantWrapper.Height = mpnContestantContent.Height + 20;
            mpnInformationWrapper.Controls.Add(lbHeaderIOC);
            mpnContestantWrapper.Controls.Add(mpnContestantContent);
            mpnInformationWrapper.Controls.Add(mpnContestantWrapper);

            HandleStyleWarning();
        }
        private MetroPanel GetPanelInformationWrapper()
        {
            return (MetroPanel)pnInformation.Controls["mpnInformationWrapper"];
        }
        /// <summary>
        /// Giao diện chú ý lỗi
        /// </summary>
        private void HandleStyleWarning()
        {
            MetroPanel mpnInformationWrapper = (MetroPanel)pnInformation.Controls["mpnInformationWrapper"];
            MetroPanel mpnContestantWrapper = (MetroPanel)mpnInformationWrapper.Controls["mpnContestantWrapper"];

            MetroPanel mpnWarningWrapper = new MetroPanel();
            mpnWarningWrapper.Name = "mpnWarningWrapper";
            Controllers.Instance.SetCanChangeMetroPanelColor(mpnWarningWrapper);
            mpnWarningWrapper.BackColor = Constant.BACKCOLOR_PANEL_WRAPPER_CONTENT;
            mpnWarningWrapper.Width = Constant.WIDTH_PANEL_INFORMATION;
            mpnInformationWrapper.Controls.Add(mpnWarningWrapper);

            MetroPanel mpnWarningContent = new MetroPanel();
            Controllers.Instance.SetCanChangeMetroPanelColor(mpnWarningContent);
            mpnWarningContent.Name = "mpnWarningContent";
            mpnWarningContent.AutoSize = true;
            mpnWarningWrapper.Controls.Add(mpnWarningContent);

            Label lbHeaderWarning = new Label();
            lbHeaderWarning.Name = "lbHeaderWarning";
            lbHeaderWarning.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Bold);
            lbHeaderWarning.ForeColor = Constant.FORCECOLOR_LABEL_HEADER_CONTENT;
            lbHeaderWarning.BackColor = Constant.COLOR_TRANSPARENT;
            lbHeaderWarning.AutoSize = true;
            lbHeaderWarning.Text = Properties.Resources.MSG_MESS_0029;
            lbHeaderWarning.Location = new Point(0, mpnContestantWrapper.Bounds.Bottom + 30);
            mpnInformationWrapper.Controls.Add(lbHeaderWarning);

            Label lbWarning1 = new Label();
            lbWarning1.Name = "lbWarning1";
            lbWarning1.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Bold);
            lbWarning1.ForeColor = Constant.COLOR_WHITE;
            lbWarning1.BackColor = Constant.COLOR_TRANSPARENT;
            lbWarning1.AutoSize = true;
            lbWarning1.Text = string.Format(Properties.Resources.MSG_MESS_0030, 1, Properties.Settings.Default.Warning1);
            lbWarning1.Location = new Point(0, 0);
            mpnWarningContent.Controls.Add(lbWarning1);


            Label lbWarning2 = new Label();
            lbWarning2.Name = "lbWarning2";
            lbWarning2.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Bold);
            lbWarning2.ForeColor = Constant.COLOR_WHITE;
            lbWarning2.BackColor = Constant.COLOR_TRANSPARENT;
            lbWarning2.AutoSize = true;
            lbWarning2.Text = string.Format(Properties.Resources.MSG_MESS_0030, 2, Properties.Settings.Default.Warning2);
            lbWarning2.Location = new Point(0, lbWarning1.Bounds.Bottom + 10);
            mpnWarningContent.Controls.Add(lbWarning2);

            Label lbWarning3 = new Label();
            lbWarning3.Name = "lbWarning3";
            lbWarning3.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Bold);
            lbWarning3.ForeColor = Constant.COLOR_WHITE;
            lbWarning3.BackColor = Constant.COLOR_TRANSPARENT;
            lbWarning3.AutoSize = true;
            lbWarning3.Text = Properties.Resources.MSG_MESS_0031;
            lbWarning3.Location = new Point(0, lbWarning2.Bounds.Bottom + 10);
            mpnWarningContent.Controls.Add(lbWarning3);

            mpnWarningWrapper.Location = new Point(0, lbHeaderWarning.Bottom - lbHeaderWarning.Height / 2);
            mpnWarningContent.Height = lbWarning3.Bounds.Bottom;

            mpnWarningWrapper.Height = mpnWarningContent.Bottom + 30;
            mpnWarningContent.Location = new Point(30, lbHeaderWarning.Height);


            mpnInformationWrapper.Controls.Add(mpnWarningWrapper);
        }
        #endregion

        #region List of question panel
        /// <summary>
        ///Giao diện danh sách câu hỏi thi
        /// </summary>
        private void HandlePanelListOfQuestions()
        {
            HandlePanelLoading();
            #region Panel list of question
            flpnListOfQuestions.Dock = DockStyle.Right;
            flpnListOfQuestions.BackColor = Constant.BACKCOLOR_PANEL_INFORMATION;
            flpnListOfQuestions.Width = Constant.WIDTH_SCREEN - Constant.WIDTH_PANEL_INFORMATION;
            flpnListOfQuestions.Controls.Clear();
            #endregion
        }
        #endregion

        #region Panel loading
        private void HandlePanelLoading()
        {
            MetroPanel mpnLoading = new MetroPanel();
            mpnLoading.Name = "mpnLoading";
            this.Controls.Add(mpnLoading);
            Controllers.Instance.SetCanChangeMetroPanelColor(mpnLoading);
            mpnLoading.BackColor = Constant.BACKCOLOR_PANEL_INFORMATION;
            mpnLoading.Width = Constant.WIDTH_SCREEN - Constant.WIDTH_PANEL_INFORMATION;
            mpnLoading.Height = Constant.HEIGHT_SCREEN;
            mpnLoading.Location = new Point(Constant.WIDTH_PANEL_INFORMATION, 0);
            mpnLoading.BringToFront();
        }
        private MetroPanel GetPanelLoading()
        {
            return (MetroPanel)this.Controls["mpnLoading"];
        }
        /// <summary>
        /// Giao diện chờ làm bài thi
        /// </summary>
        private void HandleContentPanelLoading()
        {
            MetroPanel mpnLoadingWrapper = new MetroPanel();
            mpnLoadingWrapper.Name = "mpnLoadingWrapper";
            Controllers.Instance.SetCanChangeMetroPanelColor(mpnLoadingWrapper);
            GetPanelLoading().Controls.Add(mpnLoadingWrapper);
            mpnLoadingWrapper.BackColor = Constant.COLOR_TRANSPARENT;
            mpnLoadingWrapper.AutoSize = true;

            Label lbContent = new Label();
            lbContent.Name = "lbContent";
            mpnLoadingWrapper.Controls.Add(lbContent);
            lbContent.Font = new Font(Constant.FONT_FAMILY_DEFAULT, 20, FontStyle.Bold);
            lbContent.Text = Properties.Resources.MSG_GUI_0058;
            lbContent.AutoSize = true;

            //MetroButton mbtnStart = new MetroButton();
            //mbtnStart.Name = "mbtnStart";
            //Controllers.SetCanChangeMetroButtonColor(mbtnStart);
            //mbtnStart.Text = Properties.Resources.MSG_GUI_0010;
            //mbtnStart.ForeColor = Constant.FORCECOLOR_BUTTON_SUBMIT;
            //mbtnStart.BackColor = Constant.BACKCOLOR_BUTTON_CONTROLLER;
            //mbtnStart.Size = Constant.SIZE_BUTTON_DEFAULT;
            //mbtnStart.Click += new System.EventHandler(this.mbtnStart_Click);
            //mbtnStart.Location = new Point(Convert.ToInt32((mpnLoadingWrapper.Bounds.Width - mbtnStart.Width) / 2), lbContent.Bounds.Bottom + 20);

            //mpnLoadingWrapper.Controls.Add(mbtnStart);

            mpnLoadingWrapper.Location = new Point(Convert.ToInt32((GetPanelLoading().Bounds.Width - mpnLoadingWrapper.Width) / 2), Convert.ToInt32((GetPanelLoading().Bounds.Height - mpnLoadingWrapper.Height) / 2));
        }
        //private MetroButton GetButtonStart()
        //{
        //    MetroPanel mpnLoadingWrapper = (MetroPanel)GetPanelLoading().Controls["mpnLoadingWrapper"];
        //    return (MetroButton)mpnLoadingWrapper.Controls["mbtnStart"];
        //}
        //private void mbtnStart_Click(object sender, EventArgs e)
        //{
        //    int rStatus = Constant.STATUS_NORMAL;
        //    string rMessage = string.Empty;
        //    GetPanelLoading().Visible = false;
        //    GetPanelInformationWrapper().Visible = false;
        //    HandleTimer();
        //    CILogged.Status = Constant.STATUS_DOING;
        //    ContestantBUS.Instance.ChangeStatusContestant(CILogged, out rStatus, out rMessage);
        //    if (rStatus == Constant.STATUS_OK)
        //    {
        //        Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "CHANGE_STATUS_CONTESTANT", rMessage);
        //    }
        //    else
        //    {
        //        Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, rMessage);
        //    }
        //    UT.Status = Constant.STATUS_DOING;
        //    UT.Content = "DOING TEST AT " + CILogged.TimeDisconnect;
        //    bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
        //    if (!uhRes)
        //    {
        //        ClosingSocket();
        //    }
        //}
        /// <summary>
        /// Hàm xử lý bắt đầu thi
        /// </summary>
        private void HandleStartDoingTest()
        {
            ErrorController rEC = new ErrorController();
            GetPanelLoading().Visible = false;
            GetPanelInformationWrapper().Visible = false;
            HandleTimer();
            CILogged.Status = Constant.STATUS_DOING;
            if (currentStatusContestant == Constant.STATUS_LOGGED)
            {
                CILogged.IsNewStarted = true;
                CILogged.TimeStarted = Controllers.Instance.ConvertDateTimeToUnix(DAO.DAO.ConvertDateTime.GetDateTimeServer());
            }
            ContestantBUS.Instance.ChangeStatusContestant(CILogged, CLogged, out rEC);
            if (rEC.ErrorCode == Constant.STATUS_OK)
            {
                Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | CHANGE_STATUS_CONTESTANT | STATUS_DOING | HandleStartDoingTest | ChangeStatusContestant", Controllers.Instance.HandleStringErrorController(rEC));
                UT.Status = Constant.STATUS_DOING;
                UT.Content = "DOING TEST AT " + Controllers.Instance.ConvertUnixToDateTime(CILogged.TimeStarted).ToShortTimeString();
                bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                if (!uhRes)
                {
                    ClosingSocket();
                }
            }
            else
            {
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, Controllers.Instance.HandleStringErrorController(rEC));
                Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                Controllers.Instance.ExitApplicationFromNotificationForm(this);
            }
        }
        #endregion
        #endregion

        #region Generate List control
        /// <summary>
        ///  Thực hiện tạo các object câu hỏi
        /// </summary>
        private void GernerateObjControl()
        {
            Application.DoEvents();
            this.Cursor = Cursors.WaitCursor;
            HandleGetTestInformation();
            Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | GENERATION_OBJ_CONTROL | GernerateObjControl | HandleGetTestInformation", Properties.Resources.MSG_MESS_0008);
            Debug.WriteLine(IsContinute);
            DTO.LoadingForm.TotalProgress = IsContinute ? 5:4;
            ///  DTO.LoadingForm.TotalProgress = 40;
            s = new SendWorking(DTO.LoadingForm.HandleWorking);
            DTO.LoadingForm.Owner = this;
            DTO.LoadingForm.Show();
            // Khởi tạo tiến trình render giao diện trang làm bài
            lstObjControl = new List<ObjControl>();

            foreach (List<Questions> lstQ in lstLQuestion)
            {

                lstObjControl.Add(new ObjControl(lstQ, CILogged.AnswerSheetID, Constant.WIDTH_SCREEN - Constant.WIDTH_PANEL_INFORMATION - 50));
            }
            GenerateControlQuestions();
            GenerateLayoutQuestions();
            GenerateControlBtnQuestions();
            GenerateLayoutButtonQuestions();
            HandleUCQuestionPerformClick();

            ErrorController rEC = new ErrorController();
            Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | RENDER_LAYOUT", Properties.Resources.MSG_MESS_0007);
            if (currentStatusContestant == Constant.STATUS_LOGGED)
            {
                Label lbContent = (Label)((MetroPanel)GetPanelLoading().Controls["mpnLoadingWrapper"]).Controls["lbContent"];
                lbContent.Text = Properties.Resources.MSG_GUI_0034;
            }
            // Change status to STATUS_READY
            if (currentStatusContestant == Constant.STATUS_LOGGED_DO_NOT_FINISH)
            {
                IsLoadingTest = Constant.LOAD_TEST_WITH_CONTESTANT_INTERRUPT;
            }
            if (currentStatusContestant == Constant.STATUS_LOGGED)
            {
                CILogged.Status = Constant.STATUS_READY;
                ContestantBUS.Instance.ChangeStatusContestant(CILogged, CLogged, out rEC);
                if (rEC.ErrorCode == Constant.STATUS_OK)
                {
                    Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | CHANGE_STATUS_CONTESTANT_RADIO_PERFORMCLICK | STATUS_READY | ChangeStatusContestant", Controllers.Instance.HandleStringErrorController(rEC));
                    UT.Status = Constant.STATUS_READY;
                    UT.Content = "READY TO DO TEST";
                    bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                    if (!uhRes)
                    {
                        ClosingSocket();
                    }
                    if (currentStatusContestant == Constant.STATUS_LOGGED_DO_NOT_FINISH)
                    {
                        IsLoadingTest = Constant.LOAD_TEST_WITH_CONTESTANT_INTERRUPT;
                    }
                }
                else
                {
                    Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, Controllers.Instance.HandleStringErrorController(rEC));
                    Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                    Controllers.Instance.ExitApplicationFromNotificationForm(this);

                }
            }
            this.Cursor = Cursors.Arrow;
        }
        /// <summary>
        /// Khởi tạo giao diện câu hỏi
        /// </summary>
        /// <returns></returns>
        private void GenerateControlQuestions()
        {
            Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "GENERATION_QUESTIONS", Properties.Resources.MSG_MESS_0008);
            lstbtnQuestions = new List<string>();
            //TypeControl = Constant.CONTROL_QUESTION;
            //HandleAddControl.Start(lstObjControl, Constant.CONTROL_QUESTION);
            int count = 0;
            int next = 0;
            int nextd = 0;
            Application.DoEvents();
            foreach (ObjControl obj in lstObjControl)
            {
                if (obj.Question.Count > 1)
                {
                    FlowLayoutPanel flpnMultiQuestion = new FlowLayoutPanel();
                    flpnMultiQuestion.BackColor = Constant.COLOR_WHITE;
                    flpnMultiQuestion.Width = obj.Width;
                    flpnMultiQuestion.AutoSize = true;
                    Questions qHeader = obj.Question[0];
                    obj.Question.RemoveAt(0);

                    if (qHeader.FormatQuestion == Constant.FORMAT_QUESTION_HTML)
                    {
                        HtmlLabel hlbTitleOfQuestion = new HtmlLabel();
                        Controllers.Instance.SetStyleHtmlLabel(hlbTitleOfQuestion);
                        hlbTitleOfQuestion.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Regular);
                        hlbTitleOfQuestion.Text = qHeader.TitleOfQuestion;
                        hlbTitleOfQuestion.Location = new Point(0, 0);
                        hlbTitleOfQuestion.Height = Convert.ToInt32(hlbTitleOfQuestion.HtmlContainer.Bounds.Height) + 20;
                        hlbTitleOfQuestion.Width = obj.Width - 30;
                        hlbTitleOfQuestion.HtmlContainer.Width = hlbTitleOfQuestion.Width.ToString();
                        hlbTitleOfQuestion.HtmlContainer.Margin = "0 auto";
                        hlbTitleOfQuestion.Padding = new Padding(15, 5, 15, 5);

                        flpnMultiQuestion.Controls.Add(hlbTitleOfQuestion);

                        foreach (Questions q in obj.Question)
                        {
                            if (q.IsQuestionContent && q.IsSingleChoice)
                            {
                                ucQuestionsHTML ucHtml = new ucQuestionsHTML();
                                ucHtml.Width = obj.Width;
                                SendQuestion sq = new SendQuestion(ucHtml.HandleQuestion);
                                sq(q, obj.AnswerSheetID);
                                ucHtml.Tag = q.SubQuestionID;
                                flpnMultiQuestion.Controls.Add(ucHtml);
                            }
                            else
                            {
                                // TODO
                            }
                        }
                    }
                    else if (qHeader.FormatQuestion == Constant.FORMAT_QUESTION_RTF)
                    {
                        RichTextBox rtbTitleOfQuestion = new RichTextBox();
                        Controllers.Instance.HandleRichTextBoxStyle(rtbTitleOfQuestion);                     
                        rtbTitleOfQuestion.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Bold | FontStyle.Italic);
                        rtbTitleOfQuestion.Rtf = qHeader.TitleOfQuestion;
                        rtbTitleOfQuestion.Width = flpnMultiQuestion.Width - 30;
                        rtbTitleOfQuestion.Height += 20;
                        rtbTitleOfQuestion.Margin = new Padding(15, 5, 0, 5);
                        flpnMultiQuestion.Controls.Add(rtbTitleOfQuestion);
                        count = 0;
                      
                        foreach (Questions q in obj.Question)
                        {
                            if (q.IsQuestionContent && q.IsSingleChoice)
                            {
                                ucQuestionsRTF ucRTF = new ucQuestionsRTF();
                                ucRTF.Width = obj.Width;
                             
                                q.NO = (next + 1);
                                next++;
                                nextd = q.NO;
                                SendQuestion sq = new SendQuestion(ucRTF.HandleQuestion);
                                sq(q, obj.AnswerSheetID);
                                ucRTF.Tag = q.SubQuestionID;
                                flpnMultiQuestion.Controls.Add(ucRTF);
                            }
                            else if (!q.IsQuestionContent && q.IsSingleChoice)
                            {
                                ucQuestionsRTF ucRTF = new ucQuestionsRTF();
                                ucRTF.Width = obj.Width;
                               
                                q.NO = (next + 1);
                                next++;
                                nextd = q.NO;
                                SendQuestion sq = new SendQuestion(ucRTF.HandleQuestion);
                                sq(q, obj.AnswerSheetID);
                                ucRTF.Tag = q.SubQuestionID;
                                flpnMultiQuestion.Controls.Add(ucRTF);
                            }
                            else
                            {
                                // TODO
                            }

                        }
                    }
                    lstControlQuestions.Add(flpnMultiQuestion);
                }
                else
                {
                    foreach (Questions q in obj.Question)
                    {
                        if (q.FormatQuestion == Constant.FORMAT_QUESTION_HTML)
                        {
                            if (q.IsQuestionContent && q.IsSingleChoice)
                            {
                                ucQuestionsHTML ucHtml = new ucQuestionsHTML();
                                ucHtml.Width = obj.Width;
                                SendQuestion sq = new SendQuestion(ucHtml.HandleQuestion);
                                sq(q, obj.AnswerSheetID);
                                ucHtml.Tag = q.SubQuestionID;

                                lstControlQuestions.Add(ucHtml);
                            }
                            else
                            {
                                // TODO
                            }
                        }
                        else if (q.FormatQuestion == Constant.FORMAT_QUESTION_RTF)
                        {
                            if (q.IsQuestionContent && q.IsSingleChoice)
                            {

                                if (nextd != 0)
                                {
                                    q.NO = nextd + 1;
                                    nextd = 0;
                                }
                                else
                                {
                                    q.NO = next + 1;
                                }
                                ucQuestionsRTF ucRTF = new ucQuestionsRTF();

                                ucRTF.Width = obj.Width + 10;
                                //if (count != 0)
                                //{
                                //    q.NO +=(count-1);
                                //}
                                next = q.NO;
                                SendQuestion sq = new SendQuestion(ucRTF.HandleQuestion);
                                sq(q, obj.AnswerSheetID);
                                ucRTF.Tag = q.SubQuestionID;

                                lstControlQuestions.Add(ucRTF);
                            }
                            else
                            {
                                // TODO
                            }
                        }
                    }
                }
            }
            s(true);
        }
        /// <summary>
        /// Generate control button questions
        /// </summary>
        /// <returns></returns>
        private void GenerateControlBtnQuestions()
        {
            Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | GENERATION_BUTTON_QUESTIONS | GenerateControlBtnQuestions", Properties.Resources.MSG_MESS_0008);
            lstObjControl = new List<ObjControl>();
            Application.DoEvents();
            int NumberOfButton = Constant.WIDTH_PANEL_INFORMATION / Constant.SIZE_BUTTON_QUESTION.Width;
            foreach (string top in lstbtnQuestions)
            {
                lstObjControl.Add(new ObjControl(top, NumberOfButton >= 5 ? 5 : NumberOfButton));
            }
            foreach (var obj in lstObjControl.Select((value, index) => new { data = value, index = index }))
            {
                MetroButton mbtnQuestion = new MetroButton();
                mbtnQuestion.UseCustomBackColor = true;
                mbtnQuestion.UseCustomForeColor = true;
                mbtnQuestion.Cursor = Cursors.Hand;
                mbtnQuestion.FontSize = MetroButtonSize.Medium;
                mbtnQuestion.FontWeight = MetroButtonWeight.Bold;
                mbtnQuestion.ForeColor = Constant.FORCECOLOR_BUTTON_SUBMIT;
                mbtnQuestion.BackColor = Constant.BACKCOLOR_BUTTON_CONTROLLER;
                mbtnQuestion.Size = Constant.SIZE_BUTTON_QUESTION;
                mbtnQuestion.Name = "mbtn" + obj.index;
                mbtnQuestion.Text = string.Format(Properties.Resources.MSG_GUI_0020, obj.index + 1);
                mbtnQuestion.Tag = obj.data.Top;
                if (obj.index % obj.data.Width == 0)
                {
                    int marginLeft = Convert.ToInt32((Constant.WIDTH_PANEL_INFORMATION - ((Constant.SIZE_BUTTON_QUESTION.Width + 5) * obj.data.Width)) / 2);
                    mbtnQuestion.Margin = new Padding(marginLeft, 5, 0, 5);
                }
                else
                {
                    mbtnQuestion.Margin = new Padding(5, 5, 0, 5);
                }
                lstControlBtnQuestions.Add(mbtnQuestion);
            }
            s(true);
            Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | GENERATION_BUTTON_QUESTIONS | GenerateControlBtnQuestions", Properties.Resources.MSG_MESS_0009);
        }
        #endregion

        #region Handle render layout
        /// <summary>
        /// Generate question to FlowLayoutPanel
        /// </summary>
        private void GenerateLayoutQuestions()
        {
            Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | GENERATE_LAYOUT_QUESTION | GenerateLayoutQuestions", Properties.Resources.MSG_MESS_0008);
            Application.DoEvents();
            foreach (Control e in lstControlQuestions)
            {
                flpnListOfQuestions.Controls.Add(e);
                if (e.GetType().ToString().EndsWith(Constant.STRING_FLOWLAYOUTPANEL))
                {
                    foreach (Control c in e.Controls)
                    {
                        if (c.GetType().ToString().EndsWith(Constant.STRING_QUESTION_HTML) || c.GetType().ToString().EndsWith(Constant.STRING_QUESTION_RTF))
                        {
                            lstbtnQuestions.Add(string.Format("{0}_{1}", e.Top + c.Top, c.Tag));
                        }
                    }
                }
                else
                {
                    lstbtnQuestions.Add(string.Format("{0}_{1}", e.Top, e.Tag));
                }
            }
            s(true);
        }
        /// <summary>
        /// Thực hiện đánh dấu các câu đã làm
        /// </summary>
        private void HandleUCQuestionPerformClick()
        {
            Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | RELOAD_TOPIC | HandleUCQuestionPerformClick", Properties.Resources.MSG_MESS_0008);
            Application.DoEvents();
            for (int i = 0; i < lstControlQuestions.Count; i++)
            {
                if (IsContinute)
                {
                    foreach (Control c in flpnListOfQuestions.Controls)
                    {
                        if (c.GetType().ToString().EndsWith(Constant.STRING_FLOWLAYOUTPANEL))
                        {
                            foreach (Control c1 in c.Controls)
                            {
                                if (c1.GetType().ToString().EndsWith(Constant.STRING_QUESTION_HTML))
                                {
                                    (c1 as ucQuestionsHTML).HandleClickMrbtnAnswer();
                                }
                                else if (c1.GetType().ToString().EndsWith(Constant.STRING_QUESTION_RTF))
                                {
                                    (c1 as ucQuestionsRTF).HandleClickRadioAnswer();
                                }
                            }
                        }
                        else
                        {
                            if (c.GetType().ToString().EndsWith(Constant.STRING_QUESTION_HTML))
                            {
                                (c as ucQuestionsHTML).HandleClickMrbtnAnswer();
                            }
                            else if (c.GetType().ToString().EndsWith(Constant.STRING_QUESTION_RTF))
                            {
                                (c as ucQuestionsRTF).HandleClickRadioAnswer();
                            }
                        }
                    }
                }
            }
            s(IsContinute);
        }

        /// <summary>
        /// Danh sách button lối tắt cho mỗi câu hỏi
        /// </summary>
        private void GenerateLayoutButtonQuestions()
        {
            Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "GENERATE_LAYOUT_BUTTON_QUESTION", Properties.Resources.MSG_MESS_0008);
            Application.DoEvents();
            foreach (Control e in lstControlBtnQuestions)
            {
                e.Click += new System.EventHandler(this.mbtnQuestion_Click);
                string[] arrTag = e.Tag.ToString().Split('_');
                int CurrentSubQuestionID = Convert.ToInt32(arrTag[1]);
                int Top = Convert.ToInt32(arrTag[0]);
                foreach (Control c in flpnListOfQuestions.Controls)
                {
                    if (c.GetType().ToString().EndsWith(Constant.STRING_FLOWLAYOUTPANEL))
                    {
                        foreach (Control c1 in c.Controls)
                        {
                            if (Convert.ToInt32(c1.Tag) == CurrentSubQuestionID)
                            {
                                if (c1.GetType().ToString().EndsWith(Constant.STRING_QUESTION_HTML))
                                {
                                    (c1 as ucQuestionsHTML).mbtnControl = e;
                                }
                                else if (c1.GetType().ToString().EndsWith(Constant.STRING_QUESTION_RTF))
                                {
                                    (c1 as ucQuestionsRTF).mbtnControl = e;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(c.Tag) == CurrentSubQuestionID)
                        {
                            if (c.GetType().ToString().EndsWith(Constant.STRING_QUESTION_HTML))
                            {
                                (c as ucQuestionsHTML).mbtnControl = e;
                            }
                            else if (c.GetType().ToString().EndsWith(Constant.STRING_QUESTION_RTF))
                            {
                                (c as ucQuestionsRTF).mbtnControl = e;
                            }
                        }
                    }
                }
                flpnListOfButtonQuestions.Controls.Add(e);
            }
            s(true);
        }
        #endregion

        #region Handle thread
        private void mbtnQuestion_Click(object sender, EventArgs e)
        {

            MetroButton mbtn = sender as MetroButton;
            string[] arrTag = mbtn.Tag.ToString().Split('_');
            int CurrentSubQuestionID = Convert.ToInt32(arrTag[1]);
            int Top = Convert.ToInt32(arrTag[0]);
            if (PreSubQuestionID != Constant.STATUS_NORMAL)
            {
                foreach (Control c in flpnListOfQuestions.Controls)
                {
                    if (c.GetType().ToString().EndsWith(Constant.STRING_FLOWLAYOUTPANEL))
                    {
                        foreach (Control c1 in c.Controls)
                        {
                            if (Convert.ToInt32(c1.Tag) == PreSubQuestionID)
                            {
                                c1.BackColor = Constant.COLOR_WHITE;
                            }
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(c.Tag) == PreSubQuestionID)
                        {
                            c.BackColor = Constant.COLOR_WHITE;
                        }
                    }
                }
            }

            foreach (Control c in flpnListOfQuestions.Controls)
            {
                if (c.GetType().ToString().EndsWith(Constant.STRING_FLOWLAYOUTPANEL))
                {
                    foreach (Control c1 in c.Controls)
                    {
                        if (Convert.ToInt32(c1.Tag) == CurrentSubQuestionID)
                        {
                            flpnListOfQuestions.AutoScrollPosition = new Point(0, Top - (Constant.HEIGHT_SCREEN - c1.Height) / 2);
                            c1.BackColor = Constant.BACKCOLOR_PANEL_QUESTION;
                        }
                    }
                }
                else
                {
                    if (Convert.ToInt32(c.Tag) == CurrentSubQuestionID)
                    {
                        flpnListOfQuestions.AutoScrollPosition = new Point(0, Top - (Constant.HEIGHT_SCREEN - c.Height) / 2);
                        c.BackColor = Constant.BACKCOLOR_PANEL_QUESTION;
                    }
                }
            }
            PreSubQuestionID = CurrentSubQuestionID;
        }
        #endregion

        /// <summary>
        /// Thay đổi trạng thái thí sinh sang đã hoàn thành bài thi STATUS_FINISHED
        /// </summary>
        private void ChangeContestantStatusToFinished()
        {
            ErrorController rEC = new ErrorController();
            // Change status contestant to STATUS_FINISHED
            CILogged.Status = WarningCount == 3 ? Constant.STATUS_REJECT : Constant.STATUS_FINISHED;
            CILogged.IsDisconnected = true;
         
            ContestantBUS.Instance.ChangeStatusContestant(CILogged, CLogged, out rEC);
            if (rEC.ErrorCode == Constant.STATUS_OK)
            {
                Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | CHANGE_STATUS_CONTESTANT | STATUS_FINISHED | ChangeContestantStatusToFinished", Controllers.Instance.HandleStringErrorController(rEC));
                UT.Status = Constant.STATUS_FINISHED;
                UT.Content = "CONTESTANT FINISHED";
                bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                if (!uhRes)
                {
                    ClosingSocket();
                }
            }
            else
            {
                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, Controllers.Instance.HandleStringErrorController(rEC));
                Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                Controllers.Instance.ExitApplicationFromNotificationForm(this);
            }
        }

        /// <summary>
        /// Xử lý thoát chương trình khi không thể kết nối đến máy giám thị
        /// </summary>
        private void ClosingSocket()
        {
            Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_INFO, Properties.Resources.MSG_CON_0002, this);
            if (DTO.NotificationForm.DialogResult == DialogResult.OK)
            {
                if (ClientSocket != null)
                {
                    UT.Status = Constant.STATUS_NORMAL;
                    ClientSocket.Dispose();
                }
                Application.ExitThread();
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// Xử khi client không có kết nôi với máy giám thị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>

        public int countcheck = 0;
        private void Remote_NoConnected(object sender, object data)
        {
            if (UT.Status == Constant.STATUS_NORMAL)
            {
                ClientSocket.Connect();
                if (countcheck != 0)
                {
                    UT.UserID = CILogged.ContestantID;
                    ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));

                }
                countcheck++;

            }
        }
        /// <summary>
        /// Xử lý nhận thông tin nhận được từ server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        private void Remote_Receive(object sender, object data)
        {

            UserHelper.UserTransformation Recieve = UserHelper.Ultis.FromJSONToObject((string)data);
            if (Recieve.Status == Constant.STATUS_STARTED)
            {
                HandleStartDoingTest();
                // Cập nhật lại trạng thái đã nhận đc gói tin từ server
                ClientSocket.Status = false;
            }
            else if (Recieve.Status == Constant.STATUS_WARNING)
            {
                WarningCount++;
                if (WarningCount < 3)
                {
                    Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, string.Format(Properties.Resources.MSG_GUI_0054, WarningCount, GetValueOfWarningCount(WarningCount)), this);
                    if (DTO.NotificationForm.DialogResult == DialogResult.OK)
                    {
                        // TODO
                        Label lbWarning = (Label)pnInformation.Controls["lbWarningCount"];
                        lbWarning.Text = string.Format(Properties.Resources.MSG_GUI_0053, WarningCount, GetValueOfWarningCount(WarningCount));
                        lbWarning.ForeColor = Constant.FORCECOLOR_LABEL_HEADER_CONTENT;
                    }
                }
                else
                {
                    timeCountDown.Stop();
                    Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Properties.Resources.MSG_GUI_0055, this);
                    HandleSubmitTest();
                    Controllers.Instance.ExitApplicationFromNotificationForm(this);
                }

                ClientSocket.Status = false;
            }
            else if (Recieve.Status == Constant.STATUS_GET_TEST)
            {
                IsLoadingTest = Constant.WAITING_BY_ADMIN_TO_LOAD_TEST;

            }
        }

        private int GetValueOfWarningCount(int warningCount)
        {
            if (warningCount == 1)
            {
                return Properties.Settings.Default.Warning1;
            }
            else if (warningCount == 2)
            {
                return Properties.Settings.Default.Warning2;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Xử lý khi tắt chương trình
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ErrorController rEC = new ErrorController();
            if (CILogged.Status == Constant.STATUS_DOING)
            {
                if (maxTime != 0)
                {
                    // Đổi trạng thái thí sinh sang trạng thái  STATUS_DOING_BUT_INTERRUPT
                    CILogged.Status = Constant.STATUS_DOING_BUT_INTERRUPT;
                    CILogged.IsDisconnected = true;
                    ContestantBUS.Instance.ChangeStatusContestant(CILogged, CLogged, out rEC);
                    if (rEC.ErrorCode == Constant.STATUS_OK)
                    {
                        Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | CHANGE_STATUS_CONTESTANT | STATUS_DOING_BUT_INTERRUPT | frmMainForm_FormClosing | STATUS_DOING", Controllers.Instance.HandleStringErrorController(rEC));
                        // Send message to supervisor STATUS_DOING_BUT_INTERRUPT
                        UT.Status = Constant.STATUS_DOING_BUT_INTERRUPT;
                        UT.Content = "CONTESTANT DISCONNECTED WHILE DOING TEST AT " + maxTime;
                        bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                        if (!uhRes)
                        {
                            ClosingSocket();
                        }
                    }
                    else
                    {
                        Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, Controllers.Instance.HandleStringErrorController(rEC));
                        Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                        Controllers.Instance.ExitApplicationFromNotificationForm(this);
                    }
                }
                else
                {
                    ChangeContestantStatusToFinished();
                }
            }
            else if (CILogged.Status == Constant.STATUS_READY || CILogged.Status == Constant.STATUS_LOGGED_DO_NOT_FINISH)
            {
                // Đổi trạng thái thí sinh sang trạng thái  STATUS_DOING_BUT_INTERRUPT
                CILogged.Status = Constant.STATUS_DOING_BUT_INTERRUPT;
                ContestantBUS.Instance.ChangeStatusContestant(CILogged, CLogged, out rEC);
                if (rEC.ErrorCode == Constant.STATUS_OK)
                {
                    Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | CHANGE_STATUS_CONTESTANT | STATUS_DOING_BUT_INTERRUPT | frmMainForm_FormClosing | STATUS_READY||STATUS_LOGGED_DO_NOT_FINISH", Controllers.Instance.HandleStringErrorController(rEC));
                    // Send message to supervisor STATUS_DOING_BUT_INTERRUPT
                    UT.Status = Constant.STATUS_LOGGED_DO_NOT_FINISH;
                    UT.Content = "CONTESTANT DISCONNECTED BEFORE DOING TEST";
                    bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                    if (!uhRes)
                    {
                        ClosingSocket();
                    }
                }
                else
                {
                    Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, Controllers.Instance.HandleStringErrorController(rEC));
                    Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                    Controllers.Instance.ExitApplicationFromNotificationForm(this);
                }
            }
            else if (CILogged.Status == Constant.STATUS_LOGGED || CILogged.Status == Constant.STATUS_READY_TO_GET_TEST)
            {
                // Đổi trạng thái thí sinh sang trạng thái  STATUS_INITIALIZE
                CILogged.Status = Constant.STATUS_INITIALIZE;
                ContestantBUS.Instance.ChangeStatusContestant(CILogged, CLogged, out rEC);
                if (rEC.ErrorCode == Constant.STATUS_OK)
                {
                    Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | CHANGE_STATUS_CONTESTANT | STATUS_INITIALIZE | frmMainForm_FormClosing | STATUS_LOGGED||STATUS_READY_TO_GET_TEST", Controllers.Instance.HandleStringErrorController(rEC));
                    // Send message to supervisor STATUS_INITIALIZE
                    UT.Status = Constant.STATUS_INITIALIZE;
                    UT.Content = "CONTESTANT DISCONNECTED BEFORE GET TEST";
                    bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                    if (!uhRes)
                    {
                        ClosingSocket();
                    }
                }
                else
                {
                    Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, Controllers.Instance.HandleStringErrorController(rEC));
                    Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                    Controllers.Instance.ExitApplicationFromNotificationForm(this);
                }
            }
            Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "MAIN | " + Properties.Resources.MSG_MESS_0010, Properties.Resources.MSG_MESS_0011);

            UT.Status = Constant.STATUS_NORMAL;
            if (ClientSocket != null)
            {
                ClientSocket.Dispose();
            }
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void flpnListOfQuestions_MouseEnter(object sender, EventArgs e)
        {
            flpnListOfButtonQuestions.Focus();
        }
    }
}
public struct ObjControl
{
    public List<Questions> Question;
    public int Width;
    public string Top;
    public int AnswerSheetID;

    public ObjControl(List<Questions> question, int answerSheetID, int width)
    {
        this.Question = question;
        this.Width = width;
        this.Top = string.Empty;
        this.AnswerSheetID = answerSheetID;
    }
    public ObjControl(string top, int width)
    {
        this.Question = null;
        this.Width = width;
        this.Top = top;
        this.AnswerSheetID = 0;
    }
}
