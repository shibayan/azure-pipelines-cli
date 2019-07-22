using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AzurePipelinesCli.Commands
{
    public class AddAttachment : Command
    {
        public AddAttachment()
            : base("addattachment")
        {
            Description = "Upload and attach attachment to current timeline record.";

            Add(new Argument<string>("type")
            {
                Description = "attachment type"
            });

            Add(new Argument<string>("name")
            {
                Description = "attachment name"
            });

            Add(new Argument<string>("path")
            {
                Description = "local file path"
            });

            Handler = CommandHandler.Create<string, string, string>(Execute);
        }

        private void Execute(string type, string name, string path)
        {
            var command = new PipelineCommandBuilder("task.addattachment", path)
                          .AddProperty(nameof(type), type)
                          .AddProperty(nameof(name), name)
                          .Build();

            Console.WriteLine(command);
        }
    }
}
