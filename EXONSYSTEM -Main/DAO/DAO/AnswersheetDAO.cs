using DAO;
using DAO.DataProvider;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO
{
	public class AnswersheetDAO
	{
		private static AnswersheetDAO instance;
		public static AnswersheetDAO Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new AnswersheetDAO();
				}
				return instance;
			}
		}
		private AnswersheetDAO() { }

		public void PushAnswerSheet(Answersheet ansSheet, out ErrorController EC)
		{
			using (EXON_SYSTEM_TESTEntities db = new EXON_SYSTEM_TESTEntities())
			{
				try
				{
					ANSWERSHEET ASH = db.ANSWERSHEETS.SingleOrDefault(x => x.ContestantTestID == ansSheet.ContestantTestID);
					if (ASH != null)
					{
						if (ansSheet.TestScores != null)
						{
							ASH.TestScores = ansSheet.TestScores;
						}
						if (ansSheet.EssayPoints != null)
						{
							ASH.EssayPoints = ansSheet.EssayPoints;
						}
						ASH.Status = Common.STATUS_CHANGED;
						db.Entry(ASH).State = EntityState.Modified;
						db.SaveChanges();
						EC = new ErrorController(Common.STATUS_OK, "Update ANSWERSHEET successfully");
					}
					else
					{
						ANSWERSHEET dbAnsSheet = new ANSWERSHEET();
						dbAnsSheet.ContestantTestID = ansSheet.ContestantTestID;
						dbAnsSheet.EssayPoints = ansSheet.EssayPoints;
						dbAnsSheet.TestScores = ansSheet.TestScores;
						dbAnsSheet.Status = Common.STATUS_INITIALIZE;
						db.ANSWERSHEETS.Add(dbAnsSheet);
						db.SaveChanges();
						EC = new ErrorController(Common.STATUS_OK, "Add new ANSWERSHEET successfully");
					}
				}
				catch(Exception ex)
				{
					EC = new ErrorController(Common.STATUS_UNKOWN_EXCEPTION, string.Format(Common.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
				}
			}
		}
		public void GetAnswerSheetByContestantID(ContestantInformation CI, out Answersheet ansDOut, out ErrorController EC)
		{
			Answersheet ans = new Answersheet();
			using (EXON_SYSTEM_TESTEntities db = new EXON_SYSTEM_TESTEntities())
			{
				try
				{
					ANSWERSHEET rDBAnsSheet = db.ANSWERSHEETS.SingleOrDefault(x => x.ContestantTestID == CI.ContestantTestID);
					if (rDBAnsSheet != null)
					{
						ans.AnswerSheetID = rDBAnsSheet.AnswerSheetID;
						ans.ContestantTestID = rDBAnsSheet.ContestantTestID;
						ans.Status = rDBAnsSheet.Status;
						ans.EssayPoints = rDBAnsSheet.EssayPoints ?? default(double);
						ans.TestScores = rDBAnsSheet.TestScores ?? default(double);

						ansDOut = ans;
						EC = new ErrorController(Common.STATUS_OK, "Get AnswerSheetByContestantID successfully");
					}
					else
					{
						ansDOut = null;
						EC = new ErrorController(Common.STATUS_ERROR, "Can not get AnswerSheetByContestantID");
					}
				}
				catch(Exception ex)
				{
					ansDOut = null;
					EC = new ErrorController(Common.STATUS_UNKOWN_EXCEPTION, string.Format(Common.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
				}
			}
		}
	}
}
