using Task.Repository;
using Task.DTO;

namespace Seeder;

internal class DataSeeder
{
    private readonly ApplicationDBContext _DbContext;

    public DataSeeder(ApplicationDBContext dbContext)
    {
        _DbContext = dbContext;
    }

    public void SeedData()
    {
        if (!_DbContext.Cities.Any())
        {
            _DbContext.Cities.AddRange(
                new City { Id = 1, Name = "Tbilisi" },
                new City { Id = 2, Name = "Batumi" }
            );

            _DbContext.SaveChanges();
        }
    }
}
