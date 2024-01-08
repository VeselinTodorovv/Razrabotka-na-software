using System.ComponentModel.DataAnnotations;

namespace WebShopApp.Models.Clients
{
    public class ClientDeleteVm
    {
        public string Id { get; set; } = null!;

        [Display(Name = "User Name")]
        public string UserName { get; set; } = null!;

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
