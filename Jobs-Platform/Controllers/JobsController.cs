using Jobs_Platform.Data.Entities;
using Jobs_Platform.Dtos;
using Jobs_Platform.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService jobsService;
        public JobsController(JobsService jobsService)
        {
           this.jobsService = jobsService;
        }

        [HttpGet("get-jobs")]
        public ActionResult<List<Job>> GetJobs()
        {
            var result = jobsService.GetJobs();
            return Ok(result);
        }

        [HttpPost("add-job")]
        public IActionResult Add(JobAddDto payload)
        {
            var result = jobsService.Add(payload);
            if(result == null)
            {
                return BadRequest("Job cannot be added");
            }

            return Ok(result);
        }
    }
}
