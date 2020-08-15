using System.Collections.Generic;
using System.Linq;
using Itm.DailyWorkRecords.Models;
using Microsoft.EntityFrameworkCore;
using Oqtane.Modules;

namespace Itm.DailyWorkRecords.Repository
{
    public class DailyWorkRecordRepository : IDailyWorkRecordRepository, IService
    {
        private readonly DailyWorkRecordContext _db;

        public DailyWorkRecordRepository(DailyWorkRecordContext context)
        {
            _db = context;
        }

        public IEnumerable<DailyWorkRecord> GetDailyWorkRecords(int ModuleId)
        {
            var dailyWorkRecords = new List<DailyWorkRecord>();
            var dailyWorks = _db.DailyWork.Where(item => item.ModuleId == ModuleId);

            if (dailyWorks != null)
            {

                foreach (var dailyWork in dailyWorks)
                {
                    var dailyWorkRecord = new DailyWorkRecord();

                    dailyWorkRecord.DailyWork = dailyWork;
                    dailyWorkRecord.Works = _db.Work.Where(item => item.WorkId == dailyWork.DailyWorkId).ToList();

                    dailyWorkRecords.Add(dailyWorkRecord);
                }

            }

            return dailyWorkRecords;
        }

        public DailyWorkRecord GetDailyWorkRecord(int DailyWorkId)
        {
            var dailyWorkRecord = new DailyWorkRecord();

            dailyWorkRecord.DailyWork = _db.DailyWork.Where(item => item.DailyWorkId == DailyWorkId).FirstOrDefault();
            dailyWorkRecord.Works = _db.Work.Where(item => item.WorkId == dailyWorkRecord.DailyWork.DailyWorkId).ToList();

            return dailyWorkRecord;
        }

        public DailyWorkRecord AddDailyWorkRecord(DailyWorkRecord DailyWorkRecord)
        {
            _db.DailyWork.Add(DailyWorkRecord.DailyWork);
            _db.Work.AddRange(DailyWorkRecord.Works);
            _db.SaveChanges();
            return DailyWorkRecord;
        }

        public Work AddDailyWorkWork(Work Work)
        {
            _db.Work.Add(Work);
            _db.SaveChanges();


            return Work;
        }

        public DailyWork UpdateDailyWork(DailyWork DailyWork)
        {
            _db.Entry(DailyWork).State = EntityState.Modified;
            _db.SaveChanges();
            return DailyWork;
        }

        public void DeleteDailyWorkRecord(int DailyWorkId)
        {
            DailyWork dailyWork = _db.DailyWork.Find(DailyWorkId);
            _db.DailyWork.Remove(dailyWork);
            _db.SaveChanges();
        }
    }
}
