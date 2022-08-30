using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

internal class MyApplicationContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }

    public MyApplicationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TestTask2Db;Trusted_Connection=True;");
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(builder.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
                .Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity<Enrollment>(
                   j => j
                    .HasOne(pt => pt.Student)
                    .WithMany(t => t.Enrollments)
                    .HasForeignKey(pt => pt.StudentId),
                j => j
                    .HasOne(pt => pt.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(pt => pt.CourseId),
                j =>
                {
                    j.Property(pt => pt.Mark).HasDefaultValue(3);
                    j.HasKey(t => new { t.CourseId, t.StudentId });
                    j.ToTable("Enrollments");
                });
    }
}

