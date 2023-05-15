using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp.Models
{
    public class DogCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(1, 30, ErrorMessage = "Age must be a positive number and lower than 30")]
        public int Age { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Breed { get; set; }

        public string Picture { get; set; }
    }
}
