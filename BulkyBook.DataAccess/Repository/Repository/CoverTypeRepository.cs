using BulkyBookDataAccess.Data;
using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModels.Models;

namespace BulkyBookDataAccess.Repository.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        public CoverTypeRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public void Update(CoverType category)
        {
            _dbContext.CoverTypes.Update(category);
        }
    }
}
