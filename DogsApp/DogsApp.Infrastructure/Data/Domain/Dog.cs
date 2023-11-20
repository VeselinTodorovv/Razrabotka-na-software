using System.ComponentModel.DataAnnotations;

namespace DogsApp.Infrastructure.Data.Domain
{
    public class Dog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Range(0, 30)]
        public int Age { get; set; }

        [Required]
        public int BreedId { get; set; }
        public Breed Breed { get; set; } = null!;

        public string? Picture { get; set; }
    }
}