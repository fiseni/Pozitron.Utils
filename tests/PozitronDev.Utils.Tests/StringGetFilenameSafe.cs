using System;
using System.Collections.Generic;
using System.Text;
using PozitronDev.Utils.Extensions;
using Xunit;

namespace PozitronDev.Utils.Tests
{
    public class StringGetFilenameSafe
    {
        [Theory]
        [InlineData("myString", "myString")]
        [InlineData("my/String.txt", "my_String.txt")]
        [InlineData("/myString", "_myString")]
        public void ShouldReturnCorrectString(string input, string expected)
        {
            var actual = input.GetFilenameSafe();

            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData(null)]
        public void ShoulThrowArgumentNullException(string input)
        {
            Assert.Throws<ArgumentNullException>(() => input.GetFilenameSafe());
        }

        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        public void ShoulThrowArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => input.GetFilenameSafe());
        }
    }
}
