using Wikiled.Text.Analysis.Structure;
using Wikiled.Text.Style.Description;

namespace Wikiled.Text.Style.Logic
{
    public interface IStyleFactory
    {
        IStyleExtractor ConstructStyle(Document document);
        ITextBlock ConstructTextBlock(SentenceItem[] sentences);
    }
}