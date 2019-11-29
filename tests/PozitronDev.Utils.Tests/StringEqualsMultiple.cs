using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using PozitronDev.Utils.Extensions;

namespace PozitronDev.Utils.Tests
{
    public class StringEqualsMultiple
    {
        [Theory]
        [InlineData("myString", "myString", "", "test2")]
        [InlineData("myString", null, "myString", "")]
        public void ForCaseSensitive_ShouldReturnTrue(string input, string argument1, string argument2, string argument3)
        {
            Assert.True(input.EqualsMultiple(StringComparison.InvariantCulture, argument1, argument2, argument3));
        }

        [Theory]
        [InlineData("myString", "MYString", "test1", "test2")]
        [InlineData("myString", null, "test2", "MYString")]
        public void ForCaseInsensitive_ShouldReturnTrue(string input, string argument1, string argument2, string argument3)
        {
            Assert.True(input.EqualsMultiple(StringComparison.InvariantCultureIgnoreCase, argument1, argument2, argument3));
        }

        [Theory]
        [InlineData("myString", "mystring", "", "test2")]
        [InlineData("myString", null, "myXString", "")]
        public void ForCaseSensitive_ShouldReturnFalse(string input, string argument1, string argument2, string argument3)
        {
            Assert.False(input.EqualsMultiple(StringComparison.InvariantCulture, argument1, argument2, argument3));
        }

        [Theory]
        [InlineData("myString", "myXString", "test1", "test2")]
        [InlineData("myString", null, "test2", "myXString")]
        public void ForCaseInsensitive_ShouldReturnFalse(string input, string argument1, string argument2, string argument3)
        {
            Assert.False(input.EqualsMultiple(StringComparison.InvariantCultureIgnoreCase, argument1, argument2, argument3));
        }
    }
}
