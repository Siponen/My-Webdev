using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolundApp.Util
{
    public static class Util
    {
        public static string GetImageFilePath(string value)
        {
            if (String.IsNullOrEmpty(value))
                return "default.png";

            return value;
        }
    }
}