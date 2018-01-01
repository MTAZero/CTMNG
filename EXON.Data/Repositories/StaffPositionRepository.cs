using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IStaffPositionRepository : IRepository<STAFFS_POSITIONS>
    {
    }

    public class StaffPositionRepository : RepositoryBase<STAFFS_POSITIONS>, IStaffPositionRepository
    {
        public StaffPositionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}