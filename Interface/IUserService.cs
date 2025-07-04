using LogistikaApi.Model;
using LogistikaApi.Request;
using Microsoft.AspNetCore.Mvc;

namespace LogistikaApi.Interface
{
    public interface IUserService
    {
        Task<IActionResult> GetAllAsync();
        Task<IActionResult> RegisterAsync(RegReq user);
        Task<IActionResult> LoginAsync(string username, string password);
        Task<IActionResult> DeleteAsync(int id);
    }

}
