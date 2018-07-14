using System;
using NUnit.Framework;

namespace Wikiled.Text.Style.Tests.Logic
{
    [TestFixture]
    public class SyntaxFeaturesTests
    {
        [Test]
        public void GetDataFirst()
        {
            var document = Global.InitDocument();
            var block = Global.StyleFactory.Construct(document.Sentences.ToArray());
            Assert.AreEqual(0.067, Math.Round(block.SyntaxFeatures.AdjectivesPercentage, 4));
            Assert.AreEqual(0.067, Math.Round(block.SyntaxFeatures.AdverbsPercentage, 4));
            Assert.AreEqual(0.0177, Math.Round(block.SyntaxFeatures.QuestionPercentage, 4));
            Assert.AreEqual(0.1542, Math.Round(block.SyntaxFeatures.NounsPercentage, 4));
            Assert.AreEqual(0.1745, Math.Round(block.SyntaxFeatures.VerbsPercentage, 4));
            Assert.AreEqual(0.4344, Math.Round(block.SyntaxFeatures.AdjectivesToNounsRatio, 4));
            Assert.AreEqual(0.043, Math.Round(block.SyntaxFeatures.ProperNounsPercentage, 4));
            Assert.AreEqual(0, Math.Round(block.SyntaxFeatures.NumbersPercentage, 4));
            Assert.AreEqual(0.6095, Math.Round(block.SyntaxFeatures.POSDiversity, 4));
        }

        [Test]
        public void GetDataSecond()
        {
            var document = Global.InitDocument("cv001_19502.txt");
            var block = Global.StyleFactory.Construct(document.Sentences.ToArray());
            Assert.AreEqual(0.0682, Math.Round(block.SyntaxFeatures.AdjectivesPercentage, 4));
            Assert.AreEqual(0.0644, Math.Round(block.SyntaxFeatures.AdverbsPercentage, 4));
            Assert.AreEqual(0.0189, Math.Round(block.SyntaxFeatures.QuestionPercentage, 4));
            Assert.AreEqual(0.2235, Math.Round(block.SyntaxFeatures.NounsPercentage, 4));
            Assert.AreEqual(0.1477, Math.Round(block.SyntaxFeatures.VerbsPercentage, 4));
            Assert.AreEqual(0.3051, Math.Round(block.SyntaxFeatures.AdjectivesToNounsRatio, 4));
            Assert.AreEqual(0.0189, Math.Round(block.SyntaxFeatures.ProperNounsPercentage, 4));
            Assert.AreEqual(0, Math.Round(block.SyntaxFeatures.NumbersPercentage, 4));
            Assert.AreEqual(0.7911, Math.Round(block.SyntaxFeatures.POSDiversity, 4));
        }
    }
}