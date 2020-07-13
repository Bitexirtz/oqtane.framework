using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Oqtane.Modules.Itm.DailyWorkRecords.Models
{
    [Table("ItmTask")]
    public class Task
    {
        public int TaskId { get; set; }
        public int DailyWorkRecordId { get; set; }
        public int ProjectId { get; set; }
        public int RegularMh { get; set; }
        public int OvertimeMh { get; set; }
    }
}
