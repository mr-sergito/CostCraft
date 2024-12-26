using CostCraft.Application.Common.Interfaces.Authentication;
using CostCraft.Application.Common.Interfaces.Persistence;
using CostCraft.Application.Common.Interfaces.Services;
using CostCraft.Infrastructure.Authentication;
using CostCraft.Infrastructure.Persistence;
using CostCraft.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CostCraft.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;    
    }
}
