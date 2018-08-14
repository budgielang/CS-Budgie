using System.Text;

namespace CsGls.Transforms.Results
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
            var stringBuilder = new StringBuilder();

            foreach (var child in this.Children)
            {
                stringBuilder.Append(child.GenerateResult());
            }

            return stringBuilder.ToString();
        }
    }
}