using System;
using Wikiled.Text.Analysis.NLP.Frequency;
using Wikiled.Text.Analysis.NLP.NRC;
using Wikiled.Text.Analysis.POS;
using Wikiled.Text.Analysis.Structure;
using Wikiled.Text.Inquirer.Logic;
using Wikiled.Text.Style.Description;

namespace Wikiled.Text.Style.Logic
{
    public class StyleFactory
    {
        private readonly INRCDictionary nrcDictionary;

        private readonly IFrequencyListManager frequency;

        private readonly IInquirerManager inquirer;

        private readonly IPOSTagger tagger;

        public StyleFactory(IPOSTagger tagger, INRCDictionary nrcDictionary, IFrequencyListManager frequency, IInquirerManager inquirer)
        {
            this.nrcDictionary = nrcDictionary ?? throw new ArgumentNullException(nameof(nrcDictionary));
            this.frequency = frequency ?? throw new ArgumentNullException(nameof(frequency));
            this.inquirer = inquirer ?? throw new ArgumentNullException(nameof(inquirer));
            this.tagger = tagger ?? throw new ArgumentNullException(nameof(tagger));
        }

        public IStyleExtractor Construct(Document document)
        {
            return new StyleExtractor(document, tagger, nrcDictionary, frequency, inquirer);
        }

        public ITextBlock Construct(SentenceItem[] sentences)
        {
            return new TextBlock(tagger, inquirer, frequency, sentences);
        }
    }
}
