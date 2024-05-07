namespace GraafschapCollege.Api.Services;

using GraafschapCollege.Api.Context;
using GraafschapCollege.Api.Entities;
using GraafschapCollege.Shared.Requests;
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

    public UserResponse CreateUser(CreateUserRequest request)
    {
        var existingUser = dbContext.Users
            .SingleOrDefault(x => x.Email == request.Email);

        if (existingUser != null)
        {
            // This should be a custom exception but for now we'll just throw a regular one.
            // Best case scenario is to create a Result object that contains error messages or a success flag.
            throw new Exception("User already exists");
        }

        var roles = dbContext.Roles
            .Where(x => request.Roles.Contains(x.Name))
            .ToList();

        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Roles = roles
        };

        dbContext.Users.Add(user);
        dbContext.SaveChanges();

        return new UserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }

    public UserResponse? UpdateUser(int id, User user)
    {
        throw new NotImplementedException();
    }
}
