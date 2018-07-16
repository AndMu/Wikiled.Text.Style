using System;
using System.Linq;
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

        [Test]
        public void Sentiment()
        {
            var document = Global.InitDocument();
            var block = Global.StyleFactory.ConstructTextBlock(document.Sentences.ToArray());
            Assert.AreEqual(0, block.Sentiment.Sentiment);

            document.Words.First().CalculatedValue = 2;
            block = Global.StyleFactory.ConstructTextBlock(document.Sentences.ToArray());
            Assert.AreEqual(1, block.Sentiment.Sentiment);

            document.Words.Skip(1).First().CalculatedValue = -2;
            block = Global.StyleFactory.ConstructTextBlock(document.Sentences.ToArray());
            Assert.AreEqual(0, block.Sentiment.Sentiment);

            document.Words.Skip(2).First().CalculatedValue = -2;
            block = Global.StyleFactory.ConstructTextBlock(document.Sentences.ToArray());
            Assert.AreEqual(-0.5, Math.Round(block.Sentiment.Sentiment, 1));
        }
    }
}
