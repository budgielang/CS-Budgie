using System.Collections.Generic;
using CsGls.GlsInternals;
using CsGls.Results;
using CsGls.Routing;
using CsGls.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transformers
{
    public class IfStatementVisitor : INodeVisitor<IfStatementSyntax>
    {
        private readonly SemanticModel Model;
        private readonly NodeVisitRouter Router;

        public IfStatementVisitor(SemanticModel model, NodeVisitRouter router)
        {
            this.Model = model;
            this.Router = router;
        }

        public ITransformation VisitNode(IfStatementSyntax node)
        {
            var transformations = new List<ITransformation>();

            if (node.Else != null)
            {
                transformations.Add(this.Router.RecurseIntoNode(node.Else));
            }

            transformations.Add(new CommandTransformation(CommandNames.IfEnd, Range.AfterNode(node)));

            return new ChildTransformations(
                new ITransformation[]
                {
                    new CommandTransformation(
                        CommandNames.IfStart,
                        Range.ForNode(node.Condition),
                        this.Router.RecurseIntoNode(node.Condition)),
                    this.Router.RecurseIntoNode(node.Statement),
                },
                Range.ForNode(node)
            );
        }
    }
}