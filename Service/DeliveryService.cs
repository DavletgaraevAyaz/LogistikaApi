using LogistikaApi.DBContext;
using LogistikaApi.Interface;
using LogistikaApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogistikaApi.Service
{
    public class DeliveryService : IDeliveryService
    {
        private readonly ContextDB _context;
        public DeliveryService(ContextDB context) => _context = context;

        public async Task<IActionResult> GetAllAsync()
        {
            var deliveries = await _context.Delivery.Include(x => x.Route).ToListAsync();
            return new OkObjectResult(new { deliveries });
        }

        public async Task<IActionResult> CreateAsync(Delivery delivery)
        {
            _context.Delivery.Add(delivery);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Delivery created", delivery });
        }

        public async Task<IActionResult> UpdateStatusAsync(int id, bool isDelivered)
        {
            var delivery = await _context.Delivery.FindAsync(id);
            if (delivery == null) return new NotFoundObjectResult(new { message = "Delivery not found" });

            delivery.IsDelivered = isDelivered;
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Delivery status updated", delivery });
        }
    }

}
