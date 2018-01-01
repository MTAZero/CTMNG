using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface ISubjectRepository : IRepository<SUBJECT>
    {
    }

    public class SubjectRepository : RepositoryBase<SUBJECT>, ISubjectRepository
    {
        public SubjectRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}