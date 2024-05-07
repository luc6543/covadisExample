namespace GraafschapCollege.Api.Services;

using GraafschapCollege.Api.Context;
using GraafschapCollege.Shared.Requests;
using GraafschapCollege.Shared.Responses;

public class AuthService(GraafschapCollegeDbContext dbContext, TokenService tokenService)
{
    public AuthResponse? Login(LoginRequest request)
    {
        var user = dbContext.Users.FirstOrDefault(x => x.Email == request.Email);

        if (user == null)
        {
            return null;
        }

        if (user.Password != request.Password)
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