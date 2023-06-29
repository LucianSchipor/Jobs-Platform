
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
        public List<Job> GetSeasonalJobs()
        {
            var jobs= GetJobs();
            List<Job> seasonals = new();
            foreach(Job job in jobs) 
            {
                if(job.type==JobType.SEASONAL)
                {
                    seasonals.Add(job);
                }
            }
            return seasonals;
        }
        public List<Job> GetPracticeJobs()
        {
            var jobs = GetJobs();
            List<Job> practical = new();
            foreach (Job job in jobs)
            {
                if (job.type == JobType.PRACTICE)
                {
                    practical.Add(job);
                }
            }
            return practical;
        }
        public List<Job> GetInternshiplJobs()
        {
            var jobs= GetJobs();
            List<Job> internships = new();
            foreach(Job job in jobs) 
            {
                if(job.type==JobType.INTERSHIP)
                {
                    internships.Add(job);
                }
            }
            return internships;
        }
       
        public List<Job> GetPartTimeJobs()
        {
            var jobs= GetJobs();
            List<Job> miniJobs = new();
            foreach(Job job in jobs) 
            {
                if(job.type==JobType.PART_TIME)
                {
                    miniJobs.Add(job);
                }
            }
            return miniJobs;
        }
        public List<Job> GetFullTimeJobs()
        {
            var jobs= GetJobs();
            List<Job> fullJobs = new();
            foreach(Job job in jobs) 
            {
                if(job.type==JobType.FULL_TIME)
                {
                    fullJobs.Add(job);
                }
            }
            return fullJobs;
        }
        public List<Job> GetITJobs()
        {
            var jobs= GetJobs();
            List<Job> itJobs = new();
            foreach(Job job in jobs) 
            {
                if(job.industry==IndustryEnum.IT)
                {
                    itJobs.Add(job);
                }
            }
            return itJobs;
        }
        public List<Job> GetAgricultureJobs()
        {
            var jobs= GetJobs();
            List<Job> agricultureJobs = new();
            foreach(Job job in jobs) 
            {
                if(job.industry==IndustryEnum.AGRICULTURE)
                {
                    agricultureJobs.Add(job);
                }
            }
            return agricultureJobs;
        }
        public List<Job> GetEconomyJobs()
        {
            var jobs= GetJobs();
            List<Job> economyJobs = new();
            foreach(Job job in jobs) 
            {
                if(job.industry==IndustryEnum.ECONOMY)
                {
                    economyJobs.Add(job);
                }
            }
            return economyJobs;
        }
        public List<Job> GetArhitectureJobs()
        {
            var jobs= GetJobs();
            List<Job> arhitectureJobs = new();
            foreach(Job job in jobs) 
            {
                if(job.industry==IndustryEnum.ARHITECTURE)
                {
                    arhitectureJobs.Add(job);
                }
            }
            return arhitectureJobs;
        }
        public List<Job> GetHealtchcareJobs()
        {
            var jobs= GetJobs();
            List<Job> healthcareJobs = new();
            foreach(Job job in jobs) 
            {
                if(job.industry==IndustryEnum.HEALTHCARE)
                {
                    healthcareJobs.Add(job);
                }
            }
            return healthcareJobs;
        }
    }
}
