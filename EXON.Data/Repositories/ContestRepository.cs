using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IContestRepository : IRepository<CONTEST>
    {
    }

    public class ContestRepository : RepositoryBase<CONTEST>, IContestRepository
    {
        public ContestRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}