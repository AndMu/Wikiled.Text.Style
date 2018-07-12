using System;
using System.Collections.Generic;
using System.Linq;
using Wikiled.Common.Extensions;
using Wikiled.Text.Analysis.Reflection;
using Wikiled.Text.Analysis.Structure;
using Wikiled.Text.Style.Obscurity;
using Wikiled.Text.Style.Readability;
using Wikiled.Text.Style.Surface;

namespace Wikiled.Text.Style.Logic
{
    [InfoCategory("Text Style")]
    public class TextBlock : IDataSource
    {
        private readonly Dictionary<string, List<WordEx>> lemmaDictionary = new Dictionary<string, List<WordEx>>(StringComparer.OrdinalIgnoreCase);

        private readonly Dictionary<string, List<WordEx>> wordDictionary = new Dictionary<string, List<WordEx>>(StringComparer.OrdinalIgnoreCase);

        public TextBlock(SentenceItem[] sentences, bool load = true)
        {
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
            Words = (from sentence in Sentences
                     from word in sentence.Words
                     select word).ToArray();
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

                lemmaDictionary.GetSafeCreate(handler.Extractor.GetWord(word.Text)).Add(word);
                wordDictionary.GetSafeCreate(word.Text).Add(word);
            }

            PureWords = pure.ToArray();
            VocabularyObscurity = new VocabularyObscurity(handler.FrequencyListManager, this);
            SyntaxFeatures = new SyntaxFeatures(this);
            InquirerFinger = new InquirerFingerPrint(handler.InquirerManager, this);

            if (load)
            {
                Load();
            }
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
