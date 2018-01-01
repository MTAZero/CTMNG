//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using libzkfpcsharp;
//using System.Runtime.InteropServices;
//using System.Threading;
//using System.IO;
//using CL.Persistance;
//using CL.Services.Interface;
//using CL.Services.Impl;

//namespace GeneralManagement.GetFingerPrinter
//{
//    public class InitFingerSDK
//    {
//        List<IntPtr> lstmDevHandle = new List<IntPtr>();
//        IntPtr mDBHandle = IntPtr.Zero;
//        IntPtr FormHandle = IntPtr.Zero;
//        bool bIsTimeToDie = false;
//        bool IsRegister = false;
//        bool bIdentify = true;
//        List<byte[]> lstFPBuffer = new List<byte[]>();
//        const int REGISTER_FINGER_COUNT = 3;

//        byte[][] RegTmps = new byte[3][];
//        byte[] RegTmp = new byte[2048];
//        byte[] CapTmp = new byte[2048];
//        int cbCapTmp = 2048;
//        int cbRegTmp = 0;
//        private List<int> mfpWidth = new List<int>();
//        private List<int> mfpHeight = new List<int>();
//        int currentindex;
//        const int MESSAGE_CAPTURED_OK = 0x0400 + 6;

//        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
//        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
//        int contestantID = 125;
//        //IVerifyService contestantsv;
//        IVerifyService fingersv;
//        public InitFingerSDK()
//        {

//        }
//        public void InitDevice()
//        {
//            int ret = zkfperrdef.ZKFP_ERR_OK;
//            if ((ret = zkfp2.Init()) == zkfperrdef.ZKFP_ERR_OK)
//            {
//                int nCount = zkfp2.GetDeviceCount();
//                if (nCount > 0)
//                {
//                    //lstmDevHandle = new List<IntPtr>(nCount);
//                    for (int i = 0; i < nCount; i++)
//                    {

//                        IntPtr mDevHandle = IntPtr.Zero;
//                        lstmDevHandle.Add(mDevHandle);

//                        if (IntPtr.Zero == (lstmDevHandle[i] = zkfp2.OpenDevice(i)))
//                        {
//                            break;
//                        }
//                        byte[] sn = new byte[100];
//                        int size = 100;
//                        zkfp2.GetParameters(lstmDevHandle[i], 1103, sn, ref size);
//                        string ssn = ByteArr2String(sn);
                       
//                        zkfp2.CloseDevice(lstmDevHandle[i]);
//                    }
                  
//                }
//                else
//                {
//                    zkfp2.Terminate();
//                    MessageBox.Show("Không có cảm biến nào được kết nối!");
//                }
//            }
//            else
//            {
//                MessageBox.Show("Khởi tạo cảm biến thất bại!, ret=" + ret + " !");
//            }

//            #region mở cảm biến
//            ret = zkfp.ZKFP_ERR_OK;
//            if (IntPtr.Zero == (mDBHandle = zkfp2.DBInit()))
//            {
//                MessageBox.Show("Kết nối máy quét vân tay thất bại!");
//                return;
//            }
//            for (int i = 0; i < cmbIdx.Items.Count; i++)
//            {
//                if (IntPtr.Zero == (lstmDevHandle[i] = zkfp2.OpenDevice(i)))
//                {
//                    MessageBox.Show("Mở máy quét vân tay thất bại!");
//                    return;
//                }
//                byte[] paramValue = new byte[4];
//                int size = 4;
//                int width = 0;
//                int height = 0;

//                zkfp2.GetParameters(lstmDevHandle[i], 1, paramValue, ref size);
//                zkfp2.ByteArray2Int(paramValue, ref width);
//                size = 4;
//                zkfp2.GetParameters(lstmDevHandle[i], 2, paramValue, ref size);
//                zkfp2.ByteArray2Int(paramValue, ref height);
//                mfpWidth.Add(width);
//                mfpHeight.Add(height);
//                byte[] FPBuffer = new byte[width * height];
//                lstFPBuffer.Add(FPBuffer);

//            }

//            LoadDB();
          
//            cbRegTmp = 0;
//            for (int i = 0; i < 3; i++)
//            {
//                RegTmps[i] = new byte[2048];
//            }


//            Thread captureThread = new Thread(new ThreadStart(DoCapture));
//            captureThread.IsBackground = true;
//            captureThread.Start();
//            bIsTimeToDie = false;
//            textRes.Text = "Mở máy quét vân tay thành công! Mời nhập vân tay xác thực";
//            #endregion
//        }
//        string ByteArr2String(byte[] b)
//        {
//            StringBuilder outSb = new StringBuilder(b.Length);
//            char c;
//            int i;
//            for (i = 0; i < b.Length; i++)
//            {
//                if (b[i] == 0) break;
//                c = (char)b[i];
//                outSb.Append(c);
//            }
//            return outSb.ToString().Substring(1, i - 1);
//        }
//        void LoadDB()
//        {
//            fingersv = new VerifyService();
//            List<FINGERPRINT> lstfinger = new List<FINGERPRINT>();
//            lstfinger = fingersv.ListFPOfShiftTime(GetTimeServer(), GetDateTimeServer());
//            int iFid = 0;
//            foreach (FINGERPRINT item in lstfinger)
//            {
//                iFid = item.FingerprintID;
//                RegTmp = item.FingerprintImage;
//                zkfp2.DBAdd(mDBHandle, iFid, RegTmp);
//            }

//        }
//        private void DoCapture()
//        {
//            while (!bIsTimeToDie)
//            {
//                cbCapTmp = 2048;
//                int ret = 0;
//                try
//                {
//                    for (int i = 0; i < cmbIdx.Items.Count; i++)
//                    {
//                        ret = zkfp2.AcquireFingerprint(lstmDevHandle[i], lstFPBuffer[i], CapTmp, ref cbCapTmp);
//                        if (ret == zkfp.ZKFP_ERR_OK)
//                        {
//                            currentindex = i;
//                            SendMessage(FormHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
//                            break;
//                        }
//                        Thread.Sleep(200);

//                    }
//                }
//                catch { }
//            }
//        }
//    }
//}
