using Application.Services.CommentsModule;
using Application.Services.EmployeeModule;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static void AddApplicaticationServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<ICommentService, CommentService>();
    }
}
