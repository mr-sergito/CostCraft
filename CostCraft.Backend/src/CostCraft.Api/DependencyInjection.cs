using CostCraft.Api.Common.Errors;
using CostCraft.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CostCraft.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton<ProblemDetailsFactory, CostCraftProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}
