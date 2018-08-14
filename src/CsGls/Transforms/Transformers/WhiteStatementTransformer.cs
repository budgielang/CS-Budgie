using System.Collections.Generic;
using CsGls.Transforms.Results;
using CsGls.Transforms.Routing;
using CsGls.Transforms.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transforms.Transformers
{
    public class WhileStatementTransformer : INodeTransformer<WhileStatementSyntax>
    {
        private readonly TransformerRouter Router;

        public WhileStatementTransformer(TransformerRouter router)
        {
            this.Router = router;
        }

        public ITransformation VisitNode(WhileStatementSyntax node)
        {
            throw new System.NotImplementedException();
        }
    }
}