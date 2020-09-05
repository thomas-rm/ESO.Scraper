using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtensionMethods
{
    public static class _string
    {
        public static string WithoutWhitespace(this String str)
        {
            return Regex.Replace(str, @"\s", "");
        }
    }
}
