using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Data.Models
{
    public class Student
    {
        public Student() {
            Courses = new HashSet<Course>();
            Homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MinLength(10)]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        
        [Required]
        public DateTime RegisteredOn { get; set; }
        
        public DateTime? Birthday { get; set; }
        
        private ICollection<Course> Courses { get; set; }
        private ICollection<Homework> Homeworks { get; set; }
    }
}