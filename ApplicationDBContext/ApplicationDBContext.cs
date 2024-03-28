using Configuration;
using Microsoft.EntityFrameworkCore;
using Task.DTO;
using Task.Service.Interfaces.Configuration;

namespace Task.Repository;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureEntities();
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Relationship> Relationships { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
}
