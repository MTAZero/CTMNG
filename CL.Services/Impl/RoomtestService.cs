using CL.Persistance;
using CL.Persistance.DAO;
using CL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CL.Services.Impl
{
    public partial class RoomtestService:IRomtestService
    {
        private const string XML_DATE_FORMAT = "yyyy-MM-dd'T'HH:mm:ssZ";
        public RoomtestService()
        {

        }
        public void  CheckComputer(int roomtestID)
        {
            using (MTAQuizEntities db = new MTAQuizEntities())
            {
                DateTime dt = new DateTime();
                List< ROOMDIAGRAM> listRd = new List<ROOMDIAGRAM>();
                XmlDocument xdoc = new XmlDocument();
                int current;
                int timecheck;
                try
                {
                    listRd = db.ROOMDIAGRAMS.Where(x => x.RoomTestID == roomtestID).ToList();
                    if(listRd.Count>0)
                    {
                        foreach(ROOMDIAGRAM rd in listRd)
                        {
                            if (rd.Description != null)
                            {
                                xdoc.LoadXml(rd.Description);
                                
                                XmlNodeList nodelist = xdoc.DocumentElement.SelectNodes("Computer");
                                foreach (XmlNode node in nodelist)
                                {
                                    dt = Convert.ToDateTime(node.FirstChild.InnerText);
                                    timecheck = DatetimeConvert.ConvertDateTimeToUnix(dt);
                                    current = DatetimeConvert.ConvertDateTimeToUnix(DatetimeConvert.GetDateTimeServer());
                                    if (current - timecheck > 180)
                                    {
                                        rd.Status = 4002;

                                    }
                                    else if (current - timecheck < 180)
                                    {
                                        if (rd.Status == 4003)
                                        {
                                            rd.Status = 4003;
                                        }
                                        else
                                        {
                                            rd.Status = 4001;
                                        }
                                    }

                                  
                                }
                            }
                            else
                            {
                                if (rd.Status == 4003)
                                {
                                    rd.Status = 4003;
                                }
                                else
                                {
                                    rd.Status = 4002;
                                }
                            }
                            db.SaveChanges();
                        }
                    }
                }

                catch(Exception ex)
                {
                }

            }

        }
    }
}
