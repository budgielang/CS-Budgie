using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using CsGls;

namespace CsGls.Test
{
    public class Tests
    {
        [Theory]
        [MemberData(nameof(ReadTestNames), "Integration")]
        public void Integration(string directoryName)
        {
            // Arrange
            var source = File.ReadAllText(Path.Combine(directoryName, "Source.cs"));
            var expected = File.ReadAllText(Path.Combine(directoryName, "Expected.gls"));

            // Act
            var actual = TransformationService.TransformFile("Source.cs", source).GenerateResult();

            // Assert
            #pragma warning disable xUnit2006 // The diffs are better from <string>
            Assert.Equal<string>(expected, actual);
        }

        public static IEnumerable<object[]> ReadTestNames(string type)
        {
            return Directory.GetDirectories($@"..\..\..\Cases\{type}")
                .Select(directory => new object[] { directory });
        }
    }
}
