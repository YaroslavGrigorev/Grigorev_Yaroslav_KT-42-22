using System.ComponentModel.DataAnnotations;

namespace Project_practicum.Models
{
    public class Degree
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // Например, "Кандидат наук", "Доктор наук"

    }
}
