namespace GraafschapCollege.Api.Services;

using GraafschapCollege.Api.Entities;

using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenService(IConfiguration configuration)
{
    private readonly SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));

    public string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Email, user.Email)
        };

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: signingCredentials,
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"]);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
