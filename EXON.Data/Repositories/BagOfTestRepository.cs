using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IBagOfTestRepository : IRepository<BAGOFTEST>
    {
    }

    public class BagOfTestRepository : RepositoryBase<BAGOFTEST>, IBagOfTestRepository
    {
        public BagOfTestRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}