using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.DAO;
namespace BUS
{
   public  class StatusComputerBUS
    {
        private static StatusComputerBUS instance;
        public static StatusComputerBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StatusComputerBUS();
                }
                return instance;
            }
        }
        public void SetStatusComputer(string ComputerName)
        {
            StatusComputerDAO.Instance.SetStatusComputer(ComputerName);
        }
    }
}
