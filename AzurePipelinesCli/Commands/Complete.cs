using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AzurePipelinesCli.Commands
{
    public class Complete : Command
    {
        public Complete()
            : base("complete")
        {
            Description = "Finish timeline record for current task, set task result and current operation.";

            Add(new Option("--result", "Optional: Succeeded|SucceededWithIssues|Failed|Canceled|Skipped")
            {
                Argument = new Argument<string>()
            });

            Add(new Argument<string>("operation")
            {
                Description = "current operation"
            });

            Handler = CommandHandler.Create<string, string>(Execute);
        }

        private void Execute(string result, string operation)
        {
            var command = new PipelineCommandBuilder("task.complete", operation)
                          .AddProperty(nameof(result), result)
                          .Build();

            Console.WriteLine(command);
        }
    }
}
