using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Itm.DailyWorkRecords.Models
{
    [Table("ItmDailyWorkRecord")]
    public class DailyWorkRecord : IAuditable
    {
        [Key]
        public int DailyWorkRecordId { get; set; }
        public int ModuleId { get; set; }
        public int ShiftId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
