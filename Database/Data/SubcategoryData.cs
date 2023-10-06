using ContactsApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactsApp.Repo.Data
{
    public class SubcategoryData : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.HasData(
                new Subcategory
                {
                    SubcategoryId = 1,
                    SubcategoryName = "Boss",
                },

                new Subcategory
                {
                    SubcategoryId = 2,
                    SubcategoryName = "Client",
                },

                new Subcategory
                {
                    SubcategoryId = 3,
                    SubcategoryName = "Office",
                });
        }
    }
}
