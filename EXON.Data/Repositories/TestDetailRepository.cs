using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface ITestDetailRepository : IRepository<TEST_DETAILS>
    {
    }

    public class TestDetailRepository : RepositoryBase<TEST_DETAILS>, ITestDetailRepository
    {
        public TestDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}