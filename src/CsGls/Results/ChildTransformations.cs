using System;
using System.Linq;
using System.Text;

namespace CsGls.Results
{
    /// <summary>
    /// Multiple transformations in series.
    /// </summary>
    public class ChildTransformations : ITransformation
    {
        /// <summary>
        /// Child transformations within this transformation.
        /// </summary>
        private readonly ITransformation[] Children;

        /// <summary>
        /// Character range this transformation result applies to.
        /// </summary>
        public Range Range { get; }

        public ChildTransformations(ITransformation[] children, Range range)
        {
            this.Children = children;
            this.Range = range;
        }

        /// <summary>
        /// Accumulates the converted transformation into a result string.
        /// </summary>
        /// <returns>Accumulated transformation as a string.</returns>
        public string GenerateResult()
        {
            return string.Join(
                Environment.NewLine,
                this.Children
                    .Select(child => child.GenerateResult()
                )
            );
        }
    }
}