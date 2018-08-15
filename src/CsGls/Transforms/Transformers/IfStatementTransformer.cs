using System.Collections.Generic;
using CsGls.Transforms.Results;
using CsGls.Transforms.Routing;
using CsGls.Transforms.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transforms.Transformers
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
            throw new System.NotImplementedException();
        }
    }
}