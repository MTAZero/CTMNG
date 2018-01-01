using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace EXON.Data.Services
{
    public interface IStructureService
    {
        STRUCTURE Add(STRUCTURE STRUCTURE);

        void Update(STRUCTURE STRUCTURE);

        STRUCTURE Delete(int id);

        STRUCTURE GetByScheduleId(int ScheduleId);

        STRUCTURE GetById(int id);

        void Save();
    }

    public class StructureService : IStructureService
    {
        private IStructureRepository _StructureRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public StructureService()
        {
            dbFactory = new DbFactory();
            this._StructureRepository = new StructureRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public STRUCTURE Add(STRUCTURE STRUCTURE)
        {
            return _StructureRepository.Add(STRUCTURE);
        }

        public STRUCTURE Delete(int id)
        {
            return _StructureRepository.Delete(id);
        }

        public STRUCTURE GetById(int id)
        {
            return _StructureRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(STRUCTURE STRUCTURE)
        {
            _StructureRepository.Update(STRUCTURE);
        }

        public IEnumerable<STRUCTURE> GetAll()
        {
            return _StructureRepository.GetAll();
        }

        public STRUCTURE GetByScheduleId(int ScheduleId)
        {
            return _StructureRepository.GetMulti(x => x.ScheduleID == ScheduleId).FirstOrDefault();
        }
    }
}