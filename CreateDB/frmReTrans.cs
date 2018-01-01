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

namespace CreateDB
{
    public partial class frmReTrans : Form
    {
        bool _checkMain = false;
        bool _checkExam = false;
        //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public frmReTrans()
        {
            InitializeComponent();
        }

        private void btnCheckExam_Click(object sender, EventArgs e)
        {

            if (!_checkExam)
            {
                string s = String.Format("data source={0};initial catalog={1};persist security info=True;user id={2};password={3};MultipleActiveResultSets=True;App=EntityFramework", txtIPThi.Text, txtDBThi.Text, txtUserThi.Text, txtPassThi.Text);
                try
                {
                    ConfigApp.Add("Quiz", s);

                }
                catch
                {
                    ConfigApp.Remove("Quiz");
                    ConfigApp.Add("Quiz", s);
                }
                
            }
            string conn = ConfigurationManager.ConnectionStrings["Quiz"].ConnectionString;
            SqlConnection connect = new SqlConnection(conn);
            try
            {
                connect.Open();
                MessageBox.Show("Kết nối server thi thành công!");
                _checkExam = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Kết nối server thi thất bại\n" + ex.ToString());
                ConfigApp.Remove("Quiz");

            }
            finally
            {
                connect.Close();
            }
            Properties.Settings.Default.Reload();
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!_checkMain)
            {
                string ss = String.Format("data source={0};initial catalog={1};persist security info=True;user id={2};password={3};MultipleActiveResultSets=True;App=EntityFramework", txtIPServerMain.Text, txtDBServerMain.Text, txtUserMain.Text, txtPassMain.Text);
                try
                {
                    ConfigApp.Add("QuizMain", ss);
                }
                catch
                {
                    ConfigApp.Remove("QuizMain");
                    ConfigApp.Add("QuizMain", ss);

                }
            }
            string conn2 = ConfigurationManager.ConnectionStrings["QuizMain"].ConnectionString;
            SqlConnection connect2 = new SqlConnection(conn2);
            try
            {
                connect2.Open();
                MessageBox.Show("Kết nối server trung tâm thành công!");
                _checkMain = true;

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Kết nối server trung tâm thất bại\n" + ex.ToString());
                ConfigApp.Remove("QuizMain");
            }
            finally
            {
                connect2.Close();
            }
            Properties.Settings.Default.Reload();

            if (_checkExam && _checkMain)
            {
                //Main.Main m = new Main.Main();
                //cboContest.DataSource = m.CONTESTS.ToList();
                //cboContest.DisplayMember = "ContestName";
               // cboContest.ValueMember = "ContestID";
                btnCheckExam.Enabled = false;
                btnReTransData.Visible = true;
               // btnTranferData.Enabled = true;
            }
        }

        private void btnReTransData_Click(object sender, EventArgs e)
        {
            if (_checkMain && _checkExam)
            {
                frmLoading2 frm = new frmLoading2();
                frm.ShowDialog();
            }
        }
    }
}
