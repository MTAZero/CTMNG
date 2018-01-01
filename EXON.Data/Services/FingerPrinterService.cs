using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IFingerPrinterService
    {
        FINGERPRINT Add(FINGERPRINT FINGERPRINT);

        void Update(FINGERPRINT FINGERPRINT);

        FINGERPRINT Delete(int id);

        IEnumerable<FINGERPRINT> GetAll();

        IEnumerable<FINGERPRINT> GetByContestantID(int ContestantID);

        IEnumerable<FINGERPRINT> GetAllinContest(int contestid);

        FINGERPRINT GetById(int id);

        void Save();
    }

    public class FingerPrinterService : IFingerPrinterService
    {
        private IFingerPrinterRepository _FingerPrinterRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public FingerPrinterService()
        {
            dbFactory = new DbFactory();
            this._FingerPrinterRepository = new FingerPrinterRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public FINGERPRINT Add(FINGERPRINT FINGERPRINT)
        {
            return _FingerPrinterRepository.Add(FINGERPRINT);
        }

        public FINGERPRINT Delete(int id)
        {
            return _FingerPrinterRepository.Delete(id);
        }

        public IEnumerable<FINGERPRINT> GetByContestantID(int ContestantID)
        {
            return _FingerPrinterRepository.GetMulti(x=>x.ContestantID==ContestantID);
        }


        public FINGERPRINT GetById(int id)
        {
            return _FingerPrinterRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(FINGERPRINT FINGERPRINT)
        {
            _FingerPrinterRepository.Update(FINGERPRINT);
        }

        public IEnumerable<FINGERPRINT> GetAll()
        {
            return _FingerPrinterRepository.GetAll();
        }
        public IEnumerable<FINGERPRINT> GetAllinContest(int contestid)
        {
            return _FingerPrinterRepository.GetMulti(x=>x.CONTESTANT.REGISTER.ContestID==contestid);
        }

    }
}