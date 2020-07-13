using System.Collections.Generic;
using System.Threading.Tasks;
using Itm.DailyWorkRecords.Models;

namespace Itm.DailyWorkRecords.Services
{
    public interface IDailyWorkRecordService 
    {
        Task<List<DailyWorkRecord>> GetDailyWorkRecordsAsync(int ModuleId);

        Task<DailyWorkRecord> GetDailyWorkRecordAsync(int DailyWorkRecordId, int ModuleId);

        Task<DailyWorkRecord> AddDailyWorkRecordAsync(DailyWorkRecord DailyWorkRecord);

        Task<DailyWorkRecord> UpdateDailyWorkRecordAsync(DailyWorkRecord DailyWorkRecord);

        Task DeleteDailyWorkRecordAsync(int DailyWorkRecordId, int ModuleId);
    }
}
