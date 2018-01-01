using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;
using System;
using EXON.Common;

namespace EXON.Data.Services
{
    public interface IReceiptService
    {
        RECEIPT Add(RECEIPT RECEIPT);

        void Update(RECEIPT RECEIPT);

        RECEIPT Delete(int id);

        IEnumerable<RECEIPT> GetAll();

        List<RECEIPT> GetRandomList(List<RECEIPT> listQuestion, int numQuestion);

        RECEIPT GetById(int id);

        void Save();
    }

    public class ReceiptService : IReceiptService
    {
        private IReceiptRepository _ReceiptRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ReceiptService()
        {
            dbFactory = new DbFactory();
            this._ReceiptRepository = new ReceiptRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public RECEIPT Add(RECEIPT RECEIPT)
        {
            return _ReceiptRepository.Add(RECEIPT);
        }

        public RECEIPT Delete(int id)
        {
            return _ReceiptRepository.Delete(id);
        }

        public RECEIPT GetById(int id)
        {
            return _ReceiptRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(RECEIPT RECEIPT)
        {
            _ReceiptRepository.Update(RECEIPT);
        }

        public IEnumerable<RECEIPT> GetAll()
        {
            return _ReceiptRepository.GetAll();
        }
        public IEnumerable<RECEIPT> GetWithRegisterID(int registerID)
        {
            return _ReceiptRepository.GetMulti(x => x.RegisterID == registerID);
        }

        public List<RECEIPT> GetRandomList(List<RECEIPT> listQuestion, int numQuestion)
        {
            return _ReceiptRepository.GetRandomList(listQuestion, numQuestion);
        }

      
    }
}