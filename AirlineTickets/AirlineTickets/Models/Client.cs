using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirlineTickets.Models
{
    public class Client
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Phone]
        public string Phone { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Address { get; set; }
        
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}