﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        public Project() {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }
        
        [Required]
        public DateTime OpenDate { get; set; }
        
        [Required]
        public DateTime? DueDate { get; set; }

        private ICollection<Task> Tasks { get; set; }
    }
}