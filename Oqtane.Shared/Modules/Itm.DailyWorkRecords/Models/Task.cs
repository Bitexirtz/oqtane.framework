using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Itm.DailyWorkRecords.Models
{
    [Table("ItmTask")]
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public int DailyWorkRecordId { get; set; }
        public int ProjectId { get; set; }
        public int RegularMh { get; set; }
        public int OvertimeMh { get; set; }
    }
}
