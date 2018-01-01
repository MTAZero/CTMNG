using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IPositionRepository : IRepository<POSITION>
    {
    }

    public class PositionRepository : RepositoryBase<POSITION>, IPositionRepository
    {
        public PositionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}