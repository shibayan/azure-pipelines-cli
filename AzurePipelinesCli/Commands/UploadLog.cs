using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AzurePipelinesCli.Commands
{
    public class UploadLog : Command
    {
        public UploadLog()
            : base("uploadlog")
        {
            Description = "Upload user interested log to build’s container \"logs\\tool\" folder.";

            Add(new Argument<string>("path")
            {
                Description = "local file path"
            });

            Handler = CommandHandler.Create<string>(Execute);
        }

        private void Execute(string path)
        {
            var command = new PipelineCommandBuilder("build.uploadlog", path).Build();

            Console.WriteLine(command);
        }
    }
}
