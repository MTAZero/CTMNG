using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace EXON.Data.Services
{
    public interface IDepartmentService
    {
        DEPARTMENT Add(DEPARTMENT DEPARTMENT);

        void Update(DEPARTMENT DEPARTMENT);

        DEPARTMENT Delete(int id);

        IEnumerable<DEPARTMENT> GetAll();

        List<DEPARTMENT> GetRandomList(List<DEPARTMENT> listQuestion, int numQuestion);

        DEPARTMENT GetById(int id);

        void Save();
    }

    public class DepartmentService : IDepartmentService
    {
        private IDeparmentRepository _DepartmentrRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public DepartmentService()
        {
            dbFactory = new DbFactory();
            this._DepartmentrRepository = new DeparmentRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public DEPARTMENT Add(DEPARTMENT DEPARTMENT)
        {
            return _DepartmentrRepository.Add(DEPARTMENT);
        }

        public DEPARTMENT Delete(int id)
        {
            return _DepartmentrRepository.Delete(id);
        }

        public IEnumerable<DEPARTMENT> GetAll()
        {
            return _DepartmentrRepository.GetAll();
        }

        public DEPARTMENT GetById(int id)
        {
            return _DepartmentrRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(DEPARTMENT DEPARTMENT)
        {
            _DepartmentrRepository.Update(DEPARTMENT);
        }

        public List<DEPARTMENT> GetRandomList(List<DEPARTMENT> listQuestion, int numQuestion)
        {
            return _DepartmentrRepository.GetRandomList(listQuestion, numQuestion);
        }
    }
}