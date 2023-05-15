using System;
using System.ComponentModel.DataAnnotations;
using StudentSystem.Data.Models.Enums;

namespace StudentSystem.Data.Models
{
    public class Homework
    {
        public int Id { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public ContentType ContentType { get; set; }
        
        [Required]
        public DateTime SubmissionTime { get; set; }
        
        [Required]
        public int StudentId { get; set; }
        
        [Required]
        public int CourseId { get; set; }
    }
}