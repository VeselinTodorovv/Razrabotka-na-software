using System.Collections.Generic;
using System.Linq;
using DogApp.Data;
using DogApp.Domain;
using DogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogApp.Controllers
{
    public class DogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DogsController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var dogFormDb = new Dog
                {
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Picture = bindingModel.Picture
                };

                _context.Dogs.Add(dogFormDb);
                _context.SaveChanges();

                return RedirectToAction("Success");
            }

            return View();
        }

        public IActionResult Success() {
            return View();
        }

        public IActionResult All() {
            List<DogAllViewModel> dogs = _context.Dogs
                .Select(x => new DogAllViewModel {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age,
                    Breed = x.Breed,
                    Picture = x.Picture
                }).ToList();

            return View(dogs);
        }
    }
}