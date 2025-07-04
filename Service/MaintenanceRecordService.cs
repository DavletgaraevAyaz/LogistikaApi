using LogistikaApi.DBContext;
using LogistikaApi.Interface;
using LogistikaApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogistikaApi.Service
{
    public class MaintenanceRecordService : IMaintenanceRecordService
    {
        private readonly ContextDB _context;
        public MaintenanceRecordService(ContextDB context) => _context = context;

        public async Task<IActionResult> GetAllAsync()
        {
            var records = await _context.MaintenanceRecord.Include(x => x.Vehicle).ToListAsync();
            return new OkObjectResult(new { maintenanceRecords = records });
        }

        public async Task<IActionResult> GetByVehicleIdAsync(int vehicleId)
        {
            var records = await _context.MaintenanceRecord
                .Where(x => x.VehicleId == vehicleId)
                .ToListAsync();
            return new OkObjectResult(new { maintenanceRecords = records });
        }

        public async Task<IActionResult> CreateAsync(MaintenanceRecord record)
        {
            _context.MaintenanceRecord.Add(record);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "Record added", record });
        }
    }

}
