using LogistikaApi.DBContext;
using LogistikaApi.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogistikaApi.Model;

namespace LogistikaApi.Service
{
    public class ReportService : IReportService
    {
        private readonly ContextDB _context;
        public ReportService(ContextDB context) => _context = context;

        public async Task<IActionResult> GetStockReportAsync()
        {
            var report = await _context.Product
                .Select(p => new { p.Name, p.Quantity, p.ExpirationDate })
                .ToListAsync();

            return new OkObjectResult(new { stockReport = report });
        }

        public async Task<IActionResult> GetMovementsReportAsync()
        {
            var movements = await _context.ProductMovements
                .Include(x => x.Product)
                .Include(x => x.MovementType)
                .ToListAsync();

            return new OkObjectResult(new { movementReport = movements });
        }

        public async Task<IActionResult> GetReturnsReportAsync()
        {
            var returns = await _context.ProductMovements
                .Where(x => x.MovementType.type == "Return")
                .Include(x => x.Product)
                .ToListAsync();

            return new OkObjectResult(new { returns });
        }

        public async Task<IActionResult> GetEfficiencyReportAsync()
        {
            var efficiency = await _context.Delivery
                .Select(d => new { d.Id, d.RouteId, d.IsDelivered, d.ScheduledDate })
                .ToListAsync();

            return new OkObjectResult(new { efficiency });
        }
    }

}
