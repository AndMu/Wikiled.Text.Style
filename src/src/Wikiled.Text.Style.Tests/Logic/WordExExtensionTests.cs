using NUnit.Framework;

namespace Wikiled.Text.Style.Tests.Logic
{
    [TestFixture]
    public class WordExExtensionTests
    {
        [Test]
        public void CountSyllables()
        {
            WordEx word = WordExFactory.Construct(ActualWordsHandler.Instance.WordsHandler.WordFactory.CreateWord("creatures", "NN"));
            Assert.AreEqual(2, word.CountSyllables());

            word = WordExFactory.Construct(ActualWordsHandler.Instance.WordsHandler.WordFactory.CreateWord("creature", "NN"));
            Assert.AreEqual(2, word.CountSyllables());
        }
    }
}
