namespace GraafschapCollege.Api.Context;

using GraafschapCollege.Api.Entities;

using Microsoft.EntityFrameworkCore;

public class GraafschapCollegeDbContext(DbContextOptions<GraafschapCollegeDbContext> options)
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
}
