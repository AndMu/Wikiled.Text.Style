namespace Wikiled.Text.Style.Description.Data
{
    public class AllObscrunityData : INLPDataItem
    {
        public ObscurityData Reuters { get; set; }

        public ObscurityData Internet { get; set; }

        public ObscurityData BNC { get; set; }

        public ObscurityData Subtitles { get; set; }

        public object Clone()
        {
            return new AllObscrunityData
            {
                Reuters = Reuters,
                Internet = Internet,
                BNC = BNC,
                Subtitles = Subtitles
            };
        }
    }
}
