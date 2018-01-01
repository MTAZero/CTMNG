using EXON_EM.Data;
using EXON_EM.Data.Model;
using EXON_EM.Data.Service;
using MetroFramework.Forms;
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

namespace EXON.ForRegister
{
    public partial class FormMain : MetroForm
    {
        private int index = 0, index1 = 0;
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            EXON.Register.frmRegister frm = new Register.frmRegister();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            EXONSYSTEM.Layout.frmConfigApplication frm = new EXONSYSTEM.Layout.frmConfigApplication();
            this.Hide();
            frm.runwork();
            //frm.ShowDialog();
            //this.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //if(CheckConnectionString())
            {
                LoadDgvContest();
            }
            //else
            //{
            //    Application.Exit();
            //}
        }
        bool CheckConnectionString()
        {
            
        string conn2 = ConfigurationManager.ConnectionStrings["EXON_DbContext"].ConnectionString;
        SqlConnection connect2 = new SqlConnection(conn2);
            try
            {
                connect2.Open();
               
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Kết nối máy chủ thất bại\n" + ex.Message);
                return false;
            }
            finally
            {
                connect2.Close();
            }
            return true;
        }
        private void LoadDgvContest()
        {
            try
            {
                List<CONTEST> dsCuocThi = new Contest_Service().getAll().Where(p => p.Status != 2).ToList();
                //if (cbxLoai.SelectedIndex == 0)
                //{
                // kì thi đang diễn ra
                dsCuocThi = dsCuocThi.Where(p => p.Status != 3 && p.Status != 2).ToList();
                //}

                //if (cbxLoai.SelectedIndex == 1)
                //{
                //    // kì thi đã kết thúc
                //    dsCuocThi = dsCuocThi.Where(p => p.Status ==3 ).ToList();
                //}

                //if (cbxLoai.SelectedIndex == 2)
                //{
                //    // kì thi theo khoảng thời gian
                //    dsCuocThi = dsCuocThi
                //                .Where(p => Helper.ConvertUnixToDateTime((int)p.BeginDate) >= dateBatDau.Value)
                //                .Where(p => Helper.ConvertUnixToDateTime((int)p.EndDate) <= dateKetThuc.Value)
                //                .ToList();
                //}

                int i = 0;
                dgvContest.DataSource = dsCuocThi
                                        .Select(p => new
                                        {
                                            ID = p.ContestID,
                                            STT = ++i,
                                            TenKiThi = p.ContestName,
                                            TrangThai = Helper.TrangThaiKiThi(p.Status),
                                            Status = p.Status
                                        })
                                        .ToList();

                // load Color
                foreach (DataGridViewRow row in dgvContest.Rows)
                {
                    int gt = (int)Convert.ToInt32(row.Cells["Status"].Value);
                    row.DefaultCellStyle.BackColor = getMauCuocThi(gt);
                }

                // Load Index
                index = index1;
                dgvContest.Rows[index].Cells["STT"].Selected = true;
                dgvContest.Select();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return;
            }
        }
         Color getMauCuocThi(int status)
        {
            switch (status)
            {
                case 0: return Color.White;
                case 1: return Color.White;
                case 2: return Color.Red;
                case 3: return Color.Green;
                case 4: return Color.White;
                case 5: return Color.White;
                case 6: return Color.White;
                case 7: return Color.LightGreen;
            }

            return Color.Red;
        }
    }
}
