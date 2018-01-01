using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IContestantSubjectService
    {
        CONTESTANTS_SUBJECTS Add(CONTESTANTS_SUBJECTS CONTESTANT);

        void Update(CONTESTANTS_SUBJECTS CONTESTANT);

        CONTESTANTS_SUBJECTS Delete(int id);

        IEnumerable<CONTESTANTS_SUBJECTS> GetAll();

        CONTESTANTS_SUBJECTS GetById(int id);

        void Save();
    }

    public class ContestantSubjectService : IContestantSubjectService
    {
        private IContestanSubjectRepository _IContestantSubjectRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ContestantSubjectService()
        {
            dbFactory = new DbFactory();
            this._IContestantSubjectRepository = new ContestanSubjectRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public CONTESTANTS_SUBJECTS Add(CONTESTANTS_SUBJECTS CONTESTANT)
        {
            return _IContestantSubjectRepository.Add(CONTESTANT);
        }

        public CONTESTANTS_SUBJECTS Delete(int id)
        {
            return _IContestantSubjectRepository.Delete(id);
        }

        public IEnumerable<CONTESTANTS_SUBJECTS> GetAll()
        {
            return _IContestantSubjectRepository.GetAll();
        }

        public CONTESTANTS_SUBJECTS GetById(int id)
        {
            return _IContestantSubjectRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CONTESTANTS_SUBJECTS CONTESTANT)
        {
            _IContestantSubjectRepository.Update(CONTESTANT);
        }
    }
}