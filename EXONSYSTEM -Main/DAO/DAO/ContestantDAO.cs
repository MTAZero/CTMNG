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
	public class ContestantDAO
	{
		private static ContestantDAO instance;
		public static ContestantDAO Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ContestantDAO();
				}
				return instance;
			}
		}
		private ContestantDAO() { }
		public void Authen(Contest C, string ContestantCode, string ComputerName, int LoginType, out ContestantInformation rCI, out ErrorController EC)
		{
			ContestantInformation CI = new ContestantInformation();
			using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
			{
				try
				{
					CONTESTANT CS = null;
					if (LoginType == Common.LOGIN_WITH_CONTESTANT_CODE)
					{
						CS = DB.CONTESTANTS.SingleOrDefault(x => x.ContestantCode == ContestantCode);
					}
					else if (LoginType == Common.LOGIN_WITH_IDENTITY_CARD_NAME)
					{
						CS = DB.CONTESTANTS.SingleOrDefault(x => x.IdentityCardNumber.ToLower() == ContestantCode.ToLower());
					}
					else if (LoginType == Common.LOGIN_WITH_STUDENT_CODE)
					{
						CS = DB.CONTESTANTS.SingleOrDefault(x => x.StudentCode.ToLower() == ContestantCode.ToLower());
					}
					if (CS != null)
					{
						CONTESTANTS_SHIFTS CSH = CS.CONTESTANTS_SHIFTS.Single(x => x.ContestantID == CS.ContestantID && x.DivisionShiftID == C.DivisionShiftID && x.ScheduleID == C.ScheduleID);
						if (CSH.ROOMDIAGRAM.ComputerName == ComputerName)
						{
                           int TimeRemain = (Common.ConvertDateTimeToUnix(ConvertDateTime.GetDateTimeServer()) - CSH.TimeStarted) ?? default(int);
                            CI.Fullname = CS.FullName;
							CI.ContestantID = CS.ContestantID;
							CI.ContestantCode = CS.ContestantCode;
							CI.DOB = CS.DOB.Value;
							CI.SEX = CS.Sex.Value;
							CI.ContestantShiftID = CSH.ContestantShiftID;
							CI.Ethnic = CS.Ethnic;
							CI.HighSchool = CS.HighSchool;
							CI.IdentityCardName = CS.IdentityCardNumber;
							CI.CurrentAddress = CS.CurrentAddress;
							CI.TrainingSystem = CS.TrainingSystem;
							CI.StudentCode = CS.StudentCode;
							CI.TimeRemained = (CSH.SCHEDULE.TimeOfTest+300 - TimeRemain); /// 5pkiem tra bai
							CI.Status = CSH.Status;
							//CI.ShiftID = CS.ShiftID;

							if (CSH.Status == Common.STATUS_DOING_BUT_INTERRUPT || CSH.Status== Common.STATUS_DOING)
							{
								CONTESTANTS_TESTS CT = CSH.CONTESTANTS_TESTS.SingleOrDefault(y => y.ContestantShiftID == CSH.ContestantShiftID);
								if (CT != null)
								{
									CI.ContestantTestID = CT.ContestantTestID;
									CI.TestID = CT.TestID;
								}
							}

							CI.Warning = CSH.VIOLATIONS_CONTESTANTS.Where(x => x.ContestantShiftID == CI.ContestantShiftID).ToList().Count;

							rCI = CI;
							EC = new ErrorController(Common.STATUS_OK, "Login successfully!");
						}
						else
						{
							EC = new ErrorController(Common.STATUS_WRONG_COMPUTTER, "Login wrong compuer.");
							rCI = null;
						}
					}
					else
					{
						EC = new ErrorController(Common.STATUS_LOGIN_FAIL, "Login wrong username or identity number or student code");
						rCI = null;
					}
				}
				catch (Exception ex)
				{
					EC = new ErrorController(Common.STATUS_UNKOWN_EXCEPTION, string.Format(Common.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
					rCI = null;
				}

			}
		}
		public void ChangeStatusContestant(ContestantInformation CI,Contest Contest, out ErrorController EC)
		{
			using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
			{
				try
				{
					CONTESTANT C = DB.CONTESTANTS.SingleOrDefault(x => x.ContestantID == CI.ContestantID);
					CONTESTANTS_SHIFTS CSH = C.CONTESTANTS_SHIFTS.Single(x => x.ContestantID == C.ContestantID && x.DivisionShiftID == Contest.DivisionShiftID && x.ScheduleID == Contest.ScheduleID);
					if (C != null && CSH != null)
					{
						CSH.Status = CI.Status;
					
						if (CI.IsNewStarted)
						{
                            CSH.TimeStarted = CI.TimeStarted;
                            CSH.TimeWorked = 0;
						}
						if (CI.IsDisconnected)
						{
						CSH.TimeWorked = Common.ConvertDateTimeToUnix(ConvertDateTime.GetDateTimeServer()) - CI.TimeStarted;
						}
						DB.Entry(C).State = EntityState.Modified;
						DB.Entry(CSH).State = EntityState.Modified;
						DB.SaveChanges();
						EC = new ErrorController(Common.STATUS_OK, string.Format("{0}: {1}", CI.Status, Common.GetStringStatus(CI.Status)));
					}
					else
					{
						EC = new ErrorController(Common.STATUS_ERROR, "Can not get CONTESTANT by ContestantID");
					}
				}
				catch (Exception ex)
				{
					EC = new ErrorController(Common.STATUS_UNKOWN_EXCEPTION, string.Format(Common.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
				}

			}
		}
		public void GetContestantTestInformation(ContestantInformation CI, out ContestantInformation rCI, out ErrorController EC)
		{
			using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
			{
				try
				{
					CONTESTANTS_TESTS CT = DB.CONTESTANTS_TESTS.SingleOrDefault(x => x.ContestantShiftID == CI.ContestantShiftID);
                    CONTESTANTS_SHIFTS CSH = DB.CONTESTANTS_SHIFTS.SingleOrDefault(x => x.ContestantShiftID == CI.ContestantShiftID);

                    if (CT != null && CSH!=null)
					{
						CI.ContestantTestID = CT.ContestantTestID;
						CI.TestID = CT.TestID;
                 
						rCI = CI;
						EC = new ErrorController(Common.STATUS_OK, "Get CONTESTANTS_TESTS by ContestantShiftID successfully.");
					}
					else
					{
						rCI = null;
						EC = new ErrorController(Common.STATUS_ERROR, "Can not get CONTESTANTS_TESTS by ContestantID | GetContestantTestInformation");
					}
				}
				catch (Exception ex)
				{
					rCI = null;
					EC = new ErrorController(Common.STATUS_UNKOWN_EXCEPTION, string.Format(Common.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
				}
			}
		}
        public void GetContestantTimeStart(ContestantInformation CI, out ContestantInformation rCI, out ErrorController EC)
        {
            using (EXON_SYSTEM_TESTEntities DB = new EXON_SYSTEM_TESTEntities())
            {
                try
                {
                    CONTESTANTS_SHIFTS CT = DB.CONTESTANTS_SHIFTS.SingleOrDefault(x => x.ContestantShiftID == CI.ContestantShiftID);
                    if (CT != null)
                    {
                        CI.TimeStarted = CT.TimeStarted ?? 0;
                        rCI = CI;
                        EC = new ErrorController(Common.STATUS_OK, "Get CONTESTANTS_Shift Timestarted by ContestantShiftID successfully.");
                    }
                    else
                    {
                        rCI = null;
                        EC = new ErrorController(Common.STATUS_ERROR, "Can not get CONTESTANTS_TESTS by ContestantID | GetContestantTestInformation");
                    }
                }
                catch (Exception ex)
                {
                    rCI = null;
                    EC = new ErrorController(Common.STATUS_UNKOWN_EXCEPTION, string.Format(Common.STR_STATUS_UNKOWN_EXCEPTION, ex.Message));
                }
            }
        }
    }
}
