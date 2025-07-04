using Microsoft.AspNetCore.Mvc;
using LogistikaApi.Interface;
using LogistikaApi.Model;
using System.Threading.Tasks;
using LogistikaApi.Request;

namespace LogistikaApi.Controllers
{
    [ApiController]
    [Route("vehicle")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _service;
        public VehicleController(IVehicleService service) => _service = service;

        [HttpGet("get")]
        public async Task<IActionResult> Get() => await _service.GetAllAsync();

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] VehReq vehicle) => await _service.CreateAsync(vehicle);

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Vehicle vehicle) => await _service.UpdateAsync(id, vehicle);

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id) => await _service.DeleteAsync(id);
    }
}
