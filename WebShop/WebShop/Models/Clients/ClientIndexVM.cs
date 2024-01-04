﻿using System.ComponentModel.DataAnnotations;

namespace WebShopApp.Models.Clients
{
    public class ClientIndexVM
    {
        public string Id { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }
        
        public string Email { get; set; }
        
        public bool isAdmin { get; set; }
    }
}
