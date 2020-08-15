using System.Collections.Generic;
using System.Linq;
using Itm.DailyWorkRecords.Models;
using Microsoft.EntityFrameworkCore;

namespace Itm.DailyWorkRecords.Repository
{
    public class WorkRepository : IWorkRepository
    {
        private readonly DailyWorkRecordContext _db;

        public WorkRepository(DailyWorkRecordContext context)
        {
            _db = context;
        }

        public Work AddWork(Work Work)
        {
            _db.Work.Add(Work);
            _db.SaveChanges();
            return Work;
        }

        public void DeleteWork(int WorkId)
        {
            Work Work = _db.Work.Find(WorkId);
            _db.Work.Remove(Work);
            _db.SaveChanges();
        }

        public Work GetWork(int WorkId)
        {
            return _db.Work.Find(WorkId);
        }

        public IEnumerable<Work> GetWorks(int DailyWorkRecordId)
        {
            return _db.Work.Where(item => item.DailyWorkId == DailyWorkRecordId);
        }

        public Work UpdateWork(Work Work)
        {
            _db.Entry(Work).State = EntityState.Modified;
            _db.SaveChanges();
            return Work;
        }
    }
}
