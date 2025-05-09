﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NuGet.DependencyResolver;

namespace Project_practicum.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime FoundedDate { get; set; }

        public int? HeadId { get; set; }

        [ForeignKey("HeadId")]
        public virtual Teacher Head { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
