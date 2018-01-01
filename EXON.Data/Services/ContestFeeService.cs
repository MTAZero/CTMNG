using EXON.Common;
using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IContestFeeService
    {
        CONTEST_FEES Add(CONTEST_FEES CONTEST_FEES);

        void Update(CONTEST_FEES CONTEST_FEES);

        CONTEST_FEES Delete(int id);

        IEnumerable<CONTEST_FEES> GetAll();

        IEnumerable<CONTEST_FEES> GetByContestId(int id);

        CONTEST_FEES GetById(int id);

        void Save();
    }

    public class ContestFeeService : IContestFeeService
    {
        private IContestFeeRepository _ContestFeeRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ContestFeeService()
        {
            dbFactory = new DbFactory();
            this._ContestFeeRepository = new ContestFeeRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public CONTEST_FEES Add(CONTEST_FEES CONTEST_FEES)
        {
            return _ContestFeeRepository.Add(CONTEST_FEES);
        }

        public CONTEST_FEES Delete(int id)
        {
            return _ContestFeeRepository.Delete(id);
        }

        public IEnumerable<CONTEST_FEES> GetAll()
        {
            return _ContestFeeRepository.GetAll();
        }

     

        public CONTEST_FEES GetById(int id)
        {
            return _ContestFeeRepository.GetSingleById(id);
        }
        public IEnumerable<CONTEST_FEES> GetByContestId(int id)
        {
            return _ContestFeeRepository.GetMulti(x => x.ContestID == id);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CONTEST_FEES CONTEST_FEES)
        {
            _ContestFeeRepository.Update(CONTEST_FEES);
        }
    }
}