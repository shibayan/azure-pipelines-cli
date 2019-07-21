using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AzurePipelinesCli.Commands
{
    public class SetProgress : Command
    {
        public SetProgress()
            : base("setprogress")
        {
            Description = "Set progress and current operation for current task.";

            Add(new Option("--value", "percentage of completion")
            {
                Argument = new Argument<int>()
            });

            Add(new Argument<string>("operation")
            {
                Description = "current operation"
            });

            Handler = CommandHandler.Create<int, string>(Execute);
        }

        private void Execute(int value, string operation)
        {
            var command = new PipelineCommandBuilder("task.setprogress", operation)
                          .AddProperty(nameof(value), value)
                          .Build();

            Console.WriteLine(command);
        }
    }
}
