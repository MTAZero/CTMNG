
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DataProvider
{
	public class Questions
	{
		public int NO { get; set; }
		public int QuestionID { get; set; }
		public int SubQuestionID { get; set; }
		public string TitleOfQuestion { get; set; }
		public List<Answer> ListAnswer { get; set; }
		//public string AnswerA { get; set; }
		//public int AnswerAID { get; set; }
		//public string AnswerB { get; set; }
		//public int AnswerBID { get; set; }
		//public string AnswerC { get; set; }
		//public int AnswerCID { get; set; }
		//public string AnswerD { get; set; }
		//public int AnswerDID { get; set; }
		public int FormatQuestion { get; set; }
		public int AnswerChecked { get; set; }
		public int TestID { get; set; }
		public int TestDetailID { get; set; }
		public bool IsSingleChoice { get; set; }
		public bool IsQuestionContent { get; set; }
		public Questions()
		{
			this.ListAnswer = new List<Answer>();
		}
		public Questions(string title, int formatQuestion)
		{
			this.ListAnswer = new List<Answer>();
			this.TitleOfQuestion = title;
			this.FormatQuestion = formatQuestion;
			this.AnswerChecked = -1;
		}
	}
}
