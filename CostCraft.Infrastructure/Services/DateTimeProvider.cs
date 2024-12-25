using CostCraft.Application.Common.Interfaces.Services;

namespace CostCraft.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
