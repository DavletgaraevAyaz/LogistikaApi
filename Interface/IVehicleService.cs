using LogistikaApi.Model;
using LogistikaApi.Request;
using Microsoft.AspNetCore.Mvc;

namespace LogistikaApi.Interface
{
    public interface IVehicleService
    {
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> CreateAsync(VehReq vehicle);
        Task<IActionResult> UpdateAsync(int id, Vehicle vehicle);
        Task<IActionResult> DeleteAsync(int id);
    }

}
