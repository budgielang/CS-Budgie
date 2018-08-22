using System;
using System.Collections.Generic;
using System.Linq;
using CsGls.GlsInternals;
using CsGls.Results;
using CsGls.Routing;
using CsGls.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transformers
{
    public class NamespaceDeclarationVisitor : INodeVisitor<NamespaceDeclarationSyntax>
    {
        private readonly string FileName;
        private readonly SemanticModel Model;
        private readonly NodeVisitRouter Router;

        public NamespaceDeclarationVisitor(string fileName, SemanticModel model, NodeVisitRouter router)
        {
            this.FileName = fileName;
            this.Model = model;
            this.Router = router;
        }

        public ITransformation VisitNode(NamespaceDeclarationSyntax node)
            => new ChildTransformations(
                new ITransformation[]
                {
                    new CommandTransformation(
                        CommandNames.FileStart,
                        Range.ForNode(node.Name),
                        this.CreateParametersForName(node.Name)
                    ),
                    this.Router.RecurseIntoNodes(node.Members, node),
                    new CommandTransformation(CommandNames.FileEnd, Range.AfterNode(node))
                },
                Range.ForNode(node)
            );

        private ITransformation[] CreateParametersForName(NameSyntax name)
        {
            var rawParameters = name.ToString().Split('.');
            var parameters = new List<ITransformation>();
            var startIndex = 0;

            foreach (var rawParameter in rawParameters)
            {
                parameters.Add(new StringTransformation(rawParameter, new Range(startIndex, rawParameter.Length)));
                startIndex += rawParameter.Length + 1;
            }

            parameters.Add(new StringTransformation(this.FileName, Range.AfterNode(name)));

            return parameters.ToArray();
        }
    }
}