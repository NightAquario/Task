using Microsoft.EntityFrameworkCore;

namespace Task.Service.Interfaces.Configuration;

public interface IEntityConfiguration
{
    bool Configure(ModelBuilder modelbuilder);
}
