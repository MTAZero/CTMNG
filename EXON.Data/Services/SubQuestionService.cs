using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface ISubQuestionService
    {
        SUBQUESTION Add(SUBQUESTION SUBQUESTION);

        void Update(SUBQUESTION SUBQUESTION);

        SUBQUESTION Delete(int id);

        IEnumerable<SUBQUESTION> GetAll();

        IEnumerable<SUBQUESTION> GetAll(int QuestionId);

        IEnumerable<SUBQUESTION> GetAll(string keyword, int QuestionId);

        SUBQUESTION GetById(int id);

        void Save();
    }

    public class SubQuestionService : ISubQuestionService
    {
        private ISubQuestionRepository _SubQuestionRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public SubQuestionService()
        {
            dbFactory = new DbFactory();
            this._SubQuestionRepository = new SubQuestionRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public SUBQUESTION Add(SUBQUESTION SUBQUESTION)
        {
            return _SubQuestionRepository.Add(SUBQUESTION);
        }

        public SUBQUESTION Delete(int id)
        {
            return _SubQuestionRepository.Delete(id);
        }

        public IEnumerable<SUBQUESTION> GetAll(int QuestionId)
        {
            return _SubQuestionRepository.GetMulti(x => x.QuestionID == QuestionId);
        }

        public IEnumerable<SUBQUESTION> GetAll(string keyword, int QuestionId)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _SubQuestionRepository.GetMulti(x => x.SubQuestionContent.Contains(keyword) && x.QuestionID == QuestionId);
            else
                return _SubQuestionRepository.GetMulti(x => x.QuestionID == QuestionId);
        }

        public SUBQUESTION GetById(int id)
        {
            return _SubQuestionRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(SUBQUESTION SUBQUESTION)
        {
            _SubQuestionRepository.Update(SUBQUESTION);
        }

        public IEnumerable<SUBQUESTION> GetAll()
        {
            return _SubQuestionRepository.GetAll();
        }
    }
}