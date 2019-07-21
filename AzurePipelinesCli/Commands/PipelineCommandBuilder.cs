using System.Collections.Generic;

namespace AzurePipelinesCli.Commands
{
    public class PipelineCommandBuilder
    {
        public PipelineCommandBuilder(string action, string value)
        {
            _action = action;
            _value = value;
        }

        private readonly string _action;
        private readonly string _value;
        private readonly List<string> _properties = new List<string>();

        public PipelineCommandBuilder AddProperty(string name, object value)
        {
            if (value != null)
            {
                _properties.Add($"{name}={value}");
            }

            return this;
        }

        public string Build()
        {
            if (_properties.Count > 0)
            {
                return $"##vso[{_action} {string.Join(';', _properties)}]{_value}";
            }

            return $"##vso[{_action}]{_value}";
        }
    }
}