using System.Collections.Generic;
using Itm.DailyWorkRecords.Models;

namespace Itm.DailyWorkRecords.Repository
{
    public interface IWorkRepository
    {
        IEnumerable<Work> GetWorks(int DailyWorkRecordId);
        Work GetWork(int WorkId);
        Work AddWork(Work Work);
        Work UpdateWork(Work Work);
        void DeleteWork(int WorkId);
    }
}
