using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AzurePipelinesCli.Commands
{
    public class UpdateReleaseName : Command
    {
        public UpdateReleaseName()
            : base("updatereleasename")
        {
            Description = "Update release name for current release.";

            Add(new Argument<string>("name")
            {
                Description = "release name"
            });

            Handler = CommandHandler.Create<string>(Execute);
        }

        private void Execute(string path)
        {
            var command = new PipelineCommandBuilder("release.updatereleasename", path).Build();

            Console.WriteLine(command);
        }
    }
}