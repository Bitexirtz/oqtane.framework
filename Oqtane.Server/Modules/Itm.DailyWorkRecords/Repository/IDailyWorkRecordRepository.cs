using System.Collections.Generic;
using Itm.DailyWorkRecords.Models;

namespace Itm.DailyWorkRecords.Repository
{
    public interface IDailyWorkRecordRepository
    {
        IEnumerable<DailyWork> GetDailyWorkRecords(int ModuleId);
        DailyWork GetDailyWorkRecord(int DailyWorkRecordId);
        DailyWork AddDailyWorkRecord(DailyWork DailyWorkRecord);
        DailyWork UpdateDailyWorkRecord(DailyWork DailyWorkRecord);
        void DeleteDailyWorkRecord(int DailyWorkRecordId);
    }
}
