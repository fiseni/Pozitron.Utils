using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using PozitronDev.Utils.Extensions;

namespace PozitronDev.Utils.Tests
{
    public class StringIsAlphanumeric
    {
        [Theory]
        [InlineData("myString")]
        [InlineData("myString1")]
        [InlineData("1myS34tring1")]
        public void ShouldReturnTrue(string input)
        {
            Assert.True(input.IsAlphanumeric());
        }

        [Theory]
        [InlineData("my_String")]
        [InlineData("_myString")]
        [InlineData("myString!")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnFalse(string input)
        {
            Assert.False(input.IsAlphanumeric());
        }
    }
}
