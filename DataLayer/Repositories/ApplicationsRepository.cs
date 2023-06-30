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

        public List<Application> Employer_GetApps(int id)
        {
            var result = GetRecords().Where(a => a.JobId == id).ToList();
            return result;
        }

        public List<Application> Applier_GetApps(string email)
        {
            var result = GetRecords().Where(a => a.Email == email).ToList();
            return result;
        }

        public bool DeleteApp(int id, string Email)
        {
           

            GetRecords().Where(a => a.Id == id).ExecuteDelete();
            return true;

        }
    }
}
