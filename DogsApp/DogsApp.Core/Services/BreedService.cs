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
    public class BreedService : IBreedService
    {
        private readonly ApplicationDbContext _context;

        public BreedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Breed GetBreedById(int id)
        {
            return _context.Breeds.Find(id);
        }

        public List<Breed> GetBreeds()
        {
            return _context.Breeds.ToList();
        }

        public List<Dog> GetDogsByBreed(int breedId)
        {
            return _context.Dogs.Where(x => x.BreedId == breedId).ToList();
        }
    }
}
