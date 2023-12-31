﻿using ContactsApp.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Repo.Data
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryData());
            modelBuilder.ApplyConfiguration(new ContactData());
            modelBuilder.ApplyConfiguration(new SubcategoryData());
        }

        public DbSet<Category> Categories{ get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Subcategory> Subcategories { get; set;}
    }
}
