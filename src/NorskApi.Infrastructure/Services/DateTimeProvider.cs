using NorskApi.Application.Common.Interfaces.Services;

namespace NorskApi.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}