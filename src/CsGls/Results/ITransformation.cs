namespace CsGls.Results
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
    }
}