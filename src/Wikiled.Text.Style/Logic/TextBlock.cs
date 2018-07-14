using System;
using System.Collections.Generic;
using System.Linq;
using Wikiled.Common.Extensions;
using Wikiled.Text.Analysis.NLP;
using Wikiled.Text.Analysis.NLP.Frequency;
using Wikiled.Text.Analysis.POS;
using Wikiled.Text.Analysis.Reflection;
using Wikiled.Text.Analysis.Structure;
using Wikiled.Text.Inquirer.Logic;
using Wikiled.Text.Style.Obscurity;
using Wikiled.Text.Style.Readability;
using Wikiled.Text.Style.Surface;

namespace Wikiled.Text.Style.Logic
{
    [InfoCategory("Text Style")]
    public class TextBlock : ITextBlock
    {
        private readonly Dictionary<string, List<WordEx>> lemmaDictionary = new Dictionary<string, List<WordEx>>(StringComparer.OrdinalIgnoreCase);

        private readonly Dictionary<string, List<WordEx>> wordDictionary = new Dictionary<string, List<WordEx>>(StringComparer.OrdinalIgnoreCase);

        public TextBlock(IPOSTagger tagger, IInquirerManager inquirer, IFrequencyListManager frequency, SentenceItem[] sentences)
        {
            if (tagger is null)
            {
                throw new ArgumentNullException(nameof(tagger));
            }

            if (inquirer is null)
            {
                throw new ArgumentNullException(nameof(inquirer));
            }

            if (frequency is null)
            {
                throw new ArgumentNullException(nameof(frequency));
            }

            if (sentences is null)
            {
                throw new ArgumentNullException(nameof(sentences));
            }

            if (sentences is null)
            {
                throw new ArgumentNullException(nameof(sentences));
            }

            if (sentences.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty collection.", nameof(sentences));
            }

            Sentences = sentences;
            Surface = new SurfaceData(this);
            Readability = new ReadabilityDataSource(this);
            Words = (from sentence in Sentences from word in sentence.Words select word).ToArray();
            if (Words.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty collection.", nameof(Words));
            }

            var pure = new List<WordEx>();
            foreach (var word in Words)
            {
                if (word.Text.HasLetters() ||
                    word.Text.Length > 0 && char.IsDigit(word.Text[0]))
                {
                    pure.Add(word);
                }

                if (!string.IsNullOrEmpty(word.Raw))
                {
                    lemmaDictionary.GetSafeCreate(word.Raw).Add(word);
                }

                wordDictionary.GetSafeCreate(word.Text).Add(word);
            }

            PureWords = pure.ToArray();
            VocabularyObscurity = new VocabularyObscurity(this, frequency);
            SyntaxFeatures = new SyntaxFeatures(this, tagger);
            InquirerFinger = new InquirerFingerPrint(this, inquirer);
        }

        [InfoCategory("Inquirer Based Info", IsCollapsed = true)]
        public InquirerFingerPrint InquirerFinger { get; }

        public WordEx[] PureWords { get; }

        [InfoCategory("Readability")]
        public ReadabilityDataSource Readability { get; }

        public SentenceItem[] Sentences { get; }

        [InfoCategory("Text Surface")]
        public SurfaceData Surface { get; }

        [InfoCategory("Syntax Features")]
        public SyntaxFeatures SyntaxFeatures { get; }

        public int TotalCharacters { get; private set; }

        public int TotalLemmas => lemmaDictionary.Count;

        public int TotalWordTokens => wordDictionary.Count;

        [InfoCategory("Vocabulary Obscurity")]
        public VocabularyObscurity VocabularyObscurity { get; }

        public WordEx[] Words { get; }

        public void Load()
        {
            TotalCharacters = Sentences.Sum(item => item.CountCharacters());
            Surface.Load();
            InquirerFinger.Load();
            SyntaxFeatures.Load();
            VocabularyObscurity.Load();
            Readability.Load();
        }
    }
}
