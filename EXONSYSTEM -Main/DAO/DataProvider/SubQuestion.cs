using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DataProvider
{
	public class SubQuestion
	{
		public int SubQuestionID { get; set; }
		public List<int> ListAnswerID { get; set; }
		public SubQuestion() { }
	}
}
