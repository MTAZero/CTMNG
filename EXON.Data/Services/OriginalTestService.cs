using EXON.Common;
using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IOriginalTestService
    {
        ORIGINAL_TESTS Add(ORIGINAL_TESTS ORIGINAL_TESTS);

        void Update(ORIGINAL_TESTS ORIGINAL_TESTS);

        ORIGINAL_TESTS Delete(int id);

        IEnumerable<ORIGINAL_TESTS> GetAll();

        IEnumerable<ORIGINAL_TESTS> GetByContest2Subject(int CurrentContestId, int CurrentSubjectId);

        IEnumerable<ORIGINAL_TESTS> GetByNewContest2Subject(int CurrentContestId, int CurrentSubjectId);

        ORIGINAL_TESTS GetById(int id);

        void Save();
    }

    public class OriginalTestService : IOriginalTestService
    {
        private IOriginalTestRepository _OriginalTestRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public OriginalTestService()
        {
            dbFactory = new DbFactory();
            this._OriginalTestRepository = new OriginalTestRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public ORIGINAL_TESTS Add(ORIGINAL_TESTS ORIGINAL_TESTS)
        {
            return _OriginalTestRepository.Add(ORIGINAL_TESTS);
        }

        public ORIGINAL_TESTS Delete(int id)
        {
            return _OriginalTestRepository.Delete(id);
        }

        public IEnumerable<ORIGINAL_TESTS> GetAll()
        {
            return _OriginalTestRepository.GetAll();
        }

        public ORIGINAL_TESTS GetById(int id)
        {
            return _OriginalTestRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ORIGINAL_TESTS ORIGINAL_TESTS)
        {
            _OriginalTestRepository.Update(ORIGINAL_TESTS);
        }

        public IEnumerable<ORIGINAL_TESTS> GetByContest2Subject(int CurrentContestId, int CurrentSubjectId)
        {
            return _OriginalTestRepository
                .GetMulti(x => x.ContestID == CurrentContestId
                && x.SubjectID == CurrentSubjectId && x.Status == (int)OriginalTestStatus.Accepted);
        }

        public IEnumerable<ORIGINAL_TESTS> GetByNewContest2Subject(int CurrentContestId, int CurrentSubjectId)
        {
            return _OriginalTestRepository
                .GetMulti(x => x.ContestID == CurrentContestId
                && x.SubjectID == CurrentSubjectId);
        }
    }
}