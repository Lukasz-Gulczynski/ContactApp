using ContactsApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactsApp.Repo.Data
{
    public class CategoryData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    CategoryName = "Private",
                },

                new Category
                {
                    Id = 2,
                    CategoryName = "Bussines",
                    SubcategoryId = 2
                },

                new Category
                {
                    Id = 3,
                    CategoryName = "Other",
                });
        }
    }
}
