using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace CsGls.Test
{
    public static class Tests
    {
        public static void RunTest(string directoryName, string caseName)
        {
            // Arrange
            var sourceText = File.ReadAllText(Path.Combine(directoryName, caseName, "Source.cs"));
            var expected = File.ReadAllText(Path.Combine(directoryName, caseName, "Expected.gls"));

            // Act
            var transformation = TransformationService.TransformFile("Source.cs", sourceText);
            var actual = string.Join(
                Environment.NewLine,
                TransformationPrinter.Print(sourceText, transformation)
            );

            // Assert
            #pragma warning disable xUnit2006 // The diffs are better from <string>
            Assert.Equal<string>(expected, actual);
        }
    }
}
