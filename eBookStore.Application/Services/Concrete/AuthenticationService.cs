using AutoMapper;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using IdentityTask.DTOs.Authentication;
using IdentityTask.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eBookStore.Application.Services.Concrete;
public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;

    public AuthenticationService(
        UserManager<User> userManager,
        IConfiguration config,
        IMapper mapper)
    {
        _userManager = userManager;
        _config = config;
        _mapper = mapper;
    }

    private string GenerateJWTToken(User user, List<string> roles)
    {
        var claims = new List<Claim>();

        claims.Add(new Claim(ClaimTypes.Email, user.Email));

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }


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

        if (user.EntityStatus == EntityStatus.Active)
        {
            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);
                return GenerateJWTToken(user, roles.ToList());
            }
        }
        return "Invalid email or password or User does not exist";
    }
    
}

