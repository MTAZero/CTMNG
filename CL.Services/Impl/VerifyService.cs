using CL.Persistance;
using CL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Services.Impl
{
    public partial class VerifyService : IVerifyService
    {
        public MTAQuizEntities Db { get; set; }

        public VerifyService()
        {
            if (Db == null)
                Db = new MTAQuizEntities();
        }
        public CONTESTANT GetInfoContestantbyID(int contestantID)
        {
            CONTESTANT result = new CONTESTANT();
            Db = new MTAQuizEntities();

            try
            {
                result = Db.CONTESTANTS.Where(x => x.ContestantID == contestantID).FirstOrDefault();
                return result;
            }
            catch
            {
                return new CONTESTANT();
            }

        }
        #region check in with fingerprint
        public bool AddFingerprint(FINGERPRINT fingerprint)
        {
            Db = new MTAQuizEntities();

            FINGERPRINT finger = Db.FINGERPRINTS.OrderByDescending(x => x.FingerprintID).ToList().FirstOrDefault();

            try
            {
                if (finger == null) fingerprint.FingerprintID = 0;
                else fingerprint.FingerprintID = finger.FingerprintID + 1;
                Db.FINGERPRINTS.Add(fingerprint);
                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdateFingerprint(FINGERPRINT fingerprint)
        {
            try
            {
                FINGERPRINT result = Db.FINGERPRINTS.Where(x => x.FingerprintID == fingerprint.FingerprintID).FirstOrDefault();
                if (result != null)
                {
                    result.FingerprintID = fingerprint.FingerprintID;
                    result.FingerprintImage = fingerprint.FingerprintImage;
                    result.FilePath = fingerprint.FilePath;
                    result.TimeSaveFingerprint = fingerprint.TimeSaveFingerprint;
                    result.Status = fingerprint.Status;
                    Db.SaveChanges();
                }
                else
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public FINGERPRINT GetFingerprint(int fingerprintID)
        {
            try
            {
                FINGERPRINT result = Db.FINGERPRINTS.Where(x => x.FingerprintID == fingerprintID).FirstOrDefault();
                return result;
            }
            catch { return new FINGERPRINT(); }
        }

        public List<FINGERPRINT> ListFPOfShift(int divisionShiftID)
        {
            try
            {

                var listcontestant = (from cs in Db.CONTESTANTS_SHIFTS
                                      where cs.DivisionShiftID == divisionShiftID
                                      select cs.ContestantID).ToList();
                if (listcontestant != null)
                {
                    List<FINGERPRINT> result = new List<FINGERPRINT>();
                    result = (from fp in Db.FINGERPRINTS
                              where listcontestant.Contains(fp.ContestantID)
                              select fp).ToList();
                    return result;
                }
                else
                {
                    return new List<FINGERPRINT>();
                }
            }
            catch
            {
                return new List<FINGERPRINT>();
            }
        }

        public List<FINGERPRINT> ListFPOfShiftTime(int shiftid)
        {
            try
            {
                List<FINGERPRINT> result = new List<FINGERPRINT>();
                result = (from fp in Db.FINGERPRINTS
                              //from dv in  Db.DIVISION_SHIFTS
                              //from sh in Db.SHIFTS
                          from ctsh in Db.CONTESTANTS_SHIFTS
                          where fp.ContestantID == ctsh.ContestantID && ctsh.DIVISION_SHIFTS.SHIFT.ShiftID == shiftid
                          select fp).ToList();
                if (result != null)
                    return result;

                else
                {
                    return new List<FINGERPRINT>();
                }
            }
            catch (Exception ex)
            {
                return new List<FINGERPRINT>();
            }
        }
        public CONTESTANT GetInfoContestant(int fingerprintID)// LẤY thông tin của thí sinh theo mã vân tay
        {
            try
            {
                FINGERPRINT fp = (from obj in Db.FINGERPRINTS
                                  where obj.FingerprintID == fingerprintID
                                  select obj).FirstOrDefault();
                if (fp != null)
                {
                    CONTESTANT result = new CONTESTANT();
                    result = (from contestant in Db.CONTESTANTS
                              where contestant.ContestantID == fp.ContestantID
                              select contestant).FirstOrDefault();
                    return result;
                }
                else
                {
                    return new CONTESTANT();
                }
            }
            catch
            {
                return new CONTESTANT();
            }
        }

        public ROOMDIAGRAM GetInfoRoomDia(int roomdiaID)
        {
            try
            {
                ROOMDIAGRAM result = (from obj in Db.ROOMDIAGRAMS
                                      where obj.RoomDiagramID == roomdiaID
                                      select obj).FirstOrDefault();
                return result;
            }
            catch
            {
                return new ROOMDIAGRAM();
            }

            #endregion
        }

        public CONTESTANTS_SHIFTS GetContestantShift(int divisionShiftID, int contestantID)
        {
            Db = new MTAQuizEntities();
            try
            {
                CONTESTANTS_SHIFTS result = (from obj in Db.CONTESTANTS_SHIFTS
                                             where obj.DivisionShiftID == divisionShiftID && obj.ContestantID == contestantID
                                             select obj).FirstOrDefault();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return new CONTESTANTS_SHIFTS();
                }
            }
            catch
            {
                return new CONTESTANTS_SHIFTS();
            }
        }
        public CONTESTANTS_SHIFTS GetContestant_Shift(int timenow, int timedate, int contestantID)
        {
            Db = new MTAQuizEntities();
            try
            {
                CONTESTANTS_SHIFTS result = (from obj in Db.CONTESTANTS_SHIFTS
                                             where obj.DIVISION_SHIFTS.SHIFT.StartTime - 900 < timenow && obj.DIVISION_SHIFTS.SHIFT.EndTime > timenow/* && (int)(timedate / 86400) == (int)(obj.DIVISION_SHIFTS.SHIFT.ShiftDate / 86400) */&& obj.ContestantID == contestantID
                                             select obj).FirstOrDefault();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return new CONTESTANTS_SHIFTS();
                }
            }
            catch
            {
                return new CONTESTANTS_SHIFTS();
            }
        }
        public bool UpdateContestantShift(CONTESTANTS_SHIFTS contestantShift)
        {
            Db = new MTAQuizEntities();
            try
            {
                CONTESTANTS_SHIFTS result = Db.CONTESTANTS_SHIFTS.Where(x => x.ContestantShiftID == contestantShift.ContestantShiftID).FirstOrDefault();
                if (result != null)
                {
                    result.ContestantShiftID = contestantShift.ContestantShiftID;
                    result.ContestantID = contestantShift.ContestantID;
                    //?????  result.ClientIP = contestantShift.ClientIP;
                    result.DivisionShiftID = contestantShift.DivisionShiftID;
                    result.Status = contestantShift.Status;
                    result.ScheduleID = contestantShift.ScheduleID;
                    result.RoomDiagramID = contestantShift.RoomDiagramID;
                    result.IsCheckFingerprint = contestantShift.IsCheckFingerprint;
                    Db.SaveChanges();
                }
                else
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateContestantShiftSTT(int id)
        {
            Db = new MTAQuizEntities();
            CONTESTANT con = Db.CONTESTANTS.Where(x => x.ContestantID == id).FirstOrDefault();
            if (con != null)
            {
                if (con.Status == 1000)
                {
                    con.Status = 1001;
                }
                else
                {
                    con.Status = 1003;
                }


                try
                {
                    Db.SaveChanges();
                    List<CONTESTANTS_SHIFTS> lstCon = con.CONTESTANTS_SHIFTS.Where(x => x.Status < 2000).ToList();
                    if (lstCon != null)
                    {
                        foreach (CONTESTANTS_SHIFTS item in lstCon)
                        {
                            CONTESTANTS_SHIFTS conshift = Db.CONTESTANTS_SHIFTS.Where(x => x.ContestantShiftID == item.ContestantShiftID).FirstOrDefault();
                            if (conshift != null)
                            {
                                if (conshift.Status == 1000)
                                {
                                    conshift.Status = 1001;
                                }
                                else if (conshift.Status == 1002)
                                {
                                    conshift.Status = 1003;
                                }
                                else conshift.Status = 1001;
                                Db.SaveChanges();
                            }
                        }
                        return true;
                    }
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }
        public int GetIDRoomTest(string roomtestname)
        {
            ROOMTEST room = Db.ROOMTESTS.Where(x => x.RoomTestName == roomtestname).FirstOrDefault();
            if (roomtestname != null)
            {
                return room.RoomTestID;
            }
            else return 0;
        }
        public bool UpdateCheckFP(int roomtestid, int shiftid, int status)
        {
            Db = new MTAQuizEntities();
            DIVISION_SHIFTS con = Db.DIVISION_SHIFTS.Where(x => x.RoomTestID == roomtestid && x.ShiftID == shiftid).FirstOrDefault();
            if (con != null)
            {

                try
                {
                    con.CheckFinger = status;
                    Db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }
    }
}
