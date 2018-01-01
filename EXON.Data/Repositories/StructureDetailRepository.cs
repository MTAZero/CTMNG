using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IStructureDetailRepository : IRepository<STRUCTURE_DETAILS>
    {
    }

    public class StructureDetailRepository : RepositoryBase<STRUCTURE_DETAILS>, IStructureDetailRepository
    {
        public StructureDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}