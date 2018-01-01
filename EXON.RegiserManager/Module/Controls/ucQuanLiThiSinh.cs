using System;
using EXON.Data.Services;
using System.Linq;
using EXON.Common;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using EXON.Model.Models;
using System.Drawing;
using EXON.RegisterManager.Module.Forms;
using EXON.RegisterManager.Core;
using Microsoft.Office.Interop.Excel;

namespace EXON.RegisterManager.Module.Controls
{
    public partial class ucQuanLiThiSinh : BaseModule
    {
        private ContestantService _ContestantService = new ContestantService();
        private RegisterService _RegisterService = new RegisterService();
        FingerPrinterService fingerssv;
        int _contestantID = 0;
        private List<CONTESTANT_REGISTER> listContestant;

        //private int selectedIndex;
        public ucQuanLiThiSinh()
        {
            InitializeComponent();
            InitDataControl();
        }

        public ucQuanLiThiSinh(List<int> listDone)
        {
            InitializeComponent();
            InitDataControl();

            Refresh();
           
        }

        private void InitDataControl()
        {
            listContestant = new List<CONTESTANT_REGISTER>();
            _ContestantService = new ContestantService();
            _RegisterService = new RegisterService();
            int count = 0;
            List<REGISTER> listRegister = _RegisterService.GetAllNotDelete(CurrentContestID).ToList();
            for (int i = 0; i < listRegister.Count; i++)
            {
                listContestant.AddRange((from obj in _ContestantService.GetAllByRegister(listRegister[i].RegisterID)
                                         select new CONTESTANT_REGISTER
                                         {
                                             ContestantID = obj.ContestantID,
                                             FullName = listRegister[i].FullName,
                                             DOB = listRegister[i].DOB.HasValue ? DateTimeHelpers.ConvertUnixToDateTime(obj.REGISTER.DOB.Value).Date.ToString("dd/MM/yyy") : "",
                                             Sex = listRegister[i].Sex == 0 ? "Nữ" : "Nam",
                                             IdentityCardNumber = listRegister[i].IdentityCardNumber,
                                             ContestantCode = obj.ContestantCode,
                                             StudentCode = listRegister[i].StudentCode,
                                             Status = GetStatus(obj.ContestantID),
                                             STT = ++count,
                                             IsImage=GetIsImage(obj.REGISTER.Image)
                                         }).ToList());
            }
              
            if (listContestant != null)
            {
                gvMain.DataSource = listContestant.ToList();
                lbTongSo.Text = string.Format("Tổng Số {0} thí sinh", listContestant.Count);
            }
            else gvMain.DataSource = null;

            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            for (int i = 0; i < listContestant.Count; i++)
            {
                collection.Add(listContestant[i].FullName);
                collection.Add(listContestant[i].IdentityCardNumber);
                collection.Add(listContestant[i].ContestantCode);
                collection.Add(listContestant[i].StudentCode);
            }

            this.cmbKeyName.AutoCompleteCustomSource = collection;
            this.cmbKeyName.AutoCompleteMode = AutoCompleteMode.Suggest;

            UpdateButtonEnable();
        }
        bool GetIsImage(byte[] im)
        {
            if (im.Length > 0)
                return true;
            else return false;
        }
        private string GetStatus(int id)
        {
            fingerssv = new FingerPrinterService();
            int count=fingerssv.GetByContestantID(id).Count();
            if (count > 0)
            {
                return "Đã lấy " + count.ToString() + " vân tay";
            }
            else
                return "Chưa lấy vân tay";
        }

        private void btnFilter_Click(object sender, System.EventArgs e)
        {
            if (gvMain.DataSource == null) return;

            string NeedStatus = string.Empty;
            if (rdiNotImage.Checked)
            {
                gvMain.DataSource = listContestant.Where(z => z.IsImage==false).ToList();
                return;
            }
            else if (rbNotFinger.Checked)
                NeedStatus = "Chưa";
            else if (rbAll.Checked)
                NeedStatus = string.Empty;
            gvMain.DataSource = listContestant.Where(z => z.Status.Contains(NeedStatus)).ToList();
        }

        public override void Refresh()
        {
            InitDataControl();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string a = cmbKeyName.Text;
            gvMain.DataSource = listContestant.Where(z => z.FullName.Contains(a) || z.IdentityCardNumber.Contains(a) || z.StudentCode.Contains(a) || z.ContestantCode.Contains(a)).ToList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            gvMain.DataSource = listContestant;
        }

        private void cmbKeyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        private void gvMain_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //gvMain.CurrentRow.Selected = true; //dữ liệu đc chọn cả dòng
                _contestantID = int.Parse(gvMain.CurrentRow.Cells["cID"].Value.ToString());
            }
            catch
            { }
        }

        private void UpdateButtonEnable(bool isUpdateEnable = false, bool isDeleteEnable = false)
        {
            btnChiTietThiSinh.Enabled = isUpdateEnable;
            btnLayVanTay.Enabled = isUpdateEnable;

            btnXoa.Enabled = isDeleteEnable;

        }

        int GridviewHasManyRowChecked()
        {
            int count = 0;
            foreach (DataGridViewRow r in gvMain.Rows)
            {
                if (r.Cells["cCheck"].Value != null && (bool)r.Cells["cCheck"].Value)
                    count++;
                if (count >= 2) return count;
            }
            return count;
        }

        private void gvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                gvMain.CurrentRow.Selected = true;
                if (e.ColumnIndex != 0)
                    return;
                if (gvMain.CurrentRow.Cells["cCheck"].Value != null && (bool)gvMain.CurrentRow.Cells["cCheck"].Value)
                {
                    gvMain.CurrentRow.Cells["cCheck"].Value = false;
                    gvMain.CurrentRow.Cells["cCheck"].Value = null;
                }
                else if (gvMain.CurrentRow.Cells["cCheck"].Value == null)
                {
                    gvMain.CurrentRow.Cells["cCheck"].Value = true;
                }
                _contestantID = int.Parse(gvMain.CurrentRow.Cells["cID"].Value.ToString());
                int numOfChecked = GridviewHasManyRowChecked();
                UpdateButtonEnable(numOfChecked == 1, numOfChecked != 0);
            }
            catch
            {

            }



        }

        private void gvMain_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (Convert.ToBoolean(gvMain.Rows[e.RowIndex].Cells["cCheck"].Value))
            {
                gvMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
            else
            {
                gvMain.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                if (gvMain.Rows[e.RowIndex].Cells["cStatus"].Value.ToString() == "Chưa lấy vân tay")
                {
                    gvMain.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                }
                else
                    gvMain.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void btnChiTietThiSinh_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in gvMain.Rows)
            {
                if (r.Cells["cCheck"].Value != null && (bool)r.Cells["cCheck"].Value)
                {
                    try
                    {
                        frmThongTinThiSinh temp = new frmThongTinThiSinh(int.Parse(r.Cells["cID"].Value.ToString()));
                        temp.ShowDialog();
                        if (temp.Status == ProcessStatus.OK) Refresh();
                    }
                    catch { }
                    return;
                }
            }
            MessageBox.Show("Vui lòng chọn thí sinh bằng cách tích vào ô bên cạnh", Properties.Resources.Notification);
        }

        private void btnLayVanTay_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in gvMain.Rows)
            {
                if (r.Cells["cCheck"].Value != null && (bool)r.Cells["cCheck"].Value)
                {
                    try
                    {
                        EXON.GetFinger.frmGetFingerPrinter temp = new EXON.GetFinger.frmGetFingerPrinter(int.Parse(r.Cells["cID"].Value.ToString()));
                        temp.ShowDialog();
                        Refresh();
                    }
                    catch { }
                    return;
                }
            }
        }


        private void ExportFileExcel()
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Workbooks.Add();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {
                SplashForm.ShowSplashScreen();
                worksheet = workbook.ActiveSheet;

                worksheet.Name = "Danh sách thí sinh";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column.
                for (int i = 0; i < gvMain.Rows.Count; i++)
                {
                    for (int j = 1; j < gvMain.Columns.Count; j++)
                    {
                        if (j == 2 || j == 0) continue;
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = gvMain.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = gvMain.Rows[i - 1].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FilterIndex = 2;
                SplashForm.CloseForm();

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    if (MessageBox.Show("Xuất file thành công. Bạn có muốn mở không?", "Thông Báo", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                        excelApp.Visible = true;
                        Workbook wb = excelApp.Workbooks.Open(saveDialog.FileName);
                    }
                }

            }
            catch (System.Exception ex)
            {
                SplashForm.CloseForm();
                MessageBox.Show(ex.Message);
            }
            finally
            {               
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }
        public void Export(string sheetName, string title)
        {

            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần đầu nếu muốn

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "G1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "16";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "STT";

            cl1.ColumnWidth = 7;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("B3", "B3");

            cl8.Value2 = "Số Báo Danh";

            cl8.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("C3", "C3");

            cl2.Value2 = "Họ và Tên";

            cl2.ColumnWidth = 25;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("D3", "D3");

            cl3.Value2 = "CMND";

            cl3.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("E3", "E3");

            cl4.Value2 = "Ngày sinh";

            cl4.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("F3", "F3");

            cl5.Value2 = "Giới tính";
            cl5.ColumnWidth = 10;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("G3", "G3");

            cl6.Value2 = "Trạng Thái";


            cl6.ColumnWidth = 20;
            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("H3", "H3");

            cl7.Value2 = "Có ảnh";

            cl7.ColumnWidth = 10;
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "H3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,

            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.

            object[,] arr = new object[this.gvMain.Rows.Count + 1, gvMain.Columns.Count - 2];

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + gvMain.Rows.Count - 1;

            int columnEnd = gvMain.Columns.Count - 3;
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            Microsoft.Office.Interop.Excel.Range cSTT;
            Microsoft.Office.Interop.Excel.Range cContestantCode;
            Microsoft.Office.Interop.Excel.Range cName;
            Microsoft.Office.Interop.Excel.Range cCMND;
            Microsoft.Office.Interop.Excel.Range cBoD;
            Microsoft.Office.Interop.Excel.Range cSex;
            Microsoft.Office.Interop.Excel.Range cStatus;
            Microsoft.Office.Interop.Excel.Range cIsImage = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            for (int r = 0; r < this.gvMain.Rows.Count; r++)

            {
                int rowindex = rowStart + r;
                // Ô STT
                cSTT = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowindex, 1];
                cContestantCode = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowindex, 2];
                cName = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowindex, 3];
                cCMND = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowindex, 4];
                
                cBoD = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowindex, 5];
                cSex = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowindex, 6];
                cStatus = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowindex, 7];
                cIsImage = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowindex, 8];

                DataGridViewRow dr = gvMain.Rows[r];
               
                cSTT.Value = dr.Cells["cSTT"].Value;
                cContestantCode.Value = dr.Cells["cContestantCode"].Value.ToString();
                cName.Value = dr.Cells["cName"].Value.ToString();
                cCMND.Value = dr.Cells["cCMND"].Value.ToString();
                cBoD.Value = dr.Cells["cBoD"].Value.ToString();
                cSex.Value = dr.Cells["cSex"].Value.ToString();
                cStatus.Value = dr.Cells["cStatus"].Value.ToString();
                if ((bool)dr.Cells["cIsImage"].Value)
                    cIsImage.Value = "X";
                else cIsImage.Value = "";
            }

            //Thiết lập vùng điền dữ liệu



            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            // Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, cIsImage);

            //Điền dữ liệu vào vùng đã thiết lập

            //range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột STT

            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            //Xuat tat ca ra file excel voi cac thong tin chinh
            Export("Danhsachthisinh", "DANH SÁCH THÍ SINH");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
            if (BaseControl.CurrentContestStatus != (int)ContestStatus.Accepted)
            {
                MessageBox.Show("Kỳ thi đã được phê duyệt thí sinh!\nKhông thể xóa thí sinh!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ContestantService = new ContestantService();
            if (MessageBox.Show("Bạn chắc chắn muốn xóa thí sinh", "Xác nhận",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow r in gvMain.Rows)
                {
                    if (r.Cells["cCheck"].Value != null && (bool)r.Cells["cCheck"].Value)
                    {
                        try
                        {
                            _ContestantService.Delete(int.Parse(r.Cells["cID"].Value.ToString()));
                        }
                        catch { return; }
                    }
                }
                try
                {
                    _ContestantService.Save();
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    return; }

                Refresh();
            }


        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void cậpNhậtThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinThiSinh frm = new frmThongTinThiSinh(_contestantID);
            frm.ShowDialog();
            Refresh();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentContestStatus != (int)ContestStatus.Accepted)
            {
                MessageBox.Show("Kỳ thi đã được phê duyệt thí sinh!\n Không thể xóa thí sinh!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn muốn xóa thí sinh", "Xác nhận",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _ContestantService.Delete(_contestantID);

                try
                {
                    _ContestantService.Save();
                    Refresh();
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    return; }


            }
        }

        private void gvMain_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    gvMain.CurrentCell = gvMain.Rows[rowSelected].Cells[0];
                    //gvMain.SelectedRows.Clear();
                    this.gvMain.Rows[rowSelected].Selected = true;
                }
                // you now have the selected row with the context menu showing for the user to delete etc.
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn phê duyệt đăng ký?\nSau khi phê duyệt xong, không thể thay đổi thông tin đăng ký.", "Xác nhận",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CONTEST contest = new CONTEST();
                ContestService contestsv = new ContestService();
                contest = contestsv.GetById(CurrentContestID);
                contest.Status = 4;
                
                try
                {
                    contestsv.Update(contest);
                    contestsv.Save();
                    MessageBox.Show("Phê Duyệt đăng ký thành công!");
                    CurrentContestStatus = 4;
                }
                catch
                {
                    MessageBox.Show("Phê Duyệt đăng ký thất bại!");
                }
            }
        }

        private void lấyVânTayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EXON.GetFinger.frmGetFingerPrinter frm = new GetFinger.frmGetFingerPrinter(_contestantID);
                frm.ShowDialog();
                Refresh();
            }
            catch
            {

            }
            
        }
    }

    public class CONTESTANT_REGISTER
    {
        public int ContestantID { get; set; }
        public string FullName { get; set; }
        public string DOB { get; set; }
        public string Sex { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Status { get; set; }
        public string ContestantCode { get; set; }

        public string StudentCode { get; set; }
        public int STT { get; internal set; }
        public bool IsImage { get; set; }
    }
}