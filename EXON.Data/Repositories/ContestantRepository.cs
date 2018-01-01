using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IContestantRepository : IRepository<CONTESTANT>
    {
    }

    public class ContestantRepository : RepositoryBase<CONTESTANT>, IContestantRepository
    {
        public ContestantRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}