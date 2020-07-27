using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Strings
{
    public static class StringExtensions
    {
        public static string RemoveAll(this string input, Func<char, bool> selector)
        {
            return new string(input.Where(c => !selector(c)).ToArray());
        }

        public static string RemoveAll(this string input, params char[] chars)
        {
            return new string(input.Where(c => !chars.Contains(c)).ToArray());
        }

        public static string RemoveAllWhiteSpace(this string input)
        {
            return input.RemoveAll(c => char.IsWhiteSpace(c));
        }
    }
}
