using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IContestantShiftService
    {
        CONTESTANTS_SHIFTS Add(CONTESTANTS_SHIFTS CONTESTANTS_SHIFTS);

        void Update(CONTESTANTS_SHIFTS CONTESTANTS_SHIFTS);

        CONTESTANTS_SHIFTS Delete(int id);

        IEnumerable<CONTESTANTS_SHIFTS> GetAll();

        IEnumerable<CONTESTANTS_SHIFTS> GetAllByShift(int ShiftId);

        IEnumerable<CONTESTANTS_SHIFTS> GetAllBySchedule(int ScheduleId);

        IEnumerable<CONTESTANTS_SHIFTS> GetAllByScheduleShift(int ScheduleId, int ShiftId);

        CONTESTANTS_SHIFTS GetById(int id);

        void Save();
    }

    public class ContestantShiftService : IContestantShiftService
    {
        private IContestantShiftRepository _ContestantShiftRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ContestantShiftService()
        {
            dbFactory = new DbFactory();
            this._ContestantShiftRepository = new ContestantShiftRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public CONTESTANTS_SHIFTS Add(CONTESTANTS_SHIFTS CONTESTANTS_SHIFTS)
        {
            return _ContestantShiftRepository.Add(CONTESTANTS_SHIFTS);
        }

        public CONTESTANTS_SHIFTS Delete(int id)
        {
            return _ContestantShiftRepository.Delete(id);
        }

        public IEnumerable<CONTESTANTS_SHIFTS> GetAll()
        {
            return _ContestantShiftRepository.GetAll();
        }

        public CONTESTANTS_SHIFTS GetById(int id)
        {
            return _ContestantShiftRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CONTESTANTS_SHIFTS CONTESTANTS_SHIFTS)
        {
            _ContestantShiftRepository.Update(CONTESTANTS_SHIFTS);
        }

        public IEnumerable<CONTESTANTS_SHIFTS> GetAllByShift(int ShiftId)
        {
            return _ContestantShiftRepository.GetMulti(x => x.ShiftID == ShiftId);
        }

        public IEnumerable<CONTESTANTS_SHIFTS> GetAllBySchedule(int ScheduleId)
        {
            return _ContestantShiftRepository.GetMulti(x => x.ScheduleID == ScheduleId);
        }

        public IEnumerable<CONTESTANTS_SHIFTS> GetAllByScheduleShift(int ScheduleId, int ShiftId)
        {
            return _ContestantShiftRepository.GetMulti(x => x.ScheduleID == ScheduleId && x.ShiftID == ShiftId);
        }
    }
}