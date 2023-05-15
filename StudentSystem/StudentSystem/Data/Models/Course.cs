using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Data.Models
{
    public class Course
    {
        public Course() {
            Students = new HashSet<Student>();
            Resources = new HashSet<Resource>();
            Homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }
        
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        private ICollection<Student> Students { get; set; }
        private ICollection<Resource> Resources { get; set; }
        private ICollection<Homework> Homeworks { get; set; }
    }
}