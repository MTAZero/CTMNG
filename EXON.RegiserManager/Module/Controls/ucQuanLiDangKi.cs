using System;
using EXON.Data.Services;
using System.Linq;
using EXON.Common;
using System.Windows.Forms;
using System.Drawing;
using EXON.RegisterManager.Module.Forms;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using EXON.RegisterManager.Core;
using EXON.Model.Models;
using System.Data;

namespace EXON.RegisterManager.Module.Controls
{
    public partial class ucQuanLiDangKi : BaseModule
    {
        private RegisterService _RegisterService;
        private ReceiptService receiptservice;
        int registerID = 0;
        int contestantID = 0;
        List<REGISTERDGV> lstRegisterDGV;
        IContestantService contestantsv;

        public int Currentindex;

        public ucQuanLiDangKi()
        {
            InitializeComponent();
            InitDataControl();
            LoadCombox();
        }
        #region Phương thức
        private void InitDataControl()
        {
            lstRegisterDGV = new List<REGISTERDGV>();
            List<REGISTER> lst = new List<REGISTER>();
            _RegisterService = new RegisterService();
            lst = _RegisterService.GetAllNotDelete(CurrentContestID).ToList();
            int count = 0;
            lstRegisterDGV.AddRange(from obj in lst
                                    select new REGISTERDGV
                                    {
                                        RegisterID = obj.RegisterID,
                                        FullName = obj.FullName,
                                        DOB = obj.DOB.HasValue ? DateTimeHelpers.ConvertUnixToDateTime(obj.DOB.Value).Date.ToString("dd/MM/yyyy") : "",
                                        Sex = obj.Sex == 0 ? "Nữ" : "Nam",
                                        IdentityCardNumber = obj.IdentityCardNumber,
                                        StudentCode = obj.StudentCode,
                                        ContestantID = IsContestant(obj.RegisterID).ContestantID,
                                        ContestantCode = IsContestant(obj.RegisterID).ContestantCode,
                                        Status = GetStatus(obj),
                                        STT = ++count,
                                        IsImage = GetIsImage(obj.Image),
                                        IsGetFingerPrinter = IsFinger(obj.RegisterID)

                                    });


            gvMain.DataSource = lstRegisterDGV.ToList();
            lbCount.Text = string.Format("Hiện có {0} đăng ký thi", lst.Count().ToString());

            UpdateButtonEnable();
        }
        CONTESTANT IsContestant(int regID)
        {
            CONTESTANT con;
            contestantsv = new ContestantService();
            con = contestantsv.GetAllByRegister(regID).FirstOrDefault();
            if (con == null)
            {
                con = new CONTESTANT();
                con.ContestantCode = " ";
            }
            return con;
        }
        private void LoadCombox()
        {
            if (lstRegisterDGV != null)
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                for (int i = 0; i < lstRegisterDGV.ToList().Count; i++)
                {
                    collection.Add(lstRegisterDGV.ToList()[i].FullName);
                    collection.Add(lstRegisterDGV.ToList()[i].IdentityCardNumber);
                    collection.Add(lstRegisterDGV.ToList()[i].StudentCode);
                    //collection.Add(lstRegisterDGV.ToList()[i].ContestantCode);
                }

                this.cmbKeyName.AutoCompleteCustomSource = collection;
                this.cmbKeyName.AutoCompleteMode = AutoCompleteMode.Suggest;
            }
        }
        private string GetStatus(REGISTER v)
        {
            if (v.Status == (int)EXON.Common.Register.New)
            {
                return "Chưa Lập Phiếu Thu";

            }
            else if (v.Status == (int)EXON.Common.Register.Receipted)
            {
                return "Đã Lập Phiếu Thu";
            }
            else
            {
                return "Đã thu lệ phí";
            }
        }
        bool GetIsImage(byte[] im)
        {
            if (im.Length > 0)
                return true;
            else return false;
        }
        bool IsFinger(int regID)
        {
            CONTESTANT con;
            contestantsv = new ContestantService();
            con = contestantsv.GetAllByRegister(regID).FirstOrDefault();
            if (con == null)
                return false;
            else
            {
                FingerPrinterService fingerssv = new FingerPrinterService();
                int count = fingerssv.GetByContestantID(con.ContestantID).Count();
                if (count > 0)
                {
                    return true;
                }
                else
                    return false;
            }

        }
        public override void Refresh()
        {
            InitDataControl();
            LoadCombox();

            if (gvMain.RowCount != 0)
            {
                gvMain.FirstDisplayedScrollingRowIndex = Currentindex;
                gvMain.Refresh();
                gvMain.CurrentCell = gvMain.Rows[Currentindex].Cells[0];
                gvMain.Rows[Currentindex].Selected = true;

                // PaintGV();
            }
        }

        public void AddReceipt()
        {
            if (registerID == 0)
            {
                MessageBox.Show("Vui lòng chọn bản đăng ký!");
                return;
            }
            List<RECEIPT> lstReceipt = new List<RECEIPT>();
            List<SCHEDULE> lstSchedule = new List<SCHEDULE>();
            receiptservice = new ReceiptService();
            _RegisterService = new RegisterService();
            ScheduleService _scheduleservice = new ScheduleService();
            lstReceipt = receiptservice.GetWithRegisterID(registerID).ToList();
            if (lstReceipt.Count > 0)
            {
                frmReport frm = new frmReport(registerID);
                frm.ShowDialog();
            }
            else
            {
                int typefee = 0;
                ContestFeeService contestfeesv = new ContestFeeService();
                List<CONTEST_FEES> lstfee = contestfeesv.GetByContestId(CurrentContestID).ToList();
                if (lstfee == null || lstfee.Count == 0)
                {
                    MessageBox.Show("Cuộc thi chưa có lệ phí!");
                    return;
                }
                else
                {
                    typefee = (int)lstfee[0].FreeType;
                }
                REGISTER register = _RegisterService.GetById(registerID);
                lstSchedule = _scheduleservice.GetAllByContest(CurrentContestID).ToList();
                List<REGISTERS_SUBJECTS> lstSubjectRegister = register.REGISTERS_SUBJECTS.ToList();
                //List<SCHEDULE> lstSchedule = _scheduleservice.GetAllByContest(CurrentContestID).ToList();
                //List<SCHEDULE> lstSchRegister = new List<SCHEDULE>();
                int countfee = 0;
                if (typefee != 0)
                    foreach (var item in lstSubjectRegister)
                    {
                        foreach (SCHEDULE sche in lstSchedule)
                        {
                            if (sche.SubjectID == item.SubjectID)
                            {
                                countfee += (int)sche.Fee;
                            }
                        }
                    }
                else
                {
                    countfee = (int)lstfee[0].Cost;
                }


                RECEIPT receipt = new RECEIPT();
                receipt.Cost = countfee;
                receipt.ReceiptType = false;
                receipt.ReceivedDate = DateTimeHelpers.ConvertDateTimeToUnix(DateTime.Now);
                receipt.RegisterID = registerID;
                receipt.RegisteredDate = 0;
                receipt.StaffID = CurrentStaffId;
                ReceiptService receiptsv = new ReceiptService();
                receiptsv.Add(receipt);
                try
                {
                    receiptsv.Save();
                    _RegisterService.Delete(registerID, 2);
                    _RegisterService.Save();
                }
                catch (Exception ex)
                {
                    string a = ex.Message;
                }

                frmReport frm = new frmReport(registerID);
                frm.ShowDialog();
            }
        }
        int GridviewHasManyRowChecked()
        {
            int count = 0;
            //DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
            foreach (DataGridViewRow r in gvMain.Rows)
            {
                //cell = (DataGridViewCheckBoxCell)r.Cells["cCheck"];
                if (Convert.ToBoolean(r.Cells["cCheck"].Value))
                    count++;
                //if (count >= 2) return count;
            }
            return count;
        }
        int Registered(int registerid)
        {
            CONTESTANT contestant = new CONTESTANT();
            ContestantService consv = new ContestantService();
            _RegisterService = new RegisterService();
            int countContestant = 0;
            countContestant = consv.GetAllByContest(CurrentContestID).Count();
            string s = "KQH" + CurrentContestID.ToString();
            int k = countContestant + 1;
            if (k < 10) s = s + "00000";
            else if (k < 100)
                s = s + "0000";
            else if (k < 1000)
                s = s + "000";
            else if (k < 10000)
                s = s + "00";
            else if (k < 100000)
                s = s + "0";
            s += k.ToString();
            contestant.ContestantCode = s;
            contestant.RegisterID = registerid;
            REGISTER reg = new REGISTER();
            reg = _RegisterService.GetById(registerid);
            //if(re)
            if (GetIsImage(reg.Image))
                contestant.Status = 1002;
            else contestant.Status = 1000;
            CONTESTANT con = consv.Add(contestant);

            try
            {
                consv.Save();
                _RegisterService.Delete(registerid, 3);
                _RegisterService.Save();
                if (con != null)
                {

                    CONTESTANTS_SUBJECTS con_sub;


                    RegisterSubjectService _rsservice = new RegisterSubjectService();
                    List<REGISTERS_SUBJECTS> lstre_sub = _rsservice.GetWithRegisterID(registerid).ToList();
                    ContestantSubjectService consubsv = new ContestantSubjectService();
                    int count = 0;
                    if (lstre_sub.Count > 0)
                        foreach (REGISTERS_SUBJECTS sub in lstre_sub)
                        {
                            con_sub = new CONTESTANTS_SUBJECTS();
                            con_sub.ContestantID = con.ContestantID;
                            con_sub.SubjectID = sub.SubjectID;
                            con_sub.Status = 1;
                            consubsv.Add(con_sub);
                            try { consubsv.Save(); count++; }
                            catch { }

                        }
                    if (count == lstre_sub.Count && count != 0)
                        return 1;
                    else return 0;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        private void SearchByName(string text)
        {
            List<REGISTERDGV> lst = lstRegisterDGV.Where(x => x.FullName.Contains(text) || x.IdentityCardNumber.Contains(text) || x.StudentCode.Contains(text) || (x.ContestantCode != null && x.ContestantCode.Contains(text))).ToList();
            gvMain.DataSource = lst;
            // PaintGV();

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
                worksheet.Name = "Danh sách đăng ký";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column.
                for (int i = 0; i < gvMain.Rows.Count; i++)
                {
                    for (int j = 0; j < gvMain.Columns.Count; j++)
                    {
                        if (j == 0 || j == 1) continue;
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
                    if (MessageBox.Show("Xuất file thành công, Bạn có muốn mở file?", "Xác nhận",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "I1");

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
            cl6.Value2 = "Lệ phí thi";
            cl6.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("H3", "H3");
            cl7.Value2 = "Đã lấy vân tay";
            cl7.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "Có ảnh";
            cl9.ColumnWidth = 10;
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "I3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 15;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rowHead.Font.Name = "Times New Roman";

            rowHead.Font.Size = "13";

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
            Microsoft.Office.Interop.Excel.Range cIsGetfinger;
            Microsoft.Office.Interop.Excel.Range cIsImage = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, rowEnd];
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
                cIsGetfinger = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowindex, 8];
                cIsImage = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowindex, 9];

                DataGridViewRow dr = gvMain.Rows[r];

                cSTT.Value = dr.Cells["cSTT"].Value;
                if ((int)dr.Cells["cContestantID"].Value != 0)
                    cContestantCode.Value = dr.Cells["cContestantCode"].Value.ToString();
                cName.Value = dr.Cells["cName"].Value.ToString();
                cCMND.Value = dr.Cells["cCMND"].Value.ToString();
                cBoD.Value = dr.Cells["cBoD"].Value.ToString();
                cSex.Value = dr.Cells["cSex"].Value.ToString();
                cStatus.Value = dr.Cells["cStatus"].Value.ToString();
                if ((bool)dr.Cells["cIsGetFinger"].Value)
                    cIsGetfinger.Value = "X";
                else cIsGetfinger.Value = "";
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
            range.Font.Name = "Times New Roman";
            range.Font.Size = "13";

            // Căn giữa cột STT

            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            oSheet.get_Range("H3", cIsImage).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        #endregion

        #region Event Control
        private void gvMain_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
        private void tạoPhiếuThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentContestStatus != (int)ContestStatus.Accepted)
            {
                MessageBox.Show("Kỳ thi đã được phê duyệt thí sinh!\nKhông thể tạo phiếu thu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AddReceipt();
            Refresh();
        }

        private void UpdateInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (registerID == 0)
            {
                MessageBox.Show("Vui lòng chọn bản đăng ký!");
                return;
            }
            Forms.frmRegister frm = new Forms.frmRegister(registerID);
            frm.ShowDialog();
            Refresh();
        }

        private void gvMain_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //gvMain.CurrentRow.Selected = true; //dữ liệu đc chọn cả dòng
                registerID = int.Parse(gvMain.CurrentRow.Cells["cID"].Value.ToString());

                contestantID = int.Parse(gvMain.CurrentRow.Cells["cContestantID"].Value.ToString());

            }
            catch
            { }
        }

        private void gvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gvMain.CurrentRow.Selected = true;
                Currentindex = gvMain.CurrentCell.RowIndex;
            }
            catch
            { }

            if (e.ColumnIndex != 0)
                return;
            DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
            cell = (DataGridViewCheckBoxCell)gvMain.CurrentRow.Cells["cCheck"];

            if (gvMain.CurrentRow.Cells["cCheck"].Value == cell.TrueValue)
            {
                gvMain.CurrentRow.Cells["cCheck"].Value = false;
                gvMain.CurrentRow.Cells["cCheck"].Value = cell.FalseValue;
                //gvMain.CurrentRow.Cells["cCheck"].Value = null;
            }
            else //(gvMain.CurrentRow.Cells["cCheck"].Value == null )
            {
                gvMain.CurrentRow.Cells["cCheck"].Value = true;
                gvMain.CurrentRow.Cells["cCheck"].Value = cell.TrueValue;
            }

            int numOfChecked = GridviewHasManyRowChecked();
            UpdateButtonEnable(numOfChecked != 0, numOfChecked != 0);

        }
        private void UpdateButtonEnable(bool isUpdateEnable = false, bool isDeleteEnable = false)
        {
            btnDone.Enabled = isUpdateEnable;
            btnDelete.Enabled = isDeleteEnable;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (BaseControl.CurrentContestStatus != (int)ContestStatus.Accepted)
            {
                MessageBox.Show("Kỳ thi đã được phê duyệt thí sinh!\nKhông thể xóa thí sinh!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            contestantsv = new ContestantService();
            _RegisterService = new RegisterService();
            if (MessageBox.Show("Bạn chắc chắn muốn xóa thí sinh", "Xác nhận",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                cell = (DataGridViewCheckBoxCell)gvMain.CurrentRow.Cells["cCheck"];
                foreach (DataGridViewRow r in gvMain.Rows)
                {
                    if (r.Cells["cCheck"].Value == cell.TrueValue)
                    {
                        try
                        {
                            contestantsv.Delete(int.Parse(r.Cells["cContestantID"].Value.ToString()));
                            _RegisterService.Delete(int.Parse(r.Cells["cID"].Value.ToString()), 0);
                        }
                        catch
                        {
                            MessageBox.Show("Xóa không thành công!");
                            return;
                        }
                    }
                }
                try
                {
                    contestantsv.Save();
                    _RegisterService.Save();
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    MessageBox.Show("Xóa không thành công!\n" + s);
                    return;
                }

                Refresh();
            }
        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BaseControl.CurrentContestStatus != (int)ContestStatus.Accepted)
            {
                MessageBox.Show("Kỳ thi đã được phê duyệt thí sinh!\nKhông thể xóa thí sinh!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _RegisterService = new RegisterService();
            contestantsv = new ContestantService();
            if (registerID == 0)
            {
                MessageBox.Show("Vui lòng chọn bản đăng ký!");
                return;
            }
            if (MessageBox.Show("Bạn chắc chắn muốn xóa đăng ký", "Xác nhận",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (contestantID != 0)
                    {
                        contestantsv.Delete(contestantID);
                        contestantsv.Save();
                    }
                    _RegisterService.Delete(registerID, 0);
                    _RegisterService.Save();
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa không thành công!\n" + ex.Message);
                    return;
                }
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

        private void PrintReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentContestStatus != (int)ContestStatus.Accepted)
            {
                MessageBox.Show("Kỳ thi đã được phê duyệt thí sinh!\n Không thể in phiếu thu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AddReceipt();
            Refresh();
        }

        private void DoneRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentContestStatus != (int)ContestStatus.Accepted)
            {
                MessageBox.Show("Kỳ thi đã được phê duyệt thí sinh!\n Không thể hoàn tất đăng ký nữa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (registerID == 0)
            {
                MessageBox.Show("Vui lòng chọn bản đăng ký!");
                return;
            }
            if (gvMain.CurrentRow.Cells["cStatus"].Value.ToString().Contains("Chưa") || gvMain.CurrentRow.Cells["cStatus"].Value.ToString().Contains("Chưa"))
            {
                if (MessageBox.Show("Thí sinh " + gvMain.CurrentRow.Cells["cName"].Value.ToString() + " chưa lập phiếu thu!\nBạn chắc chắn muốn hoàn tất đăng ký?", "Xác nhận",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn hoàn tất đăng ký cho Thí sinh " + gvMain.CurrentRow.Cells["cName"].Value.ToString() + "?", "Xác nhận",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            if (Registered(registerID) == 1)
                MessageBox.Show("Hoàn tất đăng ký xong");
            else
                MessageBox.Show("Hoàn tất không thành công");

            Refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (CurrentContestStatus != (int)ContestStatus.Accepted)
            {
                MessageBox.Show("Kỳ thi đã được phê duyệt thí sinh!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int count = 0;
            List<int> listDone = new List<int>();
            DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();

            foreach (DataGridViewRow r in gvMain.Rows)
            {
                cell = (DataGridViewCheckBoxCell)gvMain.CurrentRow.Cells["cCheck"];
                if (r.Cells["cCheck"].Value == cell.TrueValue)
                {
                    if (r.Cells["cContestantCode"] == null || r.Cells["cContestantCode"].Value.ToString() == " ")
                    {
                        try
                        {
                            if (r.Cells["cStatus"].Value.ToString().Contains("Chưa"))
                            {
                                if (MessageBox.Show("Thí sinh " + r.Cells["cName"].Value.ToString() + " chưa lập phiếu thu!\nBạn chắc chắn muốn hoàn tất đăng ký?", "Xác nhận",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    continue;
                                }

                            }
                            else
                            {
                                if (MessageBox.Show("Bạn chắc chắn muốn hoàn tất đăng ký cho Thí sinh " + r.Cells["cName"].Value.ToString(), "Xác nhận",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    continue;
                                }
                            }

                            int currentDoneID = int.Parse(r.Cells["cID"].Value.ToString());
                            Registered(currentDoneID);
                            listDone.Add(currentDoneID);
                            count++;
                        }
                        catch { return; }
                    }
                }
            }
            if (count > 0)
                try
                {
                    _RegisterService.Save();

                    //if (OwnerForm != null)
                    //{
                    //    frmMain main = OwnerForm;
                    //    main.modulesNavigator.ChangeGroup(new ucQuanLiThiSinh());
                    //    main.ChangeBackgroundMenuStrip(1);
                    //}
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    return;
                }

            Refresh();

        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            if (CurrentContestStatus != (int)ContestStatus.Accepted)
            {
                MessageBox.Show("Kỳ thi đã được phê duyệt thí sinh!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EXON.Register.frmRegister frmRegister = new EXON.Register.frmRegister(true);
            frmRegister.ShowDialog();
            Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchByName(cmbKeyName.Text);
        }


        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (gvMain.DataSource == null) return;

            string NeedStatus = string.Empty;
            if (rbtnLostImage.Checked)
            {
                gvMain.DataSource = lstRegisterDGV.Where(z => z.IsImage == false && z.ContestantID != 0).ToList();
            }
            //NeedStatus = "Thiếu";
            else if (rbtnNotReceipt.Checked)
            {
                NeedStatus = "Chưa";
                gvMain.DataSource = lstRegisterDGV.Where(z => z.Status.Contains(NeedStatus)).ToList();
            }

            else if (rbtnAll.Checked)
            {
                NeedStatus = string.Empty;
                gvMain.DataSource = lstRegisterDGV.Where(z => z.Status.Contains(NeedStatus)).ToList();

            }
            else if (rbtnDone.Checked)
            {
                gvMain.DataSource = lstRegisterDGV.Where(z => z.ContestantID != 0).ToList();

            }
            else if (rbtnNotgetFinger.Checked)
            {
                gvMain.DataSource = lstRegisterDGV.Where(z => z.IsGetFingerPrinter == false && z.ContestantID != 0).ToList();

            }


            //PaintGV();
        }
        #endregion

        private void btnExportExcel_Click(object sender, EventArgs e)
        {

            Export("Danh Sách", "Danh sách đăng ký");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbKeyName.Text = "";
            Refresh();
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
                if ((int)(gvMain.Rows[e.RowIndex].Cells["cContestantID"].Value) == 0)
                {
                    switch (gvMain.Rows[e.RowIndex].Cells["cStatus"].Value.ToString())
                    {
                        case "Chưa Lập Phiếu Thu":
                            //if ((bool)gvMain.Rows[e.RowIndex].Cells["cIsImage"].Value)
                            gvMain.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
                            //
                            //   gvMain.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                            break;
                        case "Đã Lập Phiếu Thu":
                            gvMain.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.SaddleBrown;
                            break;
                        default:
                            gvMain.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                            break;
                    }
                }
                else
                {
                    if ((bool)gvMain.Rows[e.RowIndex].Cells["cIsGetFinger"].Value)
                        gvMain.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Indigo;
                    else
                        gvMain.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkBlue;
                }
            }
        }

        private void cmbKeyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        private void GetfingerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (contestantID != 0)
                {
                    EXON.GetFinger.frmGetFingerPrinter frm = new GetFinger.frmGetFingerPrinter(contestantID);
                    frm.ShowDialog();
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        private void contextMenuMain_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (contestantID != 0)
            {
                PrintReceiptToolStripMenuItem.Visible = false;
                DoneRegisterToolStripMenuItem.Visible = false;
                GetfingerToolStripMenuItem.Visible = true;
            }
            else
            {
                PrintReceiptToolStripMenuItem.Visible = true;
                DoneRegisterToolStripMenuItem.Visible = true;
                GetfingerToolStripMenuItem.Visible = false;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn kết thúc đăng ký?\nSau khi kết thúc sẽ không thể hoàn tất đăng ký.", "Xác nhận",
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
                    MessageBox.Show("Hoàn thành danh sách thí sinh!");
                    CurrentContestStatus = 4;
                    BaseControl.CurrentContestStatus = 4;
                    rbtnDone.Checked = true;
                    btnFilter_Click(sender, e);
                }
                catch
                {
                    MessageBox.Show("Hoàn thành danh sách thí sinh thất bại!");
                }
            }
        }

        private void cmbKeyName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    public class REGISTERDGV
    {
        public int RegisterID { get; set; }
        public int ContestantID { get; set; }
        public string ContestantCode { get; set; }
        public string FullName { get; set; }
        public string DOB { get; set; }
        public string Sex { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Status { get; set; }
        public string StudentCode { get; set; }
        public int STT { get; set; }
        public bool IsImage { get; set; }

        public bool IsGetFingerPrinter { get; set; }
    }
}