using LogistikaApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace LogistikaApi.Interface
{
    public interface IMaintenanceRecordService
    {
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> GetByVehicleIdAsync(int vehicleId);
        Task<IActionResult> CreateAsync(MaintenanceRecord record);
    }

}
