using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ContactsApp.Core.Models;

namespace ContactsApp.Repo.Data
{
    public class RegisteredUserData : IEntityTypeConfiguration<RegisteredUser>
    {
        public void Configure(EntityTypeBuilder<RegisteredUser> builder)
        {
            builder.HasData(
                new RegisteredUser
                {
                    Id = 1,
                    Name = "Lukasz",
                    Email = "lukasz.gulczynski90@gmail.com"
                },

                new RegisteredUser
                {
                    Id = 2,
                    Name = "John",
                    Email = "john.wick@gmail.com"
                });
        }
    }
}
