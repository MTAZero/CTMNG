using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface ITopicRepository : IRepository<TOPIC>
    {
    }

    public class TopicRepository : RepositoryBase<TOPIC>, ITopicRepository
    {
        public TopicRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}