using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierAPI.Models
{
    public static class ExtensionHelpers
    {
        public static int ToInt(this string stringNumber)
            => Convert.ToInt32(stringNumber);

        public static string MyToString(this int intNumber)
            => Convert.ToString(intNumber);
    }
}
