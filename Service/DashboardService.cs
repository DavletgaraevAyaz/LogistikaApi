using LogistikaApi.DBContext;
using LogistikaApi.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogistikaApi.Service
{
    public class DashboardService : IDashboardService
    {
        private readonly ContextDB _context;
        public DashboardService(ContextDB context) => _context = context;

        public async Task<IActionResult> GetOverviewAsync()
        {
            var totalProducts = await _context.Product.CountAsync();
            var totalDeliveries = await _context.Delivery.CountAsync();
            var totalVehicles = await _context.Vehicle.CountAsync();

            return new OkObjectResult(new
            {
                overview = new
                {
                    totalProducts,
                    totalDeliveries,
                    totalVehicles
                }
            });
        }

        public async Task<IActionResult> GetAlertsAsync()
        {
            var lowStock = await _context.Product
                .Where(p => p.Quantity < 10)
                .Select(p => $"{p.Name} - Low stock: {p.Quantity}")
                .ToListAsync();

            var expired = await _context.Product
                .Select(p => $"{p.Name} - Expired: {p.ExpirationDate:d}")
                .ToListAsync();

            return new OkObjectResult(new { alerts = lowStock.Concat(expired) });
        }

        public async Task<IActionResult> GetStatisticsAsync()
        {
            var products = await _context.Product.CountAsync();
            var warehouses = await _context.Warehouse.CountAsync();
            var users = await _context.User.CountAsync();

            return new OkObjectResult(new
            {
                statistics = new
                {
                    products,
                    warehouses,
                    users
                }
            });
        }
    }

}
