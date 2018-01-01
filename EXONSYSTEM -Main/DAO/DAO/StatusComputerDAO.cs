using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAO.DAO
{
    public  class StatusComputerDAO
    {
        private static StatusComputerDAO instance;
        public static StatusComputerDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StatusComputerDAO();
                }
                return instance;
            }
        }
        private static string getOSInfo()
        {
            //Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            Version vs = os.Version;

            //Variable to hold our return value
            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else
                            operatingSystem = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else if (vs.Minor == 1)
                            operatingSystem = "7";
                        else if (vs.Minor == 2)
                            operatingSystem = "8";
                        break;
                    case 10:
                        operatingSystem = "10";
                        break;
                    default:
                        break;
                }
            }
            //Make sure we actually got something in our OS check
            //We don't want to just return " Service Pack 2" or " 32-bit"
            //That information is useless without the OS version.
            if (operatingSystem != "")
            {
                //Got something.  Let's prepend "Windows" and get more info.
                operatingSystem = "Windows " + operatingSystem;
                //See if there's a service pack installed.
                if (os.ServicePack != "")
                {
                    //Append it to the OS name.  i.e. "Windows XP Service Pack 3"
                    operatingSystem += " " + os.ServicePack;
                }
                //Append the OS architecture.  i.e. "Windows XP Service Pack 3 32-bit"
                //operatingSystem += " " + getOSArchitecture().ToString() + "-bit";
                if (Environment.Is64BitOperatingSystem)
                    operatingSystem += " x64 Bit Operating System ";
                else
                    operatingSystem += " x32 Bit Operating System";
            }

            //Return the information we've gathered.
            return operatingSystem;
        }
        public void SetStatusComputer(string ComputerName)
        {
            ROOMDIAGRAM rd = new ROOMDIAGRAM();
            try
            {
                using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
                {
                    DateTime now = DAO.ConvertDateTime.GetDateTimeServer();
                    rd = DB.ROOMDIAGRAMS.SingleOrDefault(x => x.ComputerName == ComputerName);
                    string s = getOSInfo();
                    if (rd != null)
                    {
                        XElement format = new XElement("Computer",
                                  new XElement("Time", now), 
                                  new XElement("OperatingSystem",s)                  
                                  );
                        XDocument xdoc = new XDocument(
                                   new XElement("Root",
                                   format
                                       )
                                    );
                        rd.Description = xdoc.ToString();
                        DB.Entry(rd).State = System.Data.Entity.EntityState.Modified;
                        DB.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            { }
        }

    }
}
