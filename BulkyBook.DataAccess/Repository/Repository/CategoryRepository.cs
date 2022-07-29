using BulkyBookDataAccess.Data;
using BulkyBookDataAccess.Repository.IRepository;
using BulkyBookModels.Models;

namespace BulkyBookDataAccess.Repository.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public void Update(Category category)
        {
            _dbContext.Categories.Update(category);
        }
    }
}
