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
        public ITransformation[] Children { get; }

        /// <summary>
        /// Character range this transformation result applies to.
        /// </summary>
        public Range Range { get; }

        public ChildTransformations(ITransformation[] children, Range range)
        {
            this.Children = children;
            this.Range = range;
        }
    }
}