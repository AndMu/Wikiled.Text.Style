using System;
using System.Collections.Generic;
using System.Linq;
using Wikiled.Text.Analysis.NLP.Frequency;
using Wikiled.Text.Analysis.Reflection;
using Wikiled.Text.Style.Description.Data;
using Wikiled.Text.Style.Logic;

namespace Wikiled.Text.Style.Obscurity
{
    public class SpecificObscurity : IDataSource
    {
        private readonly ObscurityData data = new ObscurityData();

        private readonly IWordFrequencyList list;

        public SpecificObscurity(TextBlock text, IWordFrequencyList list)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            this.list = list ?? throw new ArgumentNullException(nameof(list));
        }

        public TextBlock Text { get; }

        [InfoField("Percentage in Top 100000 Words")]
        public double Top100000Words => data.Top100000Words;

        [InfoField("Percentage in Top 10000 Words")]
        public double Top10000Words => data.Top10000Words;

        [InfoField("Percentage in Top 1000 Words")]
        public double Top1000Words => data.Top1000Words;

        [InfoField("Percentage in Top 100 Words")]
        public double Top100Words => data.Top100Words;

        [InfoField("Percentage in Top 200000 Words")]
        public double Top200000Words => data.Top200000Words;

        [InfoField("Percentage in Top 300000 Words")]
        public double Top300000Words => data.Top300000Words;

        [InfoField("Percentage in Top 50000 Words")]
        public double Top50000Words => data.Top50000Words;

        [InfoField("Percentage in Top 5000 Words")]
        public double Top5000Words => data.Top5000Words;

        [InfoField("Percentage in Top 500 Words")]
        public double Top500Words => data.Top500Words;

        public ObscurityData GetData()
        {
            return (ObscurityData)data.Clone();
        }

        public void Load()
        {
            var wordsIndexes = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var word in Text.Words)
            {
                var item = list.GetIndex(word.Text);
                if (item != null)
                {
                    wordsIndexes[word.Text] = list.GetIndex(word.Text).Index;
                }
            }

            data.Top100Words = CountPercentage(wordsIndexes, 100);
            data.Top500Words = CountPercentage(wordsIndexes, 500);
            data.Top1000Words = CountPercentage(wordsIndexes, 1000);
            data.Top5000Words = CountPercentage(wordsIndexes, 5000);
            data.Top10000Words = CountPercentage(wordsIndexes, 10000);
            data.Top50000Words = CountPercentage(wordsIndexes, 50000);
            data.Top100000Words = CountPercentage(wordsIndexes, 100000);
            data.Top200000Words = CountPercentage(wordsIndexes, 200000);
            data.Top300000Words = CountPercentage(wordsIndexes, 300000);
        }

        private double CountPercentage(Dictionary<string, int> wordsIndexes, int top)
        {
            return wordsIndexes.Count(item => item.Value <= top) / (wordsIndexes.Count + 0.01);
        }
    }
}
