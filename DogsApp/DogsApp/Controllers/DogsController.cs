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
        public ActionResult Index()
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

            return View(all);
        }

        // GET: DogsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DogsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DogsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DogsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
