using System.ComponentModel.DataAnnotations;

using WebShopApp.Infrastructure.Data.Domain;
using WebShopApp.Models.Brands;
using WebShopApp.Models.Categories;

namespace WebShopApp.Models.Products
{
    public class ProductIndexVm
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
