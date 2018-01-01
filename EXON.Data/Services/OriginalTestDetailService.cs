using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IOriginalTestDetailService
    {
        ORIGINAL_TEST_DETAILS Add(ORIGINAL_TEST_DETAILS ORIGINAL_TEST_DETAILS);

        void Update(ORIGINAL_TEST_DETAILS ORIGINAL_TEST_DETAILS);

        ORIGINAL_TEST_DETAILS Delete(int id);

        IEnumerable<ORIGINAL_TEST_DETAILS> GetAll();

        IEnumerable<ORIGINAL_TEST_DETAILS> GetAll(int OriginalTestId);

        ORIGINAL_TEST_DETAILS GetById(int id);

        void DeleteAllByOriginalTest(int OriginalTestId);

        void Save();
    }

    public class OriginalTestDetailService : IOriginalTestDetailService
    {
        private IOriginalTestDetailRepository _OriginalTestDetailRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public OriginalTestDetailService()
        {
            dbFactory = new DbFactory();
            this._OriginalTestDetailRepository = new OriginalTestDetailRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public ORIGINAL_TEST_DETAILS Add(ORIGINAL_TEST_DETAILS ORIGINAL_TEST_DETAILS)
        {
            return _OriginalTestDetailRepository.Add(ORIGINAL_TEST_DETAILS);
        }

        public ORIGINAL_TEST_DETAILS Delete(int id)
        {
            return _OriginalTestDetailRepository.Delete(id);
        }

        public IEnumerable<ORIGINAL_TEST_DETAILS> GetAll(int OriginalTestId)
        {
            return _OriginalTestDetailRepository.GetMulti(x => x.OriginalTestID == OriginalTestId);
        }

        public ORIGINAL_TEST_DETAILS GetById(int id)
        {
            return _OriginalTestDetailRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ORIGINAL_TEST_DETAILS ORIGINAL_TEST_DETAILS)
        {
            _OriginalTestDetailRepository.Update(ORIGINAL_TEST_DETAILS);
        }

        public void DeleteAllByOriginalTest(int OriginalTestId)
        {
            _OriginalTestDetailRepository.DeleteMulti(x => x.OriginalTestID == OriginalTestId);
        }

        public IEnumerable<ORIGINAL_TEST_DETAILS> GetAll()
        {
            return _OriginalTestDetailRepository.GetAll();
        }
    }
}