using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AzurePipelinesCli.Commands
{
    public class UploadSummary : Command
    {
        public UploadSummary()
            : base("uploadsummary")
        {
            Description = "Upload and attach summary markdown to current timeline record.";

            Add(new Argument<string>("path")
            {
                Description = "local file path"
            });

            Handler = CommandHandler.Create<string>(Execute);
        }

        private void Execute(string path)
        {
            var command = new PipelineCommandBuilder("task.uploadsummary", path).Build();

            Console.WriteLine(command);
        }
    }
}