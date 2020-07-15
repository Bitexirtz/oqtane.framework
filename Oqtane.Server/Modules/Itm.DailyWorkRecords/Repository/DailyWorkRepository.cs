using Itm.DailyWorkRecords.Models;
using Microsoft.EntityFrameworkCore;
using Oqtane.Modules;
using System.Collections.Generic;
using System.Linq;

namespace Itm.DailyWorkRecords.Repository
{
    public class DailyWorkRepository : IDailyWorkRepository, IService
    {
        private readonly DailyWorkRecordContext _db;

        public DailyWorkRepository(DailyWorkRecordContext context)
        {
            _db = context;
        }

        public IEnumerable<DailyWork> GetDailyWorks(int ModuleId)
        {
            return _db.DailyWorkRecord.Where(item => item.ModuleId == ModuleId);
        }

        public DailyWork GetDailyWork(int DailyWorkId)
        {
            return _db.DailyWorkRecord.Find(DailyWorkId);
        }

        public DailyWork AddDailyWork(DailyWork DailyWorkRecord)
        {
            _db.DailyWorkRecord.Add(DailyWorkRecord);
            _db.SaveChanges();
            return DailyWorkRecord;
        }

        public DailyWork UpdateDailyWork(DailyWork DailyWorkRecord)
        {`
            _db.Entry(DailyWorkRecord).State = EntityState.Modified;
            _db.SaveChanges();
            return DailyWorkRecord;
        }

        public void DeleteDailyWork(int DailyWorkId)
        {
            DailyWork DailyWorkRecord = _db.DailyWorkRecord.Find(DailyWorkId);
            _db.DailyWorkRecord.Remove(DailyWorkRecord);
            _db.SaveChanges();
        }
    }
}
