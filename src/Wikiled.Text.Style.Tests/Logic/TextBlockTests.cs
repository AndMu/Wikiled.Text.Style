using System.Threading.Tasks;
using NUnit.Framework;

namespace Wikiled.Text.Style.Tests.Logic
{
    [TestFixture]
    public class TextBlockTests
    {
        [Test]
        public void GetDataFirst()
        {
            var document = Global.InitDocument();
            var block = Global.StyleFactory.ConstructTextBlock(document.Sentences.ToArray());
            Assert.AreEqual(326, block.TotalLemmas);
            Assert.AreEqual(352, block.TotalWordTokens);
        }
    }
}
