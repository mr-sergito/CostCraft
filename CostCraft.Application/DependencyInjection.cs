using CostCraft.Application.Services.Authentication;
using CostCraft.Application.Services.Authentication.Commands;
using CostCraft.Application.Services.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CostCraft.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

        return services;
    }
}
