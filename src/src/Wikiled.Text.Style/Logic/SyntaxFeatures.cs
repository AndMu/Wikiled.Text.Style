using System;
using System.Collections.Generic;
using System.Linq;
using Wikiled.Common.Extensions;
using Wikiled.Text.Analysis.NLP;
using Wikiled.Text.Analysis.POS;
using Wikiled.Text.Analysis.Reflection;
using Wikiled.Text.Analysis.Structure;
using Wikiled.Text.Style.Description.Data;

namespace Wikiled.Text.Style.Logic
{
    public class SyntaxFeatures : IDataSource
    {
        private readonly SyntaxData data = new SyntaxData();

        private readonly IPOSTagger tagger;

        public SyntaxFeatures(TextBlock text, IPOSTagger tagger)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            this.tagger = tagger ?? throw new ArgumentNullException(nameof(tagger));
        }

        /// <summary>
        ///     Percentage of words that are adjective
        /// </summary>
        [InfoField("Adjectives Percentage")]
        public double AdjectivesPercentage => data.AdjectivesPercentage;

        /// <summary>
        ///     Ratio of number of adjectives to nouns
        /// </summary>
        [InfoField("Adjectives To NounsRatio")]
        public double AdjectivesToNounsRatio => data.AdjectivesToNounsRatio;

        /// <summary>
        ///     Percentage of words that are adverbs
        /// </summary>
        [InfoField("Adverbs Percentage")]
        public double AdverbsPercentage => data.AdverbsPercentage;

        /// <summary>
        ///     Percentage of words that are nouns
        /// </summary>
        [InfoField("Nouns Percentage")]
        public double NounsPercentage => data.NounsPercentage;

        /// <summary>
        ///     Percentage of words that are numbers (i.e. cardinal, ordinal, nouns such as
        ///     dozen, thousands, etc.)
        /// </summary>
        [InfoField("Numbers Percentage")]
        public double NumbersPercentage => data.NumbersPercentage;

        /// <summary>
        ///     Diversity of POS tri-grams
        /// </summary>
        [InfoField("Diversity of POS tri-grams")]
        public double POSDiversity => data.POSDiversity;

        /// <summary>
        ///     Percentage of words that are proper nouns
        /// </summary>
        [InfoField("Proper Nouns Percentage")]
        public double ProperNounsPercentage => data.ProperNounsPercentage;

        /// <summary>
        ///     Percentage of words that are interrogative words (who, what, where when, etc.)
        /// </summary>
        [InfoField("Questions Percentage")]
        public double QuestionPercentage => data.QuestionPercentage;

        public TextBlock Text { get; }

        /// <summary>
        ///     Percentage of words that are verbs
        /// </summary>
        [InfoField("Verbs Percentage")]
        public double VerbsPercentage => data.VerbsPercentage;

        public SyntaxData GetData()
        {
            return (SyntaxData)data.Clone();
        }

        public void Load()
        {
            Dictionary<string, int> posTable = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var sentenceItem in Text.Sentences)
            {
                var words = sentenceItem.Words.Where(item => item.Tag.WordType != WordType.Symbol &&
                                                             item.Tag.WordType == WordType.SeparationSymbol &&
                                                             item.Tag.WordType == WordType.Unknown &&
                                                             item.Tag.Tag.HasLetters())
                    .ToArray();
                foreach (var block in words.GetNGram())
                {
                    if (!posTable.TryGetValue(block.PosMask, out var value))
                    {
                        value = 0;
                    }

                    value++;
                    posTable[block.PosMask] = value;
                }
            }


            data.AdjectivesPercentage = (double)Text.Words.Count(item => tagger.IsWordType(item, WordType.Adjective)) / Text.Words.Length;
            data.AdverbsPercentage = (double)Text.Words.Count(item => tagger.IsWordType(item, WordType.Adverb)) / Text.Words.Length;
            data.QuestionPercentage = (double)Text.Words.Count(item => item.IsQuestion()) / Text.Words.Length;
            data.NounsPercentage = (double)Text.Words.Count(item => tagger.IsWordType(item, WordType.Noun)) / Text.Words.Length;
            data.VerbsPercentage = (double)Text.Words.Count(item => tagger.IsWordType(item, WordType.Verb)) / Text.Words.Length;
            var nouns = (double)Text.Words.Count(item => tagger.IsWordType(item, WordType.Noun));
            if (nouns == 0)
            {
                data.AdjectivesToNounsRatio = 0;
            }
            else
            {
                data.AdjectivesToNounsRatio = Text.Words.Count(item => tagger.IsWordType(item, WordType.Adjective)) / nouns;
            }

            data.ProperNounsPercentage = (double)Text.Words.Count(item => tagger.IsWordType(item, POSTags.Instance.NNS)) / Text.Words.Length;
            data.NumbersPercentage = (double)Text.Words.Count(item => item.IsDigit()) / Text.Words.Length;
            if (posTable.Count == 0)
            {
                data.POSDiversity = 0;
            }
            else
            {
                data.POSDiversity = (double)posTable.Count / posTable.Sum(item => item.Value);
            }
        }
    }
}
