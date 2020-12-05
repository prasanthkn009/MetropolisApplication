using Metropolis.DAL.Entities;
using Metropolis.DAL.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metropolis.DAL
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<Activity> Activities { get; set; }
        public DbSet<Street> Streets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActivityEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StreetEntityConfiguration());

        }

        
    }
}
