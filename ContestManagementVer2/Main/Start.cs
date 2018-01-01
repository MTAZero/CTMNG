using ContestManagementVer2.CSDL_Exonsytem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestManagementVer2.Main
{
    public class Start
    {
        private ExonSystem db = DAO.DBService.db;
        

        #region Hàm khởi tạo
        public Start()
        {
            DAO.DBService.Reload();
        }
        #endregion

        #region Chức năng
        public void QuanLyKeHoachThi(int staffid, int contestID)
        {
            /// mở form lập kế hoạch kì thi

            // nếu kì thi đã phê duyệt kế hoạch thì mở Form xem (không được sửa)
            // nếu kì thi chưa được phê duyệt và vào với quyền trợ lý khảo thí thì được phép thay đổi kế hoạch
            // nếu kì thi chưa được phê duyệt và vào với quyền trợ lý khảo thí thì có quyền phê duyệt (xác nhận phê duyệt) hoặc thay đổi
            STAFF nhanvien = new STAFF();
            CONTEST kithi = new CONTEST();

            nhanvien = db.STAFFS.Where(p => p.StaffID == staffid).FirstOrDefault();
            kithi = db.CONTESTS.Where(p => p.ContestID == contestID).FirstOrDefault();

            FrmKeHoachThi form = new FrmKeHoachThi(nhanvien, kithi);
            form.ShowDialog();
            
        }

        public void LapKeHoachThi(int userid)
        {

            STAFF nhanvien = db.STAFFS.Where(p => p.StaffID == userid).FirstOrDefault();

            if (nhanvien == null) return;

            // Mở form Lập kế hoạch thi
            FrmLapKeHoachThi form = new FrmLapKeHoachThi(nhanvien);
            form.ShowDialog();
        }

        public void XepLich(int  staffid, int _contestID)
        {
            // Xếp lịch thi cho kì thi
            CONTEST kithi = db.CONTESTS.Where(p => p.ContestID == _contestID).FirstOrDefault();
            FrmXepLich form = new FrmXepLich(kithi);
            form.ShowDialog();
        }
        #endregion

    }
}
