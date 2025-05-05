using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_practicum.Models;

namespace Project_practicum.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "Departments";

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired();

            builder.Property(d => d.FoundedDate)
                .IsRequired();

            // Связь 1:1 между Department.Head и Teacher.HeadingDepartment
            builder.HasOne(d => d.Head)
                   .WithOne(t => t.HeadingDepartment)
                   .HasForeignKey<Department>(d => d.HeadId)
                   .OnDelete(DeleteBehavior.Restrict); // Или другой подходящий DeleteBehavior

            // Уникальность HeadId для обеспечения 1:1
            builder.HasIndex(d => d.HeadId).IsUnique();
        }
    }
}
