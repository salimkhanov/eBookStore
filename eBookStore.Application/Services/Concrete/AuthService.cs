using eBookStore.Application.DTOs.Authentication;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eBookStore.Application.Services.Concrete;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;

    private readonly IConfiguration _config;

    public AuthService(
        UserManager<User> userManager,
        IConfiguration config
       )
    {
        _userManager = userManager;
        _config = config;
    }

    private async Task<string> GenerateToken(User user) 
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

        var roles = await _userManager.GetRolesAsync(user);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));


        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
        _config["Jwt:Issuer"],
        _config["Jwt:Audience"],
        claims,
        expires: DateTime.Now.AddMinutes(15),
        signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public async Task<string> Login(LoginDTO login)
    {
        var user = await _userManager.FindByEmailAsync(login.Email);

        if (user == null || user.EntityStatus != EntityStatus.Active)
        {
            return "User does not exist or is not active";
        }
        if (!await _userManager.CheckPasswordAsync(user, login.Password))
        {
            return "Invalid email or password";
        }
        return await GenerateToken(user);
    }
}
