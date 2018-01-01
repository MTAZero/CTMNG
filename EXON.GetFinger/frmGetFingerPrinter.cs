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
using EXON.Common;
using EXON.Data.Services;
using EXON.Model.Models;
namespace EXON.GetFinger
{
    public partial class frmGetFingerPrinter : Form
    {
        IntPtr mDevHandle = IntPtr.Zero;
        IntPtr mDBHandle = IntPtr.Zero;
        IntPtr FormHandle = IntPtr.Zero;
        bool bIsTimeToDie = false;
        bool IsRegister = false;
        bool bIdentify = false;
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
        int contestantID = 125;
        IContestantService contestantsv;
        IFingerPrinterService fingersv;
        public frmGetFingerPrinter()
        {
            InitializeComponent();
        }
        public frmGetFingerPrinter(int id)
        {
            InitializeComponent();
            contestantID = id;
            LoadDevice();
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
                            LoadDB();
                            int ret = zkfp.ZKFP_ERR_OK;
                            int fid = 0, score = 0;
                            ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
                            if (zkfp.ZKFP_ERR_OK == ret)
                            {
                                fingersv = new FingerPrinterService();
                                FINGERPRINT finger = fingersv.GetById(fid);
                                if (finger != null)
                                {
                                    #region phát âm thanh khi có kết quả sai
                                    System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.sai);
                                    spwarning.Play();
                                    #endregion
                                    MessageBox.Show("Vân tay đã được đăng ký bởi thí sinh " + finger.CONTESTANT.REGISTER.FullName + "! SBD: " + finger.CONTESTANT.ContestantCode);
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
                                    fingersv = new FingerPrinterService();
                                    FINGERPRINT finger = new FINGERPRINT();
                                    finger.ContestantID = contestantID;
                                    finger.FingerprintImage = RegTmp;
                                    finger.FilePath = "";
                                    finger.TimeSaveFingerprint = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
                                    finger.Status = 1;
                                    fingersv.Add(finger);
                                    contestantsv.UpdateSTT(contestantID, 2);
                                    try
                                    {
                                        fingersv.Save();
                                        contestantsv.Save();
                                        #region phát âm thanh khi lấy vân tay thành công
                                        System.Media.SoundPlayer spwarning = new System.Media.SoundPlayer(Properties.Resources.succ);
                                        spwarning.Play();
                                        #endregion
                                        MessageBox.Show("Lấy mẫu vân tay thành công!");
                                        textRes.Text = "Lấy mẫu vân tay thành công!";
                                    }
                                    catch
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
                                LoadDB();
                                int ret = zkfp.ZKFP_ERR_OK;
                                int fid = 0, score = 0;
                                ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
                                if (zkfp.ZKFP_ERR_OK == ret)
                                {
                                    fingersv = new FingerPrinterService();
                                    FINGERPRINT finger = fingersv.GetById(fid);
                                    if (finger != null)
                                    {
                                        textRes.Text = "Xác thực Thành công, độ trùng khớp =" + score + "%!";
                                        lbSBD.Text = finger.CONTESTANT.ContestantCode;
                                        lbName.Text = finger.CONTESTANT.REGISTER.FullName;
                                    }

                                    return;
                                }
                                else
                                {
                                    textRes.Text = "Thất bại, không có thí sinh nào có vân tay trên";
                                    return;
                                }
                            }
                            else
                            {
                                int ret = zkfp2.DBMatch(mDBHandle, CapTmp, RegTmp);
                                if (0 < ret)
                                {
                                    //textRes.Text = "Match finger succ, score=" + ret + "!";
                                    return;
                                }
                                else
                                {
                                    //textRes.Text = "Match finger fail, ret= " + ret;
                                    return;
                                }
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
        void LoadDB()
        {
            fingersv = new FingerPrinterService();
            List<FINGERPRINT> lstfinger = new List<FINGERPRINT>();
            lstfinger = fingersv.GetAllinContest(contestID).ToList();
            int iFid = 0;
            foreach (FINGERPRINT item in lstfinger)
            {
                iFid = item.FingerprintID;
                RegTmp = item.FingerprintImage;
                zkfp2.DBAdd(mDBHandle, iFid, RegTmp);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        void LoadDevice()
        {
            FormHandle = this.Handle;
            contestantsv = new ContestantService();
            CONTESTANT contestant = contestantsv.GetById(contestantID);
            if (contestant != null)
            {
                lbSBD.Text = contestant.ContestantCode;
                lbName.Text = contestant.REGISTER.FullName;
                contestID = contestant.REGISTER.ContestID;
            }
            //khởi tạo

            int ret = zkfperrdef.ZKFP_ERR_OK;
            if ((ret = zkfp2.Init()) == zkfperrdef.ZKFP_ERR_OK)
            {
                int nCount = zkfp2.GetDeviceCount();
                if (nCount > 0)
                {

                }
                else
                {
                    zkfp2.Terminate();
                    MessageBox.Show("Không có thiết bị quét vân tay nào được kết nối!");
                    this.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Kết nối với thiết bị quét vân tay thất bại! Vui lòng kiểm tra lại kết nối!");
                this.Close();
                return;
            }

            //mở máy quét
            ret = zkfp.ZKFP_ERR_OK;
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

            Thread captureThread = new Thread(new ThreadStart(DoCapture));
            captureThread.IsBackground = true;
            captureThread.Start();
            bIsTimeToDie = false;
            textRes.Text = "Mở thiết bị quét vân tay thành công!";
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
        private void frmGetFingerPrinter_FormClosing(object sender, FormClosingEventArgs e)
        {
            bIsTimeToDie = true;
            zkfp2.CloseDevice(mDevHandle);
            zkfp2.Terminate();
        }

        private void picFPImg_Click(object sender, EventArgs e)
        {

        }
    }
}
