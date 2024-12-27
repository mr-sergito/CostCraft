using CostCraft.Api.Infrastructure.Data;
using CostCraft.Application;
using CostCraft.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddDbContext<CostCraftDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("CostCraftDb"))
    );
//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddControllers();
//builder.Services.AddSingleton<ProblemDetailsFactory, CostCraftProblemDetailsFactory>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext httpContext) =>
{
    Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    return Results.Problem();
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await app.RunAsync();
