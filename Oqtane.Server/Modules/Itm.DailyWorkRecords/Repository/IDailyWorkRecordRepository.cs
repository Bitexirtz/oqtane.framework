using System.Collections.Generic;
using Itm.DailyWorkRecords.Models;

namespace Itm.DailyWorkRecords.Repository
{
    public interface IDailyWorkRecordRepository
    {
        IEnumerable<DailyWorkRecord> GetDailyWorkRecords(int ModuleId);
        DailyWorkRecord GetDailyWorkRecord(int DailyWorkRecordId);
        DailyWorkRecord AddDailyWorkRecord(DailyWorkRecord DailyWorkRecord);
        DailyWorkRecord UpdateDailyWorkRecord(DailyWorkRecord DailyWorkRecord);
        void DeleteDailyWorkRecord(int DailyWorkRecordId);
    }
}
