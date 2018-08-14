using CommandLine;
using System;

namespace CsGls.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new CommandLineParser();
            var options = new Options();
            var result = parser.ParseArguments(args, options);

            Console.WriteLine("Hello World! " + options.Help);
        }
    }
}
