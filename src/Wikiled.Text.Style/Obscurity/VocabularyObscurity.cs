﻿using Wikiled.Text.Analysis.NLP.Frequency;
using Wikiled.Text.Analysis.Reflection;
using Wikiled.Text.Style.Description.Data;
using Wikiled.Text.Style.Logic;

namespace Wikiled.Text.Style.Obscurity
{
    public class VocabularyObscurity : IDataSource
    {
        public VocabularyObscurity(TextBlock text, IFrequencyListManager manager)
        {
            Internet = new SpecificObscrunity(text, manager.Internet);
            BNC = new SpecificObscrunity(text, manager.BNC);
            Reuters = new SpecificObscrunity(text, manager.Reuters);
            Subtitles = new SpecificObscrunity(text, manager.Subtitles);
        }

        [InfoCategory("Reuters", Ignore = true)]
        public SpecificObscrunity Reuters { get; }

        [InfoCategory("Internet", Ignore = true)]
        public SpecificObscrunity Internet { get; }

        [InfoCategory("BNC")]
        public SpecificObscrunity BNC { get; }

        [InfoCategory("Subtitles", Ignore = true)]
        public SpecificObscrunity Subtitles { get; }

        public void Load()
        {
            Reuters.Load();
            Internet.Load();
            BNC.Load();
            Subtitles.Load();
        }

        public AllObscrunityData GetData()
        {
            return new AllObscrunityData
                   {
                       BNC = BNC.GetData(),
                       Internet = Internet.GetData(),
                       Reuters = Reuters.GetData(),
                       Subtitles = Subtitles.GetData()
                   };
        }
    }
}