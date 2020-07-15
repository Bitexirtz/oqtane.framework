using System.Collections.Generic;
using System.Threading.Tasks;
using Itm.DailyWorkRecords.Models;

namespace Itm.DailyWorkRecords.Services
{
    public interface IDailyWorkRecordService 
    {
        Task<List<DailyWork>> GetDailyWorkRecordsAsync(int ModuleId);

        Task<DailyWork> GetDailyWorkRecordAsync(int DailyWorkRecordId, int ModuleId);

        Task<DailyWork> AddDailyWorkRecordAsync(DailyWork DailyWorkRecord);

        Task<DailyWork> UpdateDailyWorkRecordAsync(DailyWork DailyWorkRecord);

        Task DeleteDailyWorkRecordAsync(int DailyWorkRecordId, int ModuleId);
    }
}
