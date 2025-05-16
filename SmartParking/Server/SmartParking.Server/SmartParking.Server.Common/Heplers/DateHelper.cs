using System;

namespace SmartParking.Server.Common.Heplers
{
    public static class DateHelper
    {
        public static long GetCurrentMilliseconds()
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var now = DateTime.UtcNow;
            return (long)(now - epoch).TotalMilliseconds;
        }
    }
}