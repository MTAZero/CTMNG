using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CL.Persistance;

namespace GeneralManagement.Supervisors
{
    public partial class ucComputer : UserControl
    {
        public bool CheckedConfirm;
        public bool CheckedConfirmtoload = true;
        CONTESTANT _contestant = new CONTESTANT();
        CONTESTANTS_SHIFTS _contestantshift = new CONTESTANTS_SHIFTS();
        public int contestantid;
        public int contestanshifttid;
        int _divisionshiftid;
        int _roomdiagramid;
        public int status;

        public ucComputer(ROOMDIAGRAM roomdia, int divisionShiftID)
        {
            InitializeComponent();
            _divisionshiftid = divisionShiftID;
            _roomdiagramid = roomdia.RoomDiagramID;
            string fullnameCom = roomdia.ComputerName.Split('H')[0];
           

            if (roomdia.Status == 4002)
            {
                ptbImage.Image = Properties.Resources.monitor_hong;
                lbComputername.Text = fullnameCom;
                lbComputername.ForeColor = Color.Red;

            }
            else if (roomdia.Status ==4003)
            {
                ptbImage.Image = Properties.Resources.monitor_dubi;
                lbComputername.Text = fullnameCom ;
                lbComputername.ForeColor = Color.Yellow;
            }
            else
            {
                lbComputername.Text = fullnameCom;
            }
            LoadInfoContestant();
            // this.po.Y = _y;
        }
        CONTESTANTS_SHIFTS GetContestantShiftByComName(int divisionshiftID, int comid)
        {
            CONTESTANTS_SHIFTS result = new CONTESTANTS_SHIFTS();
            MTAQuizEntities Db = new MTAQuizEntities();

            try
            {

                result = (from obj in Db.CONTESTANTS_SHIFTS
                          where obj.DivisionShiftID == divisionshiftID && obj.RoomDiagramID == comid
                          select obj).FirstOrDefault();
                return result;

            }
            catch { return new CONTESTANTS_SHIFTS(); }
        }
        CONTESTANT GetInfoContestant(int contestantID)
        {
            CONTESTANT result = new CONTESTANT();
            MTAQuizEntities Db = new MTAQuizEntities();

            try
            {
                result = Db.CONTESTANTS.Where(x => x.ContestantID == contestantID).FirstOrDefault();
                return result;
            }
            catch
            {
                return new CONTESTANT();
            }

        }
        delegate void SetTextCallback(string text, Color color);
        private void SetText(string text,Color color)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lbStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text,color });
            }
            else
            {
                lbStatus.Text = text;
                lbStatus.BackColor = color;
            }
        }
        public void DisablecbCheckFP()
        {
            cBCheckFP.Enabled = false;
        }
        public void LoadStatusContestan()
        {
            _contestantshift = new CONTESTANTS_SHIFTS();
            _contestantshift = GetContestantShiftByComName(_divisionshiftid, _roomdiagramid);
            status = _contestantshift.Status;
            if (_contestantshift != null)
            {

                string statusStr = "";

                Color color = new Color();
                switch (_contestantshift.Status)
                {
                    case 3000:
                        statusStr = "Đăng nhập";
                        color = Color.SpringGreen;
                        break;
                    case 3001:
                        statusStr = "Đăng nhập lại ";
                        color = Color.GreenYellow;
                        break;
                    case 3002:
                        statusStr = "Sẵn sàng thi";
                        color = Color.DeepSkyBlue;
                        break;
                    case 3003:
                        statusStr = "Đang thi";
                        color = Color.DodgerBlue;
                        break;
                    case 3004:
                        statusStr = "Mất kết nối";
                        color = Color.Fuchsia;
                        break;
                    case 3005:
                        statusStr = "Hoàn thành thi";
                        color = Color.Turquoise;
                        break;
                    case 3006:
                        statusStr = "T/S Báo lỗi";
                        color = Color.Magenta;
                        break;
                    case 3007:
                        statusStr = "Đăng nhập thất bại";
                        color = Color.Red;
                        break;
                    case 3008:
                        statusStr = "Cảnh cáo";
                        color = Color.OrangeRed;// HotPink;
                        break;
                    case 3009:
                        statusStr = "Bắt đầu thi";
                        break;
                    case 3010:
                        statusStr = "Sẵn sàng nhận đề";
                        break;
                    case 3011:
                        statusStr = "Phát đề";
                        break;
                    case 4001:
                        statusStr = "Chưa đăng nhập";
                        color = Color.Yellow;
                        break;
                    case 4002:
                        statusStr = "Thay đổi";
                        color = Color.SpringGreen;
                        break;
                }
               SetText(statusStr,color);
                
            }
        }
        public void CountViolation()
        {
            _contestantshift = new CONTESTANTS_SHIFTS();
            _contestantshift = GetContestantShiftByComName(_divisionshiftid, _roomdiagramid);
            if (_contestantshift != null)
            {
                lblCountViolation.Text = " " + CountTimesViolation(contestanshifttid).ToString() + " lần";
                lblCountViolation.ForeColor = Color.IndianRed;
            }
        }

        public void LoadInfoContestant()
        {
            _contestantshift = new CONTESTANTS_SHIFTS(); 
            _contestantshift = GetContestantShiftByComName(_divisionshiftid, _roomdiagramid);
            
            if (_contestantshift != null)
            {
                status = _contestantshift.Status;
                contestantid = _contestantshift.ContestantID;
                contestanshifttid = _contestantshift.ContestantShiftID;
                _contestant = new CONTESTANT();
                _contestant = GetInfoContestant(_contestantshift.ContestantID);
               
                lbContestantCode.Text = _contestant.ContestantCode;
                lbContestantName.Text = _contestant.FullName;
                cBCheckFP.Enabled = CheckedConfirmtoload;
              
                #region status
                string statusStr = "";
                if (_contestantshift.IsCheckFingerprint ==1 || _contestantshift.IsCheckFingerprint == 2)
                {
                    ptbImage.Image = Properties.Resources.monitor;
                    cBCheckFP.Checked = true;
                    this.BackColor = Color.White;
                }
                else
                {
                    cBCheckFP.Checked = false;
                    this.BackColor = Color.Gray;
                    ptbImage.Image = Properties.Resources.monitor_khongcothisinh;
                }
                Color color = new Color();
                switch (_contestantshift.Status)
                {
                    case 3000:
                        statusStr = "Đăng nhập";
                        color = Color.SpringGreen;
                        break;
                    case 3001:
                        statusStr = "Đăng nhập lại ";
                        color = Color.GreenYellow;
                        break;
                    case 3002:
                        statusStr = "Sẵn sàng thi";
                        color = Color.DeepSkyBlue;
                        break;
                    case 3003:
                        statusStr = "Đang thi";
                        color = Color.DodgerBlue;
                        break;
                    case 3004:
                        statusStr = "Mất kết nối";
                        color = Color.Fuchsia;
                        break;
                    case 3005:
                        statusStr = "Hoàn thành thi";
                        color = Color.Turquoise;
                        break;
                    case 3006:
                        statusStr = "T/S Báo lỗi";
                        color = Color.Magenta;
                        break;
                    case 3007:
                        statusStr = "Đăng nhập thất bại";
                        color = Color.Red;
                        break;
                    case 3008:
                        statusStr = "Cảnh cáo";
                        color = Color.OrangeRed;// HotPink;
                        break;
                    case 3009:
                        statusStr = "Bắt đầu thi";
                        break;
                    case 3010:
                        statusStr = "Sẵn sàng nhận đề";
                        break;
                    case 3011:
                        statusStr = "Phát đề";
                        break;
                    case 4001:
                        statusStr = "Chưa đăng nhập";
                        color = Color.Yellow;
                        break;
                    case 4002:
                        statusStr = "Thay đổi";
                        color = Color.SpringGreen;
                        break;
                }
                lbStatus.Text = statusStr;
                lbStatus.BackColor = color;
                lblCountViolation.Text = " " + CountTimesViolation(contestanshifttid).ToString() + " lần";
                //this.BackColor = color;
                #endregion
            }
            else
            {
                lbContestantName.Text = "Không có thí sinh";
                this.BackColor = Color.Gray;
            }
        //    lblCountViolation.Text = " " + CountTimesViolation(contestanshifttid).ToString() + " lần";
        }
        public int CountTimesViolation(int contestantShiftID)
        {
            List<VIOLATIONS_CONTESTANTS> result = new List<VIOLATIONS_CONTESTANTS>();
            MTAQuizEntities Db = new MTAQuizEntities();

            int count = -1;
            try
            {
                result = (from obj in Db.VIOLATIONS_CONTESTANTS
                          where (obj.ContestantShiftID == contestantShiftID)
                          select obj).ToList();
                count = result.Count;
                return count;
            }
            catch
            {
                return count;
            }

        }
        private void ucComputer_Load(object sender, EventArgs e)
        {
            if (cBCheckFP.Checked == true)
            {
                CheckedConfirm = true;
            }
            else
            {
                CheckedConfirm = false;
            }
        }
        public event EventHandler RightClick;

        public event EventHandler ImageClick;
        protected void ptbImage_Click(object sender, EventArgs e)
        {
            // bubble the event up to the parent
            if (this.ImageClick != null)
                this.ImageClick(this, e);
        }
    
      
        private void cBCheckFP_Click(object sender, EventArgs e)
        {
            if (cBCheckFP.Checked == true)
            {
                CheckedConfirm = true;
            }
            else
            {
                CheckedConfirm = false;
            }
        }

    
        private void ptbImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.RightClick != null)
                    this.RightClick(this, e);
            }
        }
    }
}
