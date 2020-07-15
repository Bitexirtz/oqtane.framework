using System.Collections.Generic;
using System.Linq;
using Itm.DailyWorkRecords.Models;
using Microsoft.EntityFrameworkCore;

namespace Itm.DailyWorkRecords.Repository
{
    public class ProcessRepository : IProcessRepository
    {
        private readonly DailyWorkRecordContext _db;

        public ProcessRepository(DailyWorkRecordContext context)
        {
            _db = context;
        }

        public Process AddProcess(Process Process)
        {
            _db.Process.Add(Process);
            _db.SaveChanges();
            return Process;
        }

        public void DeleteProcess(int ProcessId)
        {
            Process Process = _db.Process.Find(ProcessId);
            _db.Process.Remove(Process);
            _db.SaveChanges();
        }

        public Process GetProcess(int ProcessId)
        {
            return _db.Process.Find(ProcessId);
        }

        public IEnumerable<Process> GetProcesses(int ModuleId)
        {
            return _db.Process.Where(item => item.ModuleId == ModuleId);
        }

        public Process UpdateProcess(Process Process)
        {
            _db.Entry(Process).State = EntityState.Modified;
            _db.SaveChanges();
            return Process;
        }
    }
}
