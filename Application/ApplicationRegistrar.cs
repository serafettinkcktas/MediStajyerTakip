using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationRegistrar
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}