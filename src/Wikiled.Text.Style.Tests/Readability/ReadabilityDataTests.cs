﻿using System;
using NUnit.Framework;
using Wikiled.Text.Style.Readability;

namespace Wikiled.Text.Style.Tests.Readability
{
    [TestFixture]
    public class ReadabilityDataTests
    {
        [Test]
        public void GetDataFirst()
        {
            var document = Global.InitDocument();
            var block = Global.StyleFactory.ConstructTextBlock(document.Sentences.ToArray());
            Assert.AreEqual(967, block.Surface.Words.TotalSyllables);
            Assert.AreEqual(68.2994, Math.Round(block.Readability.ReadingEase, 4));
            Assert.AreEqual(FleschReadingEase.Student13to15Years, block.Readability.ReadingEaseCategory);
            Assert.AreEqual(8.9951, Math.Round(block.Readability.GradeLevel, 4));
            Assert.AreEqual(9.5028, Math.Round(block.Readability.GunningFogIndexSimplified, 4));
            Assert.AreEqual(8.2910, Math.Round(block.Readability.ColemanLiauFormula, 4));
            Assert.AreEqual(9.5776, Math.Round(block.Readability.AutomatedReadabilityIndex, 4));
            Assert.AreEqual(45.5023, Math.Round(block.Readability.LixFormula, 4));
            Assert.AreEqual(8.8045, Math.Round(block.Readability.SMOGIndex, 4));
        }

        [Test]
        public void GetDataSecond()
        {
            var document = Global.InitDocument("cv001_19502.txt");
            var block = Global.StyleFactory.ConstructTextBlock(document.Sentences.ToArray());
            Assert.AreEqual(327, block.Surface.Words.TotalSyllables);
            Assert.AreEqual(71.2675, Math.Round(block.Readability.ReadingEase, 4));
            Assert.AreEqual(FleschReadingEase.Student11Years, block.Readability.ReadingEaseCategory);
            Assert.AreEqual(8.2875, Math.Round(block.Readability.GradeLevel, 4));
            Assert.AreEqual(8.1667, Math.Round(block.Readability.GunningFogIndexSimplified, 4));
            Assert.AreEqual(7.906, Math.Round(block.Readability.ColemanLiauFormula, 4));
            Assert.AreEqual(8.7445, Math.Round(block.Readability.AutomatedReadabilityIndex, 4));
            Assert.AreEqual(44.5833, Math.Round(block.Readability.LixFormula, 4));
            Assert.AreEqual(5.3474, Math.Round(block.Readability.SMOGIndex, 4));
        }

        [Test]
        public void SReadingEaseValueSentence1()
        {
            var document = Global.Extraction.GetDocument("This is sentence, for example, taken as a reading passage unto itself, has a readability score of about");
            var block = Global.StyleFactory.ConstructTextBlock(document.Sentences.ToArray());
            Assert.AreEqual(31, block.Surface.Words.TotalSyllables);
            Assert.AreEqual(42.865, Math.Round(block.Readability.ReadingEase, 4));
            Assert.AreEqual(FleschReadingEase.Student13to15Years, block.Readability.ReadingEaseCategory);
            Assert.AreEqual(11.7522, Math.Round(block.Readability.GradeLevel, 4));
            Assert.AreEqual(9.4222, Math.Round(block.Readability.GunningFogIndexSimplified, 4));
            Assert.AreEqual(9.6689, Math.Round(block.Readability.ColemanLiauFormula, 4));
            Assert.AreEqual(9.2883, Math.Round(block.Readability.AutomatedReadabilityIndex, 4));
            Assert.AreEqual(51.3333, Math.Round(block.Readability.LixFormula, 4));
            Assert.AreEqual(10.8136, Math.Round(block.Readability.SMOGIndex, 4));
        }

        [Test]
        public void SReadingEaseValueSentence2()
        {
            var document = Global.Extraction.GetDocument("The Australian platypus is seemingly a hybrid of a mammal and reptilian");
            var block = Global.StyleFactory.ConstructTextBlock(document.Sentences.ToArray());
            Assert.AreEqual(24, block.Surface.Words.TotalSyllables);
            Assert.AreEqual(25.455, Math.Round(block.Readability.ReadingEase, 4));
            Assert.AreEqual(12.69, Math.Round(block.Readability.GradeLevel, 4));
            Assert.AreEqual(FleschReadingEase.UniversityGraduate, block.Readability.ReadingEaseCategory);
            Assert.AreEqual(11.4667, Math.Round(block.Readability.GunningFogIndexSimplified, 4));
            Assert.AreEqual(11.1333, Math.Round(block.Readability.ColemanLiauFormula, 4));
            Assert.AreEqual(8.12, Math.Round(block.Readability.AutomatedReadabilityIndex, 4));
            Assert.AreEqual(62, Math.Round(block.Readability.LixFormula, 4));
            Assert.AreEqual(13.9967, Math.Round(block.Readability.SMOGIndex, 4));
        }

        [Test]
        public void ColemanLiauFormula()
        {
            var document = Global.Extraction.GetDocument("Existing computer programs that measure readability are based largely upon subroutines which estimate number of syllables, usually by counting vowels. The shortcoming in estimating syllables is that it necessitates keypunching the prose into the computer. There is no need to estimate syllables since word length in letters is a better predictor of readability than word length in syllables. Therefore, a new readability formula was computed that has for its predictors letters per 100 words and sentences per 100 words. Both predictors can be counted by an optical scanning device, and thus the formula makes it economically feasible for an organization such as the US Office of Education to calibrate the readability of all textbooks for the public school system.");
            var block = Global.StyleFactory.ConstructTextBlock(document.Sentences.ToArray());
            Assert.AreEqual(14.5, Math.Round(block.Readability.ColemanLiauFormula, 1));
        }
    }
}
