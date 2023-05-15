using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Data.Models
{
    public class Resource
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        [Url]
        public string Url { get; set; }
        
        public int CourseId { get; set; }
    }
}