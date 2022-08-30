using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("Employees");

        builder
            .Property(p => p.FName).IsRequired()
            .HasMaxLength(30);

        builder
            .Property(p => p.LName).IsRequired()
            .HasMaxLength(30);
    }
}
