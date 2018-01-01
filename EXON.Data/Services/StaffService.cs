using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IStaffService
    {
        STAFF Add(STAFF STAFF);

        void Update(STAFF STAFF);

        STAFF Delete(int id);

        IEnumerable<STAFF> GetAll();

        IEnumerable<STAFF> GetAllDeparment(int DeparmentID);

        int GetIdByUserPass(string user, string pass);

        STAFF GetById(int id);

        void Save();

        bool Login(string Username, string Password);
    }

    public class StaffService : IStaffService
    {
        private IStaffRepository _StaffRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public StaffService()
        {
            dbFactory = new DbFactory();
            this._StaffRepository = new StaffRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public STAFF Add(STAFF STAFF)
        {
            return _StaffRepository.Add(STAFF);
        }

        public STAFF Delete(int id)
        {
            return _StaffRepository.Delete(id);
        }

        public IEnumerable<STAFF> GetAll()
        {
            return _StaffRepository.GetAll();
        }

        public STAFF GetById(int id)
        {
            return _StaffRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(STAFF STAFF)
        {
            _StaffRepository.Update(STAFF);
        }

        public bool Login(string Username, string Password)
        {
            STAFF currentStaff = _StaffRepository.GetSingleByCondition(x => x.Username == Username);
            if (currentStaff != null && currentStaff.Password == Password)
                return true;
            else return false;
        }

        public int GetIdByUserPass(string user, string pass)
        {
            STAFF currentStaff = _StaffRepository.GetSingleByCondition(x => x.Username == user && x.Password == pass);
            return currentStaff.StaffID;
        }

        public IEnumerable<STAFF> GetAllDeparment(int DeparmentID)
        {
            return _StaffRepository.GetMulti(x => x.DepartmentID == DeparmentID);
        }

    }
}