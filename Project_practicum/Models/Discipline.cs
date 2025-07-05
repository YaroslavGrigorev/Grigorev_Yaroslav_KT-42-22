using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Project_practicum.Models
{
    public class Discipline
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsValidDisciplineName()
        {
            return !string.IsNullOrEmpty(Name) &&
                   Regex.IsMatch(Name, @"^[a-zA-Zа-яА-ЯёЁ ]+$");
        }
    }
}
