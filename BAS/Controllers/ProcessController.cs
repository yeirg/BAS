using System.Diagnostics;
using BAS.Contracts;
using BAS.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BAS.Controllers;

[Route("api/")]
[ApiController]
public class ProcessController(IQueueService queueService) : ControllerBase
{
    [HttpPost]
    [Route("process")]
    public ActionResult<MessageResponse> Process([FromBody] MessageRequest request)
    {
        // better solution - Diagnostics
        // better solution - Use telemetry
        var utcNow = DateTime.Now;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        if (request.Message == null) return BadRequest();

        var writeTime = queueService.EnqueueTask(request.Message);
        stopwatch.Stop();
        return new MessageResponse()
        {
            RequestTime = utcNow.ToString("O"),
            WriteTime = writeTime.ToString("O"),
            ProcessingTime = (utcNow - writeTime).Milliseconds
        };
    }
}