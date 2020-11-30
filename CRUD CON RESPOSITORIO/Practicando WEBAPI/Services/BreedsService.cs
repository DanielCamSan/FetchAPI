using AutoMapper;
using Practicando_WEBAPI.Data.Entities;
using Practicando_WEBAPI.Data.Repository;
using Practicando_WEBAPI.Exceptions;
using Practicando_WEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicando_WEBAPI.Services
{
    public class BreedsService : IBreedsService
    {
        private ILibraryRepository _libraryRepository;
        private IMapper _mapper;

        public BreedsService(ILibraryRepository libraryRepository, IMapper _mapper)
        {
            this._libraryRepository = libraryRepository;
            this._mapper = _mapper;
        }

        public IEnumerable<BreedModel> GetBreeds()
        {
            var entityList= _libraryRepository.GetBreeds();
            var modelList = _mapper.Map<IEnumerable<BreedModel>>(entityList);
            return modelList;
        }
        public BreedModel GetBreed(int breedId)
        {
            var breed = _libraryRepository.GetBreed(breedId);

            if (breed == null)
            {
                throw new NotFoundException($"The breed {breedId} doesnt exists, try it with a new id");
            }

            return _mapper.Map<BreedModel>(breed);
        }
      
        public BreedModel CreateBreed(BreedModel breedModel)
        {

            var entityreturned=_libraryRepository.CreateBreed(_mapper.Map<BreedEntity>(breedModel));
            
            return _mapper.Map<BreedModel>(entityreturned);
        }

        public bool DeleteBreed(int breedId)
        {
            var breedToDelete = GetBreed(breedId);
            return _libraryRepository.DeleteBreed(breedId);
        }

        public BreedModel UpdateBreed(int BreedId, BreedModel breedModel)
        {
            
            var breedToUpdate=_libraryRepository.UpdateBreed(_mapper.Map<BreedEntity>(breedModel));

            return _mapper.Map<BreedModel>(breedToUpdate);
        }
    }
}
