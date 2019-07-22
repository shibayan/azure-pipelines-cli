using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AzurePipelinesCli.Commands
{
    public class Upload : Command
    {
        public Upload()
            : base("upload")
        {
            Description = "Upload local file into a file container folder, create artifact if artifactname provided.";

            Add(new Option("--artifactname", "Optional: artifact name")
            {
                Argument = new Argument<string>()
            });

            Add(new Argument<string>("containerfolder")
            {
                Description = "folder that the file will upload to, folder will be created if needed."
            });

            Add(new Argument<string>("path")
            {
                Description = "local file path"
            });

            Handler = CommandHandler.Create<string, string, string>(Execute);
        }

        private void Execute(string artifactname, string containerfolder, string path)
        {
            var command = new PipelineCommandBuilder("artifact.upload", path)
                          .AddProperty(nameof(containerfolder), containerfolder)
                          .AddProperty(nameof(artifactname), artifactname)
                          .Build();

            Console.WriteLine(command);
        }
    }
}
