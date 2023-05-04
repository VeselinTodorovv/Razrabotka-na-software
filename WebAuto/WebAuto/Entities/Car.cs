using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Hosting;

namespace WebAuto.Entities
{
    public class Car
    {
        public Car() {
            Purchases = new HashSet<Purchase>();
        }
        
        public int Id { get; set; }
        
        [Required,
        StringLength(10)]
        public string RegNumber { get; set; }
        
        [Required]
        public string Brand { get; set; }
        
        public string Picture { get; set; }
        
        [Required,
        StringLength(30)]
        public string Country { get; set; }
        
        public int Year { get; set; }
        
        public decimal Price { get; set; }
        
        public ICollection<Purchase> Purchases { get; set; }
    }
}