using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DataProvider
{
	public class Contest
	{
		public int ContestID { get; set; }
		//public int ShiftID { get; set; }
		public int DivisionShiftID { get; set; }
		public string Subject { get; set; }
		public int TimeOfTest { get; set; }
		public int ShiftDate { get; set; }
		public int StartTime { get; set; }
		public int EndTime { get; set; }
		public int ScheduleID { get; set; }
		public string ContestName { get; set; }
		public int RoomID { get; set; }
		public string RoomName { get; set; }
		public string ComputerCode { get; set; }
		public string ComputerName { get; set; }
		public int NumberQuestionOfTest { get; set; }
		public int TimeToSubmit { get; set; }

		public Contest() { }
	}
}
