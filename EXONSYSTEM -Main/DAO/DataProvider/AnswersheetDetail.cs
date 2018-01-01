using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DataProvider
{
	public class AnswersheetDetail
	{
		public int AnswerSheetDetailID { get; set; }
		public int ChoosenAnswer { get; set; }
		public Nullable<int> LastTime { get; set; }
		public int Status { get; set; }
		public int AnswerSheetID { get; set; }
		public int SubQuestionID { get; set; }
		public AnswersheetDetail() { }
	}
}
