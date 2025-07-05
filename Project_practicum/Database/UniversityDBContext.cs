using Microsoft.EntityFrameworkCore;
using Project_practicum.Models;
using Project_practicum.Database.Configurations;
using System.Collections.Generic;

namespace Project_practicum.Database
{
    public class UniversityDBContext : DbContext
    {
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Load> Loads { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new DegreeConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new LoadConfiguration());
        }

        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
        {
        }
    }
}
