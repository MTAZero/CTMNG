using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IOriginalTestRepository : IRepository<ORIGINAL_TESTS>
    {
    }

    public class OriginalTestRepository : RepositoryBase<ORIGINAL_TESTS>, IOriginalTestRepository
    {
        public OriginalTestRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}