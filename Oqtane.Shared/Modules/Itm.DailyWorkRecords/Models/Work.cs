using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Itm.DailyWorkRecords.Models
{
    [Table("ItmWork")]
    public class Work
    {
        [Key]
        public int WorkId { get; set; }
        public int DailyWorkId { get; set; }
        public int ShiftId { get; set; }
        public int ProjectId { get; set; }
        public int RegularMh { get; set; }
        public int OvertimeMh { get; set; }
    }
}
