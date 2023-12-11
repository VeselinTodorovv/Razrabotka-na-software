using System.ComponentModel.DataAnnotations;

namespace WebShopApp.Infrastructure.Data.Domain
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string CategoryName { get; set; } = null!;

        public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
