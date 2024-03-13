using Task.Repository;
using Task.Service;
using Task.Service.Interfaces.Repository;


namespace Task.Api.Configuration;

public static class DependencyConfiguration
{
    public static void ConfigureDependency(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    }
}
