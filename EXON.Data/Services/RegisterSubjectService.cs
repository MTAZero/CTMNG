using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;
using System;
using EXON.Common;

namespace EXON.Data.Services
{
    public interface IRegisterSubjectService
    {
        REGISTERS_SUBJECTS Add(REGISTERS_SUBJECTS REGISTERS_SUBJECTS);

        void Update(REGISTERS_SUBJECTS REGISTERS_SUBJECTS);

        REGISTERS_SUBJECTS Delete(int id);

        IEnumerable<REGISTERS_SUBJECTS> GetAll();

        List<REGISTERS_SUBJECTS> GetRandomList(List<REGISTERS_SUBJECTS> listQuestion, int numQuestion);

        REGISTERS_SUBJECTS GetById(int id);

        void Save();
    }

    public class RegisterSubjectService : IRegisterSubjectService
    {
        private IRegisterSubjectRepository _RegisterSubjectRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public RegisterSubjectService()
        {
            dbFactory = new DbFactory();
            this._RegisterSubjectRepository = new RegisterSubjectRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public REGISTERS_SUBJECTS Add(REGISTERS_SUBJECTS REGISTERS_SUBJECTS)
        {
            return _RegisterSubjectRepository.Add(REGISTERS_SUBJECTS);
        }

        public REGISTERS_SUBJECTS Delete(int id)
        {
            return _RegisterSubjectRepository.Delete(id);
        }

        public REGISTERS_SUBJECTS GetById(int id)
        {
            return _RegisterSubjectRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(REGISTERS_SUBJECTS REGISTERS_SUBJECTS)
        {
            _RegisterSubjectRepository.Update(REGISTERS_SUBJECTS);
        }

        public IEnumerable<REGISTERS_SUBJECTS> GetAll()
        {
            return _RegisterSubjectRepository.GetAll();
        }
        public IEnumerable<REGISTERS_SUBJECTS> GetWithRegisterID(int registerID)
        {
            return _RegisterSubjectRepository.GetMulti(x => x.RegisterID == registerID) ;
        }

        public List<REGISTERS_SUBJECTS> GetRandomList(List<REGISTERS_SUBJECTS> listQuestion, int numQuestion)
        {
            return _RegisterSubjectRepository.GetRandomList(listQuestion, numQuestion);
        }


    }
}