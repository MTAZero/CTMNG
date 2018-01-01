using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;

namespace EXON.Data.Services
{
    public interface IQuestionTypeService
    {
        QUESTION_TYPES Add(QUESTION_TYPES QUESTION_TYPES);

        void Update(QUESTION_TYPES QUESTION_TYPES);

        QUESTION_TYPES Delete(int id);

        IEnumerable<QUESTION_TYPES> GetAll();

        IEnumerable<QUESTION_TYPES> GetAll(string keyword);

        QUESTION_TYPES GetById(int id);

        void Save();
    }

    public class QuestionTypeService : IQuestionTypeService
    {
        private IQuestionTypeRepository _QuestionTypeRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public QuestionTypeService()
        {
            dbFactory = new DbFactory();
            this._QuestionTypeRepository = new QuestionTypeRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public QUESTION_TYPES Add(QUESTION_TYPES QUESTION_TYPES)
        {
            return _QuestionTypeRepository.Add(QUESTION_TYPES);
        }

        public QUESTION_TYPES Delete(int id)
        {
            return _QuestionTypeRepository.Delete(id);
        }

        public IEnumerable<QUESTION_TYPES> GetAll()
        {
            return _QuestionTypeRepository.GetAll();
        }

        public IEnumerable<QUESTION_TYPES> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _QuestionTypeRepository.GetMulti(x => x.QuestionTypeName.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _QuestionTypeRepository.GetAll();
        }

        public QUESTION_TYPES GetById(int id)
        {
            return _QuestionTypeRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(QUESTION_TYPES QUESTION_TYPES)
        {
            _QuestionTypeRepository.Update(QUESTION_TYPES);
        }
    }
}