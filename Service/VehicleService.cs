using LogistikaApi.DBContext;
using LogistikaApi.Interface;
using LogistikaApi.Model;
using LogistikaApi.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogistikaApi.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly ContextDB _context;
        public VehicleService(ContextDB context) => _context = context;

        public async Task<IActionResult> GetAllAsync()
        {
            var vehicles = await _context.Vehicle.ToListAsync();
            return new OkObjectResult(new { vehicles });
        }

        public async Task<IActionResult> CreateAsync(VehReq vehReq)
        {
            var vehicle = new Vehicle();
            vehicle.LicensePlate = vehReq.LicensePlate;
            vehicle.NextMaintenanceDate = vehReq.NextMaintenanceDate;
            vehicle.LastMaintenanceDate = vehReq.LastMaintenanceDate;
            vehicle.Model = vehReq.Model;
            await _context.Vehicle.AddAsync(vehicle);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Vehicle created", vehicle });
        }

        public async Task<IActionResult> UpdateAsync(int id, Vehicle updated)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
                return new NotFoundObjectResult(new { message = "Vehicle not found" });

            vehicle.LicensePlate = updated.LicensePlate;
            vehicle.Model = updated.Model;
            vehicle.LastMaintenanceDate = updated.LastMaintenanceDate;
            vehicle.NextMaintenanceDate = updated.NextMaintenanceDate;

            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Vehicle updated", vehicle });
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
                return new NotFoundObjectResult(new { message = "Vehicle not found" });

            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Vehicle deleted" });
        }
    }
}
