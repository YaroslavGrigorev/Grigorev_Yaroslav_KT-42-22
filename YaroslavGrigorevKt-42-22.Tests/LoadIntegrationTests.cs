using Project_practicum.Database;
using Project_practicum.Interfaces.LoadInterfaces;
using Project_practicum.Models;
using Project_practicum.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Project_practicum.Interfaces.TeacherInterfaces;

namespace YaroslavGrigorevKt_42_22.Tests
{
    public class LoadIntegrationTests
    {
        private readonly DbContextOptions<UniversityDBContext> _dbContextOptions;
        public LoadIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<UniversityDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }
        /*[Fact]
        public async Task GetLoadById_ReturnsCorrectResult()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var loadService = new LoadService(ctx);
            var department = new Department { Id = 1, Name = "ИВТ" };
            await ctx.Departments.AddAsync(department);
            var teacher = new Teacher { Id = 1, FirstName = "Иван", LastName = "Иванов", DepartmentId = 1 };
            await ctx.Teachers.AddAsync(teacher);

            var discipline = new Discipline { Id = 1, Name = "Математика" };
            await ctx.Disciplines.AddAsync(discipline);
            var load = new Load { Id = 1, DisciplineId = 1, TeacherId = 1, Hours = 20 };
            await ctx.Loads.AddAsync(load);
            await ctx.SaveChangesAsync();
            var result = await loadService.GetLoadByIdAsync(1, CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(20, result.Hours);
        }*/
        [Fact]
        public async Task GetTeacherById_ReturnsCorrectResult()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var teacherService = new TeacherService(ctx);

            // Создаем и добавляем все необходимые сущности
            var department = new Department { Name = "ИВТ" };
            var degree = new Degree { Name = "Кандидат наук" };
            var position = new Position { Name = "Доцент" };

            await ctx.Departments.AddAsync(department);
            await ctx.Degrees.AddAsync(degree);
            await ctx.Positions.AddAsync(position);
            await ctx.SaveChangesAsync();

            // Создаем преподавателя со всеми обязательными полями
            var teacher = new Teacher
            {
                FirstName = "Петр",
                LastName = "Петров",
                DepartmentId = department.Id,
                DegreeId = degree.Id,     // Добавляем обязательное поле
                PositionId = position.Id  // Добавляем обязательное поле
            };

            await ctx.Teachers.AddAsync(teacher);
            await ctx.SaveChangesAsync();

            // Проверяем, что преподаватель сохранен корректно
            var savedTeacher = await ctx.Teachers.FindAsync(teacher.Id);
            Assert.NotNull(savedTeacher); // Если падает здесь - проблема с сохранением

            // Получаем преподавателя через сервис
            var result = await teacherService.GetTeacherByIdAsync(teacher.Id, CancellationToken.None);

            // Проверяем результат
            Assert.NotNull(result); // Если падает здесь - проблема в GetTeacherByIdAsync
            Assert.Equal(teacher.Id, result.Id);
            Assert.Equal("Петр", result.FirstName);
            Assert.NotNull(result.Department); // Проверяем, что связанные данные загрузились
            Assert.NotNull(result.Degree);
            Assert.NotNull(result.Position);
        }

        [Fact]
        public async Task AddLoad_WorksCorrectly()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var loadService = new LoadService(ctx);

            // Создаем и добавляем кафедру
            var department = new Department { Name = "ИВТ" };
            await ctx.Departments.AddAsync(department);

            // Создаем и добавляем ученую степень и должность
            var degree = new Degree { Name = "Кандидат наук" };
            var position = new Position { Name = "Доцент" };
            await ctx.Degrees.AddAsync(degree);
            await ctx.Positions.AddAsync(position);

            await ctx.SaveChangesAsync(); // Сохраняем изменения

            // Создаем и добавляем преподавателя со всеми обязательными полями
            var teacher = new Teacher
            {
                FirstName = "Иван",
                LastName = "Иванов",
                DepartmentId = department.Id,
                DegreeId = degree.Id,     // Добавляем обязательное поле
                PositionId = position.Id  // Добавляем обязательное поле
            };
            await ctx.Teachers.AddAsync(teacher);

            // Создаем и добавляем дисциплину
            var discipline = new Discipline { Name = "Математика" };
            await ctx.Disciplines.AddAsync(discipline);

            await ctx.SaveChangesAsync(); // Сохраняем изменения

            // Создаем DTO для нагрузки
            var loadDto = new AddLoadDto
            {
                DisciplineId = discipline.Id,
                TeacherId = teacher.Id,
                Hours = 30
            };

            // Добавляем нагрузку через сервис
            var result = await loadService.AddLoadAsync(loadDto, CancellationToken.None);

            // Проверяем результат
            Assert.NotNull(result);
            Assert.Equal(30, result.Hours);
        }


        [Fact]
        public async Task UpdateLoad_WorksCorrectly()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var loadService = new LoadService(ctx);

            // Создаем и добавляем все необходимые сущности
            var department = new Department { Name = "ИВТ" };

            var degree = new Degree { Name = "Кандидат наук" };
            var position = new Position { Name = "Доцент" };

            await ctx.Departments.AddAsync(department);
            await ctx.Degrees.AddAsync(degree);
            await ctx.Positions.AddAsync(position);
            await ctx.SaveChangesAsync();

            // Создаем и добавляем преподавателя со всеми обязательными полями
            var teacher = new Teacher
            {
                FirstName = "Иван",
                LastName = "Иванов",
                DepartmentId = department.Id,
                DegreeId = degree.Id,
                PositionId = position.Id
            };
            await ctx.Teachers.AddAsync(teacher);

            // Создаем и добавляем дисциплину
            var discipline = new Discipline { Name = "Математика" };
            await ctx.Disciplines.AddAsync(discipline);

            await ctx.SaveChangesAsync();

            // Создаем и добавляем нагрузку
            var load = new Load
            {
                DisciplineId = discipline.Id,
                TeacherId = teacher.Id,
                Hours = 20
            };
            await ctx.Loads.AddAsync(load);
            await ctx.SaveChangesAsync();

            // Проверяем, что нагрузка создана
            var initialLoad = await ctx.Loads.FindAsync(load.Id);
            Assert.NotNull(initialLoad);
            Console.WriteLine($"Initial load ID: {initialLoad.Id}, Hours: {initialLoad.Hours}");

            // Создаем DTO для обновления нагрузки
            var updatedLoadDto = new UpdateLoadDto
            {
                Id = load.Id, // Используем сгенерированный ID
                DisciplineId = discipline.Id,
                TeacherId = teacher.Id,
                Hours = 50
            };

            // Обновляем нагрузку через сервис
            var result = await loadService.UpdateLoadAsync(updatedLoadDto, CancellationToken.None);

            // Проверяем результат
            Assert.NotNull(result);
            Assert.Equal(50, result.Hours);

            // Дополнительная проверка: убедимся, что нагрузка действительно обновлена в базе
            var updatedLoad = await ctx.Loads.FindAsync(load.Id);
            Assert.NotNull(updatedLoad);
            Assert.Equal(50, updatedLoad.Hours);
        }
    }
}