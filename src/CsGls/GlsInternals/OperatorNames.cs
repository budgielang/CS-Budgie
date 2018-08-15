using System.Collections.Generic;
using CsGls.Results;
using CsGls.Routing;
using CsGls.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.GlsInternals
{
    /// <summary>
    /// Static names of known operators.
    /// </summary>
    public class OperatorNames {
        public static readonly string DecreaseBy = "decrease by";
        public static readonly string DivideBy = "divide by";
        public static readonly new string Equals = "equals";
        public static readonly string MultiplyBy = "multiply by";
    }
}
