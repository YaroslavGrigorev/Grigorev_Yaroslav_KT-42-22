using Project_practicum.Database;
using Project_practicum.Interfaces.DisciplineInterfaces;
using Project_practicum.Models;
using Project_practicum.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace YaroslavGrigorevKt_42_22.Tests
{
    public class DisciplineIntegrationTests
    {
        private readonly DbContextOptions<UniversityDBContext> _dbContextOptions;

        public DisciplineIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<UniversityDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task GetDisciplineById_ReturnsCorrectResult()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var disciplineService = new DisciplineService(ctx);

            var discipline = new Discipline { Id = 1, Name = "Математика" };
            await ctx.Disciplines.AddAsync(discipline);
            await ctx.SaveChangesAsync();

            var result = await disciplineService.GetDisciplineByIdAsync(1, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Математика", result.Name);
        }

        [Fact]
        public async Task AddDiscipline_WorksCorrectly()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var disciplineService = new DisciplineService(ctx);

            var discipline = new Discipline { Name = "Физика" };
            var result = await disciplineService.AddDisciplineAsync(discipline, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Физика", result.Name);
        }

        [Fact]
        public async Task UpdateDiscipline_WorksCorrectly()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var disciplineService = new DisciplineService(ctx);

            var discipline = new Discipline { Id = 1, Name = "Химия" };
            await ctx.Disciplines.AddAsync(discipline);
            await ctx.SaveChangesAsync();

            var updatedDiscipline = new Discipline { Id = 1, Name = "Обновлённая Химия" };
            var result = await disciplineService.UpdateDisciplineAsync(updatedDiscipline, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Обновлённая Химия", result.Name);
        }

        [Fact]
        public async Task DeleteDiscipline_WorksCorrectly()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var disciplineService = new DisciplineService(ctx);

            var discipline = new Discipline { Id = 1, Name = "Биология" };
            await ctx.Disciplines.AddAsync(discipline);
            await ctx.SaveChangesAsync();

            var result = await disciplineService.DeleteDisciplineAsync(1, CancellationToken.None);
            Assert.True(result);

            var deleted = await ctx.Disciplines.FindAsync(1);
            Assert.Null(deleted);
        }
    }
}
