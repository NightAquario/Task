using Microsoft.EntityFrameworkCore;
using Task.Service.Interfaces.Configuration;

namespace Configuration;

public static class ModelBuilderExtensions
{
    public static void ConfigureEntities(this ModelBuilder modelBuilder)
    {
        var configurationType = typeof(IEntityConfiguration);
        _ = (
          from T in typeof(IEntityConfiguration).Assembly.GetTypes()
          where configurationType.IsAssignableFrom(T) && !T.IsAbstract
          select (Activator.CreateInstance(T, modelBuilder) as IEntityConfiguration)?.Configure(modelBuilder)
        ).ToArray();
    }
}
