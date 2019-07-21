using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AzurePipelinesCli.Commands
{
    public class UploadFile : Command
    {
        public UploadFile()
            : base("uploadfile")
        {
            Description = "Upload user interested file as additional log information to the current timeline record.";

            Add(new Argument<string>("path")
            {
                Description = "local file path"
            });

            Handler = CommandHandler.Create<string>(Execute);
        }

        private void Execute(string path)
        {
            var command = new PipelineCommandBuilder("task.uploadfile", path).Build();

            Console.WriteLine(command);
        }
    }
}