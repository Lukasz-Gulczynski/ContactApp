using ContactsApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactsApp.Repo.Data
{
    public class ContactData : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData(
                new Contact
                {
                    Id = 1,
                    Name = "Lukasz",
                    Surname = "Gulczynski",
                    Email = "lukasz.gulczynski90@gmail.com",
                    Password = "Test123!",
                    CategoryId = 1,
                    PhoneNumber = "+48603049160",
                    Birthdate = new DateTime(1990, 06, 03),
                },

                new Contact
                {
                    Id = 2,
                    Name = "Natalia",
                    Surname = "Gulczynska",
                    Email = "natalia.gulczynska@gmail.com",
                    Password = "Test321!",
                    CategoryId = 2,
                    PhoneNumber = "+48123456789",
                    Birthdate = new DateTime(1992, 04, 09),
                }); ;
        }
    }
}
