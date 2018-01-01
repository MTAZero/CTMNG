using DAO.DAO;
using DAO.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class ContestantBUS
	{
		private static ContestantBUS instance;
		public static ContestantBUS Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ContestantBUS();
				}
				return instance;
			}
		}
		private ContestantBUS() { }
		public void Authen(Contest C, string ContestantCode, string ComputerName, int LoginType, out ContestantInformation rCI, out ErrorController EC)
		{
			ContestantDAO.Instance.Authen(C, ContestantCode, ComputerName, LoginType, out rCI, out EC);
		}
		public void ChangeStatusContestant(ContestantInformation CI,Contest C, out ErrorController EC)
		{
			ContestantDAO.Instance.ChangeStatusContestant(CI,C, out EC);
		}
		public void GetContestantTestInformation(ContestantInformation CI, out ContestantInformation rCI, out ErrorController EC)
		{
			ContestantDAO.Instance.GetContestantTestInformation(CI, out rCI, out EC);
		}
        public void GetContestantTimeStart(ContestantInformation CI, out ContestantInformation rCI, out ErrorController EC)
        {
            ContestantDAO.Instance.GetContestantTimeStart(CI, out rCI, out EC);
        }
    }
}
