using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IQuestionRepository : IRepository<QUESTION>
    {
    }

    public class QuestionRepository : RepositoryBase<QUESTION>, IQuestionRepository
    {
        public QuestionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}