namespace CsGls.Transforms.Results
{
    /// <summary>
    /// Source file segment that couldn't be transformed.
    /// </summary>
    public class Complaint : ITransformation
    {
        private readonly string Message;

        /// <summary>
        /// Character range this transformation result applies to.
        /// </summary>
        public Range Range { get; }

        public Complaint(string message, Range range)
        {
            this.Message = message;
            this.Range = range;
        }

        /// <summary>
        /// Accumulates the converted transformation into a result string.
        /// </summary>
        /// <returns>Accumulated transformation as a string.</returns>
        public string GenerateResult() => this.Message;
    }
}