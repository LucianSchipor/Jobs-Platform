using Jobs_Platform.Data;
using Jobs_Platform.DataLayer.Repositories;
using System;

namespace Jobs_Platform.DataLayer
{
    public class UnitOfWork
    {
        public JobsRepository Jobs { get; set; }
        private readonly AppDBContext _dbContext;

        public UnitOfWork(AppDBContext dBContext, JobsRepository jobsRepository)
        {
            _dbContext = dBContext;
            Jobs = jobsRepository;
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
