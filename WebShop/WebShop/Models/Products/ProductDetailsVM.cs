using System.ComponentModel.DataAnnotations;

namespace WebShopApp.Models.Products
{
    public class ProductDetailsVm
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public int BrandId { get; set; }

        [Display(Name = "Brand")]
        public string BrandName { get; set; } = null!;

        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; } = null!;

        public string Picture { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }
    }
}
