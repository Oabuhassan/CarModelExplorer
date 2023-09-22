using CarModelExplorer.Core.Dtos;
using CarModelExplorer.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarModelExplorer.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class vehiclesController : ControllerBase
    {
        private readonly ICarMake carMake;

        public vehiclesController(ICarMake carMake)
        {
            this.carMake = carMake;
        }

        [HttpGet]
        [Route("models")]
        public async Task<ActionResult<CarMakeReadDto>> GetModelsForMakeIdYear([FromQuery] int modelyear, [FromQuery] string make)
        {
            var vehicles = await carMake.GetModels(modelyear, make);

            return Ok(vehicles);
        }
    }
}
