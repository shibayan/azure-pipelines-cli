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

            Add(new Option("--type", "error or warning (Required)")
            {
                Argument = new Argument<string>()
            });

            Add(new Option("--sourcepath", "source file location")
            {
                Argument = new Argument<string>()
            });

            Add(new Option("--linenumber", "line number")
            {
                Argument = new Argument<int?>()
            });

            Add(new Option("--columnnumber", "column number")
            {
                Argument = new Argument<int?>()
            });

            Add(new Option("--code", "error or warning code")
            {
                Argument = new Argument<string>()
            });

            Add(new Argument<string>("message")
            {
                Description = "error/warning message"
            });

            Handler = CommandHandler.Create<string, string, int?, int?, string, string>(Execute);
        }

        private void Execute(string type, string sourcepath, int? linenumber, int? columnnumber, string code, string message)
        {
            var command = new PipelineCommandBuilder("task.logissue", message)
                          .AddProperty(nameof(type), type)
                          .AddProperty(nameof(sourcepath), sourcepath)
                          .AddProperty(nameof(linenumber), linenumber)
                          .AddProperty(nameof(columnnumber), columnnumber)
                          .AddProperty(nameof(code), code)
                          .Build();

            Console.WriteLine(command);
        }
    }
}
