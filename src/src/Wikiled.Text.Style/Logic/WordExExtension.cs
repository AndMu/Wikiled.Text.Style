using System;
using Wikiled.Text.Analysis.NLP;
using Wikiled.Text.Analysis.POS;
using Wikiled.Text.Analysis.POS.Tags;
using Wikiled.Text.Analysis.Structure;
using Wikiled.Text.Analysis.Words;

namespace Wikiled.Text.Style.Logic
{
    public static class WordExExtension
    {
        public static bool IsCoordinatingConjunction(this WordEx word)
        {
            if (word is null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            return word.Tag == POSTags.Instance.CC || WordTypeResolver.Instance.IsCoordinatingConjunctions(word.Text);
        }

        public static bool IsPronoun(this WordEx word)
        {
            if (word is null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            return word.Tag.WordType == WordType.Pronoun || WordTypeResolver.Instance.IsPronoun(word.Text);
        }

        public static int CountSyllables(this WordEx word)
        {
            if (word is null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            return EnglishSyllableCounter.Instance.CountSyllables(word.Text);
        }

        public static bool IsWordType(this IPOSTagger tagger, WordEx word, WordType type)
        {
            if (tagger is null)
            {
                throw new ArgumentNullException(nameof(tagger));
            }

            if (word is null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            return word.Tag.WordType == type || tagger.GetTag(word.Text).WordType == type;
        }

        public static bool IsDigit(this WordEx word)
        {
            if (word is null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            return word.EntityType == NamedEntities.Number ||
                   word.EntityType == NamedEntities.Percent ||
                   word.EntityType == NamedEntities.Money ||
                   word.EntityType == NamedEntities.Ordinal ||
                   word.Tag == POSTags.Instance.CD;
        }

        public static bool IsWordType(this IPOSTagger tagger, WordEx word, BasePOSType posType)
        {
            if (tagger is null)
            {
                throw new ArgumentNullException(nameof(tagger));
            }

            if (word is null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            if (posType is null)
            {
                throw new ArgumentNullException(nameof(posType));
            }

            return word.Tag == posType || tagger.GetTag(word.Text) == posType;
        }
    }
}
