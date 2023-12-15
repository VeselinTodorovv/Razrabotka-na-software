using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using WebShopApp.Infrastructure.Data.Domain;
using WebShopApp.Models.Brands;
using WebShopApp.Models.Categories;

namespace WebShopApp.Models.Products
{
    public class ProductEditVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string ProductName { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        public virtual List<BrandPairVM> Brands { get; set; } = new List<BrandPairVM>();

        [Required]
        public int CategoryId { get; set; }

        public virtual List<CategoryPairVM> Categories { get; set; } = new List<CategoryPairVM>();

        public string Picture { get; set; } = null!;

        [Range(0, 5000)]
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
