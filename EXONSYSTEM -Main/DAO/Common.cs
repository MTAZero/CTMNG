using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class Common
    {
        public static int STATUS_OK = 1;
        public static int STATUS_ERROR = -1;

        // Trạng thái thí sinh đã đăng nhập ( là thí sinh mới)
        public static int STATUS_LOGGED = 3000;

        // Trạng thái thí sinh đã đăng nhập (trước đó đã thi nhưng bị gián đoạn)
        public static int STATUS_LOGGED_DO_NOT_FINISH = 3001;

        // Trạng thái thí sinh sẵn sàng để thi ( đã load xong câu hỏi)
        public static int STATUS_READY = 3002;

        // Trạng thái thí sinh đang làm bài thi
        public static int STATUS_DOING = 3003;

        // Trạng thái đang làm thì bị gián đoạn (bị crash chương trình)
        public static int STATUS_DOING_BUT_INTERRUPT = 3004;

        // Trạng thái đã thi xong
        public static int STATUS_FINISHED = 3005;

        // Trạng thái thí sinh bị cảnh cáo
        public static int STATUS_REPORT_ERROR = 3006;

        // Trạng thái thí sinh đăng nhập sai số báo danh
        public static int STATUS_LOGIN_FAIL = 3007;

        // Trạng thái thông báo bị cảnh cáo
        public static int STATUS_WARNING = 3008;

        // Trạng thái thông báo bắt đầu làm bài thi
        public static int STATUS_STARTED = 3009;

		// Trạng thái lỗi từ SQL
		public static int STATUS_UNKOWN_EXCEPTION = 1001;
		public static string STR_STATUS_UNKOWN_EXCEPTION = "Unknown exception. [{0}]";

		// Trạng thái khởi tạo
		public static int STATUS_INITIALIZE = 4001;

        // Trạng thái đã bị thay đổi
        public static int STATUS_CHANGED = 4002;

        // Đăng nhập sai máy thi
        public static int STATUS_WRONG_COMPUTTER = 3012;

        public static int LOGIN_WITH_CONTESTANT_CODE = 5000;
        public static int LOGIN_WITH_STUDENT_CODE = 5001;
        public static int LOGIN_WITH_IDENTITY_CARD_NAME = 5002;

        public static string GetStringStatus(int status)
        {
            switch (status)
            {
                // STATUS_LOGGED_DO_NOT_FINISH 
                case 3001:
                    return "STATUS_LOGGED_DO_NOT_FINISH";
                // STATUS_READY = 3002;
                case 3002:
                    return "STATUS_READY";
                // STATUS_DOING
                case 3003:
                    return "STATUS_DOING";
                // STATUS_DOING_BUT_INTERRUPT
                case 3004:
                    return "STATUS_DOING_BUT_INTERRUPT";
                // STATUS_FINISHED
                case 3005:
                    return "STATUS_FINISHED";
                // STATUS_REPORT_ERROR
                case 3006:
                    return "STATUS_REPORT_ERROR";
                // STATUS_LOGIN_FAIL
                case 3007:
                    return "STATUS_LOGIN_FAIL";
                // STATUS_WARNING
                case 3008:
                    return "STATUS_WARNING";
                // STATUS_STARTED
                case 3009:
                    return "STATUS_STARTED";
                // STATUS_READY_TO_GET_TEST
                case 3010:
                    return "STATUS_READY_TO_GET_TEST";
                // STATUS_GET_TEST
                case 3011:
                    return "STATUS_GET_TEST";
                // STATUS_WRONG_COMPUTTER
                case 3012:
                    return "STATUS_WRONG_COMPUTTER";
                // UNKOWN_EXCEPTION
                default:
                    return "UNKOWN_EXCEPTION";
            }
        }
        public static int ConvertDateTimeToUnix(DateTime dt)
        {
            return Convert.ToInt32((dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalSeconds);
        }
        public static DateTime ConvertUnixToDateTime(int unix)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return dt.AddSeconds(unix);
        }
        public static string GetConnectString(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            EntityConnectionStringBuilder entityConnection = new EntityConnectionStringBuilder(config.ConnectionStrings.ConnectionStrings[key].ConnectionString);
            return entityConnection.ProviderConnectionString;
        }
    }
}
