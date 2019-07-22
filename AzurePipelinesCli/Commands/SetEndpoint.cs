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

            Add(new Argument<string>("id")
            {
                Description = "endpoint id"
            });

            Add(new Argument<string>("field")
            {
                Description = "field type authParameter|dataParameter|url"
            });

            Add(new Argument<string>("key")
            {
                Description = "key (Except for field=url)"
            });

            Add(new Argument<string>("value")
            {
                Description = "value for key or url"
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
