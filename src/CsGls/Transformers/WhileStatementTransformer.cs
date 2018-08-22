using System.Collections.Generic;
using CsGls.GlsInternals;
using CsGls.Results;
using CsGls.Routing;
using CsGls.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transformers
{
    public class WhileStatementVisitor : INodeVisitor<WhileStatementSyntax>
    {
        private readonly SemanticModel Model;
        private readonly NodeVisitRouter Router;

        public WhileStatementVisitor(SemanticModel model, NodeVisitRouter router)
        {
            this.Model = model;
            this.Router = router;
        }

        public ITransformation VisitNode(WhileStatementSyntax node)
        {
            return new ChildTransformations(
                new ITransformation[]
                {
                    new CommandTransformation(
                        CommandNames.WhileStart,
                        Range.ForNode(node.Condition),
                        this.Router.RecurseIntoNode(node.Condition)
                    ),
                    this.Router.RecurseIntoNode(node.Statement),
                    new CommandTransformation(
                        CommandNames.WhileEnd,
                        Range.AfterNode(node)
                    )
                },
                Range.ForNode(node)
            );
        }
    }
}