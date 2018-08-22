using System.Collections.Generic;
using CsGls.GlsInternals;
using CsGls.Results;
using CsGls.Routing;
using CsGls.Transformers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CsGls.Transformers
{
    public class ClassDeclarationVisitor : INodeVisitor<ClassDeclarationSyntax>
    {
        private readonly SemanticModel Model;
        private readonly NodeVisitRouter Router;

        public ClassDeclarationVisitor(SemanticModel model, NodeVisitRouter router)
        {
            this.Model = model;
            this.Router = router;
        }

        public ITransformation VisitNode(ClassDeclarationSyntax node)
        {
            var parameters = new List<ITransformation>();

            parameters.AddRange(this.CreateModifiersList(node.Modifiers));
            parameters.Add(new StringTransformation(node.Identifier.Text, Range.ForToken(node.Identifier)));

            if (node.BaseList != null)
            {
                parameters.AddRange(this.CreateBasesList(node.BaseList));
            }

            return new ChildTransformations(
                new ITransformation[]
                {
                    new CommandTransformation(
                        CommandNames.ClassStart,
                        Range.ForToken(node.Keyword),
                        parameters.ToArray()
                    ),
                    this.Router.RecurseIntoNodes(node.Members, node),
                    new CommandTransformation(CommandNames.ClassEnd, Range.AfterNode(node))
                },
                Range.ForNode(node)
            );
        }

        private IEnumerable<ITransformation> CreateModifiersList(SyntaxTokenList modifiers)
        {
            var transformations = new List<ITransformation>();

            foreach (var modifier in modifiers)
            {
                if (modifier.Text == "public")
                {
                    transformations.Insert(0, new StringTransformation("export", Range.ForToken(modifier)));
                }
                else if (modifier.Text == "abstract")
                {
                    transformations.Add(new StringTransformation("abstract", Range.ForToken(modifier)));
                }
            }

            return transformations;
        }

        private IEnumerable<ITransformation> CreateBasesList(BaseListSyntax baseList)
        {
            var transformations = new List<ITransformation>();
            var implements = new List<ITransformation>();

            foreach (var baseType in baseList.Types)
            {
                implements.Add(new StringTransformation(baseType.ToString(), Range.ForNode(baseType)));
            }

            if (implements.Count != 0)
            {
                transformations.Add(new StringTransformation("implements", Range.ForToken(baseList.ColonToken)));
                transformations.AddRange(implements);
            }

            return transformations;
        }
    }
}