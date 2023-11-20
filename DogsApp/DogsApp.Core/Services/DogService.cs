using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DogsApp.Core.Contracts;
using DogsApp.Infrastructure.Data;
using DogsApp.Infrastructure.Data.Domain;

namespace DogsApp.Core.Services
{
    public class DogService : IDogService
    {
        private readonly ApplicationDbContext _context;

        public DogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string name, int age, int breedId, string picture)
        {
            Dog item = new Dog()
            {
                Name = name,
                Age = age,
                Breed = _context.Breeds.Find(breedId),
                Picture = picture
            };

            _context.Dogs.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Dog GetDogById(int dogId)
        {
            return _context.Dogs.FirstOrDefault(d => d.Id == dogId);
        }

        public List<Dog> GetDogs()
        {
            List<Dog> dogs = _context.Dogs.ToList();
            return dogs;
        }

        public List<Dog> GetDogs(string searchStringBreed, string searchStringName)
        {
            List<Dog> dogs = _context.Dogs.ToList();

            if (!string.IsNullOrEmpty(searchStringName) && !string.IsNullOrEmpty(searchStringBreed))
            {
                dogs = dogs.Where(d => d.Breed.Name.Contains(searchStringBreed) && d.Name.Contains(searchStringName)).ToList();
            }
            else if (!string.IsNullOrEmpty(searchStringBreed))
            {
                dogs = dogs.Where(d => d.Breed.Name.Contains(searchStringBreed)).ToList();
            }
            else if (!string.IsNullOrEmpty(searchStringName))
            {
                dogs = dogs.Where(d => d.Name.Contains(searchStringName)).ToList();
            }

            return dogs;
        }

        public bool RemoveById(int dogId)
        {
            Dog dog = GetDogById(dogId);
            if (dog == default(Dog))
            {
                return false;
            }

            _context.Dogs.Remove(dog);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int dogId, string name, int age, int breedId, string? picture)
        {
            Dog dog = new()
            {
                Id = dogId,
                Name = name,
                Age = age,
                Breed = _context.Breeds.Find(breedId),
                Picture = picture
            };

            _context.Dogs.Update(dog);
            return _context.SaveChanges() != 0;
        }
    }
}
