using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IQuestionTypeRepository : IRepository<QUESTION_TYPES>
    {
    }

    public class QuestionTypeRepository : RepositoryBase<QUESTION_TYPES>, IQuestionTypeRepository
    {
        public QuestionTypeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}