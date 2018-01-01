using EXON.Data.Services;
using EXON.Model.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EXON.Common;
using System.IO;

namespace EXON.RegisterManager.Module.Forms
{
    public partial class frmThongTinThiSinh : Form
    {
        private int ContestantID;
        private ContestantService _ContestantService = new ContestantService();
        private RegisterService _RegisterService = new RegisterService();
        private ContestantSubjectService _ContestantSubjectService = new ContestantSubjectService();
        byte[] img = new byte[] { };

        public ProcessStatus Status = ProcessStatus.New;
        #region constructor

        public frmThongTinThiSinh()
        {
            InitializeComponent();
        }

        public frmThongTinThiSinh(int IDts)
        {
            InitializeComponent();
            ContestantID = IDts;
        }

        #endregion constructor

        #region LoadForm

        private void LoadInitControl()
        {
        }

        private void LoadInfo()
        {
            try
            {
                CONTESTANT ts = _ContestantService.GetById(ContestantID);
                REGISTER tt = _RegisterService.GetById(ts.RegisterID);

                txtFullName.Text = tt.FullName;
                dateDOB.Value = EXON.Common.DateTimeHelpers.ConvertUnixToDateTime((int)tt.DOB);
                txtSBD.Text = ts.ContestantCode;
                txtEthnic.Text = tt.Ethnic;
                txtIdentityCardNumber.Text = tt.IdentityCardNumber;
                txtEmail.Text = tt.Email;
                txtTelephoneNumber.Text = tt.TelephoneNumber;
                txtPlaceOfBirth.Text = tt.PlaceOfBirth;
                txtHighSchool.Text = tt.HighSchool;
                if (tt.Sex == 0)
                    rbtnFemale.Checked = true;
                else rbtnMale.Checked = true;
                ImageConverter imgcon = new ImageConverter();
                img = tt.Image;
                try
                {
                    picImage.Image = (Image)imgcon.ConvertFrom(img);
                }
                catch
                {
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadDgvMonThi()
        {
            SubjectService sj = new SubjectService();
            int i = 1;
            var listMonThi = _ContestantSubjectService.GetAll()
                             .ToList()
                             .Where(p => p.ContestantID == ContestantID)
                             .Select(p => new
                             {
                                 ID = p.ContestantSubjectID,
                                 STT = i++,
                                 MonThi = sj.GetById((int)p.SubjectID).SubjectName
                             })
                             .ToList();
            dgvMonThi.DataSource = listMonThi.ToList();
        }

        private void frmThongTinThiSinh_Load(object sender, EventArgs e)
        {
            LoadInitControl();
            LoadInfo();
            LoadDgvMonThi();
        }

        #endregion LoadForm

        #region Phương thức
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
                    if(fStream.Length>500000)
                    {
                        MessageBox.Show("Dung lượng ảnh quá lớn (>500KB)!");
                        return;
                    }
                    picImage.ImageLocation = of.FileName;
                    picImage.Image = new Bitmap(of.FileName);
                    BinaryReader br = new BinaryReader(fStream);
                    
                    // convert the file to a byte array
                    img = br.ReadBytes((int)numBytes);
                    br.Close();
                }
                //ptbImage.Image = Image.FromFile(of.FileName);
            }
            of.Dispose();
        }
        #endregion
        #region sự kiện

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (BaseControl.CurrentContestStatus != (int)ContestStatus.Accepted)
            {
                MessageBox.Show("Kỳ thi đã được phê duyệt thí sinh!\n Không thể thay đổi thông tin thí sinh", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                CONTESTANT ts = _ContestantService.GetById(ContestantID);
                REGISTER tt = _RegisterService.GetById(ts.RegisterID);

                tt.FullName = MathHelper.FormatProperCase(txtFullName.Text);
                tt.DOB = EXON.Common.DateTimeHelpers.ConvertDateTimeToUnix(dateDOB.Value);
                ts.ContestantCode = txtSBD.Text;
                tt.Ethnic = txtEthnic.Text;
                tt.IdentityCardNumber = txtIdentityCardNumber.Text;
                tt.Email = txtEmail.Text;
                tt.TelephoneNumber = txtTelephoneNumber.Text;
                tt.PlaceOfBirth = txtPlaceOfBirth.Text;
                tt.HighSchool = txtHighSchool.Text;
                tt.Sex = rbtnFemale.Checked ? 0 : 1;
                tt.Image = img;
                _ContestantSubjectService.Save();
                _RegisterService.Save();

                MessageBox.Show("Lưu thông tin thí sinh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Status = ProcessStatus.OK;
            }
            catch (Exception ez)
            {
                MessageBox.Show(ez.Message);
                Status = ProcessStatus.Break;
            }
        }
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            LoadImageToPicturebox();
        }

       
        protected void AddImg(object sender, EventArgs e)
        {
            img = new byte[] { };
            Register.frmTakePhoto frm = (Register.frmTakePhoto)sender;
            img = frm.img;
        }
        private void btnTakePhoto_Click(object sender, EventArgs e)
        {
            Register.frmTakePhoto frm = new Register.frmTakePhoto();
            frm.btnDoneClick += new EventHandler(AddImg);
            frm.ShowDialog();

            ImageConverter Iconver = new ImageConverter();
            try
            { picImage.Image = (Image)Iconver.ConvertFrom(img); }
            catch { }
        }
        #endregion sự kiện
    }
}