using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface ITestDetailService
    {
        TEST_DETAILS Add(TEST_DETAILS TEST_DETAILS);

        void Update(TEST_DETAILS TEST_DETAILS);

        TEST_DETAILS Delete(int id);

        IEnumerable<TEST_DETAILS> GetAll(int TestId);

        TEST_DETAILS GetById(int id);

        void Save();
    }

    public class TestDetailService : ITestDetailService
    {
        private ITestDetailRepository _TestDetailRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public TestDetailService()
        {
            dbFactory = new DbFactory();
            this._TestDetailRepository = new TestDetailRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public TEST_DETAILS Add(TEST_DETAILS TEST_DETAILS)
        {
            return _TestDetailRepository.Add(TEST_DETAILS);
        }

        public TEST_DETAILS Delete(int id)
        {
            return _TestDetailRepository.Delete(id);
        }

        public IEnumerable<TEST_DETAILS> GetAll(int TestId)
        {
            return _TestDetailRepository.GetMulti(x => x.TestID == TestId);
        }

        public TEST_DETAILS GetById(int id)
        {
            return _TestDetailRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(TEST_DETAILS TEST_DETAILS)
        {
            _TestDetailRepository.Update(TEST_DETAILS);
        }
    }
}