using System;

namespace Nibo.Util.Parser
{
    public static class DateParser
    {
        public static DateTime Parse(string dateOfx)
        {
            var year = int.Parse(dateOfx.Substring(0, 4));
            var month = int.Parse(dateOfx.Substring(4, 2));
            var day = int.Parse(dateOfx.Substring(6, 2));
            var hour = int.Parse(dateOfx.Substring(8, 2));
            var minute = int.Parse(dateOfx.Substring(10, 2));
            var second = int.Parse(dateOfx.Substring(12, 2));

            return new DateTime(year, month, day, hour, minute, second);
        }
    }
}
