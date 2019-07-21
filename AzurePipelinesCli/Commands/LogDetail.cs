using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Reflection;

namespace AzurePipelinesCli.Commands
{
    public class LogDetail : Command
    {
        public LogDetail()
            : base("logdetail")
        {
            Description = "Create and update detail timeline records.";

            Add(new Option("--id", "Timeline record Guid (Required)")
            {
                Argument = new Argument<string>()
            });

            Add(new Option("--parentid", "Parent timeline record Guid")
            {
                Argument = new Argument<string>()
            });

            Add(new Option("--type", "Record type (Required for first time, can't overwrite)")
            {
                Argument = new Argument<string>()
            });

            Add(new Option("--name", "Record name (Required for first time, can't overwrite)")
            {
                Argument = new Argument<string>()
            });

            Add(new Option("--order", "order of timeline record (Required for first time, can't overwrite)")
            {
                Argument = new Argument<string>()
            });

            Add(new Option("--starttime")
            {
                Argument = new Argument<string>()
            });

            Add(new Option("--finishtime")
            {
                Argument = new Argument<string>()
            });

            Add(new Option("--progress", "percentage of completion")
            {
                Argument = new Argument<int>()
            });

            Add(new Option("--state", "Unknown|Initialized|InProgress|Completed")
            {
                Argument = new Argument<string>()
            });

            Add(new Option("--result", "Succeeded|SucceededWithIssues|Failed|Canceled|Skipped")
            {
                Argument = new Argument<string>()
            });

            Add(new Argument<string>("operation")
            {
                Description = "current operation"
            });

            var method = typeof(LogDetail).GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Instance);

            Handler = CommandHandler.Create(method);
        }

        private void Execute(string id, string parentid, string type, string name, string order, string starttime, string finishtime,
                             int? progress, string state, string result, string operation)
        {
            var command = new PipelineCommandBuilder("build.logdetail", operation)
                          .AddProperty(nameof(id), id)
                          .AddProperty(nameof(parentid), parentid)
                          .AddProperty(nameof(type), type)
                          .AddProperty(nameof(name), name)
                          .AddProperty(nameof(order), order)
                          .AddProperty(nameof(starttime), starttime)
                          .AddProperty(nameof(finishtime), finishtime)
                          .AddProperty(nameof(progress), progress)
                          .AddProperty(nameof(state), state)
                          .AddProperty(nameof(result), result)
                          .Build();

            Console.WriteLine(command);
        }
    }
}
