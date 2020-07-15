using System.Collections.Generic;
using System.Linq;
using Itm.DailyWorkRecords.Models;
using Microsoft.EntityFrameworkCore;

namespace Itm.DailyWorkRecords.Repository
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly DailyWorkRecordContext _db;

        public ShiftRepository(DailyWorkRecordContext context)
        {
            _db = context;
        }

        public Shift AddShift(Shift Shift)
        {
            _db.Shift.Add(Shift);
            _db.SaveChanges();
            return Shift;
        }

        public void DeleteShift(int ShiftId)
        {
            Shift Shift = _db.Shift.Find(ShiftId);
            _db.Shift.Remove(Shift);
            _db.SaveChanges();
        }

        public Shift GetShift(int ShiftId)
        {
            return _db.Shift.Find(ShiftId);
        }

        public IEnumerable<Shift> GetShifts(int ModuleId)
        {
            return _db.Shift.Where(item => item.ModuleId == ModuleId);
        }

        public Shift UpdateShift(Shift Shift)
        {
            _db.Entry(Shift).State = EntityState.Modified;
            _db.SaveChanges();
            return Shift;
        }
    }
}
