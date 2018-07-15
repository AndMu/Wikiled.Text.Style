using System;
using System.Collections.Generic;
using System.Text;

namespace Wikiled.Text.Style.Logic
{
    public class SentimentFeatures : IDataSource
    {
        public TextBlock Text { get; }

        public void Load()
        {
            double positive = 0;
            double negative = 0;
            foreach (var sentenceItem in Text.Sentences)
            {
                foreach (var word in sentenceItem.Words)
                {
                    if (word.Value.HasValue)
                    {
                        if (word.Value.Value > 0)
                        {
                            positive += word.Value.Value;
                        }
                        else
                        {
                            negative += word.Value.Value;
                        }
                    }
                }
            }

            var sentiment = Calculate(positive, negative);
        }

        private static double Calculate(double positive, double negative)
        {
            int coefficient = 2;
            if (positive == 0 &&
                negative == 0)
            {
                return 0;
            }

            double min = 0.0001;
            positive += min;
            negative += min;
            double rating = Math.Log(positive / negative, 2);

            if (positive == min ||
                rating < -coefficient)
            {
                rating = -coefficient;
            }
            else if (negative == min || rating > coefficient)
            {
                rating = coefficient;
            }

            rating = rating / coefficient;
            return rating;
        }

    }
}
