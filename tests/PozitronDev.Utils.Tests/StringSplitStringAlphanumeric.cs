using System;
using System.Collections.Generic;
using System.Text;
using PozitronDev.Utils.Extensions;
using Xunit;

namespace PozitronDev.Utils.Tests
{
    public class StringSplitStringAlphanumeric
    {
        [Theory]
        [InlineData("myString", new string[] { "myString"})]
        [InlineData("my/String.1", new string[] { "my", "String", "1" })]
        [InlineData("/myString...x", new string[] { "myString", "x" })]
        public void ShouldReturn(string input, string[] expected)
        {
            var actual = input.SplitStringAlphanumeric();

            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData(null)]
        public void ShoulThrowArgumentNullException(string input)
        {
            Assert.Throws<ArgumentNullException>(() => input.SplitStringAlphanumeric());
        }

        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        public void ShoulThrowArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => input.SplitStringAlphanumeric());
        }
    }
}
