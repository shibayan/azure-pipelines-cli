using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AzurePipelinesCli.Commands
{
    public class SetEndpoint : Command
    {
        public SetEndpoint()
            : base("setendpoint")
        {
            Description = "Set an endpoint field with given value.";

            Add(new Option("--id", "endpoint id (Required)")
            {
                Argument = new Argument<string>()
            });

            Add(new Option("--field", "field type authParameter|dataParameter|url (Required)")
            {
                Argument = new Argument<string>()
            });

            Add(new Option("--key", "key (Required. Except for field=url)")
            {
                Argument = new Argument<string>()
            });

            Add(new Argument<string>("value")
            {
                Description = "value for key or url (Required)"
            });

            Handler = CommandHandler.Create<string, string, string, string>(Execute);
        }

        private void Execute(string id, string field, string key, string value)
        {
            var command = new PipelineCommandBuilder("task.setendpoint", value)
                          .AddProperty(nameof(id), id)
                          .AddProperty(nameof(field), field)
                          .AddProperty(nameof(key), key)
                          .Build();

            Console.WriteLine(command);
        }
    }
}
