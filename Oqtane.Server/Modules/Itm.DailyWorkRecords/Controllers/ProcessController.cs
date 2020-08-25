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
    [Route("{site}/api/DailyWorkRecord/[controller]")]
    public class ProcessController : Controller
    {
        private readonly IProcessRepository _processes;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public ProcessController(IProcessRepository process, ILogManager logger, IHttpContextAccessor accessor)
        {
            _processes = process;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        [HttpGet]
        [Authorize(Policy = "ViewModule")]
        public IEnumerable<Process> Get(string moduleid)
        {
            return _processes.GetProcesses(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = "ViewModule")]
        public Process Get(int id)
        {
            Process process = _processes.GetProcess(id);
            if (process != null && process.ModuleId != _entityId)
            {
                process = null;
            }

            return process;
        }

        [HttpPost]
        [Authorize(Policy = "EditModule")]
        public Process Post([FromBody] Process process)
        {
            if (ModelState.IsValid && process.ModuleId == _entityId)
            {
                process = _processes.AddProcess(process);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Process Added {Process}", process);
            }
            return process;
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "EditModule")]
        public Process Put(int id, [FromBody] Process process)
        {
            if (ModelState.IsValid && process.ModuleId == _entityId)
            {
                process = _processes.UpdateProcess(process);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Process Updated {Process}", process);
            }

            return process;
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "EditModule")]
        public void Delete(int id)
        {
            Process process = _processes.GetProcess(id);
            if (process != null && process.ModuleId == _entityId)
            {
                _processes.DeleteProcess(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Process Deleted {Process}", id);
            }
        }
    }
}
