using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IAnswerRepository : IRepository<ANSWER>
    {
    }

    public class AnswerRepository : RepositoryBase<ANSWER>, IAnswerRepository
    {
        public AnswerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}