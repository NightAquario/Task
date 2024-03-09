using Microsoft.EntityFrameworkCore;
using Task.DTO;

namespace Task.Repository;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<City>().Property(c => c.Name).HasColumnType("nvarchar(50)").IsRequired();
        modelBuilder.Entity<City>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<City>().Property(c => c.IsActive).HasColumnType("bit").HasDefaultValueSql("(0)");
        modelBuilder.Entity<City>().Property(c => c.CreateDate).HasColumnType("date").HasDefaultValueSql("GetDate()");
        modelBuilder.Entity<City>().HasMany(c => c.People).WithOne(c => c.City);

        modelBuilder.Entity<Person>().Property(p => p.FirstName).HasColumnType("Nvarchar").HasMaxLength(50).IsRequired().HasAnnotation("MinLength", 2);
        modelBuilder.Entity<Person>().Property(p => p.LastName).HasColumnType("Nvarchar").IsRequired().HasMaxLength(50).HasAnnotation("MinLength", 2);
        modelBuilder.Entity<Person>().Property(p => p.PersonalNumber).HasColumnType("Nvarchar(11)").IsRequired();
        modelBuilder.Entity<Person>().Property(p => p.DateOfBirth).IsRequired().HasColumnType("Date").HasAnnotation("CheckConstraint", "DateOfBirth <= DateAdd(Year, -18, GetDate())");
        //Picture
        modelBuilder.Entity<Person>().HasMany(c => c.PhoneNumbers).WithOne(c => c.PersonId);
        modelBuilder.Entity<Person>().Property(p => p.CreateDate).IsRequired().HasColumnType("Date").HasDefaultValue("GetDate()");
        modelBuilder.Entity<Person>().Property(p => p.IsActive).IsRequired().HasColumnType("Bit").HasDefaultValue("(0)");

        modelBuilder.Entity<Relationship>().Property(r => r.RelationshipType).IsRequired();
        modelBuilder.Entity<Relationship>().HasKey(r => new { r.Person1Id, r.Person2Id });
        modelBuilder.Entity<Relationship>().HasOne(r => r.Person1).WithMany(p => p.Relationships1).HasForeignKey(r => r.Person1Id);
        modelBuilder.Entity<Relationship>().HasOne(r => r.Person2).WithMany(p => p.Relationships2).HasForeignKey(r => r.Person2Id);

        modelBuilder.Entity<PhoneNumber>().Property(p => p.Number).HasColumnType("Nvarchar").IsRequired().HasMaxLength(50).HasAnnotation("MinLength", 4);
        modelBuilder.Entity<PhoneNumber>().Property(p => p.IsActive).HasColumnType("bit").HasDefaultValueSql("(0)");
        modelBuilder.Entity<PhoneNumber>().Property(p => p.CreateDate).HasColumnType("date").HasDefaultValueSql("GetDate()");
        modelBuilder.Entity<PhoneNumber>().HasOne(p => p.PersonId).WithMany(p => p.PhoneNumbers);


    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Relationship> Relationships { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
}
