using System.ComponentModel.DataAnnotations;

namespace DogsApp.Models
{
    public class DogAllViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        [Display(Name = "Dog Picture")]
        public string? Picture { get; set; }
    }
}
