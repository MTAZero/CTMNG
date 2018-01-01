using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace EXON.Data.Services
{
    public interface ITopicStaffService
    {
        TOPICS_STAFFS Add(TOPICS_STAFFS TOPICS_STAFFS);

        void Update(TOPICS_STAFFS TOPICS_STAFFS);

        TOPICS_STAFFS Delete(int id);

        IEnumerable<TOPICS_STAFFS> GetAll();

        IEnumerable<TOPICS_STAFFS> GetAll(int StaffId);

        IEnumerable<TOPICS_STAFFS> GetAll(int StaffId, int TopicId);

        TOPICS_STAFFS GetById(int id);

        void Save();
    }

    public class TopicStaffService : ITopicStaffService
    {
        private ITopicStaffRepository _TopicStaffRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public TopicStaffService()
        {
            dbFactory = new DbFactory();
            this._TopicStaffRepository = new TopicStaffRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public TOPICS_STAFFS Add(TOPICS_STAFFS TOPICS_STAFFS)
        {
            return _TopicStaffRepository.Add(TOPICS_STAFFS);
        }

        public TOPICS_STAFFS Delete(int id)
        {
            return _TopicStaffRepository.Delete(id);
        }

        public IEnumerable<TOPICS_STAFFS> GetAll()
        {
            return _TopicStaffRepository.GetAll();
        }

        public TOPICS_STAFFS GetById(int id)
        {
            return _TopicStaffRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(TOPICS_STAFFS TOPICS_STAFFS)
        {
            _TopicStaffRepository.Update(TOPICS_STAFFS);
        }

        public IEnumerable<TOPICS_STAFFS> GetAll(int StaffId)
        {
            return _TopicStaffRepository.GetMulti(x => x.TaskmasterStaffID == StaffId);
        }

        public IEnumerable<TOPICS_STAFFS> GetAll(int StaffId, int TopicId)
        {
            return _TopicStaffRepository
                .GetMulti(x => x.TaskmasterStaffID == StaffId && x.TopicID == TopicId)
                .OrderBy(x => x.Status);
        }
    }
}