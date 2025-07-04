using LogistikaApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace LogistikaApi.Interface
{
    public interface IWarehouseService
    {
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> CreateAsync(Warehouse warehouse);
        Task<IActionResult> UpdateAsync(int id, Warehouse warehouse);
        Task<IActionResult> DeleteAsync(int id);
    }

}
