using System;
using CsGls.Transformers;
using Microsoft.CodeAnalysis;

namespace CsGls.Routing
{
    /// <summary>
    /// Transformers for supported syntax node kinds.
    /// </summary>
    public class TransformersBag
    {
        public Lazy<AssignmentExpressionTransformer> AssignmentExpression { get; }
        public Lazy<ClassDeclarationTransformer> ClassDeclaration { get; }
        public Lazy<ElseClauseTransformer> ElseClause { get; }
        public Lazy<IfStatementTransformer> IfStatement { get; }
        public Lazy<InvocationExpressionTransformer> InvocationExpression { get; }
        public Lazy<MethodDeclarationTransformer> MethodDeclaration { get; }
        public Lazy<NamespaceDeclarationTransformer> NamespaceDeclaration { get; }
        public Lazy<PassThroughTransformer> PassThrough { get; }
        public Lazy<WhileStatementTransformer> WhileStatement { get; }

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