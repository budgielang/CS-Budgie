using System.Collections.Generic;
using CsGls.GlsInternals;
using CsGls.Results;
using CsGls.Routing;
using CsGls.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transformers
{
    public class AssignmentExpressionVisitor : INodeVisitor<AssignmentExpressionSyntax>
    {
        private static Dictionary<SyntaxKind, string> OperationCommandNames { get; } = new Dictionary<SyntaxKind, string>
        {
            { SyntaxKind.DivideAssignmentExpression, OperatorNames.DivideBy },
            { SyntaxKind.MultiplyAssignmentExpression, OperatorNames.MultiplyBy },
            { SyntaxKind.SimpleAssignmentExpression, OperatorNames.Equals },
            { SyntaxKind.SubtractAssignmentExpression, OperatorNames.DecreaseBy },
        };

        private readonly SemanticModel Model;
        private readonly NodeVisitRouter Router;

        public AssignmentExpressionVisitor(SemanticModel model, NodeVisitRouter router)
        {
            this.Model = model;
            this.Router = router;
        }

        public ITransformation VisitNode(AssignmentExpressionSyntax node)
        {
            var kind = node.Kind();
            
            if (!OperationCommandNames.ContainsKey(kind))
            {
                return Complaint.ForUnsupportedNode(node);
            }

            return new ChildTransformations(
                new ITransformation[]
                {
                    this.Router.RecurseIntoNode(node.Left),
                    new StringTransformation(OperationCommandNames[kind], Range.ForToken(node.OperatorToken)),
                    this.Router.RecurseIntoNode(node.Right),
                },
                Range.ForNode(node)
            );
        }
    }
}