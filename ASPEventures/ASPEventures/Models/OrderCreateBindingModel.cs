using System.ComponentModel.DataAnnotations;

namespace ASPEventures.Models
{
    public class OrderCreateBindingModel
    {
        [Required]
        public string EventId { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Tickets")]
        public int TicketsCount { get; set; }
    }
}