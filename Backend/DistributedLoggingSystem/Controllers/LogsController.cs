using BuildingBlocks.Repositories;
using BuildingBlocks.UnitOfWork;
using DistributedLoggingSystem.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DistributedLoggingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController
        (IRepository<LogEntry> repository, 
         IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LogEntry logEntry)
        {
            LogEntry newLog = LogEntry.CreateLog
            (
                logEntry.Service, 
                logEntry.Level, 
                logEntry.Message, 
                logEntry.Timestamp, 
                logEntry.StorageType
            );
            repository.Add(newLog);
            await unitOfWork.SaveChangesAsync();    
            return Ok(newLog);
        }

        [HttpGet]
        public async Task<IActionResult> GetLogsAsync()
        {
            IReadOnlyCollection<LogEntry> logs = await repository.GetAllAsync();
            return Ok(logs);
        }
    }
}
