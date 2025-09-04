using Project_practicum.Database;
using Project_practicum.Interfaces.DepartmentInterfaces;
using Project_practicum.Models;
using Project_practicum.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Project_practicum.Filters.DepartmentFilters;

namespace YaroslavGrigorevKt_42_22.Tests
{
    public class DepartmentIntegrationTests
    {
        private readonly DbContextOptions<UniversityDBContext> _dbContextOptions;

        public DepartmentIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<UniversityDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public void Dispose()
        {
            // Удаляем базу данных после каждого теста
            using (var context = new UniversityDBContext(_dbContextOptions))
            {
                context.Database.EnsureDeleted();
            }
        }

        [Fact]
        public async Task GetDepartmentById_ReturnsCorrectResult()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var departmentService = new DepartmentService(ctx);

            // Не указываем Id, позволяем БД сгенерировать его
            var department = new Department { Name = "ИВТ", FoundedDate = new DateTime(1980, 9, 1), HeadId = null };
            await ctx.Departments.AddAsync(department);
            await ctx.SaveChangesAsync();

            // Используем сгенерированный Id
            var result = await departmentService.GetDepartmentByIdAsync(department.Id, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(department.Id, result.Id); // Сравниваем с сгенерированным Id
            Assert.Equal("ИВТ", result.Name);
        }


        [Fact]
        public async Task AddDepartment_WorksCorrectly()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var departmentService = new DepartmentService(ctx);

            var department = new Department { Name = "РЭА", FoundedDate = new DateTime(1990, 9, 1), HeadId = null };
            var result = await departmentService.AddDepartmentAsync(department, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("РЭА", result.Name);
        }

        [Fact]
        public async Task UpdateDepartment_WorksCorrectly()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var departmentService = new DepartmentService(ctx);

            var department = new Department { Id = 1, Name = "ИВТ", FoundedDate = new DateTime(1980, 9, 1), HeadId = null };
            await ctx.Departments.AddAsync(department);
            await ctx.SaveChangesAsync();

            var updateDto = new UpdateDepartmentDto { Id = 1, Name = "РЭА", FoundedDate = new DateTime(1990, 9, 1), HeadId = null };
            var result = await departmentService.UpdateDepartmentAsync(updateDto, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("РЭА", result.Name);
        }

        [Fact]
        public async Task DeleteDepartment_WorksCorrectly()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var departmentService = new DepartmentService(ctx);

            var department = new Department { Id = 1, Name = "ИВТ", FoundedDate = new DateTime(1980, 9, 1), HeadId = null };
            await ctx.Departments.AddAsync(department);
            await ctx.SaveChangesAsync();

            var result = await departmentService.DeleteDepartmentAsync(1, CancellationToken.None);
            Assert.True(result);

            var deleted = await ctx.Departments.FindAsync(1);
            Assert.Null(deleted);
        }

        [Fact]
        public async Task FilterByFoundedDate_ReturnsExpected()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var departmentService = new DepartmentService(ctx);

            var departments = new List<Department>
            {
                new Department { Id = 1, Name = "ИВТ", FoundedDate = new DateTime(1980, 9, 1), HeadId = null },
                new Department { Id = 2, Name = "РЭА", FoundedDate = new DateTime(1990, 9, 1), HeadId = null }
            };

            await ctx.Departments.AddRangeAsync(departments);
            await ctx.SaveChangesAsync();

            var filter = new DepartmentFilter { FoundedDateFrom = new DateTime(1975, 1, 1), FoundedDateTo = new DateTime(1985, 1, 1) };
            var result = await departmentService.GetDepartmentsAsync(filter, CancellationToken.None);

            Assert.Single(result);
            Assert.Equal("ИВТ", result[0].Name);
        }
    }
}
