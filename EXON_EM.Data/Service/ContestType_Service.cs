using EXON_EM.Data.Interface;
using EXON_EM.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON_EM.Data.Service
{
    public class ContestType_Service : IService<CONTEST_TYPES>
    {
        // database
        private EXON_DbContext db = new EXON_DbContext();

        // Insert
        public CONTEST_TYPES Add(CONTEST_TYPES entity)
        {
            try
            {
                db.CONTEST_TYPES.Add(entity);
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
                CONTEST_TYPES a = Find(id);
                db.CONTEST_TYPES.Remove(a);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa theo thực thể
        public bool Delete(CONTEST_TYPES entity)
        {
            try
            {
                db.CONTEST_TYPES.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Tìm theo khóa chính
        public CONTEST_TYPES Find(int id)
        {
            CONTEST_TYPES a = db.CONTEST_TYPES.Where(p => p.ContestTypeID == id).FirstOrDefault();
            return a;
        }

        // get List
        public IEnumerable<CONTEST_TYPES> getAll()
        {
            return db.CONTEST_TYPES.ToList();
        }

        // cập nhật thực thể
        public bool Update(CONTEST_TYPES entity)
        {
            try
            {
                CONTEST_TYPES k = Find(entity.ContestTypeID);

                if (k == null) return false;

                
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
