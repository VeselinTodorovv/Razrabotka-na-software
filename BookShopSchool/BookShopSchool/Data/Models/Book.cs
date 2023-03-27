using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookShopSchool.Data.Models.Enum;

namespace BookShopSchool.Data.Models
{
    public class Book
    {
        public Book() {
            AuthorsBooks = new HashSet<AuthorBook>();
        }

        public int Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }
        
        [Required]
        public Genre Genre { get; set; }
        
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }
        
        [Range(50, 5000)]
        public int Pages { get; set; }
        
        public DateTime PublishedOn { get; set; }
        
        public ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}