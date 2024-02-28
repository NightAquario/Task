using Task.DTO;
using Task.Service.Interfaces.Repository;

namespace Task.Repository;

internal sealed class CityRepository : RepositoryBase<City> , ICityRepository
{
    internal CityRepository(ApplicationDBContext context) : base(context)
    {
        
    }
}
