using Core.Services;
using DataLayer.Entities;
using Jobs_Platform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Jobs_Platform.Controllers
{


    [ApiController]
    [Route("api/application")]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationsService _applicationsService;
        public ApplicationController(ApplicationsService applicationsService) 
        {
            this._applicationsService = applicationsService;
        }


        /// <summary>
        /// You need an Applier or an Admin account. You get all jobs, and based on their ID, you create applications.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("create-application")]
        [Authorize(Roles = "Admin, Applier")]
        public IActionResult CreateApplication(Application payload)
        {
            var result = _applicationsService.CreateApplication(payload);
            if (result == null)
            {
                return BadRequest("You already applied for this job.");
            }
            return Ok(result);
        }
        /// <summary>
        /// You need an Employer account. You will see, based on Job id, all current apps.
        /// </summary>
        /// <param name="Job_Id"></param>
        /// <returns></returns>
        [HttpGet("employer-view-applications")]
        [Authorize(Roles = "Admin, Employer")]

        public IActionResult GetApplicationsForEmployer(int Job_Id)
        {
            var result = _applicationsService.Employer_ViewJobApplications(Job_Id);
            return Ok(result);
        }

       
        [HttpGet("applier-view-applications")]
        [Authorize(Roles ="Admin, Applier")]
        public IActionResult GetApplicationsForApplier(string Email)
        {
            var result = _applicationsService.Applier_ViewJobApplications(Email);
            return Ok(result);
        }
    }
}
