using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateDB
{
    public partial class MFrmMain : MetroForm
    {
        bool _checkMain = false;
        bool _checkExam = false;
        int _contestID;
        int _currentLocationID;
        int _currentRoomID;
        Main.Main m = new Main.Main();
        public MFrmMain()
        {
            InitializeComponent();
        }
        public MFrmMain(int contestid)
        {
            InitializeComponent();
            dgvRoomTest.AutoGenerateColumns = false;
            _contestID = contestid;
            AppSession.ContestID = contestid;
        }
        private void MFrmMain_Load(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Reload();
            
            ////if (!_checkExam)
            //{
            //    string s = ConfigurationManager.ConnectionStrings["RMDbContext"].ConnectionString;

            //    try
            //    {
            //        ConfigApp.Add("Main", s);

            //    }
            //    catch
            //    {
            //        ConfigApp.Remove("Main");
            //        ConfigApp.Add("Main", s);
            //    }
            //}
            //string a = ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
            m = new Main.Main();
            AppSession.ContestID = _contestID;

            Main.CONTEST con= m.CONTESTS.Where(x => x.ContestID == _contestID).FirstOrDefault();
            if(con!=null)
            {
                lbContestName.Text += con.ContestName;
                cboLocation.DataSource = m.LOCATIONS.Where(x => x.Status != 0 && x.ContestID == _contestID).ToList();
                cboLocation.DisplayMember = "LocationName";
                cboLocation.ValueMember = "LocationID";
                cboLocation.SelectedIndex = 0;
                AppSession.LocationID = int.Parse(cboLocation.SelectedValue.ToString());
                LoadDGVRoomtest();
            }
            
        }
        private void cboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AppSession.LocationID = int.Parse(cboLocation.SelectedValue.ToString());

            }catch
            { }
            LoadDGVRoomtest();
        }
        void LoadDGVRoomtest()
        {
            m = new Main.Main();
            try
            {
                _currentLocationID = int.Parse(cboLocation.SelectedValue.ToString());
                btnStart.Enabled = true;
                var lsroom = (
                     from r in m.ROOMTESTS
                     where r.LocationID == _currentLocationID && r.Status != 0
                     select new
                     {
                         RoomtestName = r.RoomTestName,
                         RoomtestID = r.RoomTestID,
                         btnconfig = "Cấu hình máy",
                         MaxsitMount = r.MaxSeatMount
                     }).ToList();
                dgvRoomTest.DataSource = lsroom;
                //_currentLocationID = contestid;
            }
            catch { }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            m = new Main.Main();
            List<Main.ROOMTEST> lstRoom;
            List<int> lstDivisionShiftID = new List<int>();
            lstRoom = m.ROOMTESTS.Where(z => z.LocationID == _currentLocationID).ToList();
            if(lstRoom!=null && lstRoom.Count!=0)
            {
                
                foreach(Main.ROOMTEST room in lstRoom)
                {
                    List<Main.DIVISION_SHIFTS> lstds = new List<Main.DIVISION_SHIFTS>();
                    lstds = m.DIVISION_SHIFTS.Where(x => x.RoomTestID == room.RoomTestID ).ToList();
                    foreach(Main.DIVISION_SHIFTS ds in lstds)
                    {
                        if(ds.Key!=null && ds.Key!="")
                            lstDivisionShiftID.Add(ds.DivisionShiftID);
                        else
                        {
                            MessageBox.Show("Túi đề của Ca thi " + ds.SHIFT.ShiftName + ", phòng thi " + ds.ROOMTEST.RoomTestName + " chưa được niêm phong!\nVui lòng niêm phong tất cả các túi đề thi ở địa điểm, sau đó tiến hành chuyển dữ liệu!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            if(lstDivisionShiftID.Count!=0)
            {
                if (MessageBox.Show("Trước khi chuyển dữ liệu, Dữ liệu trên Server thi sẽ được xóa sạch!\nBạn có chắc chắn muốn chuyển dữ liệu?", "Xác nhận",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmLoading frm = new frmLoading(lstDivisionShiftID);
                    frm.ShowDialog();

                    Main.CONTEST ct = new Main.CONTEST();
                    ct = m.CONTESTS.Where(x => x.ContestID == AppSession.ContestID).SingleOrDefault();
                    ct.Status = 7;
                    m.SaveChanges();
                }

            }
            else
            {
                MessageBox.Show("Không có ca thi nào!");
            }
        }

        private void dgvRoomTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                frmRoomConfig frm = new frmRoomConfig((int)dgvRoomTest.Rows[e.RowIndex].Cells["cID"].Value);
                frm.Show();
            }
        }

        private void dgvRoomTest_SelectionChanged(object sender, EventArgs e)
        {
            m = new Main.Main();
            try
            { 
                dgvRoomTest.CurrentRow.Selected = true;
                
            }
            catch(Exception ex)
            {
                string a = ex.Message;
            }
        }
        public DateTime ConvertIntToDate(double number)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(number);
        }
       string CheckKey(string key)
        {
            if (key==null || key=="")
            {
                return "Niêm phong";
            }else
            {
                return "In Khóa";
            }
        }

        private void dgvRoomTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _currentRoomID = (int)dgvRoomTest.CurrentRow.Cells["cID"].Value;
                LoadDGVDivisionShift();
            }
            catch(Exception ex)
            {
                string s = ex.Message;
            }
            
        }
        void LoadDGVDivisionShift()
        {
            List<Main.DIVISION_SHIFTS> lstdv = m.DIVISION_SHIFTS.Where(x => x.RoomTestID == _currentRoomID && x.Status != 0).ToList();
            var lstDivisionShift = (from s in lstdv
                                    select new
                                    {
                                        DivisionShiftID = s.DivisionShiftID,
                                        ShiftName = s.SHIFT.ShiftName,
                                        Date = ConvertIntToDate(s.SHIFT.ShiftDate),
                                        StartTime = ConvertIntToDate(s.SHIFT.StartTime).TimeOfDay,
                                        Roomtest = s.ROOMTEST.RoomTestName,
                                        //EndTime = ConvertIntToDate(s.EndTime).TimeOfDay,
                                        checkshift = CheckKey(s.Key)
                                    }).ToList();
            dgvDivisionShift.DataSource = lstDivisionShift;
        }
        private void dgvDivisionShift_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int id = (int)dgvDivisionShift.CurrentRow.Cells["cDivisionShiftID"].Value;
                if (dgvDivisionShift.CurrentCell.Value.ToString()=="Niêm phong")
                {
                    m = new Main.Main();
                    string key = new Random().Next(100000, 999999).ToString();
                    Encrypter _encrypt = new Encrypter(key);
                    Main.DIVISION_SHIFTS dsquiz = new Main.DIVISION_SHIFTS();
                    
                    dsquiz = m.DIVISION_SHIFTS.Where(x => x.DivisionShiftID ==id ).SingleOrDefault();
                    dsquiz.Key = key;
                    try
                    {
                        m.SaveChanges();
                    }
                   catch { }
                }
                Report.frmReportKey frm = new Report.frmReportKey(id);
                frm.ShowDialog();
                LoadDGVDivisionShift();
            }
        }
    }
}
