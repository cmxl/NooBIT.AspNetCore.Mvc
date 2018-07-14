using System;
using NooBIT.AspNetCore.Mvc.Helpers;
using Xunit;

namespace NooBIT.AspNetCore.Mvc.Tests
{
    public class MiddlewareTests
    {
        [Fact]
        public void FOo()
        {
            string bar = null;
            var exception = Assert.Throws<ArgumentNullException>(() => bar.ThrowIfNull());
            Assert.Equal("bar", exception.ParamName);
            
        }
    }
}