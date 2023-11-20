using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DogsApp.Infrastructure.Data.Domain;

namespace DogsApp.Core.Contracts
{
    public interface IBreedService
    {
        List<Breed> GetBreeds();
        Breed GetBreedById(int id);
        List<Dog> GetDogsByBreed(int breedId);
    }
}
