using DAO.DataProvider;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Script.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
	public class TestDAO
	{
		private static TestDAO instance;
		public static TestDAO Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new TestDAO();
				}
				return instance;
			}
		}
		private TestDAO() { }
		public void GetListQuestionByContestantInformation(ContestantInformation CI, out List<List<Questions>> rLLstQuest, out bool IsContinute, out int numberQuestionsOfTest, out ErrorController EC)
		{
			IsContinute = false;
			numberQuestionsOfTest = 0;
			using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
			{
				//try
				//{
				int count = 0;
				List<TEST_DETAILS> lstTD = DB.TEST_DETAILS.Where(x => x.TestID == CI.TestID).ToList();
				lstTD.OrderBy(x => x.NumberIndex);
				//Debug.WriteLine("lstTD.Count {0}", lstTD.Count);
				List<Questions> lstQuestions;
				List<List<Questions>> lstLQuestion = new List<List<Questions>>();
				Hashtable hstbAnswersheetDetail = null;

				if (CI.Status == Common.STATUS_DOING_BUT_INTERRUPT || CI.Status == Common.STATUS_LOGGED_DO_NOT_FINISH)
				{
					hstbAnswersheetDetail = new Hashtable();
					AnswersheetDetailDAO.Instance.GetHastableAnswersheetDetailByAnswerSheetID(CI, out hstbAnswersheetDetail, out EC);
					IsContinute = true;
				}

				if (lstTD.Count > 0)
				{

					List<SubQuestion> lstSubQuestiton = new List<SubQuestion>();
					foreach (TEST_DETAILS td in lstTD)
					{
						lstQuestions = new List<Questions>();
						lstSubQuestiton = GetListSubQuestionByQuestionID(td.QuestionID, td.TestID);
						foreach (var sq in lstSubQuestiton.Select((value, index) => new { data = value, index = index }))
						{
							SUBQUESTION SQ = DB.SUBQUESTIONS.SingleOrDefault(x => x.SubQuestionID == sq.data.SubQuestionID);
							Questions q = new Questions();
							q.NO = td.NumberIndex + sq.index +1;
							// Todo
							q.FormatQuestion = SQ.QUESTION.QuestionFormat;
							q.TestDetailID = td.TestDetailID;
							q.QuestionID = SQ.QuestionID;
							q.SubQuestionID = SQ.SubQuestionID;
							q.TestID = td.TestID;
							q.TitleOfQuestion = SQ.SubQuestionContent;
							q.AnswerChecked = 2000;
							q.IsSingleChoice = SQ.QUESTION.IsSingleChoice;
							q.IsQuestionContent = SQ.QUESTION.IsQuestionContent;

							q.ListAnswer = GetListAnswerByListAnswerID(sq.data.ListAnswerID);

							if (hstbAnswersheetDetail != null && (CI.Status == Common.STATUS_DOING_BUT_INTERRUPT || CI.Status == Common.STATUS_LOGGED_DO_NOT_FINISH))
							{
								q.AnswerChecked = 2000 + sq.data.ListAnswerID.IndexOf(Convert.ToInt32(hstbAnswersheetDetail[q.SubQuestionID])) + 1;
							}
							count++;
							lstQuestions.Add(q);

							if (lstQuestions.Count == SQ.QUESTION.NumberSubQuestion && SQ.QUESTION.NumberSubQuestion > 1)
							{
								lstQuestions.Insert(0, new Questions(SQ.QUESTION.QuestionContent, SQ.QUESTION.QuestionFormat));
							}
						}
						lstLQuestion.Add(lstQuestions);
					}
					numberQuestionsOfTest = count;
					//Debug.WriteLine("lstLQuestion: " + lstLQuestion.Count);

					rLLstQuest = lstLQuestion;
					EC = new ErrorController(Common.STATUS_OK, "Get list questions successfully by TestID=" + CI.TestID);
				}
				else
				{
					rLLstQuest = null;
					EC = new ErrorController(Common.STATUS_ERROR, "Can not get TEST_DETAIL by TestID=" + CI.TestID);
				}
				//}
				//catch(Exception ex)
				//{
				//	rLLstQuest = null;
				//	EC = new ErrorController(Common.STATUS_UNKOWN_EXCEPTION, string.Format(Common.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
				//}
			}
		}
		private List<int> HandleGetNumberIdexAnswerInQuestion(string data)
		{
			List<int> lstIndex = new List<int>();

			string[] arrDataSplit = data.Split(',');
			foreach (string s in arrDataSplit)
			{
				lstIndex.Add(Convert.ToInt32(s));
			}
			return lstIndex;
		}

		private List<SubQuestion> GetListSubQuestionByQuestionID(int questionID, int testID)
		{
			List<SubQuestion> lstSubQuestiton = new List<SubQuestion>();
			using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
			{
				TEST_DETAILS TD = DB.TEST_DETAILS.SingleOrDefault(x => x.QuestionID == questionID && x.TestID == testID);
				lstSubQuestiton = new JavaScriptSerializer().Deserialize<List<SubQuestion>>(TD.RandomAnswer);
			}
			return lstSubQuestiton;
		}
		private List<Answer> GetListAnswerByListAnswerID(List<int> lstAnswerID)
		{
			List<Answer> lstAnswer = new List<Answer>();
			using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
			{
				foreach (int index in lstAnswerID)
				{
					ANSWER A = DB.ANSWERS.Single(x => x.AnswerID == index);
					lstAnswer.Add(new Answer(A.AnswerID, A.AnswerContent));
				}
			}
			return lstAnswer;
		}
        
        public double SumScore(ContestantInformation CI)
        {
            double result = 0;
            List<TEST_DETAILS> lstTD = new List<TEST_DETAILS>();
            
            List<SUBQUESTION> lstSub = new List<SUBQUESTION>();
            using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
            {
                lstTD = DB.TEST_DETAILS.Where(x => x.TestID == CI.TestID).ToList();

                if (lstTD.Count >0)
                    {
                    foreach (TEST_DETAILS td in lstTD)
                    {
                        
                        lstSub = DB.SUBQUESTIONS.Where(x => x.QuestionID == td.QuestionID).ToList();
                        foreach (SUBQUESTION sub in lstSub)
                        {
                            result += sub.Score ?? default(double);
                        } 
                        
                    }   
                    }
                
            }
            return result;
        }
		public double CheckAnswers(AnswersheetDetail ad)
		{
			double result = 0;

			using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
			{
				List<ANSWER> lstA = DB.ANSWERS.Where(x => x.SubQuestionID == ad.SubQuestionID).ToList();
				if (lstA.Count > 0)
				{
					ANSWER A = lstA.SingleOrDefault(y => y.AnswerID == ad.ChoosenAnswer);
					if (A != null)
					{
						if (A.IsCorrect)
						{
							result = A.SUBQUESTION.Score ?? default(double);
						}
					}
				}
			}
			return result;
		}
	}
}
