using ConsoleApp1.Configurations;
using Microsoft.EntityFrameworkCore;

public class MyAppContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserInfo> UsersInfo { get; set; }

    public MyAppContext() 
    {
        /*Database.EnsureDeleted();
        Database.EnsureCreated();*/
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=NNN;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
    }
}

