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
        private Lazy<AssignmentExpressionTransformer> AssignmentExpression { get; }
        private Lazy<ClassDeclarationTransformer> ClassDeclaration { get; }
        private Lazy<ElseClauseTransformer> ElseClause { get; }
        private Lazy<IfStatementTransformer> IfStatement { get; }
        private Lazy<InvocationExpressionTransformer> InvocationExpression { get; }
        private Lazy<MethodDeclarationTransformer> MethodDeclaration { get; }
        private Lazy<NamespaceDeclarationTransformer> NamespaceDeclaration { get; }
        private Lazy<PassThroughTransformer> PassThrough { get; }
        private Lazy<WhileStatementTransformer> WhileStatement { get; }

        public TransformersBag(string fileName, SemanticModel model, TransformerRouter router)
        {
            this.AssignmentExpression = new Lazy<AssignmentExpressionTransformer>(
                () => new AssignmentExpressionTransformer(model, router));

            this.ClassDeclaration = new Lazy<ClassDeclarationTransformer>(
                () => new ClassDeclarationTransformer(model, router));

            this.ElseClause = new Lazy<ElseClauseTransformer>(
                () => new ElseClauseTransformer(model, router));

            this.IfStatement = new Lazy<IfStatementTransformer>(
                () => new IfStatementTransformer(model, router));

            this.InvocationExpression = new Lazy<InvocationExpressionTransformer>(
                () => new InvocationExpressionTransformer(model, router));

            this.MethodDeclaration = new Lazy<MethodDeclarationTransformer>(
                () => new MethodDeclarationTransformer(model, router));

            this.NamespaceDeclaration = new Lazy<NamespaceDeclarationTransformer>(
                () => new NamespaceDeclarationTransformer(fileName, model, router));

            this.PassThrough = new Lazy<PassThroughTransformer>(
                () => new PassThroughTransformer(model, router));

            this.WhileStatement = new Lazy<WhileStatementTransformer>(
                () => new WhileStatementTransformer(model, router));
        }
    }
}