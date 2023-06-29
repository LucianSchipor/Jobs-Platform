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
        [HttpGet("seasonal-jobs")]
        [AllowAnonymous]
        public IActionResult GetSeasonalJobs() 
        {
            var seasonals = jobsService.GetSeasonalJobs();
            return seasonals != null ? Ok(seasonals) : BadRequest();
        }
        [HttpGet("practice-jobs")]
        [AllowAnonymous]
        public IActionResult GetPracticeJobs() 
        {
            var seasonals = jobsService.GetSeasonalJobs();
            return seasonals != null ? Ok(seasonals) : BadRequest();
        }
        [HttpGet("internship-jobs")]
        [AllowAnonymous]
        public IActionResult GetInternshiplJobs() 
        {
            var seasonals = jobsService.GetSeasonalJobs();
            return seasonals != null ? Ok(seasonals) : BadRequest();
        }
        [HttpGet("part-time-jobs")]
        [AllowAnonymous]
        public IActionResult GetPartTimeJobs() 
        {
            var seasonals = jobsService.GetSeasonalJobs();
            return seasonals != null ? Ok(seasonals) : BadRequest();
        }
        [HttpGet("full-time-jobs")]
        [AllowAnonymous]
        public IActionResult GetFullTimeJobs() 
        {
            var seasonals = jobsService.GetSeasonalJobs();
            return seasonals != null ? Ok(seasonals) : BadRequest();
        }
    }
}
