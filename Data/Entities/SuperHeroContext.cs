using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class SuperHeroContext:DbContext
    {
        public SuperHeroContext()
        {

        }
        public SuperHeroContext(DbContextOptions options):base(options)
        {
            
        }
        // this method will add seed data to the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registeration>().ToTable("Registeration");
            modelBuilder.Entity<Login>().ToTable("Login");
            modelBuilder.Entity<Role>().ToTable("Role");
        }
        public DbSet<Registeration> Registerations { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SkillSet> SkillSets { get; set; }


    }
}
