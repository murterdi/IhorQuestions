using AnimalManagementAPI.Model;
using AnimalManagementAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AnimalManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("FarmManagementUI")] //for Cors
    public class AnimalsController : Controller
    {
        private readonly AnimalService _animalService;

        public AnimalsController(AnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            try
            {
                var animals = _animalService.GetAllAnimals();
                return Ok(animals);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);

            }
        }

        [HttpPost]
        public IActionResult AddAnimal([FromBody] Animal animal)
        {
            try
            {
                if (_animalService.GetAllAnimals().Exists(a => a.Name == animal.Name))
                {
                    return Conflict("An animal with the same name already exists.");
                }

                _animalService.AddAnimal(animal);
                return CreatedAtAction(nameof(GetAnimals), animal);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);

            }
        }

        [HttpDelete("{name}")]
        public IActionResult RemoveAnimal(string name)
        {
            try
            {
                var result = _animalService.DeleteAnimal(name);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);

            }
        }
    }
}
