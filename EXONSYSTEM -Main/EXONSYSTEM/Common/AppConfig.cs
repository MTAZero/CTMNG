using DAO.DataProvider;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXONSYSTEM.Common
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
              
				ConnectionStringSettings CSS = config.ConnectionStrings.ConnectionStrings["EXON_SYSTEM_TESTEntities"];
                CSS.ConnectionString = value;
                CSS.ProviderName = "System.Data.EntityClient";
				config.Save(ConfigurationSaveMode.Modified);
				ConfigurationManager.RefreshSection("connectionStringsSection");
				EC = new ErrorController(Constant.STATUS_OK, "Save connection string successfully.");
			}
			catch(Exception ex)
			{
				EC = new ErrorController(Constant.STATUS_NORMAL, ex.Message);
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
