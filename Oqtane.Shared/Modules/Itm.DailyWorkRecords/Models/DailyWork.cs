using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Itm.DailyWorkRecords.Models
{
    [Table("ItmDailyWork")]
    public class DailyWork : IAuditable
    {
        [Key]
        public int DailyWorkId { get; set; }
        public int ModuleId { get; set; }
        public int ShiftId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
