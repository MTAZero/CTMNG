using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IShiftRepository : IRepository<SHIFT>
    {
    }

    public class ShiftRepository : RepositoryBase<SHIFT>, IShiftRepository
    {
        public ShiftRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}