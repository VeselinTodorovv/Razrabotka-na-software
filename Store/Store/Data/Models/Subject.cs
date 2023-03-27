using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Store.Data.Models.Enums;

namespace Store.Data.Models
{
    public class Subject
    {
        public Subject() {
            StudentsSubjects = new HashSet<StudentSubject>();
        }

        public int Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }
        
        [Required]
        public SubjectType SubjectType { get; set; }
        
        [Required]
        [Range(typeof(double), "2", "6")]
        public double AverageGrade { get; set; }
        
        [Required]
        public DateTime ReceivedOn { get; set; }
        
        public ICollection<StudentSubject> StudentsSubjects { get; set; }
    }
}