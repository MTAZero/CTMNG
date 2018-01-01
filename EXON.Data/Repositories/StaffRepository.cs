using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IStaffRepository : IRepository<STAFF>
    {
    }

    public class StaffRepository : RepositoryBase<STAFF>, IStaffRepository
    {
        public StaffRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}