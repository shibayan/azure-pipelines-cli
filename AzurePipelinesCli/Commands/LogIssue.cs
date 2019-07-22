using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AzurePipelinesCli.Commands
{
    public class LogIssue : Command
    {
        public LogIssue()
            : base("logissue")
        {
            Description = "Log error or warning issue to timeline record of current task.";

            Add(new Option("--sourcepath", "Optional: source file location")
            {
                Argument = new Argument<string>()
            });

            Add(new Option("--linenumber", "Optional: line number")
            {
                Argument = new Argument<int?>()
            });

            Add(new Option("--columnnumber", "Optional: column number")
            {
                Argument = new Argument<int?>()
            });

            Add(new Option("--code", "Optional: error or warning code")
            {
                Argument = new Argument<string>()
            });

            Add(new Argument<string>("type")
            {
                Description = "error or warning"
            });

            Add(new Argument<string>("message")
            {
                Description = "error/warning message"
            });

            Handler = CommandHandler.Create<string, int?, int?, string, string, string>(Execute);
        }

        private void Execute(string sourcepath, int? linenumber, int? columnnumber, string code, string type, string message)
        {
            var command = new PipelineCommandBuilder("task.logissue", message)
                          .AddProperty(nameof(sourcepath), sourcepath)
                          .AddProperty(nameof(linenumber), linenumber)
                          .AddProperty(nameof(columnnumber), columnnumber)
                          .AddProperty(nameof(type), type)
                          .AddProperty(nameof(code), code)
                          .Build();

            Console.WriteLine(command);
        }
    }
}
