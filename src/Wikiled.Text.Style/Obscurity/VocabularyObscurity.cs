using Wikiled.Text.Analysis.NLP.Frequency;
using Wikiled.Text.Analysis.Reflection;
using Wikiled.Text.Style.Description.Data;
using Wikiled.Text.Style.Logic;

namespace Wikiled.Text.Style.Obscurity
{
    public class VocabularyObscurity : IDataSource
    {
        public VocabularyObscurity(TextBlock text, IFrequencyListManager manager)
        {
            Internet = new SpecificObscurity(text, manager.Internet);
            BNC = new SpecificObscurity(text, manager.BNC);
            Reuters = new SpecificObscurity(text, manager.Reuters);
            Subtitles = new SpecificObscurity(text, manager.Subtitles);
        }

        [InfoCategory("Reuters", Ignore = true)]
        public SpecificObscurity Reuters { get; }

        [InfoCategory("Internet", Ignore = true)]
        public SpecificObscurity Internet { get; }

        [InfoCategory("BNC")]
        public SpecificObscurity BNC { get; }

        [InfoCategory("Subtitles", Ignore = true)]
        public SpecificObscurity Subtitles { get; }

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
