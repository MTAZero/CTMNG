using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace EXON.Data.Services
{
    public interface IStaffPositionService
    {
        STAFFS_POSITIONS Add(STAFFS_POSITIONS STAFFS_POSITIONS);

        void Update(STAFFS_POSITIONS STAFFS_POSITIONS);

        STAFFS_POSITIONS Delete(int id);

        IEnumerable<STAFFS_POSITIONS> GetAll();

        IEnumerable<STAFFS_POSITIONS> GetAll(int StaffId);

        STAFFS_POSITIONS GetById(int id);

        int GetMaxPosition(int StaffId);

        void Save();
    }

    public class StaffPositionService : IStaffPositionService
    {
        private IStaffPositionRepository _StaffPositionRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public StaffPositionService()
        {
            dbFactory = new DbFactory();
            this._StaffPositionRepository = new StaffPositionRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public STAFFS_POSITIONS Add(STAFFS_POSITIONS STAFFS_POSITIONS)
        {
            return _StaffPositionRepository.Add(STAFFS_POSITIONS);
        }

        public STAFFS_POSITIONS Delete(int id)
        {
            return _StaffPositionRepository.Delete(id);
        }

        public IEnumerable<STAFFS_POSITIONS> GetAll()
        {
            return _StaffPositionRepository.GetAll();
        }

        public STAFFS_POSITIONS GetById(int id)
        {
            return _StaffPositionRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(STAFFS_POSITIONS STAFFS_POSITIONS)
        {
            _StaffPositionRepository.Update(STAFFS_POSITIONS);
        }

        public IEnumerable<STAFFS_POSITIONS> GetAll(int StaffId)
        {
            return _StaffPositionRepository.GetMulti(x => x.StaffID == StaffId);
        }

        public int GetMaxPosition(int StaffId)
        {
            STAFFS_POSITIONS p = _StaffPositionRepository
                .GetMulti(x => x.StaffID == StaffId)
                .OrderBy(x => x.PositionID).FirstOrDefault();

            if (p != null) return p.PositionID;
            else return -1;
        }
    }
}