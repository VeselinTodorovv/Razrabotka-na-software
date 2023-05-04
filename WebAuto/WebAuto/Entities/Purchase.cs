using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAuto.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }
        
        [Required]
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DatePurchase { get; set; }
    }
}