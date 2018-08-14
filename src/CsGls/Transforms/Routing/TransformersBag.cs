using System;
using CsGls.Transforms.Transformers;
using Microsoft.CodeAnalysis;

namespace CsGls.Transforms.Routing
{
    /// <summary>
    /// Transformers for supported syntax node kinds.
    /// </summary>
    public class TransformersBag
    {
        private readonly SemanticModel Model;
        private readonly TransformerRouter Router;
        public readonly Lazy<WhileStatementTransformer> WhileStatement;

        public TransformersBag(SemanticModel model, TransformerRouter router)
        {
            this.Model = model;
            this.Router = router;

            this.WhileStatement = new Lazy<WhileStatementTransformer>(
                () => new WhileStatementTransformer(this.Model, this.Router));
        }
    }
}