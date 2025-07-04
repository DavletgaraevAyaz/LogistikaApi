using LogistikaApi.DBContext;
using LogistikaApi.Interface;
using LogistikaApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LogistikaApi.Service
{
    public class ProductMovementService : IProductMovementService
    {
        private readonly ContextDB _context;
        public ProductMovementService(ContextDB context) => _context = context;

        public async Task<IActionResult> GetAllAsync()
        {
            var movements = await _context.ProductMovements
                .Include(x => x.Product)
                .Include(x => x.Warehouse)
                .Include(x => x.MovementType)
                .ToListAsync();
            return new OkObjectResult(new { movements });
        }

        public async Task<IActionResult> GetByProductIdAsync(int productId)
        {
            var movements = await _context.ProductMovements
                .Where(x => x.ProductId == productId)
                .Include(x => x.MovementType)
                .ToListAsync();
            return new OkObjectResult(new { movements });
        }

        public async Task<IActionResult> GetByMovementTypeIdAsync(int movementTypeId)
        {
            var movements = await _context.ProductMovements
                .Where(x => x.MovementTypeId == movementTypeId)
                .Include(x => x.Product)
                .ToListAsync();
            return new OkObjectResult(new { movements });
        }

        public async Task<IActionResult> CreateAsync(ProductMovement movement)
        {
            _context.ProductMovements.Add(movement);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Movement created", movement });
        }
    }

}
