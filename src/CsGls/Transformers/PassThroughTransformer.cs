using System.Collections.Generic;
using CsGls.Results;
using CsGls.Routing;
using CsGls.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transformers
{
    public class PassThroughVisitor : INodeVisitor<SyntaxNode>
    {
        private readonly SemanticModel Model;
        private readonly NodeVisitRouter Router;

        public PassThroughVisitor(SemanticModel model, NodeVisitRouter router)
        {
            this.Model = model;
            this.Router = router;
        }

        public ITransformation VisitNode(SyntaxNode node)
        {
            return this.Router.RecurseIntoNodes(node.ChildNodes(), node);
        }
    }
}