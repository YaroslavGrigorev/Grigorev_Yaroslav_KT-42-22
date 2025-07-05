﻿using Microsoft.AspNetCore.Mvc;
using Project_practicum.Filters.DisciplineFilters;
using Project_practicum.Interfaces.DisciplineInterfaces;
using Project_practicum.Models;
using Project_practicum.Models.DTO;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Project_practicum.Database;

namespace Project_practicum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinesController : ControllerBase
    {
        private readonly ILogger<DisciplinesController> _logger;
        private readonly IDisciplineService _disciplineService;
        private readonly UniversityDBContext _dbContext;

        public DisciplinesController(
            ILogger<DisciplinesController> logger,
            IDisciplineService disciplineService,
            UniversityDBContext dbContext)
        {
            _logger = logger;
            _disciplineService = disciplineService;
            _dbContext = dbContext;
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetFilteredDisciplines(
            [FromBody] DisciplineFilter filter,
            CancellationToken cancellationToken)
        {
            var disciplines = await _disciplineService.GetDisciplinesAsync(filter, cancellationToken);
            return Ok(disciplines);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDisciplineById(int id, CancellationToken cancellationToken)
        {
            var discipline = await _disciplineService.GetDisciplineByIdAsync(id, cancellationToken);
            if (discipline == null) return NotFound();
            return Ok(discipline);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscipline(
            [FromBody] AddDisciplineDto disciplineDto,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var discipline = new Discipline
            {
                Name = disciplineDto.Name
            };

            var createdDiscipline = await _disciplineService.AddDisciplineAsync(discipline, cancellationToken);
            return CreatedAtAction(nameof(GetDisciplineById), new { id = createdDiscipline.Id }, createdDiscipline);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiscipline(
            int id,
            [FromBody] UpdateDisciplineDto disciplineDto,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != disciplineDto.Id)
                return BadRequest("ID в пути и в теле запроса не совпадают");

            var discipline = new Discipline
            {
                Id = disciplineDto.Id,
                Name = disciplineDto.Name
            };

            var updatedDiscipline = await _disciplineService.UpdateDisciplineAsync(discipline, cancellationToken);
            return Ok(updatedDiscipline);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscipline(int id, CancellationToken cancellationToken)
        {
            var result = await _disciplineService.DeleteDisciplineAsync(id, cancellationToken);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}