using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IOriginalTestDetailRepository : IRepository<ORIGINAL_TEST_DETAILS>
    {
    }

    public class OriginalTestDetailRepository : RepositoryBase<ORIGINAL_TEST_DETAILS>, IOriginalTestDetailRepository
    {
        public OriginalTestDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}