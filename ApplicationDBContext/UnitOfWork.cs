using Task.Service.Interfaces.Repository;

namespace Task.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDBContext _context;
    private readonly Lazy<IPersonRepository> _personRepository;
    private readonly Lazy<IPhoneNumberRepository> _phoneNumberRepository;
    private readonly Lazy<IRelationshipRepository> _relationshipRepository;
    private readonly Lazy<ICityRepository> _cityRepository;

    public UnitOfWork(ApplicationDBContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _personRepository = new Lazy<IPersonRepository>(() => new PersonRepository(context));
        _phoneNumberRepository = new Lazy<IPhoneNumberRepository>(() => new PhoneNumberRepository(context));
        _relationshipRepository = new Lazy<IRelationshipRepository>(() => new RelationshipRepository(context));
        _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(context));
    }

    public IPersonRepository PersonRepository => _personRepository.Value;

    public IPhoneNumberRepository PhoneNumberRepository => _phoneNumberRepository.Value;

    public IRelationshipRepository RelationshipRepository => _relationshipRepository.Value;

    public ICityRepository CityRepository => _cityRepository.Value;

    public int SaveChanges() => _context.SaveChanges();

    public void BeginTransaction()
    {
        if (_context.Database.CurrentTransaction != null)
        {
            throw new InvalidOperationException("A Transaction is already in progress.");
        }

        _context.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        try
        {
            _context.Database.CurrentTransaction?.Commit();
        }
        catch
        {
            _context.Database.CurrentTransaction?.Rollback();
            throw;
        }
        finally
        {
            _context.Database.CurrentTransaction?.Dispose();
        }
    }

    public void RollBack()
    {
        try
        {
            _context.Database.CurrentTransaction?.Rollback();
        }
        finally
        {
            _context.Database.CurrentTransaction?.Dispose();
        }
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}