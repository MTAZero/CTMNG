using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExamManagement.DAO
{
    public static class SettingDAO
    {
        public static void SaveConnectionString(string connection)
        {
            // Create Xml
            XmlDocument xml = new XmlDocument();
            var path = Environment.CurrentDirectory;

            XmlElement root = xml.CreateElement(String.Empty, "Body", String.Empty);
            xml.AppendChild(root);

            XmlNode node = xml.CreateNode("element", "ConnectionString", "");
            XmlAttribute atri = xml.CreateAttribute("Main");
            atri.Value = connection;
            node.Attributes.Append(atri);

            root.AppendChild(node);

            xml.Save(path + @"\Setting.xml");
        }

        public static string GetConnectionString(){
            string ans= "";

            XmlDocument xml = new XmlDocument();
            var path = Environment.CurrentDirectory;
            try
            {
                xml.Load(path + @"\Setting.xml");
            }
            catch
            {
                SaveConnectionString("");
                xml.Load(path + @"\Setting.xml");
            }

            try
            {
                XmlNodeList aNodes = xml.SelectNodes("/Body/ConnectionString");

                foreach (XmlNode aNode in aNodes)
                {
                    XmlAttribute atri = aNode.Attributes["Main"];
                    return atri.Value;
                }
            }
            catch
            {
                SaveConnectionString("");
                xml.Load(path + @"\Setting.xml");
            }

            return ans;
        }
    }
}
