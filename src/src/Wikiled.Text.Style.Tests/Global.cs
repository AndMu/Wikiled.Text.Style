using System;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using Wikiled.Text.Analysis.NLP.Frequency;
using Wikiled.Text.Analysis.NLP.NRC;
using Wikiled.Text.Analysis.POS;
using Wikiled.Text.Analysis.Structure;
using Wikiled.Text.Analysis.Tokenizer;
using Wikiled.Text.Analysis.Tokenizer.Pipelined;
using Wikiled.Text.Analysis.Words;
using Wikiled.Text.Inquirer.Logic;
using Wikiled.Text.Style.Logic;

namespace Wikiled.Text.Style.Tests
{
    [SetUpFixture]
    public class Global
    {
        public static NaivePOSTagger PosTagger { get; private set; }

        public static StyleFactory StyleFactory { get; private set; }

        public static SimpleWordsExtraction Extraction { get; private set; }

        [OneTimeSetUp]
        public void Setup()
        {
            PosTagger = new NaivePOSTagger(new BNCList(), WordTypeResolver.Instance);
            StyleFactory = new StyleFactory(PosTagger, new NRCDictionary(), new FrequencyListManager(), new InquirerManager());
            Extraction = new SimpleWordsExtraction(SentenceTokenizer.Create(PosTagger, true, false));
        }

        [OneTimeTearDown]
        public void Clean()
        {
        }

        public static Document InitDocument(string name = "cv000_29416.txt")
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, @"Data");
            return Extraction.GetDocument(File.ReadAllText(Path.Combine(path, name)));
        }

    }
}
