using CL.Persistance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneralManagement.Supervisors;
using GeneralManagement.Bus;
using MetroFramework.Forms;
using CL.Services.Interface;
using CL.Services.Impl;

namespace GeneralManagement.Supervisors
{
    public partial class frmRoomConfig : MetroForm
    {
        IRomtestService roomService = new RoomtestService();
        List<ROOMDIAGRAM> lstRoomdiagram = new List<ROOMDIAGRAM>();
        int divisionShiftID;
        int roomTestID;
        ucComputerConfig uccomputer;
      ROOMDIAGRAM roomdia;

        public frmRoomConfig()
        {
          
        }
        public frmRoomConfig(int _roomTestID)
        {
          
            InitializeComponent();
            this.roomTestID=_roomTestID;
            lblRoomTest.Text += BusALL.Instance.GetNameRoomTest(_roomTestID);
            LoadComputer();
            //roomdia = new ROOMDIAGRAM();
            //roomdia = uccomputer.roomdia; 
            LoadRoomdiagram();
        }
      
        private void frmRoomConfig_Load(object sender, EventArgs e)
        {
            if (roomdia != null)
            {
                roomdia = new ROOMDIAGRAM();
                roomdia = uccomputer.roomdia;
            }
        }
        public ROOMDIAGRAM ClickUC(ROOMDIAGRAM _roomdiagram)
        {
            if (_roomdiagram != null)
            {
                roomdia = new ROOMDIAGRAM();
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
            lstRoomdiagram = BusALL.Instance.GetListRoomdiagram(roomTestID);
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

        private void btnArrange_Click(object sender, EventArgs e)
        {

        }

        private void grbSendToOne_Enter(object sender, EventArgs e)
        {

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
                if (BusALL.Instance.AddRoomdiagram(roomTestID, txtComputerName.Text, txtComputerCode.Text, status))
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
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
                if (BusALL.Instance.UpdateRoomdiagram(roomTestID, txtComputerName.Text, status))
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

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            roomService.CheckComputer(roomTestID);
            LoadComputer();
        }
    }
}
