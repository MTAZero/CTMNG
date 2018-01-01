using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IFingerPrinterRepository : IRepository<FINGERPRINT>
    {
    }

    public class FingerPrinterRepository : RepositoryBase<FINGERPRINT>, IFingerPrinterRepository
    {
        public FingerPrinterRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}