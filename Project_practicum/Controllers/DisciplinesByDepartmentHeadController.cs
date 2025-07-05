using Microsoft.AspNetCore.Mvc;
using Project_practicum.Interfaces.DisciplinesByDepartmentHeadInterfaces;

namespace Project_practicum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinesByDepartmentHeadController : ControllerBase
    {
        private readonly ILogger<DisciplinesByDepartmentHeadController> _logger;
        private readonly IDisciplinesByDepartmentHeadService _DisciplinesByDepartmentHeadService;
        public DisciplinesByDepartmentHeadController(
            ILogger<DisciplinesByDepartmentHeadController> logger,
            IDisciplinesByDepartmentHeadService DisciplinesByDepartmentHeadService)
        {
            _logger = logger;
            _DisciplinesByDepartmentHeadService = DisciplinesByDepartmentHeadService;
        }
        [HttpGet("{headId}/disciplines")]
        public async Task<IActionResult> GetDisciplinesByHeadId(int headId, CancellationToken cancellationToken)
        {
            var result = await _DisciplinesByDepartmentHeadService.GetDisciplinesByHeadIdAsync(headId, cancellationToken);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
