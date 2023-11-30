using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Cors;

namespace DogsApp.Models
{
    public class DogDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Age { get; set; }

        [Display(Name = "Breed")]
        public string BreedName { get; set; } = null!;

        public string? Picture { get; set; }

        public string FullName { get; set; } = null!;
    }
}
