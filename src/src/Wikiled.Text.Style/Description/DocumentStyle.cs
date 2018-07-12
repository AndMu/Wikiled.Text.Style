using System.Collections.Generic;
using Wikiled.Text.Analysis.Structure;
using Wikiled.Text.Style.Description.Data;

namespace Wikiled.Text.Style.Description
{
    public class DocumentStyle
    {
        public DocumentStyle()
        {
            Sentences = new List<SentenceStyle>();
        }

        public Document Document { get; set; }

        public List<SentenceStyle> Sentences { get; set; }

        public AllObscrunityData Obscrunity { get; set; }

        public CharactersSurfaceData CharactersSurface { get; set; }

        public SentenceSurfaceData SentenceSurface { get; set; }

        public WordSurfaceData WordSurface { get; set; }

        public ReadabilityData Readability { get; set; }

        public SyntaxData Syntax { get; set; }
    }
}
