using BUS;
using DAO.DataProvider;
using EXONSYSTEM.Common;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXONSYSTEM.Layout
{
    public partial class frmAuthentication : MetroForm
    {
        private int loginCount = 3;
        private int LoginType = Constant.LOGIN_WITH_CONTESTANT_CODE;
        private Contest rC = null;
        ConfigApplication ca = new ConfigApplication();
        UserHelper.ClientSide ClientSocket;
        UserHelper.UserTransformation UT = new UserHelper.UserTransformation();
        public frmAuthentication()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        public delegate void SendInformationToMainForm(ContestantInformation CI, Contest C, UserHelper.ClientSide clientSocket, ConfigApplication ca);
        public void HandelInformationFromFrmConfig(ConfigApplication _ca)
        {
            this.ca = _ca;

        }
        private void frmAuthentication_Load(object sender, EventArgs e)
        {
           
            ErrorController rEC = new ErrorController();

          //  Encryption.Instance.DecryptConfigFile(Constant.PATH_CONFIG_FILE, Constant.PATH_CONFIG_FILE_TMP, out rEC);
            //if (rEC.ErrorCode == Constant.STATUS_OK)
            //{
                Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "AUTHENTICATION | frmAuthentication_Load | DecryptConfigFile", Controllers.Instance.HandleStringErrorController(rEC));
             //   Controllers.Instance.GetConfigFile(out ca, out rEC);
                if (ca != null /*&& rEC.ErrorCode == Constant.STATUS_OK*/)
            {
                    Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "AUTHENTICATION | frmAuthentication_Load | GetConfigFile", Controllers.Instance.HandleStringErrorController(rEC));
                    AppConfig app = new AppConfig();
                    //app.SaveConnectionString(app.AnalyzeConnectionString(ca), out rEC);
                    //if (rEC.ErrorCode == Constant.STATUS_OK)
                    {
                        //Encryption.Instance.EncryptConnectionString(out rEC);
                        //if (rEC.ErrorCode == Constant.STATUS_OK)
                        {
                            if (Controllers.Instance.HandleCheckConnection(ca.Supervisor.IP, ca.Supervisor.Port))
                            {
                                if (Controllers.Instance.HandleCheckDB(/*ca.DBName, ca.Database.IP, ca.Database.Port, ca.UsernameDB, ca.PasswordDB*/))
                                {
                                    ContestBUS.Instance.GetContestByShiftTime(Dns.GetHostName(), out rC, out rEC);
                                    if (rEC.ErrorCode == Constant.STATUS_OK)
                                    {
                                        this.Text = rC.ContestName.ToUpper();
                                        lbSubject.Font = lbShiftInfo.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Regular);
                                        lbSubject.Text = string.Format(Properties.Resources.MSG_GUI_0056, rC.Subject);
                                        lbShiftInfo.Text = string.Format(
                                            Properties.Resources.MSG_GUI_0057,
                                            Controllers.Instance.ConvertUnixToDateTime(rC.ShiftDate).ToString(Constant.FORMAT_DATE_DEFAULT),
                                            Controllers.Instance.ConvertUnixToDateTime(rC.StartTime).ToString(Constant.FORMAT_TIME_DEFAULT),
                                            Controllers.Instance.ConvertUnixToDateTime(rC.EndTime).ToString(Constant.FORMAT_TIME_DEFAULT)
                                        );
                                        lbSubject.Location = new Point((this.Width - lbSubject.Width) / 2, 0);
                                        lbShiftInfo.Location = new Point((this.Width - lbShiftInfo.Width) / 2, lbSubject.Bottom + 10);
                                        pnContestInfo.Width = this.Width;
                                        pnContestInfo.Height = lbShiftInfo.Bottom + 10;
                                        pnContestInfo.Location = new Point(0, 60);


                                        lbLine.BackColor = Constant.BACKCOLOR_PANEL_WRAPPER_CONTENT;
                                        lbLine.Height = 2;
                                        lbLine.Width = this.Width * 8 / 10;
                                        lbLine.Location = new Point((this.Width - lbLine.Width) / 2, pnContestInfo.Bottom);

                                        btnSubmit.ForeColor = Constant.FORCECOLOR_BUTTON_SUBMIT;
                                        btnSubmit.BackColor = Constant.BACKCOLOR_BUTTON_CONTROLLER;

                                        mrbtnIdentityCardName.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Bold);
                                        mrbtnContestantCode.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Bold);
                                        mrbtnStudentCode.Font = new Font(Constant.FONT_FAMILY_DEFAULT, Constant.FONT_SIZE_DEFAULT, FontStyle.Bold);
                                        mrbtnIdentityCardName.Text = HandleGetStringLoginType(Constant.LOGIN_WITH_IDENTITY_CARD_NAME).ToUpper();
                                        mrbtnContestantCode.Text = HandleGetStringLoginType(Constant.LOGIN_WITH_CONTESTANT_CODE).ToUpper();
                                        mrbtnStudentCode.Text = HandleGetStringLoginType(Constant.LOGIN_WITH_STUDENT_CODE).ToUpper();
                                        btnSubmit.Text = Properties.Resources.MSG_GUI_0016;

                                        mrbtnContestantCode.Location = new Point(0, 0);
                                        mrbtnStudentCode.Location = new Point(mrbtnContestantCode.Right, mrbtnContestantCode.Top);
                                        mrbtnIdentityCardName.Location = new Point(mrbtnStudentCode.Right, mrbtnContestantCode.Top);

                                        pAuthen.Width = mrbtnIdentityCardName.Right;
                                        pAuthen.Location = new Point((this.Width - pAuthen.Width) / 2, lbLine.Bottom + 20);

                                        txtUsername.Width = btnSubmit.Width = pAuthen.Width - 40;
                                        txtUsername.Left = btnSubmit.Left = 20;

                                        this.Height = pAuthen.Bottom + 10;
                                    }
                                    else
                                    {
                                        Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Controllers.Instance.HandleStringErrorController(rEC));
                                        Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_INFO, Controllers.Instance.HandleStringErrorController(rEC), this);
                                        Controllers.Instance.ExitApplicationFromNotificationForm(this);
                                    }
                                }
                                else
                                {
                                    Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Properties.Resources.MSG_GUI_0061);
                                    Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Properties.Resources.MSG_GUI_0061, this);
                                    Controllers.Instance.ExitApplicationFromNotificationForm(this);
                                }
                            }
                            else
                            {
                                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Properties.Resources.MSG_GUI_0060);
                                Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Properties.Resources.MSG_GUI_0060, this);
                                Controllers.Instance.ExitApplicationFromNotificationForm(this);
                            }
                        }
                        //else
                        //{
                        //    Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Controllers.Instance.HandleStringErrorController(rEC));
                        //    Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                        //    Controllers.Instance.ExitApplicationFromNotificationForm(this);
                        //}
                    }
                    //else
                    //{
                    //    Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Controllers.Instance.HandleStringErrorController(rEC));
                    //    Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                    //    Controllers.Instance.ExitApplicationFromNotificationForm(this);
                    //}
                }
                else
                {
                    Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_FATAL, Controllers.Instance.HandleStringErrorController(rEC));
                    Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Controllers.Instance.HandleStringErrorController(rEC), this);
                    Controllers.Instance.ExitApplicationFromNotificationForm(this);
                }
           // }

        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            HandleEnableControl(false);
            Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "AUTHENTICATION", Properties.Resources.MSG_MESS_0008);
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                Log.Instance.WriteLog(Properties.Resources.MSG_LOG_ERROR, "AUTHENTICATION", string.Format(Properties.Resources.MSG_MESS_0002, HandleGetStringLoginType(LoginType)));
                DialogResult dResult = MetroMessageBox.Show(this, string.Format(Properties.Resources.MSG_MESS_0002, HandleGetStringLoginType(LoginType)), Properties.Resources.MSG_MESS_0001, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                if (dResult.Equals(DialogResult.OK))
                {
                    HandleEnableControl(true);
                    txtUsername.Focus();
                }
            }
            else
            {
                UT.ComputerName = Dns.GetHostName();
                UT.UserCode = txtUsername.Text;
                if (ClientSocket == null)
                {
                    ClientSocket = new UserHelper.ClientSide(ca.Supervisor.Port, ca.Supervisor.IP);
                    ClientSocket.Status = true;
                    ClientSocket.Remote.NoConnected += Remote_NoConnected;
                }
                ContestantInformation rCI = null;
                ErrorController rEC = new ErrorController();

                ContestantBUS.Instance.Authen(rC, txtUsername.Text, Dns.GetHostName(), LoginType, out rCI, out rEC);
                if (rEC.ErrorCode == Constant.STATUS_OK)
                {
                    Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "AUTHENTICATION", Properties.Resources.MSG_MESS_0007);
                    #region Check Status
                    if (rCI.Status == Constant.STATUS_REJECT)
                    {
                        Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_INFO, Properties.Resources.MSG_GUI_0055, this);
                        if (DTO.NotificationForm.DialogResult == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    else if (rCI.Status == Constant.STATUS_INITIALIZE ||rCI.Status==Constant.STATUS_LOGIN_FAIL || rCI.Status==Constant.STATUS_READY_TO_GET_TEST)
                    {
                        // Trạng thái thi mới
                        Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "AUTHENTICATION | CHECK_STATUS | Authen | STATUS_INITIALIZE", Constant.STR_STATUS_INITIALIZE_CONTESTANT);

                        //Send message to supervisor LOGGED
                        UT.UserID = rCI.ContestantID;
                        UT.Status = Constant.STATUS_LOGGED;
                        UT.Content = "LOGIN SUCCESSFULLY";

                        // TODO
                           // Đổi trạng thái thí sinh sang LOGGED 3000
                            rCI.Status = Constant.STATUS_LOGGED;
                            //rCI.IsNewStarted = true;
                            //rCI.TimeStarted  = Controllers.Instance.ConvertDateTimeToUnix(DAO.DAO.ConvertDateTime.GetDateTimeServer());
                            ContestantBUS.Instance.ChangeStatusContestant(rCI, rC, out rEC);
                            if (rEC.ErrorCode == Constant.STATUS_OK)
                            {
                            bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                                if (!uhRes)
                                {
                                   ClosingSocket();
                               }
                               else
                               {
                                Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "AUTHENTICATION | CHANGE_STATUS_CONTESTANT_LOGIN | STATUS_LOGGED", Controllers.Instance.HandleStringErrorController(rEC));
                                SendInformationToMainForm sitm = new SendInformationToMainForm(DTO.MainForm.HandleInformationFromAuthenForm);
                                sitm(rCI, rC, ClientSocket, ca);
                                this.Hide();
                                DTO.MainForm.Show();
                                }
                              
                            }
                            else
                            {
                                Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, Controllers.Instance.HandleStringErrorController(rEC));
                            }
                      
                    }
                    else if (rCI.Status == Constant.STATUS_FINISHED)
                    {
                        // Trạng thái thi xong rồi
                        Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "AUTHENTICATION | CHECK_STATUS | Authen | STATUS_FINISHED", Constant.STR_STATUS_FINISHED);
                        // Send message to supervisor LOGGED WITH STATUS DOING
                        UT.UserID = rCI.ContestantID;
                        UT.Status = Constant.STATUS_FINISHED;
                        UT.Content = Constant.STR_STATUS_FINISHED;
                        bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                        if (!uhRes)
                        {
                            ClosingSocket();
                        }
                        else
                        {
                            Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_INFO, Constant.STR_STATUS_FINISHED, this);
                            if (DTO.NotificationForm.DialogResult == DialogResult.OK)
                            {
                                this.Close();
                            }
                        }
                    }
                    else if (rCI.Status == Constant.STATUS_DOING_BUT_INTERRUPT || rCI.Status==Constant.STATUS_DOING)
                    {
                        // Trạng thái đang thi nhưng bị gián đoạn
                        Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "AUTHENTICATION | CHECK_STATUS | Authen | STATUS_DOING_BUT_INTERRUPT", Constant.STR_STATUS_DOING_BUT_INTERRUPT);

                        rCI.Status = Constant.STATUS_LOGGED_DO_NOT_FINISH;
                        rCI.IsNewStarted = false;
                        ContestantBUS.Instance.ChangeStatusContestant(rCI, rC, out rEC);
                        if (rEC.ErrorCode == Constant.STATUS_OK)
                        {
                            Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "AUTHENTICATION | CHANGE_STATUS_CONTESTANT_LOGIN | STATUS_LOGGED_DO_NOT_FINISH", Controllers.Instance.HandleStringErrorController(rEC));
                            // Send message to supervisor LOGGED WITH STATUS DOING BUT INTERUPT
                            UT.UserID = rCI.ContestantID;
                            UT.Status = Constant.STATUS_LOGGED_DO_NOT_FINISH;
                            UT.Content = "LOGGED WITH STATUS DOING BUT INTERUPT SUCCESSFULLY";
                            bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                            if (!uhRes)
                            {
                                ClosingSocket();
                            }
                            else
                            {
                                SendInformationToMainForm sitm = new SendInformationToMainForm(DTO.MainForm.HandleInformationFromAuthenForm);
                                sitm(rCI, rC, ClientSocket, ca);
                                this.Hide();
                                DTO.MainForm.Show();
                            }
                        }
                        else
                        {
                            Log.Instance.WriteErrorLog(Properties.Resources.MSG_LOG_ERROR, Controllers.Instance.HandleStringErrorController(rEC));
                        }
                    }
                    else if (rCI.Status == Constant.STATUS_DOING || rCI.Status == Constant.STATUS_LOGGED_DO_NOT_FINISH || rCI.Status == Constant.STATUS_LOGGED)
                    {
                        // Trạng thái tài khoản đang được sử dụng
                        Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "AUTHENTICATION | CHECK_STATUS | Authen | STATUS_DOING||STATUS_LOGGED_DO_NOT_FINISH||STATUS_READY||STATUS_LOGGED", Constant.STR_STATUS_DOING);
                        // Send message to supervisor LOGGED WITH STATUS DOING
                        UT.UserID = rCI.ContestantID;
                        UT.Status = Constant.STATUS_DOING;
                        UT.Content = "CONTESTANT IS DOING";
                        bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                        if (!uhRes)
                        {
                            ClosingSocket();
                        }
                        else
                        {
                            Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_WARNING, Constant.STR_STATUS_DOING, this);
                            if (DTO.NotificationForm.DialogResult == DialogResult.OK)
                            {
                                this.Close();
                            }
                        }
                    }
                    else if (rCI.Status == Constant.STATUS_READY)
                    {
                        UT.UserID = rCI.ContestantID;
                        UT.Status = Constant.STATUS_READY;
                        UT.Content = "CONTESTANT READY";
                        bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                        if (!uhRes)
                        {
                            ClosingSocket();
                        }
                        else
                        {
                            SendInformationToMainForm sitm = new SendInformationToMainForm(DTO.MainForm.HandleInformationFromAuthenForm);
                            sitm(rCI, rC, ClientSocket, ca);
                            this.Hide();
                            DTO.MainForm.Show();
                        }

                    }
                    else
                    {
                        DialogResult dEResult = MetroMessageBox.Show(this, "Thí sinh chưa xác thực!", Properties.Resources.MSG_MESS_0001, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                        if (dEResult.Equals(DialogResult.OK))
                        {
                            this.Close();
                        }
                    }
                    #endregion
                }
               
                else
                {
                    //UT.Status = Constant.STATUS_LOGIN_FAIL;
                    //UT.Content = "LOGIN FAIL";
                    //bool uhRes = ClientSocket.Remote.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                    //if (!uhRes)
                    //{
                    //    ClosingSocket();
                    //}
                    //else
                    //{
                        Log.Instance.WriteLog(Properties.Resources.MSG_LOG_WARN, "AUTHENTICATION | LOGIN FAIL", string.Format("{0}: {1}", string.Format(Properties.Resources.MSG_GUI_0044, HandleGetStringLoginType(LoginType)), txtUsername.Text));
                        if (loginCount == 0)
                        {
                            DialogResult dEResult = MetroMessageBox.Show(this, Properties.Resources.MSG_GUI_0035, Properties.Resources.MSG_MESS_0001, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                            if (dEResult.Equals(DialogResult.OK))
                            {
                                this.Close();
                            }
                        }
                        else
                        {
                            DialogResult dResult = MetroMessageBox.Show(this, rEC.ErrorCode == Constant.STATUS_WRONG_COMPUTTER ? Properties.Resources.MSG_GUI_0052 : string.Format(Properties.Resources.MSG_GUI_0044, HandleGetStringLoginType(LoginType)), Properties.Resources.MSG_MESS_0001, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
                            if (dResult.Equals(DialogResult.OK))
                            {
                                HandleEnableControl(true);
                                loginCount--;
                                txtUsername.Focus();
                                Log.Instance.WriteLog(Properties.Resources.MSG_LOG_ERROR, "AUTHENTICATION | LOGINFAIL", string.Format(Properties.Resources.MSG_MESS_0037, 3 - loginCount));
                            }
                        }
                    //}
                }
            }
            Log.Instance.WriteLog(Properties.Resources.MSG_LOG_INFO, "AUTHENTICATION", Properties.Resources.MSG_MESS_0009);
        }
        private void MetroRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            MetroRadioButton mrb = sender as MetroRadioButton;
            switch (mrb.Name)
            {
                case "mrbtnContestantCode":
                    LoginType = Constant.LOGIN_WITH_CONTESTANT_CODE;
                    break;
                case "mrbtnIdentityCardName":
                    LoginType = Constant.LOGIN_WITH_IDENTITY_CARD_NAME;
                    break;
                case "mrbtnStudentCode":
                    LoginType = Constant.LOGIN_WITH_STUDENT_CODE;
                    break;
            }
            txtUsername.Clear();
            txtUsername.Focus();
        }
        private string HandleGetStringLoginType(int loginType)
        {
            switch (loginType)
            {
                // LOGIN_WITH_CONTESTANT_CODE
                case 5000:
                    return Properties.Resources.MSG_GUI_0041;
                // LOGIN_WITH_STUDENT_CODE
                case 5001:
                    return Properties.Resources.MSG_GUI_0042;
                // LOGIN_WITH_IDENTITY_CARD_NAME
                case 5002:
                    return Properties.Resources.MSG_GUI_0043;
                default:
                    return string.Empty;
            }
        }
        private void HandleEnableControl(bool flag)
        {
            mrbtnContestantCode.Enabled = mrbtnIdentityCardName.Enabled = mrbtnStudentCode.Enabled = flag;
            pAuthen.Enabled = flag;
        }
        private void Remote_NoConnected(object sender, object data)
        {
            if (UT.Status != Constant.STATUS_NORMAL)
            {
                ClientSocket.Connect();
            }
        }
        private void ClosingSocket()
        {
            Controllers.Instance.ShowNotificationForm(Constant.TYPE_NOTIFICATION_INFO, Properties.Resources.MSG_CON_0002, this);
            if (DTO.NotificationForm.DialogResult == DialogResult.OK)
            {
                this.Close();
                Application.Exit();
            }
        }
        private void frmAuthentication_FormClosing(object sender, FormClosingEventArgs e)
        {
            UT.Status = Constant.STATUS_NORMAL;
            if (ClientSocket != null)
            {
                ClientSocket.Dispose();
            }
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {

        }
    }
}
