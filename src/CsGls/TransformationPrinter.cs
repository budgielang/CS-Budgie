using System;
using System.Collections.Generic;
using System.Linq;
using CsGls.Results;

namespace CsGls
{
    /// <summary>
    /// Transforms C#-to-GLS syntax transformations to raw GLS text.
    /// </summary>
    public static class TransformationPrinter
    {
        public static string[] Print(string sourceText, ITransformation transformation)
        {
            var lines = new List<string> { };
            CommandTransformation previous = null;

            foreach (var command in FindCommandTransformations(transformation))
            {
                if (previous != null)
                {
                    var linesDifference = CountEndlinesWithin(sourceText.Substring(previous.Range.End, command.Range.Start - previous.Range.End));

                    for (var j = 0; j < linesDifference - 1; j += 1)
                    {
                        lines.Add("");
                    }
                }

                lines.Add(command.ToString());
                previous = command;
            }

            return lines.ToArray();
        }

        private static int CountEndlinesWithin(string text)
            => text.Split('\n').Length - 1;

        /// <summary>
        /// Recursively searches for <see href="CommandTransformation" />s within a transformations tree.
        /// </summary>
        /// <param name="root">Root node in the transformations tree.</param>
        /// <returns>Ordered comman transformations from the tree.</returns>
        private static IEnumerable<CommandTransformation> FindCommandTransformations(ITransformation root)
        {
            var childTransformation = root as ChildTransformations;
            if (childTransformation == null)
            {
                yield break;
            }

            foreach (var child in childTransformation.Children)
            {
                if (child is CommandTransformation childCommand)
                {
                    yield return childCommand;
                }
                else
                {
                    foreach (var result in FindCommandTransformations(child))
                    {
                        yield return result;
                    }
                }
            }
        }
    }
}