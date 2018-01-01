using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libzkfpcsharp;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using CL.Persistance;
using CL.Services.Interface;
using CL.Services.Impl;
namespace RM.GetFinger
{
    public partial class frmGetFingerPrinter : Form
    {
        IntPtr mDevHandle = IntPtr.Zero;
        IntPtr mDBHandle = IntPtr.Zero;
        IntPtr FormHandle = IntPtr.Zero;
        bool bIsTimeToDie = false;
        bool IsRegister = false;
        bool bIdentify = true;
        byte[] FPBuffer;
        int RegisterCount = 0;
        const int REGISTER_FINGER_COUNT = 3;

        byte[][] RegTmps = new byte[3][];
        byte[] RegTmp = new byte[2048];
        byte[] CapTmp = new byte[2048];
        int cbCapTmp = 2048;
        int cbRegTmp = 0;
        int iFid = 1;
        int contestID = 0;
        private int mfpWidth = 0;
        private int mfpHeight = 0;

        const int MESSAGE_CAPTURED_OK = 0x0400 + 6;

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        //int contestantID = 125;
        IVerifyService fingersv;
        //ContestantService contestantsv;
        //FingerPrinterService fingersv;
        public frmGetFingerPrinter()
        {
            InitializeComponent();
        }
        public frmGetFingerPrinter(int id)
        {
            InitializeComponent();
            //contestantID = id;
        }
        private void bnInit_Click(object sender, EventArgs e)
        {
            cmbIdx.Items.Clear();
            int ret = zkfperrdef.ZKFP_ERR_OK;
            if ((ret = zkfp2.Init()) == zkfperrdef.ZKFP_ERR_OK)
            {
                int nCount = zkfp2.GetDeviceCount();
                if (nCount > 0)
                {
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
                        cmbIdx.Items.Add(ssn);
                        zkfp2.CloseDevice(mDevHandle);
                    }
                    cmbIdx.SelectedIndex = 0;
                    bnInit.Enabled = false;
                    bnFree.Enabled = true;
                    bnOpen.Enabled = true;
                }
                else
                {
                    zkfp2.Terminate();
                    MessageBox.Show("Không có thiết bị nào được kết nối!");
                }
            }
            else
            {
                MessageBox.Show("Khởi tạo cảm biến thất bại, ret=" + ret + " !");
            }
        }

        private void bnFree_Click(object sender, EventArgs e)
        {
            zkfp2.Terminate();
            cbRegTmp = 0;
            bnInit.Enabled = true;
            bnFree.Enabled = false;
            bnOpen.Enabled = false;
            bnClose.Enabled = false;
            bnEnroll.Enabled = false;
            bnVerify.Enabled = false;
            bnIdentify.Enabled = false;
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
        private void bnOpen_Click(object sender, EventArgs e)
        {
            int ret = zkfp.ZKFP_ERR_OK;
            if (IntPtr.Zero == (mDevHandle = zkfp2.OpenDevice(cmbIdx.SelectedIndex)))
            {
                MessageBox.Show("Mở cảm biến không thành công");
                return;
            }
            if (IntPtr.Zero == (mDBHandle = zkfp2.DBInit()))
            {
                MessageBox.Show("Init DB fail");
                zkfp2.CloseDevice(mDevHandle);
                mDevHandle = IntPtr.Zero;
                return;
            }
            bnInit.Enabled = false;
            bnFree.Enabled = true;
            bnOpen.Enabled = false;
            bnClose.Enabled = true;
            bnEnroll.Enabled = true;
            bnVerify.Enabled = true;
            bnIdentify.Enabled = true;
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
            //byte[] sn = new byte[100];
            //size = 100;
            //zkfp2.GetParameters(mDevHandle, 1103, sn, ref size);
            //byte[] name = new byte[100];
            //size = 100;
            //zkfp2.GetParameters(mDevHandle, 1101, name, ref size);
            //string ssn = ByteArr2String(sn);
            //string sname = ByteArr2String(name);
            //MessageBox.Show(ssn + "  " + sname);
            size = 4;
            zkfp2.GetParameters(mDevHandle, 2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

            FPBuffer = new byte[mfpWidth * mfpHeight];

            Thread captureThread = new Thread(new ThreadStart(DoCapture));
            captureThread.IsBackground = true;
            captureThread.Start();
            bIsTimeToDie = false;
            textRes.Text = "Mở thành công!";

        }


        private void DoCapture()
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

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    {
                        MemoryStream ms = new MemoryStream();
                        BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
                        Bitmap bmp = new Bitmap(ms);
                        this.picFPImg.Image = bmp;
                        //nếu là đăng ký
                        #region đăng ký
                        if (IsRegister)
                        {
                           
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
                                LoadDB();
                                int ret = zkfp.ZKFP_ERR_OK;
                                int fid = 0, score = 0;
                                ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
                                if (zkfp.ZKFP_ERR_OK == ret)
                                {                                   
                                    fingersv = new VerifyService();
                                    FINGERPRINT finger = fingersv.GetFingerprint(fid);
                                    if(finger!=null)
                                    {
                                        ImageConverter imgconvert = new ImageConverter();

                                        textRes.Text = "Xác thực Thành công, độ trùng khớp =" + score + "%!";
                                        txtContestantCode.Text = finger.CONTESTANT.ContestantCode;
                                        txtName.Text = finger.CONTESTANT.FullName;
                                        try
                                        {
                                            if(ptbImage.Image!=null)
                                            {
                                                ptbImage.Image=null;
                                            }
                                            ptbImage.Image = (Image)imgconvert.ConvertFrom(finger.CONTESTANT.Image);
                                        }
                                        catch
                                        { }
                                        //lấy thông tin khác
                                         
                                       CONTESTANTS_SHIFTS contestantShift = fingersv.GetContestant_Shift(GetTimeServer(),GetDateTimeServer(), finger.CONTESTANT.ContestantID);

                                        ROOMDIAGRAM roomDia = new ROOMDIAGRAM();
                                        if (contestantShift != null)
                                        {
                                            if (contestantShift.RoomDiagramID != null)
                                            {
                                                roomDia = fingersv.GetInfoRoomDia(Convert.ToInt32(contestantShift.RoomDiagramID));
                                                txtComputer.Text = roomDia.ComputerName.Substring(0,7);
                                                txtRoomtest.Text = roomDia.ROOMTEST.RoomTestName;
                                                txtSubject.Text = contestantShift.SCHEDULE.SUBJECT.SubjectName;
                                            }
                                            else
                                            {
                                                txtSubject.Text = txtRoomtest.Text = txtComputer.Text = "";
                                                txtComputer.Text = "Thí sinh không có chỗ!";

                                                #region phát âm thanh
                                                System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.warningSoundEffectSound);
                                                spwarning.Play();
                                                #endregion
                                                
                                            }

                                            #region Cập nhật trạng thái cho IsCheckFingerprint
                                            contestantShift.IsCheckFingerprint = 1;
                                            contestantShift.TimeCheck = Convert.ToInt32((DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalSeconds);
                                            if (fingersv.UpdateContestantShift(contestantShift))
                                            {
                                                textRes.Text = string.Format("Xác thực thành công, độ trùng khớp =" + score + "%!");
                                                #region phát âm thanh khi có kết quả đúng
                                                System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.grunz_success);
                                                sp.Play();
                                                #endregion
                                            }
                                            else
                                            {
                                                textRes.Text = string.Format("Điểm danh không thành công, điểm danh lại");
                                                #region phát âm thanh khi có kết quả sai
                                                System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.sai);
                                                spwarning.Play();
                                                #endregion
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            textRes.Text = string.Format("Không lấy được thông tin thí sinh");
                                            txtSubject.Text = txtRoomtest.Text = txtComputer.Text = "";
                                            #region phát âm thanh
                                            System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.warningSoundEffectSound);
                                            spwarning.Play();
                                            #endregion
                                        }
                                    }
                                    else
                                    {
                                        txtSubject.Text= txtRoomtest.Text =txtComputer.Text =txtName.Text=txtContestantCode.Text=textRes.Text = "";
                                        ptbImage.Image = null;
                                        #region phát âm thanh khi có kết quả sai
                                        System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.sai);
                                        spwarning.Play();
                                        #endregion
                                    }

                                    return;
                                }
                                else
                                {
                                    textRes.Text = "Thất bại, không có thí sinh nào có vân tay trên!";
                                    txtSubject.Text = txtRoomtest.Text = txtComputer.Text = txtName.Text = txtContestantCode.Text = textRes.Text = "";
                                    ptbImage.Image = null;
                                    #region phát âm thanh khi có kết quả sai
                                    System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.sai);
                                    spwarning.Play();
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
           DateTime dt= db.Database.SqlQuery<DateTime>(@"SELECT GetDate()").First();
            return (int)dt.TimeOfDay.TotalSeconds;
        }
        public static int GetDateTimeServer()
        {
            MTAQuizEntities db = new MTAQuizEntities();
            DateTime dt = db.Database.SqlQuery<DateTime>(@"SELECT GetDate()").First();
            return  Convert.ToInt32((dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalSeconds);
        }
        void LoadDB()
        {
            fingersv = new VerifyService();
            List<FINGERPRINT> lstfinger = new List<FINGERPRINT>();
            lstfinger = fingersv.ListFPOfShiftTime(1);
            int iFid = 0;
            foreach(FINGERPRINT item in lstfinger )
            {
                iFid = item.FingerprintID;
                RegTmp = item.FingerprintImage;
                zkfp2.DBAdd(mDBHandle, iFid, RegTmp);
            }
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FormHandle = this.Handle;
            #region kết nối
            cmbIdx.Items.Clear();
            int ret = zkfperrdef.ZKFP_ERR_OK;
            if ((ret = zkfp2.Init()) == zkfperrdef.ZKFP_ERR_OK)
            {
                int nCount = zkfp2.GetDeviceCount();
                if (nCount > 0)
                {
                    string[] lines;
                    if (File.Exists(@"C:\getfingerprinter.txt"))
                    {
                        lines = File.ReadAllLines(@"C:\getfingerprinter.txt");
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
                        if(lines.Length!=0)
                        for(int j=0;j<lines.Length;j++)
                        {
                            if(lines[j]==ssn) cmbIdx.Items.Add(lines[j+1]);
                        }
                        else cmbIdx.Items.Add(ssn);
                        zkfp2.CloseDevice(mDevHandle);
                    }
                    cmbIdx.SelectedIndex = 0;
                    bnInit.Enabled = false;
                    bnFree.Enabled = true;
                    bnOpen.Enabled = true;
                }
                else
                {
                    zkfp2.Terminate();
                    MessageBox.Show("Không có thiết bị nào được kết nối!");
                }
            }
            else
            {
                MessageBox.Show("Khởi tạo cảm biến thất bại, ret=" + ret + " !");
            }
            #endregion

            //#region mở cảm biến
            //ret = zkfp.ZKFP_ERR_OK;
            //if (IntPtr.Zero == (mDBHandle = zkfp2.DBInit()))
            //{
            //    MessageBox.Show("Khởi tạo dữ liệu thất bai!");
            //    return;
            //}
            //for (int i = 0; i < cmbIdx.Items.Count; i++)
            //{
            //    if (IntPtr.Zero == (lstmDevHandle[i] = zkfp2.OpenDevice(i)))
            //    {
            //        MessageBox.Show("Mở máy quét vân tay thất bại!");
            //        return;
            //    }
            //    byte[] paramValue = new byte[4];
            //    int size = 4;
            //    int width = 0;
            //    int height = 0;

            //    zkfp2.GetParameters(lstmDevHandle[i], 1, paramValue, ref size);
            //    zkfp2.ByteArray2Int(paramValue, ref width);
            //    size = 4;
            //    zkfp2.GetParameters(lstmDevHandle[i], 2, paramValue, ref size);
            //    zkfp2.ByteArray2Int(paramValue, ref height);
            //    mfpWidth.Add(width);
            //    mfpHeight.Add(height);
            //    byte[] FPBuffer = new byte[width * height];
            //    lstFPBuffer.Add(FPBuffer);

            //}

            //LoadDB();
            //bnInit.Enabled = false;
            //bnFree.Enabled = true;
            //bnOpen.Enabled = false;
            //bnClose.Enabled = true;
            //bnEnroll.Enabled = true;
            //bnVerify.Enabled = true;
            //bnIdentify.Enabled = true;
            //cbRegTmp = 0;
            //for (int i = 0; i < 3; i++)
            //{
            //    RegTmps[i] = new byte[2048];
            //}


            //Thread captureThread = new Thread(new ThreadStart(DoCapture));
            //captureThread.IsBackground = true;
            //captureThread.Start();
            //bIsTimeToDie = false;
            //textRes.Text = "Mở máy quét vân tay thành công! Mời nhập vân tay xác thực";
            //#endregion

        }

        private void bnClose_Click(object sender, EventArgs e)
        {
            bIsTimeToDie = true;

            Thread.Sleep(1000);
            zkfp2.CloseDevice(mDevHandle);
            bnInit.Enabled = false;
            bnFree.Enabled = true;
            bnOpen.Enabled = true;
            bnClose.Enabled = false;
            bnEnroll.Enabled = false;
            bnVerify.Enabled = false;
            bnIdentify.Enabled = false;
        }

        private void bnEnroll_Click(object sender, EventArgs e)
        {
           if (!IsRegister)
            {
                IsRegister = true;

                cbRegTmp = 0;
                
            }
            textRes.Text = "Mời nhập vân tay 3 lần!";
        }

        private void bnIdentify_Click(object sender, EventArgs e)
        {
            if (!bIdentify)
            {
                bIdentify = true;
                
            }
            textRes.Text = "Mời nhập vân tay!";
        }

        private void bnVerify_Click(object sender, EventArgs e)
        {
            if (bIdentify)
            {
                bIdentify = false;
                textRes.Text = "Please press your finger!";
            }
        }

        private void frmGetFingerPrinter_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            try
            {
                zkfp2.CloseDevice(mDevHandle);
                zkfp2.Terminate();
            }
             catch { }
            }

        private void picFPImg_Click(object sender, EventArgs e)
        {

        }
    }
    
}
