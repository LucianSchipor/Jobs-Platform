
using Core.Dtos;
using DataLayer;
using DataLayer.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;

namespace Jobs_Platform.Services
{
    public class JobsService
    {
        private readonly UnitOfWork unitOfWork;

        public JobsService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Job> GetJobs()
        {
            var jobs = unitOfWork.Jobs.GetAll();
            return jobs;
        }

        public Job GetJobByID(int id)
        {
            return unitOfWork.Jobs.GetJobByID(id);
        }

        public bool AddJob(CreateJobDto payload)
        {
            if (payload == null) { return false; }

            Job newJob = new Job
            {
                description = payload.description,
                salary = payload.salary,
                location = payload.location,
                industry = payload.industry,
            };

            unitOfWork.Jobs.AddJob(newJob);
            return true;
        }

        public List<Job> GetJobByInfos(Application payload)
        {
            //returns jobs by applier's info
            var BigList = new List<Job>();
            if (!GetJobs().Where(c => c.industry == payload.Industry).IsNullOrEmpty())
                GetJobs().
                     Where(c => c.industry == payload.Industry)
                     .ToList()
                         .ForEach(c => BigList.Add(c));

            if (!GetJobs().Where(c => c.salary == payload.Salary).IsNullOrEmpty())
                GetJobs().
                     Where(c => c.salary == payload.Salary)
                     .ToList()
                         .ForEach(c => BigList.Add(c));

            if (!GetJobs().Select(c => c.experience == payload.Experience).IsNullOrEmpty())
                GetJobs().
                     Where(c => c.experience == payload.Experience)
                     .ToList()
                         .ForEach(c => BigList.Add(c));

            return BigList;
        }
    }
}
