using DataLayer.Entities;
using DataLayer.Repositories;
using System;

namespace DataLayer
{
    public class UnitOfWork
    {
        public JobsRepository Jobs { get; set; }
        public AccountRepository Accounts { get; set; }

        private readonly AppDBContext _dbContext;

        public UnitOfWork(AppDBContext dBContext, JobsRepository jobsRepository, AccountRepository accountRepository)
        {
            _dbContext = dBContext;
            Jobs = jobsRepository;
            Accounts = accountRepository;
        }
          public void Add(ref Job job)
        {
            Jobs.Add(job);
            _dbContext.Jobs.Add(job);
            _dbContext.SaveChanges();
        }
        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                var errorMessage = "Error when saving to the database: "
                    + $"{exception.Message}\n\n"
                    + $"{exception.InnerException}\n\n"
                    + $"{exception.StackTrace}\n\n";

                Console.WriteLine(errorMessage);
            }
        }

    }
}
