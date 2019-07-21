using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AzurePipelinesCli.Commands
{
    public class PrependPath : Command
    {
        public PrependPath()
            : base("prependpath")
        {
            Description = "Instruction for the agent to update the PATH environment variable.";

            Add(new Argument<string>("path")
            {
                Description = "local directory path"
            });

            Handler = CommandHandler.Create<string>(Execute);
        }

        private void Execute(string path)
        {
            var command = new PipelineCommandBuilder("task.prependpath", path).Build();

            Console.WriteLine(command);
        }
    }
}