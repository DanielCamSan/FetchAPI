using Microsoft.AspNetCore.Mvc;
using Practicando_WEBAPI.Models;
using Practicando_WEBAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Practicando_WEBAPI.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Practicando_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    public class BreedsController : ControllerBase
    {
        private IBreedsService _breedService;
        public BreedsController(IBreedsService breedService)
        {
            _breedService = breedService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<BreedModel>> GetBreeds()
        {
            try
            {
                return Ok(_breedService.GetBreeds());
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }

        }
        [HttpGet("{breedId:int}", Name="GetBreed")]
        public ActionResult<BreedModel> GetBreed(int breedId)
        {
            try
            {
                return Ok(_breedService.GetBreed(breedId));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpPost]
        public ActionResult<BreedModel> CreateBreed([FromBody] BreedModel breedModel)
        {
            try
            {
               
                var url = HttpContext.Request.Host;
                var createdBreed = _breedService.CreateBreed(breedModel);
                return CreatedAtRoute("GetBreed",new { breedId=createdBreed.Id},createdBreed);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
       
       [HttpDelete("{breedId:int}")]
       public ActionResult<bool> DeleteBreed(int breedId)
        {
            try
            {
                return Ok(_breedService.DeleteBreed(breedId));
            }
            catch (NotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpPut("{breedId:int}")]
        public ActionResult<BreedModel> UpdateBreed(int breedId, [FromBody] BreedModel breedModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var pair in ModelState)
                    {
                        if (pair.Key == nameof(breedModel.TypesofUnity) && pair.Value.Errors.Count > 0)
                        {
                            return BadRequest(pair.Value.Errors);
                        }
                    }
                }
                return _breedService.UpdateBreed(breedId, breedModel);
            }

            catch (NotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
       
    }
}
