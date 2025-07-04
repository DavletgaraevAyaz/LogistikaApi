using Microsoft.AspNetCore.Mvc;
using LogistikaApi.Interface;
using System.Threading.Tasks;

namespace LogistikaApi.Controllers
{
    [ApiController]
    [Route("dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;
        public DashboardController(IDashboardService service) => _service = service;

        [HttpGet("overview")]
        public async Task<IActionResult> Overview() => await _service.GetOverviewAsync();

        [HttpGet("alerts")]
        public async Task<IActionResult> Alerts() => await _service.GetAlertsAsync();

        [HttpGet("stats")]
        public async Task<IActionResult> Stats() => await _service.GetStatisticsAsync();
    }
}
