using Wikiled.Text.Analysis.Structure;
using Wikiled.Text.Style.Obscurity;
using Wikiled.Text.Style.Readability;
using Wikiled.Text.Style.Surface;

namespace Wikiled.Text.Style.Logic
{
    public interface ITextBlock : IDataSource
    {
        InquirerFingerPrint InquirerFinger { get; }

        WordEx[] PureWords { get; }

        ReadabilityDataSource Readability { get; }

        SentenceItem[] Sentences { get; }

        SurfaceData Surface { get; }

        SentimentFeatures Sentiment { get; }

        SyntaxFeatures SyntaxFeatures { get; }

        int TotalCharacters { get; }

        int TotalLemmas { get; }

        int TotalWordTokens { get; }

        VocabularyObscurity VocabularyObscurity { get; }

        WordEx[] Words { get; }
    }
}