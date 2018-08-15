namespace CsGls.Results
{
    /// <summary>
    /// Raw string generated from a source file.
    /// </summary>
    public class StringTransformation : ITransformation
    {
        /// <summary>
        /// Character range this transformation result applies to.
        /// </summary>
        public Range Range { get; }

        private string Contents { get; }

        public StringTransformation(string contents, Range range)
        {
            this.Contents = contents;
            this.Range = range;
        }

        /// <summary>
        /// Accumulates the converted transformation into a result string.
        /// </summary>
        /// <returns>Accumulated transformation as a string.</returns>
        public string GenerateResult() => this.Contents;
    }
}