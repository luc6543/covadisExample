namespace GraafschapCollege.Api.Seeders;

using GraafschapCollege.Api.Context;
using GraafschapCollege.Api.Entities;

public static class RoleSeeder
{
    public static void Seed(GraafschapCollegeDbContext dbContext)
    {
        var existingRoles = dbContext.Roles
            .Select(x => x.Name)
            .ToList();

        var roles = new List<Role>
        {
            new() { Name = Role.Administrator },
            new() { Name = Role.Employee }
        };

        var rolesToAdd = roles
            .Where(x => !existingRoles.Contains(x.Name))
            .ToList();

        dbContext.Roles.AddRange(rolesToAdd);
        dbContext.SaveChanges();
    }
}
