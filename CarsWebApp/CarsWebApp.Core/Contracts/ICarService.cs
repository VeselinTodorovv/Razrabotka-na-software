using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarsWebApp.Domain;

namespace CarsWebApp.Core.Contracts
{
    public interface ICarService
    {
        bool Create(string RegNumber, string Manufacturer, string Model, string Picture, DateTime YearOfManufacture, decimal Price);
        bool Update(int carId, string RegNumber, string Manufacturer, string Model, string Picture, DateTime YearOfManufacture, decimal Price);
        List<Car> GetCars();
        Car GetCarById(int carId);
        bool RemoveById(int carId);
        List<Car> GetCars(string searchStringModel, decimal minPrice, decimal maxPrice);
    }
}
