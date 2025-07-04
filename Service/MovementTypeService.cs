using LogistikaApi.DBContext;
using LogistikaApi.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LogistikaApi.Service
{
    public class MovementTypeService : IMovementTypeService
    {
        private readonly ContextDB _context;
        public MovementTypeService(ContextDB context) => _context = context;

        public async Task<IActionResult> GetAllAsync()
        {
            var types = await _context.MovementType.ToListAsync();
            return new OkObjectResult(new { movementTypes = types });
        }
    }
}
