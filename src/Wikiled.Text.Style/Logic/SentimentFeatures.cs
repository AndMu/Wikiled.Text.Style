using System;
using Wikiled.MachineLearning.Mathematics;
using Wikiled.Text.Analysis.Reflection;

namespace Wikiled.Text.Style.Logic
{
    public class SentimentFeatures : IDataSource
    {
        public SentimentFeatures(TextBlock text)
        {
            Text = text ?? throw new System.ArgumentNullException(nameof(text));
        }

        public TextBlock Text { get; }

        [InfoField("Calculated Sentiment")]
        public double Sentiment { get; private set; }

        public void Load()
        {
            double positive = 0;
            double negative = 0;
            foreach (var sentenceItem in Text.Sentences)
            {
                foreach (var word in sentenceItem.Words)
                {
                    double? value = null;
                    if (word.Value.HasValue)
                    {
                        value = word.Value;
                    }

                    if (word.CalculatedValue.HasValue)
                    {
                        value = word.CalculatedValue.Value;
                    }

                    if (value != null)
                    {
                        if (value > 0)
                        {
                            positive += Math.Abs(value.Value);
                        }
                        else
                        {
                            negative += Math.Abs(value.Value);
                        }
                    }
                }
            }

            Sentiment = RatingCalculator.Calculate(positive, negative);
        }
    }
}
