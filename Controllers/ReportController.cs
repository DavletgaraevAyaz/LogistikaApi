using Microsoft.AspNetCore.Mvc;
using LogistikaApi.Interface;
using System.Threading.Tasks;

namespace LogistikaApi.Controllers
{
    [ApiController]
    [Route("report")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;
        public ReportController(IReportService service) => _service = service;

        [HttpGet("stock")]
        public async Task<IActionResult> Stock() => await _service.GetStockReportAsync();

        [HttpGet("movement")]
        public async Task<IActionResult> Movement() => await _service.GetMovementsReportAsync();

        [HttpGet("returns")]
        public async Task<IActionResult> Returns() => await _service.GetReturnsReportAsync();

        [HttpGet("efficiency")]
        public async Task<IActionResult> Efficiency() => await _service.GetEfficiencyReportAsync();
    }
}
