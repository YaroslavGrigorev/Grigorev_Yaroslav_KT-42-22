using System.ComponentModel.DataAnnotations;

namespace Project_practicum.Models.DTO
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FoundedDate { get; set; }
        public TeacherDto? Head { get; set; }
        public int TeachersCount { get; set; }

        public record TeacherDto(int Id, string FirstName, string LastName);
    }

    public class AddDepartmentDto
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public DateTime FoundedDate { get; set; }

        public int? HeadId { get; set; }
    }

    public class UpdateDepartmentDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public DateTime FoundedDate { get; set; }

        public int? HeadId { get; set; }
    }
}