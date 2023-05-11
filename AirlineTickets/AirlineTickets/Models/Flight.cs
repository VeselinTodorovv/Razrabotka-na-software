using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineTickets.Models
{
    public class Flight
    {
        public int Id { get; set; }
        
        [Required]
        public int FlightNumber { get; set; }
        
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string StartDestination { get; set; }
        
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string EndDestination { get; set; }
        
        [Required]
        public DateTime TakeOff { get; set; }
        
        [Required]
        public DateTime Arrival { get; set; }
        
        [ForeignKey("Plane")]
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TicketPrice { get; set; }
        
        [Range(0, 100)]
        public int Discount { get; set; }
        
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}