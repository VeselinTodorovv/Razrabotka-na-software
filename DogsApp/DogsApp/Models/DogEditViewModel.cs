using System.ComponentModel.DataAnnotations;

namespace DogsApp.Models
{
    public class DogEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(0, 30)]
        public int Age { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Breed { get; set; }

        [Display(Name = "Dog Picture")]
        public string? Picture { get; set; }
    }
}
