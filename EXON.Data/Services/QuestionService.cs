using EXON.Common;
using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IQuestionService
    {
        QUESTION Add(QUESTION QUESTION);

        void Update(QUESTION QUESTION);

        QUESTION Delete(int id);

        IEnumerable<QUESTION> GetAll();

        IEnumerable<QUESTION> GetAll(string keyword);

        QUESTION GetById(int id);

        IEnumerable<QUESTION> GetByTopicType(int idTopic, int idType);

        IEnumerable<QUESTION> GetByTopicStaff(int idTopic, int StaffId);

        IEnumerable<QUESTION> GetByTopicLevel(int idTopic, int level);

        IEnumerable<QUESTION> GetNewByTopicType(int idTopic, int idType);

        IEnumerable<QUESTION> GetNewByTopic(int idTopic);

        List<QUESTION> GetRandomList(List<QUESTION> listQuestion, int numQuestion);

        void Save();
    }

    public class QuestionService : IQuestionService
    {
        private IQuestionRepository _QuestionRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public QuestionService()
        {
            dbFactory = new DbFactory();
            this._QuestionRepository = new QuestionRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public QUESTION Add(QUESTION QUESTION)
        {
            return _QuestionRepository.Add(QUESTION);
        }

        public QUESTION Delete(int id)
        {
            return _QuestionRepository.Delete(id);
        }

        public IEnumerable<QUESTION> GetAll()
        {
            return _QuestionRepository.GetAll();
        }

        public IEnumerable<QUESTION> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _QuestionRepository.GetMulti(x => x.QuestionContent.Contains(keyword));
            else
                return _QuestionRepository.GetAll();
        }

        public QUESTION GetById(int id)
        {
            return _QuestionRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(QUESTION QUESTION)
        {
            _QuestionRepository.Update(QUESTION);
        }

        public IEnumerable<QUESTION> GetByTopicType(int idTopic, int idType)
        {
            return _QuestionRepository.GetMulti(x => x.TopicID == idTopic
            && x.QuestionTypeID == idType
            && x.Status == (int)QuestionStatus.Accepted);
        }

        public IEnumerable<QUESTION> GetNewByTopicType(int idTopic, int idType)
        {
            return _QuestionRepository.GetMulti(x => x.TopicID == idTopic
            && x.QuestionTypeID == idType
            && x.Status == (int)QuestionStatus.New);
        }

        public IEnumerable<QUESTION> GetByTopicLevel(int idTopic, int level)
        {
            return _QuestionRepository.GetMulti(x => x.TopicID == idTopic
            && x.Level == level
            && x.Status == (int)QuestionStatus.Accepted);
        }

        public List<QUESTION> GetRandomList(List<QUESTION> listQuestion, int numQuestion)
        {
            return _QuestionRepository.GetRandomList(listQuestion, numQuestion);
        }

        public IEnumerable<QUESTION> GetByTopicStaff(int idTopic, int StaffId)
        {
            return _QuestionRepository.GetMulti(x => x.TopicID == idTopic
                && x.CreatedStaffID == StaffId
                && x.Status == (int)QuestionStatus.New);
        }

        public IEnumerable<QUESTION> GetNewByTopic(int idTopic)
        {
            return _QuestionRepository.GetMulti(x => x.TopicID == idTopic
                && x.Status == (int)QuestionStatus.New);
        }
    }
}