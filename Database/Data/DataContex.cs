using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Data
{
    public class DataContex : DbContext
    {
        public DataContex() : base()
        {
        }
        public DataContex(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }
        public DbSet<AppUser> Users { get; set; }

    }
}
