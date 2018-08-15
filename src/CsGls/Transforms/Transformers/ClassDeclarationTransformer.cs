using System.Collections.Generic;
using CsGls.GlsInternals;
using CsGls.Transforms.Results;
using CsGls.Transforms.Routing;
using CsGls.Transforms.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transforms.Transformers
{
    public class ClassDeclarationTransformer : INodeTransformer<ClassDeclarationSyntax>
    {
        private readonly SemanticModel Model;
        private readonly TransformerRouter Router;

        public ClassDeclarationTransformer(SemanticModel model, TransformerRouter router)
        {
            this.Model = model;
            this.Router = router;
        }

        public ITransformation VisitNode(ClassDeclarationSyntax node)
        {
            // TODO: extends, implements, etc. - should file issue?

            return new ChildTransformations(
                new ITransformation[]
                {
                    new CommandTransformation(CommandNames.ClassStart, Range.ForToken(node.Keyword)),
                    this.Router.RouteNodes(node.Members, node),
                    new CommandTransformation(CommandNames.ClassEnd, Range.AfterNode(node))
                },
                Range.ForNode(node)
            );
        }
    }
}