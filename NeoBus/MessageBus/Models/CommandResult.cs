using System.Collections.Generic;

namespace NeoBus.MessageBus.Models
{
    public class CommandResult
    {
        public IDictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();

        public List<CommandError> CommandErrors { get; set; } = new List<CommandError>();

        public bool Succeeded { get; set; } = true;

        public object Data { get; set; }

        public void AddValidationError(string fieldName,string errorMessage)
        {
            if (!Errors.ContainsKey(fieldName))
            {
                Errors[fieldName] = new List<string>();
            }

            Errors[fieldName].Add(errorMessage);
        }
    }
}
