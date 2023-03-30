using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeisterMask.Data.Models.Enum;

namespace TeisterMask.Data.Models
{
    public class Task
    {
        public Task() {
            EmployeeTasks = new HashSet<EmployeeTask>();
        }

        public int Id { get; set; }
        
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }
        
        [Required]
        public DateTime OpenDate { get; set; }
        
        [Required]
        public DateTime DueDate { get; set; }
        
        [Required]
        public ExecutionType ExecutionType { get; set; }
        
        [Required]
        public LabelType LabelType { get; set; }
        
        [Required]
        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }
        
        public Project Project { get; set; }

        private ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}