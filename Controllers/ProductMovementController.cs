using Microsoft.AspNetCore.Mvc;
using LogistikaApi.Interface;
using LogistikaApi.Model;
using System.Threading.Tasks;

namespace LogistikaApi.Controllers
{
    [ApiController]
    [Route("productmovement")]
    public class ProductMovementController : ControllerBase
    {
        private readonly IProductMovementService _service;
        public ProductMovementController(IProductMovementService service) => _service = service;

        [HttpGet("get")]
        public async Task<IActionResult> Get() => await _service.GetAllAsync();

        [HttpGet("get/product/{productId}")]
        public async Task<IActionResult> GetByProduct(int productId) => await _service.GetByProductIdAsync(productId);

        [HttpGet("get/type/{typeId}")]
        public async Task<IActionResult> GetByType(int typeId) => await _service.GetByMovementTypeIdAsync(typeId);

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProductMovement movement) => await _service.CreateAsync(movement);
    }
}
