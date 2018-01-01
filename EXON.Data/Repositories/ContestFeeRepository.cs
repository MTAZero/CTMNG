using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IContestFeeRepository : IRepository<CONTEST_FEES>
    {
        
    }

    public class ContestFeeRepository : RepositoryBase<CONTEST_FEES>, IContestFeeRepository
    {
        public ContestFeeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}