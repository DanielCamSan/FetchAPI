using Practicando_WEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicando_WEBAPI.Services
{
    public interface IBreedsService
    {
        public IEnumerable<BreedModel> GetBreeds();
        public BreedModel GetBreed(int BreedId);
        public BreedModel CreateBreed(BreedModel breedModel);
        public bool DeleteBreed(int BreedId);
        public BreedModel UpdateBreed(int BreedId, BreedModel breedModel);
    }
}
