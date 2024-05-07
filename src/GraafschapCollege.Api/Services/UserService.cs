namespace GraafschapCollege.Api.Services;

using GraafschapCollege.Api.Context;
using GraafschapCollege.Api.Entities;
using GraafschapCollege.Shared.Responses;

using System;

public class UserService(GraafschapCollegeDbContext dbContext)
{
    public IEnumerable<UserResponse> GetUsers()
    {
        return dbContext.Users.Select(x => new UserResponse
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email
        });
    }

    public UserResponse? GetUserById(int id)
    {
        var user = dbContext.Users.Find(id);

        if (user == null)
        {
            return null;
        }

        return new UserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }

    public UserResponse CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public UserResponse? UpdateUser(int id, User user)
    {
        throw new NotImplementedException();
    }
}
