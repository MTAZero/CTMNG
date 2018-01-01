using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;
using System;

namespace EXON.Data.Services
{
    public interface IContestantService
    {
        CONTESTANT Add(CONTESTANT CONTESTANT);

        void Update(CONTESTANT CONTESTANT);

        void Delete(int id);
        IEnumerable<CONTESTANT> GetAllByContest(int ContestID);
        IEnumerable<CONTESTANT> GetAll();

        IEnumerable<CONTESTANT> GetAllByName(int ContestantID, string Name);

        IEnumerable<CONTESTANT> GetAllByRegister(int RegisterID);

        List<CONTESTANT> GetRandomList(List<CONTESTANT> listQuestion, int numQuestion);

        CONTESTANT GetById(int id);

        void UpdateSTT(int id, int status);

        void Save();
    }

    public class ContestantService : IContestantService
    {
        private IContestantRepository _ContestantRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ContestantService()
        {
            dbFactory = new DbFactory();
            this._ContestantRepository = new ContestantRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }
        public void UpdateSTT(int id, int isaddIMG) // thêm ảnh ( isaddIMG=1), thêm vân tay(isaddIMG=2)
        {
            CONTESTANT rg = GetById(id);
            if (rg != null)
            {
                if(isaddIMG==1)
                {
                    if (rg.Status == 1000)
                    {
                        rg.Status = 1002;
                    }
                    if (rg.Status == 1001)
                    {
                        rg.Status = 1003;
                    }
                }
                else
                {
                    if (rg.Status == 1000)
                    {
                        rg.Status = 1001;
                    }
                    if (rg.Status == 1002)
                    {
                        rg.Status = 1003;
                    }
                }
                _ContestantRepository.Update(rg);
            }
        }

        public CONTESTANT Add(CONTESTANT CONTESTANT)
        {
            return _ContestantRepository.Add(CONTESTANT);
        }

        public void Delete(int id)
        {
            CONTESTANT rg = GetById(id);
            if (rg != null)
            {
                rg.Status = 0;
                
                _ContestantRepository.Update(rg);
            }
        }
        public CONTESTANT GetById(int id)
        {
            return _ContestantRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CONTESTANT CONTESTANT)
        {
            _ContestantRepository.Update(CONTESTANT);
        }

        public List<CONTESTANT> GetRandomList(List<CONTESTANT> listQuestion, int numQuestion)
        {
            return _ContestantRepository.GetRandomList(listQuestion, numQuestion);
        }


        public IEnumerable<CONTESTANT> GetAllByName(int ContestantID, string Name)
        {
            return _ContestantRepository.GetMulti(x => x.ContestantID == ContestantID && x.REGISTER.FullName.Contains(Name));
        }
        public IEnumerable<CONTESTANT> GetAllByContest(int ContestID)
        {
            return _ContestantRepository.GetMulti(x=> x.REGISTER.ContestID==ContestID);
        }
        public IEnumerable<CONTESTANT> GetAll()
        {
            return _ContestantRepository.GetAll();
        }

        public IEnumerable<CONTESTANT> GetAllByRegister(int RegisterID)
        {
            return _ContestantRepository.GetMulti(x => x.RegisterID == RegisterID && x.Status!=0);
        }
    }
}