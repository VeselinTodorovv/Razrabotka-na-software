using System.ComponentModel.DataAnnotations;

namespace CarsWebApp.Domain
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string RegNumber { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Model { get; set; }

        public string? Picture { get; set; }

        public DateTime YearOfManufacture { get; set; }

        [Required]
        [Range(1000, 300_000)]
        public decimal Price { get; set; }

    }
}
