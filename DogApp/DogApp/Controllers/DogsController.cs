using System;
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

        public IActionResult All(string breedFilter, string nameFilter, string sortOrder) {
            var dogs = _context.Dogs
                .Select(x => new DogAllViewModel {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age,
                    Breed = x.Breed,
                    Picture = x.Picture
                })
                .ToList();

            if (!string.IsNullOrEmpty(breedFilter) && !string.IsNullOrEmpty(nameFilter)) {
                dogs = dogs.Where(x =>
                        x.Breed.Contains(breedFilter) &&
                        x.Name.Contains(nameFilter))
                    .ToList();
            }
            else if (!string.IsNullOrEmpty(breedFilter)) {
                dogs = dogs.Where(x => x.Breed.Contains(breedFilter))
                    .ToList();
            }
            else if (!string.IsNullOrEmpty(nameFilter)) {
                dogs = dogs.Where(x => x.Name.Contains(nameFilter))
                    .ToList();
            }
            
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Breed" ? "breed_desc" : "Breed";
            
            switch (sortOrder)
            {
                case "name_desc":
                    dogs = dogs.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Breed":
                    dogs = dogs.OrderBy(s => s.Breed).ToList();
                    break;
                case "breed_desc":
                    dogs = dogs.OrderByDescending(s => s.Breed).ToList();
                    break;
                default:
                    dogs = dogs.OrderBy(s => s.Name).ToList();
                    break;
            }
            
            return View(dogs);
        }

        public IActionResult Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var item = _context.Dogs.Find(id);
            if (item == null) {
                return NotFound();
            }

            DogCreateViewModel dog = new() {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };

            return View(dog);
        }

        [HttpPost]
        public IActionResult Edit(DogCreateViewModel bindingModel) {
            if (ModelState.IsValid) {
                Dog dog = new() {
                    Id = bindingModel.Id,
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Picture = bindingModel.Picture
                };

                _context.Dogs.Update(dog);
                _context.SaveChanges();
                
                return RedirectToAction(nameof(All));
            }

            return View(bindingModel);
        }

        public IActionResult Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var item = _context.Dogs.Find(id);
            if (item == null) {
                return NotFound();
            }

            var dog = new DogCreateViewModel {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };

            return View(dog);
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            Dog item = _context.Dogs.Find(id);

            if (item == null) {
                return NotFound();
            }

            _context.Dogs.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("All", "Dogs");
        }

        public IActionResult Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            Dog item = _context.Dogs.Find(id);
            if (item == null) {
                return NotFound();
            }

            DogDetailsViewModel dog = new() {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };

            return View(dog);
        }
    }
}