using Microsoft.AspNetCore.Mvc;
using LogistikaApi.Interface;
using LogistikaApi.Model;
using System.Threading.Tasks;

namespace LogistikaApi.Controllers
{
    [ApiController]
    [Route("route")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _service;
        public RouteController(IRouteService service) => _service = service;

        [HttpGet("get")]
        public async Task<IActionResult> Get() => await _service.GetAllAsync();

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Model.Route route) => await _service.CreateAsync(route);

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Model.Route route) => await _service.UpdateAsync(id, route);

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id) => await _service.DeleteAsync(id);
    }
}
