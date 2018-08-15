using System;
using System.Collections.Generic;
using System.Linq;
using CsGls.Results;
using CsGls.Routing;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls
{
    public class TransformationService
    {
        public static ITransformation TransformFile(string fileName, string fileContents)
        {
            var range = new Range(0, fileContents.Length);
            SyntaxTree tree;

            try
            {
                tree = CSharpSyntaxTree.ParseText(fileContents);
            }
            catch (Exception exception)
            {
                return new Complaint(exception.Message, range);
            }

            var router = CreateTransformerRouter(fileName, tree);
            var syntaxTree = (CompilationUnitSyntax)tree.GetRoot();

            return router.RouteNodes(syntaxTree.ChildNodes(), syntaxTree);
        }

        private static TransformerRouter CreateTransformerRouter(string fileName, SyntaxTree syntaxTree)
        {
            var compilation = CSharpCompilation.Create(fileName)
                .AddReferences(
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddSyntaxTrees(syntaxTree);
            var model = compilation.GetSemanticModel(syntaxTree);

            return new TransformerRouter(fileName, model);
        }
    }
}
