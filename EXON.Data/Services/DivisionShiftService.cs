using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IDivisionShiftService
    {
        DIVISION_SHIFTS Add(DIVISION_SHIFTS DIVISION_SHIFTS);

        void Update(DIVISION_SHIFTS DIVISION_SHIFTS);

        DIVISION_SHIFTS Delete(int id);

        IEnumerable<DIVISION_SHIFTS> GetAll();

        IEnumerable<DIVISION_SHIFTS> GetByShift(int ShiftID);

        DIVISION_SHIFTS GetById(int id);

        void Save();
    }

    public class DivisionShiftService : IDivisionShiftService
    {
        private IDivisionShiftRepository _DivisionShiftRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public DivisionShiftService()
        {
            dbFactory = new DbFactory();
            this._DivisionShiftRepository = new DivisionShiftRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public DIVISION_SHIFTS Add(DIVISION_SHIFTS DIVISION_SHIFTS)
        {
            return _DivisionShiftRepository.Add(DIVISION_SHIFTS);
        }

        public DIVISION_SHIFTS Delete(int id)
        {
            return _DivisionShiftRepository.Delete(id);
        }

        public IEnumerable<DIVISION_SHIFTS> GetAll()
        {
            return _DivisionShiftRepository.GetAll();
        }

        public DIVISION_SHIFTS GetById(int id)
        {
            return _DivisionShiftRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(DIVISION_SHIFTS DIVISION_SHIFTS)
        {
            _DivisionShiftRepository.Update(DIVISION_SHIFTS);
        }

        public IEnumerable<DIVISION_SHIFTS> GetByShift(int ShiftID)
        {
            return _DivisionShiftRepository.GetMulti(x => x.ShiftID == ShiftID);
        }
    }
}