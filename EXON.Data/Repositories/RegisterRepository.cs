using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IRegisterRepository : IRepository<REGISTER>
    {
    }

    public class RegisterRepository : RepositoryBase<REGISTER>, IRegisterRepository
    {
        public RegisterRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}