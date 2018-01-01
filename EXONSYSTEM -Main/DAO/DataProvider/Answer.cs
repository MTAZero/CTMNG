using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DataProvider
{
	public class Answer
	{
		public int AnswerID { get; set; }
		public string AnswerContent { get; set; }
		public Answer() { }
		public Answer(int answerID, string answerContent)
		{
			AnswerID = answerID;
			AnswerContent = answerContent;
		}
	}
}
