using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebAuto.Entities
{
    public class Client
    {
        public Client() {
            Purchases = new HashSet<Purchase>();
        }
        
        public int Id { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }
        
        [Required]
        [MaxLength(10), MinLength(10)]
        public string EGN { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Address { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(10)]
        [Phone]
        public string Phone { get; set; }
        
        public ICollection<Purchase> Purchases { get; set; }
    }
}