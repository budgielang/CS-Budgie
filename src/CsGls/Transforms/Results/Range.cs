using Microsoft.CodeAnalysis;

namespace CsGls.Transforms.Results
{
    /// <summary>
    /// Integer range of characters within a source file.
    /// </summary>
    public class Range
    {
        public Range(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public int End { get; }

        public int Start { get; }

        public static Range ForNode(SyntaxNode node)
            => new Range(node.SpanStart, node.Span.End);
    }
}