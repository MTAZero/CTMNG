using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Persistance.DAO
{
  public static  class DatetimeConvert
    {
        public static int ConvertDateTimeToUnix(DateTime dt)
        {
            return Convert.ToInt32((dt.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalSeconds);
        }
        public static DateTime ConvertUnixToDateTime(int unix)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return dt.AddSeconds(unix);
        }
        public static DateTime GetDateTimeServer()
        {
            MTAQuizEntities db = new MTAQuizEntities();
            return db.Database.SqlQuery<DateTime>(@"SELECT GetDate()").First();
        }
    }
}
