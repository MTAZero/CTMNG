using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface ITopicStaffRepository : IRepository<TOPICS_STAFFS>
    {
    }

    public class TopicStaffRepository : RepositoryBase<TOPICS_STAFFS>, ITopicStaffRepository
    {
        public TopicStaffRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}