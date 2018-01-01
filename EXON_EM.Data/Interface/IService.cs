using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON_EM.Data.Interface
{
    interface IService<T> where T: class
    {
        T Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Delete(int id);
        T Find(int id);
        IEnumerable<T> getAll();
        void Save();

    }
}
