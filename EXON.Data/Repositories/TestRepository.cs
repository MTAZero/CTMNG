using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface ITestRepository : IRepository<TEST>
    {
    }

    public class TestRepository : RepositoryBase<TEST>, ITestRepository
    {
        public TestRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}