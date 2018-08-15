using System.Collections.Generic;
using CsGls.GlsInternals;
using CsGls.Transforms.Results;
using CsGls.Transforms.Routing;
using CsGls.Transforms.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transforms.Transformers
{
    public class ElseClauseTransformer : INodeTransformer<ElseClauseSyntax>
    {
        private readonly SemanticModel Model;
        private readonly TransformerRouter Router;

        public ElseClauseTransformer(SemanticModel model, TransformerRouter router)
        {
            this.Model = model;
            this.Router = router;
        }

        public ITransformation VisitNode(ElseClauseSyntax node)
        {
            return node.Statement is IfStatementSyntax
                ? this.VisitElseIfStart(node)
                : this.VisitElseStart(node);
        }

        private ITransformation VisitElseIfStart(ElseClauseSyntax node)
            => new ChildTransformations(
                new ITransformation[]
                {
                    new CommandTransformation(
                        CommandNames.ElseIfStart,
                        Range.ForNode(node.Statement)),
                    this.Router.RouteNode(node.Statement)
                },
                Range.ForNode(node)
            );

        private ITransformation VisitElseStart(ElseClauseSyntax node)
            => new ChildTransformations(
                new ITransformation[]
                {
                    new CommandTransformation(
                        CommandNames.ElseStart,
                        Range.ForNode(node.Statement)),
                    this.Router.RouteNode(node.Statement)
                },
                Range.ForNode(node)
            );
    }
}