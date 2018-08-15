using System.Collections.Generic;
using CsGls.Results;
using CsGls.Routing;
using CsGls.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transformers
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