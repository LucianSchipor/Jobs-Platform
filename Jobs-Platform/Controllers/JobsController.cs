using DataLayer.Entities;
using Jobs_Platform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace Controllers
{
    [ApiController]
    [Route("api/jobs")]
    [Authorize]
    public class JobsController : ControllerBase
    {
        private readonly JobsService jobsService;
        public JobsController(JobsService jobsService)
        {
           this.jobsService = jobsService;
        }

        /// <summary>
        /// You wil get all jobs from platform
        /// Requires an ADMIN account.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult<List<Job>> GetJobs()
        {
            var result = jobsService.GetJobs();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetJobByID (int id)
        {
            var job = jobsService.GetJobByID(id);

            if (job == null)
                return NotFound();
            return Ok(job); 
        }

        

        [HttpPost("add-job")]
        public IActionResult Add(Job payload)
        {
            var result = jobsService.AddJob(payload);
            if(result == null)
            {
                return BadRequest("Job cannot be added");
            }

            return Ok(result);
        }
    }
}
