using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Persistance
{
   public class Common
    {
        public static string GetConnectString(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            EntityConnectionStringBuilder entityConnection = new EntityConnectionStringBuilder(config.ConnectionStrings.ConnectionStrings[key].ConnectionString);
            return entityConnection.ProviderConnectionString;
        }
        public static DateTime GetDateTimeServer()
        {
            MTAQuizEntities db = new MTAQuizEntities();
            return db.Database.SqlQuery<DateTime>(@"SELECT GetDate()").First();
        }

    }
}
