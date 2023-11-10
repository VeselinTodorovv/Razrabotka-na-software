using DogsApp.Infrastructure.Data;
using DogsApp.Infrastructure.Data.Domain;
using DogsApp.Models;

using Microsoft.AspNetCore.Mvc;

namespace DogsApp.Controllers
{
    public class DogsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public DogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DogsController
        public ActionResult Index(string searchStringBreed, string searchStringName)
        {
            List<DogAllViewModel> all = _context.Dogs
                .Select(dog => new DogAllViewModel
                {
                    Id = dog.Id,
                    Name = dog.Name,
                    Age = dog.Age,
                    Breed = dog.Breed,
                    Picture = dog.Picture
                })
                .ToList();

            if (!string.IsNullOrEmpty(searchStringName) && !string.IsNullOrEmpty(searchStringBreed))
            {
                all = all.Where(d => d.Breed.Contains(searchStringBreed) && d.Name.Contains(searchStringName)).ToList();
            }
            else if (!string.IsNullOrEmpty(searchStringBreed))
            {
                all = all.Where(d => d.Breed.Contains(searchStringBreed)).ToList();
            }
            else if (!string.IsNullOrEmpty(searchStringName))
            {
                all = all.Where(d => d.Name.Contains(searchStringName)).ToList();
            }

            return View(all);
        }

        // GET: DogsController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog? dog = _context.Dogs.FirstOrDefault(dog => dog.Id == id);
            if (dog == null)
            {
                return NotFound();
            }

            DogDetailsViewModel viewModel = new()
            {
                Id = dog.Id,
                Name = dog.Name,
                Age = dog.Age,
                Breed = dog.Breed,
            };

            return View(viewModel);
        }

        // GET: DogsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DogCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Dog dog = new()
                {
                    Name = viewModel.Name,
                    Age = viewModel.Age,
                    Breed = viewModel.Breed,
                    Id = viewModel.Id,
                    Picture = viewModel.Picture
                };

                _context.Dogs.Add(dog);
                _context.SaveChanges();

                return this.RedirectToAction("Success");
            }

            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        // GET: DogsController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog? item = _context.Dogs.FirstOrDefault(dog => dog.Id == id);
            if(item == null)
            {
                return NotFound();
            }

            DogEditViewModel viewModel = new()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };

            return View(viewModel);
        }

        // POST: DogsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DogEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Dog dog = new()
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Age = viewModel.Age,
                    Breed = viewModel.Breed,
                    Picture = viewModel.Picture
                };

                _context.Dogs.Update(dog);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: DogsController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog? item = _context.Dogs.FirstOrDefault(d => d.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            DogEditViewModel viewModel = new()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };

            return View(viewModel);
        }

        // POST: DogsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Dog? item = _context.Dogs.FirstOrDefault(d => d.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Dogs.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index", "Dogs");
        }
    }
}
