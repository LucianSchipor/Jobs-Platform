using Jobs_Platform.Data;
using Jobs_Platform.Data.Entities;

namespace Jobs_Platform.DataLayer.Repositories
{
    public class JobsRepository : BaseRepository<Job>
    {
        public JobsRepository(AppDBContext dBContext)
            :base(dBContext)
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
    }
}
