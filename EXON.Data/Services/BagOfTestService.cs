using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IBagOfTestService
    {
        BAGOFTEST Add(BAGOFTEST BAGOFTEST);

        void Update(BAGOFTEST BAGOFTEST);

        BAGOFTEST Delete(int id);

        IEnumerable<BAGOFTEST> GetAll();

        IEnumerable<BAGOFTEST> GetAllByDivisionShift(int DivisionShiftID);

        BAGOFTEST GetById(int id);

        void Save();
    }

    public class BagOfTestService : IBagOfTestService
    {
        private IBagOfTestRepository _BagOfTestRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public BagOfTestService()
        {
            dbFactory = new DbFactory();
            this._BagOfTestRepository = new BagOfTestRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public BAGOFTEST Add(BAGOFTEST BAGOFTEST)
        {
            return _BagOfTestRepository.Add(BAGOFTEST);
        }

        public BAGOFTEST Delete(int id)
        {
            return _BagOfTestRepository.Delete(id);
        }

        public IEnumerable<BAGOFTEST> GetAll()
        {
            return _BagOfTestRepository.GetAll();
        }

        public BAGOFTEST GetById(int id)
        {
            return _BagOfTestRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(BAGOFTEST BAGOFTEST)
        {
            _BagOfTestRepository.Update(BAGOFTEST);
        }

        public IEnumerable<BAGOFTEST> GetAllByDivisionShift(int DivisionShiftID)
        {
            return _BagOfTestRepository.GetMulti(x => x.DivisionShiftID == DivisionShiftID);
        }
    }
}