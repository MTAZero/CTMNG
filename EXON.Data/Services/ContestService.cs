using EXON.Common;
using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IContestService
    {
        CONTEST Add(CONTEST CONTEST);

        void Update(CONTEST CONTEST);

        CONTEST Delete(int id);

        IEnumerable<CONTEST> GetAll();

        IEnumerable<CONTEST> GetAllAccepted();
        IEnumerable<CONTEST> GetInRegisterStatus();
        IEnumerable<CONTEST> GetAllInRegisterTime();

        CONTEST GetById(int id);

        void Save();
    }

    public class ContestService : IContestService
    {
        private IContestRepository _ContestRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ContestService()
        {
            dbFactory = new DbFactory();
            this._ContestRepository = new ContestRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public CONTEST Add(CONTEST CONTEST)
        {
            return _ContestRepository.Add(CONTEST);
        }

        public CONTEST Delete(int id)
        {
            return _ContestRepository.Delete(id);
        }

        public IEnumerable<CONTEST> GetAll()
        {
            return _ContestRepository.GetAll();
        }

        public IEnumerable<CONTEST> GetAllAccepted()
        {
            int endDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
            return _ContestRepository
                .GetMulti(x => x.Status != (int)ContestStatus.New && x.Status!=(int)ContestStatus.Cancel);
        }
        public IEnumerable<CONTEST> GetInRegisterStatus()
        {
            //int endDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
            return _ContestRepository
                .GetMulti(x => x.Status ==1);
        }
        public CONTEST GetById(int id)
        {
            return _ContestRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CONTEST CONTEST)
        {
            _ContestRepository.Update(CONTEST);
        }

        public IEnumerable<CONTEST> GetAllInRegisterTime()
        {
            int endDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now);
            return _ContestRepository
                .GetMulti(x => x.Status != (int)ContestStatus.New &&
                x.BeginRegistration <= endDate && x.EndRegistration >= endDate);
        }
    }
}