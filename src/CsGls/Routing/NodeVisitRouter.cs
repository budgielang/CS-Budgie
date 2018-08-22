using System;
using System.Collections.Generic;
using CsGls.Results;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Routing
{
    /// <summary>
    /// Routes syntax node visits through the appropriate transformers. 
    /// </summary>
    public class NodeVisitRouter
    {
        /// <summary>
        /// Transformers for supported syntax node kinds.
        /// </summary>
        private readonly VisitorsBag TransformersBag;

        public NodeVisitRouter(string fileName, SemanticModel model)
        {
            this.TransformersBag = new VisitorsBag(fileName, model, this);
        }

        /// <summary>
        /// Routes a syntax node visit through the appropriate transformer.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public ITransformation RecurseIntoNode(SyntaxNode node)
        {
            switch (node.Kind())
            {
                case SyntaxKind.AddExpression:
                case SyntaxKind.SubtractExpression:
                case SyntaxKind.MultiplyExpression:
                case SyntaxKind.DivideAssignmentExpression:
                case SyntaxKind.LessThanExpression:
                case SyntaxKind.EqualsExpression:
                case SyntaxKind.GreaterThanExpression:
                    return this.TransformersBag.AssignmentExpression.Value.VisitNode((AssignmentExpressionSyntax)node);

                case SyntaxKind.ClassDeclaration:
                    return this.TransformersBag.ClassDeclaration.Value.VisitNode((ClassDeclarationSyntax)node);

                case SyntaxKind.ElseClause:
                    return this.TransformersBag.ElseClause.Value.VisitNode((ElseClauseSyntax)node);

                case SyntaxKind.IfStatement:
                    return this.TransformersBag.IfStatement.Value.VisitNode((IfStatementSyntax)node);

                case SyntaxKind.InvocationExpression:
                    return this.TransformersBag.InvocationExpression.Value.VisitNode((InvocationExpressionSyntax)node);

                case SyntaxKind.MethodDeclaration:
                    return this.TransformersBag.MethodDeclaration.Value.VisitNode((MethodDeclarationSyntax)node);

                case SyntaxKind.NamespaceDeclaration:
                    return this.TransformersBag.NamespaceDeclaration.Value.VisitNode((NamespaceDeclarationSyntax)node);

                case SyntaxKind.WhileStatement:
                    return this.TransformersBag.WhileStatement.Value.VisitNode((WhileStatementSyntax)node);
            }

            return Complaint.ForUnsupportedNode(node);
        }

        public ITransformation RecurseIntoNodes(IEnumerable<SyntaxNode> nodes, SyntaxNode parent)
        {
            var range = Range.ForNode(parent);
            var start = int.MaxValue;
            var end = int.MinValue;
            var transformations = new List<ITransformation>();

            foreach (var node in nodes)
            {
                var transformation = this.RecurseIntoNode(node);
                start = Math.Min(start, transformation.Range.Start);
                end = Math.Max(start, transformation.Range.End);
                transformations.Add(this.RecurseIntoNode(node));
            }

            range = start == int.MaxValue
                ? Range.ForNode(parent)
                : new Range(start, end);

            return new ChildTransformations(transformations.ToArray(), range);
        }
    }
}