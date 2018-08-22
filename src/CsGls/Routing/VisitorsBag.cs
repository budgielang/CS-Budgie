using System;
using CsGls.Transformers;
using Microsoft.CodeAnalysis;

namespace CsGls.Routing
{
    /// <summary>
    /// Transformers for supported syntax node kinds.
    /// </summary>
    public class VisitorsBag
    {
        public Lazy<AssignmentExpressionVisitor> AssignmentExpression { get; }
        public Lazy<ClassDeclarationVisitor> ClassDeclaration { get; }
        public Lazy<ElseClauseVisitor> ElseClause { get; }
        public Lazy<IfStatementVisitor> IfStatement { get; }
        public Lazy<InvocationExpressionVisitor> InvocationExpression { get; }
        public Lazy<MethodDeclarationVisitor> MethodDeclaration { get; }
        public Lazy<NamespaceDeclarationVisitor> NamespaceDeclaration { get; }
        public Lazy<PassThroughVisitor> PassThrough { get; }
        public Lazy<WhileStatementVisitor> WhileStatement { get; }

        public VisitorsBag(string fileName, SemanticModel model, NodeVisitRouter router)
        {
            this.AssignmentExpression = new Lazy<AssignmentExpressionVisitor>(
                () => new AssignmentExpressionVisitor(model, router));

            this.ClassDeclaration = new Lazy<ClassDeclarationVisitor>(
                () => new ClassDeclarationVisitor(model, router));

            this.ElseClause = new Lazy<ElseClauseVisitor>(
                () => new ElseClauseVisitor(model, router));

            this.IfStatement = new Lazy<IfStatementVisitor>(
                () => new IfStatementVisitor(model, router));

            this.InvocationExpression = new Lazy<InvocationExpressionVisitor>(
                () => new InvocationExpressionVisitor(model, router));

            this.MethodDeclaration = new Lazy<MethodDeclarationVisitor>(
                () => new MethodDeclarationVisitor(model, router));

            this.NamespaceDeclaration = new Lazy<NamespaceDeclarationVisitor>(
                () => new NamespaceDeclarationVisitor(fileName, model, router));

            this.PassThrough = new Lazy<PassThroughVisitor>(
                () => new PassThroughVisitor(model, router));

            this.WhileStatement = new Lazy<WhileStatementVisitor>(
                () => new WhileStatementVisitor(model, router));
        }
    }
}