using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Project_practicum.Models;

namespace Project_practicum.Database.Configurations
{
    public class DegreeConfiguration : IEntityTypeConfiguration<Degree>
    {
        private const string TableName = "Degrees";
        public void Configure(EntityTypeBuilder<Degree> builder) 
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name).IsRequired();

        }
    }
}
