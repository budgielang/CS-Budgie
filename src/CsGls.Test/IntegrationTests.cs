using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace CsGls.Test
{
    public class IntegrationTests
    {
        private const string DirectoryName = @"..\..\..\Cases\Integration";

        [Fact]
        public void ClassDeclarations()
            => Tests.RunTest(DirectoryName, "Class Declarations");

        [Fact]
        public void While()
            => Tests.RunTest(DirectoryName, "While");
    }
}
