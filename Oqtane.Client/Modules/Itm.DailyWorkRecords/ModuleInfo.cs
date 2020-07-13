using Oqtane.Models;
using Oqtane.Modules;

namespace Itm.DailyWorkRecords
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "DailyWorkRecord",
            Description = "DailyWorkRecord",
            Version = "1.0.0",
            ServerManagerType = "Itm.DailyWorkRecords.Manager.DailyWorkRecordManager, Oqtane.Server",
            ReleaseVersions = "1.0.0"
        };
    }
}
