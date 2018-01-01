using ContestManagementVer2.Main;
using EXON.Common;
using EXON.Data.Services;
using EXON.Main.Module;
using EXON_EM.Data;
using EXON_EM.Data.Model;
using EXON_EM.Data.Service;
using EXON_ExamManagement.UC;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EXON_ExamManagement
{
    public partial class FrmMain : MetroForm
    {
        private int index = 0, index1 = 0;
        public object FrmLapKeHoachThi { get; private set; }

        #region Constructor

        public FrmMain()
        {
            InitializeComponent();
            InitializeLogin();
        }

        #endregion Constructor

        #region LoadForm
        void UpdateContestStatus()
        {
            ContestService _contestService = new ContestService();
            int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
            var contest = _contestService.GetById(idKiThi);

            List<MetroButton> listButtonControl = new List<MetroButton>
            {
                btnLapKeHoach,
                btnDangKiThi,
                btnSinhDeThiGoc,
                btnXepLich,
                btnSinhDeThi,
                btnChuanBiThi,
                btnToChucThi
            };
            foreach (MetroButton b in listButtonControl)
                b.Enabled = false;
            int endEnable = 0;
            switch ((ContestStatus)(contest.Status))
            {
                case ContestStatus.New:
                    endEnable = 1;
                    break;
                case ContestStatus.Accepted:
                    endEnable = 2;
                    break;
                case ContestStatus.DuringNotShit:
                    endEnable = 3;
                    break;
                case ContestStatus.DuringNotTest:
                    endEnable = 4;
                    break;
                case ContestStatus.DuringHaveTest:
                    endEnable = 5;
                    break;
                case ContestStatus.Done:
                    endEnable = 6;
                    break;
                case ContestStatus.Cancel:
                    endEnable = 0;
                    break;
            }
            for (int i = 0; i <= endEnable; i++)
            {
                listButtonControl[i].Enabled = true;
            }
        }
        private void LoadInitControl()
        {
            List<STAFFS_POSITIONS> staffpositions = new Contest_Service().GetStaffPosition(BaseControl.CurrentStaffId);
            if (staffpositions != null)
            {
                foreach (STAFFS_POSITIONS item in staffpositions)
                {
                    if (item.POSITION.Permission == 1)
                    {
                        btnLapKeHoach.Enabled = btnDangKiThi.Enabled = btnSinhDeThi.Enabled = btnSinhDeThiGoc.Enabled = btnChuanBiThi.Enabled = btnToChucThi.Enabled = btnXepLich.Enabled = true;
                    }
                    else
                    {
                        switch (item.POSITION.PositionCode)
                        {
                            case "TLKT":
                                btnLapKeHoach.Enabled = true;
                                btnChuanBiThi.Enabled = true;
                                btnSinhDeThi.Enabled = true;
                                btnXepLich.Enabled = true;
                                break;
                            case "CBTN":
                                btnDangKiThi.Enabled = true;
                                break;
                            case "GV":
                                btnSinhDeThiGoc.Enabled = true;
                                break;
                            case "CNBM":
                                btnSinhDeThiGoc.Enabled = true;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void LoadDgvContest()
        {
            if (btnDanhSachKeHoach.Text == "     Các kì thi đang diễn ra")
            {
                try
                {
                    List<CONTEST> dsCuocThi = new Contest_Service().getAll().Where(p => p.Status != 2).ToList();
                    //if (cbxLoai.SelectedIndex == 0)
                    //{
                    // kì thi đang diễn ra
                    //dsCuocThi = dsCuocThi.Where(p => p.Status != 3 && p.Status != 2).ToList();
                    //}

                    //if (cbxLoai.SelectedIndex == 1)
                    //{
                    //    // kì thi đã kết thúc
                    //    dsCuocThi = dsCuocThi.Where(p => p.Status ==3 ).ToList();
                    //}

                    //if (cbxLoai.SelectedIndex == 2)
                    //{
                    //    // kì thi theo khoảng thời gian
                    //    dsCuocThi = dsCuocThi
                    //                .Where(p => Helper.ConvertUnixToDateTime((int)p.BeginDate) >= dateBatDau.Value)
                    //                .Where(p => Helper.ConvertUnixToDateTime((int)p.EndDate) <= dateKetThuc.Value)
                    //                .ToList();
                    //}

                    int i = 0;
                    dgvContest.DataSource = dsCuocThi
                                            .Select(p => new
                                            {
                                                ID = p.ContestID,
                                                STT = ++i,
                                                TenKiThi = p.ContestName,
                                                TrangThai = Helper.TrangThaiKiThi(p.Status),
                                                Status = p.Status
                                            })
                                            .ToList();

                    // load Color
                    foreach (DataGridViewRow row in dgvContest.Rows)
                    {
                        int gt = (int)Convert.ToInt32(row.Cells["Status"].Value);
                        row.DefaultCellStyle.BackColor = ThamSoHeThong.getMauCuocThi(gt);
                    }

                    // Load Index
                    index = index1;
                    dgvContest.Rows[index].Cells["STT"].Selected = true;
                    dgvContest.Select();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    return;
                }

            }
            else
            {
                try
                {
                    List<CONTEST> dsCuocThi = new Contest_Service().getAll().Where(p => p.Status != 2).ToList();
                    //if (cbxLoai.SelectedIndex == 0)
                    //{
                    // kì thi đang diễn ra
                    dsCuocThi = dsCuocThi.Where(p => p.Status != 3 && p.Status != 2).ToList();
                    //}

                    //if (cbxLoai.SelectedIndex == 1)
                    //{
                    //    // kì thi đã kết thúc
                    //    dsCuocThi = dsCuocThi.Where(p => p.Status ==3 ).ToList();
                    //}

                    //if (cbxLoai.SelectedIndex == 2)
                    //{
                    //    // kì thi theo khoảng thời gian
                    //    dsCuocThi = dsCuocThi
                    //                .Where(p => Helper.ConvertUnixToDateTime((int)p.BeginDate) >= dateBatDau.Value)
                    //                .Where(p => Helper.ConvertUnixToDateTime((int)p.EndDate) <= dateKetThuc.Value)
                    //                .ToList();
                    //}

                    int i = 0;
                    dgvContest.DataSource = dsCuocThi
                                            .Select(p => new
                                            {
                                                ID = p.ContestID,
                                                STT = ++i,
                                                TenKiThi = p.ContestName,
                                                TrangThai = Helper.TrangThaiKiThi(p.Status),
                                                Status = p.Status
                                            })
                                            .ToList();

                    // load Color
                    foreach (DataGridViewRow row in dgvContest.Rows)
                    {
                        int gt = (int)Convert.ToInt32(row.Cells["Status"].Value);
                        row.DefaultCellStyle.BackColor = ThamSoHeThong.getMauCuocThi(gt);
                    }
                    btnDanhSachKeHoach.Text = "     Xem lại các kì thi";
                    // Load Index
                    index = index1;
                    dgvContest.Rows[index].Cells["STT"].Selected = true;
                    dgvContest.Select();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    return;
                }

            }

        }
        void UpdateStatusRegistedContest()
        {
            Contest_Service consv = new Contest_Service();
            List<CONTEST> lstcon = new List<CONTEST>();
            lstcon = consv.getAll().Where(p => p.Status == 7).ToList();
            foreach (CONTEST con in lstcon)
            {
                //if(con.EndRegistration< DateTimeHelpers.ConvertDateTimeToUnix( SystemTimeService.Now))
                //{
                //    con.Status = 4;
                //    try
                //    {
                //        consv.Update(con);
                //        consv.Save();
                //    }
                //    catch
                //    {

                //    }
                //}
                if (con.EndDate < DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now))
                {
                    con.Status = 3;
                    try
                    {
                        consv.Update(con);
                        consv.Save();
                    }
                    catch
                    {

                    }
                }

            }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadInitControl();
            UpdateStatusRegistedContest();
            //UpdateStatusRegistedContest();
            LoadDgvContest();
            LoadLabelTime();
        }

        #endregion LoadForm
        void LoadLabelTime()
        {
            try
            {
                int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
                CONTEST con = new Contest_Service().Find(idKiThi);
                lbRegisterFrom.Text = "Từ : " + DateTimeHelpers.ConvertUnixToDateTime(con.BeginRegistration).ToString("HH:mm:ss dd/MM/yyyy");
                lbRegisterTo.Text = "Đến: " + DateTimeHelpers.ConvertUnixToDateTime(con.EndRegistration).ToString("HH:mm:ss dd/MM/yyyy");
                lbSinhDeGocFrom.Text = "Từ : " + DateTimeHelpers.ConvertUnixToDateTime(con.BeginRegistration).ToString("HH:mm:ss dd/MM/yyyy");
                lbSinhDeGocTo.Text = "Đến: " + DateTimeHelpers.ConvertUnixToDateTime(con.CreatedQuestionStartDate).ToString("HH:mm:ss dd/MM/yyyy");
                lbXepLichThiFrom.Text = "Từ : " + DateTimeHelpers.ConvertUnixToDateTime(con.EndRegistration).ToString("HH:mm:ss dd/MM/yyyy");
                lbXepLichThiTo.Text = "Đến: " + DateTimeHelpers.ConvertUnixToDateTime(con.CreatedQuestionStartDate).ToString("HH:mm:ss dd/MM/yyyy");
                lbSinhDeThiFrom.Text = "Từ : " + DateTimeHelpers.ConvertUnixToDateTime(con.CreatedQuestionStartDate).ToString("HH:mm:ss dd/MM/yyyy");
                lbSinhDeThiTo.Text = "Đến: " + DateTimeHelpers.ConvertUnixToDateTime(con.CreatedQuestionEndDate).ToString("HH:mm:ss dd/MM/yyyy");
                lbChuanBiThiFrom.Text = "Từ : " + "Sau khi sinh đề thi xong.";
                lbChuanBiThiTo.Text = "Đến: " + "Trước khi thi.";
                lbGiamSatFrom.Text = "Từ : " + DateTimeHelpers.ConvertUnixToDateTime((int)con.BeginDate).ToString("HH:mm:ss dd/MM/yyyy");
                lbGiamSatTo.Text = "Đến: " + DateTimeHelpers.ConvertUnixToDateTime((int)con.EndDate).ToString("HH:mm:ss dd/MM/yyyy");
            }
            catch
            {
                MessageBox.Show("Chưa chọn kì thi",
                               "Thông báo",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }
        #region Sự kiện

        private void btnLapKeHoachThi_Click(object sender, EventArgs e)
        {
            ContestManagementVer2.Main.Start z = new ContestManagementVer2.Main.Start();
            z.LapKeHoachThi(BaseControl.CurrentStaffId);
            LoadDgvContest();
        }

        private void btnDanhSachKeHoach_Click(object sender, EventArgs e)
        {
        }

        private void btnQuanLyKiThi_Click(object sender, EventArgs e)
        {
        }

        #endregion Sự kiện

        private EXON.Main.Module.Forms.FrmLogin login;

        private void InitializeLogin()
        {

            if (login == null) login = new EXON.Main.Module.Forms.FrmLogin();
            this.Hide();
            login.ShowDialog();
            if (login.LoginStatus == EXON.Common.LoginStatus.Login)
            {
                BaseControl.CurrentStaffId = login.CurrentStaffId;
                this.Show();
            }
            else if (login.LoginStatus == LoginStatus.Close)
            {
                if (Application.MessageLoop)
                    Application.Exit();
                else Environment.Exit(1);
            }
        }

        #region Sự kiện ngầm

        private void dateKetThuc_ValueChanged(object sender, EventArgs e)
        {
            LoadDgvContest();
        }

        private void cbxLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgvContest();
        }

        private void dgvContest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ucTrangThaiKiThi uc = new ucTrangThaiKiThi();
            //panelStatus.Controls.Clear();
            //panelStatus.Controls.Add(uc);
            index = dgvContest.SelectedRows[0].Index;
            index1 = index;
            LoadLabelTime();
           // CheckContest();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }



        private void btnLapKeHoach_Click(object sender, EventArgs e)
        {
            try
            {
                int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
                ContestManagementVer2.Main.Start z = new ContestManagementVer2.Main.Start();
                z.QuanLyKeHoachThi(BaseControl.CurrentStaffId, idKiThi);
                LoadDgvContest();
                UpdateContestStatus();
            }
            catch
            {
                MessageBox.Show("Chưa chọn kì thi",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnDangKiThi_Click(object sender, EventArgs e)
        {
            try
            {
                int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;


                EXON.RegisterManager.Module.frmMain formMain = new EXON.RegisterManager.Module.frmMain(idKiThi, BaseControl.CurrentStaffId);
                ////formMain.ShowDialog();

                //Zero.SinhDuLieuTuDong.Start.SinhDuLieuNgauNhien(idKiThi);

                UpdateContestStatus();
            }
            catch
            {
                MessageBox.Show("Chưa chọn kì thi",
                               "Thông báo",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }


        private void btnSinhDeThi_Click(object sender, EventArgs e)
        {
            try
            {
                int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
                EXON.GenerateTest.frmMain test = new EXON.GenerateTest.frmMain(idKiThi, 0);
                test.ShowDialog();
                LoadDgvContest();
                UpdateContestStatus();
            }
            catch
            {
                MessageBox.Show("Chưa chọn kì thi",
                               "Thông báo",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void btnToChucThi_Click(object sender, EventArgs e)
        {
            try
            {

                GeneralManagement.Supervisors.frmSupervisorManage temp = new GeneralManagement.Supervisors.frmSupervisorManage(BaseControl.CurrentStaffId);
                temp.ShowDialog();
                UpdateContestStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            try
            {
                int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
                CreateDB.MFrmMain temp = new CreateDB.MFrmMain(idKiThi);
                temp.ShowDialog();
                LoadDgvContest();
                UpdateContestStatus();
            }
            catch
            {
                MessageBox.Show("Chưa chọn kì thi",
                               "Thông báo",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void btnXepLich_Click(object sender, EventArgs e)
        {

            try
            {
                int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
                ContestManagementVer2.Main.Start z = new ContestManagementVer2.Main.Start();
                z.XepLich(BaseControl.CurrentStaffId, idKiThi);
                LoadDgvContest();
                UpdateContestStatus();
            }
            catch
            {
                MessageBox.Show("Chưa chọn kì thi",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        private void mbtnCauHinhHeThong_Click(object sender, EventArgs e)
        {
            string _pass = "123456";
            string _user = "admin";
            ExamManagement.GUI.FrmMain frm = new ExamManagement.GUI.FrmMain(_user, _pass);
            frm.ShowDialog();
        }

        private void mbtnPhanCong_Click(object sender, EventArgs e)
        {
            QuanLyHoiDongThiVer2.GUI.FrmMain form = new QuanLyHoiDongThiVer2.GUI.FrmMain(BaseControl.CurrentStaffId);
            form.ShowDialog();
        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnDanhSachKeHoach_Click_1(object sender, EventArgs e)
        {
            if (btnDanhSachKeHoach.Text == "     Xem lại các kì thi")
            {
                btnDanhSachKeHoach.Text = "     Các kì thi đang diễn ra";
            }
            else
            {
                btnDanhSachKeHoach.Text = "     Xem lại các kì thi";

            }
            LoadDgvContest();
        }

        private void mbtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {


                int idKiThi = (int)dgvContest.SelectedRows[0].Cells["ID"].Value;
                EXON.GenerateTest.frmMain test = new EXON.GenerateTest.frmMain(idKiThi, 1);
                test.ShowDialog();
                LoadDgvContest();
            }
            catch
            {
                MessageBox.Show("Chưa chọn kì thi",
                                   "Thông báo",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timerUpdateSTTContest_Tick(object sender, EventArgs e)
        {
           // CheckContest();

        }

        private void dgvContest_SelectionChanged(object sender, EventArgs e)
        {
            UpdateContestStatus();
        }

        void CheckContest()
        {
            Contest_Service consv = new Contest_Service();
            CONTEST con = consv.Find(index);
            long timenow = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
            if (con != null)
            {
                if (con.EndDate < timenow)
                {
                    if (con.Status != 3)
                    {
                        con.Status = 3;
                        try
                        {
                            consv.Update(con);
                            consv.Save();
                        }
                        catch
                        {

                        }
                    }
                }
                else if (con.Status != 0)
                {
                    if (timenow > con.EndRegistration)
                    {
                        if (con.Status == 1) //trạng thái đăng ký
                        {
                            con.Status = 4;
                            btnLapKeHoach.Enabled = btnSinhDeThi.Enabled = btnChuanBiThi.Enabled = btnToChucThi.Enabled = btnDangKiThi.Enabled = false;
                            btnXepLich.Enabled = true;
                            btnSinhDeThiGoc.Enabled = true;
                        }
                        if (timenow > con.CreatedQuestionStartDate && timenow < con.CreatedQuestionEndDate)
                        {
                            if (con.Status == 5) // trạng thái đã xếp lịch
                            {
                                btnLapKeHoach.Enabled = btnXepLich.Enabled = btnChuanBiThi.Enabled = btnToChucThi.Enabled = btnDangKiThi.Enabled = false;
                                btnSinhDeThi.Enabled = true;
                                btnSinhDeThiGoc.Enabled = true;
                            }
                            else
                            {
                                if (con.Status == 6)
                                {
                                    btnLapKeHoach.Enabled = btnSinhDeThi.Enabled = btnXepLich.Enabled = btnSinhDeThiGoc.Enabled = btnToChucThi.Enabled = btnDangKiThi.Enabled = false;
                                    btnChuanBiThi.Enabled = true;

                                }
                                else
                                {
                                    btnLapKeHoach.Enabled = btnSinhDeThi.Enabled = btnChuanBiThi.Enabled = btnToChucThi.Enabled = btnDangKiThi.Enabled = false;
                                    btnXepLich.Enabled = true;
                                    btnSinhDeThiGoc.Enabled = true;
                                }
                            }
                        }
                        else if (con.Status == 7)
                        {
                            btnLapKeHoach.Enabled = btnSinhDeThi.Enabled = btnSinhDeThiGoc.Enabled = btnXepLich.Enabled = btnDangKiThi.Enabled = false;
                            btnChuanBiThi.Enabled = btnToChucThi.Enabled = true;
                        }

                    }
                    else
                    {
                        if (con.Status == 4) //trạng thái đã hoàn thành đăng ký
                        {
                            btnLapKeHoach.Enabled = btnSinhDeThi.Enabled = btnChuanBiThi.Enabled = btnToChucThi.Enabled = btnDangKiThi.Enabled = false;
                            btnXepLich.Enabled = true;
                            btnSinhDeThiGoc.Enabled = true;
                        }
                        else
                        {
                            btnLapKeHoach.Enabled = btnSinhDeThi.Enabled = btnSinhDeThiGoc.Enabled = btnChuanBiThi.Enabled = btnToChucThi.Enabled = btnXepLich.Enabled = false;
                            btnDangKiThi.Enabled = true;
                        }
                    }

                }
                else
                {
                    btnDangKiThi.Enabled = btnSinhDeThi.Enabled = btnChuanBiThi.Enabled = btnToChucThi.Enabled = btnXepLich.Enabled = false;
                    btnLapKeHoach.Enabled = true;
                }
            }
            consv.Update(con);
            consv.Save();
        }

        #endregion Sự kiện ngầm
    }
}