using EXON.Common;
using EXON.Data.Services;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXON.Register
{
    public partial class frmInfoRegister : Form
    {
        List<REGISTERS_SUBJECTS> list = new List<REGISTERS_SUBJECTS>();
        REGISTER register = new REGISTER();
        List<string> lstname = new List<string>();
        public bool _isSuccessfull = false;
        public frmInfoRegister(List<REGISTERS_SUBJECTS> lt, REGISTER rg, string contestname, List<string> lst)
        {
            InitializeComponent();
            list = lt;
            lstname = lst;
            register = rg;
            lbcontestname.Text = contestname;
        }

        private void frmInfoRegister_Load(object sender, EventArgs e)
        {
            lbFullName.Text = register.FullName;
            lbDOB.Text = DateTimeHelpers.ConvertUnixToDateTime((int)register.DOB).ToString("dd-MM-yyyy");
            lbSex.Text = register.Sex == 0 ? "Nữ" : "Nam";
            lbCMND.Text = register.IdentityCardNumber;
            if (register.StudentCode != null && register.StudentCode != "")
            {
                lbStudentCode.Text = register.StudentCode;
            }
            else
            {
                lbStudentCode.Visible = false;
                lb.Visible = false;
            }
            foreach (var i in lstname)
            {
                lBSubject.Items.Add(i);

            }
            ImageConverter Iconver = new ImageConverter();
            try
            { ptbImage.Image = (Image)Iconver.ConvertFrom(register.Image); }
            catch { }
        }
        string convertsex(int i)
        {
            if (i == 0)
                return "Nữ";
            else if (i == 1)
                return "Nam";
            else return "Khác";
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            AddNewRegister();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AddNewRegister()
        {
            try
            {

                RegisterService registerService = new RegisterService();
                if (registerService.GetByIdentityCard(register.IdentityCardNumber, register.ContestID).Count() > 0)
                {
                    MessageBox.Show("CMND đã có người đăng ký");
                }
                else
                {

                    REGISTER rg = registerService.Add(register);
                    int flag = 0;
                    try
                    {
                        registerService.Save();
                        flag = 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi..! \n"+ex.Message);
                    }
                    bool check = false;
                    if (rg.RegisterID != 0)
                    {
                        check = AddNewRegisterSubject(rg.RegisterID);
                    }



                    if (flag > 0 && check == true)
                    {
                        MessageBox.Show("Thành công! Thông tin đăng ký của bạn đã được lưu lại.");
                        _isSuccessfull = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(@"Đăng ký thất bại! Vui lòng kiểm tra lại thông tin nhập vào.");
                        _isSuccessfull = false;
                        this.Close();
                    }
                }

                //Reset form
                //ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private bool AddNewRegisterSubject(int rgid)
        {
            int count = 0;
            REGISTERS_SUBJECTS registerSubject = null;
            RegisterSubjectService registerSubjectService = new RegisterSubjectService();
            foreach (REGISTERS_SUBJECTS rs in list)
            {
                registerSubject = new REGISTERS_SUBJECTS();
                registerSubject.SubjectID = rs.SubjectID;
                registerSubject.RegisterID = rgid;
                registerSubjectService.Add(registerSubject);
                try
                {
                    registerSubjectService.Save();
                    count++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }

            

            if (count == list.Count) return true;
            else return false;
        }
     
    }
}
