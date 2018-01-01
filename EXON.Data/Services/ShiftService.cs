using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IShiftService
    {
        SHIFT Add(SHIFT SHIFT);

        void Update(SHIFT SHIFT);

        SHIFT Delete(int id);

        IEnumerable<SHIFT> GetAll(int ContestId);

        SHIFT GetById(int id);

        void Save();
    }

    public class ShiftService : IShiftService
    {
        private IShiftRepository _ShiftRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ShiftService()
        {
            dbFactory = new DbFactory();
            this._ShiftRepository = new ShiftRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public SHIFT Add(SHIFT SHIFT)
        {
            return _ShiftRepository.Add(SHIFT);
        }

        public SHIFT Delete(int id)
        {
            return _ShiftRepository.Delete(id);
        }

        public IEnumerable<SHIFT> GetAll(int ContestId)
        {
            return _ShiftRepository.GetMulti(x => x.ContestID == ContestId);
        }

        public SHIFT GetById(int id)
        {
            return _ShiftRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(SHIFT SHIFT)
        {
            _ShiftRepository.Update(SHIFT);
        }
    }
}