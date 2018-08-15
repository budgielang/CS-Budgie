using System.Collections.Generic;
using CsGls.GlsInternals;
using CsGls.Transforms.Results;
using CsGls.Transforms.Routing;
using CsGls.Transforms.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transforms.Transformers
{
    public class AssignmentExpressionTransformer : INodeTransformer<AssignmentExpressionSyntax>
    {
        private static Dictionary<SyntaxKind, string> OperationCommandNames { get; } = new Dictionary<SyntaxKind, string>
        {
            { SyntaxKind.DivideAssignmentExpression, OperatorNames.DivideBy },
            { SyntaxKind.MultiplyAssignmentExpression, OperatorNames.MultiplyBy },
            { SyntaxKind.SimpleAssignmentExpression, OperatorNames.Equals },
            { SyntaxKind.SubtractAssignmentExpression, OperatorNames.DecreaseBy },
        };

        private readonly SemanticModel Model;
        private readonly TransformerRouter Router;

        public AssignmentExpressionTransformer(SemanticModel model, TransformerRouter router)
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
                    this.Router.RouteNode(node.Left),
                    new StringTransformation(OperationCommandNames[kind], Range.ForToken(node.OperatorToken)),
                    this.Router.RouteNode(node.Right),
                },
                Range.ForNode(node)
            );
        }
    }
}