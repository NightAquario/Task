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
        modelBuilder.Entity<City>().HasMany(c => c.People).WithOne(p => p.City);

        modelBuilder.Entity<Person>().Property(p => p.FirstName).HasColumnType("Nvarchar(50)").IsRequired().HasAnnotation("MinLength", 2);
        modelBuilder.Entity<Person>().Property(p => p.LastName).HasColumnType("Nvarchar(50)").IsRequired().HasAnnotation("MinLength", 2);
        modelBuilder.Entity<Person>().Property(p => p.PersonalNumber).HasColumnType("Nvarchar(11)").IsRequired();
        modelBuilder.Entity<Person>().Property(p => p.DateOfBirth).IsRequired().HasColumnType("Date").HasAnnotation("CheckConstraint", "DateOfBirth <= DateAdd(Year, -18, GetDate())");
        /* Picture */
        modelBuilder.Entity<Person>().HasMany(c => c.PhoneNumbers).WithOne(c => c.PersonId);
        modelBuilder.Entity<Person>().Property(p => p.CreateDate).IsRequired().HasColumnType("Date").HasDefaultValueSql("GetDate()");
        modelBuilder.Entity<Person>().Property(p => p.IsActive).IsRequired().HasColumnType("Bit").HasDefaultValue(false);

        modelBuilder.Entity<Relationship>().Property(r => r.RelationshipType).IsRequired();
        modelBuilder.Entity<Relationship>().HasKey(r => new { r.FromPersonId, r.ToPersonId });
        modelBuilder.Entity<Relationship>().HasOne(r => r.FromPerson).WithMany(p => p.RelationshipFrom).HasForeignKey(r => r.FromPersonId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Relationship>().HasOne(r => r.ToPerson).WithMany(p => p.RelationshipTo).HasForeignKey(r => r.ToPersonId).OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<PhoneNumber>().Property(p => p.Number).HasColumnType("Nvarchar(50)").IsRequired().HasAnnotation("MinLength", 4);
        modelBuilder.Entity<PhoneNumber>().Property(p => p.IsActive).HasColumnType("bit").HasDefaultValue(false);
        modelBuilder.Entity<PhoneNumber>().Property(p => p.CreateDate).HasColumnType("date").HasDefaultValueSql("GetDate()");
        modelBuilder.Entity<PhoneNumber>().HasOne(p => p.PersonId).WithMany(p => p.PhoneNumbers);

    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Relationship> Relationships { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
}
