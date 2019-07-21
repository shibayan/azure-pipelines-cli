using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AzurePipelinesCli.Commands
{
    public class AddBuildTag : Command
    {
        public AddBuildTag()
            : base("addbuildtag")
        {
            Description = "Add a tag for current build.";

            Add(new Argument<string>("tag")
            {
                Description = "build tag"
            });

            Handler = CommandHandler.Create<string>(Execute);
        }

        private void Execute(string path)
        {
            var command = new PipelineCommandBuilder("build.addbuildtag", path).Build();

            Console.WriteLine(command);
        }
    }
}