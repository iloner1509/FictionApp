using System;

namespace User.Infrastructure.CrossCuttingConcerns.OS
{
    public class DateTimeProvider:IDateTimeProvider
    {
        public DateTime Now { get; }
        public DateTime UtcNow { get; }
        public DateTimeOffset OffsetNow { get; }
        public DateTimeOffset OffsetUtcNow { get; }
    }
}