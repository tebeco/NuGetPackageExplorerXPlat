using System;
using Xunit;
using FluentAssertions;

namespace NugetPackageExplorerXPlat.Tests
{
    public class RemoveThisFile
    {
        [Fact]
        public void RemoveThisTest()
        {
            //just to be sure no engine would fail over 0 tests ran
            true.Should().BeTrue();
        }
    }
}
