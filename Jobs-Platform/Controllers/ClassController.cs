using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Jobs_Platform.Services;
using Jobs_Platform.Dtos;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Repositories;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/classes")]
    public class ClassesController : ControllerBase
    {
        private readonly UnitOfWork classService;

        public ClassesController(UnitOfWork classService)
        {
            this.classService = classService;
        }

        [HttpPost("add")]
        public IActionResult Add(Job job)
        {
            if (job.Id<1)
            {
                return BadRequest("Clasa nu poate fi adaugata");
            }
            classService.Jobs.Add(job);
            return Ok(200);
        }

        [HttpGet("get-all")]
        public ActionResult<JobsRepository> GetAll()
        {
            var result = classService.Jobs.GetAll();

            return Ok(result);
        }
    }
}
