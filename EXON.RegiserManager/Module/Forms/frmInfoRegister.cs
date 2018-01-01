
using EXON.Common;
using EXON.Data.Services;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EXON.RegisterManager.Module;
namespace EXON.RegisterManager.Module.Forms
{
    public partial class frmRegister : Form
    {
        int _registerid=0;
        List<string> lstName;
        List<SUBJECT> lstsub =  new List<SUBJECT>();
        RegisterService _registerservice = new RegisterService();
        RegisterSubjectService _rsservice = new RegisterSubjectService();
        REGISTER _register = new REGISTER();
        byte[] img = new byte[] { };

        public frmRegister()
        {
            InitializeComponent();
           
        }
        public frmRegister(int register)
        {
            InitializeComponent();
            _registerid = register;

        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            Disable_Enable(false);
            LoadData();
            

        }

        private void LoadData()
        {
            _register = _registerservice.GetById(_registerid);
            if(_register!=null)
            {
                txtFullName.Text = _register.FullName;
                txtIdentityCardNumber.Text = _register.IdentityCardNumber;
                txtNumberphone.Text = _register.TelephoneNumber;
                txtStudentCode.Text = _register.StudentCode;
                dtpRegistedDate.Value = DateTimeHelpers.ConvertUnixToDateTime(_register.RegisteredDate);
                dtpDOB.Value = DateTimeHelpers.ConvertUnixToDateTime((Int32)_register.DOB);
                ImageConverter imger = new ImageConverter();
                img = _register.Image;
                try
                {
                    ptbImage.Image = (Image)imger.ConvertFrom(_register.Image);
                }
                catch
                {
                }
                if (_register.Sex == 0)
                    rbtnFemale.Checked = true;
                else rbtnMale.Checked = true;
                var lst = from r in _rsservice.GetWithRegisterID(_registerid).ToList()
                                   select new
                                   {
                                       SubjectID=r.SubjectID,
                                       SubjectName = r.SUBJECT.SubjectName,
                                       //check=(bool)(1==1)
                                       
                                   };
                dgvSubjectContest.DataSource = lst.ToList();
                for(int i=0;i<dgvSubjectContest.Rows.Count;i++)
                {
                    dgvSubjectContest.Rows[i].Cells["cCheck"].Value = true;
                }
            }
            
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

                    // convert the file to a byte array
                    img = br.ReadBytes((int)numBytes);
                    br.Close();
                }
                //ptbImage.Image = Image.FromFile(of.FileName);
            }
            of.Dispose();
        }
        private void EditRegister()
        {
            bool _check = true;
            try
            {
                ContestantService contestantsv = new ContestantService();
                //_register = new REGISTER(); 
                string name = MathHelper.FormatProperCase(txtFullName.Text);
                _register.FullName = name;
                _register.Sex = rbtnFemale.Checked ? 0 : 1;
                _register.StudentCode = txtStudentCode.Text;
                _register.DOB = DateTimeHelpers.ConvertDateTimeToUnix(dtpDOB.Value);
                _register.IdentityCardNumber = txtIdentityCardNumber.Text;
                _register.TelephoneNumber = txtNumberphone.Text;
                _register.Image = img;
                if (img.Length != 0)
                {
                    CONTESTANT con = contestantsv.GetAllByRegister(_register.RegisterID).FirstOrDefault();
                    if(con!=null)
                    {
                        contestantsv.UpdateSTT(con.ContestantID, 1);
                    }

                } 
                _registerservice.Update(_register);
                try
                {
                    contestantsv.Save();
                    _registerservice.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lưu thông tin không thành công!\n" + ex.Message);
                    _check = false;
                }
                List<REGISTERS_SUBJECTS> oldlist = _rsservice.GetWithRegisterID(_registerid).ToList();
                List<SUBJECT> newlist = new List<SUBJECT>();
                newlist = GetValueFromGridView();
                int checksub = 0;
                foreach (SUBJECT i in newlist)
                {
                    foreach (REGISTERS_SUBJECTS item in oldlist)
                    {
                        if (i.SubjectID == item.SubjectID)
                        {
                            checksub++;
                            break;
                        }
                    }
                }
                if (checksub == newlist.Count && newlist.Count == oldlist.Count)
                {
                    //return;
                }
                else
                {
                    foreach (REGISTERS_SUBJECTS item in oldlist)
                    {
                        _rsservice.Delete(item.RegisterSubjectID);
                    }
                    try
                    {
                        _rsservice.Save();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa môn thi cũ không thành công!\n" + ex.Message);
                        _check = false;
                    }

                    REGISTERS_SUBJECTS resub;
                    foreach (SUBJECT i in newlist)
                    {
                        resub = new REGISTERS_SUBJECTS();
                        resub.SubjectID = i.SubjectID;
                        resub.RegisterID = _registerid;
                        _rsservice.Add(resub);
                    }
                    try
                    {
                        _rsservice.Save();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm môn thi mới không thành công!\n" + ex.Message);
                        _check = false;
                    }
                }
                if (_check)
                {
                    MessageBox.Show("Sửa thành công!");
                    Disable_Enable(false);
                }
                    
                //if(frm._isSuccessfull==true)

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (CheckInfo() == false)
            {
                MessageBox.Show(@"Bạn phải điền đầy đủ các thông tin cần thiết.");
            }
            else
            {
                if (GetValueFromGridView().Count == 0)
                {
                    MessageBox.Show(@"Bạn chưa chọn môn thi nào! Tích vào ô để chọn môn thi");
                }
                else
                {
                    EditRegister();
                }
            }
        }

        private List<SUBJECT> GetValueFromGridView()
        {
            List<SUBJECT> list = new List<SUBJECT>();
            DataGridViewCheckBoxCell dgvcbc;
            //int registerID = GetRegisterNewest();
            lstName = new List<string>();
            foreach (DataGridViewRow row in dgvSubjectContest.Rows)
            {
                dgvcbc = row.Cells["cCheck"] as DataGridViewCheckBoxCell;
                bool bChecked = (null != dgvcbc && null != dgvcbc.Value && true == (bool)dgvcbc.Value);
                if (true == bChecked)
                {
                    SUBJECT registerSubject = new SUBJECT();
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
                return false;
            }
            else
            {
                return true;
            }
        }

        // Clear form
        private void ClearForm()
        {
            txtFullName.Text="";
            txtIdentityCardNumber.Text="";
            txtStudentCode.Text="";
            txtNumberphone.Text="";
            ptbImage.Image = null; 

            //dtpDOB.Text = "";

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (BaseControl.CurrentContestStatus != 1)
            {
                MessageBox.Show("Kỳ thi đã được phê duyệt thí sinh!\n Không thể Sửa thông tin đăng ký!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Disable_Enable(true);
            //lstsub = GetValueFromGridView();
            //ScheduleService subsv = new ScheduleService();
            //var lst = from r in subsv.GetAllByContest( BaseControl.CurrentContestID).ToList()
            //          select new
            //          {
            //              SubjectID = r.SubjectID,
            //              SubjectName = r.SUBJECT.SubjectName,
            //              //check = CheckSubject(r.SubjectID)

            //          };
            //dgvSubjectContest.DataSource = lst.ToList();
            //CheckSubject();
        }
        void CheckSubject()
        {
            foreach(var item in lstsub)
            {
                for (int i = 0; i < dgvSubjectContest.Rows.Count; i++)
                {
                    if(item.SubjectID==int.Parse(dgvSubjectContest.Rows[i].Cells["SubjectID"].Value.ToString()))

                    {
                        dgvSubjectContest.Rows[i].Cells["cCheck"].Value = true;
                        break;
                    }
                        
                }
            }
            
        }
        private void Disable_Enable(bool xx)
        {
           btnPhoto.Enabled= btnSave.Enabled= dtpDOB.Enabled= txtStudentCode.Enabled = txtFullName.Enabled = txtNumberphone.Enabled  = btnTakePhoto.Enabled= xx;
        }

        private void btnTakePhoto_Click(object sender, EventArgs e)
        {
            LoadImageToPicturebox();
        }

        private void dgvSubjectContest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex != 3)
                return;
            if ( (bool)dgvSubjectContest.CurrentRow.Cells["cCheck"].Value)
            {
                dgvSubjectContest.CurrentRow.Cells["cCheck"].Value = null;
                dgvSubjectContest.CurrentRow.Cells["cCheck"].Value =false;
                
            }
            else 
            {
                dgvSubjectContest.CurrentRow.Cells["cCheck"].Value = null;
                dgvSubjectContest.CurrentRow.Cells["cCheck"].Value = true;
            }
        }
        protected void AddImg(object sender, EventArgs e)
        {
            img = new byte[] { };
            Register.frmTakePhoto frm = (Register.frmTakePhoto)sender;
            img = frm.img;
        }
        private void btnPhoto_Click(object sender, EventArgs e)
        {
            Register.frmTakePhoto frm = new Register.frmTakePhoto();
            frm.btnDoneClick += new EventHandler(AddImg);
            frm.ShowDialog();

            ImageConverter Iconver = new ImageConverter();
            try
            { ptbImage.Image = (Image)Iconver.ConvertFrom(img); }
            catch { }
        }
    }
}
