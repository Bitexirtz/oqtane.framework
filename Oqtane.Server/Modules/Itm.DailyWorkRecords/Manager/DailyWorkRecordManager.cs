using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using Itm.DailyWorkRecords.Models;
using Itm.DailyWorkRecords.Repository;

namespace Itm.DailyWorkRecords.Manager
{
    public class DailyWorkRecordManager : IPortable
    {
        private IDailyWorkRecordRepository _DailyWorkRecords;

        public DailyWorkRecordManager(IDailyWorkRecordRepository DailyWorkRecords)
        {
            _DailyWorkRecords = DailyWorkRecords;
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<DailyWork> DailyWorkRecords = _DailyWorkRecords.GetDailyWorkRecords(module.ModuleId).ToList();
            if (DailyWorkRecords != null)
            {
                content = JsonSerializer.Serialize(DailyWorkRecords);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<DailyWork> DailyWorkRecords = null;
            if (!string.IsNullOrEmpty(content))
            {
                DailyWorkRecords = JsonSerializer.Deserialize<List<DailyWork>>(content);
            }
            if (DailyWorkRecords != null)
            {
                foreach(DailyWork DailyWorkRecord in DailyWorkRecords)
                {
                    DailyWork _DailyWorkRecord = new DailyWork();
                    _DailyWorkRecord.ModuleId = module.ModuleId;
                    _DailyWorkRecords.AddDailyWorkRecord(_DailyWorkRecord);
                }
            }
        }
    }
}