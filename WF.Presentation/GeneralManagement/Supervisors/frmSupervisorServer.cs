using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CL.Persistance;
using CL.Services;
using GeneralManagement.Common;

using UserHelper;
using System.Net;
using GeneralManagement.Supports;
using System.Collections;
using System.Diagnostics;
using CL.Services.Interface;
using CL.Services.Impl;
using MetroFramework.Forms;
using GeneralManagement.Bus;
using MetroFramework.Controls;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using RM;
using MetroFramework;

namespace GeneralManagement.Supervisors
{
    public partial class frmSupervisorServer : MetroForm
    {
        #region Khai báo biến

        bool CheckedContestant = true;
        // thời gian đăng nhập có thể trước trong khoảng  15' hoặc 30' là hiện danh sách của ca thi ngay sau thời gian đó
        // có thể 
        private const int DIF_TIME = 3600;
        bool sessionCheck = false;
        bool isDecrypt = false;
        // thời gian click button bắt đầu trước thời gian bắt đầu ca thi khoảng 5'
        private const int DIF_START_TIME = 3000;
      
        UserHelper.ServerSide serverSocket;
        string IP;
        int[] indexPage = new int[10];
        int[] ListShiftID = new int[10];
        int[] ListDivisionShiftID = new int[10];
        public delegate void SendWorking(bool isprogress);
        SendWorking s;
       
        int countBtnDivisionTest = 0;
        class UserGet
        {
            public UserGet() { }
            public string UserCode { get; set; }
            public int status { get; set; }
        }
        List<UserGet> lstUserGet = new List<UserGet>();
      
        int StatusDivisionShift;
       
        int supervisorID;
        int shiftID = 0;
        int roomTestID = 0;
        int divisionShiftID = 0;
        bool isStartServer = false;
        bool isCheckDivisionTest = false; // trạng thái phát đề hay chưa
        bool isCheckStartTest = false; // trạng thái bắt đầu thi hay chưa
                                       //int count3002 = 0; //đếm trạng thái nhận xong đề thi
                                       //int count3003 = 0; //đếm trạng thái đang làm bài thi
        bool CheckDivisionTest = false;


        bool isCheckArr = false; 
        List<ROOMDIAGRAM> lstRoomdiagram = new List<ROOMDIAGRAM>();
      
        ROOMTEST room = new ROOMTEST();
        SHIFT shift = new SHIFT();
      
        int ctID;
        Hashtable hashStatusLogin = new Hashtable(); // lưu trạng thái login của thí sinh tương ứng với 

        List<ContestantInformation> lstCIConnected = new List<ContestantInformation>();
        int countDivisionShift = 0;
        // int test = 0;
        int index = 0;
        private RM.GetFinger.frmIdentifyFinger _frmIdentifyFinger;
        
        private int IsInitDevice = -1;

        #endregion

        public frmSupervisorServer()
        {

            InitializeComponent();
          

            if (AppSession.StaffID > 0)
            {
                supervisorID = AppSession.StaffID;
                setFullScreen();
                STAFF staff = BusALL.Instance.GetStaff(supervisorID);
                lblSupervisorName.Text = "Giám Sát: " + staff.FullName;
                StatusDivisionShift = BusALL.Instance.GetStatusDivisionShift(divisionShiftID);
                GetInfoShift();
                // LoadListContestant();
                LoadTOV();

                //LoadComputer();
                EnableButton(StatusDivisionShift);
            }
        }

        private void ArrangeContestant()
        {
            txtMessageBox.Clear();
            int count_error = 0;

            List<int> listContestantShiftID = BusALL.Instance.ListContestantShiftID(divisionShiftID);
            List<int> listRoomDiaID = BusALL.Instance.ListRoomDiaID(roomTestID);

            if (listContestantShiftID.Count <= listRoomDiaID.Count)
            {
                Hashtable hasData = new Hashtable();
                ArrangeForContestant(listContestantShiftID, listRoomDiaID, out hasData);

                #region tiến hành xếp chỗ
                foreach (DictionaryEntry entry in hasData)
                {
                    CONTESTANTS_SHIFTS contestantShift = new CONTESTANTS_SHIFTS();
                    contestantShift = BusALL.Instance.GetContestantShift(Convert.ToInt32(entry.Key));
                    contestantShift.RoomDiagramID = Convert.ToInt32(entry.Value);
                    ROOMDIAGRAM roomDia = new ROOMDIAGRAM();
                    roomDia = BusALL.Instance.GetRoomDiaByID(Convert.ToInt32(entry.Value));
                    //????? contestantShift.ClientIP = roomDia.ClientIP;

                    if (!BusALL.Instance.UpdateContestantShift(contestantShift))
                    {
                        count_error++;
                        break;
                    }
                }
                if (count_error != 0)
                {
                    txtMessageBox.Text = string.Format("Xếp chỗ bị sai {0}  vị trí. Xếp lại", (listContestantShiftID.Count - listRoomDiaID.Count));
                }
                else
                {
                    lsbTrace.Items.Add(string.Format(" Xếp chỗ thành công"));
                    lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;


                  
                    mbtnAttendance.Enabled = true;
            
                   BusALL.Instance.UpdateStatusDivisionShift(divisionShiftID, UserHelper.Common.STATUS_ARR);

                }
                #endregion
            }
            else
            {
                txtMessageBox.Text = string.Format("Không đủ chỗ để xếp. Thiếu {0} chỗ để xếp được, Bổ xung hoặc chuyển ca", count_error);
                lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;
            }

        }

        public void HandelInfo(DivisionShift ds)
        {

            for (int i = 0; i < ListDivisionShiftID.Count(); i++)
            {
                if (ds.DivisionShiftID == ListDivisionShiftID[i])
                {
                    tabControl1.SelectedIndex = i;
                    return;
                }
            }

            ListDivisionShiftID[countDivisionShift] = ds.DivisionShiftID;

            ListShiftID[countDivisionShift] = ds.ShiftID;
            this.shiftID = ds.ShiftID;
            this.divisionShiftID = ds.DivisionShiftID;
            countDivisionShift++;
            DIVISION_SHIFTS divisionShift = BusALL.Instance.GetDivisionShiftByID(divisionShiftID);
            //  roomTestID = divisionShift.RoomTestID;
            if (divisionShift != null)
            {
                roomTestID = Convert.ToInt32(divisionShift.RoomTestID);
            }
            StatusDivisionShift = BusALL.Instance.GetStatusDivisionShift(divisionShiftID);
            if (StatusDivisionShift == 1)
            {
                ArrangeContestant();
            }
            handelPannelDiagram();

        }
        public void handelPannelDiagram()
        {


            MetroTabPage tabroom = new MetroTabPage();
            indexPage[index] = index++;
            ///CheckBox cboRoom = new CheckBox();

            DIVISION_SHIFTS divisionShift = BusALL.Instance.GetDivisionShiftByID(divisionShiftID);
            tabroom.Name = divisionShift.RoomTestID.ToString();

            tabroom.Text = "Phòng: " + divisionShift.ROOMTEST.RoomTestName;
            
           
            tabControl1.TabPages.Add(tabroom);
            Panel pnl = new Panel();
            pnl.Name = "pnlDiagram" + index;
            tabroom.Controls.Add(pnl);
            
            pnl.AutoScroll = true;
            pnl.Dock = DockStyle.Fill;
            //pnlRoom.Controls.Add(cboRoom);         
            LoadComputer1(pnl);

        }
        private void EnableButton(int _status)
        {
            if (_status == UserHelper.Common.STATUS_ARR)
            {
                mbtnAttendance.Enabled = true;
                mbtnDecry.Enabled = false;
                mbtnAuthen.Enabled = false;
                mbtnDivsionTest.Enabled = false;
                mbtnStartTest.Enabled = false;
            }
            else if (_status == UserHelper.Common.STATUS_ATTENDANCE)
            {
                if(sessionCheck)
                    mbtnAttendance.Enabled = false;
                else mbtnAttendance.Enabled = true;
                mbtnAuthen.Enabled = true;
                mbtnDecry.Enabled = false;
                mbtnDivsionTest.Enabled = false;
                mbtnStartTest.Enabled = false;
            }
            else if (_status == UserHelper.Common.STATUS_VERITY)
            {
                mbtnAttendance.Enabled = true;
                if (!isStartServer) mbtnAuthen.Enabled = true;
                else mbtnAuthen.Enabled = false;
                mbtnDecry.Enabled = true;
                isDecrypt = false;
                mbtnDivsionTest.Enabled = false;
                mbtnStartTest.Enabled = false;
            }
            else if (_status == UserHelper.Common.STATUS_DECRYPT)
            {
               if(!isStartServer) mbtnAuthen.Enabled = true;
                else mbtnAuthen.Enabled = false;
                mbtnAttendance.Enabled = true;  
                mbtnDecry.Enabled = false;
                isDecrypt = true;
                //mbtnDivsionTest.Enabled = true;
                mbtnStartTest.Enabled = false;
            }
            else if (_status == UserHelper.Common.STATUS_DIVISIONTEST)
            {
                if (!isStartServer) mbtnAuthen.Enabled = true;
                else mbtnAuthen.Enabled = false;
                mbtnAttendance.Enabled = true;
                isDecrypt = true;
                mbtnDecry.Enabled = false;
                mbtnStartTest.Enabled = true;
                mbtnDivsionTest.Enabled = false;            
            }
            else if (_status == UserHelper.Common.STATUS_STARTTEST)
            {
                if (!isStartServer) mbtnAuthen.Enabled = true;
                else mbtnAuthen.Enabled = false;
                mbtnAttendance.Enabled = true;
                mbtnDecry.Enabled = false;
                isDecrypt = true;
                mbtnDivsionTest.Enabled = false;
                mbtnStartTest.Enabled = false;
            }
            else
            {
                mbtnAttendance.Enabled = true;
                mbtnDecry.Enabled = false;
                mbtnAuthen.Enabled = false;
                mbtnDivsionTest.Enabled = false;
                mbtnStartTest.Enabled = false;
            }

        }
        private void LoadViolation(int _contestantShiftID)
        {
            foreach (TabPage tabpage in tabControl1.TabPages)
            {
                foreach (var item in tabpage.Controls)
                {
                    if (item is Panel)
                    {
                        Panel pnl = (Panel)item;
                        foreach (ucComputer i in pnl.Controls)
                        {

                            if (i.contestanshifttid == _contestantShiftID)
                            {
                                i.CountViolation();
                                // i.LoadStatusContestan();
                            }
                        }

                    }
                }
            }
        }

        delegate bool SetCheckUserIDCallback(int id);
        private bool SetCheckUserID(int id)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.tabControl1.InvokeRequired)
            {
                SetCheckUserIDCallback d = new SetCheckUserIDCallback(SetCheckUserID);
                this.Invoke(d, new object[] {id});
                return true;
            }
            else
            {
                foreach (var item in tabControl1.SelectedTab.Controls)
                {
                    if (item is Panel)
                    {
                        Panel pnl = (Panel)item;
                        foreach (ucComputer i in pnl.Controls)
                        {
                            if (i.contestantid == id)
                                return true;
                        }
                    }
                }
                return false;

            }
        }
        bool CheckUserID(int id)
        {
            foreach (var item in tabControl1.SelectedTab.Controls)
            {
                if (item is Panel)
                {
                    Panel pnl = (Panel)item;
                    foreach (ucComputer i in pnl.Controls)
                    {
                        if (i.contestantid == id && i.status==UserHelper.Common.STATUS_READY_TO_GET_TEST)
                            return true;
                    }
                }
            }
            return false;
        }
        bool CheckUserIDForStartTest(int id)
        {
            foreach (var item in tabControl1.SelectedTab.Controls)
            {
                if (item is Panel)
                {
                    Panel pnl = (Panel)item;
                    foreach (ucComputer i in pnl.Controls)
                    {
                        if (i.contestantid == id && i.status == UserHelper.Common.STATUS_READY)
                            return true;
                    }
                }
            }
            return false;
        }

        #region hỗ trợ xếp chỗ
        static void ArrangeForContestant(List<int> lstContestantShiftID, List<int> lstRoomDiaID, out Hashtable htbTestData)
        {
            List<int> lstTest = lstRoomDiaID;
            Hashtable htbReturnData = new Hashtable();
            Random rnd = new Random();
            foreach (int contestantShiftID in lstContestantShiftID.ToList())
            {
                int rndvalue = rnd.Next(lstRoomDiaID.Count);
                htbReturnData.Add(contestantShiftID, lstRoomDiaID[rndvalue]);
                lstRoomDiaID.RemoveAt(rndvalue);
            }
            htbTestData = htbReturnData;
        }
        #endregion  

        #region hỗ trợ phát đề
        static void GenerateTestForContestant(List<int> lstContestantShiftID, List<int> lstTestID, out Hashtable htbTestData)
        {
            List<int> lstTest = lstTestID;
            Hashtable htbReturnData = new Hashtable();
            Random rnd = new Random();
            foreach (int contestantShiftID in lstContestantShiftID.ToList())
            {
                int rndvalue = rnd.Next(lstTestID.Count);
                htbReturnData.Add(contestantShiftID, lstTestID[rndvalue]);
                lstTestID.RemoveAt(rndvalue);
            }
            htbTestData = htbReturnData;
        }
        #endregion

        #region set full screen

        public void setFullScreen()
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.WindowState = FormWindowState.Normal;
          
            //this.TopMost = true;
        }
        #endregion



        #region Các hàm load combobox máy có thể chuyển đến, load loại vi phạm
        private void LoadCmbComputerChange()
        {
            cmbComName.Text = "";
            List<ROOMDIAGRAM> listRoomDia = BusALL.Instance.GetListComCanChange(divisionShiftID, roomTestID);
            if (listRoomDia.Count > 0)
            {
                cmbComName.DataSource = listRoomDia;
                cmbComName.DisplayMember = "ComputerName";
                cmbComName.ValueMember = "RoomDiagramID";

                cmbComName.SelectedIndex = -1;
            }
            else
            {
                cmbComName.DataSource = null;
                cmbComName.Text = "Không có máy nào có thể chuyển đến";
            }
        }

        // Lấy danh sách loại vi phạm
        private void LoadTOV()
        {
            List<VIOLATION> listTOV = BusALL.Instance.GetListViolation();

            if (listTOV.Count > 0)
            {
                cmbTOV.DataSource = listTOV;
                cmbTOV.DisplayMember = "ViolationName";
                cmbTOV.ValueMember = "ViolationID";
                cmbTOV.Text = "Chọn loại vi phạm";
                cmbTOV.SelectedIndex = -1;
            }
            else
            {
                cmbTOV.Text = "Chọn loại vi phạm";
            }
        }
        #endregion

        void LoadComputer1(Panel pnl)
        {

            Point newP = new Point(15, 10);

            lstRoomdiagram = BusALL.Instance.GetListRoomdiagram(roomTestID);

            for (int i = 0; i < lstRoomdiagram.Count; i++)
            {
                ucComputer uccomputer = new ucComputer(lstRoomdiagram[i], BusALL.Instance.GetDivisionShift(shiftID, roomTestID).DivisionShiftID);
                if (i % 6 == 0 && i != 0)
                {
                    //newP = uccomputer.Location;
                    newP.X = 15;
                    newP.Y += uccomputer.Height + 20;
                }
                else if (i != 0)
                {
                    newP.X += uccomputer.Width + 10;

                }

                uccomputer.Location = newP;
                uccomputer.Name = lstRoomdiagram[i].ComputerName;
                if(StatusDivisionShift >= UserHelper.Common.STATUS_ATTENDANCE)
                {
                    uccomputer.DisablecbCheckFP();
                }
                uccomputer.ImageClick += new EventHandler(UserControl_ButtonClick);
                uccomputer.RightClick += new EventHandler(Uccomputer_RightClick);
                pnl.Controls.Add(uccomputer);
            }

        }

       
        // Lấy thông tin ca thi
        private void GetInfoShift()
        {
            shift = BusALL.Instance.GetShift(shiftID);

            if (shift != null)
            {
                if (shift.ShiftName != null)
                {
                    lblShiftName.Text = "Ca:" + shift.ShiftName;
                    lblDate.Text = "Ngày:" + DatetimeConvert.ConvertUnixToDateTime(shift.ShiftDate).Date.ToShortDateString();
                    lblStartTime.Text = "Thời gian bắt đầu: " + DatetimeConvert.ConvertUnixToDateTime(shift.StartTime).ToString("HH: mm:ss");
                    lblEndTime.Text = "Thời gian Kết thúc: " + DatetimeConvert.ConvertUnixToDateTime(shift.EndTime).ToString("HH: mm:ss");
                    lblContestName.Text = "Kỳ thi: " + shift.CONTEST.ContestName;

                    DIVISION_SHIFTS divisionShift = BusALL.Instance.GetDivisionShiftByID(divisionShiftID);
                    //  roomTestID = divisionShift.RoomTestID;
                    if (divisionShift != null)
                    {

                        room = BusALL.Instance.GetRoom(Convert.ToInt32(divisionShift.RoomTestID));
                        roomTestID = Convert.ToInt32(divisionShift.RoomTestID);
                        if (room != null)
                        {
                            lblRoomName.Text = "Phòng:" + room.RoomTestName;

                            roomTestID = room.RoomTestID;
                        }
                    }
                    else
                    {
                        lblRoomName.BackColor = Color.Red;
                        lblRoomName.Text += "Chưa phân phòng, Lỗi";
                    }
                }
                else
                {
                    lblShiftName.Text = "Mã ca: " + shift.ShiftID;
                }
            }



        }

        private void LoadUCComputer(int id)
        {
            if (id != -1)
            {
                foreach (TabPage tabpage in tabControl1.TabPages)
                {
                    foreach (var item in tabpage.Controls)
                    {
                        if (item is Panel)
                        {
                            Panel pnl = (Panel)item;
                            foreach (ucComputer i in pnl.Controls)
                            {

                                if (i.contestantid == id)
                                {
                                    i.LoadInfoContestant();
                                    return;
                                }
                            }

                        }
                    }
                }
            }
            else
            {
               // Bus.BusALL.Instance.UpdateCheckFingerFasle();
            }
        }

        private void frmSupervisorServer_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            supervisorID = AppSession.StaffID;
            setFullScreen();
            STAFF staff = BusALL.Instance.GetStaff(supervisorID);
            lblSupervisorName.Text = "Giám sát: " + staff.FullName;
            StatusDivisionShift = BusALL.Instance.GetStatusDivisionShift(divisionShiftID);
            GetInfoShift();
            LoadTOV();

            //  LoadCmbComputerChange();
            tabControl1.SelectedIndex = countDivisionShift - 1;
            EnableButton(StatusDivisionShift);

        }

       private void serverSocket_ClientConnected(object sender, object data)
        {
            var client = data as SocketController;
            IPEndPoint remote = (IPEndPoint)client.Sock.RemoteEndPoint;
            //SetText(remote.Address.ToString() + ":" + remote.Port.ToString() + " vừa kết nối...\n");
            //lstbTraceLog.SelectedIndex = lstbTraceLog.Items.Count - 1;
            client.Receive +=client_Receive;  

        }
       private delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lsbTrace.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lsbTrace.Items.Add(text);
                lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;

            }
        }
        void serverSocket_ClientDisconnected(object sender, object data)
        {
            var client = data as SocketController;
            IPEndPoint remote = (IPEndPoint)client.Sock.RemoteEndPoint;
            int index = GetIndexClientFromList(client);
            #region mat ket noi, kiêm tra neu là mat chu dong thi nó gui len 3004 mình cạp nhat trạng thái
            // và ko pahir cập nhật thời gian đã làm bài được
            if (index > -1)
            {
                ContestantInformation CI = lstCIConnected[index];
                CONTESTANTS_SHIFTS contestantShift = new CONTESTANTS_SHIFTS();
                CONTESTANT contestant = new CONTESTANT();
                contestantShift = BusALL.Instance.GetContestantShift(divisionShiftID, client.UserID);
                if (contestantShift != null)
                {
                    contestant = BusALL.Instance.GetInfoContestant(contestantShift.ContestantID);
                    //contestantShift.Status = UserHelper.Common.STATUS_DOING_BUT_INTERRUPT;
                }
                #region kiểm tra xem mất kết nối có chủ đích hay không. nếu ko ta cập nhật lại trạng thái và thời gian mất kết nối
                if (CI.UserTransfer.Status == UserHelper.Common.STATUS_DOING_BUT_INTERRUPT)
                {
                    SetText(string.Format("Tự tắt chương trình. Vui lòng kiểm tra máy thi này [{0}]", CI.UserTransfer.ComputerName));
                    isCheckArr = true;
                }
                else
                {
                    if (CI.UserTransfer.Status != UserHelper.Common.STATUS_FINISHED)
                    {
                        if (contestantShift != null && contestant != null)
                        {


                            ///////// note
                            DateTime timeDisconnect = Common.DatetimeConvert.GetDateTimeServer();
                            //int timeWorked = DatetimeConvert.ConvertDateTimeToUnix(timeDisconnect) - Convert.ToInt32(contestantShift.TimeStarted);
                            //contestantShift.TimeWorked += timeWorked;
                            contestantShift.Status = CI.UserTransfer.Status;
                            if (BusALL.Instance.UpdateContestantShift(contestantShift))
                            {
                                SetText(string.Format("Thí sinh [{0}] mất kết nối lúc : [{1}]",  contestant.FullName, timeDisconnect.ToString("HH: mm:ss")));
                                SetupdateUC(client.UserID);
                            }
                            else
                            {
                                SetText(string.Format("Cập nhật trạng thái ngắt kết nối cho thí sinh [{0}]-[{1}] tại [{2}] THẤT BẠI", contestant.ContestantCode, contestant.FullName, timeDisconnect.ToString("HH: mm:ss")));
                            }

                        }
                    }  
                }
                lstCIConnected.RemoveAt(GetIndexClientFromList(client));
                serverSocket.ClientList.Remove(client);
                // UpdateUCStatus(client.UserID);
              
                 #endregion
            }
         
            client.Dispose();
            #endregion
        }

        #region Nhan tin hieu tu client
        void client_Receive(object sender, object data)
          {

            var client = (SocketController)sender;
            UserTransformation Recieve = new UserTransformation();
            Recieve = Ultis.FromJSONToObject((string)data);
            client.UserID = Recieve.UserID;
            AddToView(Recieve);
            CONTESTANT contestant = new CONTESTANT();
            contestant= BusALL.Instance.GetContestantByCode(Recieve.UserCode);
            #region Change UserTransformation from client
            if (Recieve.Status != UserHelper.Common.STATUS_LOGGED || Recieve.Status != UserHelper.Common.STATUS_LOGGED_DO_NOT_FINISH || Recieve.Status == UserHelper.Common.STATUS_READY)
            {
                IPEndPoint remote = (IPEndPoint)client.Sock.RemoteEndPoint;
                foreach (ContestantInformation CI in lstCIConnected)
                {
                    if (CI.IPPORT == string.Format("{0}:{1}", remote.Address, remote.Port))
                    {
                        if (Recieve.Status == UserHelper.Common.STATUS_LOGIN_FAIL)
                        {
                            CI.LoginError++;
                        }
                        CI.UserTransfer = Recieve;

                    }
                }
                if (Recieve.Status == UserHelper.Common.STATUS_READY_TO_GET_TEST)
                {
                    HandleEnableDivisionTest();
                }
               
                if (Recieve.Status == UserHelper.Common.STATUS_READY)
                {
                    HandleEnableStartTest();
                }
            }
            #endregion

            #region nếu là trạng thái đăng nhập hoặc đăng nhập lại
            if (Recieve.Status == UserHelper.Common.STATUS_LOGGED || Recieve.Status == UserHelper.Common.STATUS_LOGGED_DO_NOT_FINISH || Recieve.Status == UserHelper.Common.STATUS_READY)
            {
                ContestantInformation CI = new ContestantInformation();
                CI.IPPORT = string.Format("{0}:{1}", client.IPERemote.Address, client.IPERemote.Port);
                CI.LoginStatus = Recieve.Status;
                CI.UserTransfer = Recieve;
                lstCIConnected.Add(CI); 
                //if (contestant != null)
                //{
                //    foreach (int item in ListDivisionShiftID)
                //    {
                //        CONTESTANTS_SHIFTS contestantShift = BusALL.Instance.GetContestantShift(item, contestant.ContestantID);
                //        if (contestantShift != null)
                //        {
                //            contestantShift.Status = Recieve.Status;
                //           HandleUpdateStatusContestantShift(contestantShift);
                //            break;
                //        }

                //    }

                //}
            }
            #endregion
            #region với trạng thái ko phải đăng nhập
            else
            {
                if (Recieve.Status == UserHelper.Common.STATUS_REPORT_ERROR)
                         {
                    
                          if (contestant != null)
                          {
                         foreach (int item in ListDivisionShiftID)
                                 {
                                   CONTESTANTS_SHIFTS contestantShift;

                                    contestantShift = new CONTESTANTS_SHIFTS();
                                    contestantShift = BusALL.Instance.GetContestantShift(item, contestant.ContestantID);
                                   if (contestantShift != null)
                                    {
                                     // MessageBox.Show("Thí sinh"+ contestant2.FullName +" thông báo lỗi tại vị trí "  + contestantShift.ROOMDIAGRAM.ComputerName,"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                       MetroMessageBox.Show(this, "Thí sinh" + contestant.FullName + " thông báo lỗi tại vị trí " + contestantShift.ROOMDIAGRAM.ComputerName,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1,150);
                                       break;
                                     }
                                 }
                              }
                           }
                    if (Recieve.Status != UserHelper.Common.STATUS_LOGIN_FAIL || Recieve.Status != UserHelper.Common.STATUS_READY)
                    {               
                        if (contestant != null)
                        {

                            foreach (int item in ListDivisionShiftID)
                            {
                                CONTESTANTS_SHIFTS contestantShift;

                                contestantShift = new CONTESTANTS_SHIFTS();
                                contestantShift = BusALL.Instance.GetContestantShift(item, contestant.ContestantID);
                                //if (contestantShift != null)
                                //{
                                //    if ((contestantShift.Status != 4001 || contestantShift.IsCheckFingerprint != 0) && Recieve.Status == UserHelper.Common.STATUS_LOGIN_FAIL)
                                //    {
                                //    }
                                //    else
                                //    {
                                //        contestantShift.Status = Recieve.Status;
                                //     HandleUpdateStatusContestantShift(contestantShift);
                                //    break;
                                //    }
                                //}

                            }   
                    }
                }
                #endregion
                
           
            }
            SetupdateUC(Recieve.UserID);
        }
        delegate void SetUpdateUCCallback(int id);
        private void SetupdateUC(int id)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.tabControl1.InvokeRequired)
            {
                SetUpdateUCCallback d = new SetUpdateUCCallback(SetupdateUC);
                this.Invoke(d, new object[] { id });
                
            }
            else
            {
                foreach (TabPage tabpage in tabControl1.TabPages)
                {
                    foreach (var item in tabpage.Controls)
                    {
                        if (item is Panel)
                        {
                            Panel pnl = (Panel)item;
                            foreach (ucComputer i in pnl.Controls)
                            {

                                if (i.contestantid == id)
                                {
                                    i.LoadStatusContestan();
                                    return;
                                }
                            }

                        }
                    }
                }

            }
        }
        private void UpdateUCStatus(int id)
        {
            foreach (TabPage tabpage in tabControl1.TabPages)
            {
                foreach (var item in tabpage.Controls)
                {
                    if (item is Panel)
                    {
                        Panel pnl = (Panel)item;
                        foreach (ucComputer i in pnl.Controls)
                        {

                            if (i.contestantid == id)
                            {                             
                                i.LoadStatusContestan();
                                return;
                            }
                        }

                    }
                }
            }
        }

        #endregion

         private void cmbComName_Click(object sender, EventArgs e)
        {
            LoadCmbComputerChange();
        }
  

        #region xu ly update Status cho thi sinh, cap nhap button
        private void HandleUpdateStatusContestantShift(CONTESTANTS_SHIFTS ic)
        {
            try
            {
                if (ic != null)
                {
                    if (BusALL.Instance.UpdateContestantShift(ic))
                    {
                        SetText(string.Format("Cập nhật trạng thái cho thí sinh [{0}] [{1}] thành công. ", ic.CONTESTANT.FullName, ic.Status));
                    }
                    else
                    {
                        //if(ic.CONTESTANT.FullName!=null)
                        //lstbTraceLog.Items.Add(string.Format("Cập nhật trạng thái cho thí sinh ["+ ic.CONTESTANT.FullName+"] thất bại" ));
                    }
                }
                //lstbTraceLog.SelectedIndex = lstbTraceLog.Items.Count - 1;

            }
            catch (Exception ex)
            {

            }
        }
   

        private int GetIndexClientFromList(SocketController sc)
        {
            IPEndPoint remote = (IPEndPoint)sc.Sock.RemoteEndPoint;
            int index = lstCIConnected.FindIndex(x => x.IPPORT == string.Format("{0}:{1}", remote.Address, remote.Port));
            return index;
        }

        delegate void SetbtnCallback(bool enable,int detail);
        private void Setbtn(bool enable, int detail)
        {           
            if (this.mbtnStartTest.InvokeRequired || mbtnDivsionTest.InvokeRequired)
            {
                SetbtnCallback d = new SetbtnCallback(Setbtn);
                this.Invoke(d, new object[] { enable ,detail});
            }
            else
            {
                if (detail == 1) mbtnStartTest.Enabled = enable;
                else
                {
                    if (enable && isDecrypt) mbtnDivsionTest.Enabled = true;
                }
               
            }
        }
        private void HandleEnableDivisionTest()
        {
           bool isEnable = false;
            if (lstCIConnected.Count > 0)
            {
                foreach (ContestantInformation CI in lstCIConnected)
                {
                    if (CI.UserTransfer.Status == UserHelper.Common.STATUS_READY_TO_GET_TEST)
                    {
                        isEnable = true;
                        CheckDivisionTest = true;
                        break;
                    }
                }
            }
            else
            {
                CheckDivisionTest = false;
               isEnable = false;
            }            
            Setbtn(isEnable, 0);       
        }

        private void HandleEnableStartTest()
        {
            bool isEnable = false;
            if (lstCIConnected.Count > 0)
            {
                foreach (ContestantInformation CI in lstCIConnected)
                {
                    if (SetCheckUserID(CI.UserTransfer.UserID))
                    {
                        if (CI.UserTransfer.Status == UserHelper.Common.STATUS_READY)
                        {
                            isEnable = true;
                            break;
                        }
                    }

                }
            }
            else
            {
                isEnable = false;
            }
            Setbtn(isEnable, 1);
          //  mbtnStartTest.Enabled = isEnable;
        }

        // Add mesage to view
        private void AddToView(UserTransformation UT)
        {
            SetText(string.Format("[{0}][{1}]:[{2}]- [{3}]", UT.UserCode, UT.ComputerName, UT.Status, UT.Content));
            //           lstbTraceLog.SelectedIndex = lstbTraceLog.Items.Count - 1;
        }

        #endregion
        // click vao UC
        protected void UserControl_ButtonClick(object sender, EventArgs e)
        {
            //handle the event 
            ucComputer uc = (ucComputer)sender;
            txtMessageBox.Clear();
            try
            {
                CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
                cs = BusALL.Instance.GetContestantShift(uc.contestanshifttid);
                if (cs != null)
                {
                    #region hiển thị thông tin contestant
                    txtFullName.Text = cs.CONTESTANT.FullName;
                    txtContestantCode.Text = cs.CONTESTANT.ContestantCode;
                    txtIdentity.Text = cs.CONTESTANT.IdentityCardNumber;
                    txtDOB.Text = DatetimeConvert.ConvertUnixToDateTime((int)cs.CONTESTANT.DOB).ToShortDateString();
                    txtContestantID.Text = cs.CONTESTANT.ContestantID.ToString();
                    txtTimesViolation.Text = Convert.ToString(BusALL.Instance.CountTimesViolation(uc.contestanshifttid));
                    txtComputerName.Text = cs.ROOMDIAGRAM.ComputerName;
                    txtSubject.Text = cs.SCHEDULE.SUBJECT.SubjectName;
                    if (Convert.ToInt32(cs.CONTESTANT.Sex) == 1)
                    {
                        txtSex.Text = "Nam";
                    }
                    else
                    {
                        txtSex.Text = "Nữ";
                    }


                    int contestantID = Convert.ToInt32(txtContestantID.Text);

                    //ContestantInformation CI = lstCIConnected.SingleOrDefault(x => x.UserTransfer.UserID == contestantID && x.UserTransfer.Status == UserHelper.Common.STATUS_DOING);
                    //if (CI != null)
                    //{
                        if (cs.Status == UserHelper.Common.STATUS_DOING)
                        {
                            btnViolation.Enabled = true;
                            isCheckArr = false;
                        }

                    //}
                    //else
                    //{
                    //    btnViolation.Enabled = false;
                    //}


                    if (isCheckArr)
                    {
                        btnChangeComputerName.Enabled = true;

                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                txtMessageBox.Text = String.Format(ex.Message);
            }

        }
        private void Uccomputer_RightClick(object sender, EventArgs e)
        {
            ucComputer uc = (ucComputer)sender;
            txtMessageBox.Clear();
            try
            {
                CONTESTANTS_SHIFTS cs = new CONTESTANTS_SHIFTS();
                cs = BusALL.Instance.GetContestantShift(uc.contestanshifttid);
                if (cs != null)
                {
                    metroContextMenu1.Show(uc, new Point(45, 45));
                    ctID = uc.contestantid;
                   
                    if (cs.Status == UserHelper.Common.STATUS_READY_TO_GET_TEST)
                    {
                        MenuItemDivisionShift.Enabled = true;
                    }
                    else if (cs.Status == UserHelper.Common.STATUS_READY)
                    {

                        MenuItemStartTest.Enabled = true;
                    }
                    else
                    {
                        MenuItemDivisionShift.Enabled = false;
                        MenuItemStartTest.Enabled = false;
                    }
    

                }
            }
            catch (Exception ex)
            {
                txtMessageBox.Text = String.Format(ex.Message);
            }
        }


        #region menucontext phat de, bat dau lam bai,chuyen ca thi du phong cho tung UC
        private void MenuItemDivisionShift_Click_1(object sender, EventArgs e)
        {
            #region Khai báo UserTransformation của máy server để gửi trên lstTraceLog
            UserTransformation UT = new UserTransformation();
            lstUserGet = new List<UserGet>();
            EXAMINATIONCOUNCIL_STAFFS supervisor = BusALL.Instance.GetInfoSupervisor(AppSession.StaffID);
            if (supervisor != null)
            {
                UT.UserID = (int)supervisor.StaffID;
                UT.UserCode = supervisor.UserName;
            }
            else
            {
                UT.UserID = 0;
                UT.UserCode = "SERVER";
            }
            #endregion
            // Trạng thái nhận đề thi và danh sách câu hỏi (Gửi) gửi cho thí sinh
            UT.Status = 3011;
            UT.Content = "Hãy lấy đề thi";
            #region update trang thái get test cho contestant shift
            int countcs = 0;
            try
            {
                foreach (SocketController sc in serverSocket.ClientList)
                {
                    if (sc.UserID == ctID)
                    {
                        CONTESTANTS_SHIFTS contestantShift = BusALL.Instance.GetContestantShift(divisionShiftID, sc.UserID);
                        CONTESTANT contestant = BusALL.Instance.GetInfoContestant(sc.UserID);
                        if (contestantShift != null && contestant != null)
                        {

                            try
                            {
                                sc.SendData(UserHelper.Ultis.FromObjectToJSON(UT));

                                MenuItemDivisionShift.Enabled = false;
                            }
                            catch
                            {
                                SetText(string.Format("Gửi trạng thái phát đề cho [{0}] đề không thành công. Phát đề lại", sc.UserID));
                                MenuItemDivisionShift.Enabled = true;
                                return;
                            }
                            lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;
                            SetText(string.Format("Phát đề thành công"));


                        }
                        else
                        {

                        }
                    }
                    break;
                }
            }
            #endregion

            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối với thí sinh", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void MenuItemStartTest_Click(object sender, EventArgs e)
        {
            #region khởi tạo tên máy server để gửi dữ liệu
            UserTransformation UT = new UserTransformation();
            lstUserGet = new List<UserGet>();
            EXAMINATIONCOUNCIL_STAFFS supervisor = BusALL.Instance.GetInfoSupervisor(AppSession.StaffID);
            if (supervisor != null)
            {
                UT.UserID = (int)supervisor.StaffID;
                UT.UserCode = supervisor.UserName;
            }
            else
            {
                UT.UserID = 0;
                UT.UserCode = "SERVER";
            }
            #endregion

            // gửi trạng thái bắt đầu làm bài thi đến tất cả các thí sinh trong list danh sách
            UT.Status = 3009;
            if(UT.ComputerName!=null)
            {
                UT.Content = "Thí sinh "+txtFullName.Text+ " bắt đầu làm bài!";

            }
            

            AddToView(UT);
            txtMessageBox.Clear();
            int count_error = 0;
            // if(serverSocket.ClientList!=null)
            bool kt = false;
            if (serverSocket.ClientList.Count > 0)
            {
                foreach (SocketController sc in serverSocket.ClientList)
                {
                    if (sc.UserID == ctID)
                    {
                        try
                        {
                            sc.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                            kt = true;
                            break;
                        }
                        catch
                        {
                            count_error++;
                        }
                    }
                }

                if (!kt)
                {
                    txtMessageBox.Text = "Thí sinh " + txtFullName.Text + " chưa bắt đầu làm bài!";
                    SetText(txtMessageBox.Text);
                }
                if (count_error > 0)
                {
                    txtMessageBox.ForeColor = Color.Red;
                    SetText("Bắt đầu thi không thành công, Gửi lại");
                    MenuItemStartTest.Enabled = true;
                }

            }
            else
            {
                SetText("Nothing in server");

            }

        }

        private void MenuItemChangeShift_Click(object sender, EventArgs e)
        {
            CONTESTANTS_SHIFTS contestantShift = BusALL.Instance.GetContestantShift(divisionShiftID, ctID);
            if (contestantShift != null)
            {
                frmThongBaoChuyen frmTB = new frmThongBaoChuyen();
                frmTB.Show();
                frmTB.sendWorking += new frmThongBaoChuyen.SendNotifi(FrmTB_sendWorking);
            }
        }

        private void FrmTB_sendWorking(string Reason)
        {

            CONTESTANTS_SHIFTS contestantShift = BusALL.Instance.GetContestantShift(divisionShiftID, ctID);
            if (contestantShift != null)
            {
                contestantShift.Status = UserHelper.Common.STATUS_CHANGE_SHIFT;
                contestantShift.IsCheckFingerprint = null;
                contestantShift.RoomDiagramID = null;
                if (BusALL.Instance.UpdateContestantShift(contestantShift))
                {
                    txtMessageBox.Clear();
                    txtMessageBox.Text = "Chuyển ca thi thành công!";
                    foreach (var item in tabControl1.TabPages[tabControl1.SelectedIndex].Controls)
                    {
                        if (item is Panel)
                        {
                            Panel pnl = (Panel)item;
                            pnl.Controls.Clear();
                            LoadComputer1(pnl);
                        }
                    }
                    frmBienBanChuyenCaThi frmBB = new frmBienBanChuyenCaThi(txtContestantCode.Text, txtFullName.Text, Reason, txtIdentity.Text, divisionShiftID);
                    frmBB.Show();
                }
                else MessageBox.Show("Chưa chuyển được thí sinh");

            }
        }
        #endregion

        private void frmSupervisorServer_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (serverSocket != null)
            {
                serverSocket.CloseSocket();
            }
            if(_frmIdentifyFinger!=null)
            {
                _frmIdentifyFinger.DisposeDevice();
                _frmIdentifyFinger.Dispose();
                _frmIdentifyFinger = null;
            } 
            
       }

        #region  tabcontrol roomtest

        private void tabControl1_ControlAdded_1(object sender, ControlEventArgs e)
        {
            frmSupervisorServer_Load(sender, e);
        }
        private void tabControl1_Selected_1(object sender, TabControlEventArgs e)
        {
            foreach (int i in indexPage)
            {
                if (e.TabPageIndex == i)

                {
                    divisionShiftID = ListDivisionShiftID[i];
                    shiftID = ListShiftID[i];
                    StatusDivisionShift = BusALL.Instance.GetStatusDivisionShift(divisionShiftID);
                    DIVISION_SHIFTS divisionShift = BusALL.Instance.GetDivisionShiftByID(divisionShiftID);
                    //  roomTestID = divisionShift.RoomTestID;
                    if (divisionShift != null)
                    {
                        roomTestID = Convert.ToInt32(divisionShift.RoomTestID);
                    }
                    //LoadCmbComputerChange();    
                    EnableButton(StatusDivisionShift);
                }
            }
        }
        #endregion

        #region Thong ke thi sinh hoan thanh, danh sach xep cho
        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport(divisionShiftID, supervisorID, shiftID);
            frm.ShowDialog();
        }
        private void tsMenuItemPrintContestant_Click(object sender, EventArgs e)
        {
            frmReportARR frm = new frmReportARR(divisionShiftID);
            frm.ShowDialog();
        }
        #endregion

        #region Su kien quy trinh phat de, bat dau ...

        // goi thi sinh vao phong thi
        private void mbtnAttendance_Click(object sender, EventArgs e)
        {
            sessionCheck = true;
            mbtnAttendance.Enabled = false;
            mbtnAuthen.Enabled = true;
            StatusDivisionShift = BusALL.Instance.GetStatusDivisionShift(divisionShiftID);
            if (_frmIdentifyFinger == null)
            {
                _frmIdentifyFinger = new RM.GetFinger.frmIdentifyFinger(shiftID,true);

            }
            if (IsInitDevice == -1)
            {
                IsInitDevice = _frmIdentifyFinger.InitDevice();
            }
            room = BusALL.Instance.GetRoom(roomTestID);
            if (_frmIdentifyFinger.OpenDevice(room.RoomTestName))
            {
                MessageBox.Show("Bắt đầu cho thí sinh vào phòng thi " + room.RoomTestName);
                if (StatusDivisionShift < 3)
                {
                    BusALL.Instance.UpdateStatusDivisionShift(divisionShiftID, UserHelper.Common.STATUS_ATTENDANCE);
                    
                }
                
            }     
            _frmIdentifyFinger.SenderIDContestant += LoadUCComputer;
        }

      
       // hoan tat viec kiem tra
        private void mbtnAuthen_Click(object sender, EventArgs e)
        {
            if (StatusDivisionShift <= UserHelper.Common.STATUS_ATTENDANCE)
            {
                foreach (var item in tabControl1.TabPages[tabControl1.SelectedIndex].Controls)
                {
                    if (item is Panel)
                    {
                        Panel pnl = (Panel)item;
                        foreach (ucComputer uc in pnl.Controls)
                        {
                            if (uc.contestantid > 0)
                            {
                                int checkedid = uc.contestantid;
                                /////
                                if (uc.CheckedConfirm == true)
                                {
                                    uc.DisablecbCheckFP();
                                    CONTESTANTS_SHIFTS contestantShift = new CONTESTANTS_SHIFTS();
                                    contestantShift = BusALL.Instance.GetContestantShift(divisionShiftID, checkedid);
                                    if (contestantShift.IsCheckFingerprint != 1)
                                        contestantShift.IsCheckFingerprint = 2;
                                    contestantShift.Status = 4001;
                                    try
                                    {
                                        BusALL.Instance.UpdateContestantShift(contestantShift);

                                    }
                                    catch
                                    {

                                    }
                                }
                                uc.CheckedConfirmtoload = false;
                                uc.LoadInfoContestant();
                            }
                        }
                    }
                }
            
                BusALL.Instance.UpdateStatusDivisionShift(divisionShiftID, UserHelper.Common.STATUS_VERITY); //đổi trạng thái divisionshift
            }
            //txtServerPort.Visible = true;
            #region dong thiet bi
            if (_frmIdentifyFinger != null)
            {
                room = BusALL.Instance.GetRoom(roomTestID);
                _frmIdentifyFinger.CloseDevice(room.RoomTestName);
                IVerifyService sv = new VerifyService();
                sv.UpdateCheckFP(roomTestID, shiftID, 2);
            }
            #endregion
            if (!isStartServer)
            {
                try
                {
                    UserHelper.Ultis.GetCurrentIP(out IP);
                    serverSocket = new UserHelper.ServerSide(IP, int.Parse(txtServerPort.Text));
                    serverSocket.ClientConnected += serverSocket_ClientConnected;
                    serverSocket.ClientDisConnected += serverSocket_ClientDisconnected;
                    lsbTrace.Items.Add(string.Format("Bắt đầu giám sát thi"));
                    lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;
                    isStartServer = true;
                    timerStartTest.Start();
                    btnChangeComputerName.Enabled = true;

                    StatusDivisionShift = BusALL.Instance.GetStatusDivisionShift(divisionShiftID);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
            if(!isDecrypt)
            {
                mbtnDecry.Enabled = true;
            }
            mbtnAuthen.Enabled = false;

        }

        //  boc tui de thi
        private void mbtnDecry_Click(object sender, EventArgs e)
        {
            frmInputKey frm = new frmInputKey(divisionShiftID);
            frm.Show();
            frm.Sender += Frm_Sender;
      
        }

        private void Frm_Sender(bool _IsDecrypt)
        {
            isDecrypt = _IsDecrypt;            
            if (CheckDivisionTest) mbtnDivsionTest.Enabled = true;
            mbtnDecry.Enabled = false;
        }

        // phat de cho thi sinh
        private void mbtnDivsionTest_Click(object sender, EventArgs e)
        {
            #region Khai báo UserTransformation của máy server để gửi trên lstTraceLog
            UserTransformation UT = new UserTransformation();
            lstUserGet = new List<UserGet>();
            EXAMINATIONCOUNCIL_STAFFS supervisor = BusALL.Instance.GetInfoSupervisor(AppSession.StaffID);
            if (supervisor != null)
            {
                UT.UserID = (int)supervisor.StaffID;
                UT.UserCode = supervisor.UserName;
            }
            else
            {
                UT.UserID = 0;
                UT.UserCode = "SERVER";
            }
            #endregion
            // Trạng thái nhận đề thi và danh sách câu hỏi (Gửi) gửi cho thí sinh
            UT.Status = 3011;
            UT.Content = "Hãy lấy đề thi";

            // List<CONTESTANTS_TESTS> listContestantTestExist = ListContestantTestExist(divisionShiftID);

            #region lấy danh sách Schedule để lấy được các môn thi có trong KÍP thi TẠI PHÒNG THI này
            List<SCHEDULE> listSchedule = BusALL.Instance.ListScheduleOfShift(divisionShiftID);

            int count_error_add_contestant = 0;
            if (countBtnDivisionTest == 0)
            {
                foreach (SCHEDULE item in listSchedule)
                {
                    // Lấy danh sách thí sinh thi theo từng schedule
                    if (item != null && item.SubjectID > 0)
                    {
                        // LẤY danh sách mã thí sinh theo phòng thi
                        List<int> listContestantShiftID = BusALL.Instance.ListContestantShiftIDForScheduleOfShift(divisionShiftID, item.ScheduleID);

                        // lấy testID cho ca thi
                        List<int> listTestIDForSubject = BusALL.Instance.ListTestIDForSubjectOfShift(divisionShiftID, item.SubjectID);

                        if (listContestantShiftID.Count <= listTestIDForSubject.Count)
                        {
                            Hashtable hasData = new Hashtable();
                            GenerateTestForContestant(listContestantShiftID, listTestIDForSubject, out hasData);
                            #region tiến hành phát đề cho từng môn
                            foreach (DictionaryEntry entry in hasData)
                            {
                                int contestantShiftID = Convert.ToInt32(entry.Key);
                                if (BusALL.Instance.CheckContestantTestExist(contestantShiftID))
                                {
                                    CONTESTANTS_TESTS contestantTest = BusALL.Instance.GetContestantTest(contestantShiftID);
                                    contestantTest.TestID = Convert.ToInt32(entry.Value);
                                    if (!BusALL.Instance.UpdateContestantTest(contestantTest))
                                    {
                                        count_error_add_contestant++;
                                        break;
                                    }
                                }
                                else
                                {
                                    CONTESTANTS_TESTS contestantTest = new CONTESTANTS_TESTS();
                                    contestantTest.ContestantShiftID = contestantShiftID;
                                    contestantTest.TestID = Convert.ToInt32(entry.Value);
                                    contestantTest.Status = 4001;
                                    if (!BusALL.Instance.AddContestantTest(contestantTest))
                                    {
                                        count_error_add_contestant++;
                                        break;
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                }
                countBtnDivisionTest = 1;
            }
            #endregion

            if (count_error_add_contestant == 0) // nếu không có lỗi trong quá trình phát đề thì /....
            {
                 mbtnDivsionTest.Enabled = false;
                // btnDivisionTest.BackColor = Color.Gray;
                #region update trang thái get test cho contestant shift
                int countcs = 0;
                if (serverSocket.ClientList.Count > 0)
                {

                    foreach (SocketController sc in serverSocket.ClientList)
                    {
                        CONTESTANTS_SHIFTS contestantShift = BusALL.Instance.GetContestantShift(divisionShiftID, sc.UserID);
                        CONTESTANT contestant = BusALL.Instance.GetInfoContestant(sc.UserID);
                        if (contestantShift != null && contestant != null)
                        {
                            contestantShift.Status = UserHelper.Common.STATUS_GET_TEST;
                            if (BusALL.Instance.UpdateContestantShift(contestantShift))
                            {
                                countcs++;
                            }
                            else
                            {

                            }
                        }
                    }

                    lsbTrace.Items.Add(string.Format("Cập nhật trạng thái nhận đề cho {0} thí sinh thành công", countcs));

                }
                else
                {
                    lsbTrace.Items.Add(string.Format("Chưa có thí sinh nào kết nối tới server"));
                    return;
                }

                #endregion

                #region gửi trạng thái đến thí sinh khi phát đề thành công
                if (serverSocket.ClientList.Count > 0)
                {
                    foreach (SocketController sc in serverSocket.ClientList)
                    {

                        if (CheckUserID(sc.UserID))
                        {
                            if (sc.SendData(UserHelper.Ultis.FromObjectToJSON(UT)))
                            {
                                
                                lsbTrace.Items.Add(string.Format("Gửi cho [{0}] trạng thái phát đề thành công", sc.UserID));
                            }
                            else
                            {
                                lsbTrace.Items.Add(string.Format("Gửi trạng thái phát đề cho [{0}] đề không thành công. Phát đề lại", sc.UserID));
                               // mbtnDivsionTest.Enabled = true;
                                return;
                            }
                            lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;
                        }
                    }
                    BusALL.Instance.UpdateStatusDivisionShift(divisionShiftID, UserHelper.Common.STATUS_DIVISIONTEST);
                    lsbTrace.Items.Add(string.Format("Phát đề thành công"));
                    isCheckDivisionTest = true;
                }
                else
                {
                    lsbTrace.Items.Add(string.Format("Chưa có thí sinh nào kết nối tới server"));
                    mbtnDivsionTest.Enabled = true;
                   
                    return;
                }

                #endregion
            }
            else
            //{

            //}
            {
                lsbTrace.Items.Add(string.Format("Phát đề không thành công. Phát đề lại"));
               mbtnDivsionTest.Enabled = true;
            }
            lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;
            // System.Threading.Thread.Sleep(15000);
        }
        // bat dau cho thi sinh lam bai
        private void mbtnStartTest_Click(object sender, EventArgs e)
        {
            #region khởi tạo tên máy server để gửi dữ liệu
            UserTransformation UT = new UserTransformation();
            lstUserGet = new List<UserGet>();
            EXAMINATIONCOUNCIL_STAFFS supervisor = BusALL.Instance.GetInfoSupervisor(AppSession.StaffID);
            if (supervisor != null)
            {
                UT.UserID = (int)supervisor.StaffID;
                UT.UserCode = supervisor.UserName;
            }
            else
            {
                UT.UserID = 0;
                UT.UserCode = "SERVER";
            }
            #endregion

            // gửi trạng thái bắt đầu làm bài thi đến tất cả các thí sinh trong list danh sách
            UT.Status = 3009;
            UT.Content = "Tất cả bắt đầu làm bài";

            AddToView(UT);
            txtMessageBox.Clear();
            int count_error = 0;
            // if(serverSocket.ClientList!=null)

            if (serverSocket.ClientList.Count > 0)
            {
                foreach (SocketController sc in serverSocket.ClientList)
                {
                    if (CheckUserIDForStartTest(sc.UserID))
                    {
                        try
                        {
                            sc.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                        }
                        catch
                        {
                            count_error++;
                        }
                    }
                }


                if (count_error > 0)
                {
                    txtMessageBox.ForeColor = Color.Red;
                    lsbTrace.Items.Add("Bắt đầu thi không thành công, Gửi lại");
                    mbtnStartTest.Enabled = true;
                }
                else
                {
                    BusALL.Instance.UpdateStatusDivisionShift(divisionShiftID, UserHelper.Common.STATUS_STARTTEST);
                    mbtnStartTest.Enabled = false;
                    isCheckStartTest = true;
                }
            }
            else
            {
                lsbTrace.Items.Add("Nothing in server");
                mbtnStartTest.Enabled = true;
            }
            mbtnDivsionTest.Enabled = false;

        }
        #endregion

        #region Sự kiện btn đổi ca, cảnh cáo, chuyển vị trí

        private void btnChangeComputerName_Click(object sender, EventArgs e)
        {
            try
            {
                MTAQuizEntities db = new MTAQuizEntities();
                txtMessageBox.Clear();
                CONTESTANT contestant = new CONTESTANT();
                if (txtContestantID.Text != "" && cmbComName.SelectedValue != null)
                {
                    int contestantID;
                    contestantID = Convert.ToInt32(txtContestantID.Text);
                    contestant = BusALL.Instance.GetInfoContestant(contestantID);
                    CONTESTANTS_SHIFTS contestantShift = new CONTESTANTS_SHIFTS();
                    contestantShift = BusALL.Instance.GetContestantShift(divisionShiftID, contestantID);
                    ROOMDIAGRAM roomDia = new ROOMDIAGRAM();
                    roomDia = BusALL.Instance.GetRoomDiaByID(Convert.ToInt32(contestantShift.RoomDiagramID));

                    DialogResult dr = MessageBox.Show(string.Format("Bạn có chắn chắn chuyển chỗ ngồi từ {0} sang {1}?", roomDia.ComputerName, cmbComName.Text), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {

                        roomDia.Status = 4002; // trạng thái máy hỏng

                        contestantShift.RoomDiagramID = Convert.ToInt32(cmbComName.SelectedValue);

                        contestantShift.DivisionShiftID = BusALL.Instance.GetDivisionShift(shiftID, roomTestID).DivisionShiftID;

                        if (BusALL.Instance.UpdateContestantShift(contestantShift) && BusALL.Instance.UpdateRoomDia(roomDia))
                        {

                            frmBienBan frmbb = new frmBienBan(roomDia.ComputerName, cmbComName.Text, roomDia.ROOMTEST.RoomTestName, roomDia.ROOMTEST.RoomTestName, divisionShiftID, contestant.FullName, contestant.ContestantCode);
                            frmbb.ShowDialog();

                            roomDia = BusALL.Instance.GetRoomDiaByID(Convert.ToInt32(contestantShift.RoomDiagramID));
                            roomDia.Status = 4001;

                            txtComputerName.Text = BusALL.Instance.GetInfoRoomDia(Convert.ToInt32(contestantShift.RoomDiagramID)).ComputerName;
                            
                            txtMessageBox.Text = "Chuyển chỗ thành công";
                            cmbComName.Text = null;
                            roomDia = BusALL.Instance.GetRoomDiaByID(Convert.ToInt32(contestantShift.RoomDiagramID));
                            roomDia.Status = 4001;
                            BusALL.Instance.UpdateRoomDia(roomDia);
                            txtComputerName.Text = BusALL.Instance.GetInfoRoomDia(Convert.ToInt32(contestantShift.RoomDiagramID)).ComputerName;
                          
                            txtMessageBox.Text = "Chuyển chỗ thành công";
                            foreach (var item in tabControl1.TabPages[tabControl1.SelectedIndex].Controls)
                            {
                                if (item is Panel)
                                {
                                    Panel pnl = (Panel)item;
                                    pnl.Controls.Clear();
                                    LoadComputer1(pnl);
                                }
                            }


                        }
                        else
                        {
                            txtMessageBox.Text = "Chuyển chỗ không thành công";
                            txtMessageBox.ForeColor = Color.Red;
                            return;
                        }
                    }
                    //    }
           
                }
                else
                {
                    txtMessageBox.Text = " Hết vị trí có thể chuyển tới. Bạn cần tích vào chuyển chỗ và chọn máy muốn đổi tới";
                    txtMessageBox.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            { }
            
        }

        private void btnViolation_Click(object sender, EventArgs e)
        {

            txtMessageBox.Clear();
            #region khai báo trans
            UserTransformation UT = new UserTransformation();
            EXAMINATIONCOUNCIL_STAFFS supervisor = BusALL.Instance.GetInfoSupervisor(AppSession.StaffID);
            if (supervisor != null)
            {
                UT.UserID = (int)supervisor.StaffID;
                UT.UserCode = supervisor.UserName;
            }
            else
            {
                UT.UserID = 0;
                UT.UserCode = "SERVER";
            }
            UT.ComputerName = Dns.GetHostName();
            #endregion

            if (txtContestantID.Text != null && cmbTOV.SelectedValue != null)
            {
                DialogResult dr = MessageBox.Show(string.Format("Bạn có chắc chắn cảnh cáo thí sinh {0} không?", txtFullName.Text), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    UT.Status = 3008; // thí sinh bị cảnh cáo thì đưa ra thông báo và update vào bảng contestant_violation
                    UT.Content = "Vi phạm quy chế thi";
                    int contestantID = Convert.ToInt32(txtContestantID.Text);

                    CONTESTANTS_SHIFTS contestantShift = BusALL.Instance.GetContestantShift(divisionShiftID, contestantID);
                    if (contestantShift.Status == UserHelper.Common.STATUS_DOING || contestantShift.Status == UserHelper.Common.STATUS_REPORT_ERROR)
                    {
                        #region gửi thông bảo cảnh cáo tới thí sinh
                        if (serverSocket.ClientList.Count > 0 && contestantShift.ContestantID.ToString() != null)
                        {
                            foreach (SocketController sc in serverSocket.ClientList)
                            {
                                if (sc.UserID == contestantShift.ContestantID)
                                {
                                    try
                                    {
                                        VIOLATIONS_CONTESTANTS vio_contestant = new VIOLATIONS_CONTESTANTS();
                                        vio_contestant.Status = 1;
                                        vio_contestant.ContestantShiftID = contestantShift.ContestantShiftID;
                                        vio_contestant.ViolationID = Convert.ToInt32(cmbTOV.SelectedValue);
                                        vio_contestant.TimeSave = DatetimeConvert.ConvertDateTimeToUnix(DateTime.Now);

                                        if (BusALL.Instance.AddViolationContestant(vio_contestant))
                                        {
                                            sc.SendData(UserHelper.Ultis.FromObjectToJSON(UT));
                                            SetText(string.Format("Gửi cảnh cáo và cập nhật trạng thái cho [{0}] thành công", sc.UserID));
                                            AddToView(UT);
                                            int countTimesViolation = BusALL.Instance.CountTimesViolation(contestantShift.ContestantShiftID);
                                            txtTimesViolation.Text = Convert.ToString(countTimesViolation) + " lần";
                                            // btnViolation.Enabled = false;

                                            LoadViolation(contestantShift.ContestantShiftID);

                                        }
                                        else
                                        {
                                            txtMessageBox.Text = (string.Format("Cảnh cáo [{0}]-[{1}] không thành công", sc.UserID, txtFullName.Text));
                                            return;
                                        }
                                        lsbTrace.SelectedIndex = lsbTrace.Items.Count - 1;
                                    }
                                    catch (Exception ex)
                                    {
                                        txtMessageBox.Text = (string.Format("Lỗi [{0}]", ex.Message));
                                    }
                                }
                            }
                        }


                        LoadTOV();
                    }

                    else
                    {
                        txtMessageBox.Text = (string.Format("Cảnh cáo chỉ được diễn ra khi trạng thái ĐANG THI"));
                        return;
                    }
                }
                #endregion
            }
            else
            {
                txtMessageBox.Text = "Phải chọn loại vi phạm!";
                return;
            }
        }




        #endregion

     
    }

}
