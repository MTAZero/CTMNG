using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IDeparmentRepository : IRepository<DEPARTMENT>
    {
    }

    public class DeparmentRepository : RepositoryBase<DEPARTMENT>, IDeparmentRepository
    {
        public DeparmentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}