using EXON.Data.Infrastructures;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON.Data.Repositories
{
    public interface IReceiptRepository : IRepository<RECEIPT>
    {
    }

    public class ReceiptRepository : RepositoryBase<RECEIPT>, IReceiptRepository
    {
        public ReceiptRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
   
}
