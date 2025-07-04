using LogistikaApi.DBContext;
using LogistikaApi.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogistikaApi.Model;

namespace LogistikaApi.Service
{
    public class RouteService : IRouteService
    {
        private readonly ContextDB _context;
        public RouteService(ContextDB context) => _context = context;

        public async Task<IActionResult> GetAllAsync()
        {
            var routes = await _context.Route.ToListAsync();
            return new OkObjectResult(new { routes });
        }

        public async Task<IActionResult> CreateAsync(Model.Route route)
        {
            _context.Route.Add(route);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Route created", route });
        }

        public async Task<IActionResult> UpdateAsync(int id, Model.Route route)
        {
            var existing = await _context.Route.FindAsync(id);
            if (existing == null) return new NotFoundObjectResult(new { message = "Route not found" });

            existing.RouteName = route.RouteName;
            existing.Priority = route.Priority;
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Route updated", route = existing });
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var route = await _context.Route.FindAsync(id);
            if (route == null) return new NotFoundObjectResult(new { message = "Route not found" });

            _context.Route.Remove(route);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Route deleted" });
        }
    }

}
