using EXON_EM.Data.Interface;
using EXON_EM.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON_EM.Data.Service
{
    public class Subject_Service : IService<SUBJECT>
    {
        // database
        private EXON_DbContext db = new EXON_DbContext();

        // Insert
        public SUBJECT Add(SUBJECT entity)
        {
            try
            {
                db.SUBJECTS.Add(entity);
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
                SUBJECT a = Find(id);
                db.SUBJECTS.Remove(a);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Xóa theo thực thể
        public bool Delete(SUBJECT entity)
        {
            try
            {
                db.SUBJECTS.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Tìm theo khóa chính
        public SUBJECT Find(int id)
        {
            SUBJECT a = db.SUBJECTS.Where(p => p.SubjectID == id).FirstOrDefault();
            return a;
        }

        // get List
        public IEnumerable<SUBJECT> getAll()
        {
            return db.SUBJECTS.ToList();
        }

        // cập nhật thực thể
        public bool Update(SUBJECT entity)
        {
            try
            {
                SUBJECT k = Find(entity.SubjectID);

                if (k == null) return false;

                k.SubjectCode = entity.SubjectCode;
                k.SubjectName = entity.SubjectName;
                k.Status = entity.Status;
                k.DepartmentID = entity.DepartmentID;

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
