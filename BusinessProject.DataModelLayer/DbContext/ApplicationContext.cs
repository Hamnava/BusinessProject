using BusinessProject.DataModelLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessProject.DataModelLayer.DbContext
{
   public class ApplicationContext : IdentityDbContext<SystemUsers,SystemRoles,string>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option) :base(option)
        {

        }

         public DbSet<SystemJobs> SystemJobs_tbl { get; set; }
         public DbSet<UserJob> UserJobs { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<RolePattern> RolePatterns { get; set; }
        public DbSet<RolePatternDetails> RolePatternDetails { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Letter> Letters { get; set; }
        public DbSet<AdminstrativeForm> AdminstrativeForms { get; set; }
        //public DbSet<Resign> Resigns { get; set; }
        //public DbSet<OverTime> OverTimes { get; set; }
        //public DbSet<Attendance> Attendances { get; set; }
        //public DbSet<Project> Projects { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<SystemUsers>(entity =>
            {
                entity.ToTable(name: "Users");
            });
            builder.Entity<SystemRoles>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
        }
    }
}
