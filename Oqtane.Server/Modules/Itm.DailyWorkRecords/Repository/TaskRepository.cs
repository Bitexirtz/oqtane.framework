using System.Collections.Generic;
using System.Linq;
using Itm.DailyWorkRecords.Models;
using Microsoft.EntityFrameworkCore;

namespace Itm.DailyWorkRecords.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DailyWorkRecordContext _db;

        public TaskRepository(DailyWorkRecordContext context)
        {
            _db = context;
        }

        public Task AddTask(Task Task)
        {
            _db.Task.Add(Task);
            _db.SaveChanges();
            return Task;
        }

        public void DeleteTask(int TaskId)
        {
            Task Task = _db.Task.Find(TaskId);
            _db.Task.Remove(Task);
            _db.SaveChanges();
        }

        public Task GetTask(int TaskId)
        {
            return _db.Task.Find(TaskId);
        }

        public IEnumerable<Task> GetTasks(int DailyWorkRecordId)
        {
            return _db.Task.Where(item => item.DailyWorkRecordId == DailyWorkRecordId);
        }

        public Task UpdateTask(Task Task)
        {
            _db.Entry(Task).State = EntityState.Modified;
            _db.SaveChanges();
            return Task;
        }
    }
}
