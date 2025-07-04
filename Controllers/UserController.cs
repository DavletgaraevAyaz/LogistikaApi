using Microsoft.AspNetCore.Mvc;
using LogistikaApi.Interface;
using LogistikaApi.Model;
using System.Threading.Tasks;
using LogistikaApi.Request;

namespace LogistikaApi.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service) => _service = service;

        [HttpGet("get")]
        public async Task<IActionResult> Get() => await _service.GetAllAsync();

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegReq user) => await _service.RegisterAsync(user);

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogReq user) => await _service.LoginAsync(user.Username, user.Password);

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id) => await _service.DeleteAsync(id);
    }
}
