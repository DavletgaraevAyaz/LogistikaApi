using LogistikaApi.DBContext;
using LogistikaApi.Interface;
using LogistikaApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LogistikaApi.Service
{
    public class WarehouseService : IWarehouseService
    {
        private readonly ContextDB _context;
        public WarehouseService(ContextDB context) => _context = context;

        public async Task<IActionResult> GetAllAsync()
        {
            var warehouses = await _context.Warehouse.ToListAsync();
            return new OkObjectResult(new { warehouses });
        }

        public async Task<IActionResult> CreateAsync(Warehouse warehouse)
        {
            _context.Warehouse.Add(warehouse);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Warehouse created", warehouse });
        }

        public async Task<IActionResult> UpdateAsync(int id, Warehouse updated)
        {
            var warehouse = await _context.Warehouse.FindAsync(id);
            if (warehouse == null) return new NotFoundObjectResult(new { message = "Warehouse not found" });

            warehouse.Name = updated.Name;
            warehouse.Location = updated.Location;
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Warehouse updated", warehouse });
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var warehouse = await _context.Warehouse.FindAsync(id);
            if (warehouse == null) return new NotFoundObjectResult(new { message = "Warehouse not found" });

            _context.Warehouse.Remove(warehouse);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Warehouse deleted" });
        }
    }
}
