using NUnit.Framework;
using Wikiled.Text.Analysis.Structure;
using Wikiled.Text.Style.Logic;

namespace Wikiled.Text.Style.Tests.Logic
{
    [TestFixture]
    public class WordExExtensionTests
    {
        [Test]
        public void CountSyllables()
        {
            WordEx word = new WordEx("creatures");
            Assert.AreEqual(2, word.CountSyllables());

            word = new WordEx("creature");
            Assert.AreEqual(2, word.CountSyllables());
        }
    }
}
