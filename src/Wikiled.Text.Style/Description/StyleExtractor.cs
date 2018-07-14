using System;
using System.Linq;
using Wikiled.Text.Analysis.NLP.Frequency;
using Wikiled.Text.Analysis.NLP.NRC;
using Wikiled.Text.Analysis.POS;
using Wikiled.Text.Analysis.Structure;
using Wikiled.Text.Inquirer.Logic;
using Wikiled.Text.Style.Logic;

namespace Wikiled.Text.Style.Description
{
    public class StyleExtractor : IStyleExtractor
    {
        private readonly Document document;

        private readonly INRCDictionary nrcDictionary;

        private readonly IFrequencyListManager frequency;

        private readonly IInquirerManager inquirer;

        private readonly IPOSTagger tagger;

        public StyleExtractor(Document document, IPOSTagger tagger, INRCDictionary nrcDictionary, IFrequencyListManager frequency, IInquirerManager inquirer)
        {
            this.document = document ?? throw new ArgumentNullException(nameof(document));
            this.nrcDictionary = nrcDictionary ?? throw new ArgumentNullException(nameof(nrcDictionary));
            this.frequency = frequency ?? throw new ArgumentNullException(nameof(frequency));
            this.inquirer = inquirer ?? throw new ArgumentNullException(nameof(inquirer));
            this.tagger = tagger ?? throw new ArgumentNullException(nameof(tagger));
        }

        public DocumentStyle Extract()
        {
            TextBlock text = new TextBlock(tagger, inquirer, frequency, document.Sentences.ToArray());
            var style = new DocumentStyle();
            style.Obscrunity = text.VocabularyObscurity.GetData();
            style.CharactersSurface = text.Surface.Characters.GetData();
            style.SentenceSurface = text.Surface.Sentence.GetData();
            style.WordSurface = text.Surface.Words.GetData();
            style.Readability = text.Readability.GetData();
            style.Syntax = text.SyntaxFeatures.GetData();

            foreach (var sentence in document.Sentences.Where(item => item.Words.Count > 0))
            {
                text = new TextBlock(tagger, inquirer, frequency, new[] { sentence }, false);
                var sentenceStyle = new SentenceStyle();
                sentenceStyle.Sentence = sentence;
                style.Sentences.Add(sentenceStyle);
                text.Surface.Words.Load();
                sentenceStyle.WordSurface = text.Surface.Words.GetData();
                foreach (var word in sentence.Words)
                {
                    var wordStyle = new WordStyle(word);
                    wordStyle.Inquirer = text.InquirerFinger.GetData(word);
                    var record = nrcDictionary.FindRecord(word.Text);
                    if (record != null)
                    {
                        wordStyle.NRC = record;
                    }

                    if (wordStyle.HasValue)
                    {
                        sentenceStyle.Words.Add(wordStyle);
                    }
                }
            }

            return style;
        }
    }
}
