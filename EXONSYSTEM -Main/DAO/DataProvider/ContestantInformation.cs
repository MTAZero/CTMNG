using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DataProvider
{
	public class ContestantInformation
	{
		public string ContestantCode { get; set; }
		public int ContestantID { get; set; }
		public int ContestantTestID { get; set; }
		public int ContestantShiftID { get; set; }
		public int TestID { get; set; }
		public string Fullname { get; set; }
		public int DOB { get; set; }
		public int SEX { get; set; }
		public string Ethnic { get; set; }
		public string HighSchool { get; set; }
		public string IdentityCardName { get; set; }
		public string Unit { get; set; }
		public string CurrentAddress { get; set; }
		public bool IsNewStarted { get; set; }
		public int TimeStarted { get; set; }
		public int TimeRemained { get; set; }
		public bool IsDisconnected { get; set; }
		public int Status { get; set; }
		public int AnswerSheetID { get; set; }
		public string TrainingSystem { get; set; }
		public string StudentCode { get; set; }
		public int Warning { get; set; }
		public ContestantInformation()
		{
			this.IsDisconnected = false;
			this.IsNewStarted = false;
		}
	}
}
