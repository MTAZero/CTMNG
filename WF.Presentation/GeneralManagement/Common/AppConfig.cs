
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralManagement.Common
{
    public class AppConfig
    {
            
        Configuration config;
        public AppConfig()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }
        public string GetConnectionString(string key)
        {
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }
        public void SaveConnectionString(string value, out ErrorController EC)
        {
            try
            {
                ConnectionStringSettings CSS = config.ConnectionStrings.ConnectionStrings["MTAQuizEntities"];
                CSS.ConnectionString = value;
                CSS.ProviderName = "System.Data.EntityClient";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStringsSection");
                EC = new ErrorController(Constant.STATUS_OK, "Save connection string successfully.");
            }
            catch
            {
                EC = new ErrorController(Constant.STATUS_NORMAL, "Can not save connection string.");
            }
        }
        public string AnalyzeConnectionString(ConfigApplication CA)
        {
            EntityConnectionStringBuilder entityConnection = new EntityConnectionStringBuilder();
            entityConnection.Metadata = @"res://*";
            entityConnection.Provider = "System.Data.SqlClient";

            SqlConnectionStringBuilder sqlConnection = new SqlConnectionStringBuilder();
            sqlConnection.InitialCatalog = CA.DBName;
            sqlConnection.DataSource = CA.Database.IP + "," + CA.Database.Port;
            sqlConnection.MultipleActiveResultSets = true;
            sqlConnection.PersistSecurityInfo = true;
            sqlConnection.UserID = CA.UsernameDB;
            sqlConnection.Password = CA.PasswordDB;

            entityConnection.ProviderConnectionString = sqlConnection.ConnectionString;

            return entityConnection.ConnectionString;
        }
    }
}
