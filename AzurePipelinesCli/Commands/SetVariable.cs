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

            Add(new Option("--variable", "variable name (Required)")
            {
                Argument = new Argument<string>()
            });

            Add(new Option("--issecret"));

            Add(new Argument<string>("value")
            {
                Description = "value for variable"
            });

            Handler = CommandHandler.Create<string, bool, string>(Execute);
        }

        private void Execute(string variable, bool issecret, string value)
        {
            var command = new PipelineCommandBuilder("task.setvariable", value)
                          .AddProperty(nameof(variable), variable)
                          .AddProperty(nameof(issecret), issecret)
                          .Build();

            Console.WriteLine(command);
        }
    }
}
