using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.DataProvider;
namespace DAO.DAO
{
    public  class RoomDiagramDAO
    {
        private static RoomDiagramDAO instance;
        public static RoomDiagramDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomDiagramDAO();
                }
                return instance;
            }
        }
        private RoomDiagramDAO() { }
        
        public bool UpdateDiagrams(int RoomTestID,RoomDiagrams RoomDiagrams)
        {
            using (EXON_SYSTEM_TESTEntities db = new EXON_SYSTEM_TESTEntities())
            {
                try

                {
                   
                    ROOMDIAGRAM rd = db.ROOMDIAGRAMS.Where(x=>x.ComputerName==RoomDiagrams.ComputerName && x.RoomTestID==RoomTestID).SingleOrDefault();
                    if (rd == null)
                    {
                        rd.ComputerCode = RoomDiagrams.ComputerCode;
                        rd.ComputerName = RoomDiagrams.ComputerName;
                        rd.Status = RoomDiagrams.Status;
                        rd.RoomTestID = RoomTestID;
                        db.ROOMDIAGRAMS.Add(rd);
                        db.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
