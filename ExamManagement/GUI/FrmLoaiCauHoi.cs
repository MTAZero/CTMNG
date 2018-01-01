using ExamManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamManagement.GUI
{
    public partial class FrmLoaiCauHoi : Form
    {
        private int index = 0;
        private int index1 = 0;

        #region Constructor
        public FrmLoaiCauHoi()
        {
            InitializeComponent();
        }
        #endregion

        #region Load
        private void LoadDgv()
        {
            dgvLoaiCauHoi.DataSource = DAO.QuestionTypeDAO.DanhSach(txtTimKiem.Text);

            index = index1;

            SetIndex();        
        }

        private void InitControl()
        {
            // dgv don vi
            dgvLoaiCauHoi.AutoGenerateColumns = false;

            // groupthongtin
            groupThongTin.Enabled = false;
        }

        private void ClearBinding()
        {
            txtQuestionTypeName.DataBindings.Clear();
            txtDescription.DataBindings.Clear();
            txtNumberSubQuestion.DataBindings.Clear();
            txtNumberAnswer.DataBindings.Clear();

            chkIsQuiz.DataBindings.Clear();
            chkIsSingleChoice.DataBindings.Clear();
            chkIsParagraph.DataBindings.Clear();
            chkIsQuestionContent.DataBindings.Clear();
        }
        private void AddBinding()
        {
            ClearBinding();

            txtQuestionTypeName.DataBindings.Add(new Binding("Text", dgvLoaiCauHoi.DataSource, "QuestionTypeName", true, DataSourceUpdateMode.OnPropertyChanged));
            txtDescription.DataBindings.Add(new Binding("Text", dgvLoaiCauHoi.DataSource, "Description", true, DataSourceUpdateMode.OnPropertyChanged));
            txtNumberSubQuestion.DataBindings.Add(new Binding("Text", dgvLoaiCauHoi.DataSource, "NumberSubQuestion", true, DataSourceUpdateMode.OnPropertyChanged));
            txtNumberAnswer.DataBindings.Add(new Binding("Text", dgvLoaiCauHoi.DataSource, "NumberAnswer", true, DataSourceUpdateMode.OnPropertyChanged));

            chkIsQuiz.DataBindings.Add(new Binding("Checked", dgvLoaiCauHoi.DataSource, "IsQuiz", true, DataSourceUpdateMode.OnPropertyChanged));
            chkIsSingleChoice.DataBindings.Add(new Binding("Checked", dgvLoaiCauHoi.DataSource, "IsSingleChoice", true, DataSourceUpdateMode.OnPropertyChanged));
            chkIsParagraph.DataBindings.Add(new Binding("Checked", dgvLoaiCauHoi.DataSource, "Isparagraph", true, DataSourceUpdateMode.OnPropertyChanged));
            chkIsQuestionContent.DataBindings.Add(new Binding("Checked", dgvLoaiCauHoi.DataSource, "IsQuestionContent", true, DataSourceUpdateMode.OnPropertyChanged));

        }

        private void SetIndex()
        {
            try
            {
                dgvLoaiCauHoi.Rows[index].Selected = true;
                dgvLoaiCauHoi.CurrentCell = dgvLoaiCauHoi.Rows[index].Cells[1];
            }
            catch { }

            dgvLoaiCauHoi.Select();
        }

        private void FrmDonVi_Load(object sender, EventArgs e)
        {
            LoadDgv();
            InitControl();
            AddBinding();
            SetIndex();
        }
        #endregion

        #region sự kiện
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            index = 0;
            index1 = 0;

            FrmDonVi_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Lưu";
                btnXoa.Text = "Hủy";
                btnSua.Enabled = false;

                dgvLoaiCauHoi.Enabled = false;
                groupThongTin.Enabled = true;
                btnTimKiem.Enabled = false;

                ClearControl();

                return;
            }

            if (btnThem.Text == "Lưu")
            {
                if (Check(1))
                {
                    QuestionTypeDTO tg = GetThongTin();

                    DAO.QuestionTypeDAO.Them(tg);

                    MessageBox.Show("Thêm thông tin loại câu hỏi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmDonVi_Load(sender, e);

                    btnThem.Text = "Thêm";
                    btnXoa.Text = "Xóa";
                    btnSua.Enabled = true;

                    dgvLoaiCauHoi.Enabled = true;
                    groupThongTin.Enabled = false;
                    btnTimKiem.Enabled = true;
                }

                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // kiểm tra trống
            QuestionTypeDTO tg = GetThongTin();

            if (tg.QuestionTypeID == 0)
            {
                MessageBox.Show("Danh sách loại câu hỏi đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // sửa
            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnXoa.Text = "Hủy";
                btnThem.Enabled = false;

                dgvLoaiCauHoi.Enabled = false;
                groupThongTin.Enabled = true;
                btnTimKiem.Enabled = false;

                return;
            }

            // lưu
            if (btnSua.Text == "Lưu")
            {
                if (Check(0))
                {

                    tg = GetThongTin();
                    MessageBox.Show("Sửa thông tin loại câu hỏi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DAO.QuestionTypeDAO.Sua(tg);
                    FrmDonVi_Load(sender, e);

                    btnSua.Text = "Sửa";
                    btnXoa.Text = "Xóa";
                    btnThem.Enabled = true;

                    dgvLoaiCauHoi.Enabled = true;
                    groupThongTin.Enabled = false;
                    btnTimKiem.Enabled = true;
                }

                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (btnXoa.Text == "Xóa")
            {
                QuestionTypeDTO tg = GetThongTin();

                if (tg.QuestionTypeID == 0)
                {
                    MessageBox.Show("Danh sách loại câu hỏi đang rỗng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa loại câu hỏi " + tg.QuestionTypeName + "?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.Cancel) return;

                DAO.QuestionTypeDAO.Xoa(tg);

                MessageBox.Show("Xóa thông tin loại câu hỏi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmDonVi_Load(sender, e);
                return;
            }

            if (btnXoa.Text == "Hủy")
            {
                btnThem.Text = "Thêm";
                btnSua.Text = "Sửa";
                btnXoa.Text = "Xóa";
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                dgvLoaiCauHoi.Enabled = true;
                groupThongTin.Enabled = false;
                btnTimKiem.Enabled = true;

                AddBinding();

                return;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region sự kiện ngầm
        private void dgvDonVi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLoaiCauHoi.SelectedRows.Count > 0)
            {
                index1 = index;
                index = dgvLoaiCauHoi.SelectedRows[0].Index;
            }
        }
        #endregion

        #region hàm chức năng

        private bool Check(int mode)
        {
            /// mode = 0 la sua
            /// mode = 1 la them
            if (txtQuestionTypeName.Text == "")
            {
                MessageBox.Show("Tên loại câu hỏi không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtDescription.Text == "")
            {
                MessageBox.Show("Mô tả loại câu hỏi không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtNumberSubQuestion.Text == "")
            {
                MessageBox.Show("Số câu hỏi con không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtNumberAnswer.Text == "")
            {
                MessageBox.Show("Số câu trả lời của mỗi câu hỏi không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private QuestionTypeDTO GetThongTin()
        {
            QuestionTypeDTO ans = new QuestionTypeDTO();

            ans.QuestionTypeName = txtQuestionTypeName.Text;
            ans.Description = txtDescription.Text;
            ans.NumberSubQuestion = (int)txtNumberSubQuestion.Value;
            ans.NumberAnswer = (int)txtNumberAnswer.Value;
            ans.Status = 1;

            ans.IsQuiz = chkIsQuiz.Checked;
            ans.IsSingleChoice = chkIsSingleChoice.Checked;
            ans.IsParagraph = chkIsParagraph.Checked;
            ans.IsQuestionContent = chkIsQuestionContent.Checked;

            try
            {
                ans.QuestionTypeID = (int)dgvLoaiCauHoi.SelectedRows[0].Cells["QuestionTypeID"].Value;
            }
            catch
            {
                ans.QuestionTypeID = 0;
            }

            return ans;
        }

        private void ClearControl()
        {
            ClearBinding();

            txtQuestionTypeName.Text = "";
            txtDescription.Text = "";
            txtNumberSubQuestion.Value = 1;
            txtNumberAnswer.Value = 1;

            chkIsQuiz.Checked = false;
            chkIsSingleChoice.Checked = false;
            chkIsParagraph.Checked = false;
            chkIsQuestionContent.Checked = false;
        }

        #endregion
    }
}
