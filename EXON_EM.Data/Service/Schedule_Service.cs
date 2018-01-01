using EXON_EM.Data.Interface;
using EXON_EM.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON_EM.Data.Service
{
    public class Schedule_Service : IService<SCHEDULE>
    {
        // database
        private EXON_DbContext db = new EXON_DbContext();

        // Insert
        public SCHEDULE Add(SCHEDULE entity)
        {
            try
            {
                db.SCHEDULES.Add(entity);
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
                SCHEDULE a = Find(id);
                db.SCHEDULES.Remove(a);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa theo thực thể
        public bool Delete(SCHEDULE entity)
        {
            try
            {
                db.SCHEDULES.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Tìm theo khóa chính
        public SCHEDULE Find(int id)
        {
            SCHEDULE a = db.SCHEDULES.Where(p => p.ScheduleID == id).FirstOrDefault();
            return a;
        }

        // get List
        public IEnumerable<SCHEDULE> getAll()
        {
            return db.SCHEDULES.ToList();
        }

        // cập nhật thực thể
        public bool Update(SCHEDULE entity)
        {
            try
            {
                SCHEDULE k = Find(entity.ScheduleID);

                if (k == null) return false;

                k.TimeOfTest = entity.TimeOfTest;
                k.TimeToSubmit = entity.TimeToSubmit;
                k.Status = entity.Status;
                k.ContestID = entity.ContestID;
                k.SubjectID = entity.SubjectID;
                k.Fee = entity.Fee;
                k.Unit = entity.Unit;
                k.ContestTypeID = entity.ContestTypeID;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
