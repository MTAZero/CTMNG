using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IContestantShiftRepository : IRepository<CONTESTANTS_SHIFTS>
    {
    }

    public class ContestantShiftRepository : RepositoryBase<CONTESTANTS_SHIFTS>, IContestantShiftRepository
    {
        public ContestantShiftRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}