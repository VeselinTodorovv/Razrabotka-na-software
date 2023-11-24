using System.ComponentModel.DataAnnotations;

namespace DogsApp.Models
{
    public class DogAllViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Age { get; set; }

        [Display(Name = "Breed")]
        public string BreedName { get; set; } = null!;

        [Display(Name = "Dog Picture")]
        public string? Picture { get; set; }
    }
}
