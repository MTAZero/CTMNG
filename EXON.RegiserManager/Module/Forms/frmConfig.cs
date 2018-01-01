using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
namespace EXON.RegisterManager.Module.Forms
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string conn = "Data Source=" + txtIP.Text + ";Database=" + txtDatabase.Text + ";User Id=" + txtUsername.Text + ";Password=" + txtPassword.Text;
           
            if (1==1)
            {
                if (!Directory.Exists("C:\\EXON_REGISTER"))
                {
                    Directory.CreateDirectory("C:\\EXON_REGISTER");
                }
                System.IO.StreamWriter sw = new StreamWriter("C:\\EXON_REGISTER\\app.config");
                //sw.Write(En_Decrypt.Encrypt(conn));
                sw.Close();
                sw = null;
                MessageBox.Show("Cấu hình xong, mời chạy lại chương trình");
                this.Close();
            }
            else
            {
                //MessageBox.Show("không kết nối được với server");
            }
            

        }
    }
}
