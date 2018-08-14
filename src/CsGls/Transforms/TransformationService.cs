using System;
using System.Collections.Generic;
using System.Linq;
using CsGls.Transforms.Results;
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

            var compilation = CSharpCompilation.Create(fileName)
                .AddReferences(
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddSyntaxTrees(tree);
            var model = compilation.GetSemanticModel(tree);
            var root = (CompilationUnitSyntax)tree.GetRoot();

            var transforms = new List<ITransformation>();

            foreach (var childNode in root.ChildNodes())
            {
                transforms.Add(TransformationService.TransformNode(childNode, model));
            }

            return new ChildTransformations(transforms.ToArray(), range);
        }

        private static ITransformation TransformNode(SyntaxNode node, SemanticModel model)
        {

        }
    }
}
