namespace CsGls.Transforms.Results
{
    /// <summary>
    /// Description of how a range of source file is transformed.
    /// </summary>
    public interface ITransformation
    {
        /// <summary>
        /// Character range this transformation result applies to.
        /// </summary>
        Range Range { get; }

        /// <summary>
        /// Accumulates the converted transformation into a result string.
        /// </summary>
        /// <returns>Accumulated transformation as a string.</returns>
        string GenerateResult();
    }
}