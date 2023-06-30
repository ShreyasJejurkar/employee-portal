using Application.Abstractions;
using Infrastructure.Implementions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, InMemoryEmployeeRepository>();
        services.AddScoped<ICommentsRepository, InMemoryCommentsRepository>();
    }
}
