using Practicando_WEBAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicando_WEBAPI.Data.Repository
{
    public interface ILibraryRepository
    {
        public IEnumerable<BreedEntity> GetBreeds();
        public BreedEntity GetBreed(int BreedId);
        public BreedEntity CreateBreed(BreedEntity breedEntity);
        public bool DeleteBreed(int BreedId);
        public BreedEntity UpdateBreed(BreedEntity breedEntity);
    }
}
