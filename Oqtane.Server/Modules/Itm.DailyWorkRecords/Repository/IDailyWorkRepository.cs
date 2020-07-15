using Itm.DailyWorkRecords.Models;
using System.Collections.Generic;

namespace Itm.DailyWorkRecords.Repository
{
    public interface IDailyWorkRepository
    {

            IEnumerable<DailyWork> GetDailyWorks(int ModuleId);
            DailyWork GetDailyWork(int DailyWorkId);
            DailyWork AddDailyWork(DailyWork DailyWork);
            DailyWork UpdateDailyWork(DailyWork DailyWork);
            void DeleteDailyWork(int DailyWorkId);
    }
}
