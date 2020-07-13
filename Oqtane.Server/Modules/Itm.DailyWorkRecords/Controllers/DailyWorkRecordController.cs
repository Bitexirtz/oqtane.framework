using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Itm.DailyWorkRecords.Models;
using Itm.DailyWorkRecords.Repository;

namespace Itm.DailyWorkRecords.Controllers
{
    [Route("{site}/api/[controller]")]
    public class DailyWorkRecordController : Controller
    {
        private readonly IDailyWorkRecordRepository _DailyWorkRecords;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public DailyWorkRecordController(IDailyWorkRecordRepository DailyWorkRecords, ILogManager logger, IHttpContextAccessor accessor)
        {
            _DailyWorkRecords = DailyWorkRecords;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = "ViewModule")]
        public IEnumerable<DailyWorkRecord> Get(string moduleid)
        {
            return _DailyWorkRecords.GetDailyWorkRecords(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = "ViewModule")]
        public DailyWorkRecord Get(int id)
        {
            DailyWorkRecord DailyWorkRecord = _DailyWorkRecords.GetDailyWorkRecord(id);
            if (DailyWorkRecord != null && DailyWorkRecord.ModuleId != _entityId)
            {
                DailyWorkRecord = null;
            }
            return DailyWorkRecord;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = "EditModule")]
        public DailyWorkRecord Post([FromBody] DailyWorkRecord DailyWorkRecord)
        {
            if (ModelState.IsValid && DailyWorkRecord.ModuleId == _entityId)
            {
                DailyWorkRecord = _DailyWorkRecords.AddDailyWorkRecord(DailyWorkRecord);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "DailyWorkRecord Added {DailyWorkRecord}", DailyWorkRecord);
            }
            return DailyWorkRecord;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "EditModule")]
        public DailyWorkRecord Put(int id, [FromBody] DailyWorkRecord DailyWorkRecord)
        {
            if (ModelState.IsValid && DailyWorkRecord.ModuleId == _entityId)
            {
                DailyWorkRecord = _DailyWorkRecords.UpdateDailyWorkRecord(DailyWorkRecord);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "DailyWorkRecord Updated {DailyWorkRecord}", DailyWorkRecord);
            }
            return DailyWorkRecord;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "EditModule")]
        public void Delete(int id)
        {
            DailyWorkRecord DailyWorkRecord = _DailyWorkRecords.GetDailyWorkRecord(id);
            if (DailyWorkRecord != null && DailyWorkRecord.ModuleId == _entityId)
            {
                _DailyWorkRecords.DeleteDailyWorkRecord(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "DailyWorkRecord Deleted {DailyWorkRecordId}", id);
            }
        }
    }
}
