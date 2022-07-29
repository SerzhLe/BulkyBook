using BulkyBookDataAccess.Data;
using BulkyBookDataAccess.Repository.IRepository;

namespace BulkyBookDataAccess.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICategoryRepository CategoryRepository => new CategoryRepository(_dbContext);

        public ICoverTypeRepository CoverTypeRepository => new CoverTypeRepository(_dbContext);

        public async Task<bool> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
