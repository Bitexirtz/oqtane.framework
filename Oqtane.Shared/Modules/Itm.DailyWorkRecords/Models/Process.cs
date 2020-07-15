using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Itm.DailyWorkRecords.Models
{
    [Table("ItmProcess")]
    public class Process : IAuditable
    {
        [Key]
        public int ProcessId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
