using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AzurePipelinesCli.Commands
{
    public class SetVariable : Command
    {
        public SetVariable()
            : base("setvariable")
        {
            Description = "Sets a variable in the variable service of taskcontext.";

            Add(new Option("--issecret")
            {
                Description = "Optional: value is secret"
            });

            Add(new Option("--isoutput")
            {
                Description = "Optional: mark it as an output variable"
            });

            Add(new Argument<string>("variable")
            {
                Description = "variable name"
            });

            Add(new Argument<string>("value")
            {
                Description = "value for variable"
            });

            Handler = CommandHandler.Create<bool, bool, string, string>(Execute);
        }

        private void Execute(bool issecret, bool isoutput, string variable, string value)
        {
            var command = new PipelineCommandBuilder("task.setvariable", value)
                          .AddProperty(nameof(issecret), issecret)
                          .AddProperty(nameof(isoutput), isoutput)
                          .AddProperty(nameof(variable), variable)
                          .Build();

            Console.WriteLine(command);
        }
    }
}
