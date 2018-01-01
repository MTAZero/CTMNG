using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IScheduleRepository : IRepository<SCHEDULE>
    {
    }

    public class ScheduleRepository : RepositoryBase<SCHEDULE>, IScheduleRepository
    {
        public ScheduleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}