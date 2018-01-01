using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ExamManagement.GUI
{
    public partial class FrmKetNoiCSDL : Form
    {
        public FrmKetNoiCSDL()
        {
            InitializeComponent();
        }

        #region sự kiện
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void btnLuu_Click(object sender, EventArgs e)
        {   
            /*Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.ConnectionStrings.ConnectionStrings["Main"].ConnectionString = String.Format(@"Data Source = {0};Initial Catalog={1}; user id = {2}; password = {3};", txtIPServer.Text, txtDataBaseName.Text.Trim(), txtUser.Text, txtPassword.Text);
            configuration.Save(ConfigurationSaveMode.Modified, true);

            ConfigurationManager.RefreshSection("connectionStrings");*/
            DAO.SettingDAO.SaveConnectionString(String.Format(@"Data Source = {0};Initial Catalog={1}; user id = {2}; password = {3};", txtIPServer.Text, txtDataBaseName.Text.Trim(), txtUser.Text, txtPassword.Text));

            MessageBox.Show("Lưu thiết lập CSDL thành công");

            txtConnection.Text = DAO.SettingDAO.GetConnectionString();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string strConnect = @"Data Source = 192.168.13.87;Initial Catalog=EXON_SYSTEM; user id = sa; password = 123456;";

            SqlConnection connection;

            try
            {
                strConnect = String.Format(@"Data Source = {0};Initial Catalog={1}; user id = {2}; password = {3};", txtIPServer.Text, txtDataBaseName.Text.Trim(), txtUser.Text, txtPassword.Text);
                connection = new SqlConnection(strConnect);
                connection.Open();
                connection.Dispose();
                MessageBox.Show("Kết nối CSDL thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch
            {
                MessageBox.Show("Kết nối CSDL thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
        #endregion

        #region LoadForm
        private void FrmKetNoiCSDL_Load(object sender, EventArgs e)
        {
            txtConnection.Text = DAO.SettingDAO.GetConnectionString();
        }
        #endregion
    }
}
