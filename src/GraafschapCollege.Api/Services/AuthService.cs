namespace GraafschapCollege.Api.Services;

using GraafschapCollege.Api.Context;
using GraafschapCollege.Shared.Requests;
using GraafschapCollege.Shared.Responses;

using Microsoft.EntityFrameworkCore;

public class AuthService(GraafschapCollegeDbContext dbContext, TokenService tokenService)
{
    public AuthResponse? Login(LoginRequest request)
    {
        var user = dbContext.Users
            .Include(x => x.Roles)
            .SingleOrDefault(x => x.Email == request.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            return null;
        }

        return new AuthResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Token = tokenService.CreateToken(user)
        };
    }
}