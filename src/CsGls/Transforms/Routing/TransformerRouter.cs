using System;
using System.Collections.Generic;
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

        public TransformerRouter(SemanticModel model)
        {
            this.TransformersBag = new TransformersBag(model, this);
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

            return new Complaint($"Unsupported node kind: {kind}", Range.ForNode(node));
        }

        public ITransformation RouteNodes(IEnumerable<SyntaxNode> nodes, SyntaxNode parent)
        {
            var range = Range.ForNode(parent);
            var start = int.MaxValue;
            var end = int.MinValue;
            var transformations = new List<ITransformation>();

            foreach (var node in nodes)
            {
                var transformation = this.RouteNode(node);
                start = Math.Min(start, transformation.Range.Start);
                end = Math.Max(start, transformation.Range.End);
                transformations.Add(this.RouteNode(node));
            }

            range = start == int.MaxValue
                ? Range.ForNode(parent)
                : new Range(start, end);

            return new ChildTransformations(transformations.ToArray(), range);
        }
    }
}