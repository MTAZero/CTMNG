using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.DAO;
using DAO.DataProvider;
namespace BUS
{
    public  class RoomDiagramsBus
    {
        private static RoomDiagramsBus instance;
        public static RoomDiagramsBus Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomDiagramsBus();
                }
                return instance;
            }
        }
        private RoomDiagramsBus()
        {

        }
        public bool UpdateRoomDiagrams(int RoomTestID, RoomDiagrams rd)
        {
            return RoomDiagramDAO.Instance.UpdateDiagrams(RoomTestID,rd);
        }
    }
}
