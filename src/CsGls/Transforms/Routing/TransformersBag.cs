using System;
using CsGls.Transforms.Transformers;

namespace CsGls.Transforms.Routing
{
    /// <summary>
    /// Transformers for supported syntax node kinds.
    /// </summary>
    public class TransformersBag
    {
        private readonly TransformerRouter Router;

        public readonly Lazy<WhileStatementTransformer> WhileStatement;

        public TransformersBag(TransformerRouter router)
        {
            this.Router = router;

            this.WhileStatement = new Lazy<WhileStatementTransformer>(
                () => new WhileStatementTransformer(this.Router));
        }
    }
}