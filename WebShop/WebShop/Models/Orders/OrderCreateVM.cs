using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using WebShopApp.Infrastructure.Data.Domain;

namespace WebShopApp.Models.Orders
{
    public class OrderCreateVM
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int QuantityInStock { get; set; }

        public string? Picture { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}