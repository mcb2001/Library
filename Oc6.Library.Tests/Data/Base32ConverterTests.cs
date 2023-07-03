using Oc6.Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Tests.Data
{
    public class Base32ConverterTests
    {
        [Theory]
        [InlineData("a", "ME======")]
        [InlineData("ab", "MFRA====")]
        [InlineData("abc", "MFRGG===")]
        [InlineData("abcd", "MFRGGZA=")]
        [InlineData("abcde", "MFRGGZDF")]
        [InlineData("abcdef", "MFRGGZDFMY======")]
        [InlineData("abcdefg", "MFRGGZDFMZTQ====")]
        [InlineData("abcdefgh", "MFRGGZDFMZTWQ===")]
        [InlineData("abcdefghi", "MFRGGZDFMZTWQ2I=")]
        [InlineData("abcdefghij", "MFRGGZDFMZTWQ2LK")]
        public void Encode(string input, string expected)
            => Assert.Equal(expected, Base32Converter.Encode(Encoding.UTF8.GetBytes(input)));
    }
}
