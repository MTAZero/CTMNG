using System;
using System.Collections.Generic;
using EXON.Data.Infrastructures;
using EXON.Model.Models;

namespace EXON.Data.Repositories
{
    public interface IRegisterSubjectRepository : IRepository<REGISTERS_SUBJECTS>
    {
      
    }

    public class RegisterSubjectRepository : RepositoryBase<REGISTERS_SUBJECTS>, IRegisterSubjectRepository
    {
        public RegisterSubjectRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       
    }
}