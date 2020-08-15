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
    public class DailyWorkRecordManager : IInstallable, IPortable
    {
        private IDailyWorkRecordRepository _DailyWorkRecords;
        private ISqlRepository _sql;

        public DailyWorkRecordManager(IDailyWorkRecordRepository DailyWorkRecords, ISqlRepository sql)
        {
            _DailyWorkRecords = DailyWorkRecords;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Itm.DailyWorkRecords." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Itm.DailyWorkRecords.Uninstall.sql");
        }


        public string ExportModule(Module module)
        {
            string content = "";
            List<DailyWorkRecord> DailyWorkRecords = _DailyWorkRecords.GetDailyWorkRecords(module.ModuleId).ToList();
            if (DailyWorkRecords != null)
            {
                content = JsonSerializer.Serialize(DailyWorkRecords);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<DailyWorkRecord> DailyWorkRecords = null;
            if (!string.IsNullOrEmpty(content))
            {
                DailyWorkRecords = JsonSerializer.Deserialize<List<DailyWorkRecord>>(content);
            }
            if (DailyWorkRecords != null)
            {
                foreach(DailyWorkRecord DailyWorkRecord in DailyWorkRecords)
                {
                    DailyWorkRecord _DailyWorkRecord = new DailyWorkRecord();
                    _DailyWorkRecord.DailyWork.ModuleId = module.ModuleId;
                    _DailyWorkRecords.AddDailyWorkRecord(_DailyWorkRecord);
                }
            }
        }
    }
}