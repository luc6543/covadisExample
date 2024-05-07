namespace GraafschapCollege.Api.Seeders;

using GraafschapCollege.Api.Context;
using GraafschapCollege.Api.Entities;

using System.Data;

public static class UserSeeder
{
    public static void Seed(GraafschapCollegeDbContext dbContext)
    {
        var existingUsers = dbContext.Users
            .Select(x => x.Email)
            .ToList();

        var roles = dbContext.Roles.ToList();

        var users = new List<User>
        {
            new() {
                Name = "Bryan Schoot",
                Email = "b.schoot@example.com",
                Password = "Password123!",
                Roles = [roles.Find(x => x.Name == Role.Administrator)!]
            },
            new() {
                Name = "John Doe",
                Email = "j.doe@example.com",
                Password = "Password123!",
                Roles = [roles.Find(x => x.Name == Role.Employee)!]
            }
        };

        var usersToAdd = users
            .Where(x => !existingUsers.Contains(x.Email))
            .ToList();

        dbContext.Users.AddRange(usersToAdd);
        dbContext.SaveChanges();
    }
}