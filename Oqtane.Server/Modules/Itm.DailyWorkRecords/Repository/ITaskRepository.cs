using System.Collections.Generic;
using Itm.DailyWorkRecords.Models;

namespace Itm.DailyWorkRecords.Repository
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetTasks(int DailyWorkRecordId);
        Task GetTask(int TaskId);
        Task AddTask(Task Task);
        Task UpdateTask(Task Task);
        void DeleteTask(int TaskId);
    }
}
