using System;
using System.Linq;
using Wikiled.Text.Inquirer.Data;

namespace Wikiled.Text.Style.Logic
{
    public static class InquirerDefinitionExtensions
    {
        public static bool HasDefined(this InquirerDefinition definition, Func<InquirerRecord, bool> condition)
        {
            return definition.Records.Any(condition);
        }
    }
}
