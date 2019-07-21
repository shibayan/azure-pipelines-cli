using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

using AzurePipelinesCli.Commands;

namespace AzurePipelinesCli
{
    class Program
    {
        static Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand("Azure Pipelines commands utility")
            {
                new Command("task", "task commands")
                {
                    new AddAttachment(),
                    new Complete(),
                    new LogDetail(),
                    new LogIssue(),
                    new PrependPath(),
                    new SetEndpoint(),
                    new SetProgress(),
                    new SetVariable(),
                    new UploadFile(),
                    new UploadSummary()
                },
                new Command("artifact", "artifact commands")
                {
                    new Associate(),
                    new Upload()
                },
                new Command("build", "build commands")
                {
                    new AddBuildTag(),
                    new UpdateBuildNumber(),
                    new UploadLog()
                },
                new Command("release", "release commands")
                {
                    new UpdateReleaseName()
                }
            };

            rootCommand.Name = "pipeline";

            return rootCommand.InvokeAsync(args);
        }
    }
}
