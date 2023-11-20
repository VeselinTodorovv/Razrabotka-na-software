using System.ComponentModel.DataAnnotations;

namespace DogsApp.Models
{
    public class DogCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(0, 30)]
        public int Age { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Breed")]
        public int BreedId { get; set; }

        [Display(Name = "Dog Picture")]
        public string? Picture { get; set; }

        public virtual List<BreedPairViewModel> Breeds { get; set; } = new List<BreedPairViewModel>();
    }
}
