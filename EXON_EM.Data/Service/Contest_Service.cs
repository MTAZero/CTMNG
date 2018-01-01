using EXON_EM.Data.Interface;
using EXON_EM.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXON_EM.Data.Service
{
    public class Contest_Service : IService<CONTEST>
    {
        // database
        private EXON_DbContext db = new EXON_DbContext();

        // Insert
        public CONTEST Add(CONTEST entity)
        {
            try
            {
                db.CONTESTS.Add(entity);
                db.SaveChanges();
            }
            catch
            {

            }


            return entity;
        }

        // Xóa theo khóa chính
        public bool Delete(int id)
        {
            try
            {
                CONTEST a = Find(id);
                db.CONTESTS.Remove(a);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa theo thực thể
        public bool Delete(CONTEST entity)
        {
            if (entity.ContestID == 0) return true;

            try
            {
                db.SCHEDULES.RemoveRange(db.SCHEDULES.Where(p => p.ContestID == entity.ContestID));
                db.SHIFTS.RemoveRange(db.SHIFTS.Where(p => p.ContestID == entity.ContestID));

                List<LOCATION> listLC = db.LOCATIONS.Where(p => p.ContestID == entity.ContestID).ToList();
                List<ROOMTEST> listRT = (from lc in listLC
                                         from rt in db.ROOMTESTS.Where(p => p.LocationID == lc.LocationID).ToList()
                                         select rt
                                         ).ToList();

                db.ROOMTESTS.RemoveRange(listRT);
                db.LOCATIONS.RemoveRange(listLC);
                db.SaveChanges();

                db.CONTESTS.RemoveRange(db.CONTESTS.Where(p => p.ContestID == entity.ContestID));
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        // Tìm theo khóa chính
        public CONTEST Find(int id)
        {
            CONTEST a = db.CONTESTS.Where(p => p.ContestID == id).FirstOrDefault();
            return a;
        }

        // get List
        public IEnumerable<CONTEST> getAll()
        {
            return db.CONTESTS.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        // cập nhật thực thể
        public bool Update(CONTEST entity)
        {
            try
            {
                CONTEST k = Find(entity.ContestID);

                if (k == null) return false;

                k.ContestName = entity.ContestName;
                k.Description = entity.Description;
                k.CreatedDate = entity.CreatedDate;
                k.EndDate = entity.EndDate;
                k.AcceptedDate = entity.AcceptedDate;
                k.BeginRegistration = entity.BeginRegistration;
                k.EndRegistration = entity.EndRegistration;
                k.CreatedQuestionStartDate = entity.CreatedQuestionStartDate;
                k.CreatedQuestionEndDate = entity.CreatedQuestionEndDate;
                k.SchoolYear = entity.SchoolYear;
                k.Status = entity.Status;
                k.CreatedStaffID = entity.CreatedStaffID;
                k.AcceptedStaffID = entity.AcceptedStaffID;
                k.BeginDate = entity.BeginDate;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public List<STAFFS_POSITIONS> GetStaffPosition(int id)
        {
            return db.STAFFS_POSITIONS.Where(x => x.StaffID == id).ToList();
        }
    }
}
