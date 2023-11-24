using DogsApp.Core.Contracts;
using DogsApp.Infrastructure.Data;
using DogsApp.Infrastructure.Data.Domain;
using DogsApp.Models;

using Microsoft.AspNetCore.Mvc;

namespace DogsApp.Controllers
{
    public class DogsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IDogService _dogService;
        private readonly IBreedService _breedService;

        public DogsController(ApplicationDbContext context, IDogService dogService, IBreedService breedService)
        {
            _context = context;
            _dogService = dogService;
            _breedService = breedService;
        }

        // GET: DogsController
        public ActionResult Index(string searchStringBreed, string searchStringName)
        {
            List<DogAllViewModel> all = _dogService.GetDogs(searchStringBreed, searchStringName)
                .Select(dog => new DogAllViewModel
                {
                    Id = dog.Id,
                    Name = dog.Name,
                    Age = dog.Age,
                    BreedName = dog.Breed.Name,
                    Picture = dog.Picture
                })
                .ToList();

            return View(all);
        }

        // GET: DogsController/Details/5
        public ActionResult Details(int id)
        {
            Dog item = _dogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }

            DogDetailsViewModel viewModel = new()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                BreedName = item.Breed.Name,
                Picture = item.Picture
            };

            return View(viewModel);
        }

        // GET: DogsController/Create
        public ActionResult Create()
        {
            var dog = new DogCreateViewModel
            {
                Breeds = _breedService.GetBreeds()
                .Select(c => new BreedPairViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToList()
            };

            return View(dog);
        }

        // POST: DogsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] DogCreateViewModel dog)
        {
            if (ModelState.IsValid)
            {
                var createdId = _dogService.Create(dog.Name, dog.Age, dog.BreedId, dog.Picture);
                if (createdId)
                {
                    return RedirectToAction(nameof(Index));
                }
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
            Dog item = _dogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }

            DogEditViewModel dog = new()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                BreedId = item.BreedId,
                Picture = item.Picture,

                Breeds = _breedService.GetBreeds()
                .Select(c => new BreedPairViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToList()
            };

            return View(dog);
        }

        // POST: DogsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DogEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _dogService.Update(id, viewModel.Name, viewModel.Age, viewModel.BreedId, viewModel.Picture);
                if (updated)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(viewModel);
        }

        // GET: DogsController/Delete/5
        public ActionResult Delete(int id)
        {
            Dog item = _dogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }

            DogDetailsViewModel viewModel = new()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                BreedName = item.Breed.Name,
                Picture = item.Picture
            };

            return View(viewModel);
        }

        // POST: DogsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _dogService.RemoveById(id);

            if (deleted)
            {
                return RedirectToAction("Index", "Dogs");
            }

            return View();
        }
    }
}
