using Microsoft.EntityFrameworkCore;
using Task.DTO;

namespace Task.Service.Interfaces.Configuration;

public class PhoneNumberConfiguration : IEntityConfiguration
{
    public bool Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PhoneNumber>().HasKey(p => p.Id);
        modelBuilder.Entity<PhoneNumber>().Property(p => p.Number).IsRequired().HasColumnType("Nvarchar(50)").IsRequired().HasAnnotation("MinLength", 4);
        modelBuilder.Entity<PhoneNumber>().Property(p => p.IsActive).IsRequired().HasColumnType("Bit").HasDefaultValue(false);
        modelBuilder.Entity<PhoneNumber>().Property(p => p.CreateDate).IsRequired().HasColumnType("Date").HasDefaultValueSql("GetDate()");
        modelBuilder.Entity<PhoneNumber>().HasOne(p => p.Person).WithMany(p => p.PhoneNumbers);

        return true;
    }
}
