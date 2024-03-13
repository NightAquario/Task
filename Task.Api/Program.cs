using Task.Api.Configuration;

namespace Task.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.ConfigureDependency();

        var app = builder.Build();

        app.Run();
    }
}
