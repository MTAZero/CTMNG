using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface ISubjectService
    {
        SUBJECT Add(SUBJECT SUBJECT);

        void Update(SUBJECT SUBJECT);

        SUBJECT Delete(int id);

        IEnumerable<SUBJECT> GetAll();

        IEnumerable<SUBJECT> GetAllByDepartment(int DepartmentID);

        IEnumerable<SUBJECT> GetAll(string keyword, int DepartmentID);

        SUBJECT GetById(int id);

        void Save();
    }

    public class SubjectService : ISubjectService
    {
        private ISubjectRepository _SUBJECTRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public SubjectService()
        {
            dbFactory = new DbFactory();
            this._SUBJECTRepository = new SubjectRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public SUBJECT Add(SUBJECT SUBJECT)
        {
            return _SUBJECTRepository.Add(SUBJECT);
        }

        public SUBJECT Delete(int id)
        {
            return _SUBJECTRepository.Delete(id);
        }

        public IEnumerable<SUBJECT> GetAll()
        {
            return _SUBJECTRepository.GetAll();
        }

        public IEnumerable<SUBJECT> GetAll(string keyword, int DepartmentID)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _SUBJECTRepository.GetMulti(x => x.SubjectName.Contains(keyword) && x.DepartmentID == DepartmentID);
            else
                return _SUBJECTRepository.GetMulti(x => x.DepartmentID == DepartmentID);
        }
        
        public SUBJECT GetById(int id)
        {
            return _SUBJECTRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(SUBJECT SUBJECT)
        {
            _SUBJECTRepository.Update(SUBJECT);
        }

        public IEnumerable<SUBJECT> GetAllByDepartment(int DepartmentID)
        {
            return _SUBJECTRepository.GetMulti(x => x.DepartmentID == DepartmentID || true);
        }
    }
}