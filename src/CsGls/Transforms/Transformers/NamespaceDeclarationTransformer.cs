using System.Collections.Generic;
using CsGls.Transforms.Results;
using CsGls.Transforms.Routing;
using CsGls.Transforms.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transforms.Transformers
{
    public class NamespaceDeclarationTransformer : INodeTransformer<NamespaceDeclarationSyntax>
    {
        private readonly SemanticModel Model;
        private readonly TransformerRouter Router;

        public NamespaceDeclarationTransformer(SemanticModel model, TransformerRouter router)
        {
            this.Model = model;
            this.Router = router;
        }

        public ITransformation VisitNode(NamespaceDeclarationSyntax node)
        {
            throw new System.NotImplementedException();
        }
    }
}