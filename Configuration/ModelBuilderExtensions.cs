using Microsoft.EntityFrameworkCore;
using Task.Service.Interfaces.Configuration;

namespace Configuration;

public static class ModelBuilderExtensions
{
    public static void ConfigureEntities(this ModelBuilder modelBuilder)
    {
        var configurationType = typeof(IEntityConfiguration);
        _ = (
          from t in typeof(IEntityConfiguration).Assembly.GetTypes()
          where configurationType.IsAssignableFrom(t) && !t.IsAbstract
          select (Activator.CreateInstance(t, modelBuilder) as IEntityConfiguration)?.Configure(modelBuilder)
        ).ToArray();
    }
}
