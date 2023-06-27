
using DataLayer;
using DataLayer.Entities;

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

        public Job AddJob(Job payload)
        {
            if(payload == null) { return null; }

            var newJob = new Job
            {
                name = payload.name,
                description = payload.description,
                salary = payload.salary,
                location = payload.location,
                industry = payload.industry,
            };
            unitOfWork.Jobs.Insert(newJob);
            unitOfWork.SaveChanges();

            return payload;
        }
    }
}
