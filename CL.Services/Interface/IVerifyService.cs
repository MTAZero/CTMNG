using CL.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Services.Interface
{
    public partial interface IVerifyService
    {
        #region check in with fingerprint
        bool AddFingerprint(FINGERPRINT fingerprint);
        bool UpdateFingerprint(FINGERPRINT fingerprint);
        CONTESTANT GetInfoContestantbyID(int contestantID);
        FINGERPRINT GetFingerprint(int fingerprintID);

        List<FINGERPRINT> ListFPOfShift(int shiftID);

        //CONTESTANT GetInfoRegister(int fingerprintID);
         List<FINGERPRINT> ListFPOfShiftTime(int shiftid);
        CONTESTANT GetInfoContestant(int fingerprintID);
        CONTESTANTS_SHIFTS GetContestant_Shift(int timenow, int timedate, int contestantID);

        ROOMDIAGRAM GetInfoRoomDia(int roomdiaID);

        CONTESTANTS_SHIFTS GetContestantShift(int shiftID, int contestantID);

        bool UpdateContestantShift(CONTESTANTS_SHIFTS contestantShift);
        bool UpdateContestantShiftSTT(int id);
        bool UpdateCheckFP(int roomtestid, int shiftid, int status);
        int GetIDRoomTest(string roomtestname);

        #endregion
    }
}
