using CsGls.Results;
using Microsoft.CodeAnalysis;

namespace CsGls.Transformers
{
    /// <summary>
    /// Transforms a type of node to <see href="ITransformation" />s.
    /// </summary>
    /// <typeparam name="TNode">Type of <see href="SyntaxNode" /> to transform.</typeparam>
    public interface INodeTransformer<TNode> where TNode : SyntaxNode 
    {
        /// <summary>
        /// Transforms a node.
        /// </summary>
        /// <param name="node">Node to transform.</param>
        /// <returns>Transformed equivalent of the node.</returns>
        ITransformation VisitNode(TNode node);
    }
}