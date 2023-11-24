using System.ComponentModel.DataAnnotations;

namespace DogsApp.Infrastructure.Data.Domain
{
    public class Breed
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        public virtual IEnumerable<Dog> Dogs { get; set; } = null!;
    }
}
