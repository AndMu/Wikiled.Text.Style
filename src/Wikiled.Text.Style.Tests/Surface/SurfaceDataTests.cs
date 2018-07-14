﻿using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Wikiled.Text.Style.Tests.Surface
{
    [TestFixture]
    public class SurfaceDataTests
    {
        [Test]
        public void GetDataFirst()
        {
            var document = Global.InitDocument();
            var block = Global.StyleFactory.ConstructTextBlock(document.Sentences.ToArray());
            Assert.AreEqual(119.12, Math.Round(block.Surface.Sentence.AverageLength, 2));
            Assert.AreEqual(4.3734, Math.Round(block.Surface.Words.AverageLength, 4));
            Assert.AreEqual(1.3834, Math.Round(block.Surface.Words.AverageSyllables, 4));
            Assert.AreEqual(0.0787, Math.Round(block.Surface.Words.PercentWithManySyllables, 4));
            Assert.AreEqual(0.721, Math.Round(block.Surface.Words.PercentHavingOneSyllable, 4));
            Assert.AreEqual(0.0265, Math.Round(block.Surface.Sentence.PercentOfLong, 4));
            Assert.AreEqual(0.0076, Math.Round(block.Surface.Sentence.PercentOfShort, 4));
            Assert.AreEqual(0.0076, Math.Round(block.Surface.Sentence.PercentOfQuestion, 4));
            Assert.AreEqual(0.0505, Math.Round(block.Surface.Characters.PercentOfPunctuation, 4));
            Assert.AreEqual(0.0145, Math.Round(block.Surface.Characters.PercentOfCommas, 4));
            Assert.AreEqual(0, Math.Round(block.Surface.Characters.PercentOfSemicolons, 4));
            Assert.AreEqual(0.2432, Math.Round(block.Surface.Words.PercentOfLong, 4));
            Assert.AreEqual(0.9261, Math.Round(block.Surface.Words.PercentOfTypeByToken, 4));
            Assert.AreEqual(0.0544, Math.Round(block.Surface.Words.PercentOfSubordinatingConjunctions, 4));
            Assert.AreEqual(0.0458, Math.Round(block.Surface.Words.PercentOfCoordinatingConjunctions, 4));
            Assert.AreEqual(0.0051, Math.Round(block.Surface.Sentence.PercentOfBeginningWithConjunction, 4));
            Assert.AreEqual(0.0787, Math.Round(block.Surface.Words.PercentOfArticles, 4));
            Assert.AreEqual(0.1373, Math.Round(block.Surface.Words.PercentOfPrepositions, 4));
            Assert.AreEqual(0.216, Math.Round(block.Surface.Words.PercentOfPronouns, 4));
            Assert.AreEqual(967, block.Surface.Words.TotalSyllables);
        }

        [Test]
        public void GetDataSecond()
        {
            var document = Global.InitDocument("cv001_19502.txt");
            var block = Global.StyleFactory.ConstructTextBlock(document.Sentences.ToArray());
            Assert.AreEqual(110.92, Math.Round(block.Surface.Sentence.AverageLength, 2));
            Assert.AreEqual(4.3375, Math.Round(block.Surface.Words.AverageLength, 4));
            Assert.AreEqual(1.3625, Math.Round(block.Surface.Words.AverageSyllables, 4));
            Assert.AreEqual(0.0542, Math.Round(block.Surface.Words.PercentWithManySyllables, 4));
            Assert.AreEqual(0.6958, Math.Round(block.Surface.Words.PercentHavingOneSyllable, 4));
            Assert.AreEqual(0.0227, Math.Round(block.Surface.Sentence.PercentOfLong, 4));
            Assert.AreEqual(0.0076, Math.Round(block.Surface.Sentence.PercentOfShort, 4));
            Assert.AreEqual(0.0496, Math.Round(block.Surface.Characters.PercentOfPunctuation, 4));
            Assert.AreEqual(0.0175, Math.Round(block.Surface.Characters.PercentOfCommas, 4));
            Assert.AreEqual(0, Math.Round(block.Surface.Characters.PercentOfSemicolons, 4));
            Assert.AreEqual(0.2458, Math.Round(block.Surface.Words.PercentOfLong, 4));
            Assert.AreEqual(0.9613, Math.Round(block.Surface.Words.PercentOfTypeByToken, 4));
            Assert.AreEqual(0.0375, Math.Round(block.Surface.Words.PercentOfSubordinatingConjunctions, 4));
            Assert.AreEqual(0.0333, Math.Round(block.Surface.Words.PercentOfCoordinatingConjunctions, 4));
            Assert.AreEqual(0, Math.Round(block.Surface.Sentence.PercentOfBeginningWithConjunction, 4));
            Assert.AreEqual(0.1083, Math.Round(block.Surface.Words.PercentOfArticles, 4));
            Assert.AreEqual(0.1333, Math.Round(block.Surface.Words.PercentOfPrepositions, 4));
            Assert.AreEqual(0.1708, Math.Round(block.Surface.Words.PercentOfPronouns, 4));
            Assert.AreEqual(327, block.Surface.Words.TotalSyllables);
        }
    }
}
