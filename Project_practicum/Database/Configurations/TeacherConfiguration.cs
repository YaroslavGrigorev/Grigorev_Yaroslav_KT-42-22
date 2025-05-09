﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_practicum.Models;

namespace Project_practicum.Database.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "Teachers";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            // поля таблицы
            builder.HasKey(t => t.Id);

            builder.Property(t => t.FirstName).IsRequired();

            builder.Property(t => t.LastName).IsRequired();

            // создание связей
            builder.HasMany(t => t.Disciplines).WithOne(d => d.Teacher).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t =>t.Loads).WithOne(l => l.Teacher).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Department).WithMany(d => d.Teachers).HasForeignKey(t => t.DepartmentId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
