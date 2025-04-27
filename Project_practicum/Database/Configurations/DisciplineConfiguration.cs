using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_practicum.Models;

namespace Project_practicum.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "Disciplines";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired();

            builder.HasMany(d => d.Loads)
                .WithOne(l => l.Discipline)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
