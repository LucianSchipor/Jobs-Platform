using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ApplicationsRepository : BaseRepository<Application>
    {

        public ApplicationsRepository(AppDBContext dBContext) 
            :base(dBContext)
        {
        
        }
        public void AddAplication(Application app)
        {
            _dbContext.Applications.Add(app);
            _dbContext.SaveChanges();
        }

        public List<Application> GetJobApplications(int id)
        {
            var result = GetRecords().Where(a => a.JobId == id).ToList();
            return result;
        }
    }
}
