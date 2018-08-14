namespace CsGls.Transforms.Results
{
    /// <summary>
    /// Integer range of characters within a source file.
    /// </summary>
    public class Range
    {
        public Range(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public int End { get; }

        public int Start { get; }
    }
}