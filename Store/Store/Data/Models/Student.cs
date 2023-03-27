using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Data.Models
{
    public class Student
    {
        public Student() {
            StudentsSubjects = new HashSet<StudentSubject>();
        }

        public int Id { get; set; }
        
        [Required]
        [MaxLength(15)]
        [MinLength(3)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(15)]
        [MinLength(3)]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        public ICollection<StudentSubject> StudentsSubjects { get; set; }
    }
}