using System.Collections.Generic;
using System.Linq;
using CL.Persistance;
using CL.Services.Interface;

namespace CL.Services
{
    public partial class GeneralService : IGeneralService
    {
        public MTAQuizEntities Db { get; set; }

        public GeneralService()
        {
            if (Db == null)
                Db = new MTAQuizEntities();
        }

        public bool CheckLogin(string user, string pass, out int per)
        {
            per = -1;
            try
            {
                //// đặt mặc định permisstion là bao nhiêu.
                //var staffList = (from obj in Db.STAFFS
                //                 where ((obj.Username == user.ToUpper()) && (obj.Password == pass) && (obj.Permission > 0))
                //                 select obj).ToList();
                //if (staffList == null || staffList.Count == 0)
                //    return false;
                //else
                //{
                //    if (staffList[0].Permission.ToString() == null)
                //        return false;
                //    else
                //        per = staffList[0].Permission;
                //}

                return true;
            }
            catch
            {
                return false;
            }
        }
        //public STAFF GetNameAccount(string user, string pass)
        //{
        //    STAFF strName = (from x in Db.STAFFS
        //                     where x.Username == user && x.Password == pass
        //                     select x).FirstOrDefault();
        //    return strName;
        //}
    }
}
