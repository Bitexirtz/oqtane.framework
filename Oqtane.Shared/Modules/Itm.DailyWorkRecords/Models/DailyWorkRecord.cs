using System;
using System.Collections.Generic;
using System.Text;

namespace Itm.DailyWorkRecords.Models
{
    public class DailyWorkRecord
    {
        public DailyWork DailyWork { get; set; }
        public List<Work> Works { get; set; }
    }
}
