using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Itm.DailyWorkRecords.Models;

namespace Itm.DailyWorkRecords.Services
{
    public class DailyWorkRecordService : ServiceBase, IDailyWorkRecordService, IService
    {
        private readonly SiteState _siteState;

        public DailyWorkRecordService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl => CreateApiUrl(_siteState.Alias, "DailyWorkRecord");

        public async Task<List<DailyWorkRecord>> GetDailyWorkRecordsAsync(int ModuleId)
        {
            List<DailyWorkRecord> DailyWorkRecords = await GetJsonAsync<List<DailyWorkRecord>>(CreateAuthPolicyUrl($"{Apiurl}?moduleid={ModuleId}", ModuleId));
            return DailyWorkRecords.OrderBy(item => item.Date).ToList();
        }

        public async Task<DailyWorkRecord> GetDailyWorkRecordAsync(int DailyWorkRecordId, int ModuleId)
        {
            return await GetJsonAsync<DailyWorkRecord>(CreateAuthPolicyUrl($"{Apiurl}/{DailyWorkRecordId}", ModuleId));
        }

        public async Task<DailyWorkRecord> AddDailyWorkRecordAsync(DailyWorkRecord DailyWorkRecord)
        {
            return await PostJsonAsync<DailyWorkRecord>(CreateAuthPolicyUrl($"{Apiurl}?entityid={DailyWorkRecord.ModuleId}", DailyWorkRecord.ModuleId), DailyWorkRecord);
        }

        public async Task<DailyWorkRecord> UpdateDailyWorkRecordAsync(DailyWorkRecord DailyWorkRecord)
        {
            return await PutJsonAsync<DailyWorkRecord>(CreateAuthPolicyUrl($"{Apiurl}/{DailyWorkRecord.DailyWorkRecordId}", DailyWorkRecord.ModuleId), DailyWorkRecord);
        }

        public async Task DeleteDailyWorkRecordAsync(int DailyWorkRecordId, int ModuleId)
        {
            await DeleteAsync(CreateAuthPolicyUrl($"{Apiurl}/{DailyWorkRecordId}", ModuleId));
        }

        private string CreateAuthPolicyUrl(string Url, int ModuleId)
        {
            if (Url.Contains("?"))
            {
                return Url + "&entityid=" + ModuleId.ToString();
            }
            else
            {
                return Url + "?entityid=" + ModuleId.ToString();
            }
        }
    }
}
