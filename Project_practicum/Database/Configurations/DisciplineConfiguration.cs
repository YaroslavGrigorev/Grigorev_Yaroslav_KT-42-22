using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_practicum.Database.Helpers;
using Project_practicum.Models;

namespace Project_practicum.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "Disciplines";
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            //Первичный ключ
            builder
                .HasKey(p => p.Id)
                .HasName($"pl_{TableName}_discipline_id");

            //Автоинкрементация
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Discipline_Id")
                .HasComment("Id дисциплины");

            builder.Property(p => p.Name)
               .IsRequired()
               .HasColumnName("Discipline_Name")
               .HasColumnType(ColumnType.String).HasMaxLength(100)
               .HasComment("Название дисциплины");

            builder.HasIndex(p => p.Name)
                    .HasDatabaseName($"idx_{TableName}_name");

            builder.ToTable(TableName);
        }
    }
}
