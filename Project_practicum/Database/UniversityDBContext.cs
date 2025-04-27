using Microsoft.EntityFrameworkCore;
using Project_practicum.Models;
using Project_practicum.Database.Configurations;
using System.Collections.Generic;

namespace Project_practicum.Database
{
    public class UniversityDBContext : DbContext
    {
        DbSet<Degree> Degrees { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Discipline> Disciplines { get; set; }
        DbSet<Load> Loads { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<Teacher> Teachers { get; set; }

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
