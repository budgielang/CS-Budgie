using System;
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

        /// <summary>
        /// Generates a range that spans the last character of a node.
        /// </summary>
        /// <param name="nodes">Node to span a range at the end of.</param>
        public static Range AfterNode(SyntaxNode node)
            => new Range(node.Span.End - 1, node.Span.End);

        /// <summary>
        /// Generates a range that spans across a node.
        /// </summary>
        /// <param name="nodes">Node to span a range across.</param>
        public static Range ForNode(SyntaxNode node)
            => new Range(node.SpanStart, node.Span.End);

        /// <summary>
        /// Generates a range that spans across multiple nodes.
        /// </summary>
        /// <param name="nodes">Ordered nodes to span a range across.</param>
        public static Range ForNodes(params SyntaxNode[] nodes)
            => nodes.Length == 0
                ? throw new ArgumentException("No nodes provided.")
                : new Range(nodes[0].SpanStart, nodes[1].Span.End);
        
    }
}