using System.ComponentModel.DataAnnotations;

namespace Project_practicum.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } // Например, "Преподаватель", "Старший преподаватель", "Доцент", "Профессор"

    }
}
