using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolundApp.Util
{
    public static class DateToString
    {
        public static string GetYearOnly(DateTime? date)
        {
            return date.HasValue ? date.Value.ToString("yyyy") : "N/A";
        }

        public static string GetYearMonth(DateTime? date)
        {
            return date.HasValue ? date.Value.ToString("yyyy MMMM") : "N/A";
        }

        public static string GetFullDate(DateTime? date)
        {
            return date.HasValue ? date.Value.ToString("yyyy-MM-dd") : "N/A";
        }
    }
}
