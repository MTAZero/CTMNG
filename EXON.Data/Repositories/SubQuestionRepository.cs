using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface ISubQuestionRepository : IRepository<SUBQUESTION>
    {
    }

    public class SubQuestionRepository : RepositoryBase<SUBQUESTION>, ISubQuestionRepository
    {
        public SubQuestionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}