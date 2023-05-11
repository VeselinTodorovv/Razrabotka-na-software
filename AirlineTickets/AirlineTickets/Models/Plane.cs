using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirlineTickets.Models
{
    public class Plane
    {
        public int Id { get; set; }
        
        [Required]
        public int PlaneNumber { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Model { get; set; }
        
        [Required]
        public string Image { get; set; }
        
        public double Baggage { get; set; }
        
        [Required]
        public bool BarOnBoard { get; set; }
        
        public int Seats { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}