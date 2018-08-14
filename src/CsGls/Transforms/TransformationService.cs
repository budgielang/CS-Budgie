using System;
using System.Collections.Generic;
using System.Linq;
using CsGls.Transforms.Results;
using CsGls.Transforms.Routing;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transforms
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

            var router = CreateTransformerRouter(tree, fileName);
            var root = (CompilationUnitSyntax)tree.GetRoot();

            return router.RouteNodes(root.ChildNodes(), root);
        }

        private static TransformerRouter CreateTransformerRouter(SyntaxTree tree, string fileName)
        {
            var compilation = CSharpCompilation.Create(fileName)
                .AddReferences(
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddSyntaxTrees(tree);
            var model = compilation.GetSemanticModel(tree);

            return new TransformerRouter(model);
        }
    }
}
