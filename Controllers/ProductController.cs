using Microsoft.AspNetCore.Mvc;
using LogistikaApi.Interface;
using LogistikaApi.Model;
using System.Threading.Tasks;
using LogistikaApi.Request;

namespace LogistikaApi.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service) => _service = service;

        [HttpGet("get")]
        public async Task<IActionResult> Get() => await _service.GetAllAsync();

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id) => await _service.GetByIdAsync(id);

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProdReq product) => await _service.CreateAsync(product);

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProdReq product) => await _service.UpdateAsync(id, product);

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id) => await _service.DeleteAsync(id);
    }
}
