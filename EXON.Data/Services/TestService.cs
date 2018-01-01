using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface ITestService
    {
        TEST Add(TEST TEST);

        void Update(TEST TEST);

        TEST Delete(int id);

        IEnumerable<TEST> GetAll();

        IEnumerable<TEST> GetAllBySubject(int SubjectID);

        TEST GetById(int id);

        void Save();
    }

    public class TestService : ITestService
    {
        private ITestRepository _TestRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public TestService()
        {
            dbFactory = new DbFactory();
            this._TestRepository = new TestRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public TEST Add(TEST TEST)
        {
            return _TestRepository.Add(TEST);
        }

        public TEST Delete(int id)
        {
            return _TestRepository.Delete(id);
        }

        public IEnumerable<TEST> GetAll()
        {
            return _TestRepository.GetAll();
        }

        public TEST GetById(int id)
        {
            return _TestRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(TEST TEST)
        {
            _TestRepository.Update(TEST);
        }

        public IEnumerable<TEST> GetAllBySubject(int SubjectID)
        {
            return _TestRepository.GetMulti(x => x.SubjectID == SubjectID);
        }
    }
}