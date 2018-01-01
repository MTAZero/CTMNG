using EXON.Data.Infrastructures;
using System;
using System.Linq;

namespace EXON.Data.Services
{
    public class SystemTimeService
    {
        private IDbFactory dbFactory;

        public SystemTimeService()
        {
            dbFactory = new DbFactory();
        }

        public static DateTime Now
        {
            get
            {
                try
                {
                    return GetDateTimeServer();
                }
                catch
                {
                    return new DateTime();
                    //throw new Exception("Not Connected Server"); 
                    
                }
            }
        }

        private static DateTime GetDateTimeServer()
        {
            return (new RMDbContext()).Database.SqlQuery<DateTime>(@"SELECT GetDate()").First();
        }
    }
}