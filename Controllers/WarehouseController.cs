using Microsoft.AspNetCore.Mvc;
using LogistikaApi.Interface;
using LogistikaApi.Model;
using System.Threading.Tasks;

namespace LogistikaApi.Controllers
{
    [ApiController]
    [Route("warehouse")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _service;
        public WarehouseController(IWarehouseService service) => _service = service;

        [HttpGet("get")]
        public async Task<IActionResult> Get() => await _service.GetAllAsync();

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Warehouse warehouse) => await _service.CreateAsync(warehouse);

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Warehouse warehouse) => await _service.UpdateAsync(id, warehouse);

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id) => await _service.DeleteAsync(id);
    }
}
