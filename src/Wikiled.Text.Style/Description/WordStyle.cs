using System;
using Newtonsoft.Json;
using Wikiled.Text.Analysis.NLP.NRC;
using Wikiled.Text.Analysis.Structure;
using Wikiled.Text.Style.Description.Data;

namespace Wikiled.Text.Style.Description
{
    public class WordStyle
    {
        public WordStyle(WordEx word)
        {
            if (word is null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            Word = word.Text;
        }

        public InquirerData Inquirer { get; set; }

        public NRCRecord NRC { get; set; }

        public string Word { get; }

        [JsonIgnore]
        public bool HasValue => (NRC != null && NRC.HasAnyValue) || Inquirer != null;
    }
}
