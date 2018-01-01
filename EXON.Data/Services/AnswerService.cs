using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IAnswerService
    {
        ANSWER Add(ANSWER ANSWER);

        void Update(ANSWER ANSWER);

        ANSWER Delete(int id);

        IEnumerable<ANSWER> GetAll();

        IEnumerable<ANSWER> GetAll(int SubQuestionId);

        IEnumerable<ANSWER> GetAll(string keyword, int SubQuestionId);

        List<ANSWER> GetRandomList(List<ANSWER> listQuestion, int numQuestion);

        ANSWER GetById(int id);

        void Save();
    }

    public class AnswerService : IAnswerService
    {
        private IAnswerRepository _AnswerRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public AnswerService()
        {
            dbFactory = new DbFactory();
            this._AnswerRepository = new AnswerRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public ANSWER Add(ANSWER ANSWER)
        {
            return _AnswerRepository.Add(ANSWER);
        }

        public ANSWER Delete(int id)
        {
            return _AnswerRepository.Delete(id);
        }

        public IEnumerable<ANSWER> GetAll(int SubQuestionId)
        {
            return _AnswerRepository.GetMulti(x => x.SubQuestionID == SubQuestionId);
        }

        public IEnumerable<ANSWER> GetAll(string keyword, int SubQuestionId)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _AnswerRepository.GetMulti(x => x.AnswerContent.Contains(keyword) && x.SubQuestionID == SubQuestionId);
            else
                return _AnswerRepository.GetMulti(x => x.SubQuestionID == SubQuestionId);
        }

        public ANSWER GetById(int id)
        {
            return _AnswerRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ANSWER ANSWER)
        {
            _AnswerRepository.Update(ANSWER);
        }

        public IEnumerable<ANSWER> GetAll()
        {
            return _AnswerRepository.GetAll();
        }

        public List<ANSWER> GetRandomList(List<ANSWER> listQuestion, int numQuestion)
        {
            return _AnswerRepository.GetRandomList(listQuestion, numQuestion);
        }
    }
}