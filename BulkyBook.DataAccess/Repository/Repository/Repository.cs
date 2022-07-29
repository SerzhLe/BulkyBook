using BulkyBookDataAccess.Data;
using BulkyBookDataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BulkyBookDataAccess.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;

        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public void Create(T entity)
        {
            _dbContext.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            _dbContext.RemoveRange(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetSingleOrDefault(Expression<Func<T, bool>> condition)
        {
#pragma warning disable
            return await _dbSet.SingleOrDefaultAsync(condition);
#pragma warning restore
        }
    }
}
