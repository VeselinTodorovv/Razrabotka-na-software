﻿using System.ComponentModel.DataAnnotations;

namespace DogApp.Models
{
    public class DogDetailsViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Display(Name = "Age")]
        public int Age { get; set; }
        
        [Display(Name = "Breed")]
        public string Breed { get; set; }
        
        [Display(Name = "Dog Picture")]
        public string Picture { get; set; }
    }
}