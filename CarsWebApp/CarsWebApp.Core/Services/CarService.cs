using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarsWebApp.Core.Contracts;
using CarsWebApp.Data;
using CarsWebApp.Domain;

namespace CarsWebApp.Core.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;

        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string RegNumber, string Manufacturer, string Model, string Picture, DateTime YearOfManufacture, decimal Price)
        {
            Car car = new Car()
            {
                RegNumber = RegNumber,
                Manufacturer = Manufacturer,
                Model = Model,
                Picture = Picture,
                YearOfManufacture = YearOfManufacture,
                Price = Price
            };

            _context.Cars.Add(car);
            return _context.SaveChanges() != 0;
        }

        public Car GetCarById(int carId)
        {
            return _context.Cars.Find(carId);
        }

        public List<Car> GetCars()
        {
            return _context.Cars.ToList();
        }

        public List<Car> GetCars(string searchStringModel, decimal minPrice, decimal maxPrice)
        {
            List<Car> cars = _context.Cars.ToList();

            if (!string.IsNullOrEmpty(searchStringModel) && minPrice != default && maxPrice != default)
            {
                cars = cars.Where(c => c.Model.Contains(searchStringModel) && c.Price >= minPrice && c.Price <= maxPrice).ToList();
            }
            //fix
            else if (minPrice != default)
            {
                cars = cars.Where(c => c.Price >= minPrice).ToList();
            }
            else if (maxPrice != default)
            {
                cars = cars.Where(c => c.Price <= maxPrice).ToList();
            }
            else if (!string.IsNullOrEmpty(searchStringModel))
            {
                cars = cars.Where(c => c.Model.Contains(searchStringModel)).ToList();
            }

            return cars;
        }

        public bool RemoveById(int carId)
        {
            Car car = _context.Cars.Find(carId);
            if (car == default(Car))
            {
                return false;
            }

            _context.Cars.Remove(car);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int carId, string RegNumber, string Manufacturer, string Model, string Picture, DateTime YearOfManufacture, decimal Price)
        {
            Car car = new()
            {
                Id = carId,
                RegNumber = RegNumber,
                Manufacturer = Manufacturer,
                Model = Model,
                Picture = Picture,
                YearOfManufacture = YearOfManufacture,
                Price = Price
            };

            _context.Cars.Update(car);
            return _context.SaveChanges() != 0;
        }
    }
}
