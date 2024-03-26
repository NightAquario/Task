using Microsoft.EntityFrameworkCore;
using Task.DTO;

namespace Task.Service.Interfaces.Configuration;

public class PersonConfiguration : IEntityConfiguration
{
    public bool Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Person>()
            .Property(p => p.FirstName)
            .IsRequired()
            .HasColumnType("Nvarchar(50)")
            .HasAnnotation("MinLength", 2);

        modelBuilder.Entity<Person>()
            .Property(p => p.LastName)
            .IsRequired()
            .HasColumnType("Nvarchar(50)")
            .HasAnnotation("MinLength", 2);

        modelBuilder.Entity<Person>()
            .Property(p => p.PersonalNumber)
            .IsRequired()
            .HasColumnType("Nvarchar(11)")
            .HasAnnotation("MinLength", 11);

        modelBuilder.Entity<Person>()
            .Property(p => p.DateOfBirth)
            .IsRequired()
            .HasColumnType("Date")
            .HasAnnotation("CheckConstraint", "DateOfBirth <= DateAdd(Year, -18, GetDate())");

        /* Picture */

        modelBuilder.Entity<Person>()
            .HasMany(p => p.PhoneNumbers)
            .WithOne(c => c.Person);

        modelBuilder.Entity<Person>()
            .Property(p => p.CreateDate)
            .IsRequired()
            .HasColumnType("Date")
            .HasDefaultValueSql("GetDate()");

        modelBuilder.Entity<Person>()
            .Property(p => p.IsActive)
            .IsRequired()
            .HasColumnType("Bit")
            .HasDefaultValue(false);

        return true;
    }
}
