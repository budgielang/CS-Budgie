using System.Collections.Generic;
using CsGls.Transforms.Results;
using CsGls.Transforms.Routing;
using CsGls.Transforms.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transforms.Transformers
{
    public class PassThroughTransformer : INodeTransformer<SyntaxNode>
    {
        private readonly SemanticModel Model;
        private readonly TransformerRouter Router;

        public PassThroughTransformer(SemanticModel model, TransformerRouter router)
        {
            this.Model = model;
            this.Router = router;
        }

        public ITransformation VisitNode(SyntaxNode node)
        {
            return this.Router.RouteNodes(node.ChildNodes(), node);
        }
    }
}