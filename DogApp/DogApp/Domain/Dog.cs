using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogApp.Domain
{
    public class Dog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        
        [Required]
        [Range(1, 30)]
        public int Age { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Breed { get; set; }
        
        public string Picture { get; set; }
    }
}