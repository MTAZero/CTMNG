using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IPositionService
    {
        POSITION Add(POSITION POSITION);

        POSITION GetById(int id);

        void Update(POSITION POSITION);

        POSITION Delete(int id);

        IEnumerable<POSITION> GetAll();

        void Save();
    }

    public class PositionService : IPositionService
    {
        private IPositionRepository _PositionRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public PositionService()
        {
            dbFactory = new DbFactory();
            this._PositionRepository = new PositionRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public POSITION Add(POSITION POSITION)
        {
            return _PositionRepository.Add(POSITION);
        }

        public POSITION Delete(int id)
        {
            return _PositionRepository.Delete(id);
        }

        public IEnumerable<POSITION> GetAll()
        {
            return _PositionRepository.GetAll();
        }

        public POSITION GetById(int id)
        {
            return _PositionRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(POSITION POSITION)
        {
            _PositionRepository.Update(POSITION);
        }
    }
}