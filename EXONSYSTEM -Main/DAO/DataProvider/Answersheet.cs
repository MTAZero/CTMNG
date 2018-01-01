using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DataProvider
{
	public class Answersheet
	{
		public int AnswerSheetID { get; set; }
		public Nullable<double> TestScores { get; set; }
		public Nullable<double> EssayPoints { get; set; }
		public int Status { get; set; }
		public int ContestantTestID { get; set; }
		public Nullable<int> StaffID { get; set; }
		public Answersheet() { }
	}
}
