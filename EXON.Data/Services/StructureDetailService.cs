using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IStructureDetailService
    {
        STRUCTURE_DETAILS Add(STRUCTURE_DETAILS STRUCTURE_DETAILS);

        void Update(STRUCTURE_DETAILS STRUCTURE_DETAILS);

        STRUCTURE_DETAILS Delete(int id);

        STRUCTURE_DETAILS GetById(int id);

        IEnumerable<STRUCTURE_DETAILS> GetAll(int structureId, int topicID);

        void Save();
    }

    public class StructureDetailService : IStructureDetailService
    {
        private IStructureDetailRepository _StructureDetailRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public StructureDetailService()
        {
            dbFactory = new DbFactory();
            this._StructureDetailRepository = new StructureDetailRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public STRUCTURE_DETAILS Add(STRUCTURE_DETAILS STRUCTURE_DETAILS)
        {
            return _StructureDetailRepository.Add(STRUCTURE_DETAILS);
        }

        public STRUCTURE_DETAILS Delete(int id)
        {
            return _StructureDetailRepository.Delete(id);
        }

        public STRUCTURE_DETAILS GetById(int id)
        {
            return _StructureDetailRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(STRUCTURE_DETAILS STRUCTURE_DETAILS)
        {
            _StructureDetailRepository.Update(STRUCTURE_DETAILS);
        }

        public IEnumerable<STRUCTURE_DETAILS> GetAll(int structureId, int topicID)
        {
            return _StructureDetailRepository.GetMulti(x => x.StructureID == structureId && x.TopicID == topicID);
        }
    }
}