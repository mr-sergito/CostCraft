using CostCraft.Api.Common.Errors;
using CostCraft.Api.Infrastructure.Data;
using CostCraft.Application;
using CostCraft.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
builder.Services.AddControllers();
builder.Services.AddSingleton<ProblemDetailsFactory, CostCraftProblemDetailsFactory>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await app.RunAsync();
