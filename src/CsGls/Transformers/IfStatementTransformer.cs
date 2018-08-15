using System.Collections.Generic;
using CsGls.GlsInternals;
using CsGls.Results;
using CsGls.Routing;
using CsGls.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transformers
{
    public class IfStatementTransformer : INodeTransformer<IfStatementSyntax>
    {
        private readonly SemanticModel Model;
        private readonly TransformerRouter Router;

        public IfStatementTransformer(SemanticModel model, TransformerRouter router)
        {
            this.Model = model;
            this.Router = router;
        }

        public ITransformation VisitNode(IfStatementSyntax node)
        {
            var transformations = new List<ITransformation>();

            if (node.Else != null)
            {
                transformations.Add(this.Router.RouteNode(node.Else));
            }

            transformations.Add(new CommandTransformation(CommandNames.IfEnd, Range.AfterNode(node)));

            return new ChildTransformations(
                new ITransformation[]
                {
                    new CommandTransformation(
                        CommandNames.IfStart,
                        Range.ForNode(node.Condition),
                        this.Router.RouteNode(node.Condition)),
                    this.Router.RouteNode(node.Statement),
                },
                Range.ForNode(node)
            );
        }
    }
}