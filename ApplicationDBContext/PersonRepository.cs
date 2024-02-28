using Task.DTO;
using Task.Service.Interfaces.Repository;

namespace Task.Repository;

internal sealed class PersonRepository : RepositoryBase<Person> , IPersonRepository
{
    internal PersonRepository(ApplicationDBContext context) : base(context)
    {
        
    }
}
