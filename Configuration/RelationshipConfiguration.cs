using Microsoft.EntityFrameworkCore;
using Task.DTO;

namespace Task.Service.Interfaces.Configuration;

internal class RelationshipConfiguration : IEntityConfiguration
{
    public bool Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Relationship>().HasKey(r => new { r.FromPersonId, r.ToPersonId });
        modelBuilder.Entity<Relationship>().Property(r => r.RelationshipType).IsRequired();
        modelBuilder.Entity<Relationship>().HasOne(r => r.FromPerson).WithMany(p => p.RelationshipFrom).HasForeignKey(r => r.FromPersonId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Relationship>().HasOne(r => r.ToPerson).WithMany(p => p.RelationshipTo).HasForeignKey(r => r.ToPersonId).OnDelete(DeleteBehavior.NoAction);

        return true;
    }
}
