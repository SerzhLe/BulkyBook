using BulkyBookDataAccess.Data.EntityConfiguration;
using BulkyBookModels.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookDataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CoverType> CoverTypes { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); //to avoid possible errors when migrating

            builder.ApplyConfiguration(new BookConfiguration());
        }
    }
}
