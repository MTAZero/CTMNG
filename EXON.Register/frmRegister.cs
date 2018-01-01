
using EXON.Common;
using EXON.Data.Services;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EXON.Register
{
    public partial class frmRegister : Form
    {
        private int contestID;
        private List<string> lstName;
        private REGISTER register = new REGISTER();
        private byte[] img = new byte[] { };
        bool isAdd = false;
        public frmRegister()
        {
            InitializeComponent();
            //this.MaximizeBox = false;
            //this.Height = 750;
        }
        public frmRegister(bool add)
        {
            InitializeComponent();
            //this.MaximizeBox = false;
            //this.Height = 750;
            isAdd = add;
            if (isAdd )
            {
                btnChooseImg.Visible = true;
                btnTakePhoto.Visible = true;
            }
        }
        public frmRegister(int contestid)
        {
            InitializeComponent();
            contestID = contestid;
            lblError.Visible = cboContest.Visible = false;
        }
        private void frmRegister_Load(object sender, EventArgs e)
        { 
            GetContestInRegistrationTime();
            rbtnMale.Checked = true;
        }

        private void GetContestInRegistrationTime()
        {
            List<CONTEST> lstcontest = new List<CONTEST>();
            ContestService contestservice = new ContestService();
            lstcontest = contestservice.GetAllInRegisterTime().ToList();

            if (lstcontest.Count > 0)
            {
            
                lblError.Text = "Kỳ thi";
                cboContest.DataSource = lstcontest;
                cboContest.DisplayMember = "ContestName";
                cboContest.ValueMember = "ContestID";
                cboContest.Text = "-- Chọn kỳ thi --";
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Hiện tại không có kỳ thi nào đang diễn ra Đăng ký thi";
                lblError.ForeColor = Color.Red;
                cboContest.Visible = false;
            }
        }

        private void LoadSubjectContest()
        {
            ScheduleService SubjectService = new ScheduleService();
            var lst = from r in SubjectService.GetAllByContest(contestID).ToList()
                      select new
                      {
                          SubjectID = r.SubjectID,
                          SubjectName = r.SUBJECT.SubjectName,
                          //check = CheckSubject(r.SubjectID)
                      };
            dgvSubjectContest.DataSource = lst.ToList();
        }

        private void cboContest_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                contestID = int.Parse(cboContest.SelectedValue.ToString());
                txtContestID.Text = contestID.ToString();
                LoadSubjectContest();
            }
            catch { }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (CheckInfo() == false)
            {
                return;
            }
            else
            {
                if (GetValueFromGridView().Count == 0)
                {
                    MessageBox.Show("Bạn chưa chọn môn thi nào.\nTích vào ô để chọn môn thi");
                }
                else
                {
                    AddNewRegister();
                }
            }
        }

        private List<REGISTERS_SUBJECTS> GetValueFromGridView()
        {
            List<REGISTERS_SUBJECTS> list = new List<REGISTERS_SUBJECTS>();
            DataGridViewCheckBoxCell dgvcbc;
            //int registerID = GetRegisterNewest();
            lstName = new List<string>();
            foreach (DataGridViewRow row in dgvSubjectContest.Rows)
            {
                dgvcbc = row.Cells["ChooseSubject"] as DataGridViewCheckBoxCell;
                bool bChecked = (null != dgvcbc && null != dgvcbc.Value && true == (bool)dgvcbc.Value);
                if (true == bChecked)
                {
                    REGISTERS_SUBJECTS registerSubject = new REGISTERS_SUBJECTS();
                    registerSubject.SubjectID = int.Parse(row.Cells["SubjectID"].Value.ToString());
                    //registerSubject.RegisterID = registerID;
                    lstName.Add(row.Cells["SubjectName"].Value.ToString());
                    list.Add(registerSubject);
                }
            }
            return list;
        }

        private bool CheckInfo()
        {
            if (txtFullName.Text == "" || txtIdentityCardNumber.Text == "" || txtNumberphone.Text == ""

                )
            {
                MessageBox.Show(@"Bạn phải điền đầy đủ các thông tin cần thiết.");
                return false;
            }
            else
            {
                if (txtIdentityCardNumber.Text.Length > 12 || txtIdentityCardNumber.Text.Length < 9)
                {
                    MessageBox.Show("Số CMND không hợp lệ (độ dài quá lớn, hoặc quá nhỏ)!");
                    return false;
                }
                else
                {
                    if (!IsNumber(txtIdentityCardNumber.Text))
                    {
                        MessageBox.Show("Số CMND không hợp lệ!");
                        return false;
                    }
                }
                if (dtpDOB.Value.Year >= SystemTimeService.Now.Year - 16)
                {
                    MessageBox.Show("Bạn chưa đủ độ tuổi đăng ký!");
                    return false;
                }

                if (txtNumberphone.Text.Length > 13 || txtNumberphone.Text.Length < 9 || !IsNumber(txtNumberphone.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ (độ dài quá lớn, hoặc quá nhỏ, hoặc chứa ký tự khác số)!");
                    return false;
                }
                if(!CheckName(txtFullName.Text))
                {
                    MessageBox.Show("Họ tên không hợp lệ, (chứa ký tự đặc biệt)!");
                    return false;
                }
                return true;
            }
        }
        bool CheckName(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsLetter(c))
                {
                    if(c!=' ') return false;
                    
                }
                    
            }
            return true;
        }
        bool IsNumber(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        // Clear form
        private void ClearForm()
        {
            txtFullName.Text = "";
            txtIdentityCardNumber.Text = "";
            txtStudentCode.Text = "";
            txtNumberphone.Text = "";
            ptbImage.Image = null;
            img = new byte[] { };
            DataGridViewCheckBoxCell cell;
            foreach (DataGridViewRow r in dgvSubjectContest.Rows)
            {
                if (r.Cells["ChooseSubject"].Value != null && (bool)r.Cells["ChooseSubject"].Value)
                {
                    cell = (DataGridViewCheckBoxCell)r.Cells["ChooseSubject"];
                    cell.Value = false;
                }
            }
            CONTEST lstcontest = new CONTEST();
            ContestService contestservice = new ContestService();
            lstcontest = contestservice.GetById(contestID);
            if (lstcontest != null)
                if (lstcontest.EndRegistration < DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now))
                {
                    GetContestInRegistrationTime();
                    dgvSubjectContest.DataSource = null;
                }
            //dtpDOB.Text = "";
        }
        private void LoadImageToPicturebox()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Tải ảnh cá nhân";
            //For any other formats
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {

                if (of.FileName != "" && of.FileName != null)
                {
                    FileInfo fInfo = new FileInfo(of.FileName);
                    long numBytes = fInfo.Length;
                    FileStream fStream = new FileStream(of.FileName, FileMode.Open, FileAccess.Read);
                    if (fStream.Length > 500000)
                    {
                        MessageBox.Show("Dung lượng ảnh quá lớn (>500KB)!");
                        return;
                    }
                    ptbImage.ImageLocation = of.FileName;
                    ptbImage.Image = new Bitmap(of.FileName);
                    BinaryReader br = new BinaryReader(fStream);
                    img = new byte[] { };
                    // convert the file to a byte array
                    img = br.ReadBytes((int)numBytes);
                    br.Close();
                }
                //ptbImage.Image = Image.FromFile(of.FileName);
            }
            of.Dispose();
        }
        private void AddNewRegister()
        {
            try
            {
                register = new REGISTER();
                string name = FormatProperCase(txtFullName.Text);
                register.FullName = name;
                register.Sex = ConvertSex();
                register.StudentCode = txtStudentCode.Text;
                register.DOB = DateTimeHelpers.ConvertDateTimeToUnix(dtpDOB.Value);
                register.IdentityCardNumber = txtIdentityCardNumber.Text;
                register.TelephoneNumber = txtNumberphone.Text;
                register.ContestID = contestID;
                register.Status = 1;
                register.RegisteredDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
                register.Image = img;

                List<REGISTERS_SUBJECTS> list = new List<REGISTERS_SUBJECTS>();
                list = GetValueFromGridView();
                frmInfoRegister frm = new frmInfoRegister(list, register, cboContest.Text, lstName);
                frm.FormClosed += new FormClosedEventHandler(frmInfoClose);
                frm.ShowDialog();
                //if(frm._isSuccessfull==true)
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void frmInfoClose(object sender, FormClosedEventArgs e)
        {
            frmInfoRegister frm = (frmInfoRegister)sender;
            if (frm._isSuccessfull == true)
                ClearForm();
        }

        private int ConvertSex()
        {
            if (rbtnFemale.Checked)
                return 0;
            if (rbtnMale.Checked)
                return 1;

            return -1;
        }

        public static string FormatProperCase(string str)
        {
            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            TextInfo textInfo = cultureInfo.TextInfo;
            str = textInfo.ToLower(str);
            // Replace multiple white space to 1 white  space
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s{2,}", " ");
            //Upcase like Title
            return textInfo.ToTitleCase(str);
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void btnTakePhoto_Click(object sender, EventArgs e)
        {
            frmTakePhoto frm = new frmTakePhoto();
            frm.btnDoneClick += new EventHandler(AddImg);
            frm.ShowDialog();

            ImageConverter Iconver = new ImageConverter();
            try
            { ptbImage.Image = (Image)Iconver.ConvertFrom(img); }
            catch { }
        }

        protected void AddImg(object sender, EventArgs e)
        {
            img = new byte[] { };
            frmTakePhoto frm = (frmTakePhoto)sender;
            img = frm.img;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnChooseImg_Click(object sender, EventArgs e)
        {
            LoadImageToPicturebox();
        }
    }
}