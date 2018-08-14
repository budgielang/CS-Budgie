using CommandLine;
using System;

namespace CsGls.Cli
{
    public class Options
    {
        [Option("h", "help", Required = false, HelpText = "Display the help dialog.")]
        public bool Help { get; set; }
    }
}
