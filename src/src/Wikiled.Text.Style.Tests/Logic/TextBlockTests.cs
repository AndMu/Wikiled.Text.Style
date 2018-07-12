using System.Threading.Tasks;
using NUnit.Framework;

namespace Wikiled.Text.Style.Tests.Logic
{
    [TestFixture]
    public class TextBlockTests
    {
        [Test]
        public async Task GetDataFirst()
        {
            var document = await ActualWordsHandler.Instance.Loader.InitDocument().ConfigureAwait(false);
            TextBlock block = new TextBlock(ActualWordsHandler.Instance.WordsHandler, document.Sentences.ToArray());
            Assert.AreEqual(324, block.TotalLemmas);
            Assert.AreEqual(350, block.TotalWordTokens);
        }
    }
}
