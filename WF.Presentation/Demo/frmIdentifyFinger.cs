using CL.Persistance;
using CL.Services.Impl;
using CL.Services.Interface;
using libzkfpcsharp;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Environment;

namespace RM.GetFinger
{
    public partial class frmIdentifyFinger : MetroForm
    {
        
        IntPtr mDevHandle = IntPtr.Zero;
        List<IntPtr> lstDev = new List<IntPtr>();
        List<string> lstRoomDev = new List<string>();
        List<Thread> lstThread = new List<Thread>();
        IntPtr mDBHandle = IntPtr.Zero;
        IntPtr FormHandle = IntPtr.Zero;
        bool bIsTimeToDie = false;
        bool IsRegister = false;
        bool bIdentify = false;
        byte[] FPBuffer;
        int RegisterCount = 0;
        const int REGISTER_FINGER_COUNT = 3;
        string scboLastIndex;
        byte[][] RegTmps = new byte[3][];
        byte[] RegTmp = new byte[2048];
        byte[] CapTmp = new byte[2048];
        int cbCapTmp = 2048;
        int cbRegTmp = 0;
        int iFid = 1;
        int contestID = 0;
        private int mfpWidth = 0;
        private int mfpHeight = 0;
        int _contestantID=0;
        const int MESSAGE_CAPTURED_OK = 0x0400 + 6;
        int _currentroomid=0;
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        IVerifyService fingersv=new VerifyService();
        int _shiftID = 0;
        List<string> lstDeviceRoom=new List<string>();
        List<string> lstRoom = new List<string>();
        int currentroom=0;
        public delegate void SendID(int id);
        public event SendID SenderIDContestant;
        public frmIdentifyFinger(int shiftid, bool check)
        {
            InitializeComponent();
            bIdentify = true;
            _shiftID =shiftid ;
        }
        public frmIdentifyFinger(int contestantID)
        {
            InitializeComponent();
            InitDevice();
            //IsRegister = true;
            _contestantID = contestantID;
            cboDevice.DataSource = lstDeviceRoom;
            scboLastIndex = cboDevice.Text;
            OpenDevWhenRegister();
            LoadInfo();
        }
        void LoadInfo()
        {
            fingersv = new VerifyService();
            CONTESTANT con = fingersv.GetInfoContestantbyID(_contestantID);
            if (con != null)
            {
                lbName.Text = con.FullName;
                lbSBD.Text = con.ContestantCode;
            }
            
        }
        string ByteArr2String(byte[] b)
        {
            StringBuilder outSb = new StringBuilder(b.Length);
            char c;
            int i;
            for (i = 0; i < b.Length; i++)
            {
                if (b[i] == 0) break;
                c = (char)b[i];
                outSb.Append(c);
            }
            return outSb.ToString().Substring(1, i - 2);
        }
        void OpenDevWhenRegister()
        {
            int ret = zkfp.ZKFP_ERR_OK;
            if (IntPtr.Zero == (mDevHandle = zkfp2.OpenDevice(0)))
            {
                MessageBox.Show("Mở thiết bị quét không thành công");
                this.Close();
                return;
            }
            if (IntPtr.Zero == (mDBHandle = zkfp2.DBInit()))
            {
                MessageBox.Show("Khởi tạo dữ liệu thất bại!");
                zkfp2.CloseDevice(mDevHandle);
                mDevHandle = IntPtr.Zero;
                this.Close();
                return;
            }
            RegisterCount = 0;
            cbRegTmp = 0;
            iFid = 1;
            for (int i = 0; i < 3; i++)
            {
                RegTmps[i] = new byte[2048];
            }
            byte[] paramValue = new byte[4];
            int size = 4;
            zkfp2.GetParameters(mDevHandle, 1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);
            size = 4;
            zkfp2.GetParameters(mDevHandle, 2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

            FPBuffer = new byte[mfpWidth * mfpHeight];

            Thread captureThread = new Thread(new ThreadStart(DoCapture2));
            captureThread.IsBackground = true;
            captureThread.Start();
            bIsTimeToDie = false;
            textRes.Text = "Mở thiết bị quét vân tay thành công!";
        }
        private void DoCapture2()
        {
            while (!bIsTimeToDie)
            {
                cbCapTmp = 2048;
                int ret = zkfp2.AcquireFingerprint(mDevHandle, FPBuffer, CapTmp, ref cbCapTmp);
                if (ret == zkfp.ZKFP_ERR_OK)
                {
                    SendMessage(FormHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                }
                Thread.Sleep(200);
            }
        }
        private void DoCapture(IntPtr dev, int roomid)
        {
            while (!bIsTimeToDie)
            {
                cbCapTmp = 2048;
                int ret = zkfp2.AcquireFingerprint(dev, FPBuffer, CapTmp, ref cbCapTmp);
                if (ret == zkfp.ZKFP_ERR_OK)
                {
                    _currentroomid = roomid;
                    SendMessage(FormHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                }
                Thread.Sleep(200);
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    {
                        //nếu là đăng ký
                        #region đăng ký
                        if (IsRegister)
                        {
                            LoadDB();
                            int ret = zkfp.ZKFP_ERR_OK;
                            int fid = 0, score = 0;
                            ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
                            if (zkfp.ZKFP_ERR_OK == ret)
                            {
                                fingersv = new VerifyService();
                                FINGERPRINT finger = fingersv.GetFingerprint(fid);
                                if (finger != null)
                                {
                                    #region phát âm thanh khi có kết quả sai
                                    System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.sai);
                                    spwarning.Play();
                                    #endregion
                                    MessageBox.Show("Vân tay đã được đăng ký bởi thí sinh " + finger.CONTESTANT.FullName + "! SBD: " + finger.CONTESTANT.ContestantCode);
                                    textRes.Text = "Đặt một ngón tay 3 lần lên máy quét!";

                                }
                                else
                                {
                                    textRes.Text = "Vân tay đã được đăng ký";
                                    #region phát âm thanh khi có kết quả sai
                                    System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.sai);
                                    spwarning.Play();
                                    #endregion
                                }

                                return;
                            }
                            if (RegisterCount > 0 && zkfp2.DBMatch(mDBHandle, CapTmp, RegTmps[RegisterCount - 1]) <= 0)
                            {
                                textRes.Text = "Vui lòng nhập 3 lần vân tay trên cùng 1 ngón tay!";
                                #region phát âm thanh khi có kết quả sai
                                System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.sai);
                                spwarning.Play();
                                #endregion
                                return;
                            }
                            #region phát âm thanh khi quét đc vân tay
                            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.grunz_success);
                            sp.Play();
                            #endregion
                            Array.Copy(CapTmp, RegTmps[RegisterCount], cbCapTmp);
                            String strBase64 = zkfp2.BlobToBase64(CapTmp, cbCapTmp);
                            byte[] blob = zkfp2.Base64ToBlob(strBase64);
                            RegisterCount++;
                            if (RegisterCount >= REGISTER_FINGER_COUNT)
                            {
                                RegisterCount = 0;
                                if (zkfp.ZKFP_ERR_OK == (ret = zkfp2.DBMerge(mDBHandle, RegTmps[0], RegTmps[1], RegTmps[2], RegTmp, ref cbRegTmp)))
                                {
                                    fingersv = new VerifyService();
                                    FINGERPRINT finger = new FINGERPRINT();
                                    finger.ContestantID = _contestantID;
                                    finger.FingerprintImage = RegTmp;
                                    finger.FilePath = "";
                                    finger.TimeSaveFingerprint = Convert.ToInt32((Common.GetDateTimeServer().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalSeconds);
                                    finger.Status = 1;
                                    if(fingersv.AddFingerprint(finger)&& fingersv.UpdateContestantShiftSTT(_contestantID))
                                    {
                                        #region phát âm thanh khi lấy vân tay thành công
                                        System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.succ);
                                        spwarning.Play();
                                        #endregion
                                        MessageBox.Show("Lấy mẫu vân tay thành công!");
                                        textRes.Text = "Lấy mẫu vân tay thành công!";
                                    }
                                    
                                    else
                                    {
                                        #region phát âm thanh khi có kết quả sai
                                        System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.sai);
                                        spwarning.Play();
                                        #endregion
                                        MessageBox.Show("Lấy vân tay không thành công!");
                                        textRes.Text = "Lấy vân tay không thành công!";
                                    }
                                }
                                else
                                {
                                    #region phát âm thanh khi có kết quả sai
                                    System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.sai);
                                    spwarning.Play();
                                    #endregion
                                    textRes.Text = "Tạo bộ mẫu vân tay thất bại";// + "\nVui lòng nhập 3 mẫu vân tay trên 1 ngón tay!";
                                }
                                IsRegister = false;
                                return;
                            }
                            else
                            {
                                textRes.Text = "Bạn cần lấy  " + (REGISTER_FINGER_COUNT - RegisterCount) + " lần vân tay!";
                            }
                        }
                        #endregion
                        else
                        {
                            //if (cbregtmp <= 0)
                            //{
                            //    textres.text = "vui lòng chọn đăng ký!";
                            //    return;
                            //}
                            //xác thực
                            #region xác thực
                            if (bIdentify)
                            {
                               
                                int ret = zkfp.ZKFP_ERR_OK;
                                int fid = 0, score = 0;
                                ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
                                if (zkfp.ZKFP_ERR_OK == ret)
                                {
                                    fingersv = new VerifyService();
                                    FINGERPRINT finger = fingersv.GetFingerprint(fid);
                                    if (finger != null)
                                    {
                                        CONTESTANTS_SHIFTS contestantShift = fingersv.GetContestant_Shift(GetTimeServer(), GetDateTimeServer(), finger.CONTESTANT.ContestantID);

                                        ROOMDIAGRAM roomDia = new ROOMDIAGRAM();
                                        if (contestantShift != null)
                                        {
                                            if (contestantShift.RoomDiagramID != null)
                                            {
                                                roomDia = fingersv.GetInfoRoomDia(Convert.ToInt32(contestantShift.RoomDiagramID));
                                            }
                                            else
                                            {
                                                MessageBox.Show("Thí sinh không có chỗ!");
                                                #region phát âm thanh
                                                fingersv.UpdateCheckFP(_currentroomid, _shiftID, 0);
                                                System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.warningSoundEffectSound);
                                                spwarning.Play();
                                                #endregion
                                            }

                                            #region Cập nhật trạng thái cho IsCheckFingerprint
                                            contestantShift.IsCheckFingerprint = 1;
                                            contestantShift.Status = 4001;
                                            contestantShift.TimeCheck = Convert.ToInt32((Common.GetDateTimeServer().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalSeconds);
                                            if (fingersv.UpdateContestantShift(contestantShift))
                                            {
                                                //textRes.Text = string.Format("Xác thực thành công, độ trùng khớp =" + score + "%!");
                                                #region phát âm thanh khi có kết quả đúng
                                                fingersv.UpdateCheckFP(_currentroomid, _shiftID, 1);
                                                System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.grunz_success);
                                                sp.Play();
                                                if (this.SenderIDContestant != null)
                                                    this.SenderIDContestant(contestantShift.ContestantID);
                                                #endregion
                                            }
                                            else
                                            {
                                                //textRes.Text = string.Format("Điểm danh không thành công, điểm danh lại");
                                                #region phát âm thanh khi có kết quả sai
                                                fingersv.UpdateCheckFP(_currentroomid, _shiftID, 0);
                                                System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.sai);
                                                spwarning.Play();
                                                #endregion
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            //textRes.Text = string.Format("Không lấy được thông tin thí sinh");
                                            //txtSubject.Text = txtRoomtest.Text = txtComputer.Text = "";
                                            #region phát âm thanh
                                            fingersv.UpdateCheckFP(_currentroomid, _shiftID, 0);
                                            System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.warningSoundEffectSound);
                                            spwarning.Play();
                                            #endregion
                                        }
                                    }
                                    else
                                    {
                                        #region phát âm thanh khi có kết quả sai
                                        fingersv.UpdateCheckFP(_currentroomid, _shiftID, 0);
                                        System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.sai);
                                        spwarning.Play();
                                        #endregion
                                    }

                                    return;
                                }
                                else
                                {
                                    #region phát âm thanh khi có kết quả sai
                                    fingersv.UpdateCheckFP(_currentroomid, _shiftID, 0);
                                    System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.sai);
                                    spwarning.Play();
                                    //if (this.SenderIDContestant != null)
                                    //    this.SenderIDContestant(5);
                                    #endregion
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                            #endregion
                        }
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }
        public static int GetTimeServer()
        {
            MTAQuizEntities db = new MTAQuizEntities();
            DateTime dt = db.Database.SqlQuery<DateTime>(@"SELECT GetDate()").First();
            return (int)dt.TimeOfDay.TotalSeconds;
        }
        public static int GetDateTimeServer()
        {
            MTAQuizEntities db = new MTAQuizEntities();
            DateTime dt = db.Database.SqlQuery<DateTime>(@"SELECT GetDate()").First();
            return Convert.ToInt32((dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalSeconds);
        }
        void LoadDB()
        {
            fingersv = new VerifyService();
            List<FINGERPRINT> lstfinger = new List<FINGERPRINT>();
            lstfinger = fingersv.ListFPOfShiftTime(_shiftID);
            int iFid = 0;
            foreach (FINGERPRINT item in lstfinger)
            {
                iFid = item.FingerprintID;
                RegTmp = item.FingerprintImage;
                zkfp2.DBAdd(mDBHandle, iFid, RegTmp);
            }
        }
        public int InitDevice()
        {
            FormHandle = this.Handle;
            #region kết nối
            //cmbIdx.Items.Clear();
            int ret = zkfperrdef.ZKFP_ERR_OK;
            if ((ret = zkfp2.Init()) == zkfperrdef.ZKFP_ERR_OK)
            {
                int nCount = zkfp2.GetDeviceCount();
                if (nCount > 0)
                {
                    string[] lines;
                    if (File.Exists(Environment.GetFolderPath(SpecialFolder.CommonApplicationData) + "\\Supervision\\getfingerprinter.txt"))
                    {
                        lines = File.ReadAllLines(Environment.GetFolderPath(SpecialFolder.CommonApplicationData) + "\\Supervision\\getfingerprinter.txt");
                    }
                    else
                        lines = new string[0];
                    for (int i = 0; i < nCount; i++)
                    {
                        if (IntPtr.Zero == (mDevHandle = zkfp2.OpenDevice(i)))
                        {
                            break;
                        }
                        byte[] sn = new byte[100];
                        int size = 100;
                        zkfp2.GetParameters(mDevHandle, 1103, sn, ref size);
                        string ssn = ByteArr2String(sn);
                        if (lines.Length != 0)
                            for (int j = 0; j < lines.Length; j++)
                            {
                                if (lines[j] == ssn) lstDeviceRoom.Add(lines[j + 1]);
                            }
                        //else cmbIdx.Items.Add(ssn);
                        zkfp2.CloseDevice(mDevHandle);
                    }
                    
                }
                else
                {
                    zkfp2.Terminate();
                    MessageBox.Show("Không có thiết bị quét vân tay nào được kết nối!");
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("Khởi tạo thiết bị quét vân tay thất bại!");
                return -1;
            }
            return 1;
            #endregion
        }
        public bool OpenDevice(string room)
        {
            fingersv = new VerifyService();
            int ret = zkfp.ZKFP_ERR_OK;
            int devideindex = -1;
            for (int i = 0; i < lstDeviceRoom.Count; i++)
            {
                if (room == lstDeviceRoom[i])
                    devideindex = i;
            }
            if (devideindex == -1)
            {
                MessageBox.Show("Phòng thi " + room + " không có trong file cấu hình!");
                return false;
            }
            if (IntPtr.Zero == (mDevHandle = zkfp2.OpenDevice(devideindex)))
            {
                MessageBox.Show("");
                return false;
            }
            if (IntPtr.Zero == (mDBHandle = zkfp2.DBInit()))
            {
                MessageBox.Show("Khởi tạo dữ liệu thất bại!");
                zkfp2.CloseDevice(mDevHandle);
                mDevHandle = IntPtr.Zero;
                return false;
            }
            RegisterCount = 0;
            cbRegTmp = 0;
            iFid = 1;
            for (int i = 0; i < 3; i++)
            {
                RegTmps[i] = new byte[2048];
            }
            byte[] paramValue = new byte[4];
            int size = 4;
            zkfp2.GetParameters(mDevHandle, 1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);
            size = 4;
            zkfp2.GetParameters(mDevHandle, 2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);
            FPBuffer = new byte[mfpWidth * mfpHeight];
            LoadDB();
            lstDev.Add(mDevHandle);
            lstRoomDev.Add(room);
            int roomid = 0;
            roomid = fingersv.GetIDRoomTest(room);
            Thread captureThread = new Thread(()=>DoCapture(mDevHandle,roomid));
            captureThread.IsBackground = true;
            lstThread.Add(captureThread);
            lstThread[lstThread.Count - 1].Start();
            bIsTimeToDie = false;
            return true;
        }
        public void DisposeDevice()
        {
            bIsTimeToDie = true;
            try
            {
                for (int i = 0; i < lstDev.Count; i++)
                {
                    
                        zkfp2.CloseDevice(lstDev[i]);
                }
                zkfp2.Terminate();
                lstDev = new List<IntPtr>();
                lstRoomDev = new List<string>();
            }
            catch { }
        }
        public void CloseDevice(string room)
        {
            bIsTimeToDie = true;
            try
            {
                for(int i=0;i<lstDev.Count;i++)
                {
                    if(lstRoomDev[i]==room)
                    {
                        //lstThread[i].cl
                        zkfp2.CloseDevice(lstDev[i]);
                        lstRoomDev.RemoveAt(i);
                        lstDev.RemoveAt(i);
                        return;
                    }
                }
            }
            catch { }
        }

        private void bnEnroll_Click(object sender, EventArgs e)
        {
            if (!IsRegister)
            {
                IsRegister = true;
                RegisterCount = 0;
                cbRegTmp = 0;

            }
            textRes.Text = "Đặt ngón tay cái của tay trái 3 lần lên máy quét!";
        }

        private void frmIdentifyFinger_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DisposeDevice();
            bIsTimeToDie = true;
            zkfp2.CloseDevice(mDevHandle);
            zkfp2.Terminate();
        }
    }
}
