using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace EXON.GenerateTest.Settings
{
    public static class XMLSettings
    {
        public const string VERSION = "RELEASE3";
        public static bool GenerateTestNotSame { get; set; }
        public static bool AutoNumberOfTest { get; set; }
        public static ushort NumberOfOriginalTest { get; set; }
        public static bool GenerateFromOrignalTest { get; set; }

        public static float ScaleNumOfTest { get; set; }

        private static string _settingsFilePath = Path.Combine(Application.StartupPath, "settings.xml");

        public static bool WriteDefaultSettings()
        {
            try
            {
                if (!File.Exists(_settingsFilePath))
                {
                    XmlDocument doc = new XmlDocument();
                    XmlNode root = doc.CreateElement("settings");
                    doc.AppendChild(root);

                    root.AppendChild(doc.CreateElement("GenerateTestNotSame")).InnerText = "True";
                    root.AppendChild(doc.CreateElement("AutoNumberOfTest")).InnerText = "False";
                    root.AppendChild(doc.CreateElement("NumberOfOriginalTest")).InnerText = "3";
                    root.AppendChild(doc.CreateElement("GenerateFromOrignalTest")).InnerText = "True";
                    root.AppendChild(doc.CreateElement("ScaleNumOfTest")).InnerText = "1.5";

                    doc.Save(_settingsFilePath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string ReadValue(string pstrValueToRead)
        {
            try
            {
                XPathDocument doc = new XPathDocument(_settingsFilePath);
                XPathNavigator nav = doc.CreateNavigator();
                var expr = nav.Compile(@"/settings/" + pstrValueToRead);
                XPathNodeIterator iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    return iterator.Current.Value;
                }

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static bool WriteValue(string pstrValueToRead, string pstrValueToWrite)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                using (var reader = new XmlTextReader(_settingsFilePath))
                {
                    doc.Load(reader);
                }

                XmlElement root = doc.DocumentElement;
                var oldNode = root.SelectSingleNode(@"/settings/" + pstrValueToRead);
                if (oldNode == null) // create if not exist
                {
                    oldNode = doc.SelectSingleNode("settings");
                    oldNode.AppendChild(doc.CreateElement(pstrValueToRead)).InnerText = pstrValueToWrite;
                    doc.Save(_settingsFilePath);
                    return true;
                }
                oldNode.InnerText = pstrValueToWrite;
                doc.Save(_settingsFilePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ReadSettings(bool writeIfNotExist = true)
        {
            if (writeIfNotExist)
                XMLSettings.WriteDefaultSettings();

            XMLSettings.GenerateTestNotSame = bool.Parse(XMLSettings.ReadValue("GenerateTestNotSame"));
            XMLSettings.AutoNumberOfTest = bool.Parse(XMLSettings.ReadValue("AutoNumberOfTest"));
            XMLSettings.NumberOfOriginalTest = ushort.Parse(XMLSettings.ReadValue("NumberOfOriginalTest"));
            XMLSettings.GenerateFromOrignalTest = bool.Parse(XMLSettings.ReadValue("GenerateFromOrignalTest"));
            XMLSettings.ScaleNumOfTest = float.Parse(XMLSettings.ReadValue("ScaleNumOfTest"));
        }
    }
}