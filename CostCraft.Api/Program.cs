using CostCraft.Api.Infrastructure.Data;
using CostCraft.Application;
using CostCraft.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddDbContext<CostCraftDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("CostCraftDb"))
    );
builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await app.RunAsync();
