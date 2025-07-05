using System.ComponentModel.DataAnnotations;

namespace Project_practicum.Models.DTO
{
    public class DisciplinesByDepartmentHeadDto
    {
        public int HeadId { get; set; }
        public string HeadName { get; set; } // ФИО заведующего
        public DisciplineDto[] Disciplines { get; set; }
    }
}
