using DAO.DAO;
using DAO.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class ContestBUS
	{
		private static ContestBUS instance;
		public static ContestBUS Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ContestBUS();
				}
				return instance;
			}
		}
		private ContestBUS() { }
		public void GetContestByComputerName(string ComputerName, out Contest ContestOut, out ErrorController EC)
		{
			ContestDAO.Instance.GetContestByComputerName(ComputerName, out ContestOut, out EC);
		}
        public void GetContestByShiftTime(string ComputerName, out Contest ContestOut, out ErrorController EC)
        {
            ContestDAO.Instance.GetContestByShiftTime(ComputerName, out ContestOut, out EC);
        }

    }
}
