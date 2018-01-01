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
using CreateDB.Quiz;
using System.Configuration;
using System.Data.SqlClient;

namespace CreateDB
{
    public partial class frmMain : Form
    {
        bool _checkMain = false;
        bool _checkExam = false;
        int contestid = 0;
        public frmMain()
        {
            InitializeComponent();
        }
        private void btnCheckExam_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            if (!_checkExam)
            {
                string s = String.Format("data source={0};initial catalog={1};persist security info=True;user id={2};password={3};MultipleActiveResultSets=True;App=EntityFramework", txtIPThi.Text, txtDBThi.Text, txtUserThi.Text, txtPassThi.Text);

                try
                {
                    ConfigApp.Add("Quiz", s);
                    
                }
                catch
                {
                    ConfigApp.Remove("Quiz");
                    ConfigApp.Add("Quiz", s);
                }
            }          
            string conn = ConfigurationManager.ConnectionStrings["Quiz"].ConnectionString;
            SqlConnection connect = new SqlConnection(conn);
            try
            {
                connect.Open();
                MessageBox.Show("Kết nối server thi thành công!");
                _checkExam = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Kết nối server thi thất bại\n" + ex.ToString());
                ConfigApp.Remove("Quiz");
            }
            finally
            {
                connect.Close();
            }
            
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!_checkMain)
            {
                string ss = String.Format("data source={0};initial catalog={1};persist security info=True;user id={2};password={3};MultipleActiveResultSets=True;App=EntityFramework", txtIPServerMain.Text, txtDBServerMain.Text, txtUserMain.Text, txtPassMain.Text);
                try
                {
                    ConfigApp.Add("Main", ss);
                }
                catch
                {
                    ConfigApp.Remove("Main");
                    ConfigApp.Add("Main", ss);
                }
                
            }
            string conn2 = ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
            SqlConnection connect2 = new SqlConnection(conn2);
            try
            {
                connect2.Open();
                MessageBox.Show("Kết nối server trung tâm thành công!");
                _checkMain = true;
               
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Kết nối server trung tâm thất bại\n" + ex.ToString());
                ConfigApp.Remove("Main");
            }
            finally
            {
                connect2.Close();
            }
            Properties.Settings.Default.Reload();
            if (_checkExam && _checkMain)
            {
                Main.Main m = new Main.Main();
                cboContest.DataSource = m.CONTESTS.Where(x=>x.Status>=6).ToList();
                cboContest.DisplayMember = "ContestName";
                cboContest.ValueMember = "ContestID";
                btnCheckExam.Enabled = false;
                btnReTransData.Enabled = true;
                btnTranferData.Enabled = true;
                btnPrint.Visible = true;
            }
                
        }

        private void btnTranferData_Click(object sender, EventArgs e)
        {
            if (_checkMain && _checkExam)
            {
               // List<int> lsDSID = new List<int>();
                //Quiz.Quiz quiz = new Quiz.Quiz();
                Main.Main main = new Main.Main();
                List<int> lsDS = new List<int>();
                List<Quiz.DIVISION_SHIFTS> ls = new List<Quiz.DIVISION_SHIFTS>();
                foreach(DataGridViewRow i in dgvRoomtest.Rows )
                {
                    if ((bool)i.Cells["check"].Value==true)
                    {
                        foreach (DataGridViewRow item in dgvShift.Rows)
                        {  
                            if((bool)item.Cells["checkshift"].Value == true)
                            {
                                Main.DIVISION_SHIFTS ds = new Main.DIVISION_SHIFTS();
                                int id = int.Parse(i.Cells["RoomtestID"].Value.ToString());
                                int ids = int.Parse(item.Cells["ShiftID"].Value.ToString());
                                ds = main.DIVISION_SHIFTS.Where(x => x.RoomTestID == id && x.ShiftID==ids).FirstOrDefault();
                                if(ds!=null)
                                lsDS.Add(ds.DivisionShiftID);
                            }  
                        }
                         
                    }
                }
                //btnTranferData.Enabled = btnDecrypt.Enabled = false;
                
                //lsDS.Add(int.Parse(txtContestID.Text));
                if(lsDS.Count>0)
                {
                    if (MessageBox.Show("Trước khi chuyển dữ liệu, Dữ liệu trên Server thi sẽ được xóa sạch!\nBạn có chắc chắn muốn chuyển dữ liệu?", "Xác nhận",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmLoading frm = new frmLoading(lsDS);
                        frm.ShowDialog();

                        Main.CONTEST ct = new Main.CONTEST();
                        ct = main.CONTESTS.Where(x => x.ContestID == AppSession.ContestID).SingleOrDefault();
                        ct.Status = 7;
                        main.SaveChanges();
                        frmReportKey frmrpt = new frmReportKey();
                        frmrpt.ShowDialog();
                    }
                       
                }
                else
                {
                    MessageBox.Show("Không có ca thi nào!");
                }
                
                //btnTranferData.Enabled = btnDecrypt.Enabled  = true;
            }
            else
            {
                MessageBox.Show("Kiểm tra lại kết nối server!");
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
        private void btnAgain_Click(object sender, EventArgs e)
        {

            ConfigApp.Remove("Main");
            ConfigApp.Remove("Quiz");
            btnCheckExam.Enabled = true;
            _checkExam = _checkMain = false;
            btnReTransData.Enabled = false;
            btnPrint.Visible = false;
        }
        private void cboContest_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.Main m = new Main.Main();
            try
            {
                contestid = int.Parse(cboContest.SelectedValue.ToString());
                AppSession.ContestID = contestid;
            }
            catch { }
            AppSession.ContestID = contestid;
            AppSession.ContestName = cboContest.Text;
            var lsshift = (from s in m.SHIFTS.Where(x => x.ContestID == contestid && x.Status!=0).ToList()

                                   select new
                                   {
                                       ShiftID = s.ShiftID,
                                       ShiftName = s.ShiftName,
                                       Date = ConvertIntToDate(s.ShiftDate),
                                       StartTime = ConvertIntToDate(s.StartTime).TimeOfDay,
                                       //EndTime = ConvertIntToDate(s.EndTime).TimeOfDay,
                                       checkshift=false
                                   }).ToList();
            dgvShift.Rows.Clear();
            for (int i = 0; i < lsshift.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = (DataGridViewRow)dgvShift.RowTemplate.Clone();
                dgvShift.Rows.Add(row);
                dgvShift.Rows[i].Cells["cSTT2"].Value = i + 1;
                dgvShift.Rows[i].Cells["ShiftID"].Value = lsshift[i].ShiftID;
                dgvShift.Rows[i].Cells["ShiftName"].Value = lsshift[i].ShiftName;
                dgvShift.Rows[i].Cells["Date"].Value = lsshift[i].Date.ToShortDateString();
                dgvShift.Rows[i].Cells["StartTime"].Value = lsshift[i].StartTime;
                dgvShift.Rows[i].Cells["checkshift"].Value = lsshift[i].checkshift;

            }
            cboLocation.DataSource = m.LOCATIONS.Where(x => x.Status != 0 && x.ContestID == contestid).ToList();
            cboLocation.DisplayMember = "LocationName";
            cboLocation.ValueMember = "LocationID";
           
        }
        
        public int ConvertDateToInt(DateTime dt)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = dt.ToUniversalTime() - origin;
            return Convert.ToInt32(Math.Floor(diff.TotalSeconds));
        }

        //convert second to datetime
        public DateTime ConvertIntToDate(double number)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(number);
        }

        private void dgvDivisionShift_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnTranferData.Enabled = true;
            //txtContestID.Text=dgvDivisionShift.CurrentRow.Cells["DivisionShiftID"].Value.ToString();
            AppSession.DivisionShiftID = int.Parse(txtContestID.Text);
        }

        private void dgvShift_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
           //     dgvShift.CurrentRow.Selected = true;
            }
            catch
            { }
        }

        private void dgvDivisionShift_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
             //   dgvDivisionShift.CurrentRow.Selected = true;
            }
            catch
            { }
        }

        private void btnChuyenNguoc_Click(object sender, EventArgs e)
        {
            //    groupBox3.Visible = false;
            //    btnReTransData.Visible = true;
            //    btnAgain_Click(sender, e);
            //this.Height = 650;
            frmReTrans frm = new frmReTrans();
            frm.Show();
        }

        private void cboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.Main m = new Main.Main();
            AppSession.LocationID = (int)cboLocation.SelectedValue;
            var lsroom = (
                          from r in m.ROOMTESTS
                          where  r.LocationID== AppSession.LocationID && r.Status != 0
                          select new
                          {
                              RoomtestName = r.RoomTestName,
                              RoomtestID = r.RoomTestID,
                              Location=r.LOCATION.LocationName,
                              check = false
                          }).ToList();
            dgvRoomtest.Rows.Clear();
            for (int i = 0; i < lsroom.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = (DataGridViewRow)dgvRoomtest.RowTemplate.Clone();
                dgvRoomtest.Rows.Add(row);
                dgvRoomtest.Rows[i].Cells["cSTT"].Value = i+1;
                dgvRoomtest.Rows[i].Cells["RoomtestID"].Value = lsroom[i].RoomtestID;
                dgvRoomtest.Rows[i].Cells["RoomtestName"].Value = lsroom[i].RoomtestName;
                dgvRoomtest.Rows[i].Cells["Location"].Value = lsroom[i].Location;
                dgvRoomtest.Rows[i].Cells["check"].Value = lsroom[i].check;

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReportKey frm = new frmReportKey();
            frm.ShowDialog();
        }

        private void btnReTransData_Click(object sender, EventArgs e)
        {

        }
    }
}
