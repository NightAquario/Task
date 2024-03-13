namespace Task.Service.Interfaces.Repository;

public interface IUnitOfWork :IDisposable
{
    IPersonRepository PersonRepository { get; }
    IPhoneNumberRepository PhoneNumberRepository { get; }
    IRelationshipRepository RelationshipRepository { get; }
    ICityRepository CityRepository { get; }
    int SaveChanges();
    void BeginTransaction();
    void CommitTransaction();
    void RollBack();

}
