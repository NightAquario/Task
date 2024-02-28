using Task.DTO;
using Task.Service.Interfaces.Repository;

namespace Task.Repository;

internal sealed class PhoneNumberRepository : RepositoryBase<PhoneNumber> , IPhoneNumberRepository
{
    internal PhoneNumberRepository(ApplicationDBContext context) : base(context)
    {
        
    }
}
