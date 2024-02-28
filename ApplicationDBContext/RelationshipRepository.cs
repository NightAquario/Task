using Task.DTO;
using Task.Service.Interfaces.Repository;

namespace Task.Repository;

internal sealed class RelationshipRepository : RepositoryBase<Relationship> , IRelationshipRepository
{
    internal RelationshipRepository(ApplicationDBContext context) : base(context)
    {
        
    }
}
