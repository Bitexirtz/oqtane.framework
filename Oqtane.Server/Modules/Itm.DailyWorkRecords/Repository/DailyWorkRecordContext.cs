using Itm.DailyWorkRecords.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Oqtane.Modules;
using Oqtane.Repository;

namespace Itm.DailyWorkRecords.Repository
{
    public class DailyWorkRecordContext : DBContextBase, IService
    {
        public virtual DbSet<DailyWork> DailyWork { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<Work> Work { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }

        public DailyWorkRecordContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
