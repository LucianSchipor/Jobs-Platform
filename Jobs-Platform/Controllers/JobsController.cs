using Core.Dtos;
using DataLayer.Entities;
using Jobs_Platform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
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
        [Authorize(Roles = "Admin")]
        public ActionResult<List<Job>> GetJobs()
        {
            var result = jobsService.GetJobs();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetJobByID(int id)
        {
            var job = jobsService.GetJobByID(id);

            if (job == null)
                return NotFound();
            return Ok(job);
        }

        [HttpPost("add-job")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(CreateJobDto payload)
        {
            var result = jobsService.AddJob(payload);
            if (result == null)
            {
                return BadRequest("Job cannot be added");
            }

            return Ok(result);
        }

        [HttpPost("create-job")]
        [Authorize(Roles ="Admin")]
        public IActionResult CreateJob(CreateJobDto payload)
        {
            var newCreatedJob = jobsService.AddJob(payload);
            if(newCreatedJob == null)
            {
                return BadRequest("Job cannot be created");
            }
            return Ok(newCreatedJob);
        }


        /// <summary>
        /// You will get jobs that matches with your application infos.
        /// You can apply to a job using Create-Application, and introducing job's id
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        [HttpPost("get-jobs-by-applier-infos")]
        [Authorize(Roles = "Applier")]
        public IActionResult GetJobsByApplierInfo(Application application)
        {
            if (jobsService.GetJobByInfos(application) != null)
                return Ok(jobsService.GetJobByInfos(application));
            else
                return BadRequest("Job not found");
        }

    }
}
