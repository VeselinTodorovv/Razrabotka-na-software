using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineTickets.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        
        [ForeignKey("Flight")]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        
        [Required]
        public DateTime TicketReservation { get; set; }
        
        public int TicketsCount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice {
            get => TotalPrice;
            set =>
                this.TotalPrice = this.TicketsCount * this.Flight.TicketPrice -
                                  this.TicketsCount * Flight.TicketPrice * this.Flight.Discount / 100;
        }
    }
}