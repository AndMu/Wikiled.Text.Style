using System.Collections.Generic;
using Wikiled.Text.Analysis.Structure;
using Wikiled.Text.Style.Description.Data;

namespace Wikiled.Text.Style.Description
{
    public class SentenceStyle
    {
        public SentenceStyle()
        {
            Words = new List<WordStyle>();
        }

        public List<WordStyle> Words { get; set; }

        public WordSurfaceData WordSurface { get; set; }

        public SentenceItem Sentence { get; set; }
    }
}
