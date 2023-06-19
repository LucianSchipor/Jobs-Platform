using Jobs_Platform.Data.Entities;
using Jobs_Platform.DataLayer;
using Jobs_Platform.Dtos;

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

        public JobAddDto Add(JobAddDto payload)
        {
            if(payload == null) { return null; }

            var newJob = new Job
            {
                name = payload.name,
                description = payload.description,
                salary = payload.salary,
            };
            unitOfWork.Jobs.Insert(newJob);
            unitOfWork.SaveChanges();

            return payload;
        }
    }
}
