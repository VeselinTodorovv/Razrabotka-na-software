using CarsWebApp.Core.Contracts;
using CarsWebApp.Domain;
using CarsWebApp.Models;

using Microsoft.AspNetCore.Mvc;

namespace CarsWebApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _service;

        public CarsController(ICarService service)
        {
            _service = service;
        }

        // GET: CarsController
        public ActionResult Index(string searchStringModel, decimal minPrice, decimal maxPrice, string sortOrder)
        {
            var cars = _service.GetCars(searchStringModel, minPrice, maxPrice)
                .Select(car => new CarsAllViewModel
                {
                    Id = car.Id,
                    RegNumber = car.RegNumber,
                    Model = car.Model,
                    Manufacturer = car.Manufacturer,
                    Picture = car.Picture,
                    YearOfManufacture = car.YearOfManufacture,
                    Price = car.Price
                });

            ViewData["PriceSortParm"] = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            cars = sortOrder switch
            {
                "price_desc" => cars.OrderByDescending(c => c.Price).ToList(),
                _ => cars.OrderBy(c => c.Price).ToList(),
            };

            return View(cars);
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            var car = _service.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            CarDetailsViewModel viewModel = new()
            {
                Id = id,
                RegNumber = car.RegNumber,
                Model = car.Model,
                Manufacturer = car.Manufacturer,
                Picture = car.Picture,
                YearOfManufacture = car.YearOfManufacture,
                Price = car.Price
            };

            return View(viewModel);
        }

        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var created = _service.Create(viewModel.RegNumber, viewModel.Manufacturer, viewModel.Model, viewModel.Picture, viewModel.YearOfManufacture, viewModel.Price);
                if (created)
                {
                    return RedirectToAction("Success");
                }
            }

            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        // GET: CarsController/Edit/5
        public ActionResult Edit(int id)
        {
            Car car = _service.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            CarCreateViewModel viewModel = new()
            {
                Id = id,
                RegNumber = car.RegNumber,
                Model = car.Model,
                Manufacturer = car.Manufacturer,
                Picture = car.Picture,
                YearOfManufacture = car.YearOfManufacture,
                Price = car.Price
            };

            return View(viewModel);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CarCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _service.Update(id, viewModel.RegNumber, viewModel.Manufacturer, viewModel.Model, viewModel.Picture, viewModel.YearOfManufacture, viewModel.Price);
                if (updated)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(viewModel);
        }

        // GET: CarsController/Delete/5
        public ActionResult Delete(int id)
        {
            Car car = _service.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            CarCreateViewModel viewModel = new()
            {
                Id = id,
                RegNumber = car.RegNumber,
                Model = car.Model,
                Manufacturer = car.Manufacturer,
                Picture = car.Picture,
                YearOfManufacture = car.YearOfManufacture,
                Price = car.Price
            };

            return View(viewModel);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _service.RemoveById(id);

            if (deleted)
            {
                return RedirectToAction("Index", "Cars");
            }

            return View();
        }
    }
}
