using System.Threading.Tasks;
using NUnit.Framework;

namespace Wikiled.Text.Style.Tests.Obscurity
{
    [TestFixture]
    public class VocabularyObscurityTests
    {
        [Test]
        public void GetDataFirst()
        {
            var document = Global.InitDocument();
            var block = Global.StyleFactory.ConstructTextBlock(document.Sentences.ToArray());
            Assert.Greater(block.VocabularyObscurity.BNC.Top100Words, 0);
        }
    }
}
