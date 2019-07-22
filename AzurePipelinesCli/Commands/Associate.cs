using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AzurePipelinesCli.Commands
{
    public class Associate : Command
    {
        public Associate()
            : base("associate")
        {
            Description = "Create an artifact link, artifact location is required to be a file container path, VC path or UNC share path.";

            Add(new Argument<string>("artifactname")
            {
                Description = "artifact name"
            });

            Add(new Argument<string>("type")
            {
                Description = "container|filepath|versioncontrol|gitref|tfvclabel, artifact type"
            });

            Add(new Argument<string>("location")
            {
                Description = "artifact location"
            });

            Handler = CommandHandler.Create<string, string, string>(Execute);
        }

        private void Execute(string artifactname, string type, string location)
        {
            var command = new PipelineCommandBuilder("artifact.associate", location)
                          .AddProperty(nameof(artifactname), artifactname)
                          .AddProperty(nameof(type), type)
                          .Build();

            Console.WriteLine(command);
        }
    }
}
