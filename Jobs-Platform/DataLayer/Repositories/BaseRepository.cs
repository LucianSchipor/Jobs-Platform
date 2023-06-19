using Jobs_Platform.Data;
using Jobs_Platform.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jobs_Platform.DataLayer.Repositories
{
    public class BaseRepository<T>where T : BaseEntity 
    {
        protected readonly AppDBContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(AppDBContext dBContext)
        {
            _dbContext = dBContext;
            _dbSet = dBContext.Set<T>();
        }

        public void Remove(T entity) {
            _dbSet.Remove(entity);
        }
        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public List<T> GetAll()
        {
            return GetRecords().ToList();
        }
        protected IQueryable<T> GetRecords()
        {
            return _dbSet.AsQueryable<T>();
        }
        public bool Any(Func<T, bool> expression) {
        return GetRecords().Any(expression);
        }
    }
}
