using Microsoft.AspNetCore.Mvc;
using LogistikaApi.Interface;
using LogistikaApi.Model;
using System.Threading.Tasks;

namespace LogistikaApi.Controllers
{
    [ApiController]
    [Route("delivery")]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _service;
        public DeliveryController(IDeliveryService service) => _service = service;

        [HttpGet("get")]
        public async Task<IActionResult> Get() => await _service.GetAllAsync();

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Delivery delivery) => await _service.CreateAsync(delivery);

        [HttpPut("updatestatus/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] bool delivered) => await _service.UpdateStatusAsync(id, delivered);
    }
}
