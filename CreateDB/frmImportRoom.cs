using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using MetroFramework.Forms;
namespace CreateDB
{
    public partial class frmImportRoom : MetroForm
    {
        int roomtest;

        public frmImportRoom(int _roomtest)
        {
            this.roomtest = _roomtest;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private DataTable ReadDataFromExcelFile()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text.Trim() + ";Extended Properties=\"Excel 8.0\";";
            // Tạo đối tượng kết nối
            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            DataTable data = null;
            try
            {
                // Mở kết nối
                oledbConn.Open();

                // Tạo đối tượng OleDBCommand và query data từ sheet có tên "Sheet1"
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);

                // Tạo đối tượng OleDbDataAdapter để thực thi việc query lấy dữ liệu từ tập tin excel
                OleDbDataAdapter oleda = new OleDbDataAdapter();

                oleda.SelectCommand = cmd;

                // Tạo đối tượng DataSet để hứng dữ liệu từ tập tin excel
                DataSet ds = new DataSet();
                // Đổ đữ liệu từ tập excel vào DataSet
                oleda.Fill(ds);

                data = ds.Tables[0];
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // Đóng chuỗi kết nối
                oledbConn.Close();
            }
            return data;
        }
        private void ImportIntoDatabase(DataTable data, int RoomTestID)
        {
            if (data == null || data.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để import");
                return;
            }
            int count = 0;
            try
            {
                Main.Main db = new Main.Main();
                Main.ROOMDIAGRAM rd = new Main.ROOMDIAGRAM();
                Main.ROOMTEST rt = new Main.ROOMTEST();

                rt = db.ROOMTESTS.Where(x => x.RoomTestID == RoomTestID).FirstOrDefault();
                int maxSeat = rt.MaxSeatMount;


                for (int i = 0; i < data.Rows.Count; i++)
                {
                    string Computername = data.Rows[i]["ComputerName"].ToString();
                    int countseat = db.ROOMDIAGRAMS.Count(x => x.RoomTestID == RoomTestID);
                    if (countseat < maxSeat)
                    {
                        if (db.ROOMDIAGRAMS.Where(x => x.ComputerName == Computername && x.RoomTestID == RoomTestID).SingleOrDefault() == null)
                        {
                            rd.ComputerCode = data.Rows[i]["ComputerCode"].ToString().Trim();
                            rd.ComputerName = data.Rows[i]["ComputerName"].ToString().Trim();
                            rd.Status = int.Parse(data.Rows[i]["Status"].ToString().Trim());
                            rd.RoomTestID = RoomTestID;
                            db.ROOMDIAGRAMS.Add(rd);

                            db.SaveChanges();
                            count++;
                        }
                        else
                        {
                            MessageBox.Show(data.Rows[i]["ComputerName"].ToString().Trim() + " Đã có trong phòng thi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phòng thi đã đủ");
                        break;
                    }
                }
                MessageBox.Show("Nhập thành công " + count.ToString() + "/" + data.Rows.Count.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể nhập file");
            }
        }
        private void mbtnChooseFile_Click(object sender, EventArgs e)
        {
            // Browse đến file cần import
            OpenFileDialog ofd = new OpenFileDialog();
            // Lấy đường dẫn file import vừa chọn
            textBox1.Text = ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : "";
            dgvCauHinh.DataSource = ReadDataFromExcelFile();
        }

        private void mbtnInputFile_Click(object sender, EventArgs e)
        {
            DataTable dt = ReadDataFromExcelFile();
            ImportIntoDatabase(dt, roomtest);
        }
      
    }
}
