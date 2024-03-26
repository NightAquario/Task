using Microsoft.EntityFrameworkCore;
using Task.DTO;

namespace Task.Service.Interfaces.Configuration;

public class CityConfiguration : IEntityConfiguration
{
    public bool Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>().HasKey(c => c.Id);
        modelBuilder.Entity<City>().Property(c => c.Name).IsRequired().HasColumnType("nvarchar(50)");
        modelBuilder.Entity<City>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<City>().Property(c => c.IsActive).IsRequired().HasColumnType("Bit").HasDefaultValue(false);
        modelBuilder.Entity<City>().Property(c => c.CreateDate).IsRequired().HasColumnType("Date").HasDefaultValueSql("GetDate()");
        modelBuilder.Entity<City>().HasMany(c => c.People).WithOne(p => p.City);

        return true;
    }
}
