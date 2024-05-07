namespace GraafschapCollege.Api.Context;

using GraafschapCollege.Api.Entities;

using Microsoft.EntityFrameworkCore;

public class GraafschapCollegeDbContext(DbContextOptions<GraafschapCollegeDbContext> options)
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            Name = "admin",
            Email = "admin@example.com",
            Password = "password123"
        });
    }
}
