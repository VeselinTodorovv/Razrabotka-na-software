using System;
using System.ComponentModel.DataAnnotations;

namespace ASPEventures.Models
{
    public class EventCreateBindingModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Place { get; set; }
        
        [Required]
        public DateTime Start { get; set; }
        
        [Required]
        public DateTime End { get; set; }
        
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Total Tickets must be a positive number.")]
        public int TotalTickets { get; set; }
        
        [Required]
        [Range(0.00, double.MaxValue, ErrorMessage = "Ticket Price must be a positive number.")]
        public decimal TicketPrice { get; set; }
    }
}