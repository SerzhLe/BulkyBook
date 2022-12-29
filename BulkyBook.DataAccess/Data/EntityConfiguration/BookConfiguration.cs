using BulkyBookModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BulkyBookDataAccess.Data.EntityConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasOne<Category>(b => b.Category)
                    .WithOne()
                    .HasForeignKey<Book>(b => b.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne<CoverType>(b => b.CoverType)
                    .WithOne()
                    .HasForeignKey<Book>(b => b.CoverTypeId)
                    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
