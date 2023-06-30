using Core.Dtos;
using DataLayer.Entities;
using Jobs_Platform.Dtos;
using Jobs_Platform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text.Json.Serialization;

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

        /// <summary>
        /// You wil get all jobs from platform
        /// Requires an Admin or an Applier account.
        /// </summary>
        /// <returns></returns>
        [HttpGet("view-all-jobs")]
        [Authorize(Roles = "Admin, Applier")]
        public ActionResult<List<ViewJobDto>> GetJobs()
        {
            var result = jobsService.ViewJobs();
            return Ok(result);
        }

        [HttpPost("add-job")]
        [Authorize(Roles = "Admin, Employer")]
        public IActionResult Add(CreateJobDto payload)
        {
            var result = jobsService.AddJob(payload);
            if (result == null)
            {
                return BadRequest("Job cannot be added");
            }

            return Ok(result);
        }

        [HttpDelete("delete-job")]
        [Authorize(Roles ="Employer, Admin")]
        public IActionResult Delete(int jobID, string Email)
        {


            var result = jobsService.Delete(jobID);
            if(result == false)
            {
                return BadRequest("Job not found.");
            }
            else
            {

                return Ok("Job deleted.");
            }
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
            var practical = jobsService.GetPracticeJobs();
            return practical != null ? Ok(practical) : BadRequest();
        }
        [HttpGet("internship-jobs")]
        [AllowAnonymous]
        public IActionResult GetInternshiplJobs()
        {
            var internships = jobsService.GetInternshiplJobs;
            return internships != null ? Ok(internships) : BadRequest();
        }
        [HttpGet("part-time-jobs")]
        [AllowAnonymous]
        public IActionResult GetPartTimeJobs()
        {
            var partTime = jobsService.GetPartTimeJobs();
            return partTime != null ? Ok(partTime) : BadRequest();
        }
        [HttpGet("full-time-jobs")]
        [AllowAnonymous]
        public IActionResult GetFullTimeJobs()
        {
            var fullTime = jobsService.GetFullTimeJobs();
            return fullTime != null ? Ok(fullTime) : BadRequest();
        }
        [HttpGet("it-jobs")]
        [AllowAnonymous]
        public IActionResult GetITJobs()
        {
            var itJobs = jobsService.GetITJobs();
            return itJobs != null ? Ok(itJobs) : BadRequest();
        }
        [HttpGet("agriculture-jobs")]
        [AllowAnonymous]
        public IActionResult GetAgricultureJobs()
        {
            var agriculture = jobsService.GetAgricultureJobs();
            return agriculture != null ? Ok(agriculture) : BadRequest();
        }
        [HttpGet("economy-jobs")]
        [AllowAnonymous]
        public IActionResult GetEconomyJobs()
        {
            var economy = jobsService.GetEconomyJobs();
            return economy != null ? Ok(economy) : BadRequest();
        }
        [HttpGet("arhitecture-jobs")]
        [AllowAnonymous]
        public IActionResult GetArhitectureJobs()
        {
            var arhitecture = jobsService.GetArhitectureJobs();
            return arhitecture != null ? Ok(arhitecture) : BadRequest();
        }
        [HttpGet("healthcare-jobs")]
        [AllowAnonymous]
        public IActionResult GetHealthcareJobs()
        {
            var healthcare = jobsService.GetHealtchcareJobs();
            return healthcare != null ? Ok(healthcare) : BadRequest();
        }
    }
}
