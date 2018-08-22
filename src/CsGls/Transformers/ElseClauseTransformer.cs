using System.Collections.Generic;
using CsGls.GlsInternals;
using CsGls.Results;
using CsGls.Routing;
using CsGls.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transformers
{
    public class ElseClauseVisitor : INodeVisitor<ElseClauseSyntax>
    {
        private readonly SemanticModel Model;
        private readonly NodeVisitRouter Router;

        public ElseClauseVisitor(SemanticModel model, NodeVisitRouter router)
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
                    this.Router.RecurseIntoNode(node.Statement)
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
                    this.Router.RecurseIntoNode(node.Statement)
                },
                Range.ForNode(node)
            );
    }
}