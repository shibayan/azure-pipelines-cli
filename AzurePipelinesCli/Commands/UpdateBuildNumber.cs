using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AzurePipelinesCli.Commands
{
    public class UpdateBuildNumber : Command
    {
        public UpdateBuildNumber()
            : base("updatebuildnumber")
        {
            Description = "Update build number for current build.";

            Add(new Argument<string>("buildnumber")
            {
                Description = "build number"
            });

            Handler = CommandHandler.Create<string>(Execute);
        }

        private void Execute(string buildnumber)
        {
            var command = new PipelineCommandBuilder("build.updatebuildnumber", buildnumber).Build();

            Console.WriteLine(command);
        }
    }
}