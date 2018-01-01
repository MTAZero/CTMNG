using CreateDB.Main;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateDB
{
    public partial class frmRoomConfig : MetroForm
    {
        List<Main.ROOMDIAGRAM> lstRoomdiagram = new List<Main.ROOMDIAGRAM>();
        int divisionShiftID;
        int roomTestID;
        ucComputerConfig uccomputer;
        Main.ROOMDIAGRAM roomdia;
        Main.Main db = new Main.Main();
        public frmRoomConfig()
        {
          
        }
        public frmRoomConfig(int _roomTestID)
        {
            this.roomTestID=_roomTestID;
            InitializeComponent();
            lblRoomTest.Text += db.ROOMTESTS.Where(x => x.RoomTestID == _roomTestID).FirstOrDefault().RoomTestName;
            LoadComputer();
            //roomdia = new ROOMDIAGRAM();
            //roomdia = uccomputer.roomdia; 
            LoadRoomdiagram();
            this.ShowInTaskbar = false;
        }
      
        private void frmRoomConfig_Load(object sender, EventArgs e)
        {
            if (roomdia != null)
            {
                roomdia = new Main.ROOMDIAGRAM();
                roomdia = uccomputer.roomdia;
            }
        }
        public Main.ROOMDIAGRAM ClickUC(Main.ROOMDIAGRAM _roomdiagram)
        {
            if (_roomdiagram != null)
            {
                roomdia = new Main.ROOMDIAGRAM();
                roomdia = _roomdiagram;
                LoadRoomdiagram();
            }
            return roomdia;

        }
        void LoadRoomdiagram()
        {
            if (roomdia != null)
            {
                txtComputerCode.Text = roomdia.ComputerCode;
                txtComputerName.Text = roomdia.ComputerName;
                if (roomdia.Status == 4001)
                {
                    cmbStatus.Text = "Tốt";
                }
                else
                {
                    cmbStatus.Text = "Hỏng";
                }
                }
        }

        void LoadComputer()
        {
            pnlDiagram.Controls.Clear();
            Point newP = new Point(10,10);
            lstRoomdiagram = db.ROOMDIAGRAMS.Where(x => x.RoomTestID ==roomTestID).ToList();
            if (lstRoomdiagram.Count != 0)
            {
                for (int i = 0; i < lstRoomdiagram.Count; i++)
                {

                    uccomputer = new ucComputerConfig(lstRoomdiagram[i]);
                    if (i % 6 == 0 && i != 0)
                    {
                        //newP = uccomputer.Location;
                        newP.X = 10;
                        newP.Y += uccomputer.Height + 20;
                    }
                    else if (i != 0)
                    {
                        newP.X += uccomputer.Width + 15;

                    }
                    uccomputer.Location = newP;
                    uccomputer.Name = lstRoomdiagram[i].ComputerName;
                    pnlDiagram.Controls.Add(this.uccomputer);


                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmImportRoom frm = new frmImportRoom(roomTestID);
            frm.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblNotifi.Text = "";
            LoadComputer();
        }
        int status;
        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtComputerName.Text.Trim() != "" && txtComputerCode.Text!="")
            {

                if (cmbStatus.Text.Trim() != null)
                {
                    if (cmbStatus.Text == "Tốt")
                    {
                        status = 4001;
                    }
                    else if (cmbStatus.Text == "Hỏng")
                    {
                        status = 4002;
                    }

                }
                Main.ROOMDIAGRAM roomdia = new Main.ROOMDIAGRAM();
                roomdia.RoomTestID = roomTestID;
                roomdia.ComputerCode = txtComputerCode.Text;
                roomdia.ComputerName = txtComputerName.Text;
                roomdia.Status = status;
               try
                {
                    db.ROOMDIAGRAMS.Add(roomdia);
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công");
                }
                catch
                {
                    MessageBox.Show("Có lỗi khi thêm");
                }                 
            }
            else
            {
                lblNotifi.Text = "Bạn cần nhập đầy đủ thông tin";
                lblNotifi.ForeColor = Color.Red;
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtComputerName.Text.Trim() != "")
            {
                if (cmbStatus.Text == "Tốt")
                {
                    status = 4001;
                }
                else if (cmbStatus.Text == "Hỏng")
                {
                    status = 4002;
                }
                if (UpdateRoomdiagram(roomTestID, txtComputerName.Text, status))
                {
                    MessageBox.Show("Cập nhập trạng thái cho máy thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else {
                    MessageBox.Show("Cập nhập trạng thái cho máy không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                lblNotifi.Text = "Bạn cần nhập đầy đủ thông tin";
                lblNotifi.ForeColor = Color.Red;
            }

        }
        public bool UpdateRoomdiagram(int roomtestID, string computername, int status)
        {
            db = new Main.Main();
            ROOMDIAGRAM rd = new ROOMDIAGRAM();
            ROOMTEST rt = new ROOMTEST();
            try
            {
                rd = db.ROOMDIAGRAMS.Single(x => x.ComputerName == computername && x.RoomTestID == roomtestID);
                rt = db.ROOMTESTS.Single(x => x.RoomTestID == roomtestID);

                rd.Status = status;
                db.Entry(rd).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Report.frmReportComputer frm = new Report.frmReportComputer(roomTestID);
            frm.ShowDialog();
        }
    }
}
