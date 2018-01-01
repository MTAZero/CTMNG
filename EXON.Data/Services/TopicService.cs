using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface ITopicService
    {
        TOPIC Add(TOPIC TOPIC);

        void Update(TOPIC TOPIC);

        TOPIC Delete(int id);

        IEnumerable<TOPIC> GetAll(int SubjectId);

        IEnumerable<TOPIC> GetAll(string keyword, int SubjectId);

        TOPIC GetById(int id);

        void Save();
    }

    public class TopicService : ITopicService
    {
        private ITopicRepository _TOPICRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public TopicService()
        {
            dbFactory = new DbFactory();
            this._TOPICRepository = new TopicRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public TOPIC Add(TOPIC TOPIC)
        {
            return _TOPICRepository.Add(TOPIC);
        }

        public TOPIC Delete(int id)
        {
            return _TOPICRepository.Delete(id);
        }

        public IEnumerable<TOPIC> GetAll(int SubjectId)
        {
            return _TOPICRepository.GetMulti(x => x.SubjectID == SubjectId);
        }

        public IEnumerable<TOPIC> GetAll(string keyword, int SubjectId)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _TOPICRepository.GetMulti(x => x.TopicName.Contains(keyword) && x.SubjectID == SubjectId);
            else
                return _TOPICRepository.GetMulti(x => x.SubjectID == SubjectId);
        }

        public TOPIC GetById(int id)
        {
            return _TOPICRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(TOPIC TOPIC)
        {
            _TOPICRepository.Update(TOPIC);
        }
    }
}