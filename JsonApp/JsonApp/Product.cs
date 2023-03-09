using System;

namespace JsonApp
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime Expiry { get; set; }

        public Product(int id, string name, decimal price, int stock, DateTime expiry) {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
            Expiry = expiry;
        }
    }
}