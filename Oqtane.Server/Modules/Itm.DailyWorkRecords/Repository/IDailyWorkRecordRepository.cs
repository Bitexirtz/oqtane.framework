using System.Collections.Generic;
using Itm.DailyWorkRecords.Models;

namespace Itm.DailyWorkRecords.Repository
{
    public interface IDailyWorkRecordRepository
    {
        IEnumerable<DailyWorkRecord> GetDailyWorkRecords(int ModuleId);
        DailyWorkRecord GetDailyWorkRecord(int DailyWorkId);
        DailyWorkRecord AddDailyWorkRecord(DailyWorkRecord DailyWorkRecord);
        Work AddDailyWorkWork(Work Work);
        DailyWork UpdateDailyWork(DailyWork DailyWork);
        void DeleteDailyWorkRecord(int DailyWorkId);
    }
}
