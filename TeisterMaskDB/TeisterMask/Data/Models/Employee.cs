using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.Data.Models
{
    public class Employee
    {
        public Employee() {
            EmployeeTasks = new HashSet<EmployeeTask>();
        }

        public int Id { get; set; }
        
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Username { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Phone { get; set; }

        private ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}