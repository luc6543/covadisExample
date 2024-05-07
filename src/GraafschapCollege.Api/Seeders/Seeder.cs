namespace GraafschapCollege.Api.Seeders;

using GraafschapCollege.Api.Context;

public static class Seeder
{
    public static void Seed(this GraafschapCollegeDbContext dbContext)
    {
        RoleSeeder.Seed(dbContext);
        UserSeeder.Seed(dbContext);
    }
}
