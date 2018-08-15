using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CsGls.Transforms.Results
{
    /// <summary>
    /// Source file segment that couldn't be transformed.
    /// </summary>
    public class Complaint : ITransformation
    {
        private readonly string Message;

        /// <summary>
        /// Character range this transformation result applies to.
        /// </summary>
        public Range Range { get; }

        public Complaint(string message, Range range)
        {
            this.Message = message;
            this.Range = range;
        }

        /// <summary>
        /// Accumulates the converted transformation into a result string.
        /// </summary>
        /// <returns>Accumulated transformation as a string.</returns>
        public string GenerateResult() => this.Message;

        /// <summary>
        /// Creates a complaint for a node with unsupported syntax.
        /// </summary>
        /// <param name="node">Node with unsupported syntax.</param>
        public static Complaint ForUnsupportedNode(SyntaxNode node)
            => new Complaint($"Unsupported node syntax kind: {node.Kind()}", Range.ForNode(node));
    }
}