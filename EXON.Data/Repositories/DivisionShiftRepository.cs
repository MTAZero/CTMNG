using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IDivisionShiftRepository : IRepository<DIVISION_SHIFTS>
    {
    }

    public class DivisionShiftRepository : RepositoryBase<DIVISION_SHIFTS>, IDivisionShiftRepository
    {
        public DivisionShiftRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}