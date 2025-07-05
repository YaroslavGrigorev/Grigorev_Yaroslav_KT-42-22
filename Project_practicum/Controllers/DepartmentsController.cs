﻿using Microsoft.AspNetCore.Mvc;
using Project_practicum.Filters.DepartmentFilters;
using Project_practicum.Interfaces.DepartmentInterfaces;
using Project_practicum.Models;
using Project_practicum.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Project_practicum.Database;

namespace Project_practicum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IDepartmentService _departmentService;
        private readonly UniversityDBContext _dbContext;

        public DepartmentsController(
            ILogger<DepartmentsController> logger,
            IDepartmentService departmentService,
            UniversityDBContext dbContext)
        {
            _logger = logger;
            _departmentService = departmentService;
            _dbContext = dbContext;
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetFilteredDepartments(
            [FromBody] DepartmentFilter filter,
            CancellationToken cancellationToken)
        {
            var departments = await _departmentService.GetDepartmentsAsync(filter, cancellationToken);
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id, cancellationToken);
            if (department == null) return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(
            [FromBody] AddDepartmentDto departmentDto,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Проверка существования HeadId, если он указан
            /*if (departmentDto.HeadId.HasValue)
            {
                var headExists = await _dbContext.Teachers
                    .AnyAsync(t => t.Id == departmentDto.HeadId.Value, cancellationToken);

                if (!headExists)
                    return BadRequest("Указанный заведующий не существует");
            }*/

            var department = new Department
            {
                Name = departmentDto.Name,
                FoundedDate = departmentDto.FoundedDate,
                //HeadId = departmentDto.HeadId
                HeadId = null
            };

            var createdDepartment = await _departmentService.AddDepartmentAsync(department, cancellationToken);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = createdDepartment.Id }, createdDepartment);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(
            int id,
            [FromBody] UpdateDepartmentDto departmentDto,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != departmentDto.Id)
                return BadRequest("ID в пути и в теле запроса не совпадают");


            try
            {
                var updatedDepartment = await _departmentService.UpdateDepartmentAsync(departmentDto, cancellationToken);
                return Ok(updatedDepartment);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при обновлении кафедры");
                return StatusCode(500, "Произошла ошибка при обновлении кафедры");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id, CancellationToken cancellationToken)
        {
            var result = await _departmentService.DeleteDepartmentAsync(id, cancellationToken);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}