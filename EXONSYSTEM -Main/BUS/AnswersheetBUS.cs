using DAO.DAO;
using DAO.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
	public class AnswersheetBUS
	{
		private static AnswersheetBUS instance;
		public static AnswersheetBUS Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new AnswersheetBUS();
				}
				return instance;
			}
		}
		private AnswersheetBUS() { }

		public void PushAnswerSheet(Answersheet ansSheet, out ErrorController EC)
		{
			AnswersheetDAO.Instance.PushAnswerSheet(ansSheet, out EC);
		}
		public void GetAnswerSheetByContestantID(ContestantInformation CI, out Answersheet ansDOut, out ErrorController EC)
		{
			AnswersheetDAO.Instance.GetAnswerSheetByContestantID(CI, out ansDOut, out EC);
		}
	}
}
