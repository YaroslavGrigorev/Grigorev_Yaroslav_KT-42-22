using Project_practicum.Database;
using Project_practicum.Filters.TeacherFilters;
using Project_practicum.Interfaces.TeacherInterfaces;
using Project_practicum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace YaroslavGrigorevKt_42_22.Tests
{
    public class TeacherIntegrationTests
    {
        private readonly DbContextOptions<UniversityDBContext> _dbContextOptions;

        public TeacherIntegrationTests()
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

            // Логируем количество кафедр
            var departmentCount = await ctx.Departments.CountAsync();
            Console.WriteLine($"Number of Departments: {departmentCount}");

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

            // Логируем количество преподавателей
            var teacherCount = await ctx.Teachers.CountAsync();
            Console.WriteLine($"Number of Teachers: {teacherCount}");

            // Дополнительная проверка: убедимся, что преподаватель сохранен корректно
            var savedTeacher = await ctx.Teachers.FindAsync(teacher.Id);
            Console.WriteLine($"Saved teacher is null: {savedTeacher == null}");
            if (savedTeacher != null)
            {
                Console.WriteLine($"Saved teacher DepartmentId: {savedTeacher.DepartmentId}");
                Console.WriteLine($"Saved teacher DegreeId: {savedTeacher.DegreeId}");
                Console.WriteLine($"Saved teacher PositionId: {savedTeacher.PositionId}");
            }

            // Получаем преподавателя по Id
            var result = await teacherService.GetTeacherByIdAsync(teacher.Id, CancellationToken.None);

            // Проверяем результат
            Assert.NotNull(result);
            Assert.Equal(teacher.Id, result.Id);
            Assert.Equal("Петр", result.FirstName);
    
            // Дополнительные проверки связанных данных
            Assert.NotNull(result.Department);
            Assert.NotNull(result.Degree);
            Assert.NotNull(result.Position);
            Assert.Equal("ИВТ", result.Department.Name);
            Assert.Equal("Кандидат наук", result.Degree.Name);
            Assert.Equal("Доцент", result.Position.Name);
        }




        [Fact]
        public async Task AddTeacher_WorksCorrectly()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var teacherService = new TeacherService(ctx);

            var department = new Department { Id = 1, Name = "ИВТ" };
            await ctx.Departments.AddAsync(department);

            var teacher = new Teacher { FirstName = "Петр", LastName = "Петров", DepartmentId = 1 };
            var result = await teacherService.AddTeacherAsync(teacher, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Петр", result.FirstName);
        }

        [Fact]
        public async Task UpdateTeacher_WorksCorrectly()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var teacherService = new TeacherService(ctx);

            var department = new Department { Id = 1, Name = "ИВТ" };
            await ctx.Departments.AddAsync(department);

            var teacher = new Teacher { Id = 1, FirstName = "Старый", LastName = "Преподаватель", DepartmentId = 1 };
            await ctx.Teachers.AddAsync(teacher);
            await ctx.SaveChangesAsync();

            var updatedTeacher = new Teacher { Id = 1, FirstName = "Обновлённый", LastName = "Преподаватель", DepartmentId = 1 };
            var result = await teacherService.UpdateTeacherAsync(updatedTeacher, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Обновлённый", result.FirstName);
        }

        [Fact]
        public async Task DeleteTeacher_WorksCorrectly()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var teacherService = new TeacherService(ctx);

            var department = new Department { Id = 1, Name = "ИВТ" };
            await ctx.Departments.AddAsync(department);

            var teacher = new Teacher { Id = 1, FirstName = "Обновлённый", LastName = "Преподаватель", DepartmentId = 1 };
            await ctx.Teachers.AddAsync(teacher);
            await ctx.SaveChangesAsync();

            var result = await teacherService.DeleteTeacherAsync(1, CancellationToken.None);
            Assert.True(result);

            var deleted = await ctx.Teachers.FindAsync(1);
            Assert.Null(deleted);
        }

        [Fact]
        public async Task FilterByDepartment_ReturnsExpected()
        {
            var ctx = new UniversityDBContext(_dbContextOptions);
            var teacherService = new TeacherService(ctx);

            // Создаем необходимые сущности: кафедры, ученые степени и должности
            var department1 = new Department { Name = "ИВТ" };
            var department2 = new Department { Name = "Математика" };

            var degree = new Degree { Name = "Кандидат наук" };
            var position = new Position { Name = "Доцент" };

            await ctx.Departments.AddRangeAsync(department1, department2);
            await ctx.Degrees.AddAsync(degree);
            await ctx.Positions.AddAsync(position);
            await ctx.SaveChangesAsync();

            // Создаем преподавателей со всеми обязательными полями
            var teachers = new List<Teacher>
    {
        new Teacher
        {
            FirstName = "Иван",
            LastName = "Иванов",
            DepartmentId = department1.Id,
            DegreeId = degree.Id,
            PositionId = position.Id
        },
        new Teacher
        {
            FirstName = "Петр",
            LastName = "Петров",
            DepartmentId = department1.Id,
            DegreeId = degree.Id,
            PositionId = position.Id
        },
        new Teacher
        {
            FirstName = "Сергей",
            LastName = "Сергеев",
            DepartmentId = department2.Id,
            DegreeId = degree.Id,
            PositionId = position.Id
        }
    };

            await ctx.Teachers.AddRangeAsync(teachers);
            await ctx.SaveChangesAsync();

            // Проверяем, что все преподаватели сохранены
            var allTeachersCount = await ctx.Teachers.CountAsync();
            Console.WriteLine($"Total teachers: {allTeachersCount}");

            // Применяем фильтр
            var filter = new TeacherFilter { Department = "ИВТ" };
            var result = await teacherService.GetTeachersAsync(filter, CancellationToken.None);

            var teacherList = Assert.IsAssignableFrom<Teacher[]>(result);

            // Дополнительная отладочная информация
            Console.WriteLine($"Filtered teachers count: {teacherList.Length}");
            foreach (var t in teacherList)
            {
                Console.WriteLine($"Teacher: {t.FirstName} {t.LastName}, Department: {t.Department?.Name}");
            }

            Assert.Equal(2, teacherList.Length); // Два преподавателя в ИВТ
        }
    }
}
