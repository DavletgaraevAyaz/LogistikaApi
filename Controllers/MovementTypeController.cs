using Microsoft.AspNetCore.Mvc;
using LogistikaApi.Interface;
using System.Threading.Tasks;

namespace LogistikaApi.Controllers
{
    [ApiController]
    [Route("movementtype")]
    public class MovementTypeController : ControllerBase
    {
        private readonly IMovementTypeService _service;
        public MovementTypeController(IMovementTypeService service) => _service = service;

        [HttpGet("get")]
        public async Task<IActionResult> Get() => await _service.GetAllAsync();
    }
}
