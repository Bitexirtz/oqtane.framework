using System.Collections.Generic;
using Itm.DailyWorkRecords.Models;

namespace Itm.DailyWorkRecords.Repository
{
    public interface IShiftRepository
    {
        IEnumerable<Shift> GetShifts(int ModuleId);
        Shift GetShift(int ShiftId);
        Shift AddShift(Shift Shift);
        Shift UpdateShift(Shift Shift);
        void DeleteShift(int ShiftId);
    }
}
