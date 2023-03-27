using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopSchool.Data.Models
{
    public class Author
    {
        public Author() {
            AuthorsBooks = new HashSet<AuthorBook>();
        }

        public int Id { get; set; }
        
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string LastName { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}