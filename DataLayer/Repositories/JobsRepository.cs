﻿using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class JobsRepository : BaseRepository<Job>
    {
        public JobsRepository(AppDBContext dBContext)
            : base(dBContext)
        {

        }
        public List<Job> GetAllJobs()
        {
            return GetRecords().Select(r => new Job()
            {
                Id = r.Id,
                name = r.name,
                description = r.description,
                salary = r.salary,
            }).ToList();
        }

        public Job GetJobByID(int id)
        {
            var result = GetRecords().Where(r => r.Id == id).FirstOrDefault();

            return result;
        }

        public void AddJob(Job job)
        {
            _dbContext.Jobs.Add(job);
            _dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            _dbContext.Jobs.Where(a => a.Id == id).ExecuteDelete();
            return true;
        }
       
    }
}
