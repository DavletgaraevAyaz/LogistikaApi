using LogistikaApi.DBContext;
using LogistikaApi.Interface;
using LogistikaApi.Model;
using LogistikaApi.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace LogistikaApi.Service
{
    public class UserService : IUserService
    {
        private readonly ContextDB _context;
        private readonly IConfiguration _config;

        public UserService(ContextDB context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _context.User.ToListAsync();
            return new OkObjectResult(new { users });
        }

        public async Task<IActionResult> RegisterAsync(RegReq user)
        {
            User us = new User();
            us.Username = user.Username;
            us.Password = user.Password;
            us.Role = user.Role;
            await _context.User.AddAsync(us);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "User registered", user });
        }

        public async Task<IActionResult> LoginAsync(string username, string password)
        {
            var user = await _context.User
                .FirstOrDefaultAsync(x => x.Username == username && x.Password == password);

            if (user == null)
                return new NotFoundObjectResult(new { message = "Invalid credentials" });

            var token = GenerateJwtToken(user);
            return new OkObjectResult(new { message = "Login successful", token });
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
        new Claim("Id", user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role, user.Role),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddHours(1);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<IActionResult> DeleteAsync(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null) return new NotFoundObjectResult(new { message = "User not found" });

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { message = "User deleted" });
        }
    }

}
