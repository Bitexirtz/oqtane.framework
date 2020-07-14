using System.Collections.Generic;
using Itm.DailyWorkRecords.Models;

namespace Itm.DailyWorkRecords.Repository
{
    public interface IProcessRepository
    {
        IEnumerable<Process> GetProcesses(int ModuleId);
        Process GetProcess(int ProcessId);
        Process AddProcess(Process Process);
        Process UpdateProcess(Process Process);
        void DeleteProcess(int ProcessId);
    }
}
