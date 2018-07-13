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
            Assert.AreEqual(0.0712, Math.Round(block.SyntaxFeatures.AdjectivesPercentage, 4));
            Assert.AreEqual(0.0712, Math.Round(block.SyntaxFeatures.AdverbsPercentage, 4));
            Assert.AreEqual(0.0188, Math.Round(block.SyntaxFeatures.QuestionPercentage, 4));
            Assert.AreEqual(0.164, Math.Round(block.SyntaxFeatures.NounsPercentage, 4));
            Assert.AreEqual(0.1855, Math.Round(block.SyntaxFeatures.VerbsPercentage, 4));
            Assert.AreEqual(0.4344, Math.Round(block.SyntaxFeatures.AdjectivesToNounsRatio, 4));
            Assert.AreEqual(0.0457, Math.Round(block.SyntaxFeatures.ProperNounsPercentage, 4));
            Assert.AreEqual(0, Math.Round(block.SyntaxFeatures.NumbersPercentage, 4));
            Assert.AreEqual(0.7336, Math.Round(block.SyntaxFeatures.POSDiversity, 4));
        }

        [Test]
        public void GetDataSecond()
        {
            var document = Global.InitDocument("cv001_19502.txt");
            var block = Global.StyleFactory.Construct(document.Sentences.ToArray());
            Assert.AreEqual(0.0732, Math.Round(block.SyntaxFeatures.AdjectivesPercentage, 4));
            Assert.AreEqual(0.0691, Math.Round(block.SyntaxFeatures.AdverbsPercentage, 4));
            Assert.AreEqual(0.0203, Math.Round(block.SyntaxFeatures.QuestionPercentage, 4));
            Assert.AreEqual(0.2398, Math.Round(block.SyntaxFeatures.NounsPercentage, 4));
            Assert.AreEqual(0.1585, Math.Round(block.SyntaxFeatures.VerbsPercentage, 4));
            Assert.AreEqual(0.3051, Math.Round(block.SyntaxFeatures.AdjectivesToNounsRatio, 4));
            Assert.AreEqual(0.0203, Math.Round(block.SyntaxFeatures.ProperNounsPercentage, 4));
            Assert.AreEqual(0, Math.Round(block.SyntaxFeatures.NumbersPercentage, 4));
            Assert.AreEqual(0.8462, Math.Round(block.SyntaxFeatures.POSDiversity, 4));
        }
    }
}