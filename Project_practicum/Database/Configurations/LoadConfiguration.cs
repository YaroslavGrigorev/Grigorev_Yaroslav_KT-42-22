﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_practicum.Models;

namespace Project_practicum.Database.Configurations
{
    public class LoadConfiguration : IEntityTypeConfiguration<Load>
    {
        private const string TableName = "Loads";
        public void Configure(EntityTypeBuilder<Load> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Hours)
                .IsRequired();

            builder.HasOne(l => l.Teacher)
                .WithMany(t => t.Loads)
                .HasForeignKey(l => l.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Discipline)
                .WithMany(d => d.Loads)
                .HasForeignKey(l => l.DisciplineId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
