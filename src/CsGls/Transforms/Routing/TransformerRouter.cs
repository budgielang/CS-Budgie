using CsGls.Transforms.Results;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transforms.Routing
{
    /// <summary>
    /// Routes syntax node visits through the appropriate transformers. 
    /// </summary>
    public class TransformerRouter
    {
        /// <summary>
        /// Transformers for supported syntax node kinds.
        /// </summary>
        private readonly TransformersBag TransformersBag;

        public TransformerRouter()
        {
            this.TransformersBag = new TransformersBag(this);
        }

        /// <summary>
        /// Routes a syntax node visit through the appropriate transformer.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public ITransformation RouteNode(SyntaxNode node)
        {
            var kind = node.Kind();

            switch (kind)
            {
                case SyntaxKind.WhileStatement:
                    return this.TransformersBag.WhileStatement.Value.VisitNode((WhileStatementSyntax)node);
            }

            return new Complaint($"Unsupported node kind: {kind}", new Range(node.SpanStart, node.Span.End));
        }
    }
}