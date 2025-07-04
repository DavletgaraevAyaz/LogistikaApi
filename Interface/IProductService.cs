using LogistikaApi.Model;
using LogistikaApi.Request;
using Microsoft.AspNetCore.Mvc;

namespace LogistikaApi.Interface
{
    public interface IProductService
    {
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> GetByIdAsync(int id);
        Task<IActionResult> CreateAsync(ProdReq product);
        Task<IActionResult> UpdateAsync(int id, ProdReq product);
        Task<IActionResult> DeleteAsync(int id);
    }
}
