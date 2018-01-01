using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IContestanSubjectRepository : IRepository<CONTESTANTS_SUBJECTS>
    {
    }

    public class ContestanSubjectRepository : RepositoryBase<CONTESTANTS_SUBJECTS>, IContestanSubjectRepository
    {
        public ContestanSubjectRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}