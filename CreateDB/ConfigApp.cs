using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDB
{
    class ConfigApp
    {
        static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public static void Remove(string name)
        {
            config.ConnectionStrings.ConnectionStrings.Remove(name);
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }
        public static void Add(string name,string connectstring)
        {
            config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(name, connectstring, "System.Data.SqlClient"));
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
