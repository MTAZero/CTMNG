using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IStructureRepository : IRepository<STRUCTURE>
    {
    }

    public class StructureRepository : RepositoryBase<STRUCTURE>, IStructureRepository
    {
        public StructureRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}