using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON_ExamManagement.UC.UI;
using EXON_EM.Data.Model;
using EXON_EM.Data;
using EXON_EM.Data.Service;

namespace EXON_ExamManagement.UC.LapKeHoachKiThi
{
    public partial class ucThongTinKiThi : UserControl
    {
        private List<UserControl> listUc = new List<UserControl>();
        private CONTEST KyThi = new CONTEST();

        #region constructor
        public ucThongTinKiThi()
        {
            InitializeComponent();
            panelStatus.Controls.Clear();

            panelStatus.Controls.Clear();
            listUc = ucLapKeHoachThiHelper.getListUserControl(1);
            panelStatus.Controls.AddRange(listUc.ToArray());
        }
        #endregion

        #region LoadForm
        private void LoadInitControl()
        {

            dateCreatedDate.Value = Helper.ConvertUnixToDateTime((int) KyThi.CreatedDate);
            dateBeginDate.Value = Helper.ConvertUnixToDateTime((int)KyThi.BeginDate);
            dateEndDate.Value = Helper.ConvertUnixToDateTime((int)KyThi.EndDate);
            dateBeginRegistration.Value = Helper.ConvertUnixToDateTime((int)KyThi.BeginRegistration);
            dateEndRegistration.Value = Helper.ConvertUnixToDateTime((int)KyThi.EndRegistration);
            dateCreatedQuestionStartDate.Value = Helper.ConvertUnixToDateTime((int)KyThi.CreatedQuestionStartDate);
            dateCreatedQuestionEndDate.Value = Helper.ConvertUnixToDateTime((int)KyThi.CreatedQuestionEndDate);
        }
        private void ucThemCaThi_Load(object sender, EventArgs e)
        {
            LoadInitControl();
        }
        #endregion

        #region Hàm chức năng
        public bool NextStep()
        {
            if (!Check()) return false;

            KyThi.ContestName = txtContestName.Text;
            KyThi.Description = txtDescription.Text;
            KyThi.CreatedDate = Helper.ConvertDateTimeToUnix(dateCreatedDate.Value);
            KyThi.BeginRegistration = Helper.ConvertDateTimeToUnix(dateBeginRegistration.Value);
            KyThi.EndRegistration = Helper.ConvertDateTimeToUnix(dateEndRegistration.Value);
            KyThi.BeginDate = Helper.ConvertDateTimeToUnix(dateBeginDate.Value);
            KyThi.EndDate = Helper.ConvertDateTimeToUnix(dateEndDate.Value);
            KyThi.CreatedQuestionStartDate = Helper.ConvertDateTimeToUnix(dateCreatedQuestionStartDate.Value);
            KyThi.CreatedQuestionEndDate = Helper.ConvertDateTimeToUnix(dateCreatedQuestionEndDate.Value);

            if (KyThi.ContestID == 0)
            {
                // Tạo mới kì thi
                new Contest_Service().Add(KyThi);
            }
            else
            {
                // Sửa kì thi
                new Contest_Service().Update(KyThi);
            }

            return true;
        }

        private bool Check()
        {
            if (txtContestName.Text == "")
            {
                MessageBox.Show("Tên kì thi không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dateBeginRegistration.Value < dateCreatedDate.Value)
            {
                MessageBox.Show("Thời gian bắt đầu đăng ký phải lớn hơn thời gian tạo kì thi",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (dateEndRegistration.Value < dateBeginRegistration.Value)
            {
                MessageBox.Show("Thời gian kết thúc đăng ký phải lớn hơn thời gian bắt đầu đăng ký",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (dateCreatedQuestionStartDate.Value < dateEndRegistration.Value)
            {
                MessageBox.Show("Thời gian bắt đầu làm đề thi phải lớn hơn thời gian kết thúc đăng ký",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (dateCreatedQuestionEndDate.Value < dateCreatedQuestionStartDate.Value)
            {
                MessageBox.Show("Thời gian kết thúc tạo đề thi phải lớn hơn thời gian bắt đầu tạo đề thi",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (dateBeginDate.Value < dateCreatedQuestionEndDate.Value)
            {
                MessageBox.Show("Thời gian bắt đầu thi phải lớn hơn thời gian kết thúc tạo đề thi",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (dateEndDate.Value < dateBeginDate.Value)
            {
                MessageBox.Show("Thời gian kết thúc phải lớn hơn thời gian bắt đầu",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public CONTEST getKiThi()
        {
            return KyThi;
        }
        #endregion
    }
}
