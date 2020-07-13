using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Itm.DailyWorkRecords.Models;

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
            return _db.DailyWorkRecord.Where(item => item.ModuleId == ModuleId);
        }

        public DailyWorkRecord GetDailyWorkRecord(int DailyWorkRecordId)
        {
            return _db.DailyWorkRecord.Find(DailyWorkRecordId);
        }

        public DailyWorkRecord AddDailyWorkRecord(DailyWorkRecord DailyWorkRecord)
        {
            _db.DailyWorkRecord.Add(DailyWorkRecord);
            _db.SaveChanges();
            return DailyWorkRecord;
        }

        public DailyWorkRecord UpdateDailyWorkRecord(DailyWorkRecord DailyWorkRecord)
        {
            _db.Entry(DailyWorkRecord).State = EntityState.Modified;
            _db.SaveChanges();
            return DailyWorkRecord;
        }

        public void DeleteDailyWorkRecord(int DailyWorkRecordId)
        {
            DailyWorkRecord DailyWorkRecord = _db.DailyWorkRecord.Find(DailyWorkRecordId);
            _db.DailyWorkRecord.Remove(DailyWorkRecord);
            _db.SaveChanges();
        }
    }
}
