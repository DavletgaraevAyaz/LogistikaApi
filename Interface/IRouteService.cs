using Microsoft.AspNetCore.Mvc;
using LogistikaApi.Model;

namespace LogistikaApi.Interface
{
    public interface IRouteService
    {
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> CreateAsync(Model.Route route);
        Task<IActionResult> UpdateAsync(int id, Model.Route route);
        Task<IActionResult> DeleteAsync(int id);
    }

}
