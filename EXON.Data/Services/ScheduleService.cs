﻿using EXON.Data.Infrastructures;
using EXON.Data.Repositories;
using EXON.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace EXON.Data.Services
{
    public interface IScheduleService
    {
        SCHEDULE Add(SCHEDULE SCHEDULE);

        void Update(SCHEDULE SCHEDULE);

        SCHEDULE Delete(int id);

        IEnumerable<SCHEDULE> GetAllByContest(int ContestID);

        SCHEDULE GetByContestAndSubject(int ContestID, int SubjectID);

        SCHEDULE GetById(int id);

        void Save();
    }

    public class ScheduleService : IScheduleService
    {
        private IScheduleRepository _ScheduleRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory dbFactory;

        public ScheduleService()
        {
            dbFactory = new DbFactory();
            this._ScheduleRepository = new ScheduleRepository(dbFactory);
            this._unitOfWork = new UnitOfWork(dbFactory);
        }

        public SCHEDULE Add(SCHEDULE SCHEDULE)
        {
            return _ScheduleRepository.Add(SCHEDULE);
        }

        public SCHEDULE Delete(int id)
        {
            return _ScheduleRepository.Delete(id);
        }

        public IEnumerable<SCHEDULE> GetAllByContest(int ContestID)
        {
            return _ScheduleRepository.GetMulti(x => x.ContestID == ContestID && x.Status != 0);
        }

        public SCHEDULE GetById(int id)
        {
            return _ScheduleRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(SCHEDULE SCHEDULE)
        {
            _ScheduleRepository.Update(SCHEDULE);
        }

        public SCHEDULE GetByContestAndSubject(int ContestID, int SubjectID)
        {
            return _ScheduleRepository
                .GetMulti(x => x.ContestID == ContestID && x.SubjectID == SubjectID && x.Status != 0)
                .FirstOrDefault();
        }
    }
}