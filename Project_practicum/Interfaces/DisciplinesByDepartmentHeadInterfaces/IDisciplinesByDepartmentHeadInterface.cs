using Project_practicum.Models.DTO;
using Project_practicum.Models;
using System.Threading.Tasks;
using System.Threading;
using Project_practicum.Database;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project_practicum.Interfaces.DisciplinesByDepartmentHeadInterfaces
{
    public interface IDisciplinesByDepartmentHeadService
    {
            Task<DisciplinesByDepartmentHeadDto> GetDisciplinesByHeadIdAsync(int headId, CancellationToken cancellationToken);
    }
    public class DisciplinesByDepartmentHeadService : IDisciplinesByDepartmentHeadService
    {
        private readonly UniversityDBContext _dbContext;
        public DisciplinesByDepartmentHeadService(UniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DisciplinesByDepartmentHeadDto> GetDisciplinesByHeadIdAsync(int headId, CancellationToken cancellationToken)
        {
            // Получаем информацию о заведующем кафедрой
            var department = await _dbContext.Departments
                .Include(d => d.Head) // Включаем заведующего
                .FirstOrDefaultAsync(d => d.HeadId == headId, cancellationToken);

            if (department == null)
            {
                return null; // Если кафедра не найдена, возвращаем null
            }

            // Получаем дисциплины, связанные с преподавателями этой кафедры
            var disciplines = await _dbContext.Loads
                .Include(l => l.Discipline)
                .Where(l => l.Teacher.DepartmentId == department.Id) // Фильтруем по кафедре
                .Select(l => new DisciplineDto
                {
                    Id = l.Discipline.Id,
                    Name = l.Discipline.Name
                })
                .Distinct() // Убираем дубликаты
                .ToListAsync(cancellationToken);

            // Формируем DTO для ответа
            return new DisciplinesByDepartmentHeadDto
            {
                HeadId = department.HeadId.GetValueOrDefault(), // Используем GetValueOrDefault()
                HeadName = $"{department.Head.LastName} {department.Head.FirstName}",
                Disciplines = disciplines.ToArray() // Преобразуем список в массив
            };
        }


    }
}
