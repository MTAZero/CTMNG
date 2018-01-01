using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace ExamManagement.DAO
{
    public static class SqlServerHelper
    {
        static private string strConnect = "";
       // static private string strConnect = @"Data Source=LAPTOP-7G4M4BCJ\SQLEXPRESS;Initial Catalog=EXON_SYSTEM_MTA;Integrated Security=True";
        //@"Data Source = 192.168.13.87;Initial Catalog=EXON_SYSTEM; user id = sa; password = 123456;";
       //@"Data Source=LAPTOP-7G4M4BCJ\SQLEXPRESS;Initial Catalog=EXON_SYSTEM_MTA;Integrated Security=True";
        static private SqlConnection connection;
        static public string LopDangKy = "";

        public static bool KiemTraKetNoi()
        {
            try
            {
                ConnectDataBase();
                connection.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ConnectDataBase()
        {
            strConnect = @"Data Source=169.254.227.0;Initial Catalog=EXON_SYSTEM;persist security info=True;user id=sa;password=1234@bcd";
//DAO.SettingDAO.GetConnectionString();
            connection = new SqlConnection(strConnect);
            connection.Open();
        }

        public static void Disconnect()
        {
            connection.Close();
        }

        public static DataTable ExecuteQuery(string query, object[] thamso = null)
        {
            SqlServerHelper.ConnectDataBase();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (thamso != null)
            {
                string[] dsThamSo = query.Split(new char[] { ' ', '%' });
                int i = 0;
                foreach (string item in dsThamSo)
                    if (item.Contains("@"))
                    {
                        cmd.Parameters.AddWithValue(item, thamso[i]);
                        i++;
                    }
            }
            DataTable ans = new DataTable();
            SqlDataAdapter apdapter = new SqlDataAdapter(cmd);
            apdapter.Fill(ans);

            Disconnect();
            return ans;
        }

        public static int ExecuteNonQuery(string query, object[] thamso = null)
        {
            ConnectDataBase();
            int ans = 0;

            SqlCommand cmd = new SqlCommand(query, connection);
            if (thamso != null)
            {
                string[] dsThamSo = query.Split(new char[] { ' ', '%' });
                int i = 0;
                foreach (string item in dsThamSo)
                    if (item.Contains("@"))
                    {
                        cmd.Parameters.AddWithValue(item, thamso[i]);
                        i++;
                    }
            }

            ans = cmd.ExecuteNonQuery();

            Disconnect();
            return ans;
        }

        public static object ExecuteScalar(string query, object[] thamso = null)
        {
            object ans = new object();
            ConnectDataBase();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (thamso != null)
            {
                string[] dsThamSo = query.Split(new char[] { ' ', '%' });
                int i = 0;
                foreach (string item in dsThamSo)
                    if (item.Contains("@"))
                    {
                        cmd.Parameters.AddWithValue(item, thamso[i]);
                        i++;
                    }
            }

            ans = cmd.ExecuteScalar();
            Disconnect();

            return ans;
        }
    }
}
